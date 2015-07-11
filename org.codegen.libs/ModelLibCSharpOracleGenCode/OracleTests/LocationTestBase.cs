﻿
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using org.model.lib.Model;
using System.Data.Linq;
using System.Linq;
using org.model.lib.db;
using Newtonsoft.Json;
using OracleModel;

///<comments>
/// Template: TestTemplate.csharp.txt
///************************************************************
/// Class autogenerated on 11-Jul-15 4:07:09 PM by ModelGenerator
/// DO NOT MODIFY CODE IN THIS CLASS!!
///************************************************************
///</comments>
[TestClass()] public class LocationTestBase {

    ///<summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext {get;set;}
    

#region "Additional test attributes"
    ///
    /// You can use the following additional attributes as you write your tests:
    ///
    /// Use ClassInitialize to run code before running the first test in the class
    [ClassInitialize()] public static void MyClassInitialize(TestContext testContext ) {
        ModelContext.newForUnitTests();
    }
    
    /// Use ClassCleanup to run code after all tests in a class have run
    [ClassCleanup()] public static void MyClassCleanup() {
        ModelContext.release();
    }


    //Use TestInitialize to run code before running each test
    [TestInitialize()]
    public void MyTestInitialize() {
    }
    
    // Use TestCleanup to run code after each test has run
    [TestCleanup()] public void MyTestCleanup() {
    
	}
    
#endregion


    [TestMethod()] public void TestLoadAndSaveLocation() {
		
		ModelContext.beginTrans();
		try {
			
			OracleMappers.LocationDBMapper pdb = new OracleMappers.LocationDBMapper();
			
		    long count = pdb.RecordCount();
			
			if (pdb.SelectFromObjectName != pdb.ManagedTableName) {
				long countFromSelectObject = pdb.dbConn.getLngValue("select count(*) from " + pdb.SelectFromObjectName);
				Assert.AreEqual(count, countFromSelectObject, 
					"Count of records in managedTableName {0} and SelectFromObjectName {1} should be equal, as there needs to be exactly 1 to 1 match between records in managed table and selectFromObject.", 
					pdb.ManagedTableName, pdb.SelectFromObjectName);
			}

			if (count == 0) {
				Assert.Inconclusive("No Location in database, table is empty");
			} else {
				/**
				using (DataContext ctx = DBUtils.Current().dbContext()) {

					var query = ctx.ExecuteQuery<Location>(@"SELECT * FROM " + pdb.SelectFromObjectName ).Skip(1).Take(1);
					var lst = query.ToList();

					Assert.AreEqual(lst.Count, 1, "Expected to receive 1 record, got: " + lst.Count);
					
				}
				todo: fix boolean fields by generating properties of original fields
				**/
				object pid  = ModelContext.CurrentDBUtils.getObjectValue("select top 1 LOCATION_ID from LOCATIONS");
				
				Location p = pdb.findByKey(pid);
				Location p2 = (Location)p.copy();

				//Test equality and hash codes
				Assert.AreEqual(p.GetHashCode(), p2.GetHashCode());
				Assert.AreEqual(p, p2);
						
				p.isDirty = true ; // force save
				pdb.save(p);
			
				// now reload object from database
				p = null;
				p = pdb.findByKey(pid);
            
				//test fields to be equal before and after save
						Assert.IsTrue(p.PrLocationId == p2.PrLocationId,"Expected Field LocationId to be equal");
		Assert.IsTrue(p.PrStreetAddress == p2.PrStreetAddress,"Expected Field StreetAddress to be equal");
		Assert.IsTrue(p.PrPostalCode == p2.PrPostalCode,"Expected Field PostalCode to be equal");
		Assert.IsTrue(p.PrCITY == p2.PrCITY,"Expected Field CITY to be equal");
		Assert.IsTrue(p.PrStateProvince == p2.PrStateProvince,"Expected Field StateProvince to be equal");
		Assert.IsTrue(p.PrCountryId == p2.PrCountryId,"Expected Field CountryId to be equal");
		Assert.IsTrue(p.CreateDate.GetValueOrDefault() == p2.CreateDate.GetValueOrDefault(),"Expected Field CreateDate to be equal");
		Assert.IsFalse(p.UpdateDate.GetValueOrDefault() == p2.UpdateDate.GetValueOrDefault(),"Expected Field UpdateDate NOT to be equal");
		Assert.IsTrue(p.CreateUser == p2.CreateUser,"Expected Field CreateUser to be equal");
		// skip update user!

				
				
				p.isDirty = true; //to force save
				ModelContext.Current.saveModelObject(p);

				p = ModelContext.Current.loadModelObject< Location >(p.Id);
				p.loadObjectHierarchy();
				string output = JsonConvert.SerializeObject(p);
				
			}

		} finally {
            ModelContext.rollbackTrans(); // 'Nothing should be saved to the database!
        }

   }

}

