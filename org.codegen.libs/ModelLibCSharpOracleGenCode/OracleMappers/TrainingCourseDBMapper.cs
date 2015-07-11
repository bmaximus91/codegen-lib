﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using org.model.lib;
using org.model.lib.Model;
using org.model.lib.db;

using System.Linq;
using OracleModel;
using System.Data.Linq.Mapping;

//<comments>
// Template: DBMapperBase.csharp.txt
//************************************************************
// 
// Class autogenerated on11-Jul-15 4:07:09 PM by ModelGenerator
// Extends base DBMapperBase object class
// *** DO NOT change code in this class.  
//     It will be re-generated and 
//     overwritten by the code generator ****
// Instead, change code in the extender class TrainingCourseDBMapper
//
//************************************************************
//</comments>

namespace OracleMappers {

	[System.Runtime.InteropServices.ComVisible(false)]
[AttrIsPrimaryKeyAutogenerated(false)]
	[Table(Name = "training_courses")]
	[SelectObject("training_courses")][KeyFieldName("CODE")]
	public class TrainingCourseDBMapper : OracleDBMapper {

		#region "Constructors "
		public TrainingCourseDBMapper(DBUtils _dbConn) : base(_dbConn) {
		}


		public TrainingCourseDBMapper() : base() {
		}
		#endregion

		#region "Overloaded Functions"

		public new TrainingCourse findWhere(string sWhereClause, params object[] @params) {

			return (TrainingCourse)base.findWhere(sWhereClause, @params);
		}


		public void saveTrainingCourse(TrainingCourse mo) {
			base.save(mo);
		}

		public new TrainingCourse findByKey(object keyval) {

			return (TrainingCourse)base.findByKey(keyval);

		}

		#endregion


		#region "getUpdateDBCommand"
		public override IDbCommand getUpdateDBCommand(IModelObject modelObj, string sql) {
			TrainingCourse obj = (TrainingCourse)modelObj;
			IDbCommand stmt = this.dbConn.getCommand(sql);
			stmt.Parameters.Add(this.dbConn.getParameter(TrainingCourse.STR_FLD_DESCR_GR,obj.PrDescrGr));
			stmt.Parameters.Add(this.dbConn.getParameter(TrainingCourse.STR_FLD_DESCR_EN,obj.PrDescrEn));

			stmt.Parameters.Add(this.dbConn.getParameter(TrainingCourse.STR_FLD_CODE,obj.PrCODE));


			return stmt;
		}
		#endregion



		#region "Find functions"

		///	<summary>Given an sql statement, it opens a result set, and for each record returned, 
		///	it creates and loads a ModelObject. 
		/// </summary>
		///	<param name="sWhereClause">where clause to be applied to "selectall" statement 
		/// that returns one or more records from the database, corresponding to the ModelObject we are going to load </param>
		///	<param name="params"> Parameter values to be passed to sql statement </param>
		///	<returns> A List(Of TrainingCourse) object containing all objects loaded </returns>
		///	 
		public new List<TrainingCourse> findList(string sWhereClause, params object[] @params) {

			string sql = this.getSqlWithWhereClause(sWhereClause);
			IDataReader rs = null;
			List<TrainingCourse> molist = new List<TrainingCourse>();

			try {
				rs = dbConn.getDataReaderWithParams(sql, @params);
				this.Loader.DataSource = rs;

				while (rs.Read()) {
					IModelObject mo = this.getModelInstance();
					this.Loader.load(mo);
					molist.Add((TrainingCourse)mo);

				}


			} finally {
				this.dbConn.closeDataReader(rs);
			}

			return molist;

		}

		///	<summary>Given an sql statement, it opens a result set, and for each record returned, 
		///	it creates and loads a ModelObject. </summary>
		///	<param name="sWhereClause">where clause to be applied to "selectall" statement 
		/// that returns one or more records from the database, corresponding to the ModelObject we are going to load </param>
		///	<param name="params"> List of IDataParameters to be passed to sql statement </param>
		///	<returns> A List(Of TrainingCourse) object containing all objects loaded </returns>
		///	 
		public List<TrainingCourse> findList(string sWhereClause, List<IDataParameter> @params) {

			string sql = this.getSqlWithWhereClause(sWhereClause);
			IDataReader rs = null;
			List<TrainingCourse> molist = new List<TrainingCourse>();

			try {
				rs = dbConn.getDataReader(sql, @params);
				this.Loader.DataSource = rs;

				while (rs.Read()) {
					IModelObject mo = this.getModelInstance();
					this.Loader.load(mo);
					molist.Add((TrainingCourse)mo);

				}


			} finally {
				this.dbConn.closeDataReader(rs);
			}

			return molist;

		}


		///    
		///	 <summary>Returns all records from database for a coresponding ModelObject </summary>
		/// <returns>List(Of TrainingCourse) </returns>
		public List<TrainingCourse> findAll()
		{
			return this.findList(string.Empty);
		}

		public override IModelObjectLoader Loader {
			get {
				if (this._loader == null) {
					this._loader = new TrainingCourseDataReaderLoader();
				}
				return this._loader;
			}
			set { this._loader = value; }
		}

