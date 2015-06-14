Option Strict On

Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Data.Linq

''' <summary>
''' Database Utility class to fascilitate sql statements execution
''' </summary>
''' <remarks></remarks>
Public MustInherit Class DBUtils
    Implements IDisposable

#Region "db provider"

    Private Shared _dbrovider As IDBUtilsProvider

    Public Shared Property dbProvider As IDBUtilsProvider
        Get
            If _dbrovider Is Nothing Then
                _dbrovider = New DBUtilsProviderFromConfig
            End If
            Return _dbrovider
        End Get
        Set(ByVal value As IDBUtilsProvider)
            _dbrovider = value
        End Set
    End Property

    ''' <summary>
    ''' Constructs a DBUtilsBase class from the connection string stored in the configuration file.
    ''' <seealso cref="DBConfig"></seealso>
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Current() As DBUtils

        Return dbProvider.getDBUtils

    End Function


    ''' <summary>
    ''' Constructs a DBUtils class from the connection string passed.
    ''' </summary>
    ''' <param name="connString"></param>
    ''' <param name="sqlConnType"></param>
    ''' <param name="iDialect"></param>
    ''' <param name="logFile"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getFromConnString(ByVal connString As String, _
                                             ByVal sqlConnType As enumConnType, _
                                             ByVal iDialect As enumSqlDialect, _
                                             Optional ByVal logFile As String = "") As DBUtils

        Dim ret As DBUtils

        Select Case sqlConnType

            Case enumConnType.CONN_MSSQL
                ret = New MSSQLUtils()
                ret.sqldialect = enumSqlDialect.MSSQL

            Case enumConnType.CONN_OLEDB
                ret = New OLEDBUtils
                ret.sqldialect = iDialect

            Case Else
                Throw New ArgumentException("Cannot Identify SQL Connection Type.  Enter 1 for SQL or 3 for OLE DB")
        End Select

        ret.ConnString = connString
        logFilePath = logFile
        Return ret

    End Function

#End Region

#Region "enums"

    ''' <summary>
    ''' Connection types
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enumConnType
        CONN_MSSQL = 1
        CONN_ORACLE = 2
        CONN_OLEDB = 3
    End Enum

    ''' <summary>
    ''' eSqlDialect enumeration, indicating the sql dialect that our database uses.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enumSqlDialect
        MSSQL = 1
        JET = 2
        ORACLE = 3
        MYSQL = 4
        COMMON = 5
    End Enum

#End Region

#Region "field Declarations"

    Protected Shared stmtCache As ConditionalWeakTable(Of String, String) = New ConditionalWeakTable(Of String, String)

    Protected p_connstring As String
    Protected p_conntype As enumConnType
    Protected p_string_quote_prefix As String
    Protected p_date_pattern As String
    Protected p_dbNow As String
    Protected p_like_char As String
    Protected p_paramPrefix As String
    Protected p_sqldialect As enumSqlDialect
    Protected p_Trans As System.Data.IDbTransaction
    Protected p_Conn As IDbConnection
    Protected p_params As IDataParameterCollection

    Private Shared p_logStnms As Boolean
    Private Shared p_logFilePath As String

#End Region

#Region "Class constructors"

    Protected Sub New()

    End Sub

#End Region

