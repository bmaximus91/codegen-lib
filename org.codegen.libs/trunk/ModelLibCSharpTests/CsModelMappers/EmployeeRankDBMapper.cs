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
// Class autogenerated on13-04-2015 07:39:44 by ModelGenerator
// Extends base DBMapperBase object class
// *** DO NOT change code in this class.  
//     It will be re-generated and 
//     overwritten by the code generator ****
// Instead, change code in the extender class EmployeeRankDBMapper
//
//************************************************************
//</comments>

namespace CsModelMappers {

	[System.Runtime.InteropServices.ComVisible(false)]
	public class EmployeeRankDBMapper : DBMapper {

		#region "Constructors "
		public EmployeeRankDBMapper(DBUtils _dbConn) : base(_dbConn) {
		}


		public EmployeeRankDBMapper() : base() {
		}
		#endregion

		#region "Overloaded Functions"

		public new EmployeeRank findWhere(string sWhereClause, params object[] @params) {

			return (EmployeeRank)base.findWhere(sWhereClause, @params);
		}


		public void saveEmployeeRank(EmployeeRank mo) {
			base.save(mo);
		}

		public new EmployeeRank findByKey(int keyval) {

			return (EmployeeRank)base.findByKey(keyval);

		}

		#endregion


		#region "getUpdateDBCommand"
		public override IDbCommand getUpdateDBCommand(IModelObject modelObj, string sql) {
			IEmployeeRank obj = (IEmployeeRank)modelObj;
			IDbCommand stmt = this.dbConn.getCommand(sql);
			stmt.Parameters.Add( this.dbConn.getParameter("@Rank",obj.Rank));

			if (! obj.isNew ) {
			//only add primary key if we are updating and as the last parameter
							stmt.Parameters.Add( this.dbConn.getParameter("@RankId",obj.RankId));
		}

			return stmt;
		}

		#endregion

		#region "SQL Statements in files"

		public override string getSQLStatement(string skey)
		{
			//because the EmployeeRankSql.xml file is stored as an Embedded resource under
			//EmployeeRankDBMapper file (DependentUpon in the project file), 
			//its resource name is the same as the DBMapper file.
			return SQLStmtsRegistry.getStatement(this.GetType().FullName, skey, this.dbConn.sqldialect);

		}


		#endregion





		#region "Find functions"

		///	<summary>Given an sql statement, it opens a result set, and for each record returned, 
		///	it creates and loads a ModelObject. </summary>
		///	<param name="sWhereClause">where clause to be applied to "selectall" statement 
		/// that returns one or more records from the database, corresponding to the ModelObject we are going to load </param>
		///	 <param name="params"> Parameter values to be passed to sql statement </param>
		///	 <returns> A List(Of EmployeeRank) object containing all objects loaded </returns>
		///	 
		public new List<EmployeeRank> findList(string sWhereClause, params object[] @params) {

			string sql = this.getSqlWithWhereClause(sWhereClause);
			IDataReader rs = null;
			List<EmployeeRank> molist = new List<EmployeeRank>();

			try {
				rs = dbConn.getDataReaderWithParams(sql, @params);
				this.Loader.DataSource = rs;

				while (rs.Read()) {
					IModelObject mo = this.getModelInstance();
					this.Loader.load(mo);
					molist.Add((EmployeeRank)mo);

				}


			} finally {
				this.dbConn.closeDataReader(rs);
			}

			return molist;

		}

		///    
		///	 <summary>Returns all records from database for a coresponding ModelObject </summary>
		/// <returns>List(Of EmployeeRank) </returns>
		public List<EmployeeRank> findAll()
		{
			return this.findList(string.Empty);
		}

		public override IModelObjectLoader Loader {
			get {
				if (this._loader == null) {
					this._loader = new EmployeeRankDataReaderLoader();
				}
				return this._loader;
			}
			set { this._loader = value; }
		}

		#endregion

		public override IModelObject getModelInstance()
		{
			return EmployeeRankFactory.Create();
		}

	}

