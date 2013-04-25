Imports System.Resources

Imports System.Globalization

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports libWBEData.My.Resources



'''<summary>
'''This is a test class for ResourcesTest and is intended
'''to contain all ResourcesTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ResourcesTest


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
    '''A test for Culture
    '''</summary>
    <TestMethod()> _
    Public Sub CultureTest()
        Dim expected As CultureInfo = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As CultureInfo
        Resources.Culture = expected
        actual = Resources.Culture
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for ResourceManager
    '''</summary>
    <TestMethod()> _
    Public Sub ResourceManagerTest()
        Dim actual As ResourceManager
        actual = Resources.ResourceManager
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub
End Class
