Public Class CustStock
    Inherits BakedGood

    Public Property StockID As Integer
    Public Property CustomerID As Integer

    Public Sub New(ByVal objBakedGoodID As Integer,
                   ByVal objCustomerID As Integer,
                   ByVal objStockQty As Integer)

        BakedGoodID = objBakedGoodID
        CustomerID = objCustomerID
        StockQty = objStockQty
    End Sub

    Public Sub New()

    End Sub
End Class
