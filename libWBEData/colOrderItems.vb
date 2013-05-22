Imports libWBEBR

'*************************************************************
'*  Class       colOrderItems
'*  Programmer  Dan Dougherty (Modified by Ken Baker for WBE Project)
'*  Date        Apr 2013
'*
'*  OrderItems Collection
'*************************************************************

''' <summary>
'''  This defines the OrderItem collection class 
'''  for the Registation system
''' </summary>
''' <remarks></remarks>
Public Class colOrderItems
    Inherits List(Of OrderItem)

    ''' <summary>
    ''' Fill Datatable with database table for a particular customer
    ''' </summary>
    ''' <remarks></remarks>
    Public Function Fill(ByRef sError As String) As Boolean
        If Me.Count > 0 Then
            Clear()
        End If
        Return OrderItemDB.Fill(Me, sError)

    End Function

    ''' <summary>
    ''' Add a OrderItem object to the collection
    ''' and to the datatable
    ''' </summary>
    ''' <param name="objOrderItem">
    ''' OrderItem to add
    ''' </param>
    ''' <remarks>
    ''' Must be Shadows since Add in List is not overridable
    ''' </remarks>
    Public Shadows Sub Add(ByVal objOrderItem As OrderItem)

        MyBase.Add(objOrderItem)
        OrderItemDB.Add(objOrderItem)

    End Sub

    ''' <summary>
    ''' remove a OrderItem object from the collection
    ''' and from the datatable
    ''' </summary>
    ''' <param name="objOrderItem">
    ''' OrderItem to add
    ''' </param>
    ''' <remarks>
    ''' Must be Shadows since Remove in List is not overridable
    ''' </remarks>

    Public Shadows Sub Remove(ByVal objOrderItem As OrderItem)
        MyBase.Remove(objOrderItem)
        OrderItemDB.Delete(objOrderItem)
    End Sub

    ''' <summary>
    ''' Change DataTable
    ''' </summary>
    ''' <param name="objOrderItem">
    ''' OrderItem to change
    ''' </param>
    ''' <remarks>
    ''' no need to Shadow since no Change in the List collection
    ''' </remarks>
    Public Sub Change(ByVal objOrderItem As OrderItem)
        OrderItemDB.Change(objOrderItem)
    End Sub

    Private _iId As Integer
    ''' <summary>
    ''' Locates a OrderItem with a certain ID in the collection
    ''' </summary>
    ''' <param name="iID">ID to find</param>
    ''' <returns>OrderItem with said ID</returns>
    ''' <remarks>Must be overloads because Find is already defined in the base class</remarks>
    Public Overloads Function Find(iID As Integer) As OrderItem
        Dim objOrderItem As OrderItem
        _iId = iID
        objOrderItem = Me.Find(AddressOf FindID)
        Return objOrderItem
    End Function

    Private Function FindID(ByVal objOrderItem As OrderItem) As Boolean
        'necessary for base class's Find
        Return objOrderItem.OrderItemID = _iId
    End Function

End Class

