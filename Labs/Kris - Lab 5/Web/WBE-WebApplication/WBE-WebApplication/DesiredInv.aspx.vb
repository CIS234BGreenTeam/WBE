
'Created by: Kristina Frye
'May 13, 2013
'CIS 234B
'
'The purpose of this screen is to show the customer's desired inventory levels.
'Inactive baked good items are excluded
'
'I switched away from a more dymamic interface that created rows on the fly because
'I was having difficulty with Visual Studio not letting me keep track of any controls
'created after the page_init. So moved to a format where all available baked goods show
'up with current desired inventory items. I may actually like this user interface better
'anyway.
'
'This screen is still buggy. If you save inventory data, change customers, and then save the
'new customer's data, the old customer's data will suddenly appear. If you switch back to the 
'old customer, all that customer's inventory points are now 0. Not sure what is going on.

Imports libWBEData
Imports libWBEBR

Public Class DesiredInv
    Inherits System.Web.UI.Page
    Dim txtDesired() As TextBox
    Dim lblItem() As Label
    Dim lblCustID As Label
    Dim lblActualID As Label

    Private _colCustomers As New colCustomers
    Private _colBakedGoods As New colBakedGoods
    Private _colCustStock As New colCustStock

    Private Sub DesiredInv_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim sError As String = ""
        lblError.Text = ""

        'Load data into collections

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

        'Fill dynamically created controls
        FillInventoryItems(Convert.ToInt32(Session("CustomerID")))

    End Sub

    ''' <summary>
    ''' Remove baked good items that are inactive from the collection
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RemoveInactiveBakedGoods()
        For i As Integer = _colBakedGoods.Count - 1 To 0 Step -1
            If _colBakedGoods(i).IsInactive = True Then
                _colBakedGoods.RemoveAt(i)
            End If
        Next
    End Sub

    ''' <summary>
    ''' Fill the customer selection dropdownlist
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillCustomerSelection()
        'fill combobox from Customer collection
        Dim sError As String = ""

        ddlCustomer.Items.Clear()


        '_colCustomers.Sort() 

        For Each objCustomer As Customer In _colCustomers
            'Add the item to the list this way to store the CustomerID with the item
            Dim objListItem As New ListItem
            objListItem.Text = objCustomer.ToString
            objListItem.Value = objCustomer.CustomerID.ToString
            ddlCustomer.Items.Add(objListItem)
        Next

        Session("CustomerID") = Convert.ToInt32(ddlCustomer.SelectedItem.Value)
    End Sub

    ''' <summary>
    ''' Called when customer is changed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ddlCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCustomer.SelectedIndexChanged
        Dim CustomerID As Integer
        CustomerID = Convert.ToInt32(ddlCustomer.SelectedItem.Value)
        FillInventoryItems(CustomerID)
    End Sub

    ''' <summary>
    ''' Create dynamic list of inventory items for the customer
    ''' </summary>
    ''' <param name="CustomerID"></param>
    ''' <remarks></remarks>
    Private Sub FillInventoryItems(ByVal CustomerID As Integer)
        Dim sError As String = ""
        Dim i As Integer = 0
        Dim iMaxLines As Integer

        'Fill the collection of customer items
        CustStockDB.CustomerID = CustomerID
        CustStockDB.SetupAdapter()

        If _colCustStock.Fill(sError) = False Then
            lblError.Text += sError + " "
            lblError.Visible = True
        End If

        'Remove any items that correspond to baked goods that are inactive
        RemoveInactiveCustStock()

        'Get the total number of active items
        iMaxLines = _colBakedGoods.Count
        iMaxLines -= 1

        Session("iMaxLines") = iMaxLines

        'Redimension arrays to active items
        ReDim txtDesired(iMaxLines)
        ReDim lblItem(iMaxLines)

        'Clear any existing dynamic controls
        pnlInventory.Controls.Clear()
        pnlInventory.Controls.Add(New LiteralControl("<br />"))

        lblCustID = New Label
        lblCustID.Text = "Customer ID: "
        pnlInventory.Controls.Add(lblCustID)

        lblActualID = New Label
        lblActualID.Text = CustomerID.ToString
        pnlInventory.Controls.Add(lblActualID)
        pnlInventory.Controls.Add(New LiteralControl("<br />"))
        pnlInventory.Controls.Add(New LiteralControl("<br />"))

        Session("CustomerID") = CustomerID

        'For each baked good, add a line
        For Each objBakedGood As BakedGood In _colBakedGoods
            CreateCustStockRow(objBakedGood, i)
        Next
    End Sub

    ''' <summary>
    ''' Removes customer inventory items that correspond to inactive baked goods
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RemoveInactiveCustStock()
        For i As Integer = _colCustStock.Count - 1 To 0 Step -1
            Dim objBakedGood As BakedGood
            objBakedGood = _colBakedGoods.Find(_colCustStock(i).BakedGoodID)
            If objBakedGood Is Nothing Then
                _colCustStock.RemoveAt(i)
            End If
        Next
    End Sub

    'Create a row of inventory items
    Private Sub CreateCustStockRow(ByVal objBakedGood As BakedGood, ByRef i As Integer)
        Dim objCustStock As CustStock
        txtDesired(i) = New TextBox
        lblItem(i) = New Label

        'Textbox for desired quantity
        objCustStock = GetCustStockItem(objBakedGood.BakedGoodID)

        'If no CustStock item can be created, this means there is no line in the database
        'that corresponds to the current baked good for this customer. Create dummy row.
        'This will create a new line in the database for this baked good item
        If objCustStock Is Nothing Then
            objCustStock = New CustStock
            CreateDummyStock(objCustStock)
        End If

        'Set attributes for textbox. These will be needed for saving later.
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

    ''' <summary>
    ''' Get the CustStock item corresponding to the bakedgood ID.
    ''' </summary>
    ''' <param name="BakedGoodID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCustStockItem(ByVal BakedGoodID As Integer) As CustStock
        For Each CustStock As CustStock In _colCustStock
            If CustStock.BakedGoodID = BakedGoodID Then
                Return CustStock
            End If
        Next
    End Function

    ''' <summary>
    ''' Create dummy custstock object if no database row corresponds to the bakedgood ID
    ''' </summary>
    ''' <param name="CustStock"></param>
    ''' <remarks></remarks>
    Private Sub CreateDummyStock(ByVal CustStock As CustStock)
        CustStock.BakedGoodID = 0
        CustStock.DesiredQty = 0
        CustStock.StockQty = 0
        CustStock.StockID = 0
    End Sub

    ''' <summary>
    ''' Save the data
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' Get the stock item from the page. I probably need to put a try/catch in here 
    ''' somewhere to validate user data, but still trying to get bugs worked out.
    ''' </summary>
    ''' <param name="i"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetStockItem(i As Integer) As CustStock
        Dim CustStock As New CustStock

        CustStock.BakedGoodID = Convert.ToInt32(lblItem(i).Attributes.Item("BakedGoodID"))
        CustStock.DesiredQty = Convert.ToInt32(txtDesired(i).Text)
        CustStock.StockID = Convert.ToInt32(txtDesired(i).Attributes.Item("StockID"))
        CustStock.CustomerID = Convert.ToInt32(Session("CustomerID"))
        CustStock.StockQty = Convert.ToInt32(txtDesired(i).Attributes.Item("StockQty"))

        Return CustStock
    End Function

End Class