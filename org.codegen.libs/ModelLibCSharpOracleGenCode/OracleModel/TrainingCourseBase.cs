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
// Instead, change code in the extender class TrainingCourse
//
//************************************************************
//</comments>
namespace OracleModel
{

	#region "Interface"
[System.Runtime.InteropServices.ComVisible(false)] 
	public interface ITrainingCourse: IModelObject {
	System.String PrCODE {get;set;} 
	System.String PrDescrGr {get;set;} 
	System.String PrDescrEn {get;set;} 
}
#endregion

	
	[DefaultMapperAttr(typeof(OracleMappers.TrainingCourseDBMapper)), ComVisible(false), Serializable(), System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
	public class TrainingCourseBase : ModelObject, IEquatable<TrainingCourseBase>, ITrainingCourse {

		#region "Constructor"

		public TrainingCourseBase() {
			this.addValidator(new TrainingCourseRequiredFieldsValidator());
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

					public const String STR_FLD_CODE = "CODE";
			public const String STR_FLD_DESCR_GR = "DescrGr";
			public const String STR_FLD_DESCR_EN = "DescrEn";


				public const int FLD_CODE = 0;
		public const int FLD_DESCR_GR = 1;
		public const int FLD_DESCR_EN = 2;



		///<summary> Returns the names of fields in the object as a string array.
		/// Useful in automatically setting/getting values from UI objects (windows or web Form)</summary>
		/// <returns> string array </returns>	 
		public override string[] getFieldList()
		{
			return new string[] {
				STR_FLD_CODE,STR_FLD_DESCR_GR,STR_FLD_DESCR_EN
			};
		}

		#endregion

		#region "Field Declarations"

	private System.String _CODE;
	private System.String _DescrGr = null;
	private System.String _DescrEn = null;

		#endregion

		#region "Field Properties"

	public virtual System.String PrCODE  {
	get {
		return _CODE;
	} 
	set {
		if (ModelObject.valueChanged(_CODE, value)) {
			if (!this.IsObjectLoading ) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_CODE);
			}
			this._CODE = value;

			this.raiseBroadcastIdChange();

		}
	}  
	}
public void setCODE( String val ) {
	if (! string.IsNullOrEmpty(val)) {
		this.PrCODE = val;
	} else {
		this.PrCODE = null;
	}
}
	public virtual System.String PrDescrGr  {
	get {
		return _DescrGr;
	} 
	set {
		if (ModelObject.valueChanged(_DescrGr, value)) {
			if (!this.IsObjectLoading ) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_DESCR_GR);
			}
			this._DescrGr = value;

		}
	}  
	}
public void setDescrGr( String val ) {
	if (! string.IsNullOrEmpty(val)) {
		this.PrDescrGr = val;
	} else {
		this.PrDescrGr = null;
	}
}
	public virtual System.String PrDescrEn  {
	get {
		return _DescrEn;
	} 
	set {
		if (ModelObject.valueChanged(_DescrEn, value)) {
			if (!this.IsObjectLoading ) {
				this.isDirty = true;
				this.setFieldChanged(STR_FLD_DESCR_EN);
			}
			this._DescrEn = value;

		}
	}  
	}
