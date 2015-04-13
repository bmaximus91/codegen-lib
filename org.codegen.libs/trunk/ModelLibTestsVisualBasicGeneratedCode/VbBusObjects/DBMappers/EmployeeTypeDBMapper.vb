﻿'NOTE: DO NOT ADD REFERENCES TO COM.NETU.LIB HERE, INSTEAD ADD
'THE IMPORT ON THE REFERENCES OF THE PROJECT

'<comments>
'Template: DBMapperBase.visualBasic.txt
'************************************************************
' Class autogenerated on 13-04-2015 20:33:56 by ModelGenerator
' Extends base DBMapperBase object class
' *** DO NOT change code in this class.  
'     It will be re-generated and 
'     overwritten by the code generator ****
' Instead, change code in the extender class EmployeeTypeDBMapper
'
'************************************************************
'</comments>

Namespace VbBusObjects.DBMappers
	<System.Runtime.InteropServices.ComVisible(False)> _
<AttrIsPrimaryKeyAutogenerated(false)> _
	Public Class EmployeeTypeDBMapper
	Inherits DBMapper

#Region "Constructors "
	Public Sub New(ByVal _dbConn As DBUtils)
		MyBase.new(_dbConn)
	End Sub


	Public Sub New()
		MyBase.new()
	End Sub
#End Region

#Region "Overloaded Functions"

	Public Shadows Function findWhere(ByVal sWhereClause As String, _
											ByVal ParamArray params() As Object) As EmployeeType

		Return DirectCast(MyBase.findWhere(sWhereClause, params), EmployeeType)
	End Function


	Public Sub saveEmployeeType(ByVal mo As EmployeeType)
		MyBase.save(mo)
	End Sub

	Public Shadows Function findByKey(ByVal keyval As Object) As EmployeeType

		Return DirectCast(MyBase.findByKey(keyval), EmployeeType)

	End Function

#End Region

#Region "getUpdateDBCommand"
	Public Overrides Function getUpdateDBCommand(ByVal modelObj As IModelObject, _
												 ByVal sql As String) As IDbCommand

		Dim p As IDataParameter = Nothing
		Dim obj As IEmployeeType = DirectCast(modelObj, IEmployeeType)
		Dim stmt As IDbCommand = Me.dbConn.getCommand(sql)
		stmt.Parameters.Add(Me.dbConn.getParameter("@EmployeeType", obj.EmployeeType))

		If obj.isNew Then
			'pk is not autogenerated, add primary key if we are inserting...
			stmt.Parameters.Add(Me.dbConn.getParameter("@EmployeeTypeCode", obj.EmployeeTypeCode))
		Else
			'only add primary key if we are updating and as the last parameter
			stmt.Parameters.Add(Me.dbConn.getParameter("@EmployeeTypeCode", obj.EmployeeTypeCode))

		End If '

		Return stmt

	End Function

#End Region


#Region "Find functions"

	'''	<summary>Given an sql statement, it opens a result set, and for each record returned, it creates and loads a ModelObject. </summary>
	'''	<param name="sWhereClause">where clause to be applied to "selectall" statement 
	''' that returns one or more records from the database, corresponding to the ModelObject we are going to load </param>
	'''	<param name="params"> Parameter values to be passed to sql statement </param>
	'''	<returns> A List(Of EmployeeType) object containing all objects loaded </returns>
	'''	 
	Public Shadows Function findList(ByVal sWhereClause As String, _
			 ByVal ParamArray params() As Object) _
			 As List(Of EmployeeType)

		Dim sql As String = Me.getSqlWithWhereClause(sWhereClause)
		Dim rs As IDataReader = Nothing
		Dim molist As New List(Of EmployeeType)

		Try
			rs = dbConn.getDataReaderWithParams(sql, params)
			Me.Loader.DataSource = rs

			Do While rs.Read
				Dim mo As IModelObject = Me.getModelInstance
				Me.Loader.load(mo)
				molist.Add(DirectCast(mo, EmployeeType))

			Loop


		Finally
			Me.dbConn.closeDataReader(rs)
		End Try

		Return molist

	End Function

	Public Shadows Function findList(ByVal sWhereClause As String, _
			 ByVal params As List(Of IDataParameter)) _
			 As List(Of EmployeeType)

		Dim sql As String = Me.getSqlWithWhereClause(sWhereClause)
		Dim rs As IDataReader = Nothing
		Dim molist As New List(Of EmployeeType)

		Try
			rs = dbConn.getDataReader(sql, params)
			Me.Loader.DataSource = rs

			Do While rs.Read
				Dim mo As IModelObject = Me.getModelInstance
				Me.Loader.load(mo)
				molist.Add(DirectCast(mo, EmployeeType))

			Loop


		Finally
			Me.dbConn.closeDataReader(rs)
		End Try

		Return molist

	End Function
	'''    
	'''	 <summary>Returns all records from database for a coresponding ModelObject </summary>
	''' <returns>List(Of EmployeeType) </returns>
	Public Function findAll() As List(Of EmployeeType)
		Return Me.findList(String.Empty)
	End Function

	Public Overrides Property Loader() As IModelObjectLoader
		Get
			If Me._loader Is Nothing Then
				Me._loader = New EmployeeTypeDataReaderLoader
			End If
			Return Me._loader
		End Get
		Set(value As IModelObjectLoader)
			Me._loader = value
		End Set
	End Property

#End Region

	Public Overrides Function getModelInstance() As IModelObject
		Return EmployeeTypeFactory.Create()
	End Function

    End Class

#Region " EmployeeType Loader "
	<System.Runtime.InteropServices.ComVisible(False)> _
	Public Class EmployeeTypeDataReaderLoader
		Inherits DataReaderLoader

		Public Overrides Sub load(ByVal mo As IModelObject)

			Const DATAREADER_FLD_EMPLOYEETYPECODE As Integer = 0
			Const DATAREADER_FLD_EMPLOYEETYPE As Integer = 1


			Dim obj As EmployeeType = DirectCast(mo, EmployeeType)
			obj.IsObjectLoading = True

			If Me.reader.IsDBNull(DATAREADER_FLD_EMPLOYEETYPECODE) = False Then
				obj.EmployeeTypeCode = Me.reader.GetString(DATAREADER_FLD_EMPLOYEETYPECODE)
			End If
			If Me.reader.IsDBNull(DATAREADER_FLD_EMPLOYEETYPE) = False Then
				obj.EmployeeType = Me.reader.GetString(DATAREADER_FLD_EMPLOYEETYPE)
			End If


			obj.isNew = False ' since we've just loaded from database, we mark as "old"
			obj.isDirty = False
			obj.IsObjectLoading = False
			obj.afterLoad()

			Return

		End Sub

	End Class

#End Region

	'''<summary>
	''' Final Class with convinience shared methods for loading/saving the EmployeeRank ModelObject. 
	'''</summary>
	<System.Runtime.InteropServices.ComVisible(False)> _
	Public NotInheritable Class EmployeeTypeDataUtils