#Region "properties"
    ''' <summary>
    ''' Parameter prefix
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Friend Property paramPrefix() As String
        Get
            Return p_paramPrefix
        End Get
        Set(ByVal Value As String)
            p_paramPrefix = Value
        End Set

    End Property

    Public Function dbContext() As DataContext

        Return New DataContext(Me.Connection)

    End Function

    ''' <summary>
    ''' SQL Dialect
    ''' <seealso cref="org.model.lib.db.DBUtils.enumSqlDialect"></seealso>
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property sqldialect() As enumSqlDialect
        Get
            Return p_sqldialect
        End Get

        Set(ByVal Value As enumSqlDialect)
            p_sqldialect = Value
            If p_sqldialect = enumSqlDialect.JET Then
            ElseIf p_sqldialect = enumSqlDialect.MSSQL Then
                p_conntype = enumConnType.CONN_MSSQL
            ElseIf p_sqldialect = enumSqlDialect.ORACLE Then
                p_conntype = enumConnType.CONN_ORACLE
            End If
            Me.setSpecialChars()

        End Set
    End Property

    Private Shared Property logFilePath() As String
        Get
            Return p_logFilePath
        End Get
        Set(ByVal Value As String)
            p_logFilePath = Value
            p_logStnms = p_logFilePath.Trim <> ""
        End Set

    End Property

    Friend Shared Sub logStatement(ByVal msg As String)

        If p_logStnms Then
            Dim _file As StreamWriter
            If File.Exists(p_logFilePath) = False Then
                ' Create a file to write to.
                _file = File.CreateText(p_logFilePath)
            Else
                _file = File.AppendText(p_logFilePath)
            End If

            Try
                _file.WriteLine(Format(Now, "dd/MM/yyyy hh:mm:ss tt:") & msg)
                _file.Flush()

            Catch ex As Exception
                'just ignore the error
            Finally
                If Not _file Is Nothing Then _file.Close()
            End Try

        End If

    End Sub

#End Region

#Region "Transactions"

    Public Property Transaction() As IDbTransaction
        Get
            Return p_Trans
        End Get
        Set(ByVal Value As IDbTransaction)
            p_Trans = Value
        End Set
    End Property

    ''' <summary>
    ''' Commits the current transaction and closes the connection to the database.
    ''' before committing, the class checks if a transaction is active.
    ''' If not, statement is ignored.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function commitTrans() As Boolean

        If Not p_Trans Is Nothing Then

            p_Trans.Commit()
            p_Trans.Dispose()
            p_Trans = Nothing

        End If
        Me.closeConnection()
        commitTrans = True

    End Function

    ''' <summary>
    ''' Rollbacks the current transaction and closes the connection to the database.
    ''' Before Rollback, the class checks if a transaction is active.
    ''' If not, statement is ignored.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function rollbackTrans() As Boolean

        If Not p_Trans Is Nothing Then
            Try
                'p_Trans.Connection.State = ConnectionState.Fetching
                p_Trans.Rollback()
                p_Trans.Dispose()

            Finally

                p_Trans = Nothing
            End Try

        End If

        Me.closeConnection()

        rollbackTrans = True

    End Function

    ''' <summary>
    ''' Returns true if a transaction is active (ie started by a beginTrans call).
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property inTrans() As Boolean
        Get
            Return (p_Trans Is Nothing = False)
        End Get
    End Property

    ''' <summary>
    ''' Starts a transaction and 
    ''' Sets the flag true that transaction is active.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function beginTrans() As Boolean

        If Not p_Trans Is Nothing Then
            Throw New ApplicationException("Nested Transactions not supported")
        End If

        p_Trans = Me.Connection.BeginTransaction

    End Function
#End Region

#Region "Connection"

    Protected Friend Sub closeConnection()

        If Me.Connection Is Nothing Then Exit Sub

        If Me.inTrans Then Exit Sub 'if we are in a transaction, do not close the connection.  It is closed in rollback/commit

        If Me.Connection.State = ConnectionState.Open Then
            Me.Connection.Close()
            Call logStatement("close connection")
        End If

    End Sub

    ''' <summary>
    ''' Connection String of database connection
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ConnString() As String
        Get
            Return p_connstring
        End Get

        Set(ByVal Value As String)
            p_connstring = Value

            If Not p_Conn Is Nothing Then
                If p_Conn.State = ConnectionState.Open Then
                    p_Conn.Close()
                End If

            End If
            Me.Connection = Nothing
        End Set

    End Property


    ''' <summary>
    ''' Sets/Returns a ADO.NET connection object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public MustOverride Property Connection() As IDbConnection

    Protected Friend MustOverride Sub setSpecialChars()

    ''' <summary>
    ''' Gets/Sets the connection type
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ConnType() As enumConnType
        Get
            Return p_conntype
        End Get
        Set(ByVal Value As enumConnType)
            p_conntype = Value
        End Set
    End Property

#End Region

