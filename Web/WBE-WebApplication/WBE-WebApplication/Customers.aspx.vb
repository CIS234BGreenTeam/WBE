Imports libWBEData
Imports libWBEBR

'Screen Name: Customers

'Designer: Kristina Frye

'Purpose: Allow Customer/WBE personnel to view profile and update 
'customer contact information.

'Also allow customer to maintain stock of goods including desired inventory levels. 

'Inactive: When a customer record is set to "inactive", orders will not be
'generated for that customer.

'Baked Good item: The customer can maintain an inventory of baked goods.
'Use the Baked Good drop-down menu to modify the item selection.
'Use the "Desired" inventory textboxes to input the desired inventory of the item 
'listed. 

'Add Item: This will add another line to the inventory area. The customer can
'selected from any active baked good offered by WBE minus items already listed (available in the 
'drop-down menu)

'Delete Item: This will delete the selected inventory line item. The selected line
'item is indicated with a "*" to the right of the "Actual" inventory textbox. When
'the user changes the screen focus to one of the line item text boxes or 
'drop-down list, the list will be selected. (The "*" will become visible to denote
'the selection)

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
    Dim cboItem() As DropDownList
    Dim lblDesired() As Label
    Dim lblSelected() As Label

    Private _colCustomers As New colCustomers
    Private _colDrivers As New colDrivers
    Private _colCustStock As New colCustStock
    Private _colBakedGoods As New colBakedGoods

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
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

            If _colCustomers.Fill(sError) Then
                FillCustomerSelection()
            Else
                lblError.Text += sError + " "
            End If

            'todo: Display error message
            If _colBakedGoods.Fill(sError) Then
                Session("colBakedGoods") = _colBakedGoods
            Else
                lblError.Text += sError + " "
            End If

            LoadCustomerData()

            lblSelected(0).Visible = True 'Identifies which inventory item is selected

            If lblError.Text <> "" Then
                lblError.Visible = True
            End If
        End If

    End Sub
    Private Sub FillInventoryItems(ByVal ID As Integer)
        'Dynamically create list of inventory items for the customer
        Dim sError As String = ""
        Dim i As Integer
        Dim iNoLines As Integer

        CustStockDB.CustomerID = ID
        CustStockDB.SetupAdapter()

        'todo: add error message
        If _colCustStock.Fill(sError) Then
            iNoLines = _colCustStock.Count
        Else
            lblError.Text += sError
            lblError.Visible = True
        End If

        pnlInventory.Controls.Clear()

        ReDim txtDesired(iNoLines)
        ReDim cboItem(iNoLines)
        ReDim lblDesired(iNoLines)
        ReDim lblSelected(iNoLines)

        pnlInventory.Controls.Add(New LiteralControl("<br />"))

        For Each objCustStock As CustStock In _colCustStock
            'Dropdownlist for Baked Good items
            cboItem(i) = New DropDownList
            FillBakedItemList(cboItem(i)) 'This function will fill the drop-down list of available items
            cboItem(i).Items.FindByValue(objCustStock.BakedGoodID.ToString).Selected = True
            pnlInventory.Controls.Add(cboItem(i))
            pnlInventory.Controls.Add(New LiteralControl("&nbsp;"))
            pnlInventory.Controls.Add(New LiteralControl("&nbsp;"))
            pnlInventory.Controls.Add(New LiteralControl("&nbsp;"))

            'Label for "desired" textbox
            lblDesired(i) = New Label
            lblDesired(i).Text = "Desired"
            lblDesired(i).Width = 50
            pnlInventory.Controls.Add(lblDesired(i))

            'Textbox for desired quantity
            txtDesired(i) = New TextBox
            txtDesired(i).Width = 25
            txtDesired(i).Text = objCustStock.DesiredQty.ToString
            pnlInventory.Controls.Add(txtDesired(i))
            pnlInventory.Controls.Add(New LiteralControl("&nbsp;"))
            pnlInventory.Controls.Add(New LiteralControl("&nbsp;"))
            pnlInventory.Controls.Add(New LiteralControl("&nbsp;"))

            'Label to show selected item
            lblSelected(i) = New Label
            lblSelected(i).Text = "*"
            lblSelected(i).Visible = False
            pnlInventory.Controls.Add(lblSelected(i))

            'Add next item on next line
            pnlInventory.Controls.Add(New LiteralControl("<br />"))
        Next
    End Sub

    Private Sub FillBakedItemList(ByVal cboItem As DropDownList)
        'This function will add the actual available baked goods
        _colBakedGoods = DirectCast(Session("colBakedGoods"), colBakedGoods)
        For Each objBakedGood As BakedGood In _colBakedGoods
            Dim objListItem As New ListItem
            objListItem.Text = objBakedGood.Name
            objListItem.Value = objBakedGood.BakedGoodID.ToString
            cboItem.Items.Add(objListItem)
        Next
    End Sub

    Private Sub FillCustomerSelection()
        'fill Course combobox from Customer collection
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
            Dim objCustomer As New Customer

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

    Protected Sub btnSaveCustomer_Click(sender As Object, e As EventArgs) Handles btnSaveCustomer.Click
        Save()
    End Sub

    Private Sub Save()
        Dim objCustomer As New Customer
        Dim objCustomerSaved As New Customer
        Dim sError As String = ""

        If IsValidData(objCustomer) Then
            objCustomer.IsActive = chkActive.Checked
            objCustomer.DriverID = Convert.ToInt32(ddlDriver.SelectedItem.Value)
            objCustomer.CustomerID = Convert.ToInt32(ddlCustomer.SelectedItem.Value)

            If _colCustomers.Count = 0 Then
                If _colCustomers.Fill(sError) = False Then
                    lblError.Text += sError + " "
                    lblError.Visible = True
                End If
            End If

            If objCustomer.CustomerID <> 0 Then
                objCustomerSaved = DirectCast(Session("objCustomer"), Customer)
                If Not objCustomer.LastCountDate Is Nothing Then
                    objCustomer.LastCountDate = objCustomerSaved.LastCountDate
                End If
                If Not objCustomer.LastOrderDate Is Nothing Then
                    objCustomer.LastOrderDate = objCustomerSaved.LastOrderDate
                End If
                _colCustomers.Change(objCustomer)
            Else
                _colCustomers.Add(objCustomer)
            End If

            FillInventoryItems(objCustomer.CustomerID)
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
        Save()
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

End Class