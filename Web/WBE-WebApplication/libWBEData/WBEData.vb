Public Class WBEData
    Protected Shared dsWBE As New DataSet
    Protected Shared connWBE As New SqlClient.SqlConnection
    Protected Shared dtCustomers As DataTable
    Protected Shared daCustomers As New SqlClient.SqlDataAdapter
    Protected Shared dtDrivers As DataTable
    Protected Shared daDrivers As New SqlClient.SqlDataAdapter
    Protected Shared dtCustStock As DataTable
    Protected Shared daCustStock As New SqlClient.SqlDataAdapter
    Protected Shared dtBakedGoods As DataTable
    Protected Shared daBakedGoods As New SqlClient.SqlDataAdapter

    ''' <summary>
    ''' Constructor for RegistationDB
    ''' </summary>
    ''' <remarks>Sets the connection string
    ''' sets up the DataAdapter for each table (derived class)</remarks>
    Shared Sub New()
        connWBE.ConnectionString =
            "Data Source=.\SQLEXPRESS;database='WBE';Integrated Security=True"
        
    End Sub
End Class
