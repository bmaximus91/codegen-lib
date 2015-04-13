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
// Instead, change code in the extender class EmployeeRank
//
//************************************************************
//</comments>
namespace CsModelObjects
{

	#region "Interface"
[System.Runtime.InteropServices.ComVisible(false)] 
	public interface IEmployeeRank: IModelObject {
	System.Int64 RankId {get;set;} 
	System.String Rank {get;set;} 
}
#endregion

	
	[DefaultMapperAttr(typeof(CsModelMappers.EmployeeRankDBMapper)), ComVisible(false), Serializable(), System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
	public class EmployeeRankBase : ModelObject, IEquatable<EmployeeRankBase>, IEmployeeRank
	{

		#region "Constructor"

		public EmployeeRankBase()
		{
			this.addValidator(new EmployeeRankRequiredFieldsValidator());
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

					public const String STR_FLD_RANKID = "RankId";
			public const String STR_FLD_RANK = "Rank";


				public const int FLD_RANKID = 0;
		public const int FLD_RANK = 1;



		///<summary> Returns the names of fields in the object as a string array.
		/// Useful in automatically setting/getting values from UI objects (windows or web Form)</summary>
		/// <returns> string array </returns>	 
		public override string[] getFieldList()
		{
			return new string[] {
				STR_FLD_RANKID,STR_FLD_RANK
			};
		}

		#endregion

		#region "Field Declarations"

	private System.Int64 _RankId;
	private System.String _Rank = null;

		#endregion

		#region "Field Properties"

	public virtual System.Int64 RankId  {
	get {
		return _RankId;
	} 
	set {
		if (ModelObject.valueChanged(_RankId, value)) {
			if (!this.IsObjectLoading ) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_RANKID);
			}
			this._RankId = value;

			this.raiseBroadcastIdChange();

		}
	}  
	}
public void setRankId(String val){
	if (Information.IsNumeric(val)) {
		this.RankId = Convert.ToInt32(val);
	} else if (String.IsNullOrEmpty(val)) {
		throw new ApplicationException("Cant update Primary Key to Null");
	} else {
		throw new ApplicationException("Invalid Integer Number, field:RankId, value:" + val);
	}
}
	public virtual System.String Rank  {
	get {
		return _Rank;
	} 
	set {
		if (ModelObject.valueChanged(_Rank, value)) {
			if (!this.IsObjectLoading ) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_RANK);
			}
			this._Rank = value;

		}
	}  
	}
public void setRank( String val ) {
	if (! string.IsNullOrEmpty(val)) {
		this.Rank = val;
	} else {
		this.Rank = null;
	}
}

		#endregion

		#region "Getters/Setters of values by field index/name"
		public override object getAttribute(int fieldKey){

		switch (fieldKey) {
		case FLD_RANKID:
			return this.RankId;
		case FLD_RANK:
			return this.Rank;
		default:
			return null;
		} //end switch

		}

		public override object getAttribute(string fieldKey) {
			fieldKey = fieldKey.ToLower();

		if (fieldKey==STR_FLD_RANKID.ToLower() ) {
			return this.RankId;
		} else if (fieldKey==STR_FLD_RANK.ToLower() ) {
			return this.Rank;
		} else {
			return null;
		}
		}

		public override void setAttribute(int fieldKey, object val){
		switch (fieldKey) {
		case FLD_RANKID:
			if (val == DBNull.Value || val == null ){
				throw new ApplicationException("Can't set Primary Key to null");
			}else{
				this.RankId=(System.Int64)val;
			} //
			return;
		case FLD_RANK:
			if (val == DBNull.Value || val == null ){
				this.Rank = null;
			}else{
				this.Rank=(System.String)val;
			} //
			return;
		default:
			return;
		}

		}

		public override void setAttribute(string fieldKey, object val) {
			fieldKey = fieldKey.ToLower();
		if ( fieldKey==STR_FLD_RANKID.ToLower()){
			if (val == DBNull.Value || val ==null ){
				throw new ApplicationException("Can't set Primary Key to null");
			} else {
				this.RankId=(System.Int64)val;
			}
			return;
		} else if ( fieldKey==STR_FLD_RANK.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.Rank = null;
			} else {
				this.Rank=(System.String)val;
			}
			return;
		}
		}

		#endregion
		#region "Overrides of GetHashCode and Equals "
		public bool Equals(EmployeeRankBase other)
		{

			//typesafe equals, checks for equality of fields
			if (other == null)
				return false;
			if (object.ReferenceEquals(other, this))
				return true;

			return this.RankId == other.RankId
				&& this.Rank == other.Rank;;

		}

		public override int GetHashCode()
		{
			//using Xor has the advantage of not overflowing the integer.
			return this.RankId.GetHashCode()
				 ^ this.getStringHashCode(this.Rank);;

		}

		public override bool Equals(object Obj) {

			if (Obj != null && Obj is EmployeeRankBase) {

				return this.Equals((EmployeeRankBase)Obj);

			} else {
				return false;
			}

		}

		public static bool operator ==(EmployeeRankBase obj1, EmployeeRankBase obj2)
		{
			return object.Equals(obj1, obj2);
		}

		public static bool operator !=(EmployeeRankBase obj1, EmployeeRankBase obj2)
		{
			return !(obj1 == obj2);
		}

		#endregion

		#region "Copy and sort"

		public override IModelObject copy()
		{
			//creates a copy

			//NOTE: we can't cast from EmployeeRankBase to EmployeeRank, so below we 
			//instantiate a EmployeeRank, NOT a EmployeeRankBase object
			EmployeeRank ret = EmployeeRankFactory.Create();

		ret.RankId = this.RankId;
		ret.Rank = this.Rank;



			return ret;

		}

		public override void merge(IModelObject other)
		{
			//merges this EmployeeRank model object (me) with the "other" instance 

			EmployeeRank o = (EmployeeRank)other;

if (! string.IsNullOrEmpty(o.Rank) && 
		 string.IsNullOrEmpty(this.Rank)){
		this.Rank = o.Rank;
}


		}

		

		#endregion




		#region "ID Property"

		public override object Id {
			get { return this._RankId; }
			set {
				this._RankId = Convert.ToInt64(value);
				this.raiseBroadcastIdChange();
			}
		}
		#endregion

		#region "Extra Code"

		#endregion

	}

	#region "Req Fields validator"
	[System.Runtime.InteropServices.ComVisible(false)]
	public class EmployeeRankRequiredFieldsValidator : IModelObjectValidator
	{


		public void validate(org.model.lib.Model.IModelObject imo) {
			EmployeeRank mo = (EmployeeRank)imo;
if (string.IsNullOrEmpty( mo.Rank)) {
		throw new ModelObjectRequiredFieldException("Rank");
}

		}

	}
	#endregion

}


