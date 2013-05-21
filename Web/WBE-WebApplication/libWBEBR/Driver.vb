'Driver class
'Created by: Kristina Frye
'April 22, 2013
'CIS 234B

Public Class Driver
    Implements IComparable(Of Driver)
    ''' <summary>
    ''' Unique identifier of Driver object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DriverID As Integer

    Private Const c_MinLength As Integer = 3
    Private Const c_MaxLength As Integer = 30

    ''' <summary>
    ''' Constructor with data
    ''' </summary>
    ''' <param name="objName">Name to be copied into new Driver object</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal objName As String)
        Name = objName
    End Sub

    ''' <summary>
    ''' default constructor without data
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

    End Sub

    Private _Name As String
    ''' <summary>
    ''' Name of driver
    ''' </summary>
    ''' <value>Driver name</value>
    ''' <returns>Driver name</returns>
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
    ''' Error returned when SetName fails
    ''' </summary>
    ''' <returns>Error message for SetName</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property NameError() As String
        Get
            Return _NameError
        End Get
    End Property

    ''' <summary>
    ''' How to display the object on the form
    ''' </summary>
    Public Overrides Function ToString() As String
        'use the real deal
        Return Name
    End Function

    Public Function CompareTo(other As Driver) As Integer Implements IComparable(Of Driver).CompareTo
        Return Me.Name.CompareTo(other.Name)
    End Function
End Class
