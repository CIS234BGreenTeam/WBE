Imports libWBEBR
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports libWBEData



'''<summary>
'''This is a test class for colOrdersTest and is intended
'''to contain all colOrdersTest Unit Tests
'''</summary>
<TestClass()> _
Public Class colOrdersTest


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

    'Use ClassInitialize to run code before running the first test in the class
    <ClassInitialize()> _
    Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
        CustomerDB.SetupAdapter()
    End Sub

#End Region



    '''<summary>
    '''A test for Adding order to database
    '''</summary>
    <TestMethod()> _
    Public Sub colOrders_Add_Test()
        Dim target As colOrders = New colOrders()
        Dim sError As String = ""
        target.Fill(sError) 'Fill the collection
        'Create new Orders object
        Dim expected As New Orders(1, Today, 0)
        target.Add(expected) 'Add object to collection
        OrdersDB.Update() 'Update database
        Dim actual As Orders
        actual = target(target.Count - 1) 'Get last record (most recently added)
        'Need to do the following instead of a normal "=" because "expected" does not have a real CustomerID
        Dim bAreEqual As Boolean =
            (actual.OrderID = expected.OrderID) And
            (actual.OrderDate = expected.OrderDate) And
            (actual.Status = expected.Status)
        Assert.IsTrue(bAreEqual)
    End Sub

    '''<summary>
    '''A test for Change
    '''</summary>
    <TestMethod()> _
    Public Sub ChangeTest()
        Dim target As colOrders = New colOrders() ' TODO: Initialize to an appropriate value
        Dim objOrders As Orders = Nothing ' TODO: Initialize to an appropriate value
        target.Change(objOrders)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for Fill
    '''</summary>
    <TestMethod()> _
    Public Sub FillTest()
        Dim target As colOrders = New colOrders() ' TODO: Initialize to an appropriate value
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
        Dim target As colOrders = New colOrders() ' TODO: Initialize to an appropriate value
        Dim iID As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim expected As Orders = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As Orders
        actual = target.Find(iID)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Remove
    '''</summary>
    <TestMethod()> _
    Public Sub RemoveTest()
        Dim target As colOrders = New colOrders() ' TODO: Initialize to an appropriate value
        Dim objOrders As Orders = Nothing ' TODO: Initialize to an appropriate value
        target.Remove(objOrders)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub
End Class
