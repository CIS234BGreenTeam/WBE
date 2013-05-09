Imports libWBEBR


Public Class OrdersDB

    Inherits WBEData
    Public Shared Property OrderID As Integer
    Public Shared Property CustomerID As Integer

    'This is used temporarily as the ID until the real one's found
    Private Shared _iTempLastID As Integer

    ''' <summary>
    ''' Fills the Orders collection
    ''' </summary>
    ''' <param name="colOrders">the collection that will be filled</param>
    ''' <param name="sError">error generated (if any)</param>
    ''' <returns>
    ''' True - if no error
    ''' False if Error (in this case sError will have the error generated)
    ''' </returns>
    ''' <remarks></remarks>
    Shared Function Fill(ByVal colOrders As List(Of Orders),
                        ByRef sError As String) As Boolean
        Try

            Dim objOrders As Orders

            'If filled a second time, clear the datatable first
            If Not dtOrders Is Nothing Then
                dtOrders.Clear()
            End If

            daOrders.Fill(dsWBE, "Orders")
            dtOrders = dsWBE.Tables("Orders")

            For Each dr As DataRow In dtOrders.Rows
                objOrders = New Orders
                With objOrders
                    .OrderID = Convert.ToInt32(dr("OrderID"))
                    .OrderDate = Convert.ToDateTime(dr("OrderDate"))
                    .Status = Convert.ToString(dr("Status"))
                    .CustomerID = Convert.ToInt32(dr("CustomerID"))

                    If _iTempLastID < .OrderID Then
                        _iTempLastID = .OrderID
                    End If

                End With

                colOrders.Add(objOrders)

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
        AddHandler daOrders.RowUpdated, New SqlClient.SqlRowUpdatedEventHandler(AddressOf OnRowUpdated)
        daOrders.Update(dsWBE, "Orders")
    End Sub

    Private Shared Sub OnRowUpdated(sender As Object, args As SqlClient.SqlRowUpdatedEventArgs)
        ' Captures the actual ID that is used  
        Dim newID As Integer = 0
        Dim idCMD As SqlClient.SqlCommand = New SqlClient.SqlCommand("SELECT @@IDENTITY", connWBE)

        If args.StatementType = StatementType.Insert Then
            newID = CInt(idCMD.ExecuteScalar())
            args.Row("OrderItemID") = newID
            If _iTempLastID < newID Then
                _iTempLastID = newID
            End If
        End If
    End Sub

    ''' <summary>
    ''' Adds a Orders to the DataTable
    ''' </summary>
    ''' <param name="objOrders">Orders to add</param>
    ''' <remarks>
    ''' assigns a temporary ID at this time
    ''' </remarks>
    Shared Sub Add(ByVal objOrders As Orders)
        '*************************************************************
        '*  Add a Orders object to the datatable
        '*************************************************************
        Dim drOrders As DataRow

        drOrders = dtOrders.NewRow

        _iTempLastID += 1
        objOrders.OrderID = _iTempLastID
        CopyToDataRow(objOrders, drOrders)

        dtOrders.Rows.Add(drOrders)
    End Sub

    ''' <summary>
    ''' deletes a Orders from the datatable
    ''' </summary>
    ''' <param name="objOrders">Orders to delete</param>
    ''' <remarks></remarks>
    Shared Sub Delete(ByVal objOrders As Orders)
        '*************************************************************
        '*  Delete from DataTable
        '*************************************************************
        Const c_strNoRecordToDeleteError As String = "No Record To Delete"
        Const c_strManyRecordsToDeleteError As String = "More than one Record To Delete"

        Dim drOrdersRow() As DataRow
        drOrdersRow = FindRow(objOrders.OrderID)
        Select Case drOrdersRow.Length
            Case 1
                drOrdersRow(0).Delete()
            Case 0
                Throw New Exception(c_strNoRecordToDeleteError)
            Case Else
                Throw New Exception(c_strManyRecordsToDeleteError)
        End Select

    End Sub

    ''' <summary>
    ''' Change a Orders in the DataTable
    ''' </summary>
    ''' <param name="objOrders">Orders to change</param>
    ''' <remarks></remarks>
    Shared Sub Change(ByVal objOrders As Orders)

        Const c_strNoRecordToChangeError As String = "No Record To Change"
        Const c_strManyRecordsToChangeError As String = "More than one Record To Change"

        Dim drOrdersRow() As DataRow

        With objOrders
            drOrdersRow = FindRow(.OrderID)

            Select Case drOrdersRow.Length
                Case 1
                    CopyToDataRow(objOrders, drOrdersRow(0))
                Case 0
                    Throw New Exception(c_strNoRecordToChangeError)
                Case Else
                    Throw New Exception(c_strManyRecordsToChangeError)
            End Select
        End With

    End Sub

    Shared Sub CopyToDataRow(ByVal objOrders As Orders,
                             ByVal drOrders As DataRow)
        '*************************************************************************
        '   Copies Orders to datarow
        '*************************************************************************
        With objOrders
            drOrders("OrderID") = .OrderID
            drOrders("OrderDate") = .OrderDate
            drOrders("Status") = .Status
            drOrders("CustomerID") = .CustomerID
        End With
    End Sub

    Shared Function FindRow(ByVal iID As Integer) As DataRow()
        '*************************************************************************
        '*  returns a row from the data table whose OrdersID matches the parameter strID
        '*************************************************************************
        Return dtOrders.Select("OrderID  = '" & iID & "'")
    End Function

    ''' <summary>
    ''' Sets up the DataAdapter for the Orders Table
    ''' </summary>
    ''' <remarks>
    ''' Establishes the SelectCommand, InsertCommand, UpdateCommand, DeleteCommand properties
    ''' </remarks>
    Shared Sub SetupAdapter()
        With daOrders
            .SelectCommand = connWBE.CreateCommand
            .InsertCommand = connWBE.CreateCommand
            .UpdateCommand = connWBE.CreateCommand
            .DeleteCommand = connWBE.CreateCommand

            .SelectCommand.CommandText = "SELECT OrderID, OrderDate, Status, CustomerID " +
                                         "FROM Orders WHERE CustomerID = @CustomerID"

            With .SelectCommand.Parameters
                .AddWithValue("@CustomerID", SqlDbType.SmallInt).Value = CustomerID
            End With

            With .InsertCommand
                .CommandText = "INSERT INTO Orders(OrderID, OrderDate, Status, CustomerID) " +
                                "VALUES(@OrderID, @OrderDate, @Status, @CustomerID)"

                With .Parameters
                    .AddWithValue("@OrderID", SqlDbType.Int).SourceColumn = "OrderID"
                    .AddWithValue("@OrderDate", SqlDbType.DateTime).SourceColumn = "OrderDate"
                    .AddWithValue("@Status", SqlDbType.VarChar).SourceColumn = "Status"
                    .AddWithValue("@CustomerID", SqlDbType.SmallInt).SourceColumn = "CustomerID"
                End With
            End With

            With .UpdateCommand
                .CommandText = "UPDATE Orders" +
                               "Set OrderDate = @OrderDate, Status = @Status, CustomerID = @CustomerID" +
                               "Where OrderID = @OrderID"

                With .Parameters
                    .AddWithValue("@OrderID", SqlDbType.SmallInt).SourceColumn = "OrderID"
                    .AddWithValue("@OrderDate", SqlDbType.DateTime).SourceColumn = "OrderDate"
                    .AddWithValue("@Status", SqlDbType.VarChar).SourceColumn = "Status"
                    .AddWithValue("@CustomerID", SqlDbType.SmallInt).SourceColumn = "CustomerID"

                End With
            End With

            With .DeleteCommand
                .CommandText = "Delete from Orders" +
                               "Where OrderItemID = @OrderItemID"
                With .Parameters
                    .AddWithValue("@OrderID", SqlDbType.SmallInt).SourceColumn = "OrderID"
                End With
            End With
        End With
    End Sub


End Class


