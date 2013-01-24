﻿
'NOTE: DO NOT ADD REFERENCES TO COM.NETU.LIB HERE, INSTEAD ADD
'THE IMPORT ON THE REFERENCES OF THE PROJECT

Imports System.Collections.Generic
Imports System.Xml.Serialization
'<comments>
'************************************************************
'
' Class autogenerated on 24/01/2013 6:48:52 PM by ModelGenerator
' Extends base model object class
' *** DO NOT change code in this class.  
'     It will be re-generated and 
'     overwritten by the code generator ****
' Instead, change code in the extender class EmployeeProject
'
'************************************************************
'</comments>
Namespace BusObjects

#Region "Interface"
Public Interface IEmployeeProject: Inherits IModelObject
	Property EmployeeProjectId as System.Int32
	Property EPEmployeeId as Nullable (of System.Int32)
	Property EPProjectId as Nullable (of System.Int32)
	Property AssignDate as Nullable (of System.DateTime)
	Property EndDate as Nullable (of System.DateTime)
	Property Rate as Nullable (of System.Decimal)
End Interface
#End region 


	<Serializable(), System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
	Public class EmployeeProjectBase
		Inherits ModelObject
		Implements IEquatable(Of EmployeeProjectBase),
		IEmployeeProject 

#Region "Constructor"
    
    public sub New()
		Me.addValidator(New EmployeeProjectRequiredFieldsValidator)
    End Sub

#End Region

#Region "Children and Parents"
	
	Public Overrides Function getChildren() As List(Of ModelObject) 
		Dim ret as New List(Of ModelObject)()
		
		return ret
	End Function
	
	Public Overrides Function getParents() As List(Of ModelObject)
		Dim ret as New List(Of ModelObject)()
		
		return ret
	End Function

