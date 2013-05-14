Imports libWBEData
Imports libWBEBR

Public Class DesiredInv
    Inherits System.Web.UI.Page
    Dim txtDesired() As TextBox
    Dim lblItem() As Label

    Private _colCustomers As New colCustomers
    Private _colBakedGoods As New colBakedGoods
    Private _colCustStock As New colCustStock

    Private Sub DesiredInv_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim sError As String = ""
        lblError.Text = ""

        CustomerDB.SetupAdapter()
        BakedGoodDB.SetupAdapter()
        If _colCustomers.Fill(sError) Then
            FillCustomerSelection()
        Else
            lblError.Text += sError + " "
        End If

        If _colBakedGoods.Fill(sError) Then
            RemoveInactiveBakedGoods()
        Else
            lblError.Text += sError + " "
        End If

        FillInventoryItems(Convert.ToInt32(ddlCustomer.SelectedItem.Value))

    End Sub

    Private Sub RemoveInactiveBakedGoods()
        For i As Integer = _colBakedGoods.Count - 1 To 0 Step -1
            If _colBakedGoods(i).Inactive = True Then
                _colBakedGoods.RemoveAt(i)
            End If
        Next
    End Sub

    Private Sub FillCustomerSelection()
        'fill combobox from Customer collection
        Dim sError As String = ""

        ddlCustomer.Items.Clear()

        'todo: Add sorting to colCustomers
        '_colCustomers.Sort() 

        For Each objCustomer As Customer In _colCustomers
            'Add the item to the list this way to store the CustomerID with the item
            Dim objListItem As New ListItem
            objListItem.Text = objCustomer.ToString
            objListItem.Value = objCustomer.CustomerID.ToString
            ddlCustomer.Items.Add(objListItem)
        Next
    End Sub

    Protected Sub ddlCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCustomer.SelectedIndexChanged
        Dim CustomerID As Integer
        CustomerID = Convert.ToInt32(ddlCustomer.SelectedItem.Value)
        FillInventoryItems(CustomerID)
    End Sub

    Private Sub FillInventoryItems(ByVal CustomerID As Integer)
        'Dynamically create list of inventory items for the customer
        Dim sError As String = ""
        Dim i As Integer = 0
        Dim iMaxLines As Integer

        CustStockDB.CustomerID = CustomerID
        CustStockDB.SetupAdapter()

        If _colCustStock.Fill(sError) = False Then
            lblError.Text += sError + " "
            lblError.Visible = True
        End If

        RemoveInactiveCustStock()

        iMaxLines = _colBakedGoods.Count
        iMaxLines -= 1

        Session("iMaxLines") = iMaxLines

        ReDim txtDesired(iMaxLines)
        ReDim lblItem(iMaxLines)

        pnlInventory.Controls.Clear()
        pnlInventory.Controls.Add(New LiteralControl("<br />"))

        For Each objBakedGood As BakedGood In _colBakedGoods
            CreateCustStockRow(objBakedGood, i)
        Next
    End Sub

    Private Sub RemoveInactiveCustStock()
        For i As Integer = _colCustStock.Count - 1 To 0 Step -1
            Dim objBakedGood As BakedGood
            objBakedGood = _colBakedGoods.Find(_colCustStock(i).BakedGoodID)
            If objBakedGood Is Nothing Then
                _colCustStock.RemoveAt(i)
            End If
        Next
    End Sub

    Private Sub CreateCustStockRow(ByVal objBakedGood As BakedGood, ByRef i As Integer)
        Dim objCustStock As CustStock
        txtDesired(i) = New TextBox
        lblItem(i) = New Label

        'Textbox for desired quantity
        objCustStock = GetCustStockItem(objBakedGood.BakedGoodID)

        If objCustStock Is Nothing Then
            objCustStock = New CustStock
            CreateDummyStock(objCustStock)
        End If

        txtDesired(i).Width = 25
        txtDesired(i).Text = objCustStock.DesiredQty.ToString
        txtDesired(i).Attributes.Add("StockID", objCustStock.StockID.ToString)
        txtDesired(i).Attributes.Add("StockQty", objCustStock.StockQty.ToString)

        pnlInventory.Controls.Add(txtDesired(i))
        pnlInventory.Controls.Add(New LiteralControl("&nbsp;"))
        pnlInventory.Controls.Add(New LiteralControl("&nbsp;"))
        pnlInventory.Controls.Add(New LiteralControl("&nbsp;"))

        'Label for Baked Good items
        lblItem(i).Text = objBakedGood.Name
        lblItem(i).Attributes.Add("BakedGoodID", objBakedGood.BakedGoodID.ToString)

        pnlInventory.Controls.Add(lblItem(i))

        'Add next item on next line
        pnlInventory.Controls.Add(New LiteralControl("<br />"))
        i += 1
    End Sub

    Private Function GetCustStockItem(ByVal BakedGoodID As Integer) As CustStock
        For Each CustStock As CustStock In _colCustStock
            If CustStock.BakedGoodID = BakedGoodID Then
                Return CustStock
            End If
        Next
    End Function

    Private Sub CreateDummyStock(ByVal CustStock As CustStock)
        CustStock.BakedGoodID = 0
        CustStock.DesiredQty = 0
        CustStock.StockQty = 0
        CustStock.StockID = 0
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim sError As String = ""
        Dim iLength As Integer

        iLength = Convert.ToInt32(Session("iMaxLines"))

        For i As Integer = 0 To iLength - 1
            Dim CustStock As CustStock
            CustStock = GetStockItem(i)
            If CustStock.StockID <> 0 Then
                _colCustStock.Change(CustStock)
            Else
                _colCustStock.Add(CustStock)
            End If
        Next

        CustStockDB.Update()
    End Sub

    Private Function GetStockItem(i As Integer) As CustStock
        Dim CustStock As New CustStock

        CustStock.BakedGoodID = Convert.ToInt32(lblItem(i).Attributes.Item("BakedGoodID"))
        CustStock.DesiredQty = Convert.ToInt32(txtDesired(i).Text)
        CustStock.StockID = Convert.ToInt32(txtDesired(i).Attributes.Item("StockID"))
        CustStock.CustomerID = Convert.ToInt32(ddlCustomer.SelectedItem.Value)
        CustStock.StockQty = Convert.ToInt32(txtDesired(i).Attributes.Item("StockQty"))

        Return CustStock
    End Function

End Class