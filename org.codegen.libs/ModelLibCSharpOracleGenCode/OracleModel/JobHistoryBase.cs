﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

using org.model.lib.Model;
using org.model.lib;

using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

//<comments>
//************************************************************
// Template: ModelBase2.csharp.txt
// Class autogenerated on 09/06/2013 8:02:57 AM by ModelGenerator
// Extends base model object class
// *** DO NOT change code in this class.  
//     It will be re-generated and 
//     overwritten by the code generator ****
// Instead, change code in the extender class JobHistory
//
//************************************************************
//</comments>
namespace OracleModel
{

	#region "Interface"
[System.Runtime.InteropServices.ComVisible(false)] 
	public interface IJobHistory: IModelObject {
	System.Int64 PrJobHistoryId {get;set;} 
	System.Int64? PrEmployeeId {get;set;} 
	System.DateTime? PrStartDate {get;set;} 
	System.DateTime? PrEndDate {get;set;} 
	System.String PrJobId {get;set;} 
	System.Int64? PrDepartmentId {get;set;} 
	System.DateTime? CreateDate {get;set;} 
	System.DateTime? UpdateDate {get;set;} 
	System.String CreateUser {get;set;} 
	System.String UpdateUser {get;set;} 
}
#endregion

	
	[DefaultMapperAttr(typeof(OracleMappers.JobHistoryDBMapper)), ComVisible(false), Serializable(), System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
	public class JobHistoryBase : ModelObject, IEquatable<JobHistoryBase>, IAuditable,IJobHistory {

		#region "Constructor"

		public JobHistoryBase() {
			this.addValidator(new JobHistoryRequiredFieldsValidator());
		}

		#endregion

		#region "Children and Parents"
		
		public override void loadObjectHierarchy() {

		}

		/// <summary>
		/// Returns the **loaded** children of this model object.
		/// Any records that are not loaded (ie the getter method was not called) are not returned.
		/// To get all child records tied to this object, call loadObjectHierarchy() method
		/// </summary>
		public override List<ModelObject> getChildren() {
			List<ModelObject> ret = new List<ModelObject>();
			
			return ret;
		}

		/// <summary>
		/// Returns the **loaded** parent objects of this model object.
		/// Any records are not loaded (ie the getter method was not called) are not returned.
		/// To get all parent records tied to this object, call loadObjectHierarchy() method
		/// </summary>
		public override List<ModelObject> getParents() {
			List<ModelObject> ret = new List<ModelObject>();
			
			return ret;
		}

		#endregion
		#region "Field CONSTANTS"

					public const String STR_FLD_JOB_HISTORY_ID = "JobHistoryId";
			public const String STR_FLD_EMPLOYEE_ID = "EmployeeId";
			public const String STR_FLD_START_DATE = "StartDate";
			public const String STR_FLD_END_DATE = "EndDate";
			public const String STR_FLD_JOB_ID = "JobId";
			public const String STR_FLD_DEPARTMENT_ID = "DepartmentId";
			public const String STR_FLD_CREATE_DATE = "CreateDate";
			public const String STR_FLD_UPDATE_DATE = "UpdateDate";
			public const String STR_FLD_CREATE_USER = "CreateUser";
			public const String STR_FLD_UPDATE_USER = "UpdateUser";


				public const int FLD_JOB_HISTORY_ID = 0;
		public const int FLD_EMPLOYEE_ID = 1;
		public const int FLD_START_DATE = 2;
		public const int FLD_END_DATE = 3;
		public const int FLD_JOB_ID = 4;
		public const int FLD_DEPARTMENT_ID = 5;
		public const int FLD_CREATE_DATE = 6;
		public const int FLD_UPDATE_DATE = 7;
		public const int FLD_CREATE_USER = 8;
		public const int FLD_UPDATE_USER = 9;



		///<summary> Returns the names of fields in the object as a string array.
		/// Useful in automatically setting/getting values from UI objects (windows or web Form)</summary>
		/// <returns> string array </returns>	 
		public override string[] getFieldList()
		{
			return new string[] {
				STR_FLD_JOB_HISTORY_ID,STR_FLD_EMPLOYEE_ID,STR_FLD_START_DATE,STR_FLD_END_DATE,STR_FLD_JOB_ID,STR_FLD_DEPARTMENT_ID,STR_FLD_CREATE_DATE,STR_FLD_UPDATE_DATE,STR_FLD_CREATE_USER,STR_FLD_UPDATE_USER
			};
		}

		#endregion

		#region "Field Declarations"

	private System.Int64 _JobHistoryId;
	private System.Int64? _EmployeeId = null;
	private System.DateTime? _StartDate = null;
	private System.DateTime? _EndDate = null;
	private System.String _JobId = null;
	private System.Int64? _DepartmentId = null;
	private System.DateTime? _CreateDate = null;
	private System.DateTime? _UpdateDate = null;
	private System.String _CreateUser = null;
	private System.String _UpdateUser = null;

		#endregion

		#region "Field Properties"

	public virtual System.Int64 PrJobHistoryId  {
	get {
		return _JobHistoryId;
	} 
	set {
		if (ModelObject.valueChanged(_JobHistoryId, value)) {
			if (!this.IsObjectLoading ) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_JOB_HISTORY_ID);
			}
			this._JobHistoryId = value;

			this.raiseBroadcastIdChange();

		}
	}  
	}
public void setJobHistoryId(String val){
	if (Information.IsNumeric(val)) {
		this.PrJobHistoryId = Convert.ToInt64(val);
	} else if (String.IsNullOrEmpty(val)) {
		throw new ApplicationException("Cant update Primary Key to Null");
	} else {
		throw new ApplicationException("Invalid Integer Number, field:JobHistoryId, value:" + val);
	}
}
	public virtual System.Int64? PrEmployeeId  {
	get {
		return _EmployeeId;
	} 
	set {
		if (ModelObject.valueChanged(_EmployeeId, value)) {
			if (!this.IsObjectLoading ) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_EMPLOYEE_ID);
			}
			this._EmployeeId = value;

		}
	}  
	}
