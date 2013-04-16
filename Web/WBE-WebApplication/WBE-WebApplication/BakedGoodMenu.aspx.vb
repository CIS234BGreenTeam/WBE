Public Class BakedGoodMenu
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        txtMenu_ProductID.Enabled = False
        txtMenu_ItemName.Enabled = False
        txtMenu_Price.Enabled = False

    End Sub

    Protected Sub btnMenu_AddItem_Click(sender As Object, e As EventArgs) Handles btnMenu_AddItem.Click
        Response.Redirect("Orders.aspx")
    End Sub

    Protected Sub btnMenu_Cancel_Click(sender As Object, e As EventArgs) Handles btnMenu_Cancel.Click
        Response.Redirect("Orders.aspx")
    End Sub
End Class