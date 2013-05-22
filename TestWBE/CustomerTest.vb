Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports libWBEBR
'CustomerTest class
'Created by: Kristina Frye
'April 22, 2013
'CIS 234B

'''<summary>
'''This is a test class for CustomerTest and is intended
'''to contain all Customer Unit Tests
'''</summary>
<TestClass()> _
Public Class CustomerTest

    '''<summary>
    '''A test for Address1 with a correct address length
    '''</summary>
    <TestMethod()> _
    Public Sub Customer_Address1Correct_Test()
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
    Public Sub Customer_Address1EmptyPass_Test()
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
    Public Sub Customer_Address1Fail31Chars_Test()
        Dim target As Customer = New Customer()
        Dim expected As String = "1234567890123456789012345678901"
        target.Address1 = expected
    End Sub

    '''<summary>
    '''A test for Address1 with a incorrect address length (min - 1)
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "This address should be too short.")>
    Public Sub Customer_Address1Fail4Chars_Test()
        Dim target As Customer = New Customer()
        Dim expected As String = "1234"
        target.Address1 = expected
    End Sub
    '''<summary>
    '''A test for Address2 with correct length
    '''</summary>
    <TestMethod()> _
    Public Sub Customer_Address2Correct_Test()
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
    Public Sub Customer_Address2EmptyPass_Test()
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
    Public Sub Customer_Address2Fail31Chars_Test()
        Dim target As Customer = New Customer()
        Dim expected As String = "1234567890123456789012345678901"
        target.Address2 = expected
    End Sub

    '''<summary>
    '''A test for Address2 with a incorrect address length (min - 1)
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "This address should be too short.")>
    Public Sub Customer_Address2Fail4Chars_Test()
        Dim target As Customer = New Customer()
        Dim expected As String = "1234"
        target.Address2 = expected
    End Sub
    '''<summary>
    '''A test for City using correct length
    '''</summary>
    <TestMethod()> _
    Public Sub Customer_CityCorrect_Test()
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
    Public Sub Customer_CityEmptyPass_Test()
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
    Public Sub Customer_CityFail31Chars_Test()
        Dim target As Customer = New Customer()
        Dim expected As String = "1234567890123456789012345678901"
        target.City = expected
    End Sub

    '''<summary>
    '''A test for City using incorrect length (min - 1)
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "This city name should be too short.")>
    Public Sub Customer_CityFail4Chars_Test()
        Dim target As Customer = New Customer()
        Dim expected As String = "1234"
        target.City = expected
    End Sub

    '''<summary>
    '''A test for Contact using correct length
    '''</summary>
    <TestMethod()> _
    Public Sub Customer_ContactCorrect_Test()
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
    Public Sub Customer_ContactEmptyPass_Test()
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
    Public Sub Customer_ContactFail31Chars_Test()
        Dim target As Customer = New Customer()
        Dim expected As String = "1234567890123456789012345678901"
        target.Contact = expected
    End Sub

    '''<summary>
    '''A test for Contact using incorrect length (min - 1)
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "This contact should be too short.")>
    Public Sub Customer_ContactFail4Chars_Test()
        Dim target As Customer = New Customer()
        Dim expected As String = "1234"
        target.Contact = expected
    End Sub
    '''<summary>
    '''A test for Email with correct format
    '''</summary>
    <TestMethod()> _
    Public Sub Customer_EmailCorrect_Test()
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
    Public Sub Customer_EmailEmptyPass_Test()
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
    Public Sub Customer_EmailIncorrectNoEnd_Test()
        Dim target As Customer = New Customer()
        Dim expected As String = "test@test"
        target.Email = expected
    End Sub

    '''<summary>
    '''A test for Email with incorrect with no name
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Email should fail because it has no name before the @")>
    Public Sub Customer_EmailIncorrectNoName_Test()
        Dim target As Customer = New Customer()
        Dim expected As String = "@test.com"
        target.Email = expected
    End Sub

    '''<summary>
    '''A test for Email with incorrect with no @
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Email should fail because it has no @")>
    Public Sub Customer_EmailIncorrectNoAt_Test()
        Dim target As Customer = New Customer()
        Dim expected As String = "test.test.com"
        target.Email = expected
    End Sub
    '''<summary>
    '''A test for Fax using the format ###-###-####
    '''</summary>
    <TestMethod()> _
    Public Sub Customer_FaxCorrectDashes_Test()
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
    Public Sub Customer_FaxCorrectNoSymbols_Test()
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
    Public Sub Customer_FaxEmptyPass_Test()
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
    Public Sub Customer_FaxFail9Chars_Test()
        Dim target As Customer = New Customer()
        Dim expected As String = "503111222"
        target.Fax = expected
    End Sub

    '''<summary>
    '''A test for Fax using an incorrect number of numbers
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Fax should fail because it has too many numbers.")>
    Public Sub Customer_FaxFail11Chars_Test()
        Dim target As Customer = New Customer()
        Dim expected As String = "50311122223"
        target.Fax = expected
    End Sub

    '''<summary>
    '''A test for Fax using an incorrect number of numbers
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Fax should fail because it has too many numbers.")>
    Public Sub Customer_FaxFail11NumsDashes_Test()
        Dim target As Customer = New Customer()
        Dim expected As String = "503-111-22223"
        target.Fax = expected
    End Sub

    '''<summary>
    '''A test for LastCountDate using good date
    '''</summary>
    <TestMethod()> _
    Public Sub Customer_LastCountDateCorrect_Test()
        Dim target As Customer = New Customer()
        target.IsInactive = True
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
    Public Sub Customer_LastCountDateMaxFail_Test()
        Dim target As Customer = New Customer()
        target.IsInactive = True
        Dim expected As Date = DateAdd(DateInterval.Day, 4, Now)
        target.LastCountDate = expected
    End Sub

    '''<summary>
    '''A test for LastCountDate using bad date (min - 1)
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Date should fail because it is before min date.")>
    Public Sub Customer_LastCountDateMinFail_Test()
        Dim target As Customer = New Customer()
        target.IsInactive = True
        Dim expected As Date = DateAdd(DateInterval.Day, -8, Now)
        target.LastCountDate = expected
    End Sub

    '''<summary>
    '''A test for LastCountDate using inactive customer that should fail for an active customer
    '''</summary>
    <TestMethod()> _
    Public Sub Customer_LastCountDateInactiveCustomer_Test()
        Dim target As Customer = New Customer()
        target.IsInactive = False
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
    Public Sub Customer_LastOrderDateCorrect_Test()
        Dim target As Customer = New Customer()
        target.IsInactive = True
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
    Public Sub Customer_LastOrderDateMaxFail_Test()
        Dim target As Customer = New Customer()
        target.IsInactive = True
        Dim expected As Date = DateAdd(DateInterval.Day, 4, Now)
        target.LastOrderDate = expected
    End Sub

    '''<summary>
    '''A test for LastOrderDate using bad date (min - 1)
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Date should fail because before min date.")>
    Public Sub Customer_LastOrderDateMinFail_Test()
        Dim target As Customer = New Customer()
        target.IsInactive = True
        Dim expected As Date = DateAdd(DateInterval.Day, -8, Now)
        target.LastOrderDate = expected
    End Sub

    '''<summary>
    '''A test for LastOrderDate using inactive customer that should fail for an active customer
    '''</summary>
    <TestMethod()> _
    Public Sub Customer_LastOrderDateInactiveCustomer_Test()
        Dim target As Customer = New Customer()
        target.IsInactive = False
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
    Public Sub Customer_NameTest25Chars_Test()
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
    Public Sub Customer_NameEmptyPass_Test()
        Dim target As Customer = New Customer()
        Dim expected As String = ""
        target.Name = expected
    End Sub

    '''<summary>
    '''A test for Name using 31 characters (max length+1)
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Name should fail because it is too long.")>
    Public Sub Customer_NameTest31Chars_Test()
        Dim target As Customer = New Customer()
        Dim expected As String = "testname90123456789012345678901"
        target.Name = expected
    End Sub

    '''<summary>
    '''A test for Name using 2 characters (min length-1)
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Name should fail because it is too short.")>
    Public Sub Customer_NameTestFail2Chars_Test()
        Dim target As Customer = New Customer()
        Dim expected As String = "12"
        target.Name = expected
    End Sub

    '''<summary>
    '''A test for Phone using the format ###-###-####
    '''</summary>
    <TestMethod()> _
    Public Sub Customer_PhoneCorrectDashes_Test()
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
    Public Sub Customer_PhoneCorrectNoDashes_Test()
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
    Public Sub Customer_PhoneEmptyPass_Test()
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
    Public Sub Customer_PhoneIncorrect_Test()
        Dim target As Customer = New Customer()
        Dim expected As String = "503111222"
        target.Phone = expected
    End Sub

    '''<summary>
    '''A test for Phone using an incorrect number of numbers
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Phone should fail because it has too many digits")>
    Public Sub Customer_PhoneFail11Chars_Test()
        Dim target As Customer = New Customer()
        Dim expected As String = "50311122223"
        target.Phone = expected
    End Sub

    '''<summary>
    '''A test for State using 2 correct letters
    '''</summary>
    <TestMethod()> _
    Public Sub Customer_StateCorrect_Test()
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
    Public Sub Customer_StateEmptyPass_Test()
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
    Public Sub Customer_StateFailID_Test()
        Dim target As Customer = New Customer()
        Dim expected As String = "ID"
        target.State = expected
    End Sub

    '''<summary>
    '''A test for Zip using correct 5 digit format
    '''</summary>
    <TestMethod()> _
    Public Sub Customer_ZipTest5DigitFormat_Test()
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
    Public Sub Customer_ZipTest9DigitFormat_Test()
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
    Public Sub Customer_ZipTestEmptyPass_Test()
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
    Public Sub Customer_ZipTestIncorrect9DigitFormat_Test()
        Dim target As Customer = New Customer()
        Dim expected As String = "123456789"
        target.Zip = expected
    End Sub

    '''<summary>
    '''A test for Zip using incorrect format with 6 digits
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Zip should fail because it has too many digits")>
    Public Sub Customer_ZipTestIncorrect6DigitFormat_Test()
        Dim target As Customer = New Customer()
        Dim expected As String = "123456"
        Dim actual As String
        target.Zip = expected
        actual = target.Zip
    End Sub

    '''<summary>
    '''A test for Zip using incorrect format with 10 digits
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Zip should fail because it has too many digits")>
    Public Sub Customer_ZipTestIncorrect10DigitFormat_Test()
        Dim target As Customer = New Customer()
        Dim expected As String = "12345-69890"
        Dim actual As String
        target.Zip = expected
        actual = target.Zip
    End Sub
End Class
