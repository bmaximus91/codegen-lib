﻿
'NOTE: DO NOT ADD REFERENCES TO COM.NETU.LIB HERE, INSTEAD ADD
'THE IMPORT ON THE REFERENCES OF THE PROJECT
Imports System.Runtime.InteropServices
Imports System.Collections.Generic
Imports System.Xml.Serialization
'<comments>
'************************************************************
' Temnplate: ModelBase2.visualBasic.txt
' Class autogenerated on 13-04-2015 11:14:08 by ModelGenerator
' Extends base model object class
' *** DO NOT change code in this class.  
'     It will be re-generated and 
'     overwritten by the code generator ****
' Instead, change code in the extender class EmployeeRank
'
'************************************************************
'</comments>
Namespace VbBusObjects

#Region "Interface"
<System.Runtime.InteropServices.ComVisible(False)> _
	Public Interface IEmployeeRank: Inherits IModelObject
	Property RankId as System.Int64
	Property Rank as System.String
End Interface
#End region 

	<DefaultMapperAttr(GetType(EmployeeRankDBMapper)), _
	 ComVisible(False),Serializable(), System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
	Public class EmployeeRankBase
		Inherits ModelObject
		Implements IEquatable(Of EmployeeRankBase),
		IEmployeeRank 

#Region "Constructor"
    
    public sub New()
		Me.addValidator(New EmployeeRankRequiredFieldsValidator)
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

			public Const STR_FLD_RANKID as String = "RankId"
			public Const STR_FLD_RANK as String = "Rank"


		public Const FLD_RANKID as Integer = 0
		public Const FLD_RANK as Integer = 1



        '''<summary> Returns the names of fields in the object as a string array.
        ''' Useful in automatically setting/getting values from UI objects (windows or web Form)</summary>
        ''' <returns> string array </returns>	 
        Public Overrides Function getFieldList() As String()
            Return New String() {STR_FLD_RANKID,STR_FLD_RANK}
        End Function
        
#END Region

#Region "Field Declarations"


	Private _RankId as System.Int64
	Private _Rank as System.String = Nothing


#END Region

#Region "Field Properties"

	Public Overridable Property RankId as System.Int64 _ 
		Implements IEmployeeRank.RankId
	Get 
		return _RankId
	End Get 
	Set
		if ModelObject.valueChanged(_RankId, value) then
			if me.IsObjectLoading = false then
				me.isDirty = true
				me.setFieldChanged(STR_FLD_RANKID)
			End If
			me._RankId = value

			me.raiseBroadcastIdChange()

		End if
	End Set 
	End Property 
Public Sub setRankId(ByVal val As String)
	If IsNumeric(val) Then
		Me.RankId = CType(val, System.Int64)
	ElseIf String.IsNullOrEmpty(val) Then
		Me.RankId = Nothing
	Else
		Throw new ApplicationException("Invalid Integer Number, field:RankId, value:" & val)
	End If
End Sub
	Public Overridable Property Rank as System.String _ 
		Implements IEmployeeRank.Rank
	Get 
		return _Rank
	End Get 
	Set
		if value isNot Nothing andAlso value.Length > 50 Then
			Throw new ModelObjectFieldTooLongException("Rank")
		End If
		if ModelObject.valueChanged(_Rank, value) then
			if me.IsObjectLoading = false then
				me.isDirty = true
				me.setFieldChanged(STR_FLD_RANK)
			End If
			me._Rank = value

		End if
	End Set 
	End Property 
Public Sub setRank(ByVal val As String)
	If not String.isNullOrEmpty(val) Then
		Me.Rank = val
	Else
		Me.Rank = Nothing
	End If
End Sub

#End Region

#Region "Getters/Setters of values by field index/name"
    Public Overloads Overrides Function getAttribute(ByVal fieldKey As Integer) As Object
		

		select case fieldKey
		case FLD_RANKID
			return me.RankId
		case FLD_RANK
			return me.Rank
		case else
			return nothing
		end select


    End Function

    Public Overloads Overrides Function getAttribute(ByVal fieldKey As String) As Object
		fieldKey = fieldKey.ToLower

		if fieldKey=STR_FLD_RANKID.ToLower() Then
			return me.RankId
		else if fieldKey=STR_FLD_RANK.ToLower() Then
			return me.Rank
		else
			return nothing
		end If
    End Function

    Public Overloads Overrides Sub setAttribute(ByVal fieldKey As Integer, ByVal val As Object)
		
		Select Case fieldKey
		case FLD_RANKID
			If Val Is DBNull.Value OrElse Val Is Nothing Then
				Me.RankId = Nothing
			Else
				Me.RankId=CType(val,System.Int64)
			End If
			return
		case FLD_RANK
			If Val Is DBNull.Value OrElse Val Is Nothing Then
				Me.Rank = Nothing
			Else
				Me.Rank=CType(val,System.String)
			End If
			return
		case else
			return
		end select


    End Sub

    Public Overloads Overrides Sub setAttribute(ByVal fieldKey As String, ByVal val As Object)
		
		fieldKey = fieldKey.ToLower
		
		if  fieldKey=STR_FLD_RANKID.ToLower() Then
			If Val Is DBNull.Value OrElse Val Is Nothing Then
				Me.RankId = Nothing
			Else
				Me.RankId=CType(val,System.Int64)
			End If
			return
		else if  fieldKey=STR_FLD_RANK.ToLower() Then
			If Val Is DBNull.Value OrElse Val Is Nothing Then
				Me.Rank = Nothing
			Else
				Me.Rank=CType(val,System.String)
			End If
			return
		end If

    End Sub

#End Region
#Region "Overrides of GetHashCode and Equals "
	Public Overloads Function Equals(ByVal other As EmployeeRankBase) As Boolean _     
		Implements System.IEquatable(Of EmployeeRankBase).Equals       
		
			'typesafe equals, checks for equality of fields
			If other Is Nothing Then Return False       
			If other Is Me Then Return True
		
			Return me.RankId= other.RankId _
				AndAlso me.Rank= other.Rank
				
	End Function
	
	Public Overrides Function GetHashCode() As Integer
        'using Xor has the advantage of not overflowing the integer.
        Return me.RankId.GetHashCode _
				Xor me.getStringHashCode(Me.Rank) 
    
    End Function
    
    Public Overloads Overrides Function Equals(ByVal Obj As Object) As Boolean
		
		Dim temp = TryCast(obj, EmployeeRankBase)       
		If temp IsNot Nothing Then 
			Return Me.Equals(temp)
		Else
			Return False
		End If

    End Function
	
	Public Shared Operator =(ByVal obj1 As EmployeeRankBase, ByVal obj2 As EmployeeRankBase) As Boolean       
		Return Object.Equals(obj1 ,obj2)    
	End Operator    
	
	Public Shared Operator <>(ByVal obj1 As EmployeeRankBase, ByVal obj2 As EmployeeRankBase) As Boolean       
		Return Not (obj1 = obj2)    
	End Operator

#End Region

#Region "Copy and sort"

	Public Overrides Function copy() as IModelObject
		'creates a copy
		
		'NOTE: we can't cast from EmployeeRankBase to EmployeeRank, so below we 
        'instantiate a EmployeeRank, NOT a EmployeeRankBase object
        Dim ret as EmployeeRank = EmployeeRankFactory.Create()
            
				ret.RankId = me.RankId
		ret.Rank = me.Rank

		
		return ret
		
	End Function
	
	Public Overrides Sub merge(other as IModelObject)
		'merges this EmployeeRank model object (me) with the "other" instance 
		
		Dim o as EmployeeRank = CType(other, EmployeeRank)
		If not String.isNullOrEmpty(o.Rank) AndAlso _
		 String.isNullOrEmpty(me.Rank) Then 
		me.Rank = o.Rank
End If

		
	End Sub

	
	
#End Region



#Region "ID Property"
	
    Public Overrides Property Id() As object 
        Get
            return me._RankId
        End Get
        Set(ByVal value As object)
             me._RankId = Clng(value)
             me.raiseBroadcastIdChange()
        End Set
    End Property
#End Region
	
#Region "Extra Code"
	
#End Region
	
	End Class

#Region "Req Fields validator"
	<System.Runtime.InteropServices.ComVisible(False)> _
    Public Class EmployeeRankRequiredFieldsValidator
        Implements IModelObjectValidator

        Public Sub validate(ByVal imo As org.model.lib.Model.IModelObject) _
                    Implements org.model.lib.IModelObjectValidator.validate

            Dim mo As EmployeeRank = CType(imo, EmployeeRank)
			if String.isNullOrEmpty( mo.Rank) Then
		Throw new ModelObjectRequiredFieldException("Rank")
End if 

			
        End Sub

    End Class
#End Region

End Namespace

