Imports System

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports libWBEBR



'''<summary>
'''This is a test class for OrderTest and is intended
'''to contain all OrderTest Unit Tests
'''</summary>
<TestClass()> _
Public Class OrdersTest


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
            testContextInstance = value
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
    '''A test for Orders Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub OrderConstructorTest()
        Dim target As Orders = New Orders()
        'Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub

    '''<summary>
    '''A test for CustomerID
    '''</summary>
    <TestMethod()> _
    Public Sub CustomerIDTest()
        Dim target As Orders = New Orders() ' TODO: Initialize to an appropriate value
        Dim expected As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim actual As Integer
        target.CustomerID = expected
        actual = target.CustomerID
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Driver
    '''</summary>
    <TestMethod()> _
    Public Sub DriverTest()
        Dim target As Orders = New Orders() ' TODO: Initialize to an appropriate value
        Dim expected As Driver = New Driver ' TODO: Initialize to an appropriate value
        Dim actual As Driver
        target.Driver = expected
        actual = target.Driver
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Item
    '''</summary>
    <TestMethod()> _
    Public Sub OrderItemTest()
        Dim target As Orders = New Orders() ' TODO: Initialize to an appropriate value
        Dim expected As List(Of OrderItem) = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As List(Of OrderItem)
        target.Item = expected
        actual = target.Item
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    ' '''<summary>
    ' '''A test for OrderDate
    ' '''</summary>
    '<TestMethod()> _
    'Public Sub OrderDateTest()
    '    Dim target As Orders = New Orders() ' TODO: Initialize to an appropriate value
    '    Dim expected As DateTime = New DateTime() ' TODO: Initialize to an appropriate value
    '    Dim actual As DateTime
    '    target.OrderDate = expected
    '    actual = target.OrderDate
    '    Assert.AreEqual(expected, actual)
    '    Assert.Inconclusive("Verify the correctness of this test method.")
    'End Sub

    '''<summary>
    '''A test for ivalid OrderID below minimum value
    '''</summary>
    <TestMethod()> _
        <ExpectedException(GetType(System.Exception), "This OrderID should be invalid at 1 below the Minimum allowed value of 1.")>
    Public Sub Orders_BelowMinOrderID_Test()
        Dim target As Orders = New Orders()
        Dim expected As Integer = 0
        Dim actual As Integer
        target.OrderID = expected
        actual = target.OrderID
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for invalid OrderID above max value
    '''</summary>
    <TestMethod()> _
        <ExpectedException(GetType(System.Exception), "This OrderID should be invalid at 1 above the maximum allowed value of 999999.")>
    Public Sub Orders_OverMinOrderID_Test()
        Dim target As Orders = New Orders()
        Dim expected As Integer = 1000000
        Dim actual As Integer
        target.OrderID = expected
        actual = target.OrderID
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for valid OrderID at minimum value
    '''</summary>
    <TestMethod()>
    Public Sub Orders_MinOrderID_Test()
        Dim target As Orders = New Orders()
        Dim expected As Integer = 1
        Dim actual As Integer
        target.OrderID = expected
        actual = target.OrderID
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for valid OrderID at maximum value
    '''</summary>
    <TestMethod()>
    Public Sub Orders_MaxOrderID_Test()
        Dim target As Orders = New Orders()
        Dim expected As Integer = 999999
        Dim actual As Integer
        target.OrderID = expected
        actual = target.OrderID
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub


    '''<summary>
    '''A test for Status
    '''</summary>
    <TestMethod()> _
    Public Sub Status_Baking_Test()
        Dim target As Orders = New Orders() ' TODO: Initialize to an appropriate value
        Dim expected As Orders.eStatus = Orders.eStatus.Baking ' TODO: Initialize to an appropriate value
        Dim actual As Orders.eStatus
        target.Status = expected
        actual = target.Status
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Status
    '''</summary>
    <TestMethod()> _
    Public Sub Status_NewOrder_Test()
        Dim target As Orders = New Orders() ' TODO: Initialize to an appropriate value
        Dim expected As Orders.eStatus = Orders.eStatus.NewOrder ' TODO: Initialize to an appropriate value
        Dim actual As Orders.eStatus
        target.Status = expected
        actual = target.Status
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Status
    '''</summary>
    <TestMethod()> _
    Public Sub Status_Invoiced_Test()
        Dim target As Orders = New Orders() ' TODO: Initialize to an appropriate value
        Dim expected As Orders.eStatus = Orders.eStatus.Invoiced ' TODO: Initialize to an appropriate value
        Dim actual As Orders.eStatus
        target.Status = expected
        actual = target.Status
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for valid OrderDate for todays date
    '''</summary>
    <TestMethod()> _
    Public Sub OrderDate_Today_Test()
        Dim target As Orders = New Orders() ' TODO: Initialize to an appropriate value
        Dim expected As DateTime = Today
        Dim actual As DateTime
        target.OrderDate = expected
        actual = target.OrderDate
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for valid OrderDate at minimum date value
    '''</summary>
    <TestMethod()> _
    Public Sub OrderDate_MinDate_Test()
        Dim target As Orders = New Orders() ' TODO: Initialize to an appropriate value
        Dim expected As DateTime = Today.AddDays(-7)
        Dim actual As DateTime
        target.OrderDate = expected
        actual = target.OrderDate
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for valid OrderDate at max value
    '''</summary>
    <TestMethod()> _
    Public Sub OrderDate_MaxDate_Test()
        Dim target As Orders = New Orders() ' TODO: Initialize to an appropriate value
        Dim expected As DateTime = Today.AddDays(3)
        Dim actual As DateTime
        target.OrderDate = expected
        actual = target.OrderDate
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for invalid OrderDate at 1 above max date
    '''</summary>
    <TestMethod()> _
        <ExpectedException(GetType(System.Exception), "This OrderID should be invalid at 1 above the maximum allowed value of Today + 3.")>
    Public Sub OrderDate_OverMaxDate_Test()
        Dim target As Orders = New Orders() ' TODO: Initialize to an appropriate value
        Dim expected As DateTime = Today.AddDays(4)
        Dim actual As DateTime
        target.OrderDate = expected
        actual = target.OrderDate
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for invalid OrderDate at 1 below minimum date
    '''</summary>
    <TestMethod()> _
        <ExpectedException(GetType(System.Exception), "This OrderDate should be invalid at 1 day below the maximum allowed value of Today - 7.")>
    Public Sub OrderDate_UnderMinDate_Test()
        Dim target As Orders = New Orders() ' TODO: Initialize to an appropriate value
        Dim expected As DateTime = Today.AddDays(-8)
        Dim actual As DateTime
        target.OrderDate = expected
        actual = target.OrderDate
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub
End Class
