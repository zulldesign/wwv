
Partial Class sitemap2
    Inherits System.Web.UI.Page


    Dim MyDBConf As New db_acc_v21_conf
    Dim MyDBData As New db_acc_v21_data

    Dim Tarihimiz, TarihEksi1

    Dim STR As New StringBuilder
    Dim LinkSayisi As Integer
    Dim UrlWords
    Dim BasePath

    Dim ListSBK1 = 500 'Sayba Başına Kayıt


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim MyPort = Request.ServerVariables("SERVER_PORT") : Dim MySec = Request.ServerVariables("SERVER_PORT_SECURE") : Dim MyServ = Request.ServerVariables("SERVER_NAME") : Dim MyAppPath = Request.ApplicationPath
        BasePath = fn_general_v30.PathYaz(MyPort, MySec, MyServ, MyAppPath)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Tarihimiz = DateTime.Now.ToString("yyy-MM-dd")

        If Not Page.IsPostBack Then
            FindVariables()
            WriteSiteMap()


        End If



    End Sub

    Sub WriteSiteMap()

        Dim Sayfa = Request.QueryString("p")

        If Sayfa = "" Then
            MapUrlStart()

            MapUrlEkle(BasePath & "sitemap.xml?p=s", Tarihimiz)

            If wpdn_v10.ExternalVideo = "yes" Then MapUrlEkle(BasePath & "sitemap_video.xml", Tarihimiz)
            If wpdn_v10.ExternalImages = "yes" Then MapUrlEkle(BasePath & "sitemap_image.xml", Tarihimiz)


            MapUrlEkle(BasePath & "sitemap.xml?p=0", Tarihimiz)
            Dim SayfaSayisi = FindSayfaSayisi()
            If SayfaSayisi >= 2 Then
                For i = 2 To SayfaSayisi
                    Dim MyURL = BasePath & "sitemap.xml?p=" & i - 1
                    MapUrlEkle(MyURL, Tarihimiz)
                Next
            End If


            MapUrlEnd()

        ElseIf Sayfa = "s" Then
            SiteMapStart()
            SiteMapData_Common()
            SiteMapEnd()
        Else
            SiteMapStart()
            SiteMapData_Content()
            SiteMapEnd()
        End If




        SiteMapGenerate()
    End Sub


    Sub SiteMapGenerate()
        Response.ContentType = "text/xml"
        Response.Write(STR.ToString())
        Response.End()
    End Sub

    Sub FindVariables()
        Dim TblName = "portal_conf"
        Dim ColName = "conf_name,conf_value"

        Dim SqlStr = MyDBConf.DB_SelectSTR(TblName, ColName)

        Dim DT As System.Data.DataTable
        DT = MyDBConf.QueryDataTable(SqlStr)


        Dim HttpName = "" : Dim HttpName2 = ""
        Dim RssTitle, RssLink, RssDesc, RssLogo, RssCopy, RssLang, RssLinkLoc
        Dim RssUpdatePeriod = "hourly"
        Dim RssUpdateFreq = "1"

        Dim MySTR = "", i
        Dim KS = DT.Rows.Count  'Kayıt Sayısı
        If KS > 0 Then
            For i = 0 To KS - 1

                Dim conf_name = DT.Rows(i)("conf_name") : Dim conf_value = DT.Rows(i)("conf_value")
                If Replace(conf_name, "http_name", "") <> conf_name Then HttpName = conf_value
                If Replace(HttpName, "http://", "") = HttpName Then HttpName = "http://" & HttpName : RssLink = HttpName
                HttpName2 = HttpName : If Right(HttpName, 1) <> "/" Then HttpName2 = HttpName & "/"
                Session("http_name") = HttpName2

            Next
        End If




    End Sub


    Sub SiteMapStart()
        STR.AppendLine("<?xml version='1.0' encoding='UTF-8'?>")
        STR.AppendLine("<?xml-stylesheet type='text/xsl' href='sitemap.xsl'?>")
        STR.AppendLine("<urlset")
        STR.AppendLine("      xmlns='http://www.sitemaps.org/schemas/sitemap/0.9'")
        STR.AppendLine("      xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'")
        STR.AppendLine("      xsi:schemaLocation='http://www.sitemaps.org/schemas/sitemap/0.9")
        STR.AppendLine("      http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd'>")
        STR.AppendLine("<!-- Created with eXtreme SiteMap Builder - www.eX.gen.tr  -->")
    End Sub
    Sub SiteMapEnd()
        STR.AppendLine("</urlset>")
        STR.AppendLine("<!-- Total Link: " & LinkSayisi & " -->")
    End Sub



    Sub SiteMapData_Common()
        Dim HttpName = Session("http_name")

        UrlEkle(HttpName, "1.0", Tarihimiz, "always")
        UrlEkle(HttpName & "index.aspx", "1.0", Tarihimiz, "always")
        UrlEkle(HttpName & "about.aspx", "0.9", Tarihimiz, "daily")
        UrlEkle(HttpName & "archive.aspx", "0.9", Tarihimiz, "daily")
        UrlEkle(HttpName & "contact.aspx", "0.9", Tarihimiz, "daily")
        UrlEkle(HttpName & "rss.aspx", "0.9", Tarihimiz, "daily")
        UrlEkle(HttpName & "search.aspx", "0.9", Tarihimiz, "daily")
        UrlEkle(HttpName & "topic.aspx", "0.9", Tarihimiz, "daily")

    End Sub

    Sub WriteArticle(ByVal IDs)

        Dim TblName = "content,categories"
        Dim ColName = "content.id,content.content_title,content.id,content.author,content.content_date,categories.cat_name,content.content,content.category_id,categories.path"
        'im ColName = "0ontent.id,1ontent.content_title,2ontent.content_intro,3ontent.author,4ontent.content_date,5ontent.categories,6ontent.content"
        Dim WhereSTR = "content.id IN (" & IDs & ") AND categories.id=content.category_id"
        Dim OrderBy = "content_date DESC"


        Dim SqlStr = MyDBData.DB_SelectSTR(TblName, ColName, WhereSTR, OrderBy)
        Dim DT As System.Data.DataTable
        DT = MyDBData.QueryDataTable(SqlStr)

        Dim i
        Dim KS = DT.Rows.Count 'Kayıt Sayısı

        If KS > 0 Then
            For i = 0 To KS - 1

                Dim MyPath = DT.Rows(i)("path").ToString & DT.Rows(i)("cat_name").ToString

                Dim Linkimiz = wpdn_v10.MakeURL("topic", MyPath, DT.Rows(i)("content_title").ToString, DT.Rows(i)("id").ToString, BasePath)
                UrlEkle(Linkimiz, "0.8", Tarihimiz, "daily")


                Dim DataFromDB As New fn_db_data
                Dim MyRESP As New class_decl_v10.Keywordz
                MyRESP = DataFromDB.FindKeywWithLink(DT.Rows(i)("id").ToString, MyPath, DT.Rows(i)("content_title").ToString, "", BasePath)


                Dim DBKeyw() = MyRESP.TotalKeywWithURLz.ToString.Split("¥")
                For j = 0 To UBound(DBKeyw)
                    Dim MyWord = Trim(DBKeyw(j).ToString)
                    If Trim(MyWord) <> "" Then
                        Dim MyLink = Trim(DBKeyw(j).ToString)
                        UrlEkle(MyLink, "0.7", Tarihimiz, "hourly")
                    End If
                Next

            Next
        End If

    End Sub

    Sub SiteMapData_Content()

        Dim TblName = "content"
        Dim ColName = "id"
  
        Dim SqlStr = MyDBData.DB_SelectSTR(TblName, ColName)
        Dim DT As System.Data.DataTable
        DT = MyDBData.QueryDataTable(SqlStr)


        Dim MyIDS As New Collection
        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        If KS > 0 Then
            For i = 0 To KS - 1
                Dim MyVal = DT.Rows(i)("id").ToString()
                MyIDS.Add(MyVal)
            Next
        End If


        Dim CurPage = Request.QueryString("p") : If CurPage = "" Then CurPage = 0

        Dim FA = CurPage * ListSBK1 'First Article
        Dim IDs
        For i = 1 To ListSBK1
            If FA + i <= MyIDS.Count Then
                IDs = IDs & MyIDS(FA + i) & ", "
            End If
        Next

        WriteArticle(IDs)


        'Dim DT As System.Data.DataTable
        'DT = MyDB.QueryDataTable(SqlStr)


        'Dim KS = DT.Rows.Count - 1 'Kayıt Sayısı

        'Dim SayfaSayisi As Integer = Val(KS) / SayfaBasinaKayit

        'Dim Sayfa = Request.QueryString("p")


        'Dim IlkKayit = Val(Sayfa) * SayfaBasinaKayit
        'Dim SonKayit = IlkKayit + SayfaBasinaKayit - 1
        'If SonKayit > KS Then SonKayit = KS

        'Dim HttpName = Session("http_name")
        'Dim MySTR = "", i



        'If KS > 0 Then
        '    For i = IlkKayit To SonKayit

        '        Dim Linkimiz = wpdn_v10.MakeURL("topic", DT.Rows(i)("categories"), DT.Rows(i)("content_title"), DT.Rows(i)("id"), BasePath)
        '        UrlEkle(Linkimiz, "0.8", Tarihimiz, "daily")

        '        Dim DBKeyw()
        '        DBKeyw = DT.Rows(i)("keywords").ToString.Split(",")
        '        For j = 0 To UBound(DBKeyw)
        '            Dim MyWord = Trim(DBKeyw(j).ToString)
        '            If Trim(MyWord) <> "" Then
        '                Dim MyLink = wpdn_v10.MakeURL("search", , MyWord, , BasePath)
        '                UrlEkle(MyLink, "0.7", Tarihimiz, "hourly")
        '            End If
        '        Next

        '    Next
        'End If






    End Sub





    Sub UrlEkle(ByVal url, ByVal priority, ByVal lastmod, ByVal changefreq)
        url = Replace(url, "&", "&amp;")

        STR.AppendLine("<url>")
        STR.AppendLine("<loc>" & url & "</loc>")
        STR.AppendLine("<priority>" & priority & "</priority>")
        STR.AppendLine("<lastmod>" & lastmod & "</lastmod>")
        STR.AppendLine("<changefreq>" & changefreq & "</changefreq>")
        STR.AppendLine("</url>")

        LinkSayisi = LinkSayisi + 1
    End Sub



    Sub SiteMapData_Searched()

    End Sub
    Function FindSayfaSayisi()
        Dim TblName = "content"
        Dim ColName = "count(id) as KS"


        Dim SqlStr = MyDBData.DB_SelectSTR(TblName, ColName)
        Dim KS = MyDBData.QueryExecuteScalar(SqlStr)
        Dim SayfaSayisi As Integer = KS / ListSBK1
        Return SayfaSayisi
    End Function

    Public Shared Function aTitle(ByVal LinkName)
        LinkName = Replace(LinkName, "'", "")
        LinkName = Replace(LinkName, Chr(34), "")
        LinkName = Replace(LinkName, ")", "")
        LinkName = Replace(LinkName, "(", "")
        LinkName = Replace(LinkName, ".", "")
        LinkName = Replace(LinkName, ",", "")
        LinkName = Trim(LinkName)
        Return LinkName
    End Function


    Sub MapUrlStart()
        STR.AppendLine("<?xml version=""1.0"" encoding=""UTF-8""?>")
        STR.AppendLine("<sitemapindex xmlns=""http://www.sitemaps.org/schemas/sitemap/0.9"">")
    End Sub
    Sub MapUrlEkle(ByVal url, ByVal lastmod)
        STR.AppendLine("<sitemap>")
        STR.AppendLine("<loc>" & url & "</loc>")
        STR.AppendLine("<lastmod>" & lastmod & "</lastmod>")
        STR.AppendLine("</sitemap>")
    End Sub
    Sub MapUrlEnd()
        STR.AppendLine("</sitemapindex>")
    End Sub
End Class
