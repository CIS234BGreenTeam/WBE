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
    Inherits List(Of Orders)

    ''' <summary>
    ''' Fill Datatable with database table for a particular customer
    ''' </summary>
    ''' <remarks></remarks>
    Public Function Fill(ByVal sError As String) As Boolean
        If Me.Count > 0 Then
            Clear()
        End If
        Return OrdersDB.Fill(Me, sError)

    End Function

    ''' <summary>
    ''' Add a Orders object to the collection
    ''' and to the datatable
    ''' </summary>
    ''' <param name="objOrders">
    ''' Orders to add
    ''' </param>
    ''' <remarks>
    ''' Must be Shadows since Add in List is not overridable
    ''' </remarks>
    Public Shadows Sub Add(ByVal objOrders As Orders)

        MyBase.Add(objOrders)
        OrdersDB.Add(objOrders)

    End Sub

    ''' <summary>
    ''' remove a Orders object from the collection
    ''' and from the datatable
    ''' </summary>
    ''' <param name="objOrders">
    ''' Orders to add
    ''' </param>
    ''' <remarks>
    ''' Must be Shadows since Remove in List is not overridable
    ''' </remarks>

    Public Shadows Sub Remove(ByVal objOrders As Orders)
        MyBase.Remove(objOrders)
        OrdersDB.Delete(objOrders)
    End Sub

    ''' <summary>
    ''' Change DataTable
    ''' </summary>
    ''' <param name="objOrders">
    ''' Orders to change
    ''' </param>
    ''' <remarks>
    ''' no need to Shadow since no Change in the List collection
    ''' </remarks>
    Public Sub Change(ByVal objOrders As Orders)
        OrdersDB.Change(objOrders)
    End Sub

    Private _iId As Integer
    ''' <summary>
    ''' Locates a Orders with a certain ID in the collection
    ''' </summary>
    ''' <param name="iID">ID to find</param>
    ''' <returns>Orders with said ID</returns>
    ''' <remarks>Must be overloads because Find is already defined in the base class</remarks>
    Public Overloads Function Find(iID As Integer) As Orders
        Dim objOrders As Orders
        _iId = iID
        objOrders = Me.Find(AddressOf FindID)
        Return objOrders
    End Function

    Private Function FindID(ByVal objOrders As Orders) As Boolean
        'necessary for base class's Find
        Return objOrders.OrderID = _iId
    End Function

End Class
