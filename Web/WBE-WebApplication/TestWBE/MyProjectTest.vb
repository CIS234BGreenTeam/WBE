Imports Microsoft.VisualBasic.ApplicationServices

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports libWBEBR.My



'''<summary>
'''This is a test class for MyProjectTest and is intended
'''to contain all MyProjectTest Unit Tests
'''</summary>
<TestClass()> _
Public Class MyProjectTest


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
    '''A test for Application
    '''</summary>
    <TestMethod()> _
    Public Sub ApplicationTest()
        Dim actual As MyApplication
        actual = MyProject.Application
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for Computer
    '''</summary>
    <TestMethod()> _
    Public Sub ComputerTest()
        Dim actual As MyComputer
        actual = MyProject.Computer
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for User
    '''</summary>
    <TestMethod()> _
    Public Sub UserTest()
        Dim actual As User
        actual = MyProject.User
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for WebServices
    '''</summary>
    <TestMethod()> _
    Public Sub WebServicesTest()
        Dim actual As MyProject.MyWebServices
        actual = MyProject.WebServices
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub
End Class
