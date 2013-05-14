Imports libWBEData
Imports libWBEBR

'Screen Name: Customers

'Designer: Kristina Frye

'Purpose: Allow Customer/WBE personnel to view profile and update 
'customer contact information.

'Also allow customer keep track of desired inventory. 

'Save Inventory: This saves all changes made to the inventory line items to the
'database.

'Save Customer: Save any changes to the customer contact information
'to the database.

'Open Order: Open the order selected in the textbox.

'New Customer: Create a new customer record (clear form)

'Note: Customers cannot be deleted from the WBE database. They
'can only be made inactive.

Public Class CustomerTab
    Inherits System.Web.UI.Page

    'These arrays store the dynamically created inventory items
    Dim txtDesired() As TextBox
    Dim lblItem() As Label

    Private _colCustomers As New colCustomers
    Private _colDrivers As New colDrivers
    Private _colCustStock As New colCustStock
    Private _colBakedGoods As New colBakedGoods

    Private Sub CustomerTab_Init(sender As Object, e As EventArgs) Handles Me.Init

        Dim sError As String = ""
        lblError.Text = ""
        CustomerDB.SetupAdapter()
        DriverDB.SetupAdapter()
        BakedGoodDB.SetupAdapter()

        If _colDrivers.Fill(sError) Then
            FillDriverSelection()
            Session("colDrivers") = _colDrivers
        Else
            lblError.Text += sError + " "
        End If

        If _colBakedGoods.Fill(sError) Then
            RemoveInactiveBakedGoods()
            Session("colBakedGoods") = _colBakedGoods
        Else
            lblError.Text += sError + " "
        End If

        If _colCustomers.Fill(sError) Then
            FillCustomerSelection()
        Else
            lblError.Text += sError + " "
        End If

        LoadCustomerData()

        If lblError.Text <> "" Then
            lblError.Visible = True
        End If
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

    Private Sub RemoveInactiveBakedGoods()
        For i As Integer = _colBakedGoods.Count - 1 To 0 Step -1
            If _colBakedGoods(i).Inactive = True Then
                _colBakedGoods.RemoveAt(i)
            End If
        Next
    End Sub

    Private Sub FillInventoryItems(ByVal ID As Integer)
        'Dynamically create list of inventory items for the customer
        Dim sError As String = ""
        Dim i As Integer = 0
        Dim iMaxLines As Integer

        CustStockDB.CustomerID = ID
        CustStockDB.SetupAdapter()

        If _colCustStock.Fill(sError) = False Then
            lblError.Text += sError + " "
            lblError.Visible = True
        End If

        If _colBakedGoods.Count = 0 Then
            _colBakedGoods = DirectCast(Session("ColBakedGoods"), colBakedGoods)
        End If

        RemoveInactiveCustStock()

        iMaxLines = _colBakedGoods.Count
        iMaxLines -= 1

        pnlInventory.Controls.Clear()
        UpdateCustStockArrays(iMaxLines)
        pnlInventory.Controls.Add(New LiteralControl("<br />"))

        For Each objBakedGood As BakedGood In _colBakedGoods
            CreateCustStockRow(objBakedGood, i)
        Next
    End Sub

    Private Sub UpdateCustStockArrays(ByVal iNoLines As Integer)
        ReDim txtDesired(iNoLines)
        ReDim lblItem(iNoLines)

        For i As Integer = 0 To iNoLines
            txtDesired(i) = New TextBox
            lblItem(i) = New Label
        Next
    End Sub

    Private Sub CreateCustStockRow(ByVal objBakedGood As BakedGood,
                                   ByRef i As Integer)
        Dim objCustStock As CustStock

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

    Private Sub FillCustomerSelection()
        'fill combobox from Customer collection
        Dim sError As String = ""

        ddlCustomer.Items.Clear()
        If _colCustomers.Count = 0 Then
            _colCustomers.Clear()
            If _colCustomers.Fill(sError) = False Then
                lblError.Text += sError
                lblError.Visible = True
            End If
        End If

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
        LoadCustomerData()
    End Sub

    Private Sub LoadCustomerData()
        If ddlCustomer.Text <> "New Customer" Then
            Dim sError As String = ""
            Dim objCustomer As Customer

            If _colCustomers.Count = 0 Then
                If _colCustomers.Fill(sError) = False Then
                    lblError.Text += sError
                    lblError.Visible = True
                End If
            End If

            objCustomer = _colCustomers.Find(Convert.ToInt32(ddlCustomer.SelectedItem.Value))

            With objCustomer
                txtName.Text = .Name
                txtAddress1.Text = .Address1
                txtAddress2.Text = .Address2
                txtCity.Text = .City
                txtState.Text = .State
                txtZip.Text = .Zip
                txtPhone.Text = .Phone
                txtFax.Text = .Fax
                txtEmail.Text = .Email
                chkActive.Checked = .IsActive
                ddlDriver.SelectedIndex = ddlDriver.Items.IndexOf(ddlDriver.Items.FindByValue(.DriverID.ToString))
                FillInventoryItems(.CustomerID)
            End With

            Session("objCustomer") = objCustomer
        End If
    End Sub

    Private Sub FillDriverSelection()
        'fill Driver combobox from Driver collection

        ddlDriver.Items.Clear()

        'todo: Add sorting to colCustomers
        '_colDrivers.Sort() 

        For Each objDriver As Driver In _colDrivers

            'Add the item to the list this way to store the DriverID with the item
            Dim objListItem As New ListItem
            objListItem.Text = objDriver.Name.ToString
            objListItem.Value = objDriver.DriverID.ToString
            ddlDriver.Items.Add(objListItem)
        Next
    End Sub

    Private Sub SaveCustomer()
        Dim objCustomer As New Customer
        Dim objCustomerSaved As New Customer
        Dim sError As String = ""

        'Check that the data is valid
        If IsValidData(objCustomer) Then
            objCustomer.IsActive = chkActive.Checked
            objCustomer.DriverID = Convert.ToInt32(ddlDriver.SelectedItem.Value)
            objCustomer.CustomerID = Convert.ToInt32(ddlCustomer.SelectedItem.Value)

            'Reset colCustomers if necessary
            If _colCustomers.Count = 0 Then
                If _colCustomers.Fill(sError) = False Then
                    lblError.Text += sError + " "
                    lblError.Visible = True
                End If
            End If

            'If CustID not zero, then existing customer
            If objCustomer.CustomerID <> 0 Then
                objCustomerSaved = DirectCast(Session("objCustomer"), Customer)
                If Not objCustomer.LastCountDate Is Nothing Then
                    objCustomer.LastCountDate = objCustomerSaved.LastCountDate
                End If
                If Not objCustomer.LastOrderDate Is Nothing Then
                    objCustomer.LastOrderDate = objCustomerSaved.LastOrderDate
                End If
                _colCustomers.Change(objCustomer)
                'If CustID = 0, then new customer.
            Else
                _colCustomers.Add(objCustomer)
            End If

            SaveInventory()
            CustomerDB.Update()

            'Need to refill colCustomers to account for changes
            _colCustomers.Clear()
            If (_colCustomers.Fill(sError)) Then
                FillCustomerSelection()
                ddlCustomer.SelectedIndex = ddlCustomer.Items.IndexOf(ddlCustomer.Items.FindByText(objCustomer.Name))
            Else
                lblError.Text += sError
                lblError.Visible = True
            End If
        End If
    End Sub
    Private Function IsValidData(ByVal objCustomer As Customer) As Boolean
        Return IsValidName(objCustomer) And
            IsValidAddress1(objCustomer) And
            IsValidAddress2(objCustomer) And
            IsValidCity(objCustomer) And
            IsValidState(objCustomer) And
            IsValidZip(objCustomer) And
            IsValidPhone(objCustomer) And
            IsValidFax(objCustomer) And
            IsValidEmail(objCustomer) And
            IsValidDriver(objCustomer)
    End Function

    Private Function IsValidName(ByVal objCustomer As Customer) As Boolean
        'Name validation
        Try
            objCustomer.Name = txtName.Text
            lblValName.Visible = False
            Return True
        Catch ex As Exception
            txtName.Focus()
            lblValName.Visible = True
            lblValName.Text = ex.Message
            Return False
        End Try
    End Function

    Private Function IsValidAddress1(ByVal objCustomer As Customer) As Boolean
        Try
            objCustomer.Address1 = txtAddress1.Text
            lblValAddress1.Visible = False
            Return True
        Catch ex As Exception
            txtAddress1.Focus()
            lblValAddress1.Visible = True
            lblValAddress1.Text = ex.Message
            Return False
        End Try
    End Function

    Private Function IsValidAddress2(ByVal objCustomer As Customer) As Boolean
        Try
            objCustomer.Address2 = txtAddress2.Text
            lblValAddress2.Visible = False
            Return True
        Catch ex As Exception
            txtAddress2.Focus()
            lblValAddress2.Visible = True
            lblValAddress2.Text = ex.Message
            Return False
        End Try
    End Function

    Private Function IsValidCity(ByVal objCustomer As Customer) As Boolean
        Try
            objCustomer.City = txtCity.Text
            lblValCity.Visible = False
            Return True
        Catch ex As Exception
            txtCity.Focus()
            lblValCity.Visible = True
            lblValCity.Text = ex.Message
            Return False
        End Try
    End Function

    Private Function IsValidState(ByVal objCustomer As Customer) As Boolean
        Try
            objCustomer.State = txtState.Text
            lblValState.Visible = False
            Return True
        Catch ex As Exception
            txtState.Focus()
            lblValState.Visible = True
            lblValState.Text = ex.Message
            Return False
        End Try
    End Function

    Private Function IsValidZip(ByVal objCustomer As Customer) As Boolean
        Try
            objCustomer.Zip = txtZip.Text
            lblValZip.Visible = False
            Return True
        Catch ex As Exception
            txtZip.Focus()
            lblValZip.Visible = True
            lblValZip.Text = ex.Message
            Return False
        End Try
    End Function

    Private Function IsValidPhone(ByVal objCustomer As Customer) As Boolean
        Try
            objCustomer.Phone = txtPhone.Text
            lblValPhone.Visible = False
            Return True
        Catch ex As Exception
            txtPhone.Focus()
            lblValPhone.Visible = True
            lblValPhone.Text = ex.Message
            Return False
        End Try
    End Function

    Private Function IsValidFax(ByVal objCustomer As Customer) As Boolean
        Try
            objCustomer.Fax = txtFax.Text
            lblValFax.Visible = False
            Return True
        Catch ex As Exception
            txtFax.Focus()
            lblValFax.Visible = True
            lblValFax.Text = ex.Message
            Return False
        End Try
    End Function

    Private Function IsValidEmail(ByVal objCustomer As Customer) As Boolean
        Try
            objCustomer.Email = txtEmail.Text
            lblValEmail.Visible = False
            Return True
        Catch ex As Exception
            txtEmail.Focus()
            lblValEmail.Visible = True
            lblValEmail.Text = ex.Message
            Return False
        End Try
    End Function

    Private Function IsValidDriver(ByVal objCustomer As Customer) As Boolean
        Try
            If ddlDriver.SelectedItem.Text <> "Please select" Then
                objCustomer.DriverID = Convert.ToInt32(ddlDriver.SelectedItem.Value)
            End If
            Return True
        Catch ex As Exception
            txtEmail.Focus()
            lblValEmail.Visible = True
            lblValEmail.Text = ex.Message
            Return False
        End Try
    End Function

    Protected Sub btnNewCustomer_Click(sender As Object, e As EventArgs) Handles btnNewCustomer.Click
        SaveCustomer()
        ClearForm()
    End Sub

    Private Sub ClearForm()
        txtName.Text = ""
        txtAddress1.Text = ""
        txtAddress2.Text = ""
        txtCity.Text = ""
        txtState.Text = ""
        txtZip.Text = ""
        txtPhone.Text = ""
        txtFax.Text = ""
        txtZip.Text = ""
        txtEmail.Text = ""
        ddlCustomer.Items.Add("New Customer")
        ddlCustomer.SelectedIndex = ddlCustomer.Items.IndexOf(ddlCustomer.Items.FindByValue("New Customer"))
        ddlCustomer.SelectedItem.Value = Convert.ToString(0)
        ddlDriver.Items.Add("Please select")
        ddlDriver.SelectedIndex = ddlDriver.Items.IndexOf(ddlDriver.Items.FindByValue("Please select"))
        ddlDriver.SelectedItem.Value = Convert.ToString(0)
        chkActive.Checked = False
        Session.Remove("objCustomer")
        pnlInventory.Controls.Clear()
        lblError.Text = ""
        lblError.Visible = False
    End Sub

    Protected Sub btnSaveItem_Click(sender As Object, e As EventArgs) Handles btnSaveItem.Click
        SaveCustomer()
    End Sub

    Private Sub SaveInventory()
        Dim sError As String = ""
        Dim iLength As Integer

        iLength = txtDesired.Count

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

    Private Function GetStockItem(ByVal i As Integer) As CustStock
        Dim CustStock As New CustStock

        CustStock.BakedGoodID = Convert.ToInt32(lblItem(i).Attributes.Item("BakedGoodID"))
        CustStock.DesiredQty = Convert.ToInt32(txtDesired(i).Text)
        CustStock.StockID = Convert.ToInt32(txtDesired(i).Attributes.Item("StockID"))
        CustStock.CustomerID = Convert.ToInt32(ddlCustomer.SelectedItem.Value)
        CustStock.StockQty = Convert.ToInt32(txtDesired(i).Attributes.Item("StockQty"))

        Return CustStock
    End Function

    Private Sub CreateDummyStock(ByVal CustStock As CustStock)
        CustStock.BakedGoodID = 0
        CustStock.DesiredQty = 0
        CustStock.StockQty = 0
        CustStock.StockID = 0
    End Sub

End Class