﻿
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using org.model.lib.Model;
using System.Data.Linq;
using System.Linq;
using org.model.lib.db;
using Newtonsoft.Json;
using CsModelObjects;

///<comments>
/// Template: TestTemplate.csharp.txt
///************************************************************
/// Class autogenerated on 23-Jul-15 12:28:47 PM by ModelGenerator
/// DO NOT MODIFY CODE IN THIS CLASS!!
///************************************************************
///</comments>
[TestClass()] public class EmployeeProjectTestBase {

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


    [TestMethod()] public void TestLoadAndSaveEmployeeProject() {
		
		ModelContext.beginTrans();
		try {
			
			CsModelMappers.EmployeeProjectDBMapper pdb = new CsModelMappers.EmployeeProjectDBMapper();
			
		    long count = pdb.RecordCount();
			
			if (pdb.SelectFromObjectName != pdb.ManagedTableName) {
				long countFromSelectObject = pdb.dbConn.getLngValue("select count(*) from " + pdb.SelectFromObjectName);
				Assert.AreEqual(count, countFromSelectObject, 
					"Count of records in managedTableName {0} and SelectFromObjectName {1} should be equal, as there needs to be exactly 1 to 1 match between records in managed table and selectFromObject.", 
					pdb.ManagedTableName, pdb.SelectFromObjectName);
			}

			if (count == 0) {
				Assert.Inconclusive("No EmployeeProject in database, table is empty");
			} else {
				/**
				using (DataContext ctx = DBUtils.Current().dbContext()) {

					var query = ctx.ExecuteQuery<EmployeeProject>(@"SELECT * FROM " + pdb.SelectFromObjectName ).Skip(1).Take(1);
					var lst = query.ToList();

					Assert.AreEqual(lst.Count, 1, "Expected to receive 1 record, got: " + lst.Count);
					
				}
				todo: fix boolean fields by generating properties of original fields
				**/
				object pid  = ModelContext.CurrentDBUtils.getObjectValue("select top 1 " + pdb.pkFieldName + " from " + pdb.ManagedTableName);
				
				EmployeeProject p = pdb.findByKey(pid);
				EmployeeProject p2 = (EmployeeProject)p.copy();

				//Test equality and hash codes
				Assert.AreEqual(p.GetHashCode(), p2.GetHashCode());
				Assert.AreEqual(p, p2);
						
				p.isDirty = true ; // force save
				pdb.save(p);
			
				// now reload object from database
				p = null;
				p = pdb.findByKey(pid);
            
				//test fields to be equal before and after save
				Assert.IsTrue(p.PrEmployeeProjectId==p2.PrEmployeeProjectId,"Expected Field EmployeeProjectId to be equal");
				Assert.IsTrue(p.PrEPEmployeeId.GetValueOrDefault() ==p2.PrEPEmployeeId.GetValueOrDefault(),"Expected Field EPEmployeeId to be equal");
				Assert.IsTrue(p.PrEPProjectId.GetValueOrDefault() ==p2.PrEPProjectId.GetValueOrDefault(),"Expected Field EPProjectId to be equal");
				Assert.IsTrue(p.PrAssignDate.GetValueOrDefault() ==p2.PrAssignDate.GetValueOrDefault(),"Expected Field AssignDate to be equal");
				Assert.IsTrue(p.PrEndDate.GetValueOrDefault() ==p2.PrEndDate.GetValueOrDefault(),"Expected Field EndDate to be equal");
				Assert.IsTrue(p.PrRate.GetValueOrDefault() ==p2.PrRate.GetValueOrDefault(),"Expected Field Rate to be equal");

	

				p.isDirty = true; //to force save
				ModelContext.Current.saveModelObject(p);

				p = ModelContext.Current.loadModelObject< EmployeeProject >(p.Id);
				p.loadObjectHierarchy();

				string json = JsonConvert.SerializeObject(p,Formatting.Indented,
					new JsonSerializerSettings(){ 
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
				System.IO.FileInfo jf = new System.IO.FileInfo(".\\EmployeeProject.json");
				System.IO.File.WriteAllText(jf.FullName,json);

				if (pdb.isPrimaryKeyAutogenerated) {
					p.isNew = true;
					p.isDirty = true;
					
					try {
						pdb.save(p);
					} catch (System.Exception e) {
						Assert.IsTrue(e.Message.ToUpper().Contains("UNIQUE INDEX")||e.Message.Contains("Violation of UNIQUE KEY constraint"),
							"Insert statement produced error other than violation of unique key:"+e.Message); 

					}
				}

			}

		} finally {
            ModelContext.rollbackTrans(); // 'Nothing should be saved to the database!
        }

   }

}

