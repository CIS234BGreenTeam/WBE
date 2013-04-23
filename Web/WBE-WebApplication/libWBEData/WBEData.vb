Public Class WBEData
    Protected Shared dsWBE As New DataSet
    Protected Shared connWBE As New SqlClient.SqlConnection
    Protected Shared dtCustomers As DataTable
    Protected Shared daCustomers As New SqlClient.SqlDataAdapter
    Protected Shared dtDriver As DataTable
    Protected Shared daDriver As New SqlClient.SqlDataAdapter

    ''' <summary>
    ''' Constructor for RegistationDB
    ''' </summary>
    ''' <remarks>Sets the connection string
    ''' sets up the DataAdapter for each table (derived class)</remarks>
    Shared Sub New()
        connWBE.ConnectionString =
            "Data Source=.\SQLEXPRESS;AttachDbFilename=\wbe.mdf';Integrated Security=True;User Instance=TRUE"
        CustomerDB.SetupAdapter()
        DriverDB.SetupAdapter()
    End Sub
End Class
