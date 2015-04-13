﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using org.model.lib;
using org.model.lib.Model;
using org.model.lib.db;

using System.Linq;
using CsModelObjects;

//<comments>
// Template: DBMapperBase.csharp.txt
//************************************************************
// 
// Class autogenerated on13-04-2015 19:28:32 by ModelGenerator
// Extends base DBMapperBase object class
// *** DO NOT change code in this class.  
//     It will be re-generated and 
//     overwritten by the code generator ****
// Instead, change code in the extender class EmployeeInfoDBMapper
//
//************************************************************
//</comments>

namespace CsModelMappers {

	[System.Runtime.InteropServices.ComVisible(false)]
	public class EmployeeInfoDBMapper : DBMapper {

		#region "Constructors "
		public EmployeeInfoDBMapper(DBUtils _dbConn) : base(_dbConn) {
		}


		public EmployeeInfoDBMapper() : base() {
		}
		#endregion

		#region "Overloaded Functions"

		public new EmployeeInfo findWhere(string sWhereClause, params object[] @params) {

			return (EmployeeInfo)base.findWhere(sWhereClause, @params);
		}


		public void saveEmployeeInfo(EmployeeInfo mo) {
			base.save(mo);
		}

		public new EmployeeInfo findByKey(object keyval) {

			return (EmployeeInfo)base.findByKey(keyval);

		}

		#endregion


		#region "getUpdateDBCommand"
		public override IDbCommand getUpdateDBCommand(IModelObject modelObj, string sql) {
			IEmployeeInfo obj = (IEmployeeInfo)modelObj;
			IDbCommand stmt = this.dbConn.getCommand(sql);
			stmt.Parameters.Add( this.dbConn.getParameter("@EIEmployeeId",obj.EIEmployeeId));
			stmt.Parameters.Add( this.dbConn.getParameter("@Salary",obj.Salary));
			stmt.Parameters.Add( this.dbConn.getParameter("@Address",obj.Address));

			if ( obj.isNew ) {
			} else {
			//only add primary key if we are updating and as the last parameter
							stmt.Parameters.Add( this.dbConn.getParameter("@EmployeeInfoId",obj.EmployeeInfoId));
		}

			return stmt;
		}

		#endregion


		#region "Find functions"

		///	<summary>Given an sql statement, it opens a result set, and for each record returned, 
		///	it creates and loads a ModelObject. </summary>
		///	<param name="sWhereClause">where clause to be applied to "selectall" statement 
		/// that returns one or more records from the database, corresponding to the ModelObject we are going to load </param>
		///	 <param name="params"> Parameter values to be passed to sql statement </param>
		///	 <returns> A List(Of EmployeeInfo) object containing all objects loaded </returns>
		///	 
		public new List<EmployeeInfo> findList(string sWhereClause, params object[] @params) {

			string sql = this.getSqlWithWhereClause(sWhereClause);
			IDataReader rs = null;
			List<EmployeeInfo> molist = new List<EmployeeInfo>();

			try {
				rs = dbConn.getDataReaderWithParams(sql, @params);
				this.Loader.DataSource = rs;

				while (rs.Read()) {
					IModelObject mo = this.getModelInstance();
					this.Loader.load(mo);
					molist.Add((EmployeeInfo)mo);

				}


			} finally {
				this.dbConn.closeDataReader(rs);
			}

			return molist;

		}

		///    
		///	 <summary>Returns all records from database for a coresponding ModelObject </summary>
		/// <returns>List(Of EmployeeInfo) </returns>
		public List<EmployeeInfo> findAll()
		{
			return this.findList(string.Empty);
		}

		public override IModelObjectLoader Loader {
			get {
				if (this._loader == null) {
					this._loader = new EmployeeInfoDataReaderLoader();
				}
				return this._loader;
			}
			set { this._loader = value; }
		}

		#endregion

		public override IModelObject getModelInstance()
		{
			return EmployeeInfoFactory.Create();
		}

	}

