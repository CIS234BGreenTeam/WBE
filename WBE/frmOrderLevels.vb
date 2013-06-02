Imports libWBEData
Imports libWBEBR

Public Class frmOrderLevels
    Private _colCustomers As New colCustomers
    Private _colBakedGoods As New colBakedGoods
    Private _colCustStock As New colCustStock

    Private Property InvCount As Boolean
    Private _IsChanged As Boolean = False

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

        If _colBakedGoods.Fill(sError) Then
            RemoveInactiveBakedGoods()
        Else
            MessageBox.Show(sError)
        End If

        'Load the desired order levels for the selected customer
        FillInventoryItems(DirectCast(cboCustomer.SelectedItem, Customer).CustomerID)

        lstOrderLevels.SelectedIndex = 0
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

        'load cust stock items for selected customer only
        CustStockDB.CustomerID = CustomerID
        CustStockDB.SetupAdapter()

        If _colCustStock.Fill(sError) = False Then
            MessageBox.Show(sError)
        End If

        'Remove any items that correspond to baked goods that are inactive
        RemoveInactiveCustStock()

        'Create list for all active baked goods. If no custstock item exists for
        'that baked good for the selected customer, create dummy row
        For Each objBakedGood As BakedGood In _colBakedGoods
            Dim objCustStock As CustStock
            objCustStock = GetCustStockItem(objBakedGood.BakedGoodID)
            If objCustStock Is Nothing Then
                objCustStock = CreateDummyStock(objBakedGood)
            End If
            objCustStock.InvCount = Me.InvCount
            lstOrderLevels.Items.Add(objCustStock)
        Next
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
        FillInventoryItems(DirectCast(cboCustomer.SelectedItem, Customer).CustomerID)

        If InvCount = True And _IsChanged = True Then
            Dim objCustomer As Customer = DirectCast(cboCustomer.SelectedItem, Customer)
            If Not objCustomer Is Nothing Then
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
    ''' Create dummy custstock object if no database row corresponds to the bakedgood ID
    ''' </summary>
    ''' <param name="BakedGood"></param>
    ''' <remarks></remarks>
    Private Function CreateDummyStock(ByVal BakedGood As BakedGood) As CustStock
        Dim CustStock As New CustStock
        CustStock.BakedGoodID = BakedGood.BakedGoodID
        CustStock.Name = BakedGood.Name
        CustStock.DesiredQty = 0
        CustStock.StockQty = 0
        CustStock.StockID = 0
        CustStock.CustomerID = DirectCast(cboCustomer.SelectedItem, Customer).CustomerID
        Return CustStock
    End Function

    ''' <summary>
    ''' Updates the quantity shown in the textbox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lstOrderLevels_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstOrderLevels.SelectedIndexChanged
        Dim objOrderItem As CustStock
        objOrderItem = DirectCast(lstOrderLevels.SelectedItem, CustStock)

        If Not objOrderItem Is Nothing Then
            If InvCount = True Then
                txtQuantity.Text = objOrderItem.StockQty
            Else
                txtQuantity.Text = objOrderItem.DesiredQty
            End If
        End If
    End Sub

    Private Sub Save()
        Dim objCustStock As CustStock

        objCustStock = DirectCast(lstOrderLevels.SelectedItem, CustStock)

        If Not objCustStock Is Nothing Then

            If IsValid(objCustStock) = True Then
                Dim iCount As Integer = lstOrderLevels.SelectedIndex

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
                FillInventoryItems(objCustStock.CustomerID)
                lstOrderLevels.SelectedIndex = iCount
            End If

        Else
            MessageBox.Show("An item must be selected.")
        End If

    End Sub

    Private Function IsValid(ByVal objCustStock As CustStock) As Boolean
        epCustStock.Clear()
        Try
            If InvCount = True Then
                objCustStock.StockQty = txtQuantity.Text
            Else
                objCustStock.DesiredQty = txtQuantity.Text
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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Save()
    End Sub
End Class