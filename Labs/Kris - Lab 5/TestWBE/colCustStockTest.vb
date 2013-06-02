'This is a class for testing the colStockTest class. By testing the 
'functions of that class, it also tests the functions of the 
'CustStockDB shared class.
'
'Created by: Kristina Frye
'CIS 234B
'April 26, 2013

Imports libWBEBR
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports libWBEData

'''<summary>
'''This is a test class for colCustStock and CustStockDB
'''</summary>
<TestClass()> _
Public Class colCustStockTest

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
        Dim target As New WBEData
        CustStockDB.CustomerID = 13
        CustStockDB.SetupAdapter()
    End Sub
    
#End Region

    '''<summary>
    '''A test for Adding a new custstock item
    '''</summary>
    <TestMethod()> _
    Public Sub colCustStock_Add_Test()

        Dim sError As String = ""
        Dim colStock As New colCustStock
        colStock.Fill(sError) 'Fill the collection
        Dim expected As New CustStock(2, 1, 4) 'Create new custstock object
        colStock.Add(expected) 'Add to the collection
        CustStockDB.Update() 'Update the database

        colStock.Fill(sError) 'Refill the collection
        Dim actual As CustStock
        actual = colStock(colStock.Count - 1)

        'This equality check is done because expected.CustStockID is only a temp value
        Dim bAreEqual As Boolean = (actual.BakedGoodID = expected.BakedGoodID) And
            (actual.CustomerID = expected.CustomerID) And
            (actual.StockQty = expected.StockQty)
        Assert.IsTrue(bAreEqual)
    End Sub

    '''<summary>
    '''A test for Add with Cust1 followed by a second with Cust2
    '''</summary>
    <TestMethod()> _
    Public Sub colCustStock_AddOtherCustomer_Test()

        Dim sError As String = ""
        Dim colStock As New colCustStock
        colStock.Fill(sError) 'Fill the database
        Dim expected As New CustStock(2, 2, 4) 'Create a new object with different customer ID
        colStock.Add(expected) 'Add the object to the collection
        CustStockDB.Update() 'Update the database

        CustStockDB.CustomerID = 2 'Only find custstock where CustomerID = 2
        CustStockDB.SetupAdapter() 'Re-setup adapter with new select statement
        colStock.Fill(sError) 'Refill collection

        'Get last collection item (last added)
        Dim actual As CustStock
        actual = colStock(colStock.Count - 1)

        'Check objects are equal (this check is done because expected.CustStockID is only a temp value
        Dim bAreEqual As Boolean = (actual.BakedGoodID = expected.BakedGoodID) And
            (actual.CustomerID = expected.CustomerID) And
            (actual.StockQty = expected.StockQty)
        Assert.IsTrue(bAreEqual)
    End Sub

    '''<summary>
    '''A test for Changing an existing CustStock object in the collection
    '''</summary>
    <TestMethod()> _
    Public Sub colCustStock_Change_Test()
        Dim sError As String = ""
        Dim colStock As New colCustStock
        colStock.Fill(sError) 'Fill collection

        'Make sure the collection isn't empty
        If colStock.Count = 0 Then
            Dim item As New CustStock(2, 1, 4)
            colStock.Add(item)
            CustStockDB.Update()
            colStock.Fill(sError)
        End If

        'Get a custstock object
        Dim expected As CustStock = colStock(0)
        expected.StockQty += 1 'Change a property
        colStock.Change(expected) 'Update the collection
        CustStockDB.Update() 'Update the database

        colStock.Fill(sError) 'Refill collection
        Dim actual As CustStock = colStock(0) 'Get the object

        'Make sure the two objects are equal
        Dim bAreEqual As Boolean = (actual.StockID = expected.StockID) And
            (actual.BakedGoodID = expected.BakedGoodID) And
            (actual.CustomerID = expected.CustomerID) And
            (actual.StockQty = expected.StockQty)
        Assert.IsTrue(bAreEqual)
    End Sub

    '''<summary>
    '''A test for Changing an existing CustStock object in the collection
    '''</summary>
    <TestMethod()> _
    Public Sub colCustStock_Change_Second_Test()
        Dim sError As String = ""
        Dim colStock As New colCustStock
        colStock.Fill(sError) 'Fill collection

        'Make sure the collection isn't empty
        If colStock.Count = 0 Then
            Dim item As New CustStock(2, 1, 4)
            colStock.Add(item)
            CustStockDB.Update()
            colStock.Fill(sError)
        End If

        'Get a custstock object
        Dim expected As CustStock = colStock(0)
        expected.StockQty += 1 'Change a property
        colStock.Change(expected) 'Update the collection
        CustStockDB.Update() 'Update the database

        colStock.Fill(sError) 'Refill collection

        CustStockDB.CustomerID = 19
        CustStockDB.SetupAdapter()

        colStock.Fill(sError) 'Refill collection

        'Make sure the collection isn't empty
        If colStock.Count = 0 Then
            Dim item As New CustStock(2, 1, 4)
            colStock.Add(item)
            CustStockDB.Update()
            colStock.Fill(sError)
        End If

        'Get a custstock object
        expected = colStock(0)
        expected.StockQty += 1 'Change a property
        colStock.Change(expected) 'Update the collection
        CustStockDB.Update() 'Update the database

        colStock.Fill(sError) 'Refill collection

        Dim actual As CustStock = colStock(0) 'Get the object

        'Make sure the two objects are equal
        Dim bAreEqual As Boolean = (actual.StockID = expected.StockID) And
            (actual.BakedGoodID = expected.BakedGoodID) And
            (actual.CustomerID = expected.CustomerID) And
            (actual.StockQty = expected.StockQty)
        Assert.IsTrue(bAreEqual)
    End Sub
    '''<summary>
    '''A test for Finding a CustStock item by ID
    '''</summary>
    <TestMethod()> _
    Public Sub colCustStock_Find_Test()
        Dim sError As String = ""
        Dim colStock As New colCustStock
        colStock.Fill(sError) 'Fill the collection

        'Make sure the collection isn't empty
        If colStock.Count = 0 Then
            Dim item As New CustStock(2, 1, 4)
            colStock.Add(item)
            CustStockDB.Update()
            colStock.Fill(sError)
        End If

        'Get an object and find its ID
        Dim expected As CustStock = colStock(0)
        Dim iStockID As Integer = expected.StockID

        'Find object by ID
        Dim actual As CustStock = colStock.Find(iStockID)

        'Check the objects are the same
        Assert.AreEqual(actual, expected)
    End Sub

    '''<summary>
    '''A test for Removing a CustStock item from the database
    '''</summary>
    <TestMethod()> _
    Public Sub colCustStock_Remove_Test()
        Dim sError As String = ""
        Dim colStock As New colCustStock
        colStock.Fill(sError) 'Fill the collection

        'Make sure the collection isn't empty
        If colStock.Count = 0 Then
            Dim item As New CustStock(2, 1, 4)
            colStock.Add(item)
            CustStockDB.Update()
            colStock.Fill(sError)
        End If

        'Get an object and find the ID
        Dim expected As CustStock = colStock(colStock.Count - 1)
        Dim iStockID As Integer = expected.StockID
        colStock.Remove(expected) 'Remove the object from database
        CustStockDB.Update() 'Update database

        colStock.Fill(sError)
        Assert.IsNull(colStock.Find(iStockID)) 'Make sure the object no longer exists
    End Sub
End Class
