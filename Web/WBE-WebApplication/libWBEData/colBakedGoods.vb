Imports libWBEBR

Public Class colBakedGoods
    Inherits List(Of BakedGood)

    ''' <summary>
    ''' Fill Datatable with database table for a particular customer
    ''' </summary>
    ''' <remarks></remarks>
    Public Function Fill(ByVal sError As String) As Boolean
        If Me.Count > 0 Then
            Clear()
        End If
        Return BakedGoodDB.Fill(Me, sError)

    End Function

    ''' <summary>
    ''' Add a BakedGood object to the collection
    ''' and to the datatable
    ''' </summary>
    ''' <param name="objBakedGood">
    ''' BakedGood to add
    ''' </param>
    ''' <remarks>
    ''' Must be Shadows since Add in List is not overridable
    ''' </remarks>
    Public Shadows Sub Add(ByVal objBakedGood As BakedGood)

        MyBase.Add(objBakedGood)
        BakedGoodDB.Add(objBakedGood)

    End Sub

    ''' <summary>
    ''' remove a BakedGood object from the collection
    ''' and from the datatable
    ''' </summary>
    ''' <param name="objBakedGood">
    ''' BakedGood to add
    ''' </param>
    ''' <remarks>
    ''' Must be Shadows since Remove in List is not overridable
    ''' </remarks>

    Public Shadows Sub Remove(ByVal objBakedGood As BakedGood)
        MyBase.Remove(objBakedGood)
        BakedGoodDB.Delete(objBakedGood)
    End Sub

    ''' <summary>
    ''' Change DataTable
    ''' </summary>
    ''' <param name="objBakedGood">
    ''' BakedGood to change
    ''' </param>
    ''' <remarks>
    ''' no need to Shadow since no Change in the List collection
    ''' </remarks>
    Public Sub Change(ByVal objBakedGood As BakedGood)
        BakedGoodDB.Change(objBakedGood)
    End Sub

    Private _iId As Integer
    ''' <summary>
    ''' Locates a BakedGood with a certain ID in the collection
    ''' </summary>
    ''' <param name="iID">ID to find</param>
    ''' <returns>BakedGood with said ID</returns>
    ''' <remarks>Must be overloads because Find is already defined in the base class</remarks>
    Public Overloads Function Find(iID As Integer) As BakedGood
        Dim objBakedGood As BakedGood
        _iId = iID
        objBakedGood = Me.Find(AddressOf FindID)
        Return objBakedGood
    End Function

    Private Function FindID(ByVal objBakedGood As BakedGood) As Boolean
        'necessary for base class's Find
        Return objBakedGood.BakedGoodID = _iId
    End Function
End Class
