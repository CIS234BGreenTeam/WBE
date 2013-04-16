Imports System

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports libWBEBR



'''<summary>
'''This is a test class for OrderTest and is intended
'''to contain all OrderTest Unit Tests
'''</summary>
<TestClass()> _
Public Class OrderTest


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
    '''A test for Order Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub OrderConstructorTest()
        Dim target As Order = New Order()
        Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub

    '''<summary>
    '''A test for CustomerID
    '''</summary>
    <TestMethod()> _
    Public Sub CustomerIDTest()
        Dim target As Order = New Order() ' TODO: Initialize to an appropriate value
        Dim expected As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim actual As Integer
        target.CustomerID = expected
        actual = target.CustomerID
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Driver
    '''</summary>
    <TestMethod()> _
    Public Sub DriverTest()
        Dim target As Order = New Order() ' TODO: Initialize to an appropriate value
        Dim expected As Driver = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As Driver
        target.Driver = expected
        actual = target.Driver
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Item
    '''</summary>
    <TestMethod()> _
    Public Sub ItemTest()
        Dim target As Order = New Order() ' TODO: Initialize to an appropriate value
        Dim expected As List(Of OrderItem) = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As List(Of OrderItem)
        target.Item = expected
        actual = target.Item
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for OrderDate
    '''</summary>
    <TestMethod()> _
    Public Sub OrderDateTest()
        Dim target As Order = New Order() ' TODO: Initialize to an appropriate value
        Dim expected As DateTime = New DateTime() ' TODO: Initialize to an appropriate value
        Dim actual As DateTime
        target.OrderDate = expected
        actual = target.OrderDate
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for OrderNo
    '''</summary>
    <TestMethod()> _
    Public Sub OrderNoTest()
        Dim target As Order = New Order() ' TODO: Initialize to an appropriate value
        Dim expected As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim actual As Integer
        target.OrderNo = expected
        actual = target.OrderNo
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub
End Class
