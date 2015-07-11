﻿
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting


'<comments>
'Template: TestTemplate.visualbasic.txt
'************************************************************
' Class autogenerated on 11-Jul-15 10:48:33 AM by ModelGenerator
' DO NOT MODIFY CODE IN THIS CLASS
'************************************************************
'</comments>
<TestClass()> Public Class ProjectTestBase

    Private testContextInstance As TestContext

    '''<summary>
    '''Gets/sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext

#Region "Additional test attributes"
    ' You can use the following additional attributes as you write your tests:
    ' Use ClassInitialize to run code before running the first test in the class
    <ClassInitialize()> Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
        ModelContext.newForUnitTests()
    End Sub
    '
    ' Use ClassCleanup to run code after all tests in a class have run
    <ClassCleanup()> Public Shared Sub MyClassCleanup()
        ModelContext.release()
    End Sub

    'Use TestInitialize to run code before running each test
    '<TestInitialize()> _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    ' Use TestCleanup to run code after each test has run
    <TestCleanup()> Public Sub MyTestCleanup()
    End Sub
    '
#End Region

    <TestMethod()> Public Sub TestLoadAndSaveProject()
		
		ModelContext.beginTrans()
		Try

			Dim pdb As New ProjectDBMapper()
			dim count as Long = pdb.RecordCount()
			
			If pdb.SelectFromObjectName <> pdb.ManagedTableName Then
                Dim countFromSelectObject As Long = pdb.dbConn.getLngValue("select count(*) from " & pdb.SelectFromObjectName)
                Assert.AreEqual(count, countFromSelectObject, _ 
					"Count of records in managedTableName {0} and SelectFromObjectName {1} should be equal, as there needs to be exactly 1 to 1 match between records in managed table and selectFromObject.", _
						pdb.ManagedTableName, pdb.SelectFromObjectName)
            End If
		
			If count = 0 Then
				Assert.Inconclusive("No Project in database, table is empty")
			Else
				Dim pid As Object = ModelContext.CurrentDBUtils.getObjectValue("select top 1 ProjectId from Project")
				
				Dim p As Project = pdb.findByKey(pid)
				Dim p2 As Project = directCast(p.copy(),Project)

				'Test equality and hash codes
				Assert.AreEqual(p.GetHashCode(), p2.GetHashCode())
				Assert.AreEqual(p, p2)
						
				p.isDirty = True 'force save
				pdb.save(p)
			
				'now reload object from database
				p = Nothing
				p = pdb.findByKey(pid)
            
				'test fields to be equal before and after save
						Assert.IsTrue(p.PrProjectId = p2.PrProjectId,"Expected Field PrProjectId to be equal")
		Assert.IsTrue(p.PrProjectName = p2.PrProjectName,"Expected Field PrProjectName to be equal")
		Assert.IsTrue(p.PrIsActive = p2.PrIsActive,"Expected Field PrIsActive to be equal")
		Assert.IsTrue(p.PrProjectTypeId.GetValueOrDefault = p2.PrProjectTypeId.GetValueOrDefault,"Expected Field PrProjectTypeId to be equal")

					Assert.isTrue(p.PrEmployeeProjects isNot Nothing)

				
				p.isDirty = True 'to force save
				ModelContext.Current.saveModelObject(p)
				p = ModelContext.Current.loadModelObject(Of Project)(p.Id)
				
				p.loadObjectHierarchy()

				

			End If

		Finally
            ModelContext.rollbackTrans() 'Nothing should be saved to the database!
        End Try

    End Sub

End Class

