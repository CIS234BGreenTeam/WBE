Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports libWBEBR

'* Class Name: OrderItemTest. 
'* Designer: Ken Baker 4/20/2013. 
'* Purpose:  Test class properties and constructors

'''<summary>
'''This is a test class for OrderItemTest and is intended
'''to contain all OrderItemTest Unit Tests
'''</summary>
<TestClass()> _
Public Class OrderItemTest


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
    '''A test for UnitPrice at the minimum good value of 0.00
    '''</summary>
    <TestMethod()>
    Public Sub UnitPrice_PriceMin_Test()
        Dim target As OrderItem = New OrderItem()
        Dim expected As [Decimal] = New [Decimal](0D)
        Dim actual As [Decimal]
        target.UnitPrice = expected
        actual = target.UnitPrice
        Assert.AreEqual(expected, actual)
    End Sub
    '''<summary>
    '''A test for UnitPrice at the maximum good value of 250.00
    '''</summary>
    <TestMethod()>
    Public Sub UnitPrice_PriceMax_Test()
        Dim target As OrderItem = New OrderItem()
        Dim expected As [Decimal] = New [Decimal](250D)
        Dim actual As [Decimal]
        target.UnitPrice = expected
        actual = target.UnitPrice
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for UnitPrice below the minimum good value of 0.00
    '''</summary>
    <TestMethod()> _
        <ExpectedException(GetType(System.Exception), "This UnitPrice should be invalid at 0.01 below the minimum allowed value of 0.00.")>
    Public Sub UnitPrice_PriceUnderMin_Test()
        Dim target As OrderItem = New OrderItem()
        Dim expected As [Decimal] = New [Decimal](-0.01D)
        Dim actual As [Decimal]
        target.UnitPrice = expected
        actual = target.UnitPrice
        Assert.AreEqual(expected, actual)
    End Sub
    '''<summary>
    '''A test for UnitPrice above the maximum good value of 250.00
    '''</summary>
    <TestMethod()> _
        <ExpectedException(GetType(System.Exception), "This UnitPrice should be invalid at 0.01 above the maximum allowed value of 250.00.")>
    Public Sub UnitPrice_PriceOverMax_Test()
        Dim target As OrderItem = New OrderItem()
        Dim expected As [Decimal] = New [Decimal](250.01D)
        Dim actual As [Decimal]
        target.UnitPrice = expected
        actual = target.UnitPrice
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for Quantity at the minimum good value of 1
    '''</summary>
    <TestMethod()>
    Public Sub Quantity_Min_Test()
        Dim target As OrderItem = New OrderItem()
        Dim expected As Integer = 1
        Dim actual As Integer
        target.Quantity = expected
        actual = target.Quantity
        Assert.AreEqual(expected, actual)
    End Sub


    '''<summary>
    '''A test for Quantity at the maximum good value of 500
    '''</summary>
    <TestMethod()>
    Public Sub Quantity_Max_Test()
        Dim target As OrderItem = New OrderItem()
        Dim expected As Integer = 500
        Dim actual As Integer
        target.Quantity = expected
        actual = target.Quantity
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for Quantity under the minimum good value of 1
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "This Quantity should be invalid at 1 below the minimum allowed value of 1.")>
    Public Sub Quantity_UnderMin_Test()
        Dim target As OrderItem = New OrderItem()
        Dim expected As Integer = 0
        Dim actual As Integer
        target.Quantity = expected
        actual = target.Quantity
        Assert.AreEqual(expected, actual)
    End Sub


    '''<summary>
    '''A test for Quantity over the maximum good value of 500
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "This Quantity should be invalid at 1 above the maximum allowed value of 500.")>
    Public Sub Quantity_OverMax_Test()
        Dim target As OrderItem = New OrderItem()
        Dim expected As Integer = 501
        Dim actual As Integer
        target.Quantity = expected
        actual = target.Quantity
        Assert.AreEqual(expected, actual)
    End Sub

End Class

