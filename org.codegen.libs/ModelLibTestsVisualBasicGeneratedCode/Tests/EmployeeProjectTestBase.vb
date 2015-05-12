﻿
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting


'<comments>
'Template: TestTemplate.visualbasic.txt
'************************************************************
' Class autogenerated on 12-May-15 9:50:31 AM by ModelGenerator
' DO NOT MODIFY CODE IN THIS CLASS
'************************************************************
'</comments>
<TestClass()> Public Class EmployeeProjectTestBase

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

    <TestMethod()> Public Sub TestLoadAndSaveEmployeeProject()
		
		ModelContext.beginTrans()
		Try

			Dim pid As long = ModelContext.CurrentDBUtils.getIntValue("select top 1 EmployeeProjectId from EmployeeProject")
			If pid = 0 Then
				Assert.Inconclusive("No EmployeeProject in database, table is empty")
			Else

				Dim pdb As New EmployeeProjectDBMapper()
				Dim p As EmployeeProject = pdb.findByKey(pid)
				Dim p2 As EmployeeProject = directCast(p.copy(),EmployeeProject)

				'Test equality and hash codes
				Assert.AreEqual(p.GetHashCode(), p2.GetHashCode())
				Assert.AreEqual(p, p2)
						
				p.isDirty = True 'force save
				pdb.save(p)
			
				'now reload object from database
				p = Nothing
				p = pdb.findByKey(pid)
            
				'test fields to be equal before and after save
						Assert.IsTrue(p.EmployeeProjectId = p2.EmployeeProjectId,"Expected Field EmployeeProjectId to be equal")
		Assert.IsTrue(p.EPEmployeeId.GetValueOrDefault = p2.EPEmployeeId.GetValueOrDefault,"Expected Field EPEmployeeId to be equal")
		Assert.IsTrue(p.EPProjectId.GetValueOrDefault = p2.EPProjectId.GetValueOrDefault,"Expected Field EPProjectId to be equal")
		Assert.IsTrue(p.AssignDate.GetValueOrDefault = p2.AssignDate.GetValueOrDefault,"Expected Field AssignDate to be equal")
		Assert.IsTrue(p.EndDate.GetValueOrDefault = p2.EndDate.GetValueOrDefault,"Expected Field EndDate to be equal")
		Assert.IsTrue(p.Rate.GetValueOrDefault = p2.Rate.GetValueOrDefault,"Expected Field Rate to be equal")

					Assert.isTrue(p.PrProject isNot Nothing)

				
				p.isDirty = True 'to force save
				ModelContext.Current.saveModelObject(p)
				p = ModelContext.Current.loadModelObject(Of EmployeeProject)(p.Id)
				
			End If

		Finally
            ModelContext.rollbackTrans() 'Nothing should be saved to the database!
        End Try

    End Sub

End Class

