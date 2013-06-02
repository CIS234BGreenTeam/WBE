Imports libWBEData
Imports libWBEBR

''' <summary>
''' This form is used to set the Baked Goods available for purchase
''' </summary>
''' <remarks></remarks>
Public Class frmBakedGood
    Private _colBakedGoods As New colBakedGoods

    Private Sub frmBakedGood_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sError As String = ""

        'Fill the collection
        BakedGoodDB.SetupAdapter()

        If _colBakedGoods.Fill(sError) Then
            _colBakedGoods.Sort()
            FillBakedGoodsList()
        Else
            MessageBox.Show(sError)
        End If

        lstBakedGoods.SelectedIndex = 0
    End Sub

    Private Sub FillBakedGoodsList()
        lstBakedGoods.Items.Clear()

        'Display each item in the listbox
        For Each BakedGood As BakedGood In _colBakedGoods
            BakedGood.DisplayAll = True
            lstBakedGoods.Items.Add(BakedGood)
        Next
    End Sub

    Private Sub lstBakedGoods_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstBakedGoods.SelectedIndexChanged
        'Show data from seleted item
        If lstBakedGoods.Items.Count > 0 And lstBakedGoods.SelectedIndex <> -1 Then
            Dim BakedGood As BakedGood
            BakedGood = DirectCast(lstBakedGoods.SelectedItem, BakedGood)
            txtName.Text = BakedGood.Name
            txtPrice.Text = BakedGood.UnitPrice.ToString("f")
            chkInactive.Checked = BakedGood.IsInactive
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'Save data
        Save()
        If btnUpdate.Text = "&Save" Then
            btnUpdate.Text = "&Update"
            btnAdd.Text = "&Add"
        End If
    End Sub

    ''' <summary>
    ''' Save new or modified data
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Save()
        Dim BakedGood As BakedGood

        If lstBakedGoods.SelectedIndex <> -1 Then
            BakedGood = DirectCast(lstBakedGoods.SelectedItem, BakedGood)
        Else
            BakedGood = New BakedGood
        End If

        epBakedGood.Clear()

        'Check the user input is valid
        If IsValidData(BakedGood) Then
            Dim sError As String = ""
            BakedGood.IsInactive = chkInactive.Checked

            'If BakedGoodID not zero, then existing customer
            If BakedGood.BakedGoodID <> 0 Then
                _colBakedGoods.Change(BakedGood)
            Else  'If BakedGoodID = 0, then new customer.
                _colBakedGoods.Add(BakedGood)
            End If

            BakedGoodDB.Update()

            'Need to refill listbox to account for changes
            _colBakedGoods.Clear()
            If (_colBakedGoods.Fill(sError)) Then
                _colBakedGoods.Sort()
                FillBakedGoodsList()
                lstBakedGoods.SelectedItem = SetBakedGoodSelection(BakedGood)
            Else
                MessageBox.Show(sError)
            End If

        End If
    End Sub

    ''' <summary>
    ''' Check data input by user is valid
    ''' </summary>
    ''' <param name="BakedGood"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidData(BakedGood As BakedGood) As Boolean
        Return IsValidName(BakedGood) And IsValidPrice(BakedGood)
    End Function

    ''' <summary>
    ''' Set the list box selection
    ''' </summary>
    ''' <param name="BakedGood"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetBakedGoodSelection(BakedGood As BakedGood) As BakedGood
        For i As Integer = 0 To lstBakedGoods.Items.Count - 1
            Dim tempBakedGood As BakedGood
            tempBakedGood = DirectCast(lstBakedGoods.Items(i), BakedGood)
            If tempBakedGood.Name <> BakedGood.Name Or
                tempBakedGood.UnitPrice <> BakedGood.UnitPrice Then
                Continue For
            Else
                Return tempBakedGood
            End If
        Next
    End Function

    ''' <summary>
    ''' Check the name input by the user is valid
    ''' </summary>
    ''' <param name="BakedGood"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidName(BakedGood As BakedGood) As Boolean
        Try
            BakedGood.Name = txtName.Text
            Return True
        Catch ex As Exception
            epBakedGood.SetError(txtName, ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Check the price input by the user is valid
    ''' </summary>
    ''' <param name="BakedGood"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidPrice(BakedGood As BakedGood) As Boolean
        Try
            BakedGood.UnitPrice = Convert.ToDecimal(txtPrice.Text)
            Return True

        Catch ex As FormatException
            epBakedGood.SetError(txtPrice, BakedGood.UnitPriceError)
            Return False

        Catch ex As Exception
            epBakedGood.SetError(txtPrice, ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Click the Add button. This clears the form and disables the Add buttons 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If btnAdd.Text = "&Add" Then
            ClearForm()
            btnAdd.Text = "&Cancel"
            btnUpdate.Text = "&Save"
        Else
            btnAdd.Text = "&Add"
            btnUpdate.Text = "&Update"
            lstBakedGoods.SelectedIndex = 0
        End If

    End Sub

    ''' <summary>
    ''' Clear the form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearForm()
        txtName.Clear()
        txtPrice.Clear()
        chkInactive.Checked = False
        lstBakedGoods.SelectedIndex = -1
    End Sub

End Class