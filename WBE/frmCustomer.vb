Imports libWBEData
Imports libWBEBR

Public Class frmCustomer
    Private _aStates() As String = {"OR", "WA"}

    Private _colCustomers As New colCustomers
    Private _colDrivers As New colDrivers


    Private Sub frmCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sError As String = ""

        CustomerDB.SetupAdapter()
        DriverDB.SetupAdapter()

        'Fill the data collections

        If _colDrivers.Fill(sError) Then
            FillDriverSelection()
        Else
            MessageBox.Show(sError)
        End If

        loadStates()

        If _colCustomers.Fill(sError) Then
            FillCustomerSelection()
        Else
            MessageBox.Show(sError)
        End If

        'Load the current selected customer data
        LoadCustomerData()

    End Sub

    ''' <summary>
    ''' Load the array of states into the dropdown box
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub loadStates()
        For Each strState As String In _aStates
            cboState.Items.Add(strState)
        Next
    End Sub

    Private Sub FillDriverSelection()
        cboDriver.Items.Clear()

        _colDrivers.Sort()

        For Each objDriver As Driver In _colDrivers
            cboDriver.Items.Add(objDriver)
        Next
    End Sub

    ''' <summary>
    ''' Fills Customer dropdownmenu for selecting the customer
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
    ''' Load the newly selected customer in the dropdownmenu
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadCustomerData()
        If cboCustomer.SelectedIndex <> -1 Then
            Dim objCustomer As New Customer
            objCustomer = cboCustomer.SelectedItem

            With objCustomer
                txtName.Text = .Name
                txtAddress1.Text = .Address1
                txtAddress2.Text = .Address2
                txtCity.Text = .City
                txtZip.Text = .Zip
                txtPhone.Text = .Phone
                txtFax.Text = .Fax
                txtEmail.Text = .Email
                chkInactive.Checked = .IsInactive
                txtContact.Text = .Contact
                SelectDriver(.DriverID)
                If .State <> "" Then
                    cboState.SelectedItem = .State
                Else
                    cboState.SelectedIndex = -1
                End If
            End With

        End If
    End Sub

    ''' <summary>
    ''' Set the driver
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <remarks></remarks>
    Private Sub SelectDriver(ByVal ID As Integer)
        For Each objDriver As Driver In _colDrivers
            If objDriver.DriverID = ID Then
                cboDriver.SelectedItem = objDriver
            End If
        Next
    End Sub

    ''' <summary>
    ''' Change the customer selection
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cboCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCustomer.SelectedIndexChanged
        LoadCustomerData()
    End Sub

    ''' <summary>
    ''' Save the customer record
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveCustomer()
        Dim objCustomer As New Customer
        Dim sError As String = ""
        epCustomer.Clear()

        'Check that the data is valid
        If IsValidData(objCustomer) Then
            objCustomer.IsInactive = chkInactive.Checked
            If cboCustomer.SelectedIndex <> -1 Then
                objCustomer.CustomerID = DirectCast(cboCustomer.SelectedItem, Customer).CustomerID
            Else
                objCustomer.CustomerID = 0
            End If

            'If CustID not zero, then existing customer
            If objCustomer.CustomerID <> 0 Then
                _colCustomers.Change(objCustomer)
            Else  'If CustID = 0, then new customer.
                objCustomer.LastCountDate = Today
                objCustomer.LastOrderDate = Today.AddDays(-1)
                _colCustomers.Add(objCustomer)
            End If

            CustomerDB.Update()

            'Need to refill cbo to account for changes
            _colCustomers.Clear()
            If (_colCustomers.Fill(sError)) Then
                _colCustomers.Sort()
                FillCustomerSelection()
                cboCustomer.SelectedItem = SetCustomerSelection(objCustomer)
            Else
                MessageBox.Show(sError)
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
            IsValidContact(objCustomer) And
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
            Return True
        Catch ex As Exception
            txtName.Focus()
            epCustomer.SetError(txtName, ex.Message)
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
            Return True
        Catch ex As Exception
            txtAddress1.Focus()
            epCustomer.SetError(txtAddress1, ex.Message)
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
            Return True
        Catch ex As Exception
            txtAddress2.Focus()
            epCustomer.SetError(txtAddress2, ex.Message)
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
            Return True
        Catch ex As Exception
            txtCity.Focus()
            epCustomer.SetError(txtCity, ex.Message)
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
            objCustomer.State = cboState.Text
            Return True
        Catch ex As Exception
            cboState.Focus()
            epCustomer.SetError(cboState, ex.Message)
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
            Return True
        Catch ex As Exception
            txtZip.Focus()
            epCustomer.SetError(txtZip, ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Check that contact is valid
    ''' </summary>
    ''' <param name="objCustomer"></param>
    ''' <returns>True if valid</returns>
    ''' <remarks></remarks>
    Private Function IsValidContact(ByVal objCustomer As Customer) As Boolean
        Try
            objCustomer.Contact = txtContact.Text
            Return True
        Catch ex As Exception
            txtContact.Focus()
            epCustomer.SetError(txtContact, ex.Message)
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
            Return True
        Catch ex As Exception
            txtPhone.Focus()
            epCustomer.SetError(txtPhone, ex.Message)
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
            Return True
        Catch ex As Exception
            txtFax.Focus()
            epCustomer.SetError(txtFax, ex.Message)
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
            Return True
        Catch ex As Exception
            txtEmail.Focus()
            epCustomer.SetError(txtEmail, ex.Message)
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
            If cboDriver.SelectedIndex <> -1 Then
                objCustomer.DriverID = DirectCast(cboDriver.SelectedItem, Driver).DriverID
            Else
                epCustomer.SetError(cboDriver, "Driver must be selected.")
                Return False
            End If
            Return True
        Catch ex As Exception
            txtEmail.Focus()
            epCustomer.SetError(cboDriver, ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Save the customer record
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveCustomer()
        btnNew.Text = "&New"
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
        cboState.SelectedIndex = -1
        txtZip.Text = ""
        txtPhone.Text = ""
        txtFax.Text = ""
        txtZip.Text = ""
        txtEmail.Text = ""
        cboCustomer.SelectedIndex = -1
        cboDriver.SelectedIndex = -1
        chkInactive.Checked = False
        txtContact.Text = ""
    End Sub

    ''' <summary>
    ''' Clear the form to allow new record
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        If btnNew.Text = "&New" Then
            ClearForm()
            btnNew.Text = "&Cancel"
        Else
            btnNew.Text = "&New"
            cboCustomer.SelectedIndex = 0
        End If
        
    End Sub

    ''' <summary>
    ''' Gets a customer object without the needing ID
    ''' </summary>
    ''' <param name="objCustomer"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetCustomerSelection(ByVal objCustomer As Customer) As Customer
        For i As Integer = 0 To cboCustomer.Items.Count - 1
            Dim tempCustomer As Customer
            tempCustomer = DirectCast(cboCustomer.Items(i), Customer)
            If tempCustomer.Name <> objCustomer.Name Or
                tempCustomer.Address1 <> objCustomer.Address1 Or
                tempCustomer.Address2 <> objCustomer.Address2 Or
                tempCustomer.City <> objCustomer.City Or
                tempCustomer.State <> objCustomer.State Or
                tempCustomer.Zip <> objCustomer.Zip Or
                tempCustomer.Phone <> objCustomer.Phone Or
                tempCustomer.Fax <> objCustomer.Fax Or
                tempCustomer.Email <> objCustomer.Email Or
                tempCustomer.Contact <> objCustomer.Contact Then
                Continue For
            Else
                Return tempCustomer
            End If
        Next
    End Function

End Class
