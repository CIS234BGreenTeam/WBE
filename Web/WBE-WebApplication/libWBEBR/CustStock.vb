Public Class CustStock
    Inherits BakedGood

    ''' <summary>
    ''' Unique identifier of CustStock object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StockID As Integer

    ''' <summary>
    ''' Customer attached to CustStock object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CustomerID As Integer

    ''' <summary>
    ''' Constructor with data
    ''' </summary>
    ''' <param name="objBakedGoodID">Identifier of baked good (needed to obtain Name)</param>
    ''' <param name="objCustomerID">Identifier of attached customer</param>
    ''' <param name="objStockQty">Quantity of item in stock</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal objBakedGoodID As Integer,
                   ByVal objCustomerID As Integer,
                   ByVal objStockQty As Integer)

        BakedGoodID = objBakedGoodID
        CustomerID = objCustomerID
        StockQty = objStockQty
    End Sub

    ''' <summary>
    ''' default constructor (no data)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

    End Sub
End Class
