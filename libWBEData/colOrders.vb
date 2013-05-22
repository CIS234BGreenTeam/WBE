Imports libWBEBR

'*************************************************************
'*  Class       colOrders
'*  Programmer  Dan Dougherty (Modified by Ken Baker for WBE Project)
'*  Date        Apr 2013
'*
'*  Orders Collection
'*************************************************************

''' <summary>
'''  This defines the Orders collection class 
'''  for the Registation system
''' </summary>
''' <remarks></remarks>
Public Class colOrders
    Inherits List(Of Order)

    ''' <summary>
    ''' Fill Datatable with database table for a particular order
    ''' </summary>
    ''' <remarks></remarks>
    Public Function Fill(ByRef sError As String) As Boolean
        If Me.Count < 1 Then
            Clear()
        End If
        Return OrdersDB.Fill(Me, sError)

    End Function

    ''' <summary>
    ''' Add a Order object to the collection
    ''' and to the datatable
    ''' </summary>
    ''' <param name="objOrder">
    ''' Order to add
    ''' </param>
    ''' <remarks>
    ''' Must be Shadows since Add in List is not overridable
    ''' </remarks>
    Public Shadows Sub Add(ByVal objOrder As Order)

        MyBase.Add(objOrder)
        OrdersDB.Add(objOrder)

    End Sub

    ''' <summary>
    ''' remove a Order object from the collection
    ''' and from the datatable
    ''' </summary>
    ''' <param name="objOrder">
    ''' Order to add
    ''' </param>
    ''' <remarks>
    ''' Must be Shadows since Remove in List is not overridable
    ''' </remarks>

    Public Shadows Sub Remove(ByVal objOrder As Order)
        MyBase.Remove(objOrder)
        OrdersDB.Delete(objOrder)
    End Sub

    ''' <summary>
    ''' Change DataTable
    ''' </summary>
    ''' <param name="objOrder">
    ''' Order to change
    ''' </param>
    ''' <remarks>
    ''' no need to Shadow since no Change in the List collection
    ''' </remarks>
    Public Sub Change(ByVal objOrder As Order)
        OrdersDB.Change(objOrder)
    End Sub

    Private _iId As Integer
    ''' <summary>
    ''' Locates a Order with a certain ID in the collection
    ''' </summary>
    ''' <param name="iID">ID to find</param>
    ''' <returns>Order with said ID</returns>
    ''' <remarks>Must be overloads because Find is already defined in the base class</remarks>
    Public Overloads Function Find(iID As Integer) As Order
        Dim objOrder As Order
        _iId = iID
        objOrder = Me.Find(AddressOf FindID)
        Return objOrder
    End Function

    Private Function FindID(ByVal objOrder As Order) As Boolean
        'necessary for base class's Find
        Return objOrder.OrderID = _iId
    End Function

End Class
