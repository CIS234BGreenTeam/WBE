﻿Imports libWBEData
Imports libWBEBR

Public Class frmCustomer
    Private _colCustomers As New colCustomers
    Private _colDrivers As New colDrivers

    Private Sub frmCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sError As String = ""

        CustomerDB.SetupAdapter()
        DriverDB.SetupAdapter()

        'Fill the data collections

        'todo: Add error checking
        If _colDrivers.Fill(sError) Then
            FillDriverSelection()
        End If

        If _colCustomers.Fill(sError) Then
            FillCustomerSelection()
        End If

        'Load the current selected customer data
        LoadCustomerData()

    End Sub

    Private Sub FillDriverSelection()
        cboDriver.Items.Clear()

        'todo: Add sorting to colDrivers
        '_colDrivers.Sort() 

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
        If _colCustomers.Count = 0 Then
            _colCustomers.Clear()
            If _colCustomers.Fill(sError) = False Then
                'todo: Add error checking
            End If
        End If

        'todo: Add sorting to colCustomers
        '_colCustomers.Sort() 

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
        If cboCustomer.Text <> "New Customer" Then
            Dim sError As String = ""
            Dim objCustomer As New Customer

            'Get customer object from the ID stored in the ddl
            objCustomer = cboCustomer.SelectedItem

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
                chkInactive.Checked = .IsActive
                SelectDriver(.DriverID)
            End With

        End If
    End Sub

    Private Sub SelectDriver(ByVal ID As Integer)
        For Each objDriver As Driver In _colDrivers
            If objDriver.DriverID = ID Then
                cboDriver.SelectedItem = objDriver
            End If
        Next
    End Sub


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
            objCustomer.IsActive = chkInactive.Checked
            objCustomer.DriverID = DirectCast(cboDriver.SelectedItem, Driver).DriverID
            objCustomer.CustomerID = DirectCast(cboCustomer.SelectedItem, Customer).CustomerID

            'If CustID not zero, then existing customer
            If objCustomer.CustomerID <> 0 Then
                _colCustomers.Change(objCustomer)

            Else  'If CustID = 0, then new customer.
                _colCustomers.Add(objCustomer)
            End If

            CustomerDB.Update()

            'Need to refill dropdownlist to account for changes
            _colCustomers.Clear()
            If (_colCustomers.Fill(sError)) Then
                FillCustomerSelection()
                cboCustomer.SelectedItem = objCustomer
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
            objCustomer.State = txtState.Text
            Return True
        Catch ex As Exception
            txtState.Focus()
            epCustomer.SetError(txtState, ex.Message)
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
            End If
            Return True
        Catch ex As Exception
            txtEmail.Focus()
            epCustomer.SetError(cboDriver, ex.Message)
            Return False
        End Try
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveCustomer()
    End Sub
End Class
