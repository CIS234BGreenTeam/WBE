Public Class Customer
    Public Property Name() As String
    Public Property Address1() As String
    Public Property Address2() As String
    Public Property City As String
    Public Property State As String
    Public Property Zip As Integer
    Public Property Phone As String
    Public Property Fax As String
    Public Property Email As String
    Public Property Stock As List(Of BakedGood)
    Public Property Order As List(Of Order)
End Class
