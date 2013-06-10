Public Class Order

    '* Class Name: Order.vb. 
    '* Designer: Ken Baker 4/20/2013. 
    '* Purpose:  Contains properties and validations

    Private m_iID As Integer
    Private m_dtOrderDate As DateTime
    Private m_eStatus As eStatus
    Private dtMaxDate As DateTime = Today.AddDays(3)
    Private dtMinDate As DateTime = Today.AddDays(-7)
    Private sDateErrorMsg As String = "Order date must be between " _
                                         & dtMinDate.ToShortDateString _
                                         & " and " & dtMaxDate.ToShortDateString

    Public Property CustomerID As Integer
    Public Property Item As List(Of OrderItem)
    Public Property StatusDesc As String

    Public Enum eStatus
        NewOrder
        Baking
        Invoiced
        NoOrder
    End Enum

    '===========================================================================

    ''' <summary>
    ''' Constructor with data
    ''' </summary>
    ''' <param  name="objOrderID">DriverID</param>
    ''' <param name="objOrderDate">Name of customer</param>
    ''' <param name="objStatus">Address of customer</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal objOrderID As Integer,
                   ByVal objOrderDate As Date,
                   ByVal objStatus As String)
        OrderID = objOrderID
        OrderDate = objOrderDate
        Status = objStatus
    End Sub

    ''' <summary>
    ''' Default constructor
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

    End Sub





    '==============================================================================
    Public Property Status() As eStatus
        Get
            Return m_eStatus
        End Get
        Set(ByVal value As eStatus)
            If value = eStatus.Baking Or
               value = eStatus.Invoiced Or
               value = eStatus.NewOrder Or
               value = eStatus.NoOrder Then

                m_eStatus = value
            Else
                Throw New Exception("Status must be NewOrder, Baking, Invoiced, or NoOrder")
            End If

        End Set
    End Property


    '''<summary>
    '''Order Date
    '''</summary>
    ''' <remarks>If invalid, throws OrderDateError()</remarks>
    Public Property OrderDate() As DateTime
        Get
            Return m_dtOrderDate
        End Get
        Set(ByVal value As DateTime)
            If Status.Equals(eStatus.NewOrder) Or Status.Equals(eStatus.Baking) Then
                If CheckDateInterval(value) = False Then
                    Throw New Exception(OrderDateError)
                Else
                    m_dtOrderDate = value
                End If
            Else
                m_dtOrderDate = value
            End If
        End Set
    End Property

    '''<summary>
    '''Returns error message if called by Quantity()
    '''</summary>
    Public ReadOnly Property OrderDateError() As String
        Get
            Return sDateErrorMsg
        End Get
    End Property

    '''<summary>
    '''Unique Order Number
    '''</summary>
    ''' <remarks>If invald, throws ID_Error()</remarks>
    Public Property OrderID() As Decimal
        Get
            Return m_iID
        End Get
        Set(ByVal value As Decimal)
            If value >= 1 And value <= 999999 Then
                m_iID = value
            Else
                Throw New Exception(OrderID_Error)
            End If

        End Set
    End Property

    '''<summary>
    '''Returns error message if called by UnitPrice()
    '''</summary>
    Public ReadOnly Property OrderID_Error() As String
        Get
            Return "Order ID must be between 1 and 999999. "
        End Get

    End Property

    ''' <summary>
    ''' Validation test for date
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckDateInterval(ByVal value As Date) As Boolean
        Dim IsSuccess As Boolean

        If value < dtMinDate Or value > dtMaxDate Then
            IsSuccess = False
        Else
            IsSuccess = True
        End If
        
        Return IsSuccess
    End Function



End Class
