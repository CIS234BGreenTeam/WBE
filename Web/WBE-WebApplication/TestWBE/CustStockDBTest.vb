Imports System.Data.SqlClient

Imports System.Collections.Generic

Imports System.Data

Imports libWBEBR

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports libWBEData



'''<summary>
'''This is a test class for CustStockDBTest and is intended
'''to contain all CustStockDBTest Unit Tests
'''</summary>
<TestClass()> _
Public Class CustStockDBTest


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
    '''A test for CustStockDB Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub CustStockDBConstructorTest()
        Dim target As CustStockDB = New CustStockDB()
        Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub

    '''<summary>
    '''A test for Add
    '''</summary>
    <TestMethod()> _
    Public Sub AddTest()
        Dim target As WBEData = New WBEData()
        Dim sError As String = ""
        CustStockDB.CustomerID = 1
        CustStockDB.SetupAdapter()
        Dim colStock As New colCustStock
        colStock.Fill(sError)
        Dim objCustStock As New CustStock(2, 1, 4)
        colStock.Add(objCustStock)
        CustStockDB.Update()
    End Sub

    '''<summary>
    '''A test for Change
    '''</summary>
    <TestMethod()> _
    Public Sub ChangeTest()
        Dim objCustStock As CustStock = Nothing ' TODO: Initialize to an appropriate value
        CustStockDB.Change(objCustStock)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for CopyToDataRow
    '''</summary>
    <TestMethod()> _
    Public Sub CopyToDataRowTest()
        Dim objCustStock As CustStock = Nothing ' TODO: Initialize to an appropriate value
        Dim drCustStock As DataRow = Nothing ' TODO: Initialize to an appropriate value
        CustStockDB.CopyToDataRow(objCustStock, drCustStock)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for Delete
    '''</summary>
    <TestMethod()> _
    Public Sub DeleteTest()
        Dim objCustStock As CustStock = Nothing ' TODO: Initialize to an appropriate value
        CustStockDB.Delete(objCustStock)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for Fill
    '''</summary>
    <TestMethod()> _
    Public Sub FillTest()
        Dim colCustStock As List(Of CustStock) = Nothing ' TODO: Initialize to an appropriate value
        Dim sError As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim sErrorExpected As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As Boolean = False ' TODO: Initialize to an appropriate value
        Dim actual As Boolean
        actual = CustStockDB.Fill(colCustStock, sError)
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
        actual = CustStockDB.FindRow(iID)
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
        CustStockDB_Accessor.OnRowUpdated(sender, args)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for SetupAdapter
    '''</summary>
    <TestMethod()> _
    Public Sub SetupAdapterTest()
        CustStockDB.SetupAdapter()
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for Update
    '''</summary>
    <TestMethod()> _
    Public Sub UpdateTest()
        CustStockDB.Update()
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for CustomerID
    '''</summary>
    <TestMethod()> _
    Public Sub CustomerIDTest()
        Dim expected As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim actual As Integer
        CustStockDB.CustomerID = expected
        actual = CustStockDB.CustomerID
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub
End Class
