
'''<summary>
''' Class Name: OrderItem.vb. -
''' -  Designer: Ken Baker 4/20/2013.
'''</summary>
''' <remarks>Purpose:  Contains properties and validations</remarks>
Public Class OrderItem
    Inherits BakedGood

    Private m_dUnitPrice As Decimal
    Private m_iQuantity As Integer



    '''<summary>
    '''ID number that uniquely identifies 
    ''' an instance of an OrderItem Object
    '''</summary>
    ''' <remarks></remarks>
    Public Property OrderItemID() As Integer

    '''<summary>
    '''ID number that identifies the Orders Object
    ''' that this OrderItem Object belongs to
    '''</summary>
    ''' <remarks></remarks>
    Public Property OrderID As Integer

    '''<summary>
    '''Cost of single baked good
    '''</summary>
    ''' <remarks>If invald, throws UnitPriceError()</remarks>
    Public Overrides Property UnitPrice() As Decimal
        Get
            Return m_dUnitPrice
        End Get
        Set(ByVal value As Decimal)
            If value >= 0D And value <= 250D Then
                m_dUnitPrice = value
            Else
                Throw New Exception(UnitPriceError)
            End If

        End Set
    End Property

    '''<summary>
    '''Returns error message if called by UnitPrice()
    '''</summary>
    Public Overloads ReadOnly Property UnitPriceError() As String
        Get
            Return "UnitPrice Price must be between $0.50 and $250.00. "
        End Get

    End Property


    '''<summary>
    '''Number of baked good wanted
    '''</summary>
    ''' <remarks>If invald, throws QuantityError()</remarks>
    Public Property Quantity() As Integer
        Get
            Return m_iQuantity
        End Get
        Set(ByVal value As Integer)
            If value >= 1 And value <= 500 Then
                m_iQuantity = value
            Else
                Throw New Exception(QuantityError)
            End If

        End Set
    End Property

    '''<summary>
    '''Returns error message if called by Quantity()
    '''</summary>
    Public ReadOnly Property QuantityError() As String
        Get
            Return "Enter a quantity between 1 and 500."
        End Get
    End Property



    '''<summary>
    '''Returns the calculated product of UnitPrice and Quantity
    '''</summary>
    Public Function GetExtendedPrice() As Decimal
        Return UnitPrice * GetOrderQty()
    End Function

    ''' <summary>
    ''' Constructor with data
    ''' </summary>
    ''' <param name="objBakedGoodID">Identifier of baked good (needed to obtain Name)</param>
    ''' <param name="objOrderID">Identifier of attached order</param>
    ''' <param name="objUnitPrice">UnitPrice of item in ordered</param>
    ''' ''' <param name="objQuantity">Quantity of item ordered</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal objBakedGoodID As Integer,
                   ByVal objOrderID As Integer,
                   ByVal objUnitPrice As Decimal,
                   ByVal objQuantity As Decimal)

        BakedGoodID = objBakedGoodID
        OrderID = objOrderID
        UnitPrice = objUnitPrice
        Quantity = objQuantity
    End Sub

    ''' <summary>
    ''' default constructor (no data)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

    End Sub
End Class
