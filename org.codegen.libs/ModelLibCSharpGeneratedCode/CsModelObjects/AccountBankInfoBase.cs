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
namespace CsModelObjects {

	[Table(Name = "AccountInfo")]
	[DataContract][SelectObject("AccountInfo")][KeyFieldName("AccInfoId")]
	[DefaultMapperAttr(typeof(CsModelMappers.AccountBankInfoDBMapper)), ComVisible(false), Serializable(), System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
	partial class AccountBankInfo:ModelObject,IEquatable<AccountBankInfo> ,IAuditable {

		#region "Constructor"

		public AccountBankInfo() {
			this.Id = ModelObjectKeyGen.nextId();
			this.addValidator(new AccountBankInfoRequiredFieldsValidator());
		}

		#endregion

		#region "Children and Parents"
		
		public override void loadObjectHierarchy() {
		LoadPrBank();

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
			if  ( this._Bank!=null && this.BankLoaded) {
	ret.Add(this.PrBank);
}

			return ret;
		}

		#endregion
		#region "Field CONSTANTS"

					public const String STR_FLD_ACCINFOID = "AccInfoId";
			public const String STR_FLD_CONTACTNAME = "ContactName";
			public const String STR_FLD_CONTACTPHONE = "ContactPhone";
			public const String STR_FLD_CONTACTFAX = "ContactFax";
			public const String STR_FLD_ACCOUNTID = "AccountID";
			public const String STR_FLD_SIGNEEEMPLOYEE = "SigneeEmployee";
			public const String STR_FLD_COMPANYNAME = "CompanyName";
			public const String STR_FLD_COMPANYBANKCODE = "CompanyBankCode";
			public const String STR_FLD_BANKID = "BankId";
			public const String STR_FLD_COOPCODE = "COOPCode";
			public const String STR_FLD_CREATEDATE = "Createdate";
			public const String STR_FLD_UPDATEDATE = "Updatedate";
			public const String STR_FLD_UPDATEUSER = "Updateuser";
			public const String STR_FLD_CREATEUSER = "Createuser";


				public const int FLD_ACCINFOID = 0;
		public const int FLD_CONTACTNAME = 1;
		public const int FLD_CONTACTPHONE = 2;
		public const int FLD_CONTACTFAX = 3;
		public const int FLD_ACCOUNTID = 4;
		public const int FLD_SIGNEEEMPLOYEE = 5;
		public const int FLD_COMPANYNAME = 6;
		public const int FLD_COMPANYBANKCODE = 7;
		public const int FLD_BANKID = 8;
		public const int FLD_COOPCODE = 9;
		public const int FLD_CREATEDATE = 10;
		public const int FLD_UPDATEDATE = 11;
		public const int FLD_UPDATEUSER = 12;
		public const int FLD_CREATEUSER = 13;



		///<summary> Returns the names of fields in the object as a string array.
		/// Useful in automatically setting/getting values from UI objects (windows or web Form)</summary>
		/// <returns> string array </returns>	 
		public override string[] getFieldList()
		{
			return new string[] {
				STR_FLD_ACCINFOID,STR_FLD_CONTACTNAME,STR_FLD_CONTACTPHONE,STR_FLD_CONTACTFAX,STR_FLD_ACCOUNTID,STR_FLD_SIGNEEEMPLOYEE,STR_FLD_COMPANYNAME,STR_FLD_COMPANYBANKCODE,STR_FLD_BANKID,STR_FLD_COOPCODE,STR_FLD_CREATEDATE,STR_FLD_UPDATEDATE,STR_FLD_UPDATEUSER,STR_FLD_CREATEUSER
			};
		}

		#endregion

		#region "Field Declarations"

	private System.Int64 _AccInfoId;
	private System.String _ContactName;
	private System.String _ContactPhone;
	private System.String _ContactFax;
	private System.Int64? _AccountID = null;
	private System.String _SigneeEmployee;
	private System.String _CompanyName;
	private System.String _CompanyBankCode;
	private System.Int64? _BankId = null;
	private System.String _COOPCode;
	private System.DateTime? _Createdate = null;
	private System.DateTime? _Updatedate = null;
	private System.String _Updateuser;
	private System.String _Createuser;
	// ****** CHILD OBJECTS ********************
[DataMember(Name="PrBank")]	private CsModelObjects.Bank _Bank = null;  //initialize to nothing, for lazy load logic below !!!

	// *****************************************
	// ****** END CHILD OBJECTS ********************

		#endregion

		#region "Field Properties"

		//Field AccInfoId
	[Required][Column(Name="AccInfoId",Storage = "_AccInfoId", IsPrimaryKey=true,DbType = "int NOT NULL",CanBeNull = false)]
	[DataMember]public virtual System.Int64 PrAccInfoId{
	get{
		return _AccInfoId;
	}
	set {
		if (ModelObject.valueChanged(_AccInfoId, value)){
			if (!this.IsObjectLoading) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_ACCINFOID);
			}
		this._AccInfoId = value;

			this.raiseBroadcastIdChange();

		}
		}
	}
		//Field ContactName
	[Key][StringLength(100, ErrorMessage="ContactName must be 100 characters or less")][Column(Name="ContactName",Storage = "_ContactName", IsPrimaryKey=false,DbType = "nvarchar",CanBeNull = true)]
	[DataMember]public virtual System.String PrContactName{
	get{
		return _ContactName;
	}
	set {
		if (ModelObject.valueChanged(_ContactName, value)){
		if (value != null && value.Length > 100){
			throw new ModelObjectFieldTooLongException("ContactName");
		}
			if (!this.IsObjectLoading) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_CONTACTNAME);
			}
		this._ContactName = value;

		}
		}
	}
		//Field ContactPhone
	[Key][StringLength(20, ErrorMessage="ContactPhone must be 20 characters or less")][Column(Name="ContactPhone",Storage = "_ContactPhone", IsPrimaryKey=false,DbType = "nvarchar",CanBeNull = true)]
	[DataMember]public virtual System.String PrContactPhone{
	get{
		return _ContactPhone;
	}
	set {
		if (ModelObject.valueChanged(_ContactPhone, value)){
		if (value != null && value.Length > 20){
			throw new ModelObjectFieldTooLongException("ContactPhone");
		}
			if (!this.IsObjectLoading) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_CONTACTPHONE);
			}
		this._ContactPhone = value;

		}
		}
	}
		//Field ContactFax
	[Key][StringLength(20, ErrorMessage="ContactFax must be 20 characters or less")][Column(Name="ContactFax",Storage = "_ContactFax", IsPrimaryKey=false,DbType = "nvarchar",CanBeNull = true)]
	[DataMember]public virtual System.String PrContactFax{
	get{
		return _ContactFax;
	}
	set {
		if (ModelObject.valueChanged(_ContactFax, value)){
		if (value != null && value.Length > 20){
			throw new ModelObjectFieldTooLongException("ContactFax");
		}
			if (!this.IsObjectLoading) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_CONTACTFAX);
			}
		this._ContactFax = value;

		}
		}
	}
		//Field accountID
	[Key][Column(Name="accountID",Storage = "_AccountID", IsPrimaryKey=false,DbType = "int",CanBeNull = true)]
	[DataMember]public virtual System.Int64? PrAccountID{
	get{
		return _AccountID;
	}
	set {
		if (ModelObject.valueChanged(_AccountID, value)){
			if (!this.IsObjectLoading) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_ACCOUNTID);
			}
		this._AccountID = value;

		}
		}
	}
		//Field signeeEmployee
	[Key][StringLength(100, ErrorMessage="signeeEmployee must be 100 characters or less")][Column(Name="signeeEmployee",Storage = "_SigneeEmployee", IsPrimaryKey=false,DbType = "nvarchar",CanBeNull = true)]
	[DataMember]public virtual System.String PrSigneeEmployee{
	get{
		return _SigneeEmployee;
	}
	set {
		if (ModelObject.valueChanged(_SigneeEmployee, value)){
		if (value != null && value.Length > 100){
			throw new ModelObjectFieldTooLongException("signeeEmployee");
		}
			if (!this.IsObjectLoading) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_SIGNEEEMPLOYEE);
			}
		this._SigneeEmployee = value;

		}
		}
	}
		//Field CompanyName
	[Key][StringLength(255, ErrorMessage="CompanyName must be 255 characters or less")][Column(Name="CompanyName",Storage = "_CompanyName", IsPrimaryKey=false,DbType = "nvarchar",CanBeNull = true)]
	[DataMember]public virtual System.String PrCompanyName{
	get{
		return _CompanyName;
	}
	set {
		if (ModelObject.valueChanged(_CompanyName, value)){
		if (value != null && value.Length > 255){
			throw new ModelObjectFieldTooLongException("CompanyName");
		}
			if (!this.IsObjectLoading) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_COMPANYNAME);
			}
		this._CompanyName = value;

		}
		}
	}
		//Field CompanyBankCode
	[Key][StringLength(20, ErrorMessage="CompanyBankCode must be 20 characters or less")][Column(Name="CompanyBankCode",Storage = "_CompanyBankCode", IsPrimaryKey=false,DbType = "nvarchar",CanBeNull = true)]
	[DataMember]public virtual System.String PrCompanyBankCode{
	get{
		return _CompanyBankCode;
	}
	set {
		if (ModelObject.valueChanged(_CompanyBankCode, value)){
		if (value != null && value.Length > 20){
			throw new ModelObjectFieldTooLongException("CompanyBankCode");
		}
			if (!this.IsObjectLoading) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_COMPANYBANKCODE);
			}
		this._CompanyBankCode = value;

		}
		}
	}
		//Field BankId
	[Key][Column(Name="BankId",Storage = "_BankId", IsPrimaryKey=false,DbType = "int",CanBeNull = true)]
	[DataMember]public virtual System.Int64? PrBankId{
	get{
		return _BankId;
	}
	set {
		if (ModelObject.valueChanged(_BankId, value)){
			if (!this.IsObjectLoading) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_BANKID);
			}
		this._BankId = value;

		}
		}
	}
		//Field COOPCode
	[Key][StringLength(100, ErrorMessage="COOPCode must be 100 characters or less")][Column(Name="COOPCode",Storage = "_COOPCode", IsPrimaryKey=false,DbType = "nvarchar",CanBeNull = true)]
	[DataMember]public virtual System.String PrCOOPCode{
	get{
		return _COOPCode;
	}
	set {
		if (ModelObject.valueChanged(_COOPCode, value)){
		if (value != null && value.Length > 100){
			throw new ModelObjectFieldTooLongException("COOPCode");
		}
			if (!this.IsObjectLoading) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_COOPCODE);
			}
		this._COOPCode = value;

		}
		}
	}
		//Field createdate
	[Key][Required][Column(Name="createdate",Storage = "_Createdate", IsPrimaryKey=false,DbType = "datetime NOT NULL",CanBeNull = false)]
	[DataMember]public virtual System.DateTime? CreateDate{
	get{
		return _Createdate;
	}
	set {
		if (ModelObject.valueChanged(_Createdate, value)){
			if (!this.IsObjectLoading) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_CREATEDATE);
			}
		this._Createdate = value;

		}
		}
	}
		//Field updatedate
	[Key][Required][Column(Name="updatedate",Storage = "_Updatedate", IsPrimaryKey=false,DbType = "datetime NOT NULL",CanBeNull = false)]
	[DataMember]public virtual System.DateTime? UpdateDate{
	get{
		return _Updatedate;
	}
	set {
		if (ModelObject.valueChanged(_Updatedate, value)){
			if (!this.IsObjectLoading) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_UPDATEDATE);
			}
		this._Updatedate = value;

		}
		}
	}
		//Field updateuser
	[Key][Required][StringLength(50, ErrorMessage="updateuser must be 50 characters or less")][Column(Name="updateuser",Storage = "_Updateuser", IsPrimaryKey=false,DbType = "varchar NOT NULL",CanBeNull = false)]
	[DataMember]public virtual System.String UpdateUser{
	get{
		return _Updateuser;
	}
	set {
		if (ModelObject.valueChanged(_Updateuser, value)){
		if (value != null && value.Length > 50){
			throw new ModelObjectFieldTooLongException("updateuser");
		}
			if (!this.IsObjectLoading) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_UPDATEUSER);
			}
		this._Updateuser = value;

		}
		}
	}
		//Field createuser
	[Key][Required][StringLength(50, ErrorMessage="createuser must be 50 characters or less")][Column(Name="createuser",Storage = "_Createuser", IsPrimaryKey=false,DbType = "varchar NOT NULL",CanBeNull = false)]
	[DataMember]public virtual System.String CreateUser{
	get{
		return _Createuser;
	}
	set {
		if (ModelObject.valueChanged(_Createuser, value)){
		if (value != null && value.Length > 50){
			throw new ModelObjectFieldTooLongException("createuser");
		}
			if (!this.IsObjectLoading) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_CREATEUSER);
			}
		this._Createuser = value;

		}
		}
	}
		#endregion
		#region "Associations"
		
		#region "Association Bank"
		//associationParentCSharp.txt
		private bool BankLoaded {get;set;}

		/// <summary>
        /// Gets/Sets parent object
        /// </summary>
		public virtual CsModelObjects.Bank PrBank {
		    //1-1 parent association
            set {
                this._Bank = value;
				if ( value != null ) {
					this.PrBankId = this._Bank.PrBANKID;
					this._Bank.IDChanged += this.handleParentIdChanged;
                } else {
					this.PrBankId = null;
				}

            }


            get {
                //LAZY LOADING! Only hit the database to get the child object if we need it
                if ( this._Bank == null ) {
					this.LoadPrBank();
                }
				
                return this._Bank;
            }
        }
        
        /// <summary>
        /// Loads parent object and sets the appropriate properties
        /// </summary>
        private void LoadPrBank() {
			
			if (this.BankLoaded) return;
			
			if ( this._Bank == null && this.PrBankId != null ) {
                
				//call the setter here, not the private variable!
                this.PrBank = new CsModelMappers.BankDBMapper().findByKey(this.PrBankId);
                
            }

            this.BankLoaded=true;
			            
       }
		#endregion


		#endregion

		#region "Getters/Setters of values by field index/name"
		public override object getAttribute(int fieldKey){

		switch (fieldKey) {
		case FLD_ACCINFOID:
			return this.PrAccInfoId;
		case FLD_CONTACTNAME:
			return this.PrContactName;
		case FLD_CONTACTPHONE:
			return this.PrContactPhone;
		case FLD_CONTACTFAX:
			return this.PrContactFax;
		case FLD_ACCOUNTID:
			return this.PrAccountID;
		case FLD_SIGNEEEMPLOYEE:
			return this.PrSigneeEmployee;
		case FLD_COMPANYNAME:
			return this.PrCompanyName;
		case FLD_COMPANYBANKCODE:
			return this.PrCompanyBankCode;
		case FLD_BANKID:
			return this.PrBankId;
		case FLD_COOPCODE:
			return this.PrCOOPCode;
		case FLD_CREATEDATE:
			return this.CreateDate;
		case FLD_UPDATEDATE:
			return this.UpdateDate;
		case FLD_UPDATEUSER:
			return this.UpdateUser;
		case FLD_CREATEUSER:
			return this.CreateUser;
		default:
			return null;
		} //end switch

		}

		public override object getAttribute(string fieldKey) {
			fieldKey = fieldKey.ToLower();

		if (fieldKey==STR_FLD_ACCINFOID.ToLower() ) {
			return this.PrAccInfoId;
		} else if (fieldKey==STR_FLD_CONTACTNAME.ToLower() ) {
			return this.PrContactName;
		} else if (fieldKey==STR_FLD_CONTACTPHONE.ToLower() ) {
			return this.PrContactPhone;
		} else if (fieldKey==STR_FLD_CONTACTFAX.ToLower() ) {
			return this.PrContactFax;
		} else if (fieldKey==STR_FLD_ACCOUNTID.ToLower() ) {
			return this.PrAccountID;
		} else if (fieldKey==STR_FLD_SIGNEEEMPLOYEE.ToLower() ) {
			return this.PrSigneeEmployee;
		} else if (fieldKey==STR_FLD_COMPANYNAME.ToLower() ) {
			return this.PrCompanyName;
		} else if (fieldKey==STR_FLD_COMPANYBANKCODE.ToLower() ) {
			return this.PrCompanyBankCode;
		} else if (fieldKey==STR_FLD_BANKID.ToLower() ) {
			return this.PrBankId;
		} else if (fieldKey==STR_FLD_COOPCODE.ToLower() ) {
			return this.PrCOOPCode;
		} else if (fieldKey==STR_FLD_CREATEDATE.ToLower() ) {
			return this.CreateDate;
		} else if (fieldKey==STR_FLD_UPDATEDATE.ToLower() ) {
			return this.UpdateDate;
		} else if (fieldKey==STR_FLD_UPDATEUSER.ToLower() ) {
			return this.UpdateUser;
		} else if (fieldKey==STR_FLD_CREATEUSER.ToLower() ) {
			return this.CreateUser;
		} else {
			return null;
		}
		}

		public override void setAttribute(int fieldKey, object val){
			try {
		switch (fieldKey) {
		case FLD_ACCINFOID:
			if (val == DBNull.Value || val == null ){
				throw new ApplicationException("Can't set Primary Key to null");
			} else {
				this.PrAccInfoId=(System.Int64)val;
			} //
			return;
		case FLD_CONTACTNAME:
			if (val == DBNull.Value || val == null ){
				this.PrContactName = null;
			} else {
				this.PrContactName=(System.String)val;
			} //
			return;
		case FLD_CONTACTPHONE:
			if (val == DBNull.Value || val == null ){
				this.PrContactPhone = null;
			} else {
				this.PrContactPhone=(System.String)val;
			} //
			return;
		case FLD_CONTACTFAX:
			if (val == DBNull.Value || val == null ){
				this.PrContactFax = null;
			} else {
				this.PrContactFax=(System.String)val;
			} //
			return;
		case FLD_ACCOUNTID:
			if (val == DBNull.Value || val == null ){
				this.PrAccountID = null;
			} else {
				this.PrAccountID=(System.Int64?)val;
			} //
			return;
		case FLD_SIGNEEEMPLOYEE:
			if (val == DBNull.Value || val == null ){
				this.PrSigneeEmployee = null;
			} else {
				this.PrSigneeEmployee=(System.String)val;
			} //
			return;
		case FLD_COMPANYNAME:
			if (val == DBNull.Value || val == null ){
				this.PrCompanyName = null;
			} else {
				this.PrCompanyName=(System.String)val;
			} //
			return;
		case FLD_COMPANYBANKCODE:
			if (val == DBNull.Value || val == null ){
				this.PrCompanyBankCode = null;
			} else {
				this.PrCompanyBankCode=(System.String)val;
			} //
			return;
		case FLD_BANKID:
			if (val == DBNull.Value || val == null ){
				this.PrBankId = null;
			} else {
				this.PrBankId=(System.Int64?)val;
			} //
			return;
		case FLD_COOPCODE:
			if (val == DBNull.Value || val == null ){
				this.PrCOOPCode = null;
			} else {
				this.PrCOOPCode=(System.String)val;
			} //
			return;
		case FLD_CREATEDATE:
			if (val == DBNull.Value || val == null ){
				this.CreateDate = null;
			} else {
				this.CreateDate=(System.DateTime?)val;
			} //
			return;
		case FLD_UPDATEDATE:
			if (val == DBNull.Value || val == null ){
				this.UpdateDate = null;
			} else {
				this.UpdateDate=(System.DateTime?)val;
			} //
			return;
		case FLD_UPDATEUSER:
			if (val == DBNull.Value || val == null ){
				this.UpdateUser = null;
			} else {
				this.UpdateUser=(System.String)val;
			} //
			return;
		case FLD_CREATEUSER:
			if (val == DBNull.Value || val == null ){
				this.CreateUser = null;
			} else {
				this.CreateUser=(System.String)val;
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
		if ( fieldKey==STR_FLD_ACCINFOID.ToLower()){
			if (val == DBNull.Value || val ==null ){
				throw new ApplicationException("Can't set Primary Key to null");
			} else {
				this.PrAccInfoId=Convert.ToInt64(val);
			}
			return;
		} else if ( fieldKey==STR_FLD_CONTACTNAME.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.PrContactName = null;
			} else {
				this.PrContactName=Convert.ToString(val);
			}
			return;
		} else if ( fieldKey==STR_FLD_CONTACTPHONE.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.PrContactPhone = null;
			} else {
				this.PrContactPhone=Convert.ToString(val);
			}
			return;
		} else if ( fieldKey==STR_FLD_CONTACTFAX.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.PrContactFax = null;
			} else {
				this.PrContactFax=Convert.ToString(val);
			}
			return;
		} else if ( fieldKey==STR_FLD_ACCOUNTID.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.PrAccountID = null;
			} else {
				this.PrAccountID=Convert.ToInt64(val);
			}
			return;
		} else if ( fieldKey==STR_FLD_SIGNEEEMPLOYEE.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.PrSigneeEmployee = null;
			} else {
				this.PrSigneeEmployee=Convert.ToString(val);
			}
			return;
		} else if ( fieldKey==STR_FLD_COMPANYNAME.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.PrCompanyName = null;
			} else {
				this.PrCompanyName=Convert.ToString(val);
			}
			return;
		} else if ( fieldKey==STR_FLD_COMPANYBANKCODE.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.PrCompanyBankCode = null;
			} else {
				this.PrCompanyBankCode=Convert.ToString(val);
			}
			return;
		} else if ( fieldKey==STR_FLD_BANKID.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.PrBankId = null;
			} else {
				this.PrBankId=Convert.ToInt64(val);
			}
			return;
		} else if ( fieldKey==STR_FLD_COOPCODE.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.PrCOOPCode = null;
			} else {
				this.PrCOOPCode=Convert.ToString(val);
			}
			return;
		} else if ( fieldKey==STR_FLD_CREATEDATE.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.CreateDate = null;
			} else {
				this.CreateDate=Convert.ToDateTime(val);
			}
			return;
		} else if ( fieldKey==STR_FLD_UPDATEDATE.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.UpdateDate = null;
			} else {
				this.UpdateDate=Convert.ToDateTime(val);
			}
			return;
		} else if ( fieldKey==STR_FLD_UPDATEUSER.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.UpdateUser = null;
			} else {
				this.UpdateUser=Convert.ToString(val);
			}
			return;
		} else if ( fieldKey==STR_FLD_CREATEUSER.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.CreateUser = null;
			} else {
				this.CreateUser=Convert.ToString(val);
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
		public bool Equals(AccountBankInfo other)
		{

			//typesafe equals, checks for equality of fields
			if (other == null)
				return false;
			if (object.ReferenceEquals(other, this))
				return true;

			return this.PrAccInfoId == other.PrAccInfoId
				&& this.PrContactName == other.PrContactName
				&& this.PrContactPhone == other.PrContactPhone
				&& this.PrContactFax == other.PrContactFax
				&& this.PrAccountID.GetValueOrDefault() == other.PrAccountID.GetValueOrDefault()
				&& this.PrSigneeEmployee == other.PrSigneeEmployee
				&& this.PrCompanyName == other.PrCompanyName
				&& this.PrCompanyBankCode == other.PrCompanyBankCode
				&& this.PrBankId.GetValueOrDefault() == other.PrBankId.GetValueOrDefault()
				&& this.PrCOOPCode == other.PrCOOPCode
				&& this.CreateDate.GetValueOrDefault() == other.CreateDate.GetValueOrDefault()
				&& this.UpdateDate.GetValueOrDefault() == other.UpdateDate.GetValueOrDefault()
				&& this.UpdateUser == other.UpdateUser
				&& this.CreateUser == other.CreateUser;;

		}

		public override int GetHashCode()
		{
			//using Xor has the advantage of not overflowing the integer.
			return this.PrAccInfoId.GetHashCode()
				 ^ this.getStringHashCode(this.PrContactName)
				 ^ this.getStringHashCode(this.PrContactPhone)
				 ^ this.getStringHashCode(this.PrContactFax)
				 ^ this.PrAccountID.GetHashCode()
				 ^ this.getStringHashCode(this.PrSigneeEmployee)
				 ^ this.getStringHashCode(this.PrCompanyName)
				 ^ this.getStringHashCode(this.PrCompanyBankCode)
				 ^ this.PrBankId.GetHashCode()
				 ^ this.getStringHashCode(this.PrCOOPCode)
				 ^ this.CreateDate.GetHashCode()
				 ^ this.UpdateDate.GetHashCode()
				 ^ this.getStringHashCode(this.UpdateUser)
				 ^ this.getStringHashCode(this.CreateUser);;

		}

		public override bool Equals(object Obj) {

			if (Obj != null && Obj is AccountBankInfo) {

				return this.Equals((AccountBankInfo)Obj);

			} else {
				return false;
			}

		}

		public static bool operator ==(AccountBankInfo obj1, AccountBankInfo obj2)
		{
			return object.Equals(obj1, obj2);
		}

		public static bool operator !=(AccountBankInfo obj1, AccountBankInfo obj2) {
			return !(obj1 == obj2);
		}

		#endregion

		#region "Copy and sort"

		public override IModelObject copy() {
			//creates a copy
			AccountBankInfo ret = new AccountBankInfo();
		ret.PrAccInfoId = this.PrAccInfoId;
		ret.PrContactName = this.PrContactName;
		ret.PrContactPhone = this.PrContactPhone;
		ret.PrContactFax = this.PrContactFax;
		ret.PrAccountID = this.PrAccountID;
		ret.PrSigneeEmployee = this.PrSigneeEmployee;
		ret.PrCompanyName = this.PrCompanyName;
		ret.PrCompanyBankCode = this.PrCompanyBankCode;
		ret.PrBankId = this.PrBankId;
		ret.PrCOOPCode = this.PrCOOPCode;
		ret.CreateDate = this.CreateDate;
		ret.UpdateDate = this.UpdateDate;
		ret.UpdateUser = this.UpdateUser;
		ret.CreateUser = this.CreateUser;

			return ret;

		}

		#endregion

#region "parentIdChanged"
	///below sub is called when parentIdChanged
	public override void handleParentIdChanged(Object parentMo, IDChangedEventArgs e){
		// Assocations from CsModelObjects.Account
		if ( parentMo is CsModelObjects.Account) {
			this.PrAccountID= ((CsModelObjects.Account)parentMo).PrAccountid;
		}
		// Assocations from CsModelObjects.Bank
		if ( parentMo is CsModelObjects.Bank) {
			this.PrBankId= ((CsModelObjects.Bank)parentMo).PrBANKID;
		}
	}
#endregion



		#region "ID Property"

		[DataMember]public sealed override object Id {
			get { return this._AccInfoId; }
			set {
				this._AccInfoId = Convert.ToInt64(value);
				this.raiseBroadcastIdChange();
			}
		}
		#endregion

		#region "Extra Code"

		#endregion

	}

	#region "Req Fields validator"
	[System.Runtime.InteropServices.ComVisible(false)]
	public class AccountBankInfoRequiredFieldsValidator : IModelObjectValidator
	{


		public void validate(org.model.lib.Model.IModelObject imo) {
			AccountBankInfo mo = (AccountBankInfo)imo;
if (mo.CreateDate == null ) {
		throw new ModelObjectRequiredFieldException("Createdate");
}
if (mo.UpdateDate == null ) {
		throw new ModelObjectRequiredFieldException("Updatedate");
}
if (string.IsNullOrEmpty( mo.UpdateUser)) {
		throw new ModelObjectRequiredFieldException("Updateuser");
}
if (string.IsNullOrEmpty( mo.CreateUser)) {
		throw new ModelObjectRequiredFieldException("Createuser");
}

		}

	}
	#endregion

}


