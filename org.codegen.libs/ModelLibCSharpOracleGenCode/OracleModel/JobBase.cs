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
// Instead, change code in the extender class Job
//
//************************************************************
//</comments>
namespace OracleModel
{

	#region "Interface"
[System.Runtime.InteropServices.ComVisible(false)] 
	public interface IJob: IModelObject {
	System.String PrJobId {get;set;} 
	System.String PrJobTitle {get;set;} 
	System.Int64? PrMinSalary {get;set;} 
	System.Int64? PrMaxSalary {get;set;} 
	System.DateTime? CreateDate {get;set;} 
	System.DateTime? UpdateDate {get;set;} 
	System.String CreateUser {get;set;} 
	System.String UpdateUser {get;set;} 
}
#endregion

	
	[DefaultMapperAttr(typeof(OracleMappers.JobDBMapper)), ComVisible(false), Serializable(), System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
	public class JobBase : ModelObject, IEquatable<JobBase>, IAuditable,IJob {

		#region "Constructor"

		public JobBase() {
			this.addValidator(new JobRequiredFieldsValidator());
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

					public const String STR_FLD_JOB_ID = "JobId";
			public const String STR_FLD_JOB_TITLE = "JobTitle";
			public const String STR_FLD_MIN_SALARY = "MinSalary";
			public const String STR_FLD_MAX_SALARY = "MaxSalary";
			public const String STR_FLD_CREATE_DATE = "CreateDate";
			public const String STR_FLD_UPDATE_DATE = "UpdateDate";
			public const String STR_FLD_CREATE_USER = "CreateUser";
			public const String STR_FLD_UPDATE_USER = "UpdateUser";


				public const int FLD_JOB_ID = 0;
		public const int FLD_JOB_TITLE = 1;
		public const int FLD_MIN_SALARY = 2;
		public const int FLD_MAX_SALARY = 3;
		public const int FLD_CREATE_DATE = 4;
		public const int FLD_UPDATE_DATE = 5;
		public const int FLD_CREATE_USER = 6;
		public const int FLD_UPDATE_USER = 7;



		///<summary> Returns the names of fields in the object as a string array.
		/// Useful in automatically setting/getting values from UI objects (windows or web Form)</summary>
		/// <returns> string array </returns>	 
		public override string[] getFieldList()
		{
			return new string[] {
				STR_FLD_JOB_ID,STR_FLD_JOB_TITLE,STR_FLD_MIN_SALARY,STR_FLD_MAX_SALARY,STR_FLD_CREATE_DATE,STR_FLD_UPDATE_DATE,STR_FLD_CREATE_USER,STR_FLD_UPDATE_USER
			};
		}

		#endregion

		#region "Field Declarations"

	private System.String _JobId;
	private System.String _JobTitle = null;
	private System.Int64? _MinSalary = null;
	private System.Int64? _MaxSalary = null;
	private System.DateTime? _CreateDate = null;
	private System.DateTime? _UpdateDate = null;
	private System.String _CreateUser = null;
	private System.String _UpdateUser = null;

		#endregion

		#region "Field Properties"

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

			this.raiseBroadcastIdChange();

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
	public virtual System.String PrJobTitle  {
	get {
		return _JobTitle;
	} 
	set {
		if (ModelObject.valueChanged(_JobTitle, value)) {
			if (!this.IsObjectLoading ) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_JOB_TITLE);
			}
			this._JobTitle = value;

		}
	}  
	}
public void setJobTitle( String val ) {
	if (! string.IsNullOrEmpty(val)) {
		this.PrJobTitle = val;
	} else {
		this.PrJobTitle = null;
	}
}
	public virtual System.Int64? PrMinSalary  {
	get {
		return _MinSalary;
	} 
	set {
		if (ModelObject.valueChanged(_MinSalary, value)) {
			if (!this.IsObjectLoading ) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_MIN_SALARY);
			}
			this._MinSalary = value;

		}
	}  
	}
public void setMinSalary(String val){
	if (Information.IsNumeric(val)) {
		this.PrMinSalary = Convert.ToInt64(val);
	} else if (String.IsNullOrEmpty(val)) {
		this.PrMinSalary = null;
	} else {
		throw new ApplicationException("Invalid Integer Number, field:MinSalary, value:" + val);
	}
}
	public virtual System.Int64? PrMaxSalary  {
	get {
		return _MaxSalary;
	} 
	set {
		if (ModelObject.valueChanged(_MaxSalary, value)) {
			if (!this.IsObjectLoading ) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_MAX_SALARY);
			}
			this._MaxSalary = value;

		}
	}  
	}
