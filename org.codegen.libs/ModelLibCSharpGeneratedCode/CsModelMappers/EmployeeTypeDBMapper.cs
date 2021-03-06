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
using System.Data.Linq.Mapping;

//<comments>
// Template: DBMapperBase.csharp.txt
//************************************************************
// 
// Class autogenerated on11/07/2015 11:47:56 AM by ModelGenerator
// Extends base DBMapperBase object class
// *** DO NOT change code in this class.  
//     It will be re-generated and 
//     overwritten by the code generator ****
// Instead, change code in the extender class EmployeeTypeDBMapper
//
//************************************************************
//</comments>

namespace CsModelMappers {

	[System.Runtime.InteropServices.ComVisible(false)]
[AttrIsPrimaryKeyAutogenerated(false)]
	[Table(Name = "EmployeeType")]
	[SelectObject("EmployeeType")][KeyFieldName("EmployeeTypeCode")]
	public class EmployeeTypeDBMapper : DBMapper {

		#region "Constructors "
		public EmployeeTypeDBMapper(DBUtils _dbConn) : base(_dbConn) {
		}


		public EmployeeTypeDBMapper() : base() {
		}
		#endregion

		#region "Overloaded Functions"

		public new EmployeeType findWhere(string sWhereClause, params object[] @params) {

			return (EmployeeType)base.findWhere(sWhereClause, @params);
		}


		public void saveEmployeeType(EmployeeType mo) {
			base.save(mo);
		}

		public new EmployeeType findByKey(object keyval) {

			return (EmployeeType)base.findByKey(keyval);

		}

		#endregion


