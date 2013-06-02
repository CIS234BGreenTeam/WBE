Imports libWBEBR

Public Class DriverDB
    Inherits WBEData

    'This is used temporarily as the ID until the real one's found
    Private Shared _iTempLastID As Integer

    ''' <summary>
    ''' Fills the Driver collection
    ''' </summary>
    ''' <param name="colDrivers">the collection that will be filled</param>
    ''' <param name="sError">error generated (if any)</param>
    ''' <returns>
    ''' True - if no error
    ''' False if Error (in this case sError will have the error generated)
    ''' </returns>
    ''' <remarks></remarks>
    Shared Function Fill(ByVal colDrivers As List(Of Driver),
                        ByRef sError As String) As Boolean
        Try

            Dim objDriver As Driver

            'If filled a second time, clear the datatable first
            If Not dtDrivers Is Nothing Then
                dtDrivers.Clear()
            End If

            daDrivers.Fill(dsWBE, "Drivers")
            dtDrivers = dsWBE.Tables("Drivers")

            For Each dr As DataRow In dtDrivers.Rows
                objDriver = New Driver
                With objDriver
                    .DriverID = Convert.ToInt32(dr("DriverID"))
                    .Name = dr("Name").ToString
                    If _iTempLastID < .DriverID Then
                        _iTempLastID = .DriverID
                    End If
                End With

                colDrivers.Add(objDriver)

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
        AddHandler daDrivers.RowUpdated, New SqlClient.SqlRowUpdatedEventHandler(AddressOf OnRowUpdated)
        daDrivers.Update(dsWBE, "Drivers")
    End Sub

    Private Shared Sub OnRowUpdated(sender As Object, args As SqlClient.SqlRowUpdatedEventArgs)
        ' Captures the actual ID that is used  
        Dim newID As Integer = 0
        Dim idCMD As SqlClient.SqlCommand = New SqlClient.SqlCommand("SELECT @@IDENTITY", connWBE)

        If args.StatementType = StatementType.Insert Then
            newID = CInt(idCMD.ExecuteScalar())
            args.Row("DriverID") = newID
            If _iTempLastID < newID Then
                _iTempLastID = newID
            End If
        End If
    End Sub

    ''' <summary>
    ''' Adds a Driver to the DataTable
    ''' </summary>
    ''' <param name="objDriver">Driver to add</param>
    ''' <remarks>
    ''' assigns a temporary ID at this time
    ''' </remarks>
    Shared Sub Add(ByVal objDriver As Driver)
        '*************************************************************
        '*  Add a Driver object to the datatable
        '*************************************************************
        Dim drDriver As DataRow

        drDriver = dtDrivers.NewRow

        _iTempLastID += 1
        objDriver.DriverID = _iTempLastID
        CopyToDataRow(objDriver, drDriver)

        dtDrivers.Rows.Add(drDriver)
    End Sub

    ''' <summary>
    ''' deletes a Driver from the datatable
    ''' </summary>
    ''' <param name="objDriver">Driver to delete</param>
    ''' <remarks></remarks>
    Shared Sub Delete(ByVal objDriver As Driver)
        '*************************************************************
        '*  Delete from DataTable
        '*************************************************************
        Const c_strNoRecordToDeleteError As String = "No Record To Delete"
        Const c_strManyRecordsToDeleteError As String = "More than one Record To Delete"

        Dim drDriverRow() As DataRow
        drDriverRow = FindRow(objDriver.DriverID)
        Select Case drDriverRow.Length
            Case 1
                drDriverRow(0).Delete()
            Case 0
                Throw New Exception(c_strNoRecordToDeleteError)
            Case Else
                Throw New Exception(c_strManyRecordsToDeleteError)
        End Select

    End Sub

    ''' <summary>
    ''' Change a Driver in the DataTable
    ''' </summary>
    ''' <param name="objDriver">Driver to change</param>
    ''' <remarks></remarks>
    Shared Sub Change(ByVal objDriver As Driver)

        Const c_strNoRecordToChangeError As String = "No Record To Change"
        Const c_strManyRecordsToChangeError As String = "More than one Record To Change"

        Dim drDriverRow() As DataRow

        With objDriver
            drDriverRow = FindRow(.DriverID)

            Select Case drDriverRow.Length
                Case 1
                    CopyToDataRow(objDriver, drDriverRow(0))
                Case 0
                    Throw New Exception(c_strNoRecordToChangeError)
                Case Else
                    Throw New Exception(c_strManyRecordsToChangeError)
            End Select
        End With

    End Sub

    Shared Sub CopyToDataRow(ByVal objDriver As Driver,
                             ByVal drDriver As DataRow)
        '*************************************************************************
        '   Copies Driver to datarow
        '*************************************************************************
        With objDriver
            drDriver("DriverID") = .DriverID
            drDriver("Name") = .Name
        End With
    End Sub

    Shared Function FindRow(ByVal iID As Integer) As DataRow()
        '*************************************************************************
        '*  returns a row from the data table whose DriverID matches the parameter strID
        '*************************************************************************
        Return dtDrivers.Select("DriverID  = '" & iID & "'")
    End Function

    ''' <summary>
    ''' Sets up the DataAdapter for the Driver Table
    ''' </summary>
    ''' <remarks>
    ''' Establishes the SelectCommand, InsertCommand, UpdateCommand, DeleteCommand properties
    ''' </remarks>
    Shared Sub SetupAdapter()
        With daDrivers
            .SelectCommand = connWBE.CreateCommand
            .InsertCommand = connWBE.CreateCommand
            .UpdateCommand = connWBE.CreateCommand
            .DeleteCommand = connWBE.CreateCommand

            .SelectCommand.CommandText = "Select DriverID, Name from Driver"

            With .InsertCommand
                .CommandText = "Insert Into Driver(Name) Values(@Name)"

                With .Parameters
                    .AddWithValue("@DriverID", SqlDbType.SmallInt).SourceColumn = "DriverID"
                    .AddWithValue("@Name", SqlDbType.VarChar).SourceColumn = "Name"
                End With
            End With

            With .UpdateCommand
                .CommandText = "Update Driver Set Name = @Name Where DriverID = @DriverID"
                With .Parameters
                    .AddWithValue("@Name", SqlDbType.VarChar).SourceColumn = "Name"
                    .AddWithValue("@DriverID", SqlDbType.SmallInt).SourceColumn = "DriverID"
                End With
            End With

            With .DeleteCommand
                .CommandText = "Delete from Driver Where DriverID = @DriverID"
                With .Parameters
                    .AddWithValue("@DriverID", SqlDbType.SmallInt).SourceColumn = "DriverID"
                End With
            End With
        End With
    End Sub
End Class
