Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports libWBEBR

'''<summary>
'''This is a test class for CustomerTest and is intended
'''to contain all CustomerTest Unit Tests
'''</summary>
<TestClass()> _
Public Class CustomerTest

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
    '''A test for Customer Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub CustomerConstructorTest()
        Dim target As Customer = New Customer()
        Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub

    '''<summary>
    '''A test for Address1 with a correct address length
    '''</summary>
    <TestMethod()> _
    Public Sub Address1CorrectTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "123 Main Street"
        Dim actual As String
        target.Address1 = expected
        actual = target.Address1
        Assert.AreEqual(expected, actual)
    End Sub
    '''<summary>
    '''A test for Address1 with a incorrect address length
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Address must be less than 40 characters in length.")>
    Public Sub Address1IncorrectTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "12345678901234567890123456789012345678901"
        Dim actual As String
        target.Address1 = expected
        actual = target.Address1
    End Sub
    '''<summary>
    '''A test for Address2
    '''</summary>
    <TestMethod()> _
    Public Sub Address2CorrectTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "123 Main Street"
        Dim actual As String
        target.Address2 = expected
        actual = target.Address2
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for Address2 with a incorrect address length
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Address must be less than 40 characters in length.")>
    Public Sub Address2IncorrectTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "12345678901234567890123456789012345678901"
        Dim actual As String
        target.Address2 = expected
        actual = target.Address2
    End Sub

    '''<summary>
    '''A test for City using correct length
    '''</summary>
    <TestMethod()> _
    Public Sub CityCorrectTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "Portland"
        Dim actual As String
        target.City = expected
        actual = target.City
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for City using incorrect length
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "City must be less than 25 characters is length.")>
    Public Sub CityIncorrectTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "12345678901234567890123456"
        Dim actual As String
        target.City = expected
        actual = target.City
    End Sub
    '''<summary>
    '''A test for Email with correct format
    '''</summary>
    <TestMethod()> _
    Public Sub EmailCorrectTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "test@test.com"
        Dim actual As String
        target.Email = expected
        actual = target.Email
        Assert.AreEqual(expected, actual)
    End Sub
    '''<summary>
    '''A test for Email with incorrect with no .com
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Email should use the format: 'name@domain.com' or similar")>
    Public Sub EmailIncorrectNoEndTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "test@test"
        Dim actual As String
        target.Email = expected
        actual = target.Email
    End Sub

    '''<summary>
    '''A test for Email with incorrect with no name
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Email should use the format: 'name@domain.com' or similar")>
    Public Sub EmailIncorrectNoNameTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "@test.com"
        Dim actual As String
        target.Email = expected
        actual = target.Email
    End Sub

    '''<summary>
    '''A test for Email with incorrect with no @
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Email should use the format: 'name@domain.com' or similar")>
    Public Sub EmailIncorrectNoAtTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "test.test.com"
        Dim actual As String
        target.Email = expected
        actual = target.Email
    End Sub
    '''<summary>
    '''A test for Fax using the format ###-###-####
    '''</summary>
    <TestMethod()> _
    Public Sub FaxCorrectNoParenthesisTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "503-111-2222"
        Dim actual As String
        target.Fax = expected
        actual = target.Fax
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for Fax using the format (###) ###-####
    '''</summary>
    <TestMethod()> _
    Public Sub FaxCorrectParenthesisTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "(503) 111-2222"
        Dim actual As String
        target.Fax = expected
        actual = target.Fax
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for Fax using the format (###)###-####
    '''</summary>
    <TestMethod()> _
    Public Sub FaxCorrectParenthesisNoSpaceTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "(503)111-2222"
        Dim actual As String
        target.Fax = expected
        actual = target.Fax
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for Fax using the format ##########
    '''</summary>
    <TestMethod()> _
    Public Sub FaxCorrectNoSymbolsTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "5031112222"
        Dim actual As String
        target.Fax = expected
        actual = target.Fax
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for Fax using an incorrect number of numbers
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Fax should be in the format '(###) ###-####' or '###-###-####'")>
    Public Sub FaxIncorrectTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "503111222"
        Dim actual As String
        target.Fax = expected
        actual = target.Fax
    End Sub

    '''<summary>
    '''A test for Name using 25 characters (max length)
    '''</summary>
    <TestMethod()> _
    Public Sub NameTest25Chars()
        Dim target As Customer = New Customer()
        Dim expected As String = "testname90123456789012345"
        Dim actual As String
        target.Name = expected
        actual = target.Name
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for Name using 26 characters (max length+1)
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Name must be no more than 25 characters in length.")>
    Public Sub NameTest26Chars()
        Dim target As Customer = New Customer()
        Dim expected As String = "testname901234567890123456"
        Dim actual As String
        target.Name = expected
        actual = target.Name
    End Sub

    '''<summary>
    '''A test for Phone using the format ###-###-####
    '''</summary>
    <TestMethod()> _
    Public Sub PhoneCorrectNoParenthesisTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "503-111-2222"
        Dim actual As String
        target.Phone = expected
        actual = target.Phone
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for Phone using the format (###) ###-####
    '''</summary>
    <TestMethod()> _
    Public Sub PhoneCorrectParenthesisTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "(503) 111-2222"
        Dim actual As String
        target.Phone = expected
        actual = target.Phone
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for Phone using the format (###)###-####
    '''</summary>
    <TestMethod()> _
    Public Sub PhoneCorrectParenthesisNoSpaceTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "(503)111-2222"
        Dim actual As String
        target.Phone = expected
        actual = target.Phone
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for Phone using the format ##########
    '''</summary>
    <TestMethod()> _
    Public Sub PhoneCorrectNoSymbolsTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "5031112222"
        Dim actual As String
        target.Phone = expected
        actual = target.Phone
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for Phone using an incorrect number of numbers
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Phone should be in the format '(###) ###-####' or '###-###-####'")>
    Public Sub PhoneIncorrectTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "503111222"
        Dim actual As String
        target.Phone = expected
        actual = target.Phone
    End Sub

    '''<summary>
    '''A test for State using 2 correct letters
    '''</summary>
    <TestMethod()> _
    Public Sub StateCorrectTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "OR"
        Dim actual As String
        target.State = expected
        actual = target.State
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for State using 3 incorrect letters
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Please use a correct state abbreviation.")>
    Public Sub StateIncorrectTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "ORG"
        Dim actual As String
        target.State = expected
        actual = target.State
    End Sub

    '''<summary>
    '''A test for Zip using correct 5 digit format
    '''</summary>
    <TestMethod()> _
    Public Sub ZipTest5DigitFormat()
        Dim target As Customer = New Customer()
        Dim expected As String = "12345"
        Dim actual As String
        target.Zip = expected
        actual = target.Zip
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for Zip using correct 9 digit format
    '''</summary>
    <TestMethod()> _
    Public Sub ZipTest9DigitFormat()
        Dim target As Customer = New Customer()
        Dim expected As String = "12345-6789"
        Dim actual As String
        target.Zip = expected
        actual = target.Zip
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for Zip using incorrect 9 digit format
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "The Zip needs to be in the format '#####' or '#####-####'")>
    Public Sub ZipTestIncorrect9DigitFormat()
        Dim target As Customer = New Customer()
        Dim expected As String = "123456789"
        Dim actual As String
        target.Zip = expected
        actual = target.Zip
    End Sub

    '''<summary>
    '''A test for Zip using incorrect format with 6 digits
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "The Zip needs to be in the format '#####' or '#####-####'")>
    Public Sub ZipTestIncorrect6DigitFormat()
        Dim target As Customer = New Customer()
        Dim expected As String = "123456"
        Dim actual As String
        target.Zip = expected
        actual = target.Zip
    End Sub
End Class
