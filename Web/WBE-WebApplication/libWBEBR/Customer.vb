Imports System.Text.RegularExpressions
'Customer class
'Created by: Kristina Frye
'April 22, 2013
'CIS 234B

Public Class Customer
    ''' <summary>
    ''' Shows whether the customer is active or not
    ''' </summary>
    ''' <value></value>
    ''' <returns>True if active</returns>
    ''' <remarks></remarks>
    Public Property IsActive As Boolean

    ''' <summary>
    ''' Identifier of the driver attached to the customer
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DriverID As Integer

    ''' <summary>
    ''' Unique identifier of the customer in the database
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CustomerID As Integer
    Const c_MinLength = 5
    Const c_MaxLength = 30

    ''' <summary>
    ''' Constructor with data
    ''' </summary>
    ''' <param name="objDriverID">DriverID</param>
    ''' <param name="objName">Name of customer</param>
    ''' <param name="objAddress1">Address of customer</param>
    ''' <param name="objAddress2">Second line of address</param>
    ''' <param name="objCity">City of customer</param>
    ''' <param name="objState">State of customer</param>
    ''' <param name="objZip">Zip of customer</param>
    ''' <param name="objPhone">Phone of customer</param>
    ''' <param name="objFax">Fax of customer</param>
    ''' <param name="objEmail">Email of customer</param>
    ''' <param name="objContact">Contact person for customer</param>
    ''' <param name="objOrderDate">Last order date of customer</param>
    ''' <param name="objCountDate">Last time inventory was input</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal objDriverID As Integer,
                   ByVal objName As String,
                   ByVal objAddress1 As String,
                   ByVal objAddress2 As String,
                   ByVal objCity As String,
                   ByVal objState As String,
                   ByVal objZip As String,
                   ByVal objPhone As String,
                   ByVal objFax As String,
                   ByVal objEmail As String,
                   ByVal objContact As String,
                   ByVal objOrderDate As Date,
                   ByVal objCountDate As Date)
        Name = objName
        Address1 = objAddress1
        Address2 = objAddress2
        City = objCity
        State = objState
        Zip = objZip
        Phone = objPhone
        Fax = objFax
        Email = objEmail
        Contact = objContact
        LastOrderDate = objOrderDate
        LastCountDate = objCountDate
    End Sub

    ''' <summary>
    ''' Default constructor
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

    End Sub

    Private _Name As String
    ''' <summary>
    ''' Name of customer
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            If value.Length < c_MinLength Or value.Length > c_MaxLength Then
                Throw New Exception(NameError)
            Else
                _Name = value
            End If
        End Set
    End Property
    Private _NameError As String = String.Format("Name is a required field between {0} and {1} characters in length.",
                                                 c_MinLength, c_MaxLength)
    ''' <summary>
    ''' Error message when customer name fails validations
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property NameError() As String
        Get
            Return _NameError
        End Get
    End Property

    Private _Address1 As String
    ''' <summary>
    ''' Address of customer
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Address1() As String
        Get
            Return _Address1
        End Get
        Set(ByVal value As String)
            If (value.Length < c_MinLength Or value.Length > c_MaxLength) And value <> "" Then
                Throw New Exception(AddressError)
            Else
                _Address1 = value
            End If
            _Address1 = value
        End Set
    End Property

    Private _Address2 As String
    ''' <summary>
    ''' Second line of address
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Address2() As String
        Get
            Return _Address2
        End Get
        Set(ByVal value As String)
            If (value.Length < c_MinLength Or value.Length > c_MaxLength) And value <> "" Then
                Throw New Exception(AddressError)
            Else
                _Address2 = value
            End If
        End Set
    End Property
    Private _AddressError As String = String.Format("Address must be between {0} and {1} characters in length.",
                                                    c_MinLength, c_MaxLength)
    ''' <summary>
    ''' Error message when address fails validation tests
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property AddressError() As String
        Get
            Return _AddressError
        End Get
    End Property

    Private _City As String
    ''' <summary>
    ''' City of customer
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property City() As String
        Get
            Return _City
        End Get
        Set(ByVal value As String)
            If (value.Length < c_MinLength Or value.Length > c_MaxLength) And value <> "" Then
                Throw New Exception(CityError)
            Else
                _City = value
            End If
        End Set
    End Property

    Private _CityError As String = String.Format("City must be between {0} and {1} characters in length.",
                                                 c_MinLength, c_MaxLength)
    ''' <summary>
    ''' Error message when city fails validation tests
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CityError As String
        Get
            Return _CityError
        End Get
    End Property
    Private _State As String
    ''' <summary>
    ''' Customer state for address
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property State() As String
        Get
            Return _State
        End Get
        Set(ByVal value As String)
            If value = "OR" Or value = "WA" Or value = "" Then
                _State = value
            Else
                Throw New Exception(StateError)
            End If
        End Set
    End Property

    Private _StateError As String = "The State must be WA or OR."
    ''' <summary>
    ''' Error message when state fails validation test
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property StateError() As String
        Get
            Return _StateError
        End Get
    End Property

    Private _Zip As String
    ''' <summary>
    ''' Zip code of customer
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Zip() As String
        Get
            Return _Zip
        End Get
        Set(ByVal value As String)
            Dim ZipMatch As Match
            If value.Length = 5 Then
                ZipMatch = Regex.Match(value, "^[0-9]{5}")
            Else
                ZipMatch = Regex.Match(value, "^[0-9]{5}-[0-9]{4}$")
            End If

            If ZipMatch.Success Or value = "" Then
                _Zip = value
            Else
                Throw New Exception(ZipError)
            End If
        End Set
    End Property

    Private _ZipError As String = "The Zip needs to be in the format '#####' or '#####-####'"
    ''' <summary>
    ''' Error when zip fails validation test
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ZipError() As String
        Get
            Return _ZipError
        End Get
    End Property

    Private _Phone As String
    ''' <summary>
    ''' Phone number of customer
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Phone() As String
        Get
            Return _Phone
        End Get
        Set(ByVal value As String)
            If CheckPhoneFormat(value) Or value = "" Then
                _Phone = value
            Else
                Throw New Exception(PhoneError)
            End If
        End Set
    End Property
    Private _PhoneError As String = "Phone should be in the format '##########' or '###-###-####'"
    ''' <summary>
    ''' Error message when phone fails validation test
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property PhoneError() As String
        Get
            Return _PhoneError
        End Get
    End Property

    Private _Fax As String
    ''' <summary>
    ''' Fax number of customer
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Fax() As String
        Get
            Return _Fax
        End Get
        Set(ByVal value As String)
            If CheckPhoneFormat(value) Or value = "" Then
                _Fax = value
            Else
                Throw New Exception(FaxError)
            End If
        End Set
    End Property

    Private _FaxError As String = "Fax should be in the format '##########' or '###-###-####'"
    ''' <summary>
    ''' Error message when fax fails validation test
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FaxError() As String
        Get
            Return _FaxError
        End Get
    End Property
    Private _Email As String
    ''' <summary>
    ''' Email address of customer
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            Dim EmailMatch As Match
            EmailMatch = Regex.Match(value.ToUpper, "^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$")
            If EmailMatch.Success Or value = "" Then
                _Email = value
            Else
                Throw New Exception(EmailError)
            End If
        End Set
    End Property
    Private _EmailError As String = "Email should use the format: 'name@domain.com' or similar"
    ''' <summary>
    ''' Error message when email fails validation test
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property EmailError() As String
        Get
            Return _EmailError
        End Get
    End Property

    Private _Contact As String
    ''' <summary>
    ''' Contact for customer
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Contact() As String
        Get
            Return _Contact
        End Get
        Set(ByVal value As String)
            If (value.Length < c_MinLength Or value.Length > c_MaxLength) And value <> "" Then
                Throw New Exception(ContactError)
            Else
                _Contact = value
            End If
        End Set
    End Property

    Private _ContactError As String = String.Format("Contact must be between {0} and {1} characters in length.",
                                                    c_MinLength, c_MaxLength)
    ''' <summary>
    ''' Error message when contact fails validation test
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ContactError() As String
        Get
            Return _ContactError
        End Get
    End Property

    Const c_MinDate As Long = 7
    Const c_MaxDate As Long = 3
    Private _LastCountDate As Date
    ''' <summary>
    ''' Date when customer inventory count was last input
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LastCountDate() As Date
        Get
            Return _LastCountDate
        End Get
        Set(ByVal value As Date)
            If CheckDateInterval(value) = False Then
                Throw New Exception(DateError)
            Else
                _LastCountDate = value
            End If
        End Set
    End Property

    Private _LastOrderDate As Date
    ''' <summary>
    ''' Last time customer placed an order
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LastOrderDate() As Date
        Get
            Return _LastOrderDate
        End Get
        Set(ByVal value As Date)
            If CheckDateInterval(value) = False Then
                Throw New Exception(DateError)
            Else
                _LastOrderDate = value
            End If
        End Set
    End Property

    Private _DateError As String = String.Format("Date must be within {0} before or {1} days after today.",
                                                 c_MinDate, c_MaxDate)
    ''' <summary>
    ''' Error message when date fails validation
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DateError() As String
        Get
            Return _DateError
        End Get
        Set(ByVal value As String)
            _DateError = value
        End Set
    End Property
    ''' <summary>
    ''' Validation test for phone number format
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckPhoneFormat(ByVal value As String) As Boolean
        Dim PhoneMatch As Match

        If value.Length = 10 Then
            PhoneMatch = Regex.Match(value, "^[0-9]{10}$")
        Else
            PhoneMatch = Regex.Match(value, "^[0-9]{3}-[0-9]{3}-[0-9]{4}$")
        End If

        Return PhoneMatch.Success
    End Function
    ''' <summary>
    ''' Validation test for date
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckDateInterval(ByVal value As Date) As Boolean
        Dim IsSuccess As Boolean
        If IsActive = True Then
            Dim iDiff As Long
            iDiff = DateDiff(DateInterval.Day, Now, value)
            If iDiff < -c_MinDate Or iDiff > c_MaxDate Then
                IsSuccess = False
            Else
                IsSuccess = True
            End If
        Else
            IsSuccess = True
        End If
        Return IsSuccess
    End Function

End Class