#End Region
#Region "Field CONSTANTS"

			public Const STR_FLD_EMPLOYEEPROJECTID as String = "EmployeeProjectId"
			public Const STR_FLD_EPEMPLOYEEID as String = "EPEmployeeId"
			public Const STR_FLD_EPPROJECTID as String = "EPProjectId"
			public Const STR_FLD_ASSIGNDATE as String = "AssignDate"
			public Const STR_FLD_ENDDATE as String = "EndDate"
			public Const STR_FLD_RATE as String = "Rate"


		public Const FLD_EMPLOYEEPROJECTID as Integer = 0
		public Const FLD_EPEMPLOYEEID as Integer = 1
		public Const FLD_EPPROJECTID as Integer = 2
		public Const FLD_ASSIGNDATE as Integer = 3
		public Const FLD_ENDDATE as Integer = 4
		public Const FLD_RATE as Integer = 5



        '''<summary> Returns the names of fields in the object as a string array.
        ''' Useful in automatically setting/getting values from UI objects (windows or web Form)</summary>
        ''' <returns> string array </returns>	 
        Public Overrides Function getFieldList() As String()
            Return New String() {STR_FLD_EMPLOYEEPROJECTID,STR_FLD_EPEMPLOYEEID,STR_FLD_EPPROJECTID,STR_FLD_ASSIGNDATE,STR_FLD_ENDDATE,STR_FLD_RATE}
        End Function
        
#END Region

#Region "Field Declarations"


	Private _EmployeeProjectId as System.Int32
	Private _EPEmployeeId as Nullable (of System.Int32) = Nothing
	Private _EPProjectId as Nullable (of System.Int32) = Nothing
	Private _AssignDate as Nullable (of System.DateTime) = Nothing
	Private _EndDate as Nullable (of System.DateTime) = Nothing
	Private _Rate as Nullable (of System.Decimal) = Nothing


#END Region

#Region "Field Properties"

	Public Overridable Property EmployeeProjectId as System.Int32 _ 
		Implements IEmployeeProject.EmployeeProjectId
	Get 
		return _EmployeeProjectId
	End Get 
	Set
		if ModelObject.valueChanged(_EmployeeProjectId, value) then
			if me.IsObjectLoading = false then
				me.isDirty = true
				me.setFieldChanged(STR_FLD_EMPLOYEEPROJECTID)
			End If
			me._EmployeeProjectId = value

			me.raiseBroadcastIdChange()

		End if
	End Set 
	End Property 
Public Sub setEmployeeProjectId(ByVal val As String)
	If IsNumeric(val) Then
		Me.EmployeeProjectId = CInt(val)
	ElseIf String.IsNullOrEmpty(val) Then
		Me.EmployeeProjectId = Nothing
	Else
		Throw new ApplicationException("Invalid Integer Number, field:EmployeeProjectId, value:" & val)
	End If
End Sub
	Public Overridable Property EPEmployeeId as Nullable (of System.Int32) _ 
		Implements IEmployeeProject.EPEmployeeId
	Get 
		return _EPEmployeeId
	End Get 
	Set(ByVal value As Nullable (of System.Int32))
		if ModelObject.valueChanged(_EPEmployeeId, value) then
			if me.IsObjectLoading = false then
				me.isDirty = true
				me.setFieldChanged(STR_FLD_EPEMPLOYEEID)
			End If
			me._EPEmployeeId = value

		End if
	End Set 
	End Property 
Public Sub setEPEmployeeId(ByVal val As String)
	If IsNumeric(val) Then
		Me.EPEmployeeId = CInt(val)
	ElseIf String.IsNullOrEmpty(val) Then
		Me.EPEmployeeId = Nothing
	Else
		Throw new ApplicationException("Invalid Integer Number, field:EPEmployeeId, value:" & val)
	End If
End Sub
	Public Overridable Property EPProjectId as Nullable (of System.Int32) _ 
		Implements IEmployeeProject.EPProjectId
	Get 
		return _EPProjectId
	End Get 
	Set(ByVal value As Nullable (of System.Int32))
		if ModelObject.valueChanged(_EPProjectId, value) then
			if me.IsObjectLoading = false then
				me.isDirty = true
				me.setFieldChanged(STR_FLD_EPPROJECTID)
			End If
			me._EPProjectId = value

		End if
	End Set 
	End Property 
Public Sub setEPProjectId(ByVal val As String)
	If IsNumeric(val) Then
		Me.EPProjectId = CInt(val)
	ElseIf String.IsNullOrEmpty(val) Then
		Me.EPProjectId = Nothing
	Else
		Throw new ApplicationException("Invalid Integer Number, field:EPProjectId, value:" & val)
	End If
End Sub
	Public Overridable Property AssignDate as Nullable (of System.DateTime) _ 
		Implements IEmployeeProject.AssignDate
	Get 
		return _AssignDate
	End Get 
	Set(ByVal value As Nullable (of System.DateTime))
		if ModelObject.valueChanged(_AssignDate, value) then
			if me.IsObjectLoading = false then
				me.isDirty = true
				me.setFieldChanged(STR_FLD_ASSIGNDATE)
			End If
			me._AssignDate = value

		End if
	End Set 
	End Property 
Public Sub setAssignDate(ByVal val As String)
	If IsDate(val) Then
		Me.AssignDate = CDate(val)
	ElseIf String.IsNullOrEmpty(val) Then
		Me.AssignDate = Nothing
	Else
		Throw new ApplicationException("Invalid Date, field:AssignDate, value:" & val)
	End If
End Sub
	Public Overridable Property EndDate as Nullable (of System.DateTime) _ 
		Implements IEmployeeProject.EndDate
	Get 
		return _EndDate
	End Get 
	Set(ByVal value As Nullable (of System.DateTime))
		if ModelObject.valueChanged(_EndDate, value) then
			if me.IsObjectLoading = false then
				me.isDirty = true
				me.setFieldChanged(STR_FLD_ENDDATE)
			End If
			me._EndDate = value

		End if
	End Set 
	End Property 
Public Sub setEndDate(ByVal val As String)
	If IsDate(val) Then
		Me.EndDate = CDate(val)
	ElseIf String.IsNullOrEmpty(val) Then
		Me.EndDate = Nothing
	Else
		Throw new ApplicationException("Invalid Date, field:EndDate, value:" & val)
	End If
End Sub
	Public Overridable Property Rate as Nullable (of System.Decimal) _ 
		Implements IEmployeeProject.Rate
	Get 
		return _Rate
	End Get 
	Set(ByVal value As Nullable (of System.Decimal))
		if ModelObject.valueChanged(_Rate, value) then
			if me.IsObjectLoading = false then
				me.isDirty = true
				me.setFieldChanged(STR_FLD_RATE)
			End If
			me._Rate = value

		End if
	End Set 
	End Property 
Public Sub setRate(ByVal val As String)
	If IsNumeric(val) Then
		Me.Rate = CDec(val)
	ElseIf String.IsNullOrEmpty(val) Then
		Me.Rate = Nothing
	Else
		Throw new ApplicationException("Invalid Decimal Number, field:Rate, value:" & val)
	End If
End Sub

#End Region

#Region "Getters/Setters of values by field index/name"
    Public Overloads Overrides Function getAttribute(ByVal fieldKey As Integer) As Object
		

		select case fieldKey
		case FLD_EMPLOYEEPROJECTID
			return me.EmployeeProjectId
		case FLD_EPEMPLOYEEID
			return me.EPEmployeeId
		case FLD_EPPROJECTID
			return me.EPProjectId
		case FLD_ASSIGNDATE
			return me.AssignDate
		case FLD_ENDDATE
			return me.EndDate
		case FLD_RATE
			return me.Rate
		case else
			return nothing
		end select


    End Function

    Public Overloads Overrides Function getAttribute(ByVal fieldKey As String) As Object
		fieldKey = fieldKey.ToLower

		if fieldKey=STR_FLD_EMPLOYEEPROJECTID.ToLower() Then
			return me.EmployeeProjectId
		else if fieldKey=STR_FLD_EPEMPLOYEEID.ToLower() Then
			return me.EPEmployeeId
		else if fieldKey=STR_FLD_EPPROJECTID.ToLower() Then
			return me.EPProjectId
		else if fieldKey=STR_FLD_ASSIGNDATE.ToLower() Then
			return me.AssignDate
		else if fieldKey=STR_FLD_ENDDATE.ToLower() Then
			return me.EndDate
		else if fieldKey=STR_FLD_RATE.ToLower() Then
			return me.Rate
		else
			return nothing
		end If
    End Function

    Public Overloads Overrides Sub setAttribute(ByVal fieldKey As Integer, ByVal val As Object)
		
		Select Case fieldKey
		case FLD_EMPLOYEEPROJECTID
			If Val Is DBNull.Value OrElse Val Is Nothing Then
				Me.EmployeeProjectId = Nothing
			Else
				Me.EmployeeProjectId=CInt(val)
			End If
			return
		case FLD_EPEMPLOYEEID
			If Val Is DBNull.Value OrElse Val Is Nothing Then
				Me.EPEmployeeId = Nothing
			Else
				Me.EPEmployeeId=CInt(val)
			End If
			return
		case FLD_EPPROJECTID
			If Val Is DBNull.Value OrElse Val Is Nothing Then
				Me.EPProjectId = Nothing
			Else
				Me.EPProjectId=CInt(val)
			End If
			return
		case FLD_ASSIGNDATE
			If Val Is DBNull.Value OrElse Val Is Nothing Then
				Me.AssignDate = Nothing
			Else
				Me.AssignDate=CDate(val)
			End If
			return
		case FLD_ENDDATE
			If Val Is DBNull.Value OrElse Val Is Nothing Then
				Me.EndDate = Nothing
			Else
				Me.EndDate=CDate(val)
			End If
			return
		case FLD_RATE
			If Val Is DBNull.Value OrElse Val Is Nothing Then
				Me.Rate = Nothing
			Else
				Me.Rate=CDec(val)
			End If
			return
		case else
			return
		end select


    End Sub

    Public Overloads Overrides Sub setAttribute(ByVal fieldKey As String, ByVal val As Object)
		
		fieldKey = fieldKey.ToLower
		
		if  fieldKey=STR_FLD_EMPLOYEEPROJECTID.ToLower() Then
			If Val Is DBNull.Value OrElse Val Is Nothing Then
				Me.EmployeeProjectId = Nothing
			Else
				Me.EmployeeProjectId=CInt(val)
			End If
			return
		else if  fieldKey=STR_FLD_EPEMPLOYEEID.ToLower() Then
			If Val Is DBNull.Value OrElse Val Is Nothing Then
				Me.EPEmployeeId = Nothing
			Else
				Me.EPEmployeeId=CInt(val)
			End If
			return
		else if  fieldKey=STR_FLD_EPPROJECTID.ToLower() Then
			If Val Is DBNull.Value OrElse Val Is Nothing Then
				Me.EPProjectId = Nothing
			Else
				Me.EPProjectId=CInt(val)
			End If
			return
		else if  fieldKey=STR_FLD_ASSIGNDATE.ToLower() Then
			If Val Is DBNull.Value OrElse Val Is Nothing Then
				Me.AssignDate = Nothing
			Else
				Me.AssignDate=CDate(val)
			End If
			return
		else if  fieldKey=STR_FLD_ENDDATE.ToLower() Then
			If Val Is DBNull.Value OrElse Val Is Nothing Then
				Me.EndDate = Nothing
			Else
				Me.EndDate=CDate(val)
			End If
			return
		else if  fieldKey=STR_FLD_RATE.ToLower() Then
			If Val Is DBNull.Value OrElse Val Is Nothing Then
				Me.Rate = Nothing
			Else
				Me.Rate=CDec(val)
			End If
			return
		end If

    End Sub

#End Region


#Region "Overrides of GetHashCode and Equals "
	
	Public Overloads Function Equals(ByVal other As EmployeeProjectBase) As Boolean _     
		Implements System.IEquatable(Of EmployeeProjectBase).Equals       
		
			'typesafe equals, checks for equality of fields
			If other Is Nothing Then Return False       
			If other Is Me Then Return True
		
			Return me.EmployeeProjectId= other.EmployeeProjectId _
				AndAlso me.EPEmployeeId.GetValueOrDefault = other.EPEmployeeId.GetValueOrDefault _
				AndAlso me.EPProjectId.GetValueOrDefault = other.EPProjectId.GetValueOrDefault _
				AndAlso me.AssignDate.GetValueOrDefault = other.AssignDate.GetValueOrDefault _
				AndAlso me.EndDate.GetValueOrDefault = other.EndDate.GetValueOrDefault _
				AndAlso me.Rate.GetValueOrDefault = other.Rate.GetValueOrDefault
				
	End Function
	
	Public Overrides Function GetHashCode() As Integer
        'using Xor has the advantage of not overflowing the integer.
        Return me.EmployeeProjectId.GetHashCode _
				Xor me.EPEmployeeId.GetHashCode _
				Xor me.EPProjectId.GetHashCode _
				Xor me.AssignDate.GetHashCode _
				Xor me.EndDate.GetHashCode _
				Xor me.Rate.GetHashCode 
    
    End Function
    
    Public Overloads Overrides Function Equals(ByVal Obj As Object) As Boolean
		
		Dim temp = TryCast(obj, EmployeeProjectBase)       
		If temp IsNot Nothing Then 
			Return Me.Equals(temp)
		Else
			Return False
		End If

    End Function
	
	Public Shared Operator =(ByVal obj1 As EmployeeProjectBase, ByVal obj2 As EmployeeProjectBase) As Boolean       
		Return Object.Equals(obj1 ,obj2)    
	End Operator    
	
	Public Shared Operator <>(ByVal obj1 As EmployeeProjectBase, ByVal obj2 As EmployeeProjectBase) As Boolean       
		Return Not (obj1 = obj2)    
	End Operator

#End Region

#Region "Copy and sort"

	Public Overrides Function copy() as IModelObject
		'creates a copy
		
		'NOTE: we can't cast from HolidayBase to Holiday, so below we 
        'instantiate a Holiday, NOT a HolidayBase object
        Dim ret as EmployeeProject = EmployeeProjectFactory.Create()
            
				ret.EmployeeProjectId = me.EmployeeProjectId
		ret.EPEmployeeId = me.EPEmployeeId
		ret.EPProjectId = me.EPProjectId
		ret.AssignDate = me.AssignDate
		ret.EndDate = me.EndDate
		ret.Rate = me.Rate

		
		return ret
		
	End Function
	
	Public Overrides Sub merge(other as IModelObject)
		'creates a copy
		
		'NOTE: we can't cast from HolidayBase to Holiday, so below we 
        'instantiate a Holiday, NOT a HolidayBase object
        Dim o as EmployeeProject = CType(other, EmployeeProject)
            
		If not o.EPEmployeeId is Nothing AndAlso _
		 me.EPEmployeeId is Nothing Then 
		me.EPEmployeeId = o.EPEmployeeId
End If
If not o.EPProjectId is Nothing AndAlso _
		 me.EPProjectId is Nothing Then 
		me.EPProjectId = o.EPProjectId
End If
If not o.AssignDate is Nothing AndAlso _
		 me.AssignDate is Nothing Then 
		me.AssignDate = o.AssignDate
End If
If not o.EndDate is Nothing AndAlso _
		 me.EndDate is Nothing Then 
		me.EndDate = o.EndDate
End If
If not o.Rate is Nothing AndAlso _
		 me.Rate is Nothing Then 
		me.Rate = o.Rate
End If

		
		
	End Sub

	
	
#End Region

#Region "parentIdChanged"
	'below sub is called when parentIdChanged
	public Overrides Sub handleParentIdChanged(parentMo as IModelObject)
		' Assocations from BusObjects.Employee
		if (typeof parentMo is BusObjects.Employee) Then
			me.EPEmployeeId= DirectCast(parentMo, BusObjects.Employee).EmployeeId
		End If
		' Assocations from BusObjects.Project
		if (typeof parentMo is BusObjects.Project) Then
			me.EPProjectId= DirectCast(parentMo, BusObjects.Project).ProjectId
		End If
	End Sub
#End Region


#Region "ID Property"
	
    Public Overrides Property Id() As Integer 
        Get
            return me._EmployeeProjectId
        End Get
        Set(ByVal value As Integer)
             me._EmployeeProjectId = value
             me.raiseBroadcastIdChange()
        End Set
    End Property
#End Region
	
#Region "Extra Code"
	
#End Region
	
	End Class

#Region "Req Fields validator"
    Public Class EmployeeProjectRequiredFieldsValidator
        Implements IModelObjectValidator

        Public Sub validate(ByVal imo As org.model.lib.Model.IModelObject) _
                    Implements org.model.lib.IModelObjectValidator.validate

            Dim mo As EmployeeProject = CType(imo, EmployeeProject)
			if mo.EPEmployeeId is Nothing then
		Throw new ModelObjectRequiredFieldException("EPEmployeeId")
End if 
if mo.EPProjectId is Nothing then
		Throw new ModelObjectRequiredFieldException("EPProjectId")
End if 

			
        End Sub

    End Class
#End Region

End Namespace

