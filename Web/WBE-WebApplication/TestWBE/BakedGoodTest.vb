Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports libWBEBR



'''<summary>
'''This is a test class for BakedGoodTest and is intended
'''to contain all BakedGoodTest Unit Tests
'''</summary>
<TestClass()> _
Public Class BakedGoodTest


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
    '''A test for BakedGood Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub BakedGoodConstructorTest()
        Dim target As BakedGood = New BakedGood()
        Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub

    '''<summary>
    '''A test for GetExtendedPrice
    '''</summary>
    <TestMethod()> _
    Public Sub GetExtendedPriceTest()
        Dim target As BakedGood = New BakedGood() ' TODO: Initialize to an appropriate value
        Dim expected As [Decimal] = New [Decimal]() ' TODO: Initialize to an appropriate value
        Dim actual As [Decimal]
        actual = target.GetExtendedPrice
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for GetOrderQty
    '''</summary>
    <TestMethod()> _
    Public Sub GetOrderQtyTest()
        Dim target As BakedGood = New BakedGood() ' TODO: Initialize to an appropriate value
        Dim expected As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim actual As Integer
        actual = target.GetOrderQty
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for ActualQty
    '''</summary>
    <TestMethod()> _
    Public Sub ActualQtyTest()
        Dim target As BakedGood = New BakedGood() ' TODO: Initialize to an appropriate value
        Dim expected As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim actual As Integer
        target.ActualQty = expected
        actual = target.ActualQty
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for DesiredQty
    '''</summary>
    <TestMethod()> _
    Public Sub DesiredQtyTest()
        Dim target As BakedGood = New BakedGood() ' TODO: Initialize to an appropriate value
        Dim expected As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim actual As Integer
        target.DesiredQty = expected
        actual = target.DesiredQty
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Name
    '''</summary>
    <TestMethod()> _
    Public Sub NameTest()
        Dim target As BakedGood = New BakedGood() ' TODO: Initialize to an appropriate value
        Dim expected As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        target.Name = expected
        actual = target.Name
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Price
    '''</summary>
    <TestMethod()> _
    Public Sub PriceTest()
        Dim target As BakedGood = New BakedGood() ' TODO: Initialize to an appropriate value
        Dim expected As [Decimal] = New [Decimal]() ' TODO: Initialize to an appropriate value
        Dim actual As [Decimal]
        target.Price = expected
        actual = target.Price
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub
End Class
