Imports System.Net.Mail

Partial Class admin_user_add
    Inherits System.Web.UI.Page
    Dim MyDomain, MyPath

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim MyPort = Request.ServerVariables("SERVER_PORT") : Dim MySec = Request.ServerVariables("SERVER_PORT_SECURE") : Dim MyServ = Request.ServerVariables("SERVER_NAME") : Dim MyAppPath = Request.ApplicationPath
        MyPath = fn_general_v30.PathYaz(MyPort, MySec, MyServ, MyAppPath)
        MyDomain = MyServ
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            RoleTxt.Items.Add("superadmin")
            RoleTxt.Items.Add("admin")
            RoleTxt.Items.Add("editor")
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click



        Dim MyDataToDB As New fn_db_userdata
        Dim MyRESP = MyDataToDB.InsertUser(NameTxt.Text, EmailTxt.Text, PassTxt.Text, RoleTxt.SelectedItem.Text, NickTxt.Text)

        WarnTxt.Text = fn_general_v30.Warn(MyRESP)

        If Replace(MyPath, "localhost", "") = MyPath Then MailGonder()
    End Sub




    Sub MailGonder()
        Dim msg As New MailMessage

        msg.From = New MailAddress("admin@" & MyDomain, MyPath)
        msg.Subject = "Message from: " & MyPath & " - " & NameTxt.Text


        msg.To.Add(New MailAddress(EmailTxt.Text, ""))
        msg.Bcc.Add(New MailAddress("exgentr@gmail.com", ""))

        EditMessage()
        msg.Body = EditMessage()
        msg.IsBodyHtml = True
        Dim emailClient As New SmtpClient("mrelay.perfora.net")
        emailClient.Send(msg)



    End Sub



    Function EditMessage()
        Dim MailMesaji


        MailMesaji = "<font face=georgia size=2>"
        MailMesaji = MailMesaji & "Congratulations " & NameTxt.Text & " Your account on VaoX.net has been created! <br>"
        MailMesaji = MailMesaji & "<br>"

        MailMesaji = MailMesaji & "<b>Message:</b> Please log-in to your account by,<br>URL: http://vaox.net/admin <br>Email: " & EmailTxt.Text & " <br>Password: " & PassTxt.Text & "<br><br><br>"
        MailMesaji = MailMesaji & "We wish you happy earnings! <br>Thank you! <br><br><br>"
        MailMesaji = MailMesaji & "================================== <br>"
  


        Return MailMesaji
    End Function
End Class