public void setEmployeeId(String val){
	if (Information.IsNumeric(val)) {
		this.PrEmployeeId = Convert.ToInt64(val);
	} else if (String.IsNullOrEmpty(val)) {
		this.PrEmployeeId = null;
	} else {
		throw new ApplicationException("Invalid Integer Number, field:EmployeeId, value:" + val);
	}
}
	public virtual System.DateTime? PrStartDate  {
	get {
		return _StartDate;
	} 
	set {
		if (ModelObject.valueChanged(_StartDate, value)) {
			if (!this.IsObjectLoading ) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_START_DATE);
			}
			this._StartDate = value;

		}
	}  
	}
public void setStartDate( String val ){
	if (Information.IsDate(val)) {
		this.PrStartDate = Convert.ToDateTime(val);
	} else if (String.IsNullOrEmpty(val) ) {
		this.PrStartDate = null;
	} else {
		throw new ApplicationException("Invalid Date, field:StartDate, value:" + val);
	}
}
	public virtual System.DateTime? PrEndDate  {
	get {
		return _EndDate;
	} 
	set {
		if (ModelObject.valueChanged(_EndDate, value)) {
			if (!this.IsObjectLoading ) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_END_DATE);
			}
			this._EndDate = value;

		}
	}  
	}
public void setEndDate( String val ){
	if (Information.IsDate(val)) {
		this.PrEndDate = Convert.ToDateTime(val);
	} else if (String.IsNullOrEmpty(val) ) {
		this.PrEndDate = null;
	} else {
		throw new ApplicationException("Invalid Date, field:EndDate, value:" + val);
	}
}
	public virtual System.String PrJobId  {
	get {
		return _JobId;
	} 
	set {
		if (ModelObject.valueChanged(_JobId, value)) {
			if (!this.IsObjectLoading ) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_JOB_ID);
			}
			this._JobId = value;

		}
	}  
	}
public void setJobId( String val ) {
	if (! string.IsNullOrEmpty(val)) {
		this.PrJobId = val;
	} else {
		this.PrJobId = null;
	}
}
	public virtual System.Int64? PrDepartmentId  {
	get {
		return _DepartmentId;
	} 
	set {
		if (ModelObject.valueChanged(_DepartmentId, value)) {
			if (!this.IsObjectLoading ) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_DEPARTMENT_ID);
			}
			this._DepartmentId = value;

		}
	}  
	}
public void setDepartmentId(String val){
	if (Information.IsNumeric(val)) {
		this.PrDepartmentId = Convert.ToInt64(val);
	} else if (String.IsNullOrEmpty(val)) {
		this.PrDepartmentId = null;
	} else {
		throw new ApplicationException("Invalid Integer Number, field:DepartmentId, value:" + val);
	}
}
	public virtual System.DateTime? CreateDate  {
	get {
		return _CreateDate;
	} 
	set {
		if (ModelObject.valueChanged(_CreateDate, value)) {
			if (!this.IsObjectLoading ) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_CREATE_DATE);
			}
			this._CreateDate = value;

		}
	}  
	}
