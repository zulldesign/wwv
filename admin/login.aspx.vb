
Partial Class admin_login
    Inherits System.Web.UI.Page



    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginTxt.Click

        Dim MyValidation As New fn_validations_wpdn_v10

        Dim IsValid = MyValidation.Validate_UserLogin(MailTxt.Text, PassTxt.Text)
        If IsValid <> "" Then WarnTxt.Text = fn_general_v30.Warn(IsValid)
        If IsValid <> "" Then Exit Sub


        Dim MyEmail = Trim(MailTxt.Text)

        Dim MyDataFromDB As New fn_db_userdata

        Dim MyRESP As New class_decl_v10.UserDetails
        MyRESP = MyDataFromDB.Get_User_Info(, MyEmail)

        If Trim(MyRESP.MyPass) = "" Then
            WarnTxt.Text = fn_general_v30.Warn("Wrong username or password!")
            Exit Sub
        End If


        If MyRESP.MyPass = PassTxt.Text Then
            Session("user_id") = MyRESP.MyID
            Session("user_name") = MyRESP.MyName
            Session("user_email") = MyRESP.MyEmail
            Session("user_role") = MyRESP.MyRole

            Session("logged") = "yes"
            Response.Redirect("index.aspx?sess=" & MyRESP.MySess & "")
        Else
            WarnTxt.Text = fn_general_v30.Warn("Wrong username or password!")
        End If


    End Sub

End Class
