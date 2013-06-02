Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports libWBEData



'''<summary>
'''This is a test class for WBEDataTest and is intended
'''to contain all WBEDataTest Unit Tests
'''</summary>
<TestClass()> _
Public Class WBEDataTest


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
    '''A test for WBEData Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub WBEDataConstructorTest()
        Dim target As WBEData = New WBEData()
        CustomerDB.SetupAdapter()

        Dim colCustomers As New colCustomers
        Dim sError As String = ""
        colCustomers.Fill(sError)

        CustStockDB.CustomerID = 1
        CustStockDB.SetupAdapter()

        Dim colStock As New colCustStock

        colStock.Fill(sError)

        'Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub
End Class
