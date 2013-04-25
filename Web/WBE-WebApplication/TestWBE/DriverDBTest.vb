Imports System.Data.SqlClient

Imports System.Collections.Generic

Imports System.Data

Imports libWBEBR

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports libWBEData



'''<summary>
'''This is a test class for DriverDBTest and is intended
'''to contain all DriverDBTest Unit Tests
'''</summary>
<TestClass()> _
Public Class DriverDBTest


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
    '''A test for DriverDB Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub DriverDBConstructorTest()
        Dim target As DriverDB = New DriverDB()
        Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub

    '''<summary>
    '''A test for Add
    '''</summary>
    <TestMethod()> _
    Public Sub AddTest()
        Dim objDriver As Driver = Nothing ' TODO: Initialize to an appropriate value
        DriverDB.Add(objDriver)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for Change
    '''</summary>
    <TestMethod()> _
    Public Sub ChangeTest()
        Dim objDriver As Driver = Nothing ' TODO: Initialize to an appropriate value
        DriverDB.Change(objDriver)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for CopyToDataRow
    '''</summary>
    <TestMethod()> _
    Public Sub CopyToDataRowTest()
        Dim objDriver As Driver = Nothing ' TODO: Initialize to an appropriate value
        Dim drDriver As DataRow = Nothing ' TODO: Initialize to an appropriate value
        DriverDB.CopyToDataRow(objDriver, drDriver)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for Delete
    '''</summary>
    <TestMethod()> _
    Public Sub DeleteTest()
        Dim objDriver As Driver = Nothing ' TODO: Initialize to an appropriate value
        DriverDB.Delete(objDriver)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for Fill
    '''</summary>
    <TestMethod()> _
    Public Sub FillTest()
        Dim colDrivers As List(Of Driver) = Nothing ' TODO: Initialize to an appropriate value
        Dim sError As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim sErrorExpected As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As Boolean = False ' TODO: Initialize to an appropriate value
        Dim actual As Boolean
        actual = DriverDB.Fill(colDrivers, sError)
        Assert.AreEqual(sErrorExpected, sError)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for FindRow
    '''</summary>
    <TestMethod()> _
    Public Sub FindRowTest()
        Dim iID As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim expected() As DataRow = Nothing ' TODO: Initialize to an appropriate value
        Dim actual() As DataRow
        actual = DriverDB.FindRow(iID)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for OnRowUpdated
    '''</summary>
    <TestMethod(), _
     DeploymentItem("libWBEData.dll")> _
    Public Sub OnRowUpdatedTest()
        Dim sender As Object = Nothing ' TODO: Initialize to an appropriate value
        Dim args As SqlRowUpdatedEventArgs = Nothing ' TODO: Initialize to an appropriate value
        DriverDB_Accessor.OnRowUpdated(sender, args)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for SetupAdapter
    '''</summary>
    <TestMethod()> _
    Public Sub SetupAdapterTest()
        DriverDB.SetupAdapter()
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for Update
    '''</summary>
    <TestMethod()> _
    Public Sub UpdateTest()
        DriverDB.Update()
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub
End Class
