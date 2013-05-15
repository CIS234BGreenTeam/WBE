Imports libWBEBR

Public Class BakedGoodDB
    Inherits WBEData

    'This is used temporarily as the ID until the real one's found
    Private Shared _iTempLastID As Integer

    ''' <summary>
    ''' Fills the BakedGood collection
    ''' </summary>
    ''' <param name="colBakedGoods">the collection that will be filled</param>
    ''' <param name="sError">error generated (if any)</param>
    ''' <returns>
    ''' True - if no error
    ''' False if Error (in this case sError will have the error generated)
    ''' </returns>
    ''' <remarks></remarks>
    Shared Function Fill(ByVal colBakedGoods As List(Of BakedGood),
                        ByRef sError As String) As Boolean
        Try

            Dim objBakedGood As BakedGood

            'If filled a second time, clear the datatable first
            If Not dtBakedGoods Is Nothing Then
                dtBakedGoods.Clear()
            End If

            daBakedGoods.Fill(dsWBE, "BakedGoods")
            dtBakedGoods = dsWBE.Tables("BakedGoods")

            For Each dr As DataRow In dtBakedGoods.Rows
                objBakedGood = New BakedGood
                With objBakedGood
                    .BakedGoodID = Convert.ToInt32(dr("BakedGoodID"))
                    .Name = dr("Name").ToString
                    .UnitPrice = Convert.ToDecimal(dr("Price"))
                    .IsActive = Convert.ToBoolean(dr("IsActive"))
                    If .IsActive = False Then
                        .InactiveDate = Convert.ToDateTime(dr("InactiveDate"))
                    End If

                    If _iTempLastID < .BakedGoodID Then
                        _iTempLastID = .BakedGoodID
                    End If

                End With

                colBakedGoods.Add(objBakedGood)

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
        AddHandler daBakedGoods.RowUpdated, New SqlClient.SqlRowUpdatedEventHandler(AddressOf OnRowUpdated)
        daBakedGoods.Update(dsWBE, "BakedGoods")
    End Sub

    Private Shared Sub OnRowUpdated(sender As Object, args As SqlClient.SqlRowUpdatedEventArgs)
        ' Captures the actual ID that is used  
        Dim newID As Integer = 0
        Dim idCMD As SqlClient.SqlCommand = New SqlClient.SqlCommand("SELECT @@IDENTITY", connWBE)

        If args.StatementType = StatementType.Insert Then
            newID = CInt(idCMD.ExecuteScalar())
            args.Row("BakedGoodID") = newID
            If _iTempLastID < newID Then
                _iTempLastID = newID
            End If
        End If
    End Sub

    ''' <summary>
    ''' Adds a BakedGood to the DataTable
    ''' </summary>
    ''' <param name="objBakedGood">BakedGood to add</param>
    ''' <remarks>
    ''' assigns a temporary ID at this time
    ''' </remarks>
    Shared Sub Add(ByVal objBakedGood As BakedGood)
        '*************************************************************
        '*  Add a BakedGood object to the datatable
        '*************************************************************
        Dim drBakedGood As DataRow

        drBakedGood = dtBakedGoods.NewRow

        _iTempLastID += 1
        objBakedGood.BakedGoodID = _iTempLastID
        CopyToDataRow(objBakedGood, drBakedGood)

        dtBakedGoods.Rows.Add(drBakedGood)
    End Sub

    ''' <summary>
    ''' deletes a BakedGood from the datatable
    ''' </summary>
    ''' <param name="objBakedGood">BakedGood to delete</param>
    ''' <remarks></remarks>
    Shared Sub Delete(ByVal objBakedGood As BakedGood)
        '*************************************************************
        '*  Delete from DataTable
        '*************************************************************
        Const c_strNoRecordToDeleteError As String = "No Record To Delete"
        Const c_strManyRecordsToDeleteError As String = "More than one Record To Delete"

        Dim drBakedGoodRow() As DataRow
        drBakedGoodRow = FindRow(objBakedGood.BakedGoodID)
        Select Case drBakedGoodRow.Length
            Case 1
                drBakedGoodRow(0).Delete()
            Case 0
                Throw New Exception(c_strNoRecordToDeleteError)
            Case Else
                Throw New Exception(c_strManyRecordsToDeleteError)
        End Select

    End Sub

    ''' <summary>
    ''' Change a BakedGood in the DataTable
    ''' </summary>
    ''' <param name="objBakedGood">BakedGood to change</param>
    ''' <remarks></remarks>
    Shared Sub Change(ByVal objBakedGood As BakedGood)

        Const c_strNoRecordToChangeError As String = "No Record To Change"
        Const c_strManyRecordsToChangeError As String = "More than one Record To Change"

        Dim drBakedGoodRow() As DataRow

        With objBakedGood
            drBakedGoodRow = FindRow(.BakedGoodID)

            Select Case drBakedGoodRow.Length
                Case 1
                    CopyToDataRow(objBakedGood, drBakedGoodRow(0))
                Case 0
                    Throw New Exception(c_strNoRecordToChangeError)
                Case Else
                    Throw New Exception(c_strManyRecordsToChangeError)
            End Select
        End With

    End Sub

    Shared Sub CopyToDataRow(ByVal objBakedGood As BakedGood,
                             ByVal drBakedGood As DataRow)
        '*************************************************************************
        '   Copies BakedGood to datarow
        '*************************************************************************
        With objBakedGood
            drBakedGood("BakedGoodID") = .BakedGoodID
            drBakedGood("Name") = .Name
            drBakedGood("Price") = .UnitPrice
            drBakedGood("IsActive") = .IsActive
            drBakedGood("InactiveDate") = .InactiveDate
        End With
    End Sub

    Shared Function FindRow(ByVal iID As Integer) As DataRow()
        '*************************************************************************
        '*  returns a row from the data table whose BakedGoodID matches the parameter strID
        '*************************************************************************
        Return dtBakedGoods.Select("BakedGoodID  = '" & iID & "'")
    End Function

    ''' <summary>
    ''' Sets up the DataAdapter for the BakedGood Table
    ''' </summary>
    ''' <remarks>
    ''' Establishes the SelectCommand, InsertCommand, UpdateCommand, DeleteCommand properties
    ''' </remarks>
    Shared Sub SetupAdapter()
        With daBakedGoods
            .SelectCommand = connWBE.CreateCommand
            .InsertCommand = connWBE.CreateCommand
            .UpdateCommand = connWBE.CreateCommand
            .DeleteCommand = connWBE.CreateCommand

            .SelectCommand.CommandText = "SELECTBakedGoodID, Name, UnitPrice, IsActive, InactiveDate FROM BAKEDGOOD"

            With .InsertCommand
                .CommandText = "INSERT INTO BakedGood(Name, UnitPrice, IsActive, InactiveDate)" &
                                "VALUES(@Name, @Price, @IsActive, @InactiveDate)"

                With .Parameters
                    .AddWithValue("@Name", SqlDbType.VarChar).SourceColumn = "Name"
                    .AddWithValue("@Price", SqlDbType.Decimal).SourceColumn = "Price"
                    .AddWithValue("@IsActive", SqlDbType.Bit).SourceColumn = "IsActive"
                    .AddWithValue("@InactiveDate", SqlDbType.DateTime).SourceColumn = "InactiveDate"
                End With
            End With

            With .UpdateCommand
                .CommandText = "UPDATE BakedGood SET Name = @Name, Price = @Price, IsActive = @IsActive," &
                                       "InactiveDate = @InactiveDate, BakedGoodID = @BakedGoodID " &
                                "WHERE BakedGoodID = @BakedGoodID"

                With .Parameters
                    .AddWithValue("@Name", SqlDbType.VarChar).SourceColumn = "Name"
                    .AddWithValue("@Price", SqlDbType.Decimal).SourceColumn = "Price"
                    .AddWithValue("@IsActive", SqlDbType.Bit).SourceColumn = "IsActive"
                    .AddWithValue("@InactiveDate", SqlDbType.DateTime).SourceColumn = "InactiveDate"
                    .AddWithValue("", SqlDbType.SmallInt).SourceColumn = "BakedGoodID"
                End With
            End With

            With .DeleteCommand
                .CommandText = "Delete from BakedGood Where BakedGoodID = @BakedGoodID"
                With .Parameters
                    .AddWithValue("", SqlDbType.SmallInt).SourceColumn = "BakedGoodID"
                End With
            End With
        End With
    End Sub

End Class
