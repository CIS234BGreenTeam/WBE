Imports libWBEBR

Public Class CustStockDB

    Inherits WBEData
    Public Shared Property CustomerID As Integer

    'This is used temporarily as the ID until the real one's found
    Private Shared _iTempLastID As Integer

    ''' <summary>
    ''' Fills the CustStock collection
    ''' </summary>
    ''' <param name="colCustStock">the collection that will be filled</param>
    ''' <param name="sError">error generated (if any)</param>
    ''' <returns>
    ''' True - if no error
    ''' False if Error (in this case sError will have the error generated)
    ''' </returns>
    ''' <remarks></remarks>
    Shared Function Fill(ByVal colCustStock As List(Of CustStock),
                        ByRef sError As String) As Boolean
        Try

            Dim objCustStock As CustStock

            'If filled a second time, clear the datatable first
            If Not dtCustStock Is Nothing Then
                dtCustStock.Clear()
            End If

            daCustStock.Fill(dsWBE, "CustStocks")
            dtCustStock = dsWBE.Tables("CustStocks")

            For Each dr As DataRow In dtCustStock.Rows
                objCustStock = New CustStock
                With objCustStock
                    .StockID = Convert.ToInt32(dr("StockID"))
                    .BakedGoodID = Convert.ToInt32(dr("BakedGoodID"))
                    .StockQty = Convert.ToInt32(dr("StockQty"))
                    .CustomerID = Convert.ToInt32(dr("CustomerID"))
                    .Name = dr("Name").ToString

                    If _iTempLastID < .StockID Then
                        _iTempLastID = .StockID
                    End If

                End With

                colCustStock.Add(objCustStock)

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
        AddHandler daCustStock.RowUpdated, New SqlClient.SqlRowUpdatedEventHandler(AddressOf OnRowUpdated)
        daCustStock.Update(dsWBE, "CustStocks")
    End Sub

    Private Shared Sub OnRowUpdated(sender As Object, args As SqlClient.SqlRowUpdatedEventArgs)
        ' Captures the actual ID that is used  
        Dim newID As Integer = 0
        Dim idCMD As SqlClient.SqlCommand = New SqlClient.SqlCommand("SELECT @@IDENTITY", connWBE)

        If args.StatementType = StatementType.Insert Then
            newID = CInt(idCMD.ExecuteScalar())
            args.Row("StockID") = newID
            If _iTempLastID < newID Then
                _iTempLastID = newID
            End If
        End If
    End Sub

    ''' <summary>
    ''' Adds a CustStock to the DataTable
    ''' </summary>
    ''' <param name="objCustStock">CustStock to add</param>
    ''' <remarks>
    ''' assigns a temporary ID at this time
    ''' </remarks>
    Shared Sub Add(ByVal objCustStock As CustStock)
        '*************************************************************
        '*  Add a CustStock object to the datatable
        '*************************************************************
        Dim drCustStock As DataRow

        drCustStock = dtCustStock.NewRow

        _iTempLastID += 1
        objCustStock.StockID = _iTempLastID
        CopyToDataRow(objCustStock, drCustStock)

        dtCustStock.Rows.Add(drCustStock)
    End Sub

    ''' <summary>
    ''' deletes a CustStock from the datatable
    ''' </summary>
    ''' <param name="objCustStock">CustStock to delete</param>
    ''' <remarks></remarks>
    Shared Sub Delete(ByVal objCustStock As CustStock)
        '*************************************************************
        '*  Delete from DataTable
        '*************************************************************
        Const c_strNoRecordToDeleteError As String = "No Record To Delete"
        Const c_strManyRecordsToDeleteError As String = "More than one Record To Delete"

        Dim drCustStockRow() As DataRow
        drCustStockRow = FindRow(objCustStock.StockID)
        Select Case drCustStockRow.Length
            Case 1
                drCustStockRow(0).Delete()
            Case 0
                Throw New Exception(c_strNoRecordToDeleteError)
            Case Else
                Throw New Exception(c_strManyRecordsToDeleteError)
        End Select

    End Sub

    ''' <summary>
    ''' Change a CustStock in the DataTable
    ''' </summary>
    ''' <param name="objCustStock">CustStock to change</param>
    ''' <remarks></remarks>
    Shared Sub Change(ByVal objCustStock As CustStock)

        Const c_strNoRecordToChangeError As String = "No Record To Change"
        Const c_strManyRecordsToChangeError As String = "More than one Record To Change"

        Dim drCustStockRow() As DataRow

        With objCustStock
            drCustStockRow = FindRow(.StockID)

            Select Case drCustStockRow.Length
                Case 1
                    CopyToDataRow(objCustStock, drCustStockRow(0))
                Case 0
                    Throw New Exception(c_strNoRecordToChangeError)
                Case Else
                    Throw New Exception(c_strManyRecordsToChangeError)
            End Select
        End With

    End Sub

    Shared Sub CopyToDataRow(ByVal objCustStock As CustStock,
                             ByVal drCustStock As DataRow)
        '*************************************************************************
        '   Copies CustStock to datarow
        '*************************************************************************
        With objCustStock
            drCustStock("StockID") = .StockID
            drCustStock("BakedGoodID") = .BakedGoodID
            drCustStock("StockQty") = .StockQty
            drCustStock("CustomerID") = .CustomerID
        End With
    End Sub

    Shared Function FindRow(ByVal iID As Integer) As DataRow()
        '*************************************************************************
        '*  returns a row from the data table whose CustStockID matches the parameter strID
        '*************************************************************************
        Return dtCustStock.Select("StockID  = '" & iID & "'")
    End Function

    ''' <summary>
    ''' Sets up the DataAdapter for the CustStock Table
    ''' </summary>
    ''' <remarks>
    ''' Establishes the SelectCommand, InsertCommand, UpdateCommand, DeleteCommand properties
    ''' </remarks>
    Shared Sub SetupAdapter()
        With daCustStock
            .SelectCommand = connWBE.CreateCommand
            .InsertCommand = connWBE.CreateCommand
            .UpdateCommand = connWBE.CreateCommand
            .DeleteCommand = connWBE.CreateCommand

            .SelectCommand.CommandText = "Select StockID, CustStock.BakedGoodID, StockQty, CustomerID, Name " +
                "FROM CustStock, BakedGood WHERE " +
                "CustStock.BakedGoodID = BakedGood.BakedGoodID AND CustomerID = @CustomerID"

            With .SelectCommand.Parameters
                .AddWithValue("@CustomerID", SqlDbType.SmallInt).Value = CustomerID
            End With

            With .InsertCommand
                .CommandText = "Insert Into CustStock(BakedGoodID, StockQty, CustomerID) " +
                    "Values(@BakedGoodID, @StockQty, @CustomerID)"

                With .Parameters
                    .AddWithValue("@BakedGoodID", SqlDbType.SmallInt).SourceColumn = "BakedGoodID"
                    .AddWithValue("@StockQty", SqlDbType.SmallInt).SourceColumn = "StockQty"
                    .AddWithValue("@CustomerID", SqlDbType.SmallInt).SourceColumn = "CustomerID"
                End With
            End With

            With .UpdateCommand
                .CommandText = "Update CustStock Set BakedGoodID = @BakedGoodID, StockQty = @StockQty, " +
                                "CustomerID = @CustomerID Where StockID = @StockID"

                With .Parameters
                    .AddWithValue("@BakedGoodID", SqlDbType.SmallInt).SourceColumn = "BakedGoodID"
                    .AddWithValue("@StockQty", SqlDbType.SmallInt).SourceColumn = "StockQty"
                    .AddWithValue("@CustomerID", SqlDbType.SmallInt).SourceColumn = "CustomerID"
                    .AddWithValue("@StockID", SqlDbType.SmallInt).SourceColumn = "StockID"
                End With
            End With

            With .DeleteCommand
                .CommandText = "Delete from CustStock Where StockID = @StockID"
                With .Parameters
                    .AddWithValue("@StockID", SqlDbType.SmallInt).SourceColumn = "StockID"
                End With
            End With
        End With
    End Sub


End Class
