Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports libWBEBR
'DriverTest class
'Created by: Kristina Frye
'April 22, 2013
'CIS 234B

'''<summary>
'''This is a test class for DriverTest and is intended
'''to contain all DriverTest Unit Tests
'''</summary>
<TestClass()> _
Public Class DriverTest

    '''<summary>
    '''A test for good Name
    '''</summary>
    <TestMethod()> _
    Public Sub Driver_NamePass_Test()
        Dim target As Driver = New Driver()
        Dim expected As String = "Good Name"
        Dim actual As String
        target.Name = expected
        actual = target.Name
        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for Name that is too short
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Driver should fail because name is too short")>
    Public Sub Driver_NameFailTooShort_Test()
        Dim target As Driver = New Driver()
        Dim expected As String = "12"
        target.Name = expected
    End Sub

    '''<summary>
    '''Name test using an empty string
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Driver should fail because name is empty")>
    Public Sub Driver_NameFailEmptyFail_Test()
        Dim target As Driver = New Driver()
        Dim expected As String = ""
        target.Name = expected
    End Sub

    '''<summary>
    '''A test for Name that is too long
    '''</summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.Exception), "Driver should fail because name is too long")>
    Public Sub Driver_NameFailTooLong_Test()
        Dim target As Driver = New Driver()
        Dim expected As String = "1234567890123456789012345678901"
        target.Name = expected
    End Sub
End Class
