﻿Imports libWBEBR

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports libWBEData



'''<summary>
'''This is a test class for colDriversTest and is intended
'''to contain all colDriversTest Unit Tests
'''</summary>
<TestClass()> _
Public Class colDriversTest


    Private testContextInstance As TestContext

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(value As TestContext)
            testContextInstance = Value
        End Set
    End Property

#Region "Additional test attributes"
    '
    'You can use the following additional attributes as you write your tests:
    '
    'Use ClassInitialize to run code before running the first test in the class
    '<ClassInitialize()>  _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Use ClassCleanup to run code after all tests in a class have run
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    'Use TestInitialize to run code before running each test
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    'Use TestCleanup to run code after each test has run
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region


    '''<summary>
    '''A test for colDrivers Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub colDriversConstructorTest()
        Dim target As colDrivers = New colDrivers()
        Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub

    '''<summary>
    '''A test for Add
    '''</summary>
    <TestMethod()> _
    Public Sub AddTest()
        Dim target As colDrivers = New colDrivers() ' TODO: Initialize to an appropriate value
        Dim objDriver As Driver = Nothing ' TODO: Initialize to an appropriate value
        target.Add(objDriver)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for Change
    '''</summary>
    <TestMethod()> _
    Public Sub ChangeTest()
        Dim target As colDrivers = New colDrivers() ' TODO: Initialize to an appropriate value
        Dim objDriver As Driver = Nothing ' TODO: Initialize to an appropriate value
        target.Change(objDriver)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for Fill
    '''</summary>
    <TestMethod()> _
    Public Sub FillTest()
        Dim target As colDrivers = New colDrivers() ' TODO: Initialize to an appropriate value
        Dim sError As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As Boolean = False ' TODO: Initialize to an appropriate value
        Dim actual As Boolean
        actual = target.Fill(sError)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Find
    '''</summary>
    <TestMethod()> _
    Public Sub FindTest()
        Dim target As colDrivers = New colDrivers() ' TODO: Initialize to an appropriate value
        Dim iID As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim expected As Driver = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As Driver
        actual = target.Find(iID)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for FindID
    '''</summary>
    <TestMethod(), _
     DeploymentItem("libWBEData.dll")> _
    Public Sub FindIDTest()
        Dim target As colDrivers_Accessor = New colDrivers_Accessor() ' TODO: Initialize to an appropriate value
        Dim objDriver As Driver = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Boolean = False ' TODO: Initialize to an appropriate value
        Dim actual As Boolean
        actual = target.FindID(objDriver)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Remove
    '''</summary>
    <TestMethod()> _
    Public Sub RemoveTest()
        Dim target As colDrivers = New colDrivers() ' TODO: Initialize to an appropriate value
        Dim objDriver As Driver = Nothing ' TODO: Initialize to an appropriate value
        target.Remove(objDriver)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub
End Class
