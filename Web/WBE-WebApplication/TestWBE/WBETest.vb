Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports libWBEBR



'''<summary>
'''This is a test class for WBETest and is intended
'''to contain all WBETest Unit Tests
'''</summary>
<TestClass()> _
Public Class WBETest


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
    '''A test for WBE Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub WBEConstructorTest()
        Dim target As WBE = New WBE()
        Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub

    '''<summary>
    '''A test for BakedGood
    '''</summary>
    <TestMethod()> _
    Public Sub BakedGoodTest()
        Dim target As WBE = New WBE() ' TODO: Initialize to an appropriate value
        Dim expected As List(Of BakedGood) = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As List(Of BakedGood)
        target.BakedGood = expected
        actual = target.BakedGood
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Customer
    '''</summary>
    <TestMethod()> _
    Public Sub CustomerTest()
        Dim target As WBE = New WBE() ' TODO: Initialize to an appropriate value
        Dim expected As List(Of Customer) = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As List(Of Customer)
        target.Customer = expected
        actual = target.Customer
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Driver
    '''</summary>
    <TestMethod()> _
    Public Sub DriverTest()
        Dim target As WBE = New WBE() ' TODO: Initialize to an appropriate value
        Dim expected As List(Of Driver) = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As List(Of Driver)
        target.Driver = expected
        actual = target.Driver
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub
End Class
