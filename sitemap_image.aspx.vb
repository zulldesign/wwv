
Partial Class sitemap_image
    Inherits System.Web.UI.Page


    Dim MyDBConf As New db_acc_v21_conf
    Dim MyDBData As New db_acc_v21_data


    Dim STR As New StringBuilder


    Dim LinkSayisi As Integer
    Dim UrlWords
    Dim BasePath

    Dim ListSBK1 = 500 'Sayba Başına Kayıt


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim MyPort = Request.ServerVariables("SERVER_PORT") : Dim MySec = Request.ServerVariables("SERVER_PORT_SECURE") : Dim MyServ = Request.ServerVariables("SERVER_NAME") : Dim MyAppPath = Request.ApplicationPath
        BasePath = fn_general_v30.PathYaz(MyPort, MySec, MyServ, MyAppPath)
        BasePath = "http://bestrecipes1.com/"
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'If Not Page.IsPostBack Then
        '    FindVariables()
        '    WriteSiteMap()


        'End If



    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        FindVariables()
        WriteSiteMap()

        Label1.Text = "Sitemap Created"
    End Sub
    Sub WriteSiteMap()

        SiteMapStart()
        SiteMapData_Content()
        SiteMapEnd()


        'SiteMapGenerate()
        SiteMapGenerate2()
    End Sub


    Sub SiteMapGenerate()
        Response.ContentType = "text/xml"
        Response.Write(STR.ToString())
        Response.End()
    End Sub

    Sub SiteMapGenerate2()
        Dim MyPath = Server.MapPath("sitemap_image.xml")

        fn_general_v30.File_WRITE(MyPath, STR.ToString())

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
        STR.AppendLine("<?xml version=""1.0"" encoding=""UTF-8""?>")
        STR.AppendLine(" <urlset xmlns=""http://www.sitemaps.org/schemas/sitemap/0.9""")
        STR.AppendLine("  xmlns:image=""http://www.google.com/schemas/sitemap-image/1.1"">")

    End Sub
    Sub SiteMapEnd()
        STR.AppendLine("</urlset> ")
        STR.AppendLine("<!-- Total Link: " & LinkSayisi & " -->")
    End Sub

    Sub SiteMapData_Content()

        Dim TblName = "content"
        Dim ColName = "id,category_id,content_title"

        Dim SqlStr = MyDBData.DB_SelectSTR(TblName, ColName)
        Dim DT As System.Data.DataTable
        DT = MyDBData.QueryDataTable(SqlStr)


        Dim MyIDS As New Collection
        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        If KS > 0 Then
            For i = 0 To KS - 1
                Dim MyID = DT.Rows(i).Item(0).ToString()
                Dim CatID = DT.Rows(i).Item(1).ToString()


                Dim MyDataFromDB As New fn_db_data

                Dim MyCatz As New class_decl_v10.ParentCatNamez
                MyCatz = MyDataFromDB.FindBreadCrumb(CatID, BasePath, "topic_keywords")
                Dim CatLink = MyCatz.CatWithLink
                Dim CatForUrl = MyCatz.cat_parent_url & MyCatz.cat_name

                Dim content_title As String = DT.Rows(i).Item(2).ToString()
                Dim TopicURL = wpdn_v10.MakeURL("topic", CatForUrl, content_title, MyID, BasePath)
                Dim TopicImgURL = BasePath & "content/images/" & MyID & ".jpg"
                UrlEkle(TopicURL, TopicImgURL, content_title)
            Next
        End If





    End Sub


    Sub UrlEkle(ByVal TopicURL, ByVal ImgUrl, ByVal content_title)
        TopicURL = Replace(TopicURL, "&", "&amp;")
        ImgUrl = Replace(ImgUrl, "&", "&amp;")





        STR.AppendLine("<url>")
        STR.AppendLine("   <loc>" & TopicURL & "</loc>")
        STR.AppendLine("   <image:image>")
        STR.AppendLine("     <image:loc>" & ImgUrl & "</image:loc>")
        STR.AppendLine("     <image:caption>" & content_title & "</image:caption>")
        STR.AppendLine("     <image:title>" & content_title & "</image:title>")
        STR.AppendLine("   </image:image>")

        STR.AppendLine("</url> ")




        LinkSayisi = LinkSayisi + 1
    End Sub


 


End Class
