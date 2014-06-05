
Partial Class admin_KeepAlive
    Inherits System.Web.UI.Page




    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ';url=KeepAlive.aspx?q=") + DateTime.Now.Ticks
        '<meta http-equiv="refresh" content="2;url=http://webdesign.about.com/">

        Dim MyURL = "url=KeepAlive.aspx?q=" & DateTime.Now.Ticks
        AddMetaTag("meta", "http-equiv", "refresh", "content", "5;" & MyURL & "")
        SessTxt.Text = "Session Extended: " & DateTime.Now.Ticks
    End Sub


    Sub AddMetaTag(ByVal Isim, ByVal Var1, ByVal Val1, Optional ByVal Var2 = "", Optional ByVal Val2 = "", Optional ByVal Var3 = "", Optional ByVal Val3 = "", Optional ByVal Var4 = "", Optional ByVal Val4 = "")
        Dim MyTag As New HtmlGenericControl(Isim)
        MyTag.Attributes.Add(Var1, Val1)

        If Var2 <> "" Then MyTag.Attributes.Add(Var2, Val2)
        If Var3 <> "" Then MyTag.Attributes.Add(Var3, Val3)
        If Var4 <> "" Then MyTag.Attributes.Add(Var4, Val4)

        Page.Header.Controls.Add(MyTag)
    End Sub








End Class