#Region "Utility Functions"

    Public MustOverride Function getAdapter(ByVal sql As String) As IDbDataAdapter
    Public MustOverride Function fillTypedDataSet(ByVal ds As DataSet, ByVal tablename As String, ByVal sql As String) As DataSet


    Public Function getDataSet(ByVal sql As String) As DataSet

        Dim ds As New DataSet
        Dim adapter As IDbDataAdapter

        Try

            adapter = Me.getAdapter(sql)
            If Me.inTrans Then
                adapter.SelectCommand.Transaction = p_Trans
            End If

            adapter.Fill(ds)

        Catch ex As Exception
            Throw New ApplicationException(ex.Message & vbCrLf & sql)

        Finally

            Me.closeConnection()
        End Try

        Return ds

    End Function

    Private Const QMARK As String = "?"

    ''' <summary>
    ''' Support for positional placeholders in sql server.
    ''' By default, the sql server driver supprorts only **named** parameters
    ''' </summary>
    ''' <param name="sql">SQL to execute.  Symbols ? and {i} are supported</param>
    ''' <param name="params">Paraneters of sql</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function replaceParameterPlaceHolders(ByVal sql As String, ByVal ParamArray params() As Object) As String

        Dim ret As String = String.Empty

        stmtCache.TryGetValue(sql, ret)
        If ret IsNot Nothing Then
            Return ret
        End If

        If sql.IndexOf(QMARK) >= 0 Then

            Dim c As String() = sql.Split(CChar(QMARK))
            For i As Integer = 0 To c.Length - 1

                ret &= c(i)

                If i < c.Length - 1 Then
                    ret &= Me.paramPrefix & i
                End If
            Next


        Else
            ret = sql
            For i As Integer = 0 To params.Length - 1
                ret = ret.Replace("{" & i & "}", Me.paramPrefix & i)
            Next

        End If

        stmtCache.Add(sql, ret)
        Return ret

    End Function

    Public Function getDataSetWithParams(ByVal sql As String, ByVal ParamArray params() As IDataParameter) As DataSet
        Dim ds As New DataSet

        Try

            Dim adapter As IDbDataAdapter = Me.getAdapter(sql)
            If Me.inTrans Then
                adapter.SelectCommand.Transaction = p_Trans
            End If

            For i As Integer = 0 To params.Length - 1
                adapter.SelectCommand.Parameters.Add(params(i))
            Next
            adapter.Fill(ds)
            logStatement("getDataSetWithParams:" & sql)

        Catch ex As Exception
            Throw New ApplicationException(ex.Message & vbCrLf & sql)

        Finally

            Me.closeConnection()
        End Try

        Return ds
    End Function

    Public Function getDataSetWithParams(ByVal sql As String, ByVal ParamArray params() As Object) As DataSet

        Dim ds As New DataSet
        Dim adapter As IDbDataAdapter

        Try

            sql = replaceParameterPlaceHolders(sql, params.Length - 1)

            adapter = Me.getAdapter(sql)
            If Me.inTrans Then
                adapter.SelectCommand.Transaction = p_Trans

            End If

            For i As Integer = 0 To params.Length - 1
                Dim iParam As System.Data.IDataParameter
                iParam = Me.getParameter(Me.paramPrefix & i)
                iParam.Value = params(i)
                adapter.SelectCommand.Parameters.Add(iParam)
            Next
            adapter.Fill(ds)
            logStatement("getDataSetWithParams:" & sql)

        Catch ex As Exception
            Throw New ApplicationException(ex.Message & vbCrLf & sql)

        Finally

            Me.closeConnection()
        End Try

        Return ds
    End Function



    ''' <summary>
    ''' Closes a DataReader and the connection to the database.  Typically used when opening a datareader and 
    ''' processing results.
    ''' <code source="C:\vs2008Projects\org.codegen.lib.vb\org.codegen.lib.db\examples.vb" region="DataReader and NullChecker Examples" lang="vbnet" title="DataReader Example" />
    ''' </summary>
    ''' <param name="dr">DataReader object to close.</param>
    Public Sub closeDataReader(ByVal dr As IDataReader)

        If dr Is Nothing Then Exit Sub

        If dr.IsClosed = False Then
            dr.Close()
        End If

        Me.closeConnection()
        dr = Nothing

    End Sub

    ''' <summary>
    ''' Executes the sql passed and returns a DataTable filled with the results of the sql.
    ''' <code source="C:\vs2008Projects\org.codegen.lib.vb\org.codegen.lib.db\examples.vb" region="DataTableExample" lang="vbnet" title="getDataTable Example" />
    ''' </summary>
    ''' <param name="sql">SQL Statement to be executed</param>
    ''' <param name="stablename">Table name of returned datatable, default "table1"</param>
    ''' <returns>a DataTable filled with the results of the sql</returns>
    Public Overridable Function getDataTable(ByVal sql As String, Optional ByVal stablename As String = "table1") As DataTable

        Dim ds As DataSet = Me.getDataSet(sql)
        If ds.Tables.Count > 0 Then
            ds.Tables(0).TableName = stablename
            Return ds.Tables(0)
        Else
            Return Nothing
        End If

    End Function

    ''' <summary>
    ''' Behaves just like DBUtilsBase.getDataTable
    ''' but it allows for a parametrized SQL statement
    ''' </summary>
    ''' <param name="sql">SQL Statement to be executed</param>
    ''' <param name="params">ParamArray of parameter values</param>
    ''' <returns>a DataTable filled with the results of the sql</returns>
    Public Function getDataTableWithParams(ByVal sql As String, ByVal ParamArray params() As Object) As DataTable

        Dim ds As DataSet = Me.getDataSetWithParams(sql, params)
        If ds.Tables.Count > 0 Then
            Return ds.Tables(0)
        Else
            Return Nothing
        End If

    End Function

    ''' <summary>
    ''' Behaves just like <see cref="DBUtils.getSValue">DBUtilsBase.getSValue</see> but it returns a Double value
    ''' </summary>
    ''' <param name="sql">SQL statement to execute</param>
    ''' <returns>String value returned by first row, first column.  If no rows are returned, returns 0. 
    ''' If value of first column is DBNULL, returns 0</returns>
    ''' <remarks></remarks>
    ''' <seealso cref="DBUtils.getSValue"></seealso>
    Function getDblValue(ByVal sql As String) As Double

        Dim rs As IDataReader
        Dim ret As Double

        Try
            rs = Me.getDataReader(sql)
            If rs.Read Then
                If IsDBNull(rs.GetValue(0)) OrElse Not IsNumeric(rs.GetValue(0)) Then

                Else
                    ret = CDbl(rs.GetValue(0))
                End If

            End If

        Finally
            Call Me.closeDataReader(rs)
        End Try

        Return ret

    End Function

    ''' <summary>
    ''' Behaves just like <see cref="DBUtils.getSValue">DBUtilsBase.getSValue</see> but it returns an Integer value
    ''' </summary>
    ''' <param name="sql">SQL statement to execute</param>
    ''' <returns>String value returned by first row, first column.  If no rows are returned, returns 0. 
    ''' If value of first column is DBNULL, returns 0</returns>
    ''' <remarks></remarks>
    ''' <seealso cref="DBUtils.getSValue"></seealso>
    Function getIntValue(ByVal sql As String) As Int32

        Return CInt(getLngValue(sql))

    End Function

    ''' <summary>
    ''' Behaves just like <see cref="DBUtils.getSValue">DBUtilsBase.getSValue</see> but it returns a Long value
    ''' </summary>
    ''' <param name="sql">SQL statement to execute</param>
    ''' <returns>String value returned by first row, first column.  If no rows are returned, returns 0. 
    ''' If value of first column is DBNULL, returns 0</returns>
    ''' <remarks></remarks>
    ''' <seealso cref="DBUtils.getSValue"></seealso>
    Function getLngValue(ByVal sql As String, ByVal ParamArray params() As Object) As Int32
        Dim rs As IDataReader
        Try
            rs = Me.getDataReaderWithParams(sql, params)
            If rs.Read Then
                If IsDBNull(rs.GetValue(0)) Then
                    getLngValue = 0
                Else
                    If (Not IsNumeric(rs.GetValue(0))) Then
                        Throw New ApplicationException("Non Numeric value returned in call to getLngValue ")
                    End If

                    getLngValue = CInt(rs.GetValue(0))

                End If

            End If

        Finally
            Call Me.closeDataReader(rs)
        End Try

    End Function

    Public Function getObjectValue(ByVal sql As String, ByVal ParamArray params() As Object) As Object
        Dim rs As IDataReader
        Try
            rs = Me.getDataReaderWithParams(sql, params)
            If rs.Read Then
                If Not IsDBNull(rs.GetValue(0)) Then
                    Return rs.GetValue(0)
                End If

            End If

        Finally
            Call Me.closeDataReader(rs)
        End Try


        Return Nothing
    End Function

    ''' <summary>
    ''' Behaves just like <see cref="DBUtils.getSValue">DBUtilsBase.getSValue</see> but it allows for a parametarized SQL, and it returns a Long value
    ''' <code source="C:\vs2008Projects\org.codegen.lib.vb\org.codegen.lib.db\examples.vb" region="getSValueWithParams" lang="vbnet" title="getSValueWithParams Example" />
    ''' </summary>
    ''' <param name="sql">SQL statement to execute</param>
    ''' <returns>String value returned by first row, first column.  If no rows are returned, returns 0. 
    ''' If value of first column is DBNULL, returns 0</returns>
    ''' <remarks></remarks>
    ''' <seealso cref="DBUtils.getSValueWithParams"></seealso>
    Function getLngValueWithParams(ByVal sql As String, ByVal ParamArray params() As Object) As Int32

        Dim rs As IDataReader

        Try
            getLngValueWithParams = 0

            rs = Me.getDataReaderWithParams(sql, params)
            If rs.Read Then
                If IsDBNull(rs.GetValue(0)) OrElse Not IsNumeric(rs.GetValue(0)) Then
                    getLngValueWithParams = 0
                Else
                    getLngValueWithParams = CInt(rs.GetValue(0))
                End If
            End If

        Finally
            Call Me.closeDataReader(rs)
        End Try

    End Function

    Public ReadOnly Property dbnow() As String
        Get
            Return p_dbNow
        End Get

    End Property

    ''' <summary>
    ''' Behaves just like <see cref="DBUtils.getSValue">DBUtilsBase.getSValue</see> but it allows for a parametarized SQL
    ''' <code source="C:\vs2008Projects\org.codegen.lib.vb\org.codegen.lib.db\examples.vb" region="getSValueWithParams" lang="vbnet" title="getSValueWithParams Example" />
    ''' </summary>
    ''' <param name="sql">SQL statement to execute</param>
    ''' <returns>String value returned by first row, first column.  If no rows are returned, returns String.Empty. 
    ''' If value of first column is DBNULL, returns String.Empty</returns>
    ''' <remarks></remarks>
    ''' <seealso cref="DBUtils.getSValue"></seealso>
    Function getSValueWithParams(ByVal sql As String, _
                                 ByVal ParamArray params() As Object) As String

        Dim rs As IDataReader

        Try
            rs = Me.getDataReaderWithParams(sql, params)
            If rs.Read() Then
                'rs.MoveFirst
                Return NullChecker.strNull(rs(0))
            End If
            Return String.Empty
        Finally
            Call Me.closeDataReader(rs)
        End Try

    End Function

    ''' <summary>
    ''' This function opens a datareader, reads the first row and returns the value of the first field 
    ''' as a <b>date</b>.
    ''' <code source="C:\vs2008Projects\org.codegen.lib.vb\org.codegen.lib.db\examples.vb" region="DtValueExample" lang="vbnet" title="DtValue Example" />
    ''' </summary>
    ''' <param name="sql">SQL statement to execute</param>
    ''' <returns>String value returned by first row, first column.  If no rows are returned, returns String.Empty. 
    ''' If value of first column is DBNULL, returns String.Empty</returns>
    ''' <remarks></remarks>
    Function getDtValue(ByVal sql As String) As Date

        Dim rs As IDataReader

        Try
            rs = Me.getDataReader(sql)
            If rs.Read() Then
                'rs.MoveFirst
                getDtValue = NullChecker.dateNull(rs(0))
            End If

        Finally
            Call Me.closeDataReader(rs)
        End Try

    End Function

    ''' <summary>
    ''' This function opens a datareader, reads the first row and returns the value of the first field 
    ''' as a string.
    ''' <code source="C:\vs2008Projects\org.codegen.lib.vb\org.codegen.lib.db\examples.vb" region="SValueExample" lang="vbnet" title="SValue Example" />
    ''' </summary>
    ''' <param name="sql">SQL statement to execute</param>
    ''' <returns>String value returned by first row, first column.  If no rows are returned, returns String.Empty. 
    ''' If value of first column is DBNULL, returns String.Empty</returns>
    ''' <remarks></remarks>
    Function getSValue(ByVal sql As String) As String

        Dim rs As IDataReader
        Dim ret As String = String.Empty
        Try
            rs = Me.getDataReader(sql)
            If rs.Read() Then
                'rs.MoveFirst
                ret = NullChecker.strNull(rs(0))
            End If

        Finally
            Call Me.closeDataReader(rs)
        End Try
        Return ret

    End Function

