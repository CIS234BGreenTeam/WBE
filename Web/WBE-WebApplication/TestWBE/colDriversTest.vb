'This is a class for testing the colDrivers class. By testing the 
'functions of that class, it also tests the functions of the 
'DriverDB shared class.
'
'Created by: Kristina Frye
'CIS 234B
'April 26, 2013

Imports libWBEBR
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports libWBEData

'''<summary>
'''This is a test class for colDrivers and DriverDB
'''</summary>
<TestClass()> _
Public Class colDriversTest
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
        DriverDB.SetupAdapter()
    End Sub

#End Region

    '''<summary>
    '''A test for Adding drivers to the database
    '''</summary>
    <TestMethod()> _
    Public Sub colDrivers_Add_Test()
        'Fill the driver collection
        Dim sError As String = ""
        Dim colDrivers As New colDrivers
        colDrivers.Fill(sError)

        'Add new driver object to collection and update database
        Dim expected As New Driver("Mike")
        colDrivers.Add(expected)
        DriverDB.Update()

        'Refill driver collection
        colDrivers.Fill(sError)
        Dim actual As Driver
        actual = colDrivers(colDrivers.Count - 1)

        'This type of equals is done because expected.DriverID is not the realID
        Dim bAreEqual As Boolean = (actual.Name = expected.Name)
        Assert.IsTrue(bAreEqual)
    End Sub

    '''<summary>
    '''A test for Changing an existing driver record
    '''</summary>
    <TestMethod()> _
    Public Sub colDrivers_Change_Test()
        Dim sError As String = ""
        Dim colDrivers As New colDrivers
        colDrivers.Fill(sError)

        'Make sure there is a driver in the database 
        If colDrivers.Count = 0 Then
            Dim item As New Driver("Joe")
            colDrivers.Add(item)
            DriverDB.Update()
            colDrivers.Fill(sError)
        End If

        Dim expected As Driver = colDrivers(0)

        'Make sure that we are changing the driver name
        If expected.Name <> "Drew" Then
            expected.Name = "Drew"
        Else
            expected.Name = "Joe"
        End If

        'Change the collection and update the database
        colDrivers.Change(expected)
        DriverDB.Update()

        'Refill the collection and make sure the change worked
        colDrivers.Fill(sError)
        Dim actual As Driver = colDrivers(0)
        Dim bAreEqual As Boolean = (actual.Name = expected.Name)
        Assert.IsTrue(bAreEqual)
    End Sub

    '''<summary>
    '''A test for Finding driver by DriverID in colDrivers
    '''</summary>
    <TestMethod()> _
    Public Sub colDrivers_Find_Test()
        Dim sError As String = ""
        Dim colDrivers As New colDrivers
        colDrivers.Fill(sError) 'Fill the driver collection

        'Make sure there is a driver in the collection to find
        If colDrivers.Count = 0 Then
            Dim item As New Driver("Joe")
            colDrivers.Add(item)
            DriverDB.Update()
            colDrivers.Fill(sError)
        End If

        'Get the ID from an item in the collection
        Dim expected As Driver = colDrivers(0)
        Dim iID As Integer = expected.DriverID

        'Find the object by ID
        Dim actual As Driver = colDrivers.Find(iID)

        'Make sure the two object are the same
        Assert.AreEqual(actual, expected)
    End Sub

    '''<summary>
    '''A test for Removing driver from database
    '''</summary>
    <TestMethod()> _
    Public Sub coDrivers_Remove_Test()
        Dim sError As String = ""
        Dim colDrivers As New colDrivers
        colDrivers.Fill(sError) 'Fill the driver collection

        'Make sure there is a driver in the collection to delete
        If colDrivers.Count = 0 Then
            Dim item As New Driver("Joe")
            colDrivers.Add(item)
            DriverDB.Update()
            colDrivers.Fill(sError)
        End If

        'Get the driver ID for reference later
        Dim expected As Driver = colDrivers(colDrivers.Count - 1)
        Dim iID As Integer = expected.DriverID

        'Remove the driver and update database
        colDrivers.Remove(expected)
        DriverDB.Update()

        'Refill the collection and make sure the DriverID is not found
        colDrivers.Fill(sError)
        Assert.IsNull(colDrivers.Find(iID))
    End Sub
End Class