public void setCreateDate( String val ){
	if (Information.IsDate(val)) {
		this.CreateDate = Convert.ToDateTime(val);
	} else if (String.IsNullOrEmpty(val) ) {
		this.CreateDate = null;
	} else {
		throw new ApplicationException("Invalid Date, field:CreateDate, value:" + val);
	}
}
	public virtual System.DateTime? UpdateDate  {
	get {
		return _UpdateDate;
	} 
	set {
		if (ModelObject.valueChanged(_UpdateDate, value)) {
			if (!this.IsObjectLoading ) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_UPDATE_DATE);
			}
			this._UpdateDate = value;

		}
	}  
	}
public void setUpdateDate( String val ){
	if (Information.IsDate(val)) {
		this.UpdateDate = Convert.ToDateTime(val);
	} else if (String.IsNullOrEmpty(val) ) {
		this.UpdateDate = null;
	} else {
		throw new ApplicationException("Invalid Date, field:UpdateDate, value:" + val);
	}
}
	public virtual System.String CreateUser  {
	get {
		return _CreateUser;
	} 
	set {
		if (ModelObject.valueChanged(_CreateUser, value)) {
			if (!this.IsObjectLoading ) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_CREATE_USER);
			}
			this._CreateUser = value;

		}
	}  
	}
public void setCreateUser( String val ) {
	if (! string.IsNullOrEmpty(val)) {
		this.CreateUser = val;
	} else {
		this.CreateUser = null;
	}
}
	public virtual System.String UpdateUser  {
	get {
		return _UpdateUser;
	} 
	set {
		if (ModelObject.valueChanged(_UpdateUser, value)) {
			if (!this.IsObjectLoading ) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_UPDATE_USER);
			}
			this._UpdateUser = value;

		}
	}  
	}