#Region "Shared ""get"" Functions "

		Public Shared Function findList(ByVal where As String, ByVal ParamArray params() As Object) _
		   As List(Of EmployeeType)

			Dim dbm As EmployeeTypeDBMapper = New EmployeeTypeDBMapper()
			Return dbm.findList(where, params)

		End Function

		Public Shared Function findList(ByVal where As String, ByVal params As List(Of IDataParameter)) _
				As List(Of EmployeeType)

			Dim dbm As EmployeeTypeDBMapper = New EmployeeTypeDBMapper()
			Return dbm.findList(where, params)

		End Function

		Public Shared Function findOne(ByVal where As String, ByVal ParamArray params() As Object) _
		   As EmployeeType

			Dim dbm As EmployeeTypeDBMapper = New EmployeeTypeDBMapper()
			Return DirectCast(dbm.findWhere(where, params), EmployeeType)

		End Function


		Public Shared Function findList() As List(Of EmployeeType)

			Return New EmployeeTypeDBMapper().findAll()

		End Function

		Public Shared Function findByKey(id As Object) As EmployeeType

			Return DirectCast(New EmployeeTypeDBMapper().findByKey(id), EmployeeType)

		End Function

		''' <summary>
		''' Reload the EmployeeType from the database
		''' </summary>
		''' <remarks>
		''' use this method when you want to relad the EmployeeType 
		''' from the database, discarding any changes
		''' </remarks>
		Public Shared Sub reload(ByRef mo As EmployeeType)

			If mo Is Nothing Then
				Throw New System.ArgumentNullException("null object past to reload function")
			End If

			mo = DirectCast(New EmployeeTypeDBMapper().findByKey(mo.Id), EmployeeType)

		End Sub

#End Region

#Region "Shared Save and Delete Functions"
		''' <summary>
		''' Convinience method to save a EmployeeType Object.
		''' Important note: DO NOT CALL THIS IN A LOOP!
		''' </summary>
		''' <param name="EmployeeTypeObj"></param>
		''' <remarks>
		''' Important note: DO NOT CALL THIS IN A LOOP!  
		''' This method simply instantiates a EmployeeTypeDBMapper and calls the save method
		''' </remarks>
		Public Shared Sub saveEmployeeType(ByVal ParamArray EmployeeTypeObj() As EmployeeType)

			Dim dbm As EmployeeTypeDBMapper = New EmployeeTypeDBMapper()
			dbm.saveList(EmployeeTypeObj.ToList)


		End Sub


		Public Shared Sub deleteEmployeeType(ByVal EmployeeTypeObj As EmployeeType)

			Dim dbm As EmployeeTypeDBMapper = New EmployeeTypeDBMapper()
			dbm.delete(EmployeeTypeObj)

		End Sub
#End Region

#Region "Data Table and data row load/save "
		Public Shared Sub saveEmployeeType(ByVal dr As DataRow, _
												 Optional ByRef mo As EmployeeType = Nothing)

			If mo Is Nothing Then
				mo = EmployeeTypeFactory.Create()
			End If

			For Each dc As DataColumn In dr.Table.Columns
				mo.setAttribute(dc.ColumnName, dr.Item(dc.ColumnName))
			Next

			Call saveEmployeeType(mo)

		End Sub


		Public Shared Sub saveEmployeeType(ByVal dt As DataTable, _
												 Optional ByRef mo As EmployeeType = Nothing)

			For Each dr As DataRow In dt.Rows
				Call saveEmployeeType(dr, mo)
			Next

		End Sub

		Public Shared Function loadFromDataRow(ByVal r As DataRow) As EmployeeType

			Dim a As New DataRowLoader
			Dim mo As IModelObject = EmployeeTypeFactory.Create
			a.DataSource = r
			a.load(mo)
			Return DirectCast(mo, EmployeeType)

		End Function

#End Region

	End Class

End Namespace

