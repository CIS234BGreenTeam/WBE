'This is a class for testing the colCustomers class. By testing the 
'functions of that class, it also tests the functions of the 
'CustomerDB shared class.
'
'Created by: Kristina Frye
'CIS 234B
'April 26, 2013

Imports libWBEBR
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports libWBEData

'''<summary>
'''This is a test class for colCustomers and CustomerDB 
'''</summary>
<TestClass()> _
Public Class colCustomersTest

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
    '''A test for Adding customer to database
    '''</summary>
    <TestMethod()> _
    Public Sub colCustomers_Add_Test()
        Dim sError As String = ""
        Dim colCustomers As New colCustomers
        colCustomers.Fill(sError) 'Fill the collection

        'Create new customer object
        Dim expected As New Customer(1, "This Little Store", "321 Main St", "Suite A", _
                                     "Portland", "OR", "93223", "555-111-2222", _
                                     "555-222-3333", "This@littlestore.com", "Cindy",
                                     Today, Today)
        colCustomers.Add(expected) 'Add object to collection
        CustomerDB.Update() 'Update database

        'Refill collection
        colCustomers.Fill(sError)

        Dim actual As Customer
        actual = colCustomers(colCustomers.Count - 1) 'Get last record (most recently added)
        'Need to do the following instead of a normal "=" because "expected" does not have a real CustomerID
        Dim bAreEqual As Boolean =
            (actual.DriverID = expected.DriverID) And
            (actual.Name = expected.Name) And
            (actual.Address1 = expected.Address1) And
            (actual.Address2 = expected.Address2) And
            (actual.City = expected.City) And
            (actual.State = expected.State) And
            (actual.Zip = expected.Zip) And
            (actual.Phone = expected.Phone) And
            (actual.Fax = expected.Fax) And
            (actual.Email = expected.Email) And
            (actual.Contact = expected.Contact) And
            (actual.LastOrderDate = expected.LastOrderDate) And
            (actual.LastCountDate = expected.LastCountDate)
        Assert.IsTrue(bAreEqual)
    End Sub

    '''<summary>
    '''A test for Changing a customer record in database
    '''</summary>
    <TestMethod()> _
    Public Sub colCustomers_Change_Test()
        Dim sError As String = ""
        Dim colCustomers As New colCustomers
        colCustomers.Fill(sError) 'Fill the collection

        'Make sure the collection isn't empty
        If colCustomers.Count = 0 Then
            Dim item As New Customer(1, "This Little Store", "321 Main St", "Suite A", _
                                     "Portland", "OR", "93223", "555-111-2222", _
                                     "555-222-3333", "This@littlestore.com", "Cindy",
                                     Today, Today)
            colCustomers.Add(item)
            CustomerDB.Update()
            colCustomers.Fill(sError)
        End If

        'Get a customer record, find a property and change it
        Dim expected As Customer = colCustomers(0)
        expected.DriverID += 1
        colCustomers.Change(expected)
        CustomerDB.Update() 'Update database

        'Refill the collection, get the object, make sure the two are the same
        colCustomers.Fill(sError)
        Dim actual As Customer = colCustomers(0)
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for Finding customer by ID number
    '''</summary>
    <TestMethod()> _
    Public Sub colCustomers_Find_Test()
        Dim sError As String = ""
        Dim colCustomers As New colCustomers
        colCustomers.Fill(sError) 'Fill the collection

        'Make sure the collection isn't empty
        If colCustomers.Count = 0 Then
            Dim item As New Customer(1, "This Little Store", "321 Main St", "Suite A", _
                                     "Portland", "OR", "93223", "555-111-2222", _
                                     "555-222-3333", "This@littlestore.com", "Cindy",
                                     Today, Today)
            colCustomers.Add(item)
            CustomerDB.Update()
            colCustomers.Fill(sError)
        End If

        'Get the customer ID of an item
        Dim expected As Customer = colCustomers(0)
        Dim ID As Integer = expected.CustomerID

        'Find a customer by ID
        Dim actual As Customer = colCustomers.Find(ID)

        'Make sure the two objects are the same
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for Removing Customer from database
    '''</summary>
    <TestMethod()> _
    Public Sub colCustomers_Remove_Test()
        Dim sError As String = ""
        Dim colCustomers As New colCustomers
        colCustomers.Fill(sError) 'Fill the collection

        'Make sure the collection isn't empty
        If colCustomers.Count = 0 Then
            Dim item As New Customer(1, "This Little Store", "321 Main St", "Suite A", _
                                     "Portland", "OR", "93223", "555-111-2222", _
                                     "555-222-3333", "This@littlestore.com", "Cindy",
                                     Today, Today)
            colCustomers.Add(item)
            CustomerDB.Update()
            colCustomers.Fill(sError)
        End If

        'Find a customer object, save the ID for later
        Dim expected As Customer = colCustomers(colCustomers.Count - 1)
        Dim iID As Integer = expected.CustomerID

        'Remove the customer and update database
        colCustomers.Remove(expected)
        CustomerDB.Update()

        colCustomers.Fill(sError) 'Refill the collection
        Assert.IsNull(colCustomers.Find(iID)) 'Make sure the ID is gone
    End Sub
End Class
