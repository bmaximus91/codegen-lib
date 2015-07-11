﻿'NOTE: DO NOT ADD REFERENCES TO COM.NETU.LIB HERE, INSTEAD ADD
'THE IMPORT ON THE REFERENCES OF THE PROJECT

Imports System.Data.Linq.Mapping

'<comments>
'Template: DBMapperBase.visualBasic.txt
'************************************************************
' Class autogenerated on 11-Jul-15 10:08:12 AM by ModelGenerator
' Extends base DBMapperBase object class
' *** DO NOT change code in this class.  
'     It will be re-generated and 
'     overwritten by the code generator ****
' Instead, change code in the extender class ProjectDBMapper
'
'************************************************************
'</comments>
''
Namespace VbBusObjects.DBMappers
	<System.Runtime.InteropServices.ComVisible(False)>
	<Table(Name := "Project")> _
	<SelectObject("Project")><KeyFieldName("ProjectId")> _
    public Class ProjectDBMapper
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
                                        ByVal ParamArray params() As Object)  As Project
		
        return DirectCast(MyBase.findWhere(sWhereClause, params), Project)
    End Function
        

	Public Sub saveProject(ByVal mo As Project)
        MyBase.save(mo)
    End Sub
        
    Public Shadows Function findByKey(ByVal keyval As object) As Project

        Return DirectCast(MyBase.findByKey(keyval), Project)

    End Function
        
#End Region

#Region "getUpdateDBCommand"
        Public Overrides Function getUpdateDBCommand(ByVal modelObj As IModelObject, ByVal sql As String) As IDbCommand

             Dim p As IDataParameter = Nothing
             Dim obj as Project = DirectCast(modelObj,Project)
             Dim stmt As IDbCommand = Me.dbConn.getCommand(sql)
			stmt.Parameters.Add(Me.dbConn.getParameter(Project.STR_FLD_PROJECTNAME,obj.PrProjectName))
			stmt.Parameters.Add(Me.dbConn.getParameter(Project.STR_FLD_ISACTIVE,obj.PrIsActive))
			stmt.Parameters.Add(Me.dbConn.getParameter(Project.STR_FLD_PROJECTTYPEID,CType(IIf(obj.PrProjectTypeId Is Nothing, Nothing, Convert.ToInt64(obj.PrProjectTypeId)), Long?)))

			If (obj.isNew) Then
			Else
			'only add primary key if we are updating and as the last parameter
				stmt.Parameters.Add(Me.dbConn.getParameter(Project.STR_FLD_PROJECTID,obj.PrProjectId))
			End if

             return stmt

        End Function

#End Region
#Region "Save Children Code"
	Public overrides Sub saveChildren(mo as IModelObject )

		 dim ret as Project = DirectCast(mo, Project)
		'** Child Association:employeeprojects
		If ret.EmployeeProjectsLoaded = True then 
			Dim employeeprojectsMapper as VbBusObjects.DBMappers.EmployeeProjectDBMapper = new VbBusObjects.DBMappers.EmployeeProjectDBMapper(me.DBConn())
			employeeprojectsMapper.saveList(ret.PrEmployeeProjects())
			employeeprojectsMapper.deleteList(ret.PrEmployeeProjectsGetDeleted())
		End if
	End Sub
#End Region

#Region "Find functions"

	'''	<summary>Given an sql statement, it opens a result set, and for each record returned, it creates and loads a ModelObject. </summary>
	'''	<param name="sWhereClause">where clause to be applied to "selectall" statement 
	''' that returns one or more records from the database, corresponding to the ModelObject we are going to load </param>
	'''	<param name="params"> Parameter values to be passed to sql statement </param>
	'''	<returns> A List(Of Project) object containing all objects loaded </returns>
	'''	 
	Public shadows Function findList(ByVal sWhereClause As String, _
										ByVal ParamArray params() As Object) _
										As List(Of Project)

		dim sql as String = Me.getSqlWithWhereClause(sWhereClause)
		Dim rs As IDataReader = Nothing
		Dim molist As New List(Of Project)
						
		Try				
			rs = dbConn.getDataReaderWithParams(sql, params)
            Me.Loader.DataSource = rs
               
			Do While rs.Read
				Dim mo As IModelObject = Me.getModelInstance
				Me.Loader.load(mo)
                molist.Add(DirectCast(mo, Project))
					
			Loop

				
		Finally
			Me.dbConn.closeDataReader(rs)
		End Try

		Return molist

	End Function
    
	Public Shadows Function findList(ByVal sWhereClause As String, _
        ByVal params As List(Of IDataParameter)) _
        As List(Of Project)

        Dim sql As String = Me.getSqlWithWhereClause(sWhereClause)
        Dim rs As IDataReader = Nothing
        Dim molist As New List(Of Project)

        Try
            rs = dbConn.getDataReader(sql, params)
            Me.Loader.DataSource = rs

            Do While rs.Read
                Dim mo As IModelObject = Me.getModelInstance
                Me.Loader.load(mo)
                molist.Add(DirectCast(mo, Project))

            Loop


        Finally
            Me.dbConn.closeDataReader(rs)
        End Try

        Return molist

    End Function

	'''    
	'''	 <summary>Returns all records from database for a coresponding ModelObject </summary>
	''' <returns>List(Of Project) </returns>
	Public Function findAll() As List(Of Project)
		Return Me.findList(String.Empty)
	End Function
		
	public Overrides Property Loader() As IModelObjectLoader
		Get
			if me._loader is Nothing then 
				me._loader = New ProjectDataReaderLoader
			end If
			return me._loader
        End Get
        Set(value as IModelObjectLoader)
			me._loader = value
        end Set
    End Property

#End Region
		
	Public Overrides Function getModelInstance() As IModelObject
		return new Project()
    End Function
		
End Class

#Region " Project Loader "
	<System.Runtime.InteropServices.ComVisible(False)> _
	Public Class ProjectDataReaderLoader
		Inherits DataReaderLoader

			Public Overrides sub load(ByVal mo As IModelObject)

			Const DATAREADER_FLD_PROJECTID as Integer = 0
			Const DATAREADER_FLD_PROJECTNAME as Integer = 1
			Const DATAREADER_FLD_ISACTIVE as Integer = 2
			Const DATAREADER_FLD_PROJECTTYPEID as Integer = 3

			
            Dim obj As Project = directCast(mo, Project)
            obj.IsObjectLoading = True

			if me.reader.IsDBNull(DATAREADER_FLD_PROJECTID) = false Then
				obj.PrProjectId = Convert.ToInt64(me.reader.GetInt32(DATAREADER_FLD_PROJECTID))
			End if
			if me.reader.IsDBNull(DATAREADER_FLD_PROJECTNAME) = false Then
				obj.PrProjectName = me.reader.GetString(DATAREADER_FLD_PROJECTNAME)
			End if
			if me.reader.IsDBNull(DATAREADER_FLD_ISACTIVE) = false Then
				obj.PrIsActive = me.reader.GetInt32(DATAREADER_FLD_ISACTIVE)<>0
			End if
			if me.reader.IsDBNull(DATAREADER_FLD_PROJECTTYPEID) = false Then
				obj.PrProjectTypeId = CType(me.reader.GetInt32(DATAREADER_FLD_PROJECTTYPEID),EnumProjectType?)
			End if

            
            obj.isNew = false ' since we've just loaded from database, we mark as "old"
            obj.isDirty = False
			obj.IsObjectLoading = False
			obj.afterLoad()

            return
            
        End sub
	
	End Class

#End Region
		
	'''<summary>
    ''' Final Class with convinience shared methods for loading/saving the EmployeeRank ModelObject. 
    '''</summary>
	<System.Runtime.InteropServices.ComVisible(False)> _
	Public NotInheritable Class ProjectDataUtils