#End Region

#Region "Parameters"

    Public Function getCommand(Optional ByVal sql As String = "") As IDbCommand

        Dim icomm As IDbCommand = Me.Connection.CreateCommand()
        If sql <> String.Empty Then
            icomm.CommandText = sql
        End If
        icomm.Transaction = Me.Transaction
        icomm.CommandType = CommandType.Text
        Return icomm

    End Function

    Public MustOverride Function getParameter() As IDataParameter


    Public Function getParameter(ByVal _paramName As String, ByVal val As Byte()) As IDataParameter
        Dim tmp As IDataParameter = Me.getParameter
        tmp.ParameterName = _paramName
        tmp.DbType = DbType.Binary

        If val Is Nothing Then
            tmp.Value = DBNull.Value
        Else
            tmp.Value = val
        End If

        Return tmp

    End Function

    Public Function getParameter(ByVal _paramName As String, ByVal val As DateTime?) As IDataParameter
        Dim tmp As IDataParameter = Me.getParameter
        tmp.ParameterName = _paramName
        tmp.DbType = DbType.DateTime

        If val.HasValue = False Then
            tmp.Value = DBNull.Value
        Else
            Dim org As DateTime = val.Value
            Dim truncatedDateTime As DateTime = New DateTime(org.Year, org.Month, org.Day, org.Hour, org.Minute, org.Second)
            'Debug.WriteLine("Saving datetime:" & truncatedDateTime)
            tmp.Value = truncatedDateTime
        End If

        Return tmp

    End Function

    Public Function getParameter(ByVal _paramName As String, ByVal val As Int16?) As IDataParameter
        Dim tmp As IDataParameter = Me.getParameter
        tmp.ParameterName = _paramName
        tmp.DbType = DbType.Int16

        If val.HasValue = False Then
            tmp.Value = DBNull.Value
        Else
            tmp.Value = val
        End If

        Return tmp
    End Function

    Public Function getParameter(ByVal _paramName As String, ByVal val As Int64?) As IDataParameter
        Dim tmp As IDataParameter = Me.getParameter
        tmp.ParameterName = _paramName
        tmp.DbType = DbType.Int64

        If val.HasValue = False Then
            tmp.Value = DBNull.Value
        Else
            tmp.Value = val
        End If

        Return tmp
    End Function

    Public Function getParameter(ByVal _paramName As String, ByVal val As Boolean?) As IDataParameter
        Dim tmp As IDataParameter = Me.getParameter
        tmp.ParameterName = _paramName
        tmp.DbType = DbType.Int32

        If val.HasValue = False Then
            tmp.Value = 0
        Else
            tmp.Value = val
        End If

        Return tmp
    End Function

    Public Function getParameter(ByVal _paramName As String, ByVal val As Single?) As IDataParameter
        Dim tmp As IDataParameter = Me.getParameter
        tmp.ParameterName = _paramName
        tmp.DbType = DbType.Single

        If val.HasValue = False Then
            tmp.Value = DBNull.Value
        Else
            tmp.Value = val
        End If

        Return tmp
    End Function

    Public Function getParameter(ByVal _paramName As String, ByVal val As Double?) As IDataParameter
        Dim tmp As IDataParameter = Me.getParameter
        tmp.ParameterName = _paramName
        tmp.DbType = DbType.Double

        If val.HasValue = False Then
            tmp.Value = DBNull.Value
        Else
            tmp.Value = val
        End If

        Return tmp
    End Function

    Public Function getParameter(ByVal _paramName As String, ByVal val As Decimal?) As IDataParameter
        Dim tmp As IDataParameter = Me.getParameter
        tmp.ParameterName = _paramName
        tmp.DbType = DbType.Decimal

        If val.HasValue = False Then
            tmp.Value = DBNull.Value
        Else
            tmp.Value = val
        End If

        Return tmp
    End Function

    Public Function getParameter(ByVal _paramName As String, ByVal val As Integer?) As IDataParameter
        Dim tmp As IDataParameter = Me.getParameter
        tmp.ParameterName = _paramName
        tmp.DbType = DbType.Int32

        If val.HasValue = False Then
            tmp.Value = DBNull.Value
        Else
            tmp.Value = val
        End If

        Return tmp
    End Function

    Public Function getParameter(ByVal _paramName As String, ByVal val As String) As IDataParameter
        Dim tmp As IDataParameter = Me.getParameter
        tmp.ParameterName = _paramName
        tmp.DbType = DbType.String

        If String.IsNullOrEmpty(val) Then
            tmp.Value = DBNull.Value
        Else
            tmp.Value = val
        End If

        Return tmp
    End Function


    ''' <summary>
    ''' Returns a GUID parameter
    ''' </summary>
    ''' <param name="_paramName"></param>
    ''' <param name="val"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getParameter(ByVal _paramName As String, ByVal val As Guid?) As IDataParameter

        Dim tmp As IDataParameter = Me.getParameter
        tmp.ParameterName = _paramName
        tmp.DbType = DbType.Guid

        If val Is Nothing Then
            tmp.Value = DBNull.Value
        Else
            tmp.Value = val
        End If

        Return tmp
    End Function


    Public Function getParameter(ByVal _paramName As String) As IDataParameter
        Dim tmp As IDataParameter = Me.getParameter
        tmp.ParameterName = _paramName
        Return tmp
    End Function

    Public Function getParameterInOut(ByVal _paramName As String) As IDataParameter

        Dim tmp As IDataParameter = Me.getParameter(_paramName)
        tmp.Direction = ParameterDirection.InputOutput
        Return tmp

    End Function

    Public Function getOutputParameterValue(ByVal _paramName As String) As Object

        If p_params Is Nothing Then Return Nothing

        Dim tmp As IDataParameter = CType(p_params.Item(_paramName), IDataParameter)
        If tmp Is Nothing Then Return Nothing

        Return tmp.Value

    End Function

#End Region

#Region "SQL"

    ''' <summary>
    ''' <code source="C:\vs2008Projects\org.codegen.lib.vb\org.codegen.common.tests\DBUtilsTest.vb" region="Parameters Example, with output parameter" lang="vbnet" title="Parameters Example, with output parameter" />
    ''' </summary>
    ''' <param name="sql">Paratarized sql statement</param>
    ''' <param name="params">Parameters collection</param>
    ''' <remarks></remarks>
    ''' 
    Public Sub executeSQLWithParams(ByVal sql As String, ByVal params As System.Collections.Generic.List(Of IDataParameter))

        Dim icomm As IDbCommand = Me.Connection.CreateCommand()
        icomm.CommandText = sql
        icomm.Transaction = Me.Transaction
        icomm.CommandType = CommandType.Text

        For i As Integer = 0 To params.Count - 1
            Dim iParam As System.Data.IDataParameter = params(i)
            icomm.Parameters.Add(iParam)
        Next

        Try
            icomm.ExecuteNonQuery()

        Finally
            icomm.Dispose()
        End Try
        logStatement("getDataSetWithParams:" & sql)

    End Sub



    ''' <summary>
    ''' Executes an sql statement of type UPDATE, INSERT or DELETE, but allows for paramerized sql
    ''' </summary>
    ''' <param name="sql"></param>
    ''' <param name="params"></param>
    ''' <remarks></remarks>
    Public Sub executeSQLWithParams(ByVal sql As String, ByVal ParamArray params() As Object)

        Dim icomm As IDbCommand = Me.Connection.CreateCommand()
        icomm.CommandText = replaceParameterPlaceHolders(sql, params)
        icomm.Transaction = Me.Transaction
        icomm.CommandType = CommandType.Text
        Me.setParamValues(icomm, params)

        Try
            icomm.ExecuteNonQuery()

        Finally
            icomm.Dispose()
        End Try


    End Sub

    Private Sub setParamValues(ByVal icomm As IDbCommand, ByVal ParamArray params() As Object)

        For i As Integer = 0 To params.Length - 1
            Dim iParam As System.Data.IDataParameter
            If TypeOf (params(i)) Is Date AndAlso CDate(params(i)) = NullChecker.NULL_DATE Then
                iParam = Me.getParameter(String.Concat(Me.paramPrefix, i))
            Else
                iParam = Me.getParameter(String.Concat(Me.paramPrefix, i))
                iParam.Value = params(i)
            End If

            icomm.Parameters.Add(iParam)
        Next

    End Sub

    Public Sub executeSQLWithParamsIdentity(ByVal sql As String, ByVal ParamArray params() As Object)

        Const STR_LEFT As String = "{"
        Const STR_RIGHT As String = "}"

        For i As Integer = 0 To params.Length - 1
            sql = sql.Replace(String.Concat(STR_LEFT, i, STR_RIGHT), String.Concat(Me.paramPrefix, i))
        Next

        Dim icomm As IDbCommand = Me.Connection.CreateCommand()
        icomm.CommandText = sql
        icomm.Transaction = Me.Transaction
        icomm.CommandType = CommandType.Text

        Me.setParamValues(icomm, params)

        Try
            icomm.ExecuteNonQuery()
        Finally
            icomm.Dispose()
        End Try
        logStatement("getDataSetWithParams:" & sql)

    End Sub

    Public Function getLastIdentity() As Integer
        Dim ireader As IDataReader
        Dim icomm As IDbCommand = Me.getCommand

        Try
            icomm.CommandText = Me.getIdentitySQL
            icomm.CommandType = CommandType.Text
            ireader = icomm.ExecuteReader()
            If ireader.Read() Then
                Return CInt(ireader.GetValue(0))
            End If

        Finally
            Call Me.closeDataReader(ireader)
        End Try

    End Function


    Public MustOverride Function getIdentitySQL() As String

    ''' <summary>
    ''' Executes a stored procedure with parameters. How to use:
    ''' </summary>
    ''' <param name="spSql">Pass only the name of the stored procedure</param>
    ''' <param name="spParams">Pass a list of parameters, with the same name as the parameters 
    ''' of the stored procedure</param>
    ''' <remarks></remarks>
    Public Sub executeSP(ByVal spSql As String, ByVal spParams As System.Collections.Generic.List(Of IDataParameter))

        Dim icomm As IDbCommand

        Try

            icomm = Me.Connection.CreateCommand()
            icomm.Transaction = p_Trans
            icomm.CommandText = spSql
            icomm.CommandType = CommandType.StoredProcedure

            For Each param As IDataParameter In spParams
                icomm.Parameters.Add(param)
            Next
            icomm.ExecuteNonQuery()

            Me.p_params = Nothing
            Me.p_params = icomm.Parameters
            logStatement("Execute:" & spSql)

        Catch e As Exception
            Throw New ApplicationException(e.Message & vbCrLf & _
                                           "Error SQL:" & getStmtAndParamsAsString(icomm))

        Finally
            Me.closeConnection()
            icomm.Dispose()

        End Try

    End Sub
    ''' <summary>
    ''' Executes an sql statement of type UPDATE, INSERT or DELETE
    ''' </summary>
    ''' <param name="sql"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function executeSQL(ByVal sql As String) As Boolean

        Dim icomm As IDbCommand

        Try

            icomm = Me.Connection.CreateCommand()
            icomm.Transaction = p_Trans
            icomm.CommandText = sql
            icomm.CommandType = CommandType.Text
            icomm.ExecuteNonQuery()

            logStatement("Execute:" & sql)

        Catch e As Exception
            Throw New ApplicationException(e.Message & vbCrLf & _
                                           "Error SQL:" & getStmtAndParamsAsString(icomm))

        Finally
            Me.closeConnection()
            icomm.Dispose()

        End Try

    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sql"></param>
    ''' <param name="spParams"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getDataReader(ByVal sql As String, ByVal spParams As List(Of IDataParameter)) As IDataReader

        Dim rsado As IDataReader
        Dim icomm As IDbCommand

        Try

            icomm = Me.Connection.CreateCommand()
            icomm.CommandText = sql
            icomm.CommandType = CommandType.Text
            For Each param As IDataParameter In spParams
                icomm.Parameters.Add(param)
            Next
            If Me.inTrans Then
                icomm.Transaction = p_Trans
                rsado = icomm.ExecuteReader(CommandBehavior.Default)
            Else
                rsado = icomm.ExecuteReader(CommandBehavior.CloseConnection)
            End If

            logStatement("getDataReader:" & sql)
            icomm.Dispose()
            icomm = Nothing

        Catch e As Exception
            Throw New ApplicationException(e.Message & vbCrLf & _
                                           "Error SQL:" & getStmtAndParamsAsString(icomm))

        Finally
            If Not icomm Is Nothing Then
                icomm.Dispose()
            End If

        End Try

        Return rsado

    End Function
    ''' <summary>
    ''' <seealso cref="DBUtils.getDataReader"></seealso>
    ''' <code source="C:\vs2008Projects\org.codegen.lib.vb\org.codegen.lib.db\examples.vb" region="DataReader with parameters and NullChecker Examples" lang="vbnet" title="DataReader With Parameters Example" />
    ''' </summary>
    ''' <param name="sql"></param>
    ''' <param name="params"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Public Function getDataReaderWithParams(ByVal sql As String, ByVal ParamArray params() As Object) As IDataReader

        Dim rs As IDataReader
        Dim icomm As IDbCommand = Me.Connection.CreateCommand()

        sql = replaceParameterPlaceHolders(sql, params)

        icomm.CommandText = sql
        icomm.Transaction = Me.Transaction
        icomm.CommandType = CommandType.Text


        setParamValues(icomm, params)
        Try
            rs = icomm.ExecuteReader

        Catch e As Exception
            Throw New ApplicationException(e.Message & vbCrLf & _
                                           "Error SQL:" & getStmtAndParamsAsString(icomm))


        Finally
            icomm.Dispose()
        End Try
        logStatement("getDataReaderWithParams:" & sql)
        Return rs

    End Function


    ''' <summary>
    ''' Opens a datareader for SQL results processing
    ''' <code source="C:\vs2008Projects\org.codegen.lib.vb\org.codegen.lib.db\examples.vb" region="DataReader and NullChecker Examples" lang="vbnet" title="DataReader Example" />
    ''' </summary>
    ''' <param name="sql"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getDataReader(ByVal sql As String) As IDataReader

        Dim rsado As IDataReader
        Dim icomm As IDbCommand

        Try

            icomm = Me.Connection.CreateCommand()
            logStatement("getDataReader:" & sql)
            icomm.CommandText = sql
            icomm.CommandType = CommandType.Text

            If Me.inTrans Then
                icomm.Transaction = p_Trans
                rsado = icomm.ExecuteReader(CommandBehavior.Default)
            Else
                rsado = icomm.ExecuteReader(CommandBehavior.CloseConnection)
                Call logStatement("Close Connection")
            End If

        Catch e As Exception
            Throw New ApplicationException(e.Message & vbCrLf & _
                                           "Error SQL:" & getStmtAndParamsAsString(icomm))

        Finally
            If Not icomm Is Nothing Then
                icomm.Dispose()
            End If

        End Try

        Return rsado

    End Function

    ''' <summary>
    ''' Used to built a string 
    ''' </summary>
    ''' <param name="pstmt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getStmtAndParamsAsString(ByVal pstmt As System.Data.IDbCommand) As String

        Dim err As String = ""

        If pstmt IsNot Nothing Then
            err = "SQL: " & pstmt.CommandText & vbCrLf
            err &= "Parameters: " & vbCrLf
            For Each iparam As IDataParameter In pstmt.Parameters
                err &= "Name  :" & iparam.ParameterName & vbCrLf
                err &= "DBType:" & iparam.DbType.ToString & vbCrLf
                If IsDBNull(iparam.Value) Then
                    err &= "Value : NULL" & vbCrLf
                Else
                    err &= "Value :" & CStr(iparam.Value) & vbCrLf
                End If

                err &= "------------" & vbCrLf
            Next

        End If
        Return err
    End Function


#End Region

#Region "Schema"

    Public Overridable Function GetDbObjectsDataTable() As DataTable

        Dim dt As DataTable
        Dim sql As String = String.Empty

        If Me.sqldialect = DBUtils.enumSqlDialect.MSSQL Then
            sql = "select '0' as id,' -- none -- ' as objName from sysobjects union SELECT [name] as id, [name] AS OBJNAME FROM sysobjects O WHERE (xtype = 'V') OR (xtype = 'U') ORDER BY 2"

        ElseIf Me.sqldialect = DBUtils.enumSqlDialect.ORACLE Then
            sql = "select '0' as id,' -- none -- ' as ""objName"" from dual union SELECT table_name as id, table_name AS ""objName"" FROM user_tables ORDER BY 2"

        Else
            Throw New NotSupportedException()

        End If
        dt = Me.getDataTable(sql)
        Return dt

    End Function

#End Region

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                Me.rollbackTrans()
                Me.closeConnection()
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class