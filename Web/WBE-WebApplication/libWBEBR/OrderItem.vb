Public Class OrderItem
    Public Property Item As BakedGood


    Private m_dUnitPrice As Decimal
    Private m_iQuantity As Integer

    '''<summary>
    '''Cost of single baked good
    '''</summary>
    ''' <remarks>If invald, throws UnitPriceError()</remarks>
    Public Property UnitPrice() As Decimal
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
    Public ReadOnly Property UnitPriceError() As String
        Get
            Return "UnitPrice Price must be between $0.00 and $250.00. "
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



End Class
