Public Class Order
    Public Property CustomerID As Integer
    Public Property OrderNo As Integer
    Public Property OrderDate As DateTime
    Public Property Driver As Driver
    Public Property Item As List(Of OrderItem)
End Class
