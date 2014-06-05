
Partial Class admin_index
    Inherits System.Web.UI.Page

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        If KullTxt.Text = "site" And SifreTxt.Text = "panel1234" Then
            Session("logged") = "yes"
        Else
            Session("logged") = "no"
        End If
    End Sub
End Class