		#region "getUpdateDBCommand"
		public override IDbCommand getUpdateDBCommand(IModelObject modelObj, string sql) {
			EmployeeType obj = (EmployeeType)modelObj;
			IDbCommand stmt = this.dbConn.getCommand(sql);
			stmt.Parameters.Add(this.dbConn.getParameter(EmployeeType.STR_FLD_EMPLOYEETYPE,obj.PrEmployeeType));

			stmt.Parameters.Add(this.dbConn.getParameter(EmployeeType.STR_FLD_EMPLOYEETYPECODE,obj.PrEmployeeTypeCode));


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
		///	<returns> A List(Of EmployeeType) object containing all objects loaded </returns>
		///	 
		public new List<EmployeeType> findList(string sWhereClause, params object[] @params) {

			string sql = this.getSqlWithWhereClause(sWhereClause);
			IDataReader rs = null;
			List<EmployeeType> molist = new List<EmployeeType>();

			try {
				rs = dbConn.getDataReaderWithParams(sql, @params);
				this.Loader.DataSource = rs;

				while (rs.Read()) {
					IModelObject mo = this.getModelInstance();
					this.Loader.load(mo);
					molist.Add((EmployeeType)mo);

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
		///	<returns> A List(Of EmployeeType) object containing all objects loaded </returns>
		///	 
		public List<EmployeeType> findList(string sWhereClause, List<IDataParameter> @params) {

			string sql = this.getSqlWithWhereClause(sWhereClause);
			IDataReader rs = null;
			List<EmployeeType> molist = new List<EmployeeType>();

			try {
				rs = dbConn.getDataReader(sql, @params);
				this.Loader.DataSource = rs;

				while (rs.Read()) {
					IModelObject mo = this.getModelInstance();
					this.Loader.load(mo);
					molist.Add((EmployeeType)mo);

				}


			} finally {
				this.dbConn.closeDataReader(rs);
			}

			return molist;

		}


		///    
		///	 <summary>Returns all records from database for a coresponding ModelObject </summary>
		/// <returns>List(Of EmployeeType) </returns>
		public List<EmployeeType> findAll()
		{
			return this.findList(string.Empty);
		}

		public override IModelObjectLoader Loader {
			get {
				if (this._loader == null) {
					this._loader = new EmployeeTypeDataReaderLoader();
				}
				return this._loader;
			}
			set { this._loader = value; }
		}

		#endregion

		public override IModelObject getModelInstance() {
			return new EmployeeType();
		}

	}

	#region " EmployeeType Loader "
	[System.Runtime.InteropServices.ComVisible(false)]
	public class EmployeeTypeDataReaderLoader : DataReaderLoader {
		public override void load(IModelObject mo) {
			const int DATAREADER_FLD_EMPLOYEETYPECODE = 0;
			const int DATAREADER_FLD_EMPLOYEETYPE = 1;

			EmployeeType obj = (EmployeeType)mo;
			obj.IsObjectLoading = true;

			if (!this.reader.IsDBNull(DATAREADER_FLD_EMPLOYEETYPECODE) ) {
				obj.PrEmployeeTypeCode = this.reader.GetString(DATAREADER_FLD_EMPLOYEETYPECODE);
			}
			if (!this.reader.IsDBNull(DATAREADER_FLD_EMPLOYEETYPE) ) {
				obj.PrEmployeeType = this.reader.GetString(DATAREADER_FLD_EMPLOYEETYPE);
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
	/// Final Class with convinience shared methods for loading/saving the EmployeeTypeRank ModelObject. 
	///</summary>
	[System.Runtime.InteropServices.ComVisible(false)]
	public sealed class EmployeeTypeDataUtils {

		#region "Shared ""get"" Functions "

		public static List<EmployeeType> findList(string @where, params object[] @params) {

			EmployeeTypeDBMapper dbm = new EmployeeTypeDBMapper();
			return dbm.findList(@where, @params);

		}

		public static List<EmployeeType> findList(string @where, List<IDataParameter> listOfIParams) {

			EmployeeTypeDBMapper dbm = new EmployeeTypeDBMapper();
			return dbm.findList(@where,listOfIParams);

		}

		public static EmployeeType findOne(string @where, params object[] @params) {

			EmployeeTypeDBMapper dbm = new EmployeeTypeDBMapper();
			return (EmployeeType)dbm.findWhere(@where, @params);

		}

		public static List<EmployeeType> findList(){

			return new EmployeeTypeDBMapper().findAll();

		}

		public static EmployeeType findByKey(object id) {

			return (EmployeeType)new EmployeeTypeDBMapper().findByKey(id);

		}

		/// <summary>
		/// Reload the EmployeeType from the database
		/// </summary>
		/// <remarks>
		/// use this method when you want to relad the EmployeeType 
		/// from the database, discarding any changes
		/// </remarks>
		public static void reload(ref EmployeeType mo) {

			if (mo == null) {
				throw new System.ArgumentNullException("null object past to reload function");
			}

			mo = (EmployeeType)new EmployeeTypeDBMapper().findByKey(mo.Id);

		}

		#endregion

		#region "Shared Save and Delete Functions"
		/// <summary>
		/// Convinience method to save a EmployeeType Object.
		/// Important note: DO NOT CALL THIS IN A LOOP!
		/// </summary>
		/// <param name="EmployeeTypeObj"></param>
		/// <remarks>
		/// Important note: DO NOT CALL THIS IN A LOOP!  
		/// This method simply instantiates a EmployeeTypeDBMapper and calls the save method
		/// </remarks>
		public static void saveEmployeeType(params EmployeeType[] EmployeeTypeObj)
		{

			EmployeeTypeDBMapper dbm = new EmployeeTypeDBMapper();
			dbm.saveList(EmployeeTypeObj.ToList());


		}


		public static void deleteEmployeeType(EmployeeType EmployeeTypeObj)
		{

			EmployeeTypeDBMapper dbm = new EmployeeTypeDBMapper();
			dbm.delete(EmployeeTypeObj);

		}
		#endregion

		#region "Data Table and data row load/save "

		public static void saveEmployeeType(DataRow dr, ref EmployeeType mo) {
			if (mo == null) {
				mo = new EmployeeType();
			}

			foreach (DataColumn dc in dr.Table.Columns) {
				mo.setAttribute(dc.ColumnName, dr[dc.ColumnName]);
			}

			saveEmployeeType(mo);

		}

		public static void saveEmployeeType(DataTable dt, ref EmployeeType mo) {
			foreach (DataRow dr in dt.Rows) {
				saveEmployeeType(dr, ref mo);
			}

		}

		public static EmployeeType loadFromDataRow(DataRow r) {

			DataRowLoader a = new DataRowLoader();
			IModelObject mo = new EmployeeType();
			a.DataSource = r;
			a.load(mo);
			return (EmployeeType)mo;

		}

		#endregion

	}

}


