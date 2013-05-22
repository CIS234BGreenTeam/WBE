Imports libWBEBR
'*************************************************************
'*  Class       OrderItemsDB
'*  Programmer  Dan Dougherty (Modified by Ken Baker for WBE Project)
'*  Date        Apr 2013
'*
'*  OrderItems Database
'*************************************************************

Public Class OrderItemDB
    Inherits WBEData
    Public Shared Property OrderID As Integer

    'This is used temporarily as the ID until the real one's found
    Private Shared _iTempLastID As Integer

    ''' <summary>
    ''' Fills the OrderItem collection
    ''' </summary>
    ''' <param name="colOrderItems">the collection that will be filled</param>
    ''' <param name="sError">error generated (if any)</param>
    ''' <returns>
    ''' True - if no error
    ''' False if Error (in this case sError will have the error generated)
    ''' </returns>
    ''' <remarks></remarks>
    Shared Function Fill(ByVal colOrderItems As List(Of OrderItem),
                        ByRef sError As String) As Boolean
        Try

            Dim objOrderItem As OrderItem


            'If filled a second time, clear the datatable first
            If Not dtOrderItem Is Nothing Then
                dtOrderItem.Clear()
            End If

            daOrderItem.Fill(dsWBE, "OrderItems")
            dtOrderItem = dsWBE.Tables("OrderItems")

            For Each dr As DataRow In dtOrderItem.Rows
                objOrderItem = New OrderItem
                With objOrderItem
                    .OrderItemID = Convert.ToInt32(dr("OrderItemID"))
                    .Quantity = Convert.ToInt32(dr("Quantity"))
                    .BakedGoodID = Convert.ToInt32(dr("BakedGoodID"))
                    .OrderID = Convert.ToInt32(dr("OrderID"))
                    .UnitPrice = Convert.ToDecimal(dr("Price"))
                    .Name = dr("Name").ToString

                    If _iTempLastID < .OrderItemID Then
                        _iTempLastID = .OrderItemID
                    End If

                End With

                colOrderItems.Add(objOrderItem)
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
        AddHandler daOrderItem.RowUpdated, New SqlClient.SqlRowUpdatedEventHandler(AddressOf OnRowUpdated)
        daOrderItem.Update(dsWBE, "OrderItems")
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
    ''' Adds a OrderItem to the DataTable
    ''' </summary>
    ''' <param name="objOrderItem">OrderItem to add</param>
    ''' <remarks>
    ''' assigns a temporary ID at this time
    ''' </remarks>
    Shared Sub Add(ByVal objOrderItem As OrderItem)
        '*************************************************************
        '*  Add a OrderItem object to the datatable
        '*************************************************************
        Dim drOrderItem As DataRow

        drOrderItem = dtOrderItem.NewRow

        _iTempLastID += 1
        objOrderItem.OrderItemID = _iTempLastID
        CopyToDataRow(objOrderItem, drOrderItem)

        dtOrderItem.Rows.Add(drOrderItem)
    End Sub

    ''' <summary>
    ''' deletes a OrderItem from the datatable
    ''' </summary>
    ''' <param name="objOrderItem">OrderItem to delete</param>
    ''' <remarks></remarks>
    Shared Sub Delete(ByVal objOrderItem As OrderItem)
        '*************************************************************
        '*  Delete from DataTable
        '*************************************************************
        Const c_strNoRecordToDeleteError As String = "No Record To Delete"
        Const c_strManyRecordsToDeleteError As String = "More than one Record To Delete"

        Dim drOrderItemRow() As DataRow

        drOrderItemRow = FindRow(objOrderItem.OrderItemID)

        Select Case drOrderItemRow.Length
            Case 1
                drOrderItemRow(0).Delete()
            Case 0
                Throw New Exception(c_strNoRecordToDeleteError)
            Case Else
                Throw New Exception(c_strManyRecordsToDeleteError)
        End Select

    End Sub

    ''' <summary>
    ''' Change a OrderItem in the DataTable
    ''' </summary>
    ''' <param name="objOrderItem">OrderItem to change</param>
    ''' <remarks></remarks>
    Shared Sub Change(ByVal objOrderItem As OrderItem)

        Const c_strNoRecordToChangeError As String = "No Record To Change"
        Const c_strManyRecordsToChangeError As String = "More than one Record To Change"

        Dim drOrderItemRow() As DataRow

        With objOrderItem
            drOrderItemRow = FindRow(.OrderItemID)

            Select Case drOrderItemRow.Length
                Case 1
                    CopyToDataRow(objOrderItem, drOrderItemRow(0))
                Case 0
                    Throw New Exception(c_strNoRecordToChangeError)
                Case Else
                    Throw New Exception(c_strManyRecordsToChangeError)
            End Select
        End With

    End Sub

    Shared Sub CopyToDataRow(ByVal objOrderItem As OrderItem,
                             ByVal drOrderItem As DataRow)
        '*************************************************************************
        '   Copies OrderItem to datarow
        '*************************************************************************
        With objOrderItem
            drOrderItem("OrderItemID") = .OrderItemID
            drOrderItem("Quantity") = .Quantity
            drOrderItem("BakedGoodID") = .BakedGoodID
            drOrderItem("OrderID") = .OrderID
            drOrderItem("Price") = .UnitPrice
        End With
    End Sub

    Shared Function FindRow(ByVal iID As Integer) As DataRow()
        '*************************************************************************
        '*  returns a row from the data table whose OrderItemID matches the parameter strID
        '*************************************************************************
        Return dtOrderItem.Select("OrderItemID  = '" & iID & "'")
    End Function

    ''' <summary>
    ''' Sets up the DataAdapter for the OrderItems Table
    ''' </summary>
    ''' <remarks>
    ''' Establishes the SelectCommand, InsertCommand, UpdateCommand, DeleteCommand properties
    ''' </remarks>
    Shared Sub SetupAdapter()
        With daOrderItem
            .SelectCommand = connWBE.CreateCommand
            .InsertCommand = connWBE.CreateCommand
            .UpdateCommand = connWBE.CreateCommand
            .DeleteCommand = connWBE.CreateCommand

            .SelectCommand.CommandText = "SELECT OrderItemID, Quantity, OrderID, OrderItems.Price, " +
                                         "OrderItems.BakedGoodID, BakedGood.Name " +
                                         "FROM OrderItems, BakedGood " +
                                         "WHERE OrderID = @OrderID And " +
                                         "OrderItems.BakedGoodID = BakedGood.BakedGoodID"

            With .SelectCommand.Parameters
                .AddWithValue("@OrderID", SqlDbType.Int).Value = OrderID
            End With

            With .InsertCommand
                .CommandText = "INSERT INTO OrderItems(Quantity, OrderID, Price, BakedGoodID) " +
                               "VALUES(@Quantity, @OrderID, @Price, @BakedGoodID)"

                With .Parameters
                    .AddWithValue("@Quantity", SqlDbType.SmallInt).SourceColumn = "Quantity"
                    .AddWithValue("@OrderID", SqlDbType.Int).SourceColumn = "OrderID"
                    .AddWithValue("@Price", SqlDbType.SmallMoney).SourceColumn = "Price"
                    .AddWithValue("@BakedGoodID", SqlDbType.SmallInt).SourceColumn = "BakedGoodID"

                End With
            End With

            With .UpdateCommand
                .CommandText = "UPDATE OrderItems " +
                                "SET Quantity = @Quantity, " +
                                "OrderID = @OrderID, " +
                                "Price = @Price, " +
                                "BakedGoodID = @BakedGoodID " +
                                "WHERE OrderItemID = @OrderItemID"

                With .Parameters
                    .AddWithValue("@Quantity", SqlDbType.SmallInt).SourceColumn = "Quantity"
                    .AddWithValue("@OrderID", SqlDbType.Int).SourceColumn = "OrderID"
                    .AddWithValue("@Price", SqlDbType.SmallMoney).SourceColumn = "Price"
                    .AddWithValue("@BakedGoodID", SqlDbType.SmallInt).SourceColumn = "BakedGoodID"
                    .AddWithValue("@OrderItemID", SqlDbType.Int).SourceColumn = "OrderItemID"
                End With
            End With

            With .DeleteCommand
                .CommandText = "DELETE FROM OrderItems " +
                               "WHERE OrderItemID = @OrderItemID"
                With .Parameters
                    .AddWithValue("@OrderItemID", SqlDbType.Int).SourceColumn = "OrderItemID"
                End With
            End With
        End With
    End Sub

End Class