		#endregion

		public override IModelObject getModelInstance() {
			return new TrainingCourse();
		}

	}

	#region " TrainingCourse Loader "
	[System.Runtime.InteropServices.ComVisible(false)]
	public class TrainingCourseDataReaderLoader : DataReaderLoader {
		public override void load(IModelObject mo) {
			const int DATAREADER_FLD_CODE = 0;
			const int DATAREADER_FLD_DESCR_GR = 1;
			const int DATAREADER_FLD_DESCR_EN = 2;

			TrainingCourse obj = (TrainingCourse)mo;
			obj.IsObjectLoading = true;

			if (!this.reader.IsDBNull(DATAREADER_FLD_CODE) ) {
				obj.PrCODE = this.reader.GetString(DATAREADER_FLD_CODE);
			}
			if (!this.reader.IsDBNull(DATAREADER_FLD_DESCR_GR) ) {
				obj.PrDescrGr = this.reader.GetString(DATAREADER_FLD_DESCR_GR);
			}
			if (!this.reader.IsDBNull(DATAREADER_FLD_DESCR_EN) ) {
				obj.PrDescrEn = this.reader.GetString(DATAREADER_FLD_DESCR_EN);
			}


			obj.isNew = false;
			// since we've just loaded from database, we mark as "old"
			obj.isDirty = false;
			obj.IsObjectLoading = false;
			obj.afterLoad();

			return;

		}

	}

	#endregion

	///<summary>
	/// Final Class with convinience shared methods for loading/saving the TrainingCourseRank ModelObject. 
	///</summary>
	[System.Runtime.InteropServices.ComVisible(false)]
	public sealed class TrainingCourseDataUtils {

		#region "Shared ""get"" Functions "

		public static List<TrainingCourse> findList(string @where, params object[] @params) {

			TrainingCourseDBMapper dbm = new TrainingCourseDBMapper();
			return dbm.findList(@where, @params);

		}

		public static List<TrainingCourse> findList(string @where, List<IDataParameter> listOfIParams) {

			TrainingCourseDBMapper dbm = new TrainingCourseDBMapper();
			return dbm.findList(@where,listOfIParams);

		}

		public static TrainingCourse findOne(string @where, params object[] @params) {

			TrainingCourseDBMapper dbm = new TrainingCourseDBMapper();
			return (TrainingCourse)dbm.findWhere(@where, @params);

		}

		public static List<TrainingCourse> findList(){

			return new TrainingCourseDBMapper().findAll();

		}

		public static TrainingCourse findByKey(object id) {

			return (TrainingCourse)new TrainingCourseDBMapper().findByKey(id);

		}

		/// <summary>
		/// Reload the TrainingCourse from the database
		/// </summary>
		/// <remarks>
		/// use this method when you want to relad the TrainingCourse 
		/// from the database, discarding any changes
		/// </remarks>
		public static void reload(ref TrainingCourse mo) {

			if (mo == null) {
				throw new System.ArgumentNullException("null object past to reload function");
			}

			mo = (TrainingCourse)new TrainingCourseDBMapper().findByKey(mo.Id);

		}

		#endregion

		#region "Shared Save and Delete Functions"
		/// <summary>
		/// Convinience method to save a TrainingCourse Object.
		/// Important note: DO NOT CALL THIS IN A LOOP!
		/// </summary>
		/// <param name="TrainingCourseObj"></param>
		/// <remarks>
		/// Important note: DO NOT CALL THIS IN A LOOP!  
		/// This method simply instantiates a TrainingCourseDBMapper and calls the save method
		/// </remarks>
		public static void saveTrainingCourse(params TrainingCourse[] TrainingCourseObj)
		{

			TrainingCourseDBMapper dbm = new TrainingCourseDBMapper();
			dbm.saveList(TrainingCourseObj.ToList());


		}


		public static void deleteTrainingCourse(TrainingCourse TrainingCourseObj)
		{

			TrainingCourseDBMapper dbm = new TrainingCourseDBMapper();
			dbm.delete(TrainingCourseObj);

		}
		#endregion

		#region "Data Table and data row load/save "

		public static void saveTrainingCourse(DataRow dr, ref TrainingCourse mo) {
			if (mo == null) {
				mo = new TrainingCourse();
			}

			foreach (DataColumn dc in dr.Table.Columns) {
				mo.setAttribute(dc.ColumnName, dr[dc.ColumnName]);
			}

			saveTrainingCourse(mo);

		}

		public static void saveTrainingCourse(DataTable dt, ref TrainingCourse mo) {
			foreach (DataRow dr in dt.Rows) {
				saveTrainingCourse(dr, ref mo);
			}

		}

		public static TrainingCourse loadFromDataRow(DataRow r) {

			DataRowLoader a = new DataRowLoader();
			IModelObject mo = new TrainingCourse();
			a.DataSource = r;
			a.load(mo);
			return (TrainingCourse)mo;

		}

		#endregion

	}

}


