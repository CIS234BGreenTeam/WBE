Public Class Driver
    Public Property DriverID As Integer

    Private Const c_MinLength As Integer = 3
    Private Const c_MaxLength As Integer = 30
    Private _Name As String
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

    Public ReadOnly Property NameError() As String
        Get
            Return _NameError
        End Get
    End Property

End Class