#Region "Shared ""get"" Functions "

		Public Shared Function findList(ByVal where As String, ByVal ParamArray params() As Object) _
					As List(Of Project)

            dim dbm as ProjectDBMapper = new ProjectDBMapper()
            Return dbm.findList(where, params)

        End Function
		
		Public Shared Function findList(ByVal where As String, ByVal params As List(Of IDataParameter)) _
										As List(Of Project)

            Dim dbm As ProjectDBMapper = New ProjectDBMapper()
            Return dbm.findList(where, params)

        End Function

		Public Shared Function findOne(ByVal where As String, ByVal ParamArray params() As Object) _
					As Project

            Dim dbm As ProjectDBMapper = New ProjectDBMapper()
            Return DirectCast(dbm.findWhere(where, params), Project)

        End Function
        
        
         Public Shared Function findList() As List(Of Project)
			
			return new ProjectDBMapper().findAll()
			
        End Function
        
        Public Shared Function findByKey(id as object) as Project
			
			return DirectCast( new ProjectDBMapper().findByKey(id),Project)
                        
        end function
        
		''' <summary>
        ''' Reload the Project from the database
        ''' </summary>
        ''' <remarks>
		''' use this method when you want to relad the Project 
		''' from the database, discarding any changes
		''' </remarks>
		Public Shared Sub reload(ByRef mo As Project)
			
			If mo Is Nothing Then
                Throw New System.ArgumentNullException("null object past to reload function")
            End If
            
			mo = DirectCast(New ProjectDBMapper().findByKey(mo.Id), Project)
            
        End Sub

#End Region

#Region "Shared Save and Delete Functions"
		''' <summary>
        ''' Convinience method to save a Project Object.
        ''' Important note: DO NOT CALL THIS IN A LOOP!
        ''' </summary>
        ''' <param name="ProjectObj"></param>
        ''' <remarks>
		''' Important note: DO NOT CALL THIS IN A LOOP!  
		''' This method simply instantiates a ProjectDBMapper and calls the save method
		''' </remarks>
		public shared sub saveProject(ByVal ParamArray ProjectObj() As Project)
            
            dim dbm as ProjectDBMapper = new ProjectDBMapper()
            dbm.saveList(ProjectObj.ToList)

                       
       end sub
       

       public shared sub deleteProject(ByVal ProjectObj As Project)
            
            dim dbm as ProjectDBMapper = new ProjectDBMapper()
            dbm.delete(ProjectObj)
            
        end sub
#End Region

#Region "Data Table and data row load/save "        
        Public Shared Sub saveProject(ByVal dr As DataRow, _
                                                 Optional ByRef mo As Project = Nothing)

            if mo is Nothing then 
				mo = new Project()
			end if
			
            For Each dc As DataColumn In dr.Table.Columns
                mo.setAttribute(dc.ColumnName, dr.Item(dc.ColumnName))
            Next

            call saveProject(mo)

        End Sub
        
         
        Public Shared Sub saveProject(ByVal dt As DataTable, _
                                                 Optional ByRef mo As Project = Nothing)

            For Each dr As DataRow In dt.Rows
            	call saveProject(dr,mo)
            Next
			
        End Sub
        
		 Public Shared Function loadFromDataRow(ByVal r As DataRow) As Project

            Dim a As New DataRowLoader
            Dim mo As IModelObject = new Project()
            a.DataSource = r
            a.load(mo)
            Return DirectCast(mo, Project)

        End Function

#End Region

    End Class
	
End Namespace