public void setUpdateUser( String val ) {
	if (! string.IsNullOrEmpty(val)) {
		this.UpdateUser = val;
	} else {
		this.UpdateUser = null;
	}
}

		#endregion

		#region "Getters/Setters of values by field index/name"
		public override object getAttribute(int fieldKey){

		switch (fieldKey) {
		case FLD_JOB_HISTORY_ID:
			return this.PrJobHistoryId;
		case FLD_EMPLOYEE_ID:
			return this.PrEmployeeId;
		case FLD_START_DATE:
			return this.PrStartDate;
		case FLD_END_DATE:
			return this.PrEndDate;
		case FLD_JOB_ID:
			return this.PrJobId;
		case FLD_DEPARTMENT_ID:
			return this.PrDepartmentId;
		case FLD_CREATE_DATE:
			return this.CreateDate;
		case FLD_UPDATE_DATE:
			return this.UpdateDate;
		case FLD_CREATE_USER:
			return this.CreateUser;
		case FLD_UPDATE_USER:
			return this.UpdateUser;
		default:
			return null;
		} //end switch

		}

		public override object getAttribute(string fieldKey) {
			fieldKey = fieldKey.ToLower();

		if (fieldKey==STR_FLD_JOB_HISTORY_ID.ToLower() ) {
			return this.PrJobHistoryId;
		} else if (fieldKey==STR_FLD_EMPLOYEE_ID.ToLower() ) {
			return this.PrEmployeeId;
		} else if (fieldKey==STR_FLD_START_DATE.ToLower() ) {
			return this.PrStartDate;
		} else if (fieldKey==STR_FLD_END_DATE.ToLower() ) {
			return this.PrEndDate;
		} else if (fieldKey==STR_FLD_JOB_ID.ToLower() ) {
			return this.PrJobId;
		} else if (fieldKey==STR_FLD_DEPARTMENT_ID.ToLower() ) {
			return this.PrDepartmentId;
		} else if (fieldKey==STR_FLD_CREATE_DATE.ToLower() ) {
			return this.CreateDate;
		} else if (fieldKey==STR_FLD_UPDATE_DATE.ToLower() ) {
			return this.UpdateDate;
		} else if (fieldKey==STR_FLD_CREATE_USER.ToLower() ) {
			return this.CreateUser;
		} else if (fieldKey==STR_FLD_UPDATE_USER.ToLower() ) {
			return this.UpdateUser;
		} else {
			return null;
		}
		}

		public override void setAttribute(int fieldKey, object val){
		switch (fieldKey) {
		case FLD_JOB_HISTORY_ID:
			if (val == DBNull.Value || val == null ){
				throw new ApplicationException("Can't set Primary Key to null");
			}else{
				this.PrJobHistoryId=(System.Int64)val;
			} //
			return;
		case FLD_EMPLOYEE_ID:
			if (val == DBNull.Value || val == null ){
				this.PrEmployeeId = null;
			}else{
				this.PrEmployeeId=(System.Int64)val;
			} //
			return;
		case FLD_START_DATE:
			if (val == DBNull.Value || val == null ){
				this.PrStartDate = null;
			}else{
				this.PrStartDate=(System.DateTime)val;
			} //
			return;
		case FLD_END_DATE:
			if (val == DBNull.Value || val == null ){
				this.PrEndDate = null;
			}else{
				this.PrEndDate=(System.DateTime)val;
			} //
			return;
		case FLD_JOB_ID:
			if (val == DBNull.Value || val == null ){
				this.PrJobId = null;
			}else{
				this.PrJobId=(System.String)val;
			} //
			return;
		case FLD_DEPARTMENT_ID:
			if (val == DBNull.Value || val == null ){
				this.PrDepartmentId = null;
			}else{
				this.PrDepartmentId=(System.Int64)val;
			} //
			return;
		case FLD_CREATE_DATE:
			if (val == DBNull.Value || val == null ){
				this.CreateDate = null;
			}else{
				this.CreateDate=(System.DateTime)val;
			} //
			return;
		case FLD_UPDATE_DATE:
			if (val == DBNull.Value || val == null ){
				this.UpdateDate = null;
			}else{
				this.UpdateDate=(System.DateTime)val;
			} //
			return;
		case FLD_CREATE_USER:
			if (val == DBNull.Value || val == null ){
				this.CreateUser = null;
			}else{
				this.CreateUser=(System.String)val;
			} //
			return;
		case FLD_UPDATE_USER:
			if (val == DBNull.Value || val == null ){
				this.UpdateUser = null;
			}else{
				this.UpdateUser=(System.String)val;
			} //
			return;
		default:
			return;
		}

		}

		public override void setAttribute(string fieldKey, object val) {
			fieldKey = fieldKey.ToLower();
		if ( fieldKey==STR_FLD_JOB_HISTORY_ID.ToLower()){
			if (val == DBNull.Value || val ==null ){
				throw new ApplicationException("Can't set Primary Key to null");
			} else {
				this.PrJobHistoryId=(System.Int64)val;
			}
			return;
		} else if ( fieldKey==STR_FLD_EMPLOYEE_ID.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.PrEmployeeId = null;
			} else {
				this.PrEmployeeId=(System.Int64)val;
			}
			return;
		} else if ( fieldKey==STR_FLD_START_DATE.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.PrStartDate = null;
			} else {
				this.PrStartDate=(System.DateTime)val;
			}
			return;
		} else if ( fieldKey==STR_FLD_END_DATE.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.PrEndDate = null;
			} else {
				this.PrEndDate=(System.DateTime)val;
			}
			return;
		} else if ( fieldKey==STR_FLD_JOB_ID.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.PrJobId = null;
			} else {
				this.PrJobId=(System.String)val;
			}
			return;
		} else if ( fieldKey==STR_FLD_DEPARTMENT_ID.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.PrDepartmentId = null;
			} else {
				this.PrDepartmentId=(System.Int64)val;
			}
			return;
		} else if ( fieldKey==STR_FLD_CREATE_DATE.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.CreateDate = null;
			} else {
				this.CreateDate=(System.DateTime)val;
			}
			return;
		} else if ( fieldKey==STR_FLD_UPDATE_DATE.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.UpdateDate = null;
			} else {
				this.UpdateDate=(System.DateTime)val;
			}
			return;
		} else if ( fieldKey==STR_FLD_CREATE_USER.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.CreateUser = null;
			} else {
				this.CreateUser=(System.String)val;
			}
			return;
		} else if ( fieldKey==STR_FLD_UPDATE_USER.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.UpdateUser = null;
			} else {
				this.UpdateUser=(System.String)val;
			}
			return;
		}
		}

		#endregion
		#region "Overrides of GetHashCode and Equals "
		public bool Equals(JobHistoryBase other)
		{

			//typesafe equals, checks for equality of fields
			if (other == null)
				return false;
			if (object.ReferenceEquals(other, this))
				return true;

			return this.PrJobHistoryId == other.PrJobHistoryId
				&& this.PrEmployeeId.GetValueOrDefault() == other.PrEmployeeId.GetValueOrDefault()
				&& this.PrStartDate.GetValueOrDefault() == other.PrStartDate.GetValueOrDefault()
				&& this.PrEndDate.GetValueOrDefault() == other.PrEndDate.GetValueOrDefault()
				&& this.PrJobId == other.PrJobId
				&& this.PrDepartmentId.GetValueOrDefault() == other.PrDepartmentId.GetValueOrDefault()
				&& this.CreateDate.GetValueOrDefault() == other.CreateDate.GetValueOrDefault()
				&& this.UpdateDate.GetValueOrDefault() == other.UpdateDate.GetValueOrDefault()
				&& this.CreateUser == other.CreateUser
				&& this.UpdateUser == other.UpdateUser;;

		}

		public override int GetHashCode()
		{
			//using Xor has the advantage of not overflowing the integer.
			return this.PrJobHistoryId.GetHashCode()
				 ^ this.PrEmployeeId.GetHashCode()
				 ^ this.PrStartDate.GetHashCode()
				 ^ this.PrEndDate.GetHashCode()
				 ^ this.getStringHashCode(this.PrJobId)
				 ^ this.PrDepartmentId.GetHashCode()
				 ^ this.CreateDate.GetHashCode()
				 ^ this.UpdateDate.GetHashCode()
				 ^ this.getStringHashCode(this.CreateUser)
				 ^ this.getStringHashCode(this.UpdateUser);;

		}

		public override bool Equals(object Obj) {

			if (Obj != null && Obj is JobHistoryBase) {

				return this.Equals((JobHistoryBase)Obj);

			} else {
				return false;
			}

		}

		public static bool operator ==(JobHistoryBase obj1, JobHistoryBase obj2)
		{
			return object.Equals(obj1, obj2);
		}

		public static bool operator !=(JobHistoryBase obj1, JobHistoryBase obj2)
		{
			return !(obj1 == obj2);
		}

		#endregion

		#region "Copy and sort"

		public override IModelObject copy()
		{
			//creates a copy

			//NOTE: we can't cast from JobHistoryBase to JobHistory, so below we 
			//instantiate a JobHistory, NOT a JobHistoryBase object
			JobHistory ret = JobHistoryFactory.Create();

		ret.PrJobHistoryId = this.PrJobHistoryId;
		ret.PrEmployeeId = this.PrEmployeeId;
		ret.PrStartDate = this.PrStartDate;
		ret.PrEndDate = this.PrEndDate;
		ret.PrJobId = this.PrJobId;
		ret.PrDepartmentId = this.PrDepartmentId;
		ret.CreateDate = this.CreateDate;
		ret.UpdateDate = this.UpdateDate;
		ret.CreateUser = this.CreateUser;
		ret.UpdateUser = this.UpdateUser;



			return ret;

		}

		
		#endregion

