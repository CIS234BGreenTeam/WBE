Imports System.Text.RegularExpressions

Public Class Customer
    Public Property Stock As List(Of BakedGood)
    Public Property Order As List(Of Order)

    Const c_NameMaxLength As Integer = 25
    Private _Name As String
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            If value.Length > c_NameMaxLength Then
                Throw New Exception(NameError)
            Else
                _Name = value
            End If
        End Set
    End Property
    Private _NameError As String = String.Format("Name must be no more than {0} characters in length.", c_NameMaxLength)
    Public ReadOnly Property NameError() As String
        Get
            Return _NameError
        End Get
    End Property

    Private Const c_AddressMaxLength As Integer = 40
    Private _Address1 As String
    Public Property Address1() As String
        Get
            Return _Address1
        End Get
        Set(ByVal value As String)
            If value.Length > c_AddressMaxLength Then
                Throw New Exception(AddressError)
            Else
                _Address1 = value
            End If
            _Address1 = value
        End Set
    End Property

    Private _Address2 As String
    Public Property Address2() As String
        Get
            Return _Address2
        End Get
        Set(ByVal value As String)
            If value.Length > c_AddressMaxLength Then
                Throw New Exception(AddressError)
            Else
                _Address2 = value
            End If
        End Set
    End Property
    Private _AddressError As String = String.Format("Address must be less than {0} characters in length.", c_AddressMaxLength)
    Public ReadOnly Property AddressError() As String
        Get
            Return _AddressError
        End Get
    End Property

    Private Const c_CityMaxLength As Integer = 25
    Private _City As String
    Public Property City() As String
        Get
            Return _City
        End Get
        Set(ByVal value As String)
            If value.Length > c_CityMaxLength Then
                Throw New Exception(CityError)
            Else
                _City = value
            End If
        End Set
    End Property

    Private _CityError As String = String.Format("City must be less than {0} characters is length.", c_CityMaxLength)
    Public ReadOnly Property CityError As String
        Get
            Return _CityError
        End Get
    End Property
    Private _State As String
    Public Property State() As String
        Get
            Return _State
        End Get
        Set(ByVal value As String)
            Dim StateMatch As Match
            StateMatch = Regex.Match(value.ToUpper, "^[A-Z]{2}")
            If value.Length = 2 And StateMatch.Success Then
                _State = value
            Else
                Throw New Exception(StateError)
            End If
        End Set
    End Property

    Private _StateError As String = "Please use a correct state abbreviation."
    Public ReadOnly Property StateError() As String
        Get
            Return _StateError
        End Get
    End Property

    Private _Zip As String
    Public Property Zip() As String
        Get
            Return _Zip
        End Get
        Set(ByVal value As String)
            Dim ZipMatch As Match
            If value.Length = 5 Then
                ZipMatch = Regex.Match(value, "^[0-9]{5}")
            Else
                ZipMatch = Regex.Match(value, "^[0-9]{5}-[0-9]{4}")
            End If

            If ZipMatch.Success Then
                _Zip = value
            Else
                Throw New Exception(ZipError)
            End If
        End Set
    End Property

    Private _ZipError As String = "The Zip needs to be in the format '#####' or '#####-####'"
    Public ReadOnly Property ZipError() As String
        Get
            Return _ZipError
        End Get
    End Property

    Private _Phone As String
    Public Property Phone() As String
        Get
            Return _Phone
        End Get
        Set(ByVal value As String)
            If CheckPhoneFormat(value) Then
                _Phone = value
            Else
                Throw New Exception(PhoneError)
            End If
        End Set
    End Property
    Private _PhoneError As String = "Phone should be in the format '(###) ###-####' or '###-###-####'"
    Public ReadOnly Property PhoneError() As String
        Get
            Return _PhoneError
        End Get
    End Property

    Private _Fax As String
    Public Property Fax() As String
        Get
            Return _Fax
        End Get
        Set(ByVal value As String)
            If CheckPhoneFormat(value) Then
                _Fax = value
            Else
                Throw New Exception(FaxError)
            End If
        End Set
    End Property

    Private _FaxError As String = "Fax should be in the format '(###) ###-####' or '###-###-####'"
    Public ReadOnly Property FaxError() As String
        Get
            Return _FaxError
        End Get
    End Property
    Private _Email As String
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            Dim EmailMatch As Match
            EmailMatch = Regex.Match(value.ToUpper, "^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$")
            If EmailMatch.Success Then
                _Email = value
            Else
                Throw New Exception(EmailError)
            End If
        End Set
    End Property
    Private _EmailError As String = "Email should use the format: 'name@domain.com' or similar"
    Public ReadOnly Property EmailError() As String
        Get
            Return _EmailError
        End Get
    End Property

    Public Function CheckPhoneFormat(ByVal value As String) As Boolean
        Dim PhoneMatch As Match

        If value.Length = 10 Then
            PhoneMatch = Regex.Match(value, "^[0-9]{10}")
        ElseIf value.Length = 12 Then
            PhoneMatch = Regex.Match(value, "^[0-9]{3}-[0-9]{3}-[0-9]{4}")
        ElseIf value.Length = 14 Then
            PhoneMatch = Regex.Match(value, "^\([0-9]{3}\) [0-9]{3}-[0-9]{4}")
        Else
            PhoneMatch = Regex.Match(value, "^\([0-9]{3}\)[0-9]{3}-[0-9]{4}")
        End If

        Return PhoneMatch.Success
    End Function
End Class
