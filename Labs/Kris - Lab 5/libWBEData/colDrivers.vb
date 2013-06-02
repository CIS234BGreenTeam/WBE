Imports libWBEBR

'*************************************************************
'*  Class       colDrivers
'*  Programmer  Dan Dougherty (Modified by Kristina Frye for WBE Project)
'*  Date        Apr 2013
'*
'*  Driver Collection
'*************************************************************

''' <summary>
'''  This defines the Driver collection class 
'''  for the Registation system
''' </summary>
''' <remarks></remarks>
Public Class colDrivers
    Inherits List(Of Driver)

    ''' <summary>
    ''' Fill Datatable with entire database table
    ''' </summary>
    ''' <remarks></remarks>
    Public Function Fill(ByVal sError As String) As Boolean
        If Count < 1 Then
            Clear()
        End If
        Return DriverDB.Fill(Me, sError)

    End Function

    ''' <summary>
    ''' Add a Driver object to the collection
    ''' and to the datatable
    ''' </summary>
    ''' <param name="objDriver">
    ''' Driver to add
    ''' </param>
    ''' <remarks>
    ''' Must be Shadows since Add in List is not overridable
    ''' </remarks>
    Public Shadows Sub Add(ByVal objDriver As Driver)

        MyBase.Add(objDriver)
        DriverDB.Add(objDriver)

    End Sub

    ''' <summary>
    ''' remove a Driver object from the collection
    ''' and from the datatable
    ''' </summary>
    ''' <param name="objDriver">
    ''' Driver to add
    ''' </param>
    ''' <remarks>
    ''' Must be Shadows since Remove in List is not overridable
    ''' </remarks>

    Public Shadows Sub Remove(ByVal objDriver As Driver)
        MyBase.Remove(objDriver)
        DriverDB.Delete(objDriver)
    End Sub

    ''' <summary>
    ''' Change DataTable
    ''' </summary>
    ''' <param name="objDriver">
    ''' Driver to change
    ''' </param>
    ''' <remarks>
    ''' no need to Shadow since no Change in the List collection
    ''' </remarks>
    Public Sub Change(ByVal objDriver As Driver)
        DriverDB.Change(objDriver)
    End Sub

    Private _iId As Integer
    ''' <summary>
    ''' Locates a Driver with a certain ID in the collection
    ''' </summary>
    ''' <param name="iID">ID to find</param>
    ''' <returns>Driver with said ID</returns>
    ''' <remarks>Must be overloads because Find is already defined in the base class</remarks>
    Public Overloads Function Find(iID As Integer) As Driver
        Dim objDriver As Driver
        _iId = iID
        objDriver = Me.Find(AddressOf FindID)
        Return objDriver
    End Function

    Private Function FindID(ByVal objDriver As Driver) As Boolean
        'necessary for base class's Find
        Return objDriver.DriverID = _iId
    End Function

End Class

