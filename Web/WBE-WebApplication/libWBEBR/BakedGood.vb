Public Class BakedGood
    Public Property Name() As String
    Public Property DesiredQty() As Integer
    Public Property ActualQty() As Integer
    Public Property Price() As Decimal

    Public Function GetOrderQty() As Integer
        Return DesiredQty - ActualQty
    End Function

    Public Function GetExtendedPrice() As Decimal
        Return Price * GetOrderQty()
    End Function
End Class
