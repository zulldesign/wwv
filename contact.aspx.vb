Imports System.Net.Mail

Partial Class contact
    Inherits System.Web.UI.Page


    Dim MyPath, MyDomain

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim CULTURE As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture(Session("lang_code"))
        System.Threading.Thread.CurrentThread.CurrentCulture = CULTURE
        System.Threading.Thread.CurrentThread.CurrentUICulture = CULTURE
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim MyPort = Request.ServerVariables("SERVER_PORT") : Dim MySec = Request.ServerVariables("SERVER_PORT_SECURE") : Dim MyServ = Request.ServerVariables("SERVER_NAME") : Dim MyAppPath = Request.ApplicationPath
        MyPath = fn_general_v30.PathYaz(MyPort, MySec, MyServ, MyAppPath)
        MyDomain = MyServ
        If Session("lang") = "tr" Then
            TitleTxt.Text = "İletişim Formu"
            Button1.Text = "Gönder"

            NameTxt.Text = "İsminiz"
            MailTxt.Text = "Email"
            MessageTxt.Text = "Mesajınız"
        Else
            TitleTxt.Text = "Contact"
            Button1.Text = "Send"

            NameTxt.Text = "Name"
            MailTxt.Text = "Email"
            MessageTxt.Text = "Message"
        End If

        If Not Page.IsPostBack Then Metas()
    End Sub

    Sub Metas()
        Dim DefaultTitle = Session("meta_title")
        Dim DefaultDesc = Session("meta_desc")
        Dim DefaultKeyw = Session("meta_keyw")
        Dim ShortHTTP = Session("short_http_name")

        If Session("lang") = "tr" Then
            Me.Title = "İletişim" & " | " & DefaultTitle
            MetaEkle("description", "İletişim" & " | " & DefaultDesc)
            MetaEkle("keywords", DefaultKeyw)
            WriteMasterFooter("İletişim" & " | " & DefaultTitle)
        Else
            Me.Title = "Contact" & " | " & DefaultTitle
            MetaEkle("description", "Contact" & " | " & DefaultDesc)
            MetaEkle("keywords", DefaultKeyw)
            WriteMasterFooter("Contact" & " | " & DefaultTitle)
        End If

    End Sub

    Sub MetaEkle(ByVal meta_adi As String, ByVal meta_icerik As String)
        Dim yenimeta As New HtmlMeta()
        yenimeta.Name = meta_adi
        yenimeta.Content = meta_icerik
        Page.Header.Controls.Add(yenimeta)
    End Sub
    Sub WriteMasterFooter(ByVal MyTxt)
        Dim mpLabel As Label
        mpLabel = CType(Master.FindControl("TitleForSEOTxt"), Label)
        If Not mpLabel Is Nothing Then
            mpLabel.Text = MyTxt
        End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        CheckYap()
    End Sub

    Sub CheckYap()
        If fn_general_v30.CheckMail(EmailTxt.Text) = False Then
            If Session("lang") = "tr" Then
                WarnTxt.Text = fn_general_v30.Warn("Yanlış E-Mail Adresi!")
            Else
                WarnTxt.Text = fn_general_v30.Warn("Wrong Email Address!")
            End If

        ElseIf Trim(IsimTxt.Text) = "" Then
            If Session("lang") = "tr" Then
                WarnTxt.Text = fn_general_v30.Warn("İsminizi Giriniz!")
            Else
                WarnTxt.Text = fn_general_v30.Warn("Please write your name!")
            End If

        Else

            If Replace(MyPath, "localhost", "") = MyPath Then MailGonder()
            If Session("lang") = "tr" Then
                WarnTxt.Text = fn_general_v30.Warn("Email Gönderildi!")
            Else
                WarnTxt.Text = fn_general_v30.Warn("Email Sent!")
            End If

        End If

    End Sub


    Sub MailGonder()
        Dim msg As New MailMessage

        msg.From = New MailAddress("admin@" & MyDomain, MyPath)
        msg.Subject = "Message from: " & MyPath & " - " & IsimTxt.Text


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

        If Session("lang") = "tr" Then
            MailMesaji = "<font face=georgia size=2>"
            MailMesaji = MailMesaji & "Mesajınız bize ulaştı! <br>"
            MailMesaji = MailMesaji & "<br>"
            MailMesaji = MailMesaji & "<b>İsim :</b> " & IsimTxt.Text & "<br>"
            MailMesaji = MailMesaji & "<b>Email:</b> " & EmailTxt.Text & "<br>"
            MailMesaji = MailMesaji & "<b>Mesajınız:</b> " & MsgTxt.Text & "<br><br>"
            MailMesaji = MailMesaji & "Teşekkürler! <br><br><br>"
            MailMesaji = MailMesaji & "================================== <br>"
        Else
            MailMesaji = "<font face=georgia size=2>"
            MailMesaji = MailMesaji & "We've received your message! <br>"
            MailMesaji = MailMesaji & "<br>"
            MailMesaji = MailMesaji & "<b>Name :</b> " & IsimTxt.Text & "<br>"
            MailMesaji = MailMesaji & "<b>Email:</b> " & EmailTxt.Text & "<br>"
            MailMesaji = MailMesaji & "<b>Message:</b> " & MsgTxt.Text & "<br><br>"
            MailMesaji = MailMesaji & "Thank You! <br><br><br>"
            MailMesaji = MailMesaji & "================================== <br>"
        End If


        Return MailMesaji
    End Function
End Class