public void setMaxSalary(String val){
	if (Information.IsNumeric(val)) {
		this.PrMaxSalary = Convert.ToInt64(val);
	} else if (String.IsNullOrEmpty(val)) {
		this.PrMaxSalary = null;
	} else {
		throw new ApplicationException("Invalid Integer Number, field:MaxSalary, value:" + val);
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
		case FLD_JOB_ID:
			return this.PrJobId;
		case FLD_JOB_TITLE:
			return this.PrJobTitle;
		case FLD_MIN_SALARY:
			return this.PrMinSalary;
		case FLD_MAX_SALARY:
			return this.PrMaxSalary;
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

		if (fieldKey==STR_FLD_JOB_ID.ToLower() ) {
			return this.PrJobId;
		} else if (fieldKey==STR_FLD_JOB_TITLE.ToLower() ) {
			return this.PrJobTitle;
		} else if (fieldKey==STR_FLD_MIN_SALARY.ToLower() ) {
			return this.PrMinSalary;
		} else if (fieldKey==STR_FLD_MAX_SALARY.ToLower() ) {
			return this.PrMaxSalary;
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
		case FLD_JOB_ID:
			if (val == DBNull.Value || val == null ){
				throw new ApplicationException("Can't set Primary Key to null");
			}else{
				this.PrJobId=(System.String)val;
			} //
			return;
		case FLD_JOB_TITLE:
			if (val == DBNull.Value || val == null ){
				this.PrJobTitle = null;
			}else{
				this.PrJobTitle=(System.String)val;
			} //
			return;
		case FLD_MIN_SALARY:
			if (val == DBNull.Value || val == null ){
				this.PrMinSalary = null;
			}else{
				this.PrMinSalary=(System.Int64)val;
			} //
			return;
		case FLD_MAX_SALARY:
			if (val == DBNull.Value || val == null ){
				this.PrMaxSalary = null;
			}else{
				this.PrMaxSalary=(System.Int64)val;
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
		if ( fieldKey==STR_FLD_JOB_ID.ToLower()){
			if (val == DBNull.Value || val ==null ){
				throw new ApplicationException("Can't set Primary Key to null");
			} else {
				this.PrJobId=(System.String)val;
			}
			return;
		} else if ( fieldKey==STR_FLD_JOB_TITLE.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.PrJobTitle = null;
			} else {
				this.PrJobTitle=(System.String)val;
			}
			return;
		} else if ( fieldKey==STR_FLD_MIN_SALARY.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.PrMinSalary = null;
			} else {
				this.PrMinSalary=(System.Int64)val;
			}
			return;
		} else if ( fieldKey==STR_FLD_MAX_SALARY.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.PrMaxSalary = null;
			} else {
				this.PrMaxSalary=(System.Int64)val;
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
		public bool Equals(JobBase other)
		{

			//typesafe equals, checks for equality of fields
			if (other == null)
				return false;
			if (object.ReferenceEquals(other, this))
				return true;

			return this.PrJobId == other.PrJobId
				&& this.PrJobTitle == other.PrJobTitle
				&& this.PrMinSalary.GetValueOrDefault() == other.PrMinSalary.GetValueOrDefault()
				&& this.PrMaxSalary.GetValueOrDefault() == other.PrMaxSalary.GetValueOrDefault()
				&& this.CreateDate.GetValueOrDefault() == other.CreateDate.GetValueOrDefault()
				&& this.UpdateDate.GetValueOrDefault() == other.UpdateDate.GetValueOrDefault()
				&& this.CreateUser == other.CreateUser
				&& this.UpdateUser == other.UpdateUser;;

		}

		public override int GetHashCode()
		{
			//using Xor has the advantage of not overflowing the integer.
			return this.getStringHashCode(this.PrJobId)
				 ^ this.getStringHashCode(this.PrJobTitle)
				 ^ this.PrMinSalary.GetHashCode()
				 ^ this.PrMaxSalary.GetHashCode()
				 ^ this.CreateDate.GetHashCode()
				 ^ this.UpdateDate.GetHashCode()
				 ^ this.getStringHashCode(this.CreateUser)
				 ^ this.getStringHashCode(this.UpdateUser);;

		}

		public override bool Equals(object Obj) {

			if (Obj != null && Obj is JobBase) {

				return this.Equals((JobBase)Obj);

			} else {
				return false;
			}

		}

		public static bool operator ==(JobBase obj1, JobBase obj2)
		{
			return object.Equals(obj1, obj2);
		}

		public static bool operator !=(JobBase obj1, JobBase obj2)
		{
			return !(obj1 == obj2);
		}

		#endregion

		#region "Copy and sort"

		public override IModelObject copy()
		{
			//creates a copy

			//NOTE: we can't cast from JobBase to Job, so below we 
			//instantiate a Job, NOT a JobBase object
			Job ret = JobFactory.Create();

		ret.PrJobId = this.PrJobId;
		ret.PrJobTitle = this.PrJobTitle;
		ret.PrMinSalary = this.PrMinSalary;
		ret.PrMaxSalary = this.PrMaxSalary;
		ret.CreateDate = this.CreateDate;
		ret.UpdateDate = this.UpdateDate;
		ret.CreateUser = this.CreateUser;
		ret.UpdateUser = this.UpdateUser;



			return ret;

		}

		

		#endregion




		#region "ID Property"

		public override object Id {
			get { return this._JobId; }
			set {
				this._JobId = Convert.ToString(value);
				this.raiseBroadcastIdChange();
			}
		}
		#endregion

		#region "Extra Code"

		#endregion

	}

	#region "Req Fields validator"
	[System.Runtime.InteropServices.ComVisible(false)]
	public class JobRequiredFieldsValidator : IModelObjectValidator
	{


		public void validate(org.model.lib.Model.IModelObject imo) {
			Job mo = (Job)imo;
if (string.IsNullOrEmpty( mo.PrJobTitle)) {
		throw new ModelObjectRequiredFieldException("JobTitle");
}

		}

	}
	#endregion

}


