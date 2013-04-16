Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports libWBEBR



'''<summary>
'''This is a test class for CustomerTest and is intended
'''to contain all CustomerTest Unit Tests
'''</summary>
<TestClass()> _
Public Class CustomerTest


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
    '''A test for Customer Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub CustomerConstructorTest()
        Dim target As Customer = New Customer()
        Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub

    '''<summary>
    '''A test for Address1
    '''</summary>
    <TestMethod()> _
    Public Sub Address1Test()
        Dim target As Customer = New Customer() ' TODO: Initialize to an appropriate value
        Dim expected As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        target.Address1 = expected
        actual = target.Address1
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Address2
    '''</summary>
    <TestMethod()> _
    Public Sub Address2Test()
        Dim target As Customer = New Customer() ' TODO: Initialize to an appropriate value
        Dim expected As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        target.Address2 = expected
        actual = target.Address2
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for City
    '''</summary>
    <TestMethod()> _
    Public Sub CityTest()
        Dim target As Customer = New Customer() ' TODO: Initialize to an appropriate value
        Dim expected As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        target.City = expected
        actual = target.City
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Email
    '''</summary>
    <TestMethod()> _
    Public Sub EmailTest()
        Dim target As Customer = New Customer() ' TODO: Initialize to an appropriate value
        Dim expected As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        target.Email = expected
        actual = target.Email
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Fax
    '''</summary>
    <TestMethod()> _
    Public Sub FaxTest()
        Dim target As Customer = New Customer() ' TODO: Initialize to an appropriate value
        Dim expected As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        target.Fax = expected
        actual = target.Fax
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Name
    '''</summary>
    <TestMethod()> _
    Public Sub NameTest()
        Dim target As Customer = New Customer() ' TODO: Initialize to an appropriate value
        Dim expected As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        target.Name = expected
        actual = target.Name
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Order
    '''</summary>
    <TestMethod()> _
    Public Sub OrderTest()
        Dim target As Customer = New Customer() ' TODO: Initialize to an appropriate value
        Dim expected As List(Of Order) = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As List(Of Order)
        target.Order = expected
        actual = target.Order
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Phone
    '''</summary>
    <TestMethod()> _
    Public Sub PhoneTest()
        Dim target As Customer = New Customer() ' TODO: Initialize to an appropriate value
        Dim expected As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        target.Phone = expected
        actual = target.Phone
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for State
    '''</summary>
    <TestMethod()> _
    Public Sub StateTest()
        Dim target As Customer = New Customer() ' TODO: Initialize to an appropriate value
        Dim expected As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        target.State = expected
        actual = target.State
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Stock
    '''</summary>
    <TestMethod()> _
    Public Sub StockTest()
        Dim target As Customer = New Customer() ' TODO: Initialize to an appropriate value
        Dim expected As List(Of BakedGood) = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As List(Of BakedGood)
        target.Stock = expected
        actual = target.Stock
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Zip
    '''</summary>
    <TestMethod()> _
    Public Sub ZipTest()
        Dim target As Customer = New Customer() ' TODO: Initialize to an appropriate value
        Dim expected As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim actual As Integer
        target.Zip = expected
        actual = target.Zip
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub
End Class
