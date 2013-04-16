Public Class Orders
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtO_OrderID.Enabled = False
        txtO_OrderDate.Enabled = False
        chkO_OrderShipped.Enabled = False
        txtO_TotalCharge.Enabled = False
        txtOI_ItemID.Enabled = False
        txtOI_ItemName.Enabled = False
        txtOI_UnitPrice.Enabled = False
        txtOI_ExtendPrice.Enabled = False
        
    End Sub

    Protected Sub btnOI_AddItem_Click(sender As Object, e As EventArgs) Handles btnOI_AddItem.Click
        Response.Redirect("BakedGoodMenu.aspx")
    End Sub
End Class