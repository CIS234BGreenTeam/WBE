Public Class BakedGood

    '* Class Name: BakedGood.vb. 
    '* Designer: Ken Baker 4/20/2013. 
    '* Purpose:  Contains properties and validations

    Private sName As String

    Public Property DesiredQty() As Integer
    Public Property StockQty() As Integer
    Public Property BakedGoodID() As Integer

    Public Property Name() As String
        Get
            Return sName
        End Get
        Set(ByVal value As String)
            If value.Length >= 2 And value.Length <= 30 Then
                sName = value
            Else
                Throw New Exception("Name must contain between 2 and 30 characters")
            End If
        End Set
    End Property

    Private m_dUnitPrice As Decimal

    '''<summary>
    '''Cost of single baked good
    '''</summary>
    ''' <remarks>If invald, throws UnitPriceError()</remarks>
    Public Overridable Property UnitPrice() As Decimal
        Get
            Return m_dUnitPrice
        End Get
        Set(ByVal value As Decimal)
            If value >= 0.5D And value <= 250D Then
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
            Return "UnitPrice Price must be between $0.50 and $250.00. "
        End Get

    End Property

    Public Function GetOrderQty() As Integer
        Return DesiredQty - StockQty
    End Function

End Class
