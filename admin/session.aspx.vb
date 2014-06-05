
Partial Class admin_session
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Write(Session.Timeout)
    End Sub
End Class