	#region " EmployeeInfo Loader "
	[System.Runtime.InteropServices.ComVisible(false)]
	public class EmployeeInfoDataReaderLoader : DataReaderLoader {
		public override void load(IModelObject mo) {
			const int DATAREADER_FLD_EMPLOYEEINFOID = 0;
			const int DATAREADER_FLD_EIEMPLOYEEID = 1;
			const int DATAREADER_FLD_SALARY = 2;
			const int DATAREADER_FLD_ADDRESS = 3;

			EmployeeInfo obj = (EmployeeInfo)mo;
			obj.IsObjectLoading = true;

			if (!this.reader.IsDBNull(DATAREADER_FLD_EMPLOYEEINFOID) ) {
				obj.EmployeeInfoId = this.reader.GetInt32(DATAREADER_FLD_EMPLOYEEINFOID);
			}
			if (!this.reader.IsDBNull(DATAREADER_FLD_EIEMPLOYEEID) ) {
				obj.EIEmployeeId = this.reader.GetInt32(DATAREADER_FLD_EIEMPLOYEEID);
			}
			if (!this.reader.IsDBNull(DATAREADER_FLD_SALARY) ) {
				obj.Salary = this.reader.GetDecimal(DATAREADER_FLD_SALARY);
			}
			if (!this.reader.IsDBNull(DATAREADER_FLD_ADDRESS) ) {
				obj.Address = this.reader.GetString(DATAREADER_FLD_ADDRESS);
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
	/// Final Class with convinience shared methods for loading/saving the EmployeeInfoRank ModelObject. 
	///</summary>
	[System.Runtime.InteropServices.ComVisible(false)]
	public sealed class EmployeeInfoDataUtils {

		#region "Shared ""get"" Functions "

		public static List<EmployeeInfo> findList(string @where, params object[] @params){

			EmployeeInfoDBMapper dbm = new EmployeeInfoDBMapper();
			return dbm.findList(@where, @params);

		}

		public static EmployeeInfo findOne(string @where, params object[] @params) {

			EmployeeInfoDBMapper dbm = new EmployeeInfoDBMapper();
			return (EmployeeInfo)dbm.findWhere(@where, @params);

		}

		public static List<EmployeeInfo> findList(){

			return new EmployeeInfoDBMapper().findAll();

		}

		public static EmployeeInfo findByKey(object id) {

			return (EmployeeInfo)new EmployeeInfoDBMapper().findByKey(id);

		}

		/// <summary>
		/// Reload the EmployeeInfo from the database
		/// </summary>
		/// <remarks>
		/// use this method when you want to relad the EmployeeInfo 
		/// from the database, discarding any changes
		/// </remarks>
		public static void reload(ref EmployeeInfo mo) {

			if (mo == null) {
				throw new System.ArgumentNullException("null object past to reload function");
			}

			mo = (EmployeeInfo)new EmployeeInfoDBMapper().findByKey(mo.Id);

		}

		#endregion

		#region "Shared Save and Delete Functions"
		/// <summary>
		/// Convinience method to save a EmployeeInfo Object.
		/// Important note: DO NOT CALL THIS IN A LOOP!
		/// </summary>
		/// <param name="EmployeeInfoObj"></param>
		/// <remarks>
		/// Important note: DO NOT CALL THIS IN A LOOP!  
		/// This method simply instantiates a EmployeeInfoDBMapper and calls the save method
		/// </remarks>
		public static void saveEmployeeInfo(params EmployeeInfo[] EmployeeInfoObj)
		{

			EmployeeInfoDBMapper dbm = new EmployeeInfoDBMapper();
			dbm.saveList(EmployeeInfoObj.ToList());


		}


		public static void deleteEmployeeInfo(EmployeeInfo EmployeeInfoObj)
		{

			EmployeeInfoDBMapper dbm = new EmployeeInfoDBMapper();
			dbm.delete(EmployeeInfoObj);

		}
		#endregion

		#region "Data Table and data row load/save "

		public static void saveEmployeeInfo(DataRow dr, ref EmployeeInfo mo) {
			if (mo == null) {
				mo = EmployeeInfoFactory.Create();
			}

			foreach (DataColumn dc in dr.Table.Columns) {
				mo.setAttribute(dc.ColumnName, dr[dc.ColumnName]);
			}

			saveEmployeeInfo(mo);

		}

		public static void saveEmployeeInfo(DataTable dt, ref EmployeeInfo mo) {
			foreach (DataRow dr in dt.Rows) {
				saveEmployeeInfo(dr, ref mo);
			}

		}

		public static EmployeeInfo loadFromDataRow(DataRow r) {

			DataRowLoader a = new DataRowLoader();
			IModelObject mo = EmployeeInfoFactory.Create();
			a.DataSource = r;
			a.load(mo);
			return (EmployeeInfo)mo;

		}

		#endregion

	}

}


