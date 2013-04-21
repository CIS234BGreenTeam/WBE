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
    '''A test for Address1 with empty address length
    '''</summary>
    <TestMethod()> _
    Public Sub Address1EmptyPassTest()
        Dim target As Customer = New Customer()
        Dim expected As String = ""
        Dim actual As String
        target.Address1 = expected
        actual = target.Address1
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for Address1 with a incorrect address length (max + 1)
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "This address should be too long.")>
    Public Sub Address1Fail31CharsTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "1234567890123456789012345678901"
        target.Address1 = expected
    End Sub

    '''<summary>
    '''A test for Address1 with a incorrect address length (min - 1)
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "This address should be too short.")>
    Public Sub Address1Fail4CharsTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "1234"
        target.Address1 = expected
    End Sub
    '''<summary>
    '''A test for Address2 with correct length
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
    '''A test for Address2 with empty length
    '''</summary>
    <TestMethod()> _
    Public Sub Address2EmptyPassTest()
        Dim target As Customer = New Customer()
        Dim expected As String = ""
        Dim actual As String
        target.Address2 = expected
        actual = target.Address2
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for Address2 with a incorrect address length (max + 1)
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "This address should be too long.")>
    Public Sub Address2Fail31CharsTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "1234567890123456789012345678901"
        target.Address2 = expected
    End Sub

    '''<summary>
    '''A test for Address2 with a incorrect address length (min - 1)
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "This address should be too short.")>
    Public Sub Address2Fail4CharsTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "1234"
        target.Address2 = expected
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
    '''A test for City using empty length
    '''</summary>
    <TestMethod()> _
    Public Sub CityEmptyPassTest()
        Dim target As Customer = New Customer()
        Dim expected As String = ""
        Dim actual As String
        target.City = expected
        actual = target.City
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for City using incorrect length (max + 1)
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "This city name should be too long.")>
    Public Sub CityFail31CharsTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "1234567890123456789012345678901"
        target.City = expected
    End Sub

    '''<summary>
    '''A test for City using incorrect length (min - 1)
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "This city name should be too short.")>
    Public Sub CityFail4CharsTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "1234"
        target.City = expected
    End Sub

    '''<summary>
    '''A test for Contact using correct length
    '''</summary>
    <TestMethod()> _
    Public Sub ContactCorrectTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "12345"
        Dim actual As String
        target.Contact = expected
        actual = target.Contact
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for Contact using empty string
    '''</summary>
    <TestMethod()> _
    Public Sub ContactEmptyPassTest()
        Dim target As Customer = New Customer()
        Dim expected As String = ""
        Dim actual As String
        target.Contact = expected
        actual = target.Contact
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for Contact using incorrect length (max + 1)
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "This contact should be too long.")>
    Public Sub ContactFail31CharsTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "1234567890123456789012345678901"
        target.Contact = expected
    End Sub

    '''<summary>
    '''A test for Contact using incorrect length (min - 1)
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "This contact should be too short.")>
    Public Sub ContactFail4CharsTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "1234"
        target.Contact = expected
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
    '''A test for Email with empty string
    '''</summary>
    <TestMethod()> _
    Public Sub EmailEmptyPassTest()
        Dim target As Customer = New Customer()
        Dim expected As String = ""
        Dim actual As String
        target.Email = expected
        actual = target.Email
        Assert.AreEqual(expected, actual)
    End Sub
    '''<summary>
    '''A test for Email with incorrect with no .com
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Email should fail beause it has no .com or equivalent")>
    Public Sub EmailIncorrectNoEndTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "test@test"
        target.Email = expected
    End Sub

    '''<summary>
    '''A test for Email with incorrect with no name
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Email should fail because it has no name before the @")>
    Public Sub EmailIncorrectNoNameTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "@test.com"
        target.Email = expected
    End Sub

    '''<summary>
    '''A test for Email with incorrect with no @
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Email should fail because it has no @")>
    Public Sub EmailIncorrectNoAtTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "test.test.com"
        target.Email = expected
    End Sub
    '''<summary>
    '''A test for Fax using the format ###-###-####
    '''</summary>
    <TestMethod()> _
    Public Sub FaxCorrectDashesTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "503-111-2222"
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
    '''A test for Fax using an empty string
    '''</summary>
    <TestMethod()> _
    Public Sub FaxEmptyPassTest()
        Dim target As Customer = New Customer()
        Dim expected As String = ""
        Dim actual As String
        target.Fax = expected
        actual = target.Fax
        Assert.AreEqual(expected, actual)
    End Sub
    '''<summary>
    '''A test for Fax using an incorrect number of numbers
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Fax should fail because it is missing a number")>
    Public Sub FaxFail9CharsTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "503111222"
        target.Fax = expected
    End Sub

    '''<summary>
    '''A test for Fax using an incorrect number of numbers
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Fax should fail because it has too many numbers.")>
    Public Sub FaxFail11CharsTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "50311122223"
        target.Fax = expected
    End Sub

    '''<summary>
    '''A test for Fax using an incorrect number of numbers
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Fax should fail because it has too many numbers.")>
    Public Sub FaxFail11NumsDashesTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "503-111-22223"
        target.Fax = expected
    End Sub

    '''<summary>
    '''A test for LastCountDate using good date
    '''</summary>
    <TestMethod()> _
    Public Sub LastCountDateCorrectTest()
        Dim target As Customer = New Customer()
        target.IsActive = True
        Dim expected As Date = Now
        Dim actual As Date
        target.LastCountDate = expected
        actual = target.LastCountDate
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for LastCountDate using bad date (max + 1)
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Date should fail because it is after max date")>
    Public Sub LastCountDateMaxFailTest()
        Dim target As Customer = New Customer()
        target.IsActive = True
        Dim expected As Date = DateAdd(DateInterval.Day, 4, Now)
        target.LastCountDate = expected
    End Sub

    '''<summary>
    '''A test for LastCountDate using bad date (min - 1)
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Date should fail because it is before min date.")>
    Public Sub LastCountDateMinFailTest()
        Dim target As Customer = New Customer()
        target.IsActive = True
        Dim expected As Date = DateAdd(DateInterval.Day, -8, Now)
        target.LastCountDate = expected
    End Sub

    '''<summary>
    '''A test for LastCountDate using inactive customer that should fail for an active customer
    '''</summary>
    <TestMethod()> _
    Public Sub LastCountDateInactiveCustomerTest()
        Dim target As Customer = New Customer()
        target.IsActive = False
        Dim expected As Date = DateAdd(DateInterval.Day, 4, Now)
        Dim actual As Date
        target.LastCountDate = expected
        actual = target.LastCountDate
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for LastOrderDate using good date
    '''</summary>
    <TestMethod()> _
    Public Sub LastOrderDateCorrectTest()
        Dim target As Customer = New Customer()
        target.IsActive = True
        Dim expected As Date = Now
        Dim actual As Date
        target.LastOrderDate = expected
        actual = target.LastOrderDate
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for LastOrderDate using bad date (max + 1)
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Date should fail because after max date")>
    Public Sub LastOrderDateMaxFailTest()
        Dim target As Customer = New Customer()
        target.IsActive = True
        Dim expected As Date = DateAdd(DateInterval.Day, 4, Now)
        target.LastOrderDate = expected
    End Sub

    '''<summary>
    '''A test for LastOrderDate using bad date (min - 1)
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Date should fail because before min date.")>
    Public Sub LastOrderDateMinFailTest()
        Dim target As Customer = New Customer()
        target.IsActive = True
        Dim expected As Date = DateAdd(DateInterval.Day, -8, Now)
        target.LastOrderDate = expected
    End Sub

    '''<summary>
    '''A test for LastOrderDate using inactive customer that should fail for an active customer
    '''</summary>
    <TestMethod()> _
    Public Sub LastOrderDateInactiveCustomerTest()
        Dim target As Customer = New Customer()
        target.IsActive = False
        Dim expected As Date = DateAdd(DateInterval.Day, 4, Now)
        Dim actual As Date
        target.LastOrderDate = expected
        actual = target.LastOrderDate
        Assert.AreEqual(expected, actual)
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
    '''A test for Name using the empty string
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Name should fail because it is empty.")>
    Public Sub NameEmptyPassTest()
        Dim target As Customer = New Customer()
        Dim expected As String = ""
        target.Name = expected
    End Sub

    '''<summary>
    '''A test for Name using 31 characters (max length+1)
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Name should fail because it is too long.")>
    Public Sub NameTest31Chars()
        Dim target As Customer = New Customer()
        Dim expected As String = "testname90123456789012345678901"
        target.Name = expected
    End Sub

    '''<summary>
    '''A test for Name using 2 characters (min length-1)
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Name should fail because it is too short.")>
    Public Sub NameTestFail2Chars()
        Dim target As Customer = New Customer()
        Dim expected As String = "12"
        target.Name = expected
    End Sub

    '''<summary>
    '''A test for Phone using the format ###-###-####
    '''</summary>
    <TestMethod()> _
    Public Sub PhoneCorrectDashesTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "503-111-2222"
        Dim actual As String
        target.Phone = expected
        actual = target.Phone
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for Phone using the format ##########
    '''</summary>
    <TestMethod()> _
    Public Sub PhoneCorrectNoDashesTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "5031112222"
        Dim actual As String
        target.Phone = expected
        actual = target.Phone
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for Phone using an empty string
    '''</summary>
    <TestMethod()> _
    Public Sub PhoneEmptyPassTest()
        Dim target As Customer = New Customer()
        Dim expected As String = ""
        Dim actual As String
        target.Phone = expected
        actual = target.Phone
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for Phone using an incorrect number of numbers
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Phone should fail because it is missing a digit")>
    Public Sub PhoneIncorrectTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "503111222"
        target.Phone = expected
    End Sub

    '''<summary>
    '''A test for Phone using an incorrect number of numbers
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Phone should fail because it has too many digits")>
    Public Sub PhoneFail11CharsTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "50311122223"
        target.Phone = expected
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
    '''A test for State using empty string
    '''</summary>
    <TestMethod()> _
    Public Sub StateEmptyPassTest()
        Dim target As Customer = New Customer()
        Dim expected As String = ""
        Dim actual As String
        target.State = expected
        actual = target.State
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for State using Idaho
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "State should fail because it is not WA or OR")>
    Public Sub StateFailIDTest()
        Dim target As Customer = New Customer()
        Dim expected As String = "ID"
        target.State = expected
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
    '''A test for Zip using empty string
    '''</summary>
    <TestMethod()> _
    Public Sub ZipTestEmptyPassTest()
        Dim target As Customer = New Customer()
        Dim expected As String = ""
        Dim actual As String
        target.Zip = expected
        actual = target.Zip
        Assert.AreEqual(expected, actual)
    End Sub
    '''<summary>
    '''A test for Zip using incorrect 9 digit format
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Zip should fail because it is missing a dash")>
    Public Sub ZipTestIncorrect9DigitFormat()
        Dim target As Customer = New Customer()
        Dim expected As String = "123456789"
        target.Zip = expected
    End Sub

    '''<summary>
    '''A test for Zip using incorrect format with 6 digits
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Zip should fail because it has too many digits")>
    Public Sub ZipTestIncorrect6DigitFormat()
        Dim target As Customer = New Customer()
        Dim expected As String = "123456"
        Dim actual As String
        target.Zip = expected
        actual = target.Zip
    End Sub
End Class
