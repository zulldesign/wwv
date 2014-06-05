

Partial Class sitemap_video
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



            MapUrlEkle(BasePath & "sitemap_video.xml?p=0", Tarihimiz)
            Dim SayfaSayisi = FindSayfaSayisi()
            If SayfaSayisi >= 2 Then
                For i = 2 To SayfaSayisi
                    Dim MyURL = BasePath & "sitemap_video.xml?p=" & i - 1
                    MapUrlEkle(MyURL, Tarihimiz)
                Next
            End If


            MapUrlEnd()


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
        Dim MyTxt
        STR.AppendLine("<urlset xmlns=""http://www.sitemaps.org/schemas/sitemap/0.9""" & vbCrLf)
        STR.AppendLine("        xmlns:video=""http://www.google.com/schemas/sitemap-video/1.1""> " & vbCrLf)
        STR.AppendLine("           <!-- Created with eXtreme SiteMap Builder - www.eX.gen.tr  --> " & vbCrLf)

    End Sub
    Sub SiteMapEnd()
        Dim MyTxt
        STR.AppendLine("</urlset>" & vbCrLf)
        STR.AppendLine("<!-- Total Link: " & LinkSayisi & " -->" & vbCrLf)

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




    End Sub


    Sub WriteArticle(ByVal IDs)

        Dim TblName = "content,categories"
        Dim ColName = "content.id,content.content_title,content.content,content.author,content.content_date,categories.cat_name,content.content,content.category_id,categories.path"
        'im ColName = "0ontent.id,1ontent.content_title,2ontent.content_intro,3ontent.author,4ontent.content_date,5ontent.categories,6ontent.content"
        Dim WhereSTR = "content.id IN (" & IDs & ") AND categories.id=content.category_id"
        Dim OrderBy = "content_date DESC"


        Dim SqlStr = MyDBData.DB_SelectSTR(TblName, ColName, WhereSTR, OrderBy)

        Dim DT As System.Data.DataTable
        DT = MyDBData.QueryDataTable(SqlStr)

        Dim R(8), i
        Dim KS = DT.Rows.Count 'Kayıt Sayısı

        If KS > 0 Then
            For i = 0 To KS - 1

                Dim MyId = DT.Rows(i)("id").ToString : Dim MyCat = DT.Rows(i)("cat_name").ToString : Dim MyTit = fn_general_v30.HtmlTemizle(DT.Rows(i)("content_title").ToString) : Dim MyDesc = Left(fn_general_v30.HtmlTemizle(DT.Rows(i)("content").ToString), 500)
                Dim MyPath = DT.Rows(i)("path").ToString & MyCat
                Dim Linkimiz = wpdn_v10.MakeURL("topic", MyPath, DT.Rows(i)("content_title").ToString, DT.Rows(i)("id").ToString, BasePath)

                Dim ImgURL = BasePath & "images/intro-" & MyId & ".gif"
                Dim vURL = BasePath & "images/intro-" & MyId & ".flv"
                Dim vTitle = MyCat & ": " & MyTit

                Dim MyKeyw = MyCat & ", " & MyCat & " video, " & MyTit & ", " & MyTit & " video"
                UrlEkle(Linkimiz, ImgURL, vTitle, MyDesc, vURL, "600", MyKeyw, MyCat)

            Next
        End If

    End Sub

    Sub UrlEkle(ByVal vsayfa, ByVal vthumb, ByVal vtitle, ByVal vdesc, ByVal vloc, ByVal vsure, ByVal vkeyw, ByVal vcat)
        vloc = Replace(vloc, "&", "&amp;")
        vsayfa = Replace(vsayfa, "&", "&amp;")
        vtitle = Replace(vtitle, "&", "&amp;")
        vdesc = Replace(vtitle, "&", "&amp;")
        vkeyw = Replace(vkeyw, "&", "&amp;")
        vcat = Replace(vcat, "&", "&amp;")

        'vsayfa = ".html"
        'vthumb = "http://www.example.com/thumbs/123.jpg"
        'vtitle = "Grilling steaks for summer"
        'vdesc = "Grilling steaks for suasdfasdfammer"
        'vloc = "http://safd.flv"
        'Dim vPath = BasePath & "images/intro-" & vid & ".flv"
        'vsure = "600"

        Dim vrate = fn_general_v30.RandomNumber2(5) & "." & fn_general_v30.RandomNumber2(10)
        Dim pPath = BasePath & ""

        Dim keyw() = vkeyw.ToString.Split(",")
        Dim i, MyKeyw
        For i = 0 To UBound(keyw)
            MyKeyw = MyKeyw & "<video:tag>" & keyw(i) & "</video:tag>"
        Next

        vsure = fn_general_v30.RandomNumber2(600, 400)

        Dim MyTxt
        STR.AppendLine("   <url> " & vbCrLf)
        STR.AppendLine("     <loc>" & vsayfa & "</loc>" & vbCrLf)
        STR.AppendLine("     <video:video>" & vbCrLf)
        STR.AppendLine("       <video:thumbnail_loc>" & vthumb & "</video:thumbnail_loc> " & vbCrLf)
        STR.AppendLine("       <video:title>" & vtitle & "</video:title>" & vbCrLf)
        STR.AppendLine("       <video:description>" & vdesc & "</video:description>" & vbCrLf)
        STR.AppendLine("       <video:content_loc>" & vloc & "</video:content_loc>" & vbCrLf)
        'STR.AppendLine "       <video:player_loc allow_embed=""yes"" autoplay=""ap=1"">http://www.example.com/videoplayer.swf?video=123</video:player_loc>" & vbCrLf

        STR.AppendLine("       <video:duration>" & vsure & "</video:duration>" & vbCrLf)
        STR.AppendLine("       <video:live>no</video:live>" & vbCrLf)
        'STR.AppendLine "       <video:expiration_date>2009-11-05T19:20:30+08:00</video:expiration_date>" & vbCrLf
        STR.AppendLine("       <video:rating>" & vrate & "</video:rating> " & vbCrLf)
        'STR.AppendLine "       <video:view_count>12345</video:view_count>    " & vbCrLf
        'STR.AppendLine "       <video:publication_date>2007-11-05T19:20:30+08:00</video:publication_date>" & vbCrLf
        STR.AppendLine("       " & MyKeyw & vbCrLf)
        STR.AppendLine("       <video:category>" & vcat & "</video:category>" & vbCrLf)
        STR.AppendLine("       <video:family_friendly>yes</video:family_friendly>   " & vbCrLf)
        'STR.AppendLine "       <video:restriction relationship=""allow"">IE GB US CA</video:restriction> " & vbCrLf
        'STR.AppendLine "       <video:gallery_loc title=""Cooking Videos"">http://cooking.example.com</video:gallery_loc>" & vbCrLf
        'STR.AppendLine "       <video:price currency=""EUR"">1.99</video:price>" & vbCrLf
        'STR.AppendLine "       <video:requires_subscription>yes</video:requires_subscription>" & vbCrLf
        'STR.AppendLine "       <video:uploader info=""http://www.example.com/users/grillymcgrillerson"">GrillyMcGrillerson</video:uploader>" & vbCrLf

        STR.AppendLine("     </video:video> " & vbCrLf)
        STR.AppendLine("   </url> " & vbCrLf)


        LinkSayisi = LinkSayisi + 1
    End Sub

  
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
    Function FindSayfaSayisi()
        Dim TblName = "content"
        Dim ColName = "count(id) as KS"


        Dim SqlStr = MyDBData.DB_SelectSTR(TblName, ColName)
        Dim KS = MyDBData.QueryExecuteScalar(SqlStr)
        Dim SayfaSayisi As Integer = KS / ListSBK1
        Return SayfaSayisi
    End Function

End Class
