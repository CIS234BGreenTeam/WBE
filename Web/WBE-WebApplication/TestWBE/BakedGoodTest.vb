Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports libWBEBR

'* Class Name: BakedGoodTest. 
'* Designer: Ken Baker 4/20/2013. 
'* Purpose:  Test class properties and constructors


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
        'Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub


    '''<summary>
    '''A test for a baked good Name at a valid minimum length = 2 chars
    '''</summary>
    <TestMethod()>
    Public Sub Name_NameMin_Test()
        Dim target As BakedGood = New BakedGood() ' TODO: Initialize to an appropriate value
        Dim expected As String = "12"
        Dim actual As String
        target.Name = expected
        actual = target.Name
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")

    End Sub
    '''<summary>
    '''A test for a baked good Name at a valid maximum length = 30 chars
    '''</summary>
    <TestMethod()>
    Public Sub Name_NameMax_Test()
        Dim target As BakedGood = New BakedGood() ' TODO: Initialize to an appropriate value
        Dim expected As String = "123456789012345678901234567890"
        Dim actual As String
        target.Name = expected
        actual = target.Name
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for an invalid baked good Name (1 char below  minimum length of 2 chars)
    '''</summary>
    <TestMethod()> _
     <ExpectedException(GetType(System.Exception), "This Name should be invalid at 1 below the lower limit of 2 chars.")>
    Public Sub Name_NameUnderMin_Test()
        Dim target As BakedGood = New BakedGood() ' TODO: Initialize to an appropriate value
        Dim expected As String = "1"
        Dim actual As String
        target.Name = expected
        actual = target.Name
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for an invalid baked good Name (1 char above  maximum length of 30 chars)
    '''</summary>
    <TestMethod()> _
     <ExpectedException(GetType(System.Exception), "This Name should be invalid at 1 above the Upper limit of 30 chars.")>
    Public Sub Name_NameOverMax_Test()
        Dim target As BakedGood = New BakedGood() ' TODO: Initialize to an appropriate value
        Dim expected As String = "1234567890123456789012345678901"
        Dim actual As String
        target.Name = expected
        actual = target.Name
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for a baked good name Name with an empty string
    '''</summary>
    <TestMethod()> _
     <ExpectedException(GetType(System.Exception), "This Name should be invalid containing no chars.")>
    Public Sub Name_NameEmpty_Test()
        Dim target As BakedGood = New BakedGood()
        Dim expected As String = ""
        Dim actual As String
        target.Name = expected
        actual = target.Name
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub
    '''<summary>
    '''A test for UnitPrice at the minimum good value of 0.50
    '''</summary>
    <TestMethod()>
    Public Sub UnitPrice_PriceMin_Test()
        Dim target As BakedGood = New BakedGood()
        Dim expected As [Decimal] = New [Decimal](0.5D)
        Dim actual As [Decimal]
        target.UnitPrice = expected
        actual = target.UnitPrice
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub
    '''<summary>
    '''A test for UnitPrice at the maximum good value of 250.00
    '''</summary>
    <TestMethod()>
    Public Sub UnitPrice_PriceMax_Test()
        Dim target As BakedGood = New BakedGood()
        Dim expected As [Decimal] = New [Decimal](250D)
        Dim actual As [Decimal]
        target.UnitPrice = expected
        actual = target.UnitPrice
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for UnitPrice below the minimum good value of 0.50
    '''</summary>
    <TestMethod()> _
        <ExpectedException(GetType(System.Exception), "This UnitPrice should be invalid at 0.01 below the minimum allowed value of 0.50.")>
    Public Sub UnitPrice_PriceUnderMin_Test()
        Dim target As BakedGood = New BakedGood()
        Dim expected As [Decimal] = New [Decimal](0.49D)
        Dim actual As [Decimal]
        target.UnitPrice = expected
        actual = target.UnitPrice
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub
    '''<summary>
    '''A test for UnitPrice above the maximum good value of 250.00
    '''</summary>
    <TestMethod()> _
        <ExpectedException(GetType(System.Exception), "This UnitPrice should be invalid at 0.01 above the maximum allowed value of 250.00.")>
    Public Sub UnitPrice_PriceOverMax_Test()
        Dim target As BakedGood = New BakedGood()
        Dim expected As [Decimal] = New [Decimal](250.01D)
        Dim actual As [Decimal]
        target.UnitPrice = expected
        actual = target.UnitPrice
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for UnitPrice with no value
    '''</summary>
    <TestMethod()> _
        <ExpectedException(GetType(System.Exception), "This UnitPrice of no value (empty) should be invalid.")>
    Public Sub UnitPrice_PriceEmpty_Test()
        Dim target As BakedGood = New BakedGood()
        Dim expected As [Decimal] = New [Decimal](vbEmpty)
        Dim actual As [Decimal]
        target.UnitPrice = expected
        actual = target.UnitPrice
        Assert.AreEqual(expected, actual)
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub



    '================================NOT INCLUDED AT THIS TIME==========================
    ' '''<summary>
    ' '''A test for GetExtendedPrice
    ' '''</summary>
    '<TestMethod()> _
    'Public Sub GetExtendedPriceTest()
    '    Dim target As BakedGood = New BakedGood() ' TODO: Initialize to an appropriate value
    '    Dim expected As [Decimal] = New [Decimal]() ' TODO: Initialize to an appropriate value
    '    Dim actual As [Decimal]
    '    actual = target.GetExtendedPrice
    '    Assert.AreEqual(expected, actual)
    '    Assert.Inconclusive("Verify the correctness of this test method.")
    'End Sub
    '==============================================================
    ' '''<summary>
    ' '''A test for GetOrderQty
    ' '''</summary>
    '<TestMethod()> _
    'Public Sub GetOrderQtyTest()
    '    Dim target As BakedGood = New BakedGood() ' TODO: Initialize to an appropriate value
    '    Dim expected As Integer = 0 ' TODO: Initialize to an appropriate value
    '    Dim actual As Integer
    '    actual = target.GetOrderQty
    '    Assert.AreEqual(expected, actual)
    '    Assert.Inconclusive("Verify the correctness of this test method.")
    'End Sub
    '================================================================

    ' '''<summary>
    ' '''A test for ActualQty
    ' '''</summary>
    '<TestMethod()> _
    'Public Sub ActualQtyTest()
    '    Dim target As BakedGood = New BakedGood() ' TODO: Initialize to an appropriate value
    '    Dim expected As Integer = 0 ' TODO: Initialize to an appropriate value
    '    Dim actual As Integer
    '    target.ActualQty = expected
    '    actual = target.ActualQty
    '    Assert.AreEqual(expected, actual)
    '    Assert.Inconclusive("Verify the correctness of this test method.")
    'End Sub
    '================================================================
    ' '''<summary>
    ' '''A test for DesiredQty
    ' '''</summary>
    '<TestMethod()> _
    'Public Sub DesiredQtyTest()
    '    Dim target As BakedGood = New BakedGood() ' TODO: Initialize to an appropriate value
    '    Dim expected As Integer = 0 ' TODO: Initialize to an appropriate value
    '    Dim actual As Integer
    '    target.DesiredQty = expected
    '    actual = target.DesiredQty
    '    Assert.AreEqual(expected, actual)
    '    Assert.Inconclusive("Verify the correctness of this test method.")
    'End Sub
    '================================================================
    ' '''<summary>
    ' '''A test for Type
    ' '''</summary>
    '<TestMethod()> _
    'Public Sub TypeTest()
    '    Dim target As BakedGood = New BakedGood() ' TODO: Initialize to an appropriate value
    '    Dim expected As String = String.Empty ' TODO: Initialize to an appropriate value
    '    Dim actual As String
    '    target.Type = expected
    '    actual = target.Type
    '    Assert.AreEqual(expected, actual)
    '    Assert.Inconclusive("Verify the correctness of this test method.")
    'End Sub
End Class
