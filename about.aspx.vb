
Partial Class about
    Inherits System.Web.UI.Page




    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim CULTURE As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture(Session("lang_code"))
        System.Threading.Thread.CurrentThread.CurrentCulture = CULTURE
        System.Threading.Thread.CurrentThread.CurrentUICulture = CULTURE
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("lang") = "tr" Then
            TitleTxt.Text = "Hakkımızda"
        Else
            TitleTxt.Text = "About"
        End If

        If Not Page.IsPostBack Then Metas()
    End Sub

    Sub Metas()
        Dim DefaultTitle = Session("meta_title")
        Dim DefaultDesc = Session("meta_desc")
        Dim DefaultKeyw = Session("meta_keyw")
        Dim ShortHTTP = Session("short_http_name")

        If Session("lang") = "tr" Then
            Me.Title = "Hakkımızda" & " | " & DefaultTitle
            MetaEkle("description", "Hakkımızda" & " | " & DefaultDesc)
            MetaEkle("keywords", DefaultKeyw)
            WriteMasterFooter("Hakkımızda" & " | " & DefaultTitle)
        Else
            Me.Title = "About Us" & " | " & DefaultTitle
            MetaEkle("description", "About Us" & " | " & DefaultDesc)
            MetaEkle("keywords", DefaultKeyw)
            WriteMasterFooter("About Us" & " | " & DefaultTitle)
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
End Class
