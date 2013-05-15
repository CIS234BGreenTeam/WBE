Imports libWBEData
Imports libWBEBR

'Screen Name: Customers

'Designer: Kristina Frye

'Purpose: Allow Customer/WBE personnel to view profile and update 
'customer contact information.

'Save Customer: Save any changes to the customer contact information
'to the database.

'New Customer: Create a new customer record (clear form)

'Note: Customers cannot be deleted from the WBE database. They
'can only be made inactive.

Public Class CustomerTab
    Inherits System.Web.UI.Page

    Private _colCustomers As New colCustomers
    Private _colDrivers As New colDrivers

    Private Sub CustomerTab_Init(sender As Object, e As EventArgs) Handles Me.Init

        Dim sError As String = ""
        lblError.Text = ""
        CustomerDB.SetupAdapter()
        DriverDB.SetupAdapter()

        'Fill the data collections
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

        'Load the current selected customer data
        LoadCustomerData()

        If lblError.Text <> "" Then
            lblError.Visible = True
        End If
    End Sub
    ''' <summary>
    ''' Fills Customer dropdownmenu for selecting the customer
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillCustomerSelection()
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
            Dim objListItem As New ListItem
            objListItem.Text = objCustomer.ToString
            objListItem.Value = objCustomer.CustomerID.ToString
            ddlCustomer.Items.Add(objListItem)
        Next
    End Sub
    ''' <summary>
    ''' Called when the dropdownlist is changed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ddlCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCustomer.SelectedIndexChanged
        LoadCustomerData()
    End Sub

    ''' <summary>
    ''' Load the newly selected customer in the dropdownmenu
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadCustomerData()
        If ddlCustomer.Text <> "New Customer" Then
            Dim sError As String = ""
            Dim objCustomer As New Customer

            'Put this in case the data did not persist
            If _colCustomers.Count = 0 Then
                If _colCustomers.Fill(sError) = False Then
                    lblError.Text += sError
                    lblError.Visible = True
                End If
            End If

            'Get customer object from the ID stored in the ddl
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
            End With

            'Store customer in a cookie
            Session("objCustomer") = objCustomer
        End If
    End Sub

    ''' <summary>
    ''' Fill driver selection dropdownlist
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillDriverSelection()
        ddlDriver.Items.Clear()

        'todo: Add sorting to colDrivers
        '_colDrivers.Sort() 

        For Each objDriver As Driver In _colDrivers

            'Add the item to the list this way to store the DriverID with the item
            Dim objListItem As New ListItem
            objListItem.Text = objDriver.Name.ToString
            objListItem.Value = objDriver.DriverID.ToString
            ddlDriver.Items.Add(objListItem)
        Next
    End Sub

    ''' <summary>
    ''' Save the customer record
    ''' </summary>
    ''' <remarks></remarks>
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

            Else  'If CustID = 0, then new customer.
                _colCustomers.Add(objCustomer)
            End If

            CustomerDB.Update()

            'Need to refill dropdownlist to account for changes
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
    ''' <summary>
    ''' Check data is valid
    ''' </summary>
    ''' <param name="objCustomer"></param>
    ''' <returns>True if valid</returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' Check that name is valid
    ''' </summary>
    ''' <param name="objCustomer"></param>
    ''' <returns>True if valid</returns>
    ''' <remarks></remarks>
    Private Function IsValidName(ByVal objCustomer As Customer) As Boolean
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

    ''' <summary>
    ''' Check that address1 is valid
    ''' </summary>
    ''' <param name="objCustomer"></param>
    ''' <returns>True if valid</returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' Check that address2 is valid
    ''' </summary>
    ''' <param name="objCustomer"></param>
    ''' <returns>True if valid</returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' Check that city is valid
    ''' </summary>
    ''' <param name="objCustomer"></param>
    ''' <returns>True if valid</returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' Check that state is valid
    ''' </summary>
    ''' <param name="objCustomer"></param>
    ''' <returns>True if valid</returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' Check that zip is valid
    ''' </summary>
    ''' <param name="objCustomer"></param>
    ''' <returns>True if valid</returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' Check that phone is valid
    ''' </summary>
    ''' <param name="objCustomer"></param>
    ''' <returns>True if valid</returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' Check that fax is valid
    ''' </summary>
    ''' <param name="objCustomer"></param>
    ''' <returns>True if valid</returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' Check that email is valid
    ''' </summary>
    ''' <param name="objCustomer"></param>
    ''' <returns>True if valid</returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' Check that driver is valid
    ''' </summary>
    ''' <param name="objCustomer"></param>
    ''' <returns>true if valid</returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' Creates new customer, clears form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnNewCustomer_Click(sender As Object, e As EventArgs) Handles btnNewCustomer.Click
        SaveCustomer()
        ClearForm()
    End Sub

    ''' <summary>
    ''' Clears form
    ''' </summary>
    ''' <remarks></remarks>
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
        lblError.Text = ""
        lblError.Visible = False
    End Sub

    ''' <summary>
    ''' Saves customer record
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnSaveItem_Click(sender As Object, e As EventArgs) Handles btnSaveItem.Click
        SaveCustomer()
    End Sub

End Class