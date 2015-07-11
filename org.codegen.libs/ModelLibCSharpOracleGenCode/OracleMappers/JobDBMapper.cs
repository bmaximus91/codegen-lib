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
// Class autogenerated on11-Jul-15 10:06:31 AM by ModelGenerator
// Extends base DBMapperBase object class
// *** DO NOT change code in this class.  
//     It will be re-generated and 
//     overwritten by the code generator ****
// Instead, change code in the extender class JobDBMapper
//
//************************************************************
//</comments>

namespace OracleMappers {

	[System.Runtime.InteropServices.ComVisible(false)]
[AttrIsPrimaryKeyAutogenerated(false)]
	[Table(Name = "JOBS")]
	[SelectObject("JOBS")][KeyFieldName("JOB_ID")]
	public class JobDBMapper : OracleDBMapper {

		#region "Constructors "
		public JobDBMapper(DBUtils _dbConn) : base(_dbConn) {
		}


		public JobDBMapper() : base() {
		}
		#endregion

		#region "Overloaded Functions"

		public new Job findWhere(string sWhereClause, params object[] @params) {

			return (Job)base.findWhere(sWhereClause, @params);
		}


		public void saveJob(Job mo) {
			base.save(mo);
		}

		public new Job findByKey(object keyval) {

			return (Job)base.findByKey(keyval);

		}

		#endregion


		#region "getUpdateDBCommand"
		public override IDbCommand getUpdateDBCommand(IModelObject modelObj, string sql) {
			Job obj = (Job)modelObj;
			IDbCommand stmt = this.dbConn.getCommand(sql);
			stmt.Parameters.Add(this.dbConn.getParameter(Job.STR_FLD_JOB_TITLE,obj.PrJobTitle));
			stmt.Parameters.Add(this.dbConn.getParameter(Job.STR_FLD_MIN_SALARY,obj.PrMinSalary));
			stmt.Parameters.Add(this.dbConn.getParameter(Job.STR_FLD_MAX_SALARY,obj.PrMaxSalary));
			stmt.Parameters.Add(this.dbConn.getParameter(Job.STR_FLD_CREATE_DATE,obj.CreateDate));
			stmt.Parameters.Add(this.dbConn.getParameter(Job.STR_FLD_UPDATE_DATE,obj.UpdateDate));
			stmt.Parameters.Add(this.dbConn.getParameter(Job.STR_FLD_CREATE_USER,obj.CreateUser));
			stmt.Parameters.Add(this.dbConn.getParameter(Job.STR_FLD_UPDATE_USER,obj.UpdateUser));

			stmt.Parameters.Add(this.dbConn.getParameter(Job.STR_FLD_JOB_ID,obj.PrJobId));


			return stmt;
		}
		#endregion



		#region "Find functions"

		///	<summary>Given an sql statement, it opens a result set, and for each record returned, 
		///	it creates and loads a ModelObject. </summary>
		///	<param name="sWhereClause">where clause to be applied to "selectall" statement 
		/// that returns one or more records from the database, corresponding to the ModelObject we are going to load </param>
		///	 <param name="params"> Parameter values to be passed to sql statement </param>
		///	 <returns> A List(Of Job) object containing all objects loaded </returns>
		///	 
		public new List<Job> findList(string sWhereClause, params object[] @params) {

			string sql = this.getSqlWithWhereClause(sWhereClause);
			IDataReader rs = null;
			List<Job> molist = new List<Job>();

			try {
				rs = dbConn.getDataReaderWithParams(sql, @params);
				this.Loader.DataSource = rs;

				while (rs.Read()) {
					IModelObject mo = this.getModelInstance();
					this.Loader.load(mo);
					molist.Add((Job)mo);

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
		///	 <param name="params"> List of IDataParameters to be passed to sql statement </param>
		///	 <returns> A List(Of Job) object containing all objects loaded </returns>
		///	 
		public new List<Job> findList(string sWhereClause, List<IDataParameter> @params) {

			string sql = this.getSqlWithWhereClause(sWhereClause);
			IDataReader rs = null;
			List<Job> molist = new List<Job>();

			try {
				rs = dbConn.getDataReader(sql, @params);
				this.Loader.DataSource = rs;

				while (rs.Read()) {
					IModelObject mo = this.getModelInstance();
					this.Loader.load(mo);
					molist.Add((Job)mo);

				}


			} finally {
				this.dbConn.closeDataReader(rs);
			}

			return molist;

		}


		///    
		///	 <summary>Returns all records from database for a coresponding ModelObject </summary>
		/// <returns>List(Of Job) </returns>
		public List<Job> findAll()
		{
			return this.findList(string.Empty);
		}

		public override IModelObjectLoader Loader {
			get {
				if (this._loader == null) {
					this._loader = new JobDataReaderLoader();
				}
				return this._loader;
			}
			set { this._loader = value; }
		}

		#endregion

		public override IModelObject getModelInstance() {
			return new Job();
		}

	}

	#region " Job Loader "
	[System.Runtime.InteropServices.ComVisible(false)]
	public class JobDataReaderLoader : DataReaderLoader {
		public override void load(IModelObject mo) {
			const int DATAREADER_FLD_JOB_ID = 0;
			const int DATAREADER_FLD_JOB_TITLE = 1;
			const int DATAREADER_FLD_MIN_SALARY = 2;
			const int DATAREADER_FLD_MAX_SALARY = 3;
			const int DATAREADER_FLD_CREATE_DATE = 4;
			const int DATAREADER_FLD_UPDATE_DATE = 5;
			const int DATAREADER_FLD_CREATE_USER = 6;
			const int DATAREADER_FLD_UPDATE_USER = 7;

			Job obj = (Job)mo;
			obj.IsObjectLoading = true;

			if (!this.reader.IsDBNull(DATAREADER_FLD_JOB_ID) ) {
				obj.PrJobId = this.reader.GetString(DATAREADER_FLD_JOB_ID);
			}
			if (!this.reader.IsDBNull(DATAREADER_FLD_JOB_TITLE) ) {
				obj.PrJobTitle = this.reader.GetString(DATAREADER_FLD_JOB_TITLE);
			}
			if (!this.reader.IsDBNull(DATAREADER_FLD_MIN_SALARY) ) {
				obj.PrMinSalary = Convert.ToInt64(this.reader.GetDecimal(DATAREADER_FLD_MIN_SALARY));
			}
			if (!this.reader.IsDBNull(DATAREADER_FLD_MAX_SALARY) ) {
				obj.PrMaxSalary = Convert.ToInt64(this.reader.GetDecimal(DATAREADER_FLD_MAX_SALARY));
			}
			if (!this.reader.IsDBNull(DATAREADER_FLD_CREATE_DATE) ) {
				obj.CreateDate = this.reader.GetDateTime(DATAREADER_FLD_CREATE_DATE);
			}
			if (!this.reader.IsDBNull(DATAREADER_FLD_UPDATE_DATE) ) {
				obj.UpdateDate = this.reader.GetDateTime(DATAREADER_FLD_UPDATE_DATE);
			}
			if (!this.reader.IsDBNull(DATAREADER_FLD_CREATE_USER) ) {
				obj.CreateUser = this.reader.GetString(DATAREADER_FLD_CREATE_USER);
			}
			if (!this.reader.IsDBNull(DATAREADER_FLD_UPDATE_USER) ) {
				obj.UpdateUser = this.reader.GetString(DATAREADER_FLD_UPDATE_USER);
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
	/// Final Class with convinience shared methods for loading/saving the JobRank ModelObject. 
	///</summary>
	[System.Runtime.InteropServices.ComVisible(false)]
	public sealed class JobDataUtils {

		#region "Shared ""get"" Functions "

		public static List<Job> findList(string @where, params object[] @params) {

			JobDBMapper dbm = new JobDBMapper();
			return dbm.findList(@where, @params);

		}

		public static List<Job> findList(string @where, List<IDataParameter> listOfIParams) {

			JobDBMapper dbm = new JobDBMapper();
			return dbm.findList(@where,listOfIParams);

		}

		public static Job findOne(string @where, params object[] @params) {

			JobDBMapper dbm = new JobDBMapper();
			return (Job)dbm.findWhere(@where, @params);

		}

		public static List<Job> findList(){

			return new JobDBMapper().findAll();

		}

		public static Job findByKey(object id) {

			return (Job)new JobDBMapper().findByKey(id);

		}

		/// <summary>
		/// Reload the Job from the database
		/// </summary>
		/// <remarks>
		/// use this method when you want to relad the Job 
		/// from the database, discarding any changes
		/// </remarks>
		public static void reload(ref Job mo) {

			if (mo == null) {
				throw new System.ArgumentNullException("null object past to reload function");
			}

			mo = (Job)new JobDBMapper().findByKey(mo.Id);

		}

		#endregion

		#region "Shared Save and Delete Functions"
		/// <summary>
		/// Convinience method to save a Job Object.
		/// Important note: DO NOT CALL THIS IN A LOOP!
		/// </summary>
		/// <param name="JobObj"></param>
		/// <remarks>
		/// Important note: DO NOT CALL THIS IN A LOOP!  
		/// This method simply instantiates a JobDBMapper and calls the save method
		/// </remarks>
		public static void saveJob(params Job[] JobObj)
		{

			JobDBMapper dbm = new JobDBMapper();
			dbm.saveList(JobObj.ToList());


		}


		public static void deleteJob(Job JobObj)
		{

			JobDBMapper dbm = new JobDBMapper();
			dbm.delete(JobObj);

		}
		#endregion

		#region "Data Table and data row load/save "

		public static void saveJob(DataRow dr, ref Job mo) {
			if (mo == null) {
				mo = new Job();
			}

			foreach (DataColumn dc in dr.Table.Columns) {
				mo.setAttribute(dc.ColumnName, dr[dc.ColumnName]);
			}

			saveJob(mo);

		}

		public static void saveJob(DataTable dt, ref Job mo) {
			foreach (DataRow dr in dt.Rows) {
				saveJob(dr, ref mo);
			}

		}

		public static Job loadFromDataRow(DataRow r) {

			DataRowLoader a = new DataRowLoader();
			IModelObject mo = new Job();
			a.DataSource = r;
			a.load(mo);
			return (Job)mo;

		}

		#endregion

	}

}


