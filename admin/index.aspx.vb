
Partial Class admin_index
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Response.Redirect("article_add.aspx")
    End Sub
End Class