	#region " EmployeeRank Loader "
	[System.Runtime.InteropServices.ComVisible(false)]
	public class EmployeeRankDataReaderLoader : DataReaderLoader {


		public override void load(IModelObject mo) {
			const int DATAREADER_FLD_RANKID = 0;
			const int DATAREADER_FLD_RANK = 1;

			EmployeeRank obj = (EmployeeRank)mo;
			obj.IsObjectLoading = true;

			if (!this.reader.IsDBNull(DATAREADER_FLD_RANKID) ) {
				obj.RankId = this.reader.GetInt32(DATAREADER_FLD_RANKID);
			}
			if (!this.reader.IsDBNull(DATAREADER_FLD_RANK) ) {
				obj.Rank = this.reader.GetString(DATAREADER_FLD_RANK);
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
	/// Final Class with convinience shared methods for loading/saving the EmployeeRankRank ModelObject. 
	///</summary>
	[System.Runtime.InteropServices.ComVisible(false)]
	public sealed class EmployeeRankDataUtils
	{

		#region "Shared ""get"" Functions "

		public static List<EmployeeRank> findList(string @where, params object[] @params)
		{

			EmployeeRankDBMapper dbm = new EmployeeRankDBMapper();
			return dbm.findList(@where, @params);

		}

		public static EmployeeRank findOne(string @where, params object[] @params)
		{

			EmployeeRankDBMapper dbm = new EmployeeRankDBMapper();
			return (EmployeeRank)dbm.findWhere(@where, @params);

		}


		public static List<EmployeeRank> findList()
		{

			return new EmployeeRankDBMapper().findAll();

		}

		public static EmployeeRank findByKey(int id)
		{

			return (EmployeeRank)new EmployeeRankDBMapper().findByKey(id);

		}

		/// <summary>
		/// Reload the EmployeeRank from the database
		/// </summary>
		/// <remarks>
		/// use this method when you want to relad the EmployeeRank 
		/// from the database, discarding any changes
		/// </remarks>
		public static void reload(ref EmployeeRank mo)
		{

			if (mo == null) {
				throw new System.ArgumentNullException("null object past to reload function");
			}

			mo = (EmployeeRank)new EmployeeRankDBMapper().findByKey(mo.Id);

		}

		#endregion

		#region "Shared Save and Delete Functions"
		/// <summary>
		/// Convinience method to save a EmployeeRank Object.
		/// Important note: DO NOT CALL THIS IN A LOOP!
		/// </summary>
		/// <param name="EmployeeRankObj"></param>
		/// <remarks>
		/// Important note: DO NOT CALL THIS IN A LOOP!  
		/// This method simply instantiates a EmployeeRankDBMapper and calls the save method
		/// </remarks>
		public static void saveEmployeeRank(params EmployeeRank[] EmployeeRankObj)
		{

			EmployeeRankDBMapper dbm = new EmployeeRankDBMapper();
			dbm.saveList(EmployeeRankObj.ToList());


		}


		public static void deleteEmployeeRank(EmployeeRank EmployeeRankObj)
		{

			EmployeeRankDBMapper dbm = new EmployeeRankDBMapper();
			dbm.delete(EmployeeRankObj);

		}
		#endregion

		#region "Data Table and data row load/save "

		public static void saveEmployeeRank(DataRow dr, ref EmployeeRank mo) {
			if (mo == null) {
				mo = EmployeeRankFactory.Create();
			}

			foreach (DataColumn dc in dr.Table.Columns) {
				mo.setAttribute(dc.ColumnName, dr[dc.ColumnName]);
			}

			saveEmployeeRank(mo);

		}

		public static void saveEmployeeRank(DataTable dt, ref EmployeeRank mo) {
			foreach (DataRow dr in dt.Rows) {
				saveEmployeeRank(dr, ref mo);
			}

		}

		public static EmployeeRank loadFromDataRow(DataRow r) {

			DataRowLoader a = new DataRowLoader();
			IModelObject mo = EmployeeRankFactory.Create();
			a.DataSource = r;
			a.load(mo);
			return (EmployeeRank)mo;

		}

		#endregion

	}

}


