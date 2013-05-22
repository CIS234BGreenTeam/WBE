Imports libWBEBR

'*************************************************************
'*  Class       colCustomers
'*  Programmer  Dan Dougherty (Modified by Kristina Frye for WBE Project)
'*  Date        Apr 2013
'*
'*  Customer Collection
'*************************************************************

''' <summary>
'''  This defines the Customer collection class 
'''  for the Registation system
''' </summary>
''' <remarks></remarks>
Public Class colCustomers
    Inherits List(Of Customer)

    ''' <summary>
    ''' Fill Datatable with entire database table
    ''' </summary>
    ''' <remarks></remarks>
    Public Function Fill(ByRef sError As String) As Boolean

        If Count < 1 Then
            Clear()
        End If
        Return CustomerDB.Fill(Me, sError)

    End Function

    ''' <summary>
    ''' Add a Customer object to the collection
    ''' and to the datatable
    ''' </summary>
    ''' <param name="objCustomer">
    ''' Customer to add
    ''' </param>
    ''' <remarks>
    ''' Must be Shadows since Add in List is not overridable
    ''' </remarks>
    Public Shadows Sub Add(ByVal objCustomer As Customer)

        MyBase.Add(objCustomer)
        CustomerDB.Add(objCustomer)

    End Sub

    ''' <summary>
    ''' remove a Customer object from the collection
    ''' and from the datatable
    ''' </summary>
    ''' <param name="objCustomer">
    ''' Customer to add
    ''' </param>
    ''' <remarks>
    ''' Must be Shadows since Remove in List is not overridable
    ''' </remarks>

    Public Shadows Sub Remove(ByVal objCustomer As Customer)
        MyBase.Remove(objCustomer)
        CustomerDB.Delete(objCustomer)
    End Sub

    ''' <summary>
    ''' Change DataTable
    ''' </summary>
    ''' <param name="objCustomer">
    ''' Customer to change
    ''' </param>
    ''' <remarks>
    ''' no need to Shadow since no Change in the List collection
    ''' </remarks>
    Public Sub Change(ByVal objCustomer As Customer)
        CustomerDB.Change(objCustomer)
    End Sub

    Private _iId As Integer
    ''' <summary>
    ''' Locates a Customer with a certain ID in the collection
    ''' </summary>
    ''' <param name="iID">ID to find</param>
    ''' <returns>Customer with said ID</returns>
    ''' <remarks>Must be overloads because Find is already defined in the base class</remarks>
    Public Overloads Function Find(iID As Integer) As Customer
        Dim objCustomer As Customer
        _iId = iID
        objCustomer = Me.Find(AddressOf FindID)
        Return objCustomer
    End Function

    Private Function FindID(ByVal objCustomer As Customer) As Boolean
        'necessary for base class's Find
        Return objCustomer.CustomerID = _iId
    End Function

End Class


