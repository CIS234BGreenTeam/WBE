Imports libWBEData
Imports libWBEBR

Module modFillCollections
    ''' <summary>
    ''' Removes customer inventory items that correspond to inactive baked goods
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RemoveInactiveCustStock(ByVal _colCustStock As colCustStock,
                                       ByVal _colBakedGoods As colBakedGoods)

        For i As Integer = _colCustStock.Count - 1 To 0 Step -1
            Dim objBakedGood As libWBEBR.BakedGood
            objBakedGood = _colBakedGoods.Find(_colCustStock(i).BakedGoodID)

            If objBakedGood Is Nothing Then
                _colCustStock.RemoveAt(i)
            End If
        Next
    End Sub

    ''' <summary>
    ''' Removes order items that correspond to inactive baked goods
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RemoveInactiveOrderItems(ByVal _colOrderItems As colOrderItems, _colBakedGoods As colBakedGoods)
        For i As Integer = _colOrderItems.Count - 1 To 0 Step -1
            Dim objBakedGood As BakedGood
            objBakedGood = _colBakedGoods.Find(_colOrderItems(i).BakedGoodID)

            If objBakedGood Is Nothing Then
                _colOrderItems.Remove(_colOrderItems(i))
            End If
        Next
    End Sub

    ''' <summary>
    ''' Remove baked good items that are inactive from the collection
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RemoveInactiveBakedGoods(ByVal _colBakedGoods As colBakedGoods)
        For i As Integer = _colBakedGoods.Count - 1 To 0 Step -1
            If _colBakedGoods(i).IsInactive = True Then
                _colBakedGoods.RemoveAt(i)
            End If
        Next
    End Sub


    ''' <summary>
    ''' Add baked good prices to custstock collection
    ''' </summary>
    ''' <param name="_colCustStock"></param>
    ''' <param name="_colBakedGoods"></param>
    ''' <remarks></remarks>
    Public Sub AddCustStockPrices(ByVal _colCustStock As colCustStock,
                                  ByVal _colBakedGoods As colBakedGoods)
        For Each CustStock As CustStock In _colCustStock
            Dim objBakedGood As BakedGood
            objBakedGood = _colBakedGoods.Find(CustStock.BakedGoodID)
            CustStock.UnitPrice = objBakedGood.UnitPrice
        Next
    End Sub

    ''' <summary>
    ''' Determines whether or not a type of baked good is in a cust stock item
    ''' </summary>
    ''' <param name="objBakedGood"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsBakedGoodInOrder(ByVal objBakedGood As BakedGood,
                                        ByVal _colCustStock As colCustStock) As Boolean
        For Each objCustStock As CustStock In _colCustStock
            If objCustStock.BakedGoodID = objBakedGood.BakedGoodID Then
                Return True
            End If
        Next
        Return False
    End Function


End Module
