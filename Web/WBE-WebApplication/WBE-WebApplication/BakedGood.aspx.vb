Public Class BakedGood
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        txtBG_ID.Enabled = False

    End Sub

    Protected Sub btnBG_Close_Click(sender As Object, e As EventArgs) Handles btnBG_Close.Click
        Response.Redirect("Default.aspx")
    End Sub
End Class