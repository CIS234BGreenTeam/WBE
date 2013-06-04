Imports libWBEData
Imports libWBEBR

Public Class frmOrderLevels
    Private _colCustomers As New colCustomers
    Private _colBakedGoods As New colBakedGoods
    Private _colCustStock As New colCustStock

    Private Property InvCount As Boolean
    Private _IsChanged As Boolean = False

    ''' <summary>
    ''' One form is used to perform two actions. Set the current form here. If parameter is true,
    ''' the inventory count screen will be loaded. Otherwise, the Order Levels (for desired inventory)
    ''' will be loaded.
    ''' </summary>
    ''' <param name="bCount"></param>
    ''' <remarks></remarks>
    Public Sub SetFormType(ByVal bCount As Boolean)
        InvCount = bCount
        If bCount = True Then
            Me.Text = "Inventory Count"
            lblDescription.Text = "Counted Inventory Levels of Customer"
        End If
    End Sub

    Private Sub frmOrderLevels_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sError As String = ""

        'Set up database adapters
        CustomerDB.SetupAdapter()
        BakedGoodDB.SetupAdapter()

        'Fill the data collections
        If _colCustomers.Fill(sError) Then
            FillCustomerSelection()
        Else
            MessageBox.Show(sError)
        End If

        'Fill the baked good collection but remove inactive baked goods
        If _colBakedGoods.Fill(sError) Then
            RemoveInactiveBakedGoods()
            _colBakedGoods.Sort()
        Else
            MessageBox.Show(sError)
        End If

        'Load the desired order levels for the selected customer
        FillInventoryItems(DirectCast(cboCustomer.SelectedItem, Customer).CustomerID)

    End Sub

    ''' <summary>
    ''' Fills Customer combobox for selecting the customer
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillCustomerSelection()
        Dim sError As String = ""

        cboCustomer.Items.Clear()

        _colCustomers.Sort()

        For Each objCustomer As Customer In _colCustomers
            cboCustomer.Items.Add(objCustomer)
        Next

        cboCustomer.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' Fill listbox with items desired by customer or inventory count
    ''' </summary>
    ''' <param name="CustomerID"></param>
    ''' <remarks></remarks>
    Private Sub FillInventoryItems(ByVal CustomerID As Integer)
        Dim sError As String = ""

        'Fill the collection of customer items
        lstOrderLevels.Items.Clear()
        txtQuantity.Clear()
        cboItem.SelectedIndex = -1

        'load cust stock items for selected customer only
        CustStockDB.CustomerID = CustomerID
        CustStockDB.SetupAdapter()

        If _colCustStock.Fill(sError) = False Then
            MessageBox.Show(sError)
        End If

        'Remove any items that correspond to baked goods that are inactive
        RemoveInactiveCustStock()

        'Add all custstock items to the listbox
        For Each CustStock As CustStock In _colCustStock
            CustStock.InvCount = Me.InvCount

            'If loading OrderLevels screen (not inventory count screen) and the quantity
            'is zero, don't add it to the listbox.
            If Me.InvCount = True Or CustStock.DesiredQty <> 0 Then
                lstOrderLevels.Items.Add(CustStock)
            End If
        Next

        'Select the first item in the listbox if any items exist.
        If lstOrderLevels.Items.Count > 0 Then
            lstOrderLevels.SelectedIndex = 0
            btnAdd.Enabled = True
        Else
            'Don't allow more items to be added unless one already exists.
            btnAdd.Enabled = False
        End If
        
    End Sub

    ''' <summary>
    ''' Adds all available baked goods to the combobox
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillItemList()
        cboItem.Items.Clear()
        For Each BakedGood As BakedGood In _colBakedGoods
            cboItem.Items.Add(BakedGood)
        Next
    End Sub

    ''' <summary>
    ''' Removes baked good items that are already listed in custstock items (except current selected baked good item)
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RemoveUsedBakedGoods()
        For i As Integer = cboItem.Items.Count - 1 To 0 Step -1
            Dim objBakedGood As BakedGood = DirectCast(cboItem.Items(i), BakedGood)
            If IsBakedGoodInOrder(objBakedGood) Then

                'if there is an item selected in the list box, we want to make sure to include it in cboItem
                If lstOrderLevels.SelectedIndex <> -1 Then
                    If objBakedGood.BakedGoodID <> DirectCast(lstOrderLevels.SelectedItem, BakedGood).BakedGoodID Then
                        cboItem.Items.Remove(objBakedGood)
                    End If

                    'if no item is selected in the listbox, we want to make sure to remove any existing 
                    'CustStock items
                Else
                    cboItem.Items.Remove(objBakedGood)
                End If
            End If
        Next
    End Sub

    ''' Determines whether or not a type of baked good is in a cust stock item
    ''' </summary>
    ''' <param name="objBakedGood"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsBakedGoodInOrder(ByVal objBakedGood As BakedGood) As Boolean
        For Each objCustStock As CustStock In _colCustStock
            If objCustStock.BakedGoodID = objBakedGood.BakedGoodID Then
                Return True
            End If
        Next
        Return False
    End Function

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

    'Change list of custstock items when customer changes
    Private Sub cboCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCustomer.SelectedIndexChanged
        Dim objCustomer = DirectCast(cboCustomer.SelectedItem, Customer)

        If Not objCustomer Is Nothing Then
            FillInventoryItems(objCustomer.CustomerID)

            If InvCount = True And _IsChanged = True Then
                objCustomer.LastCountDate = Today
                _colCustomers.Change(objCustomer)
                CustomerDB.Update()
            End If
        End If
    End Sub

    'Get cust stock item for each baked good, if possible
    Private Function GetCustStockItem(ByVal BakedGoodID As Integer) As CustStock
        For Each CustStock As CustStock In _colCustStock
            If CustStock.BakedGoodID = BakedGoodID Then
                Return CustStock
            End If
        Next
    End Function

    ''' <summary>
    ''' Updates the quantity shown in the textbox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lstOrderLevels_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstOrderLevels.SelectedIndexChanged
        Dim objCustStock As CustStock

        'Fill cbolist with baked goods
        FillItemList()

        'remove any baked goods that are already used in custstock
        RemoveUsedBakedGoods()

        'If an item is selected, fill cboItem and txtQuantity
        If lstOrderLevels.SelectedIndex <> -1 Then
            objCustStock = DirectCast(lstOrderLevels.SelectedItem, CustStock)
            SetItemSelection(objCustStock)

            'Select which quantity to use in the txtQuantity
            If InvCount = True Then
                txtQuantity.Text = objCustStock.StockQty
            Else
                txtQuantity.Text = objCustStock.DesiredQty
            End If
        End If

    End Sub

    ''' <summary>
    ''' Set the cboItem equal to the Baked Good with ID matching the custstock item
    ''' </summary>
    ''' <param name="CustStock"></param>
    ''' <remarks></remarks>
    Private Sub SetItemSelection(ByVal CustStock As CustStock)
        For i As Integer = 0 To cboItem.Items.Count - 1
            If DirectCast(cboItem.Items(i), BakedGood).BakedGoodID = CustStock.BakedGoodID Then
                cboItem.SelectedIndex = i
            End If
        Next
    End Sub

    ''' <summary>
    ''' Save the item and quantity user inputs
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Save()
        Dim objCustStock As CustStock

        'Get CustStock item from selected item in listbox
        objCustStock = DirectCast(lstOrderLevels.SelectedItem, CustStock)

        'If no item is selected, make a new item
        If objCustStock Is Nothing Then
            objCustStock = New CustStock
            objCustStock.CustomerID = DirectCast(cboCustomer.SelectedItem, Customer).CustomerID
        End If

        'Check if user input is valid
        If IsValid(objCustStock) Then

            'Get listbox index of selected item for later use
            Dim iCount As Integer = lstOrderLevels.SelectedIndex

            'If we are counting inventory, note that the customer's count has changed
            If InvCount = True Then
                _IsChanged = True
            End If

            'If StockID not zero, then existing custstock item
            If objCustStock.StockID <> 0 Then
                _colCustStock.Change(objCustStock)
            Else  'If StockID = 0, then new custstock item.
                _colCustStock.Add(objCustStock)
            End If

            'To update data in listbox, we need to save and refresh data
            CustStockDB.Update()
            lstOrderLevels.Items.Clear()

            'Fill the listbox again
            FillInventoryItems(objCustStock.CustomerID)

            'Select the item in the listbox. 
            If iCount <> -1 Then
                lstOrderLevels.SelectedIndex = iCount
            Else
                lstOrderLevels.SelectedIndex = 0
            End If

            'Fill cboItem with selections
            FillItemList()

            'Remove any items that have already been used
            RemoveUsedBakedGoods()

            'Select the cboItem selection
            SetItemSelection(DirectCast(lstOrderLevels.SelectedItem, CustStock))

            'Make sure the Add button is enabled since we just saved an item
            btnAdd.Enabled = True
            btnAdd.Text = "&Add Item"
        End If

    End Sub

    ''' <summary>
    ''' Check that user input is valid.
    ''' </summary>
    ''' <param name="objCustStock"></param>
    ''' <returns>True if valid</returns>
    ''' <remarks></remarks>
    Private Function IsValid(ByVal objCustStock As CustStock) As Boolean
        epCustStock.Clear()

        If IsValidQuantity(objCustStock) And IsValidItem(objCustStock) Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Check that user input of quantity is valid
    ''' </summary>
    ''' <param name="objCustStock"></param>
    ''' <returns>True if valid</returns>
    ''' <remarks></remarks>
    Private Function IsValidQuantity(ByVal objCustStock As CustStock) As Boolean
        Try
            If InvCount = True Then
                objCustStock.StockQty = txtQuantity.Text
            Else
                objCustStock.DesiredQty = txtQuantity.Text

                'This is a little hack to disallow users from entering a value of zero
                'but still allowing it to be set in the CustStock item for instances
                'when StockQty is set without DesiredQty being set.
                If objCustStock.DesiredQty = 0 Then
                    epCustStock.SetError(txtQuantity, objCustStock.DesiredQtyError)
                    Return False
                End If
            End If
            Return True

        Catch ex As InvalidCastException
            If InvCount = True Then
                epCustStock.SetError(txtQuantity, objCustStock.StockQtyError)
            Else
                epCustStock.SetError(txtQuantity, objCustStock.DesiredQtyError)
            End If

            Return False

        Catch ex As Exception
            epCustStock.SetError(txtQuantity, ex.Message)
            Return False
        End Try

    End Function

    ''' <summary>
    ''' Check that user has selected an item
    ''' </summary>
    ''' <param name="CustStock"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidItem(ByVal CustStock As CustStock) As Boolean
        Dim objBakedGood As BakedGood = DirectCast(cboItem.SelectedItem, BakedGood)
        If objBakedGood Is Nothing Then
            epCustStock.SetError(cboItem, "You must select a baked good.")
            Return False
        Else
            CustStock.BakedGoodID = objBakedGood.BakedGoodID
            Return True
        End If
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Save()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If btnAdd.Text = "&Add Item" Then
            ClearForm()
            btnAdd.Text = "&Cancel"
        Else
            btnAdd.Text = "&Add Item"
            If lstOrderLevels.Items.Count > 0 Then
                lstOrderLevels.SelectedIndex = 0
            End If
        End If
    End Sub

    ''' <summary>
    ''' Clear the form and reset item list
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearForm()
        txtQuantity.Clear()
        lstOrderLevels.SelectedIndex = -1
        FillItemList()
        RemoveUsedBakedGoods()
        cboItem.SelectedItem = -1
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If lstOrderLevels.SelectedIndex = -1 Then
            MessageBox.Show("You must select an item to delete first.")
        Else
            'Delete the selected item in the listbox
            Dim objCustStock As CustStock = DirectCast(lstOrderLevels.SelectedItem, CustStock)
            _colCustStock.Remove(objCustStock)
            CustStockDB.Update()

            'Reset listbox
            FillInventoryItems(DirectCast(cboCustomer.SelectedItem, Customer).CustomerID)
            If lstOrderLevels.Items.Count > 0 Then
                lstOrderLevels.SelectedIndex = 0
            End If
        End If
    End Sub
End Class