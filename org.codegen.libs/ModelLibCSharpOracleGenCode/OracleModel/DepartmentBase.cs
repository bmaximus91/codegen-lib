﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization;
using org.model.lib.Model;
using org.model.lib;

using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations;


//<comments>
//************************************************************
// Template: ModelBase2.csharp.txt
// Class autogenerated on 09/06/2013 8:02:57 AM by ModelGenerator
// Extends base model object class
// *** DO NOT change code in this class.  
//     It will be re-generated and 
//     overwritten by the code generator ****
//</comments>
namespace OracleModel {

	[Table(Name = "DEPARTMENTS")]
	[DataContract][SelectObject("DEPARTMENTS")][KeyFieldName("DEPARTMENT_ID")]
	[DefaultMapperAttr(typeof(OracleMappers.DepartmentDBMapper)), ComVisible(false), Serializable(), System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
	partial class Department:ModelObject,IEquatable<Department> ,IAuditable {

		#region "Constructor"

		public Department() {
			this.Id = ModelObjectKeyGen.nextId();
			this.addValidator(new DepartmentRequiredFieldsValidator());
		}

		#endregion

		#region "Children and Parents"
		
		public override void loadObjectHierarchy() {

		}

		/// <summary>
		/// Returns the *loaded* children of this model object.
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

					public const String STR_FLD_DEPARTMENT_ID = "DepartmentId";
			public const String STR_FLD_DEPARTMENT_NAME = "DepartmentName";
			public const String STR_FLD_MANAGER_ID = "ManagerId";
			public const String STR_FLD_LOCATION_ID = "LocationId";
			public const String STR_FLD_CREATE_DATE = "CreateDate";
			public const String STR_FLD_UPDATE_DATE = "UpdateDate";
			public const String STR_FLD_CREATE_USER = "CreateUser";
			public const String STR_FLD_UPDATE_USER = "UpdateUser";


				public const int FLD_DEPARTMENT_ID = 0;
		public const int FLD_DEPARTMENT_NAME = 1;
		public const int FLD_MANAGER_ID = 2;
		public const int FLD_LOCATION_ID = 3;
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
				STR_FLD_DEPARTMENT_ID,STR_FLD_DEPARTMENT_NAME,STR_FLD_MANAGER_ID,STR_FLD_LOCATION_ID,STR_FLD_CREATE_DATE,STR_FLD_UPDATE_DATE,STR_FLD_CREATE_USER,STR_FLD_UPDATE_USER
			};
		}

		#endregion

		#region "Field Declarations"

	private System.Int64 _DepartmentId;
	private System.String _DepartmentName;
	private System.Int64? _ManagerId = null;
	private System.Int64? _LocationId = null;
	private System.DateTime? _CreateDate = null;
	private System.DateTime? _UpdateDate = null;
	private System.String _CreateUser;
	private System.String _UpdateUser;

		#endregion

		#region "Field Properties"

		//Field DEPARTMENT_ID
	[Required][Column(Name="DEPARTMENT_ID",Storage = "_DepartmentId", IsPrimaryKey=true,DbType = " NOT NULL",CanBeNull = false)]
	[DataMember]public virtual System.Int64 PrDepartmentId{
	get{
		return _DepartmentId;
	}
	set {
		if (ModelObject.valueChanged(_DepartmentId, value)){
			if (!this.IsObjectLoading) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_DEPARTMENT_ID);
			}
		this._DepartmentId = value;

			this.raiseBroadcastIdChange();

		}
		}
	}
		//Field DEPARTMENT_NAME
	[Key][Required][StringLength(30, ErrorMessage="DEPARTMENT_NAME must be 30 characters or less")][Column(Name="DEPARTMENT_NAME",Storage = "_DepartmentName", IsPrimaryKey=false,DbType = " NOT NULL",CanBeNull = false)]
	[DataMember]public virtual System.String PrDepartmentName{
	get{
		return _DepartmentName;
	}
	set {
		if (ModelObject.valueChanged(_DepartmentName, value)){
		if (value != null && value.Length > 30){
			throw new ModelObjectFieldTooLongException("DEPARTMENT_NAME");
		}
			if (!this.IsObjectLoading) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_DEPARTMENT_NAME);
			}
		this._DepartmentName = value;

		}
		}
	}
		//Field MANAGER_ID
	[Key][Column(Name="MANAGER_ID",Storage = "_ManagerId", IsPrimaryKey=false,DbType = "",CanBeNull = true)]
	[DataMember]public virtual System.Int64? PrManagerId{
	get{
		return _ManagerId;
	}
	set {
		if (ModelObject.valueChanged(_ManagerId, value)){
			if (!this.IsObjectLoading) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_MANAGER_ID);
			}
		this._ManagerId = value;

		}
		}
	}
		//Field LOCATION_ID
	[Key][Column(Name="LOCATION_ID",Storage = "_LocationId", IsPrimaryKey=false,DbType = "",CanBeNull = true)]
	[DataMember]public virtual System.Int64? PrLocationId{
	get{
		return _LocationId;
	}
	set {
		if (ModelObject.valueChanged(_LocationId, value)){
			if (!this.IsObjectLoading) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_LOCATION_ID);
			}
		this._LocationId = value;

		}
		}
	}
		//Field CREATE_DATE
	[Key][Column(Name="CREATE_DATE",Storage = "_CreateDate", IsPrimaryKey=false,DbType = "",CanBeNull = true)]
	[DataMember]public virtual System.DateTime? CreateDate{
	get{
		return _CreateDate;
	}
	set {
		if (ModelObject.valueChanged(_CreateDate, value)){
			if (!this.IsObjectLoading) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_CREATE_DATE);
			}
		this._CreateDate = value;

		}
		}
	}
		//Field UPDATE_DATE
	[Key][Column(Name="UPDATE_DATE",Storage = "_UpdateDate", IsPrimaryKey=false,DbType = "",CanBeNull = true)]
	[DataMember]public virtual System.DateTime? UpdateDate{
	get{
		return _UpdateDate;
	}
	set {
		if (ModelObject.valueChanged(_UpdateDate, value)){
			if (!this.IsObjectLoading) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_UPDATE_DATE);
			}
		this._UpdateDate = value;

		}
		}
	}
		//Field CREATE_USER
	[Key][StringLength(20, ErrorMessage="CREATE_USER must be 20 characters or less")][Column(Name="CREATE_USER",Storage = "_CreateUser", IsPrimaryKey=false,DbType = "",CanBeNull = true)]
	[DataMember]public virtual System.String CreateUser{
	get{
		return _CreateUser;
	}
	set {
		if (ModelObject.valueChanged(_CreateUser, value)){
		if (value != null && value.Length > 20){
			throw new ModelObjectFieldTooLongException("CREATE_USER");
		}
			if (!this.IsObjectLoading) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_CREATE_USER);
			}
		this._CreateUser = value;

		}
		}
	}
		//Field UPDATE_USER
	[Key][StringLength(20, ErrorMessage="UPDATE_USER must be 20 characters or less")][Column(Name="UPDATE_USER",Storage = "_UpdateUser", IsPrimaryKey=false,DbType = "",CanBeNull = true)]
	[DataMember]public virtual System.String UpdateUser{
	get{
		return _UpdateUser;
	}
	set {
		if (ModelObject.valueChanged(_UpdateUser, value)){
		if (value != null && value.Length > 20){
			throw new ModelObjectFieldTooLongException("UPDATE_USER");
		}
			if (!this.IsObjectLoading) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_UPDATE_USER);
			}
		this._UpdateUser = value;

		}
		}
	}

		#endregion

		#region "Getters/Setters of values by field index/name"
		public override object getAttribute(int fieldKey){

		switch (fieldKey) {
		case FLD_DEPARTMENT_ID:
			return this.PrDepartmentId;
		case FLD_DEPARTMENT_NAME:
			return this.PrDepartmentName;
		case FLD_MANAGER_ID:
			return this.PrManagerId;
		case FLD_LOCATION_ID:
			return this.PrLocationId;
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

		if (fieldKey==STR_FLD_DEPARTMENT_ID.ToLower() ) {
			return this.PrDepartmentId;
		} else if (fieldKey==STR_FLD_DEPARTMENT_NAME.ToLower() ) {
			return this.PrDepartmentName;
		} else if (fieldKey==STR_FLD_MANAGER_ID.ToLower() ) {
			return this.PrManagerId;
		} else if (fieldKey==STR_FLD_LOCATION_ID.ToLower() ) {
			return this.PrLocationId;
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
			try {
		switch (fieldKey) {
		case FLD_DEPARTMENT_ID:
			if (val == DBNull.Value || val == null ){
				throw new ApplicationException("Can't set Primary Key to null");
			} else {
				this.PrDepartmentId=(System.Int64)val;
			} //
			return;
		case FLD_DEPARTMENT_NAME:
			if (val == DBNull.Value || val == null ){
				this.PrDepartmentName = null;
			} else {
				this.PrDepartmentName=(System.String)val;
			} //
			return;
		case FLD_MANAGER_ID:
			if (val == DBNull.Value || val == null ){
				this.PrManagerId = null;
			} else {
				this.PrManagerId=(System.Int64?)val;
			} //
			return;
		case FLD_LOCATION_ID:
			if (val == DBNull.Value || val == null ){
				this.PrLocationId = null;
			} else {
				this.PrLocationId=(System.Int64?)val;
			} //
			return;
		case FLD_CREATE_DATE:
			if (val == DBNull.Value || val == null ){
				this.CreateDate = null;
			} else {
				this.CreateDate=(System.DateTime?)val;
			} //
			return;
		case FLD_UPDATE_DATE:
			if (val == DBNull.Value || val == null ){
				this.UpdateDate = null;
			} else {
				this.UpdateDate=(System.DateTime?)val;
			} //
			return;
		case FLD_CREATE_USER:
			if (val == DBNull.Value || val == null ){
				this.CreateUser = null;
			} else {
				this.CreateUser=(System.String)val;
			} //
			return;
		case FLD_UPDATE_USER:
			if (val == DBNull.Value || val == null ){
				this.UpdateUser = null;
			} else {
				this.UpdateUser=(System.String)val;
			} //
			return;
		default:
			return;
		}

			} catch ( Exception ex ) {
				throw new ApplicationException(
						String.Format("Error setting field with index {0}, value \"{1}\" : {2}", 
								fieldKey, val, ex.Message));
			}
		}

		public override void setAttribute(string fieldKey, object val) {
			fieldKey = fieldKey.ToLower();
			try {
		if ( fieldKey==STR_FLD_DEPARTMENT_ID.ToLower()){
			if (val == DBNull.Value || val ==null ){
				throw new ApplicationException("Can't set Primary Key to null");
			} else {
				this.PrDepartmentId=Convert.ToInt64(val);
			}
			return;
		} else if ( fieldKey==STR_FLD_DEPARTMENT_NAME.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.PrDepartmentName = null;
			} else {
				this.PrDepartmentName=Convert.ToString(val);
			}
			return;
		} else if ( fieldKey==STR_FLD_MANAGER_ID.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.PrManagerId = null;
			} else {
				this.PrManagerId=Convert.ToInt64(val);
			}
			return;
		} else if ( fieldKey==STR_FLD_LOCATION_ID.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.PrLocationId = null;
			} else {
				this.PrLocationId=Convert.ToInt64(val);
			}
			return;
		} else if ( fieldKey==STR_FLD_CREATE_DATE.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.CreateDate = null;
			} else {
				this.CreateDate=Convert.ToDateTime(val);
			}
			return;
		} else if ( fieldKey==STR_FLD_UPDATE_DATE.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.UpdateDate = null;
			} else {
				this.UpdateDate=Convert.ToDateTime(val);
			}
			return;
		} else if ( fieldKey==STR_FLD_CREATE_USER.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.CreateUser = null;
			} else {
				this.CreateUser=Convert.ToString(val);
			}
			return;
		} else if ( fieldKey==STR_FLD_UPDATE_USER.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.UpdateUser = null;
			} else {
				this.UpdateUser=Convert.ToString(val);
			}
			return;
		}
			} catch ( Exception ex ) {
				throw new ApplicationException(
					String.Format("Error setting field with index {0}, value \"{1}\" : {2}", 
							fieldKey, val, ex.Message));
			}
		}

		#endregion
		#region "Overrides of GetHashCode and Equals "
		public bool Equals(Department other)
		{

			//typesafe equals, checks for equality of fields
			if (other == null)
				return false;
			if (object.ReferenceEquals(other, this))
				return true;

			return this.PrDepartmentId == other.PrDepartmentId
				&& this.PrDepartmentName == other.PrDepartmentName
				&& this.PrManagerId.GetValueOrDefault() == other.PrManagerId.GetValueOrDefault()
				&& this.PrLocationId.GetValueOrDefault() == other.PrLocationId.GetValueOrDefault()
				&& this.CreateDate.GetValueOrDefault() == other.CreateDate.GetValueOrDefault()
				&& this.UpdateDate.GetValueOrDefault() == other.UpdateDate.GetValueOrDefault()
				&& this.CreateUser == other.CreateUser
				&& this.UpdateUser == other.UpdateUser;;

		}

		public override int GetHashCode()
		{
			//using Xor has the advantage of not overflowing the integer.
			return this.PrDepartmentId.GetHashCode()
				 ^ this.getStringHashCode(this.PrDepartmentName)
				 ^ this.PrManagerId.GetHashCode()
				 ^ this.PrLocationId.GetHashCode()
				 ^ this.CreateDate.GetHashCode()
				 ^ this.UpdateDate.GetHashCode()
				 ^ this.getStringHashCode(this.CreateUser)
				 ^ this.getStringHashCode(this.UpdateUser);;

		}

		public override bool Equals(object Obj) {

			if (Obj != null && Obj is Department) {

				return this.Equals((Department)Obj);

			} else {
				return false;
			}

		}

		public static bool operator ==(Department obj1, Department obj2)
		{
			return object.Equals(obj1, obj2);
		}

		public static bool operator !=(Department obj1, Department obj2) {
			return !(obj1 == obj2);
		}

		#endregion

		#region "Copy and sort"

		public override IModelObject copy() {
			//creates a copy
			Department ret = new Department();
		ret.PrDepartmentId = this.PrDepartmentId;
		ret.PrDepartmentName = this.PrDepartmentName;
		ret.PrManagerId = this.PrManagerId;
		ret.PrLocationId = this.PrLocationId;
		ret.CreateDate = this.CreateDate;
		ret.UpdateDate = this.UpdateDate;
		ret.CreateUser = this.CreateUser;
		ret.UpdateUser = this.UpdateUser;

			return ret;

		}

		#endregion




		#region "ID Property"

		[DataMember]public sealed override object Id {
			get { return this._DepartmentId; }
			set {
				this._DepartmentId = Convert.ToInt64(value);
				this.raiseBroadcastIdChange();
			}
		}
		#endregion

		#region "Extra Code"

		#endregion

	}

	#region "Req Fields validator"
	[System.Runtime.InteropServices.ComVisible(false)]
	public class DepartmentRequiredFieldsValidator : IModelObjectValidator
	{


		public void validate(org.model.lib.Model.IModelObject imo) {
			Department mo = (Department)imo;
if (string.IsNullOrEmpty( mo.PrDepartmentName)) {
		throw new ModelObjectRequiredFieldException("DepartmentName");
}

		}

	}
	#endregion

}


