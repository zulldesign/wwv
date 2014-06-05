
Partial Class admin_KeepAlive2
    Inherits System.Web.UI.Page

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If Session("logged") <> "yes" Then
            Session("session_test") = "session is dead! "
        End If

        Label1.Text = Session("session_test") & " last updated at: " & DateTime.Now.ToString
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("session_test") = "session is alive! "
        Session("logged") = "yes"

        Server.ScriptTimeout = "3600"

    End Sub
End Class
