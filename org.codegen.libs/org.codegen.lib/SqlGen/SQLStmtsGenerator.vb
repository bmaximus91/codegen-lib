
Imports System.IO
Imports System.Collections.Generic
Imports System.Text

Public Class SQLStmtsGenerator

    Private Property dTable As IDBTable
    Private paramPrefix As String

    Sub New(ByVal dbTable As IDBTable)
        Me._dTable = dbTable
        Me.paramPrefix = ModelGenerator.Current.dbConn.paramPrefix ' CStr(IIf(ModelGenerator.Current.DbConnStringDialect = DBUtils.enumSqlDialect.ORACLE, "?", "@"))
    End Sub

    Private Function getWherePK(pkParamName As String) As String

        If ModelGenerator.Current.DbConnStringDialect = DBUtils.enumSqlDialect.MSSQL OrElse
              ModelGenerator.Current.DbConnStringDialect = DBUtils.enumSqlDialect.ORACLE OrElse
              ModelGenerator.Current.DbConnStringDialect = DBUtils.enumSqlDialect.MYSQL Then

            Return New StringBuilder().Append(dTable.getPrimaryKeyName()).
                    Append("=").Append(paramPrefix).Append(pkParamName).ToString
        Else
            Return New StringBuilder().Append(dTable.getPrimaryKeyName()).Append("=?").ToString

        End If

    End Function

    Protected Friend Overridable Function getSelectStatement() As String

        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
        Dim vec As Dictionary(Of String, IDBField) = dTable.Fields()
        Dim fldLineCnt As Integer = 0
        Dim count As Integer = 0
        Dim sfields As List(Of String) = New List(Of String)

        sb.Append("SELECT ")

        For Each field As IDBField In vec.Values
            If Not field.isBinaryField Then
                fldLineCnt = fldLineCnt + 1
                sfields.Add(field.FieldName())

                count += 1

                If fldLineCnt = 5 AndAlso count < vec.Count Then
                    fldLineCnt = 0
                End If
            End If

        Next

        sb.Append(String.Join(",", sfields)).Append(" FROM " & DBTable.quoteObjectName(Me.dTable.SelectObject))

        Return sb.ToString()
    End Function



    Protected Friend Overridable Function deleteStatement() As String
        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
        Dim vec As Dictionary(Of String, IDBField) = dTable.Fields()

        Dim keyparam As Integer = 0
        sb.Append("DELETE FROM ")
        Dim count As Integer = 1

        For Each field As DBField In vec.Values
            If Not (field.FieldName().Equals(dTable.getPrimaryKeyName())) Then
                count += 1
            Else
                keyparam = count
                count += 1
            End If
        Next

        sb.Append(Me.dTable.quotedTableName())
        sb.Append(" WHERE ")
        sb.Append(getWherePK("0"))

        Return sb.ToString()
    End Function

    Protected Friend Overridable Function updateStatement() As String

        Dim sql As String = "" 'the sql string to be executed for this method.
        Dim sbf As System.Text.StringBuilder = New System.Text.StringBuilder() 'buffre for the parameters numbers
        Dim vec As Dictionary(Of String, IDBField) = Me.dTable.Fields() 'loads the field vector in out vector (vec).

        'Iterator a = new Iterator();
        Dim parameterCounter As Integer = 1
        Dim keyparam As Integer = 0
        Dim fldLineCnt As Integer = 0

        Dim tblName As String = Me.dTable.TableName

        For Each field As IDBField In vec.Values
            If field.IsTableField Then

                Dim skipit As Boolean = field.isBinaryField OrElse (field.isPrimaryKey)
                'Me.dbTable.isPrimaryKeyAutogenerated AndAlso _

                If Not skipit Then
                    If sbf.Length > 0 Then
                        sbf.Append(",")
                    End If
                    fldLineCnt = fldLineCnt + 1
                    If fldLineCnt = 5 Then
                        'sbf.Append(vbCrLf & vbTab)
                        fldLineCnt = 0
                    End If
                    sbf.Append(field.FieldName())

                    If ModelGenerator.Current.DbConnStringDialect = DBUtils.enumSqlDialect.MSSQL OrElse
                      ModelGenerator.Current.DbConnStringDialect = DBUtils.enumSqlDialect.ORACLE OrElse
                      ModelGenerator.Current.DbConnStringDialect = DBUtils.enumSqlDialect.MYSQL Then
                        sbf.Append("=" & paramPrefix)
                        sbf.Append(field.RuntimeFieldName())
                    Else
                        sbf.Append("=?")

                    End If

                    parameterCounter += 1
                End If
            End If
        Next


        sbf.Append(" WHERE ").Append(getWherePK(dTable.getPrimaryKeyField().RuntimeFieldName))

        sbf.Insert(0, "UPDATE " & Me.dTable.quotedTableName() & " SET ")
        Return sbf.ToString()

    End Function


    Public Overridable Function insertStatementMSSQL() As String

        Dim sbf As New List(Of String)  'buffre for the parameters numbers
        Dim sbv As New List(Of String) ' string buffer where we add/append elements through the loop

        Dim vec As Dictionary(Of String, IDBField) = Me.dTable.Fields() 'loads the field vector in out vector (vec).

        Dim fldLineCnt As Integer = 0
        Dim parameterCounter As Integer = 1
        Dim keyparam As Integer = 0

        'Dim tblName As String = "[" & Me.dbTable.TableName & "]"
        'note: do not use above [] to support generation from a foreign schema select * from [dbname.dbo.table] fails!
        Dim tblName As String = Me.dTable.TableName

        For Each field As DBField In vec.Values
            If field.IsTableField Then
                Dim skipit As Boolean = field.isBinaryField OrElse (Me.dTable.isPrimaryKeyAutogenerated AndAlso _
                        field.FieldName().ToLower().Equals(Me.dTable.getPrimaryKeyName.ToLower()))

                If Not skipit Then

                    sbf.Add(field.FieldName())
                    sbv.Add(paramPrefix & field.RuntimeFieldName())

                    parameterCounter += 1
                End If
            End If

        Next

        Return "insert into " & tblName & " (" & String.Join(",", sbf) & _
                ") values (" & String.Join(",", sbv) & ")"



    End Function


    Public Overridable Function insertStatementOracle() As String

        Dim sql As String = "" 'the sql string to be executed for this method.
        Dim sbfields As StringBuilder = New StringBuilder() 'buffre for the parameters numbers
        Dim sbvalues As StringBuilder = New StringBuilder() ' string buffer where we add/append elements through the loop
        Dim sbsp As StringBuilder = New StringBuilder() ' buffer for the set parameters
        Dim vec As Dictionary(Of String, IDBField) = Me.dTable.Fields() 'loads the field vector in out vector (vec).

        'Iterator a = new Iterator();
        Dim parameterCounter As Integer = 1
        Dim keyparam As Integer = 0
        Dim fldLineCnt As Integer = 0

        For Each field As DBField In vec.Values

            If field.IsTableField AndAlso Not field.isBinaryField AndAlso Not (field.isPrimaryKey) Then

                If (Not sbfields.ToString().Equals("")) Then
                    sbfields.Append(",")
                End If
                sbfields.Append(field.FieldName())

                If (Not sbvalues.ToString().Equals("")) Then
                    sbvalues.Append(",")
                End If
                sbvalues.Append(paramPrefix).Append(field.RuntimeFieldName)
                fldLineCnt = fldLineCnt + 1
                If fldLineCnt = 5 Then
                    fldLineCnt = 0
                End If

                parameterCounter += 1
            End If
        Next



        If Me.dTable.isPrimaryKeyAutogenerated Then
            sbfields.Append(") values (")
            sbvalues.Append(") RETURNING " & Me.dTable.getPrimaryKeyName() & " INTO ").
                    Append(paramPrefix).Append("pk").Append(";END;")
        Else
            sbfields.Append(",").Append(Me.dTable.getPrimaryKeyName()).Append(") values (")
            sbvalues.Append(",").Append(paramPrefix).Append("pk").Append(")")

        End If

        sbfields.Append(sbvalues)
        If Me.dTable.isPrimaryKeyAutogenerated Then
            sbfields.Insert(0, "BEGIN insert into " & Me.dTable.quotedTableName() & " (")
        Else
            sbfields.Insert(0, "insert into " & Me.dTable.quotedTableName() & " (")
        End If

        Return sbfields.ToString()

    End Function

    Function insertStatement() As String
        If ModelGenerator.Current.DbConnStringDialect = DBUtils.enumSqlDialect.ORACLE Then
            Return insertStatementOracle()
        Else
            Return insertStatementMSSQL()
        End If

    End Function

End Class
