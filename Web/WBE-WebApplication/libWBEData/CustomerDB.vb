Imports libWBEBR

Public Class CustomerDB
    Inherits WBEData

    'This is used temporarily as the ID until the real one's found
    Private Shared _iTempLastID As Integer

    ''' <summary>
    ''' Fills the Customer collection
    ''' </summary>
    ''' <param name="colCustomers">the collection that will be filled</param>
    ''' <param name="sError">error generated (if any)</param>
    ''' <returns>
    ''' True - if no error
    ''' False if Error (in this case sError will have the error generated)
    ''' </returns>
    ''' <remarks></remarks>
    Shared Function Fill(ByVal colCustomers As List(Of Customer),
                        ByRef sError As String) As Boolean
        Try

            Dim objCustomer As Customer

            'If filled a second time, clear the datatable first
            If Not dtCustomers Is Nothing Then
                dtCustomers.Clear()
            End If

            daCustomers.Fill(dsWBE, "Customers")
            dtCustomers = dsWBE.Tables("Customers")

            For Each dr As DataRow In dtCustomers.Rows
                objCustomer = New Customer
                With objCustomer
                    .CustomerID = Convert.ToInt32(dr("CustomerID"))
                    .DriverID = Convert.ToInt32(dr("DriverID"))
                    .Name = dr("Name").ToString
                    .Address1 = dr("Address1").ToString
                    .Address2 = dr("Address2").ToString
                    .City = dr("City").ToString
                    .State = dr("State").ToString
                    .Zip = dr("Zip").ToString
                    .Phone = dr("Phone").ToString
                    .Fax = dr("Fax").ToString
                    .Email = dr("Email").ToString
                    .Contact = dr("Contact").ToString
                    .IsActive = Convert.ToBoolean(dr("IsActive"))

                    If _iTempLastID < .CustomerID Then
                        _iTempLastID = .CustomerID
                    End If

                    If Not dr("LastCountDate") Is DBNull.Value Then
                        .LastCountDate = Convert.ToDateTime(dr("LastCountDate"))
                    End If

                    If Not dr("LastOrderDate") Is DBNull.Value Then
                        .LastOrderDate = Convert.ToDateTime(dr("LastOrderDate"))
                    End If
                End With

                colCustomers.Add(objCustomer)

            Next
            Return True
        Catch ex As Exception
            sError = ex.Message
            Return False
        End Try
    End Function
    ''' <summary>
    ''' Updates the DataTable to the database
    ''' </summary>
    ''' <remarks>Captures the Actual ID that's used in the database</remarks>
    Shared Sub Update()
        AddHandler daCustomers.RowUpdated, New SqlClient.SqlRowUpdatedEventHandler(AddressOf OnRowUpdated)
        daCustomers.Update(dsWBE, "Customers")
    End Sub

    Private Shared Sub OnRowUpdated(sender As Object, args As SqlClient.SqlRowUpdatedEventArgs)
        ' Captures the actual ID that is used  
        Dim newID As Integer = 0
        Dim idCMD As SqlClient.SqlCommand = New SqlClient.SqlCommand("SELECT @@IDENTITY", connWBE)

        If args.StatementType = StatementType.Insert Then
            newID = CInt(idCMD.ExecuteScalar())
            args.Row("CustomerID") = newID
            If _iTempLastID < newID Then
                _iTempLastID = newID
            End If
        End If
    End Sub

    ''' <summary>
    ''' Adds a customer to the DataTable
    ''' </summary>
    ''' <param name="objCustomer">Customer to add</param>
    ''' <remarks>
    ''' assigns a temporary ID at this time
    ''' </remarks>
    Shared Sub Add(ByVal objCustomer As Customer)
        '*************************************************************
        '*  Add a Customer object to the datatable
        '*************************************************************
        Dim drCustomer As DataRow

        drCustomer = dtCustomers.NewRow

        _iTempLastID += 1
        objCustomer.CustomerID = _iTempLastID
        CopyToDataRow(objCustomer, drCustomer)

        dtCustomers.Rows.Add(drCustomer)
    End Sub

    ''' <summary>
    ''' deletes a customer from the datatable
    ''' </summary>
    ''' <param name="objCustomer">customer to delete</param>
    ''' <remarks></remarks>
    Shared Sub Delete(ByVal objCustomer As Customer)
        '*************************************************************
        '*  Delete from DataTable
        '*************************************************************
        Const c_strNoRecordToDeleteError As String = "No Record To Delete"
        Const c_strManyRecordsToDeleteError As String = "More than one Record To Delete"

        Dim drCustomerRow() As DataRow
        drCustomerRow = FindRow(objCustomer.CustomerID)
        Select Case drCustomerRow.Length
            Case 1
                drCustomerRow(0).Delete()
            Case 0
                Throw New Exception(c_strNoRecordToDeleteError)
            Case Else
                Throw New Exception(c_strManyRecordsToDeleteError)
        End Select

    End Sub

    ''' <summary>
    ''' Change a Customer in the DataTable
    ''' </summary>
    ''' <param name="objCustomer">Customer to change</param>
    ''' <remarks></remarks>
    Shared Sub Change(ByVal objCustomer As Customer)

        Const c_strNoRecordToChangeError As String = "No Record To Change"
        Const c_strManyRecordsToChangeError As String = "More than one Record To Change"

        Dim drCustomerRow() As DataRow

        With objCustomer
            drCustomerRow = FindRow(.CustomerID)

            Select Case drCustomerRow.Length
                Case 1
                    CopyToDataRow(objCustomer, drCustomerRow(0))
                Case 0
                    Throw New Exception(c_strNoRecordToChangeError)
                Case Else
                    Throw New Exception(c_strManyRecordsToChangeError)
            End Select
        End With

    End Sub

    Shared Sub CopyToDataRow(ByVal objCustomer As Customer,
                             ByVal drCustomer As DataRow)
        '*************************************************************************
        '   Copies Customer to datarow
        '*************************************************************************
        With objCustomer
            drCustomer("CustomerID") = .CustomerID
            drCustomer("DriverID") = .DriverID
            drCustomer("Name") = .Name
            drCustomer("Address1") = .Address1
            drCustomer("Address2") = .Address2
            drCustomer("City") = .City
            drCustomer("State") = .State
            drCustomer("Zip") = .Zip
            drCustomer("Phone") = .Phone
            drCustomer("Fax") = .Fax
            drCustomer("Email") = .Email
            drCustomer("Contact") = .Contact
            drCustomer("IsActive") = .IsActive

            If .LastCountDate.HasValue Then
                drCustomer("LastCountDate") = .LastCountDate
            Else
                drCustomer("LastCountDate") = DBNull.Value
            End If

            If .LastOrderDate.HasValue Then
                drCustomer("LastOrderDate") = .LastOrderDate
            Else
                drCustomer("LastOrderDate") = DBNull.Value
            End If
        End With
    End Sub

    Shared Function FindRow(ByVal iID As Integer) As DataRow()
        '*************************************************************************
        '*  returns a row from the data table whose CustomerID matches the parameter strID
        '*************************************************************************
        Return dtCustomers.Select("CustomerID  = '" & iID & "'")
    End Function

    ''' <summary>
    ''' Sets up the DataAdapter for the Customer Table
    ''' </summary>
    ''' <remarks>
    ''' Establishes the SelectCommand, InsertCommand, UpdateCommand, DeleteCommand properties
    ''' </remarks>
    Shared Sub SetupAdapter()
        With daCustomers
            .SelectCommand = connWBE.CreateCommand
            .InsertCommand = connWBE.CreateCommand
            .UpdateCommand = connWBE.CreateCommand
            .DeleteCommand = connWBE.CreateCommand

            .SelectCommand.CommandText = "Select CustomerID, DriverID, Name, Address1, Address2, " +
                "City, State, Zip, Phone, Fax, Email, Contact, LastOrderDate, LastCountDate, " +
                "IsActive from Customer"

            With .InsertCommand
                .CommandText = "Insert Into Customer(DriverID, Name, Address1, Address2, " +
                    "City, State, Zip, Phone, Fax, Email, Contact, LastOrderDate, LastCountDate, " +
                    "IsActive) Values(@DriverID, @Name, @Address1, @Address2, @City, @State, @Zip, " +
                    "@Phone, @Fax, @Email, @Contact, @LastOrderDate, @LastCountDate, @IsActive)"

                With .Parameters
                    .AddWithValue("@DriverID", SqlDbType.Int).SourceColumn = "DriverID"
                    .AddWithValue("@Name", SqlDbType.VarChar).SourceColumn = "Name"
                    .AddWithValue("@Address1", SqlDbType.VarChar).SourceColumn = "Address1"
                    .AddWithValue("@Address2", SqlDbType.VarChar).SourceColumn = "Address2"
                    .AddWithValue("@City", SqlDbType.VarChar).SourceColumn = "City"
                    .AddWithValue("@State", SqlDbType.VarChar).SourceColumn = "State"
                    .AddWithValue("@Zip", SqlDbType.VarChar).SourceColumn = "Zip"
                    .AddWithValue("@Phone", SqlDbType.VarChar).SourceColumn = "Phone"
                    .AddWithValue("@Fax", SqlDbType.VarChar).SourceColumn = "Fax"
                    .AddWithValue("@Email", SqlDbType.VarChar).SourceColumn = "Email"
                    .AddWithValue("@Contact", SqlDbType.VarChar).SourceColumn = "Contact"
                    .AddWithValue("@LastOrderDate", SqlDbType.Date).SourceColumn = "LastOrderDate"
                    .AddWithValue("@LastCountDate", SqlDbType.Date).SourceColumn = "LastCountDate"
                    .AddWithValue("@IsActive", SqlDbType.Int).SourceColumn = "IsActive"
                End With
            End With

            With .UpdateCommand
                .CommandText = "Update Customer Set DriverID = @DriverID, Name = @Name, Address1 = @Address1, " &
                                "Address2 = @Address2, City = @City, State = @State, Zip = @Zip, " &
                                "Phone = @Phone, Fax = @Fax, Email = @Email, Contact = @Contact, " &
                                "LastOrderDate = @LastOrderDate, LastCountDate = @LastCountDate, " &
                                "IsActive = @IsActive Where CustomerID = @CustomerID"
                With .Parameters
                    .AddWithValue("@DriverID", SqlDbType.Int).SourceColumn = "DriverID"
                    .AddWithValue("@Name", SqlDbType.VarChar).SourceColumn = "Name"
                    .AddWithValue("@Address1", SqlDbType.VarChar).SourceColumn = "Address1"
                    .AddWithValue("@Address2", SqlDbType.VarChar).SourceColumn = "Address2"
                    .AddWithValue("@City", SqlDbType.VarChar).SourceColumn = "City"
                    .AddWithValue("@State", SqlDbType.VarChar).SourceColumn = "State"
                    .AddWithValue("@Zip", SqlDbType.VarChar).SourceColumn = "Zip"
                    .AddWithValue("@Phone", SqlDbType.VarChar).SourceColumn = "Phone"
                    .AddWithValue("@Fax", SqlDbType.VarChar).SourceColumn = "Fax"
                    .AddWithValue("@Email", SqlDbType.VarChar).SourceColumn = "Email"
                    .AddWithValue("@Contact", SqlDbType.VarChar).SourceColumn = "Contact"
                    .AddWithValue("@LastOrderDate", SqlDbType.Date).SourceColumn = "LastOrderDate"
                    .AddWithValue("@LastCountDate", SqlDbType.Date).SourceColumn = "LastCountDate"
                    .AddWithValue("@IsActive", SqlDbType.Int).SourceColumn = "IsActive"
                    .AddWithValue("@CustomerID", SqlDbType.Int).SourceColumn = "CustomerID"
                End With
            End With

            With .DeleteCommand
                .CommandText = "Delete from Customer Where CustomerID = @CustomerID"
                With .Parameters
                    .AddWithValue("@CustomerID", SqlDbType.Int).SourceColumn = "CustomerID"
                End With
            End With
        End With
    End Sub

End Class