public void setDescrEn( String val ) {
	if (! string.IsNullOrEmpty(val)) {
		this.PrDescrEn = val;
	} else {
		this.PrDescrEn = null;
	}
}

		#endregion

		#region "Getters/Setters of values by field index/name"
		public override object getAttribute(int fieldKey){

		switch (fieldKey) {
		case FLD_CODE:
			return this.PrCODE;
		case FLD_DESCR_GR:
			return this.PrDescrGr;
		case FLD_DESCR_EN:
			return this.PrDescrEn;
		default:
			return null;
		} //end switch

		}

		public override object getAttribute(string fieldKey) {
			fieldKey = fieldKey.ToLower();

		if (fieldKey==STR_FLD_CODE.ToLower() ) {
			return this.PrCODE;
		} else if (fieldKey==STR_FLD_DESCR_GR.ToLower() ) {
			return this.PrDescrGr;
		} else if (fieldKey==STR_FLD_DESCR_EN.ToLower() ) {
			return this.PrDescrEn;
		} else {
			return null;
		}
		}

		public override void setAttribute(int fieldKey, object val){
		switch (fieldKey) {
		case FLD_CODE:
			if (val == DBNull.Value || val == null ){
				throw new ApplicationException("Can't set Primary Key to null");
			}else{
				this.PrCODE=(System.String)val;
			} //
			return;
		case FLD_DESCR_GR:
			if (val == DBNull.Value || val == null ){
				this.PrDescrGr = null;
			}else{
				this.PrDescrGr=(System.String)val;
			} //
			return;
		case FLD_DESCR_EN:
			if (val == DBNull.Value || val == null ){
				this.PrDescrEn = null;
			}else{
				this.PrDescrEn=(System.String)val;
			} //
			return;
		default:
			return;
		}

		}

		public override void setAttribute(string fieldKey, object val) {
			fieldKey = fieldKey.ToLower();
		if ( fieldKey==STR_FLD_CODE.ToLower()){
			if (val == DBNull.Value || val ==null ){
				throw new ApplicationException("Can't set Primary Key to null");
			} else {
				this.PrCODE=(System.String)val;
			}
			return;
		} else if ( fieldKey==STR_FLD_DESCR_GR.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.PrDescrGr = null;
			} else {
				this.PrDescrGr=(System.String)val;
			}
			return;
		} else if ( fieldKey==STR_FLD_DESCR_EN.ToLower()){
			if (val == DBNull.Value || val ==null ){
				this.PrDescrEn = null;
			} else {
				this.PrDescrEn=(System.String)val;
			}
			return;
		}
		}

		#endregion
		#region "Overrides of GetHashCode and Equals "
		public bool Equals(TrainingCourseBase other)
		{

			//typesafe equals, checks for equality of fields
			if (other == null)
				return false;
			if (object.ReferenceEquals(other, this))
				return true;

			return this.PrCODE == other.PrCODE
				&& this.PrDescrGr == other.PrDescrGr
				&& this.PrDescrEn == other.PrDescrEn;;

		}

		public override int GetHashCode()
		{
			//using Xor has the advantage of not overflowing the integer.
			return this.getStringHashCode(this.PrCODE)
				 ^ this.getStringHashCode(this.PrDescrGr)
				 ^ this.getStringHashCode(this.PrDescrEn);;

		}

		public override bool Equals(object Obj) {

			if (Obj != null && Obj is TrainingCourseBase) {

				return this.Equals((TrainingCourseBase)Obj);

			} else {
				return false;
			}

		}

		public static bool operator ==(TrainingCourseBase obj1, TrainingCourseBase obj2)
		{
			return object.Equals(obj1, obj2);
		}

		public static bool operator !=(TrainingCourseBase obj1, TrainingCourseBase obj2)
		{
			return !(obj1 == obj2);
		}

		#endregion

		#region "Copy and sort"

		public override IModelObject copy()
		{
			//creates a copy

			//NOTE: we can't cast from TrainingCourseBase to TrainingCourse, so below we 
			//instantiate a TrainingCourse, NOT a TrainingCourseBase object
			TrainingCourse ret = TrainingCourseFactory.Create();

		ret.PrCODE = this.PrCODE;
		ret.PrDescrGr = this.PrDescrGr;
		ret.PrDescrEn = this.PrDescrEn;



			return ret;

		}


		

		#endregion




		#region "ID Property"

		public override object Id {
			get { return this._CODE; }
			set {
				this._CODE = Convert.ToString(value);
				this.raiseBroadcastIdChange();
			}
		}
		#endregion

		#region "Extra Code"

		#endregion

	}

	#region "Req Fields validator"
	[System.Runtime.InteropServices.ComVisible(false)]
	public class TrainingCourseRequiredFieldsValidator : IModelObjectValidator
	{


		public void validate(org.model.lib.Model.IModelObject imo) {
			TrainingCourse mo = (TrainingCourse)imo;

		}

	}
	#endregion

}


