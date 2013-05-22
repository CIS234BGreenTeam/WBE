Imports libWBEBR

'*************************************************************
'*  Class       colCustStock
'*  Programmer  Dan Dougherty (Modified by Kristina Frye for WBE Project)
'*  Date        Apr 2013
'*
'*  CustStock Collection
'*************************************************************

''' <summary>
'''  This defines the CustStock collection class 
'''  for the Registation system
''' </summary>
''' <remarks></remarks>
Public Class colCustStock
    Inherits List(Of CustStock)

    ''' <summary>
    ''' Fill Datatable with database table for a particular customer
    ''' </summary>
    ''' <remarks></remarks>
    Public Function Fill(ByRef sError As String) As Boolean
        If Me.Count > 0 Then
            Clear()
        End If
        Return CustStockDB.Fill(Me, sError)

    End Function

    ''' <summary>
    ''' Add a CustStock object to the collection
    ''' and to the datatable
    ''' </summary>
    ''' <param name="objCustStock">
    ''' CustStock to add
    ''' </param>
    ''' <remarks>
    ''' Must be Shadows since Add in List is not overridable
    ''' </remarks>
    Public Shadows Sub Add(ByVal objCustStock As CustStock)

        MyBase.Add(objCustStock)
        CustStockDB.Add(objCustStock)

    End Sub

    ''' <summary>
    ''' remove a CustStock object from the collection
    ''' and from the datatable
    ''' </summary>
    ''' <param name="objCustStock">
    ''' CustStock to add
    ''' </param>
    ''' <remarks>
    ''' Must be Shadows since Remove in List is not overridable
    ''' </remarks>

    Public Shadows Sub Remove(ByVal objCustStock As CustStock)
        MyBase.Remove(objCustStock)
        CustStockDB.Delete(objCustStock)
    End Sub

    ''' <summary>
    ''' Change DataTable
    ''' </summary>
    ''' <param name="objCustStock">
    ''' CustStock to change
    ''' </param>
    ''' <remarks>
    ''' no need to Shadow since no Change in the List collection
    ''' </remarks>
    Public Sub Change(ByVal objCustStock As CustStock)
        CustStockDB.Change(objCustStock)
    End Sub

    Private _iId As Integer
    ''' <summary>
    ''' Locates a CustStock with a certain ID in the collection
    ''' </summary>
    ''' <param name="iID">ID to find</param>
    ''' <returns>CustStock with said ID</returns>
    ''' <remarks>Must be overloads because Find is already defined in the base class</remarks>
    Public Overloads Function Find(iID As Integer) As CustStock
        Dim objCustStock As CustStock
        _iId = iID
        objCustStock = Me.Find(AddressOf FindID)
        Return objCustStock
    End Function

    Private Function FindID(ByVal objCustStock As CustStock) As Boolean
        'necessary for base class's Find
        Return objCustStock.StockID = _iId
    End Function

End Class
