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

    Public Property InvCount As Boolean

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

    ''' <summary>
    ''' How to display the object on the form
    ''' </summary>
    Public Overrides Function ToString() As String
        Dim sDisplay As String

        'use the real deal
        If InvCount = True Then
            sDisplay = String.Format("{0,-21} {1, 4}", Name, StockQty)
        Else
            sDisplay = String.Format("{0,-21} {1, 4}", Name, DesiredQty)
        End If

        Return sDisplay
    End Function
End Class