#region "parentIdChanged"
	//below sub is called when parentIdChanged
	public override void handleParentIdChanged(IModelObject parentMo ){
		// Assocations from OracleModel.Employee
		if ( parentMo is OracleModel.Employee) {
			this.PrEmployeeId= ((OracleModel.Employee)parentMo).PrEmployeeId;
		}
	}
#endregion



		#region "ID Property"

		public override object Id {
			get { return this._JobHistoryId; }
			set {
				this._JobHistoryId = Convert.ToInt64(value);
				this.raiseBroadcastIdChange();
			}
		}
		#endregion

		#region "Extra Code"

		#endregion

	}

	#region "Req Fields validator"
	[System.Runtime.InteropServices.ComVisible(false)]
	public class JobHistoryRequiredFieldsValidator : IModelObjectValidator
	{


		public void validate(org.model.lib.Model.IModelObject imo) {
			JobHistory mo = (JobHistory)imo;
if (mo.PrEmployeeId == null ) {
		throw new ModelObjectRequiredFieldException("EmployeeId");
}
if (mo.PrStartDate == null ) {
		throw new ModelObjectRequiredFieldException("StartDate");
}
if (mo.PrEndDate == null ) {
		throw new ModelObjectRequiredFieldException("EndDate");
}
if (string.IsNullOrEmpty( mo.PrJobId)) {
		throw new ModelObjectRequiredFieldException("JobId");
}

		}

	}
	#endregion

}


