

Partial Class rss
    Inherits System.Web.UI.Page

    Dim MyDBData As New db_acc_v21_data
    Dim MyDBConf As New db_acc_v21_conf

    Dim XMLText
    Dim LinkSayisi As Integer

    Dim BasePath


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim MyPort = Request.ServerVariables("SERVER_PORT") : Dim MySec = Request.ServerVariables("SERVER_PORT_SECURE") : Dim MyServ = Request.ServerVariables("SERVER_NAME") : Dim MyAppPath = Request.ApplicationPath
        BasePath = fn_general_v30.PathYaz(MyPort, MySec, MyServ, MyAppPath)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Page.IsPostBack Then
            WriteFromDB()

        End If
    End Sub
    Sub WriteFromDB()
        RSS_Yaz()


    End Sub
    Sub RSS_Yaz()

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

                If Replace(conf_name, "meta_title", "") <> conf_name Then RssTitle = conf_value
                If Replace(conf_name, "meta_desc", "") <> conf_name Then RssDesc = conf_value
                If Replace(conf_name, "http_name", "") <> conf_name Then HttpName = conf_value
                If Replace(HttpName, "http://", "") = HttpName Then HttpName = "http://" & HttpName : RssLink = HttpName
                HttpName2 = HttpName : If Right(HttpName, 1) <> "/" Then HttpName2 = HttpName & "/"
                If Replace(conf_name, "portal_logo", "") <> conf_name Then RssLogo = HttpName2 & conf_value
                If Replace(conf_name, "text_copyright", "") <> conf_name Then RssCopy = conf_value
                If Replace(conf_name, "lang_code", "") <> conf_name Then RssLang = conf_value
                RssLinkLoc = HttpName2 & "rss.aspx"
            Next
        End If





        XMLText = XMLText & "<?xml version='1.0' encoding='utf-8'?>" & vbCrLf
        XMLText = XMLText & "<rss version='2.0'"
        XMLText = XMLText & "       xmlns:atom='http://www.w3.org/2005/Atom'"
        XMLText = XMLText & "       xmlns:sy='http://purl.org/rss/1.0/modules/syndication/'"
        XMLText = XMLText & "       xmlns:dc='http://purl.org/dc/elements/1.1/'"
        XMLText = XMLText & "       xmlns:content='http://purl.org/rss/1.0/modules/content/'"
        XMLText = XMLText & "       >" & vbCrLf

        XMLText = XMLText & "	<channel>" & vbCrLf
        XMLText = XMLText & "		<title>" & Clr_RssItem(RssTitle) & "</title>" & vbCrLf
        XMLText = XMLText & "		<link>" & Clr_RssItem(RssLink) & "</link>" & vbCrLf
        XMLText = XMLText & "		<description>" & Clr_RssItem(RssDesc) & "</description>" & vbCrLf
        XMLText = XMLText & "		<copyright>" & Clr_RssItem(RssCopy) & "</copyright>" & vbCrLf
        XMLText = XMLText & "		<language>" & Clr_RssItem(RssLang) & "</language>" & vbCrLf
        XMLText = XMLText & "		<ttl>5</ttl>" & vbCrLf
        XMLText = XMLText & "		<lastBuildDate>" & String.Format("{0:R}", DateTime.Now) & "</lastBuildDate>" & vbCrLf

        XMLText = XMLText & "		<atom:link href='" & RssLinkLoc & "' rel='self' type='application/rss+xml' />" & vbCrLf
        XMLText = XMLText & "		<sy:updatePeriod>" & RssUpdatePeriod & "</sy:updatePeriod>" & vbCrLf
        XMLText = XMLText & "		<sy:updateFrequency>" & RssUpdateFreq & "</sy:updateFrequency>" & vbCrLf

        XMLText = XMLText & "       <image>" & vbCrLf
        XMLText = XMLText & "           <title>" & Clr_RssItem(RssTitle) & "</title>" & vbCrLf
        XMLText = XMLText & "           <url>" & RssLogo & "</url>" & vbCrLf
        XMLText = XMLText & "           <link>" & RssLink & "</link>" & vbCrLf
        XMLText = XMLText & "       </image>" & vbCrLf


        RSS_DataYaz(HttpName2)


        XMLText = XMLText & "	</channel>" & vbCrLf
        XMLText = XMLText & "</rss>" & vbCrLf


        Response.ContentType = "text/xml"
        Response.Write(XMLText.ToString())
        Response.End()
    End Sub



    Sub RSS_DataYaz(ByVal httpname2)

        Dim MyDataFromDB As New fn_db_data
        Dim MyANSW As New class_decl_v10.ContentIDs
        MyANSW = MyDataFromDB.GetTotalContentIDs

        Dim MyIDs = MyANSW.ContentIDs

        If wpdn_v10.MixedContent = "yes" Then
            MyIDs = fn_general_v30.RandomSec(MyIDs, wpdn_v10.ListSBK)
            WriteContentByIDs(httpname2, MyIDs, "yes")
        Else
            WriteContentByIDs(httpname2)
        End If



    End Sub
    Sub WriteContentByIDs(ByVal HttpName2, Optional ByVal IDs = "", Optional ByVal MixedContent = "no")

        Dim TblName, ColName, WhereSTR, OrderBy

        If MixedContent = "yes" Then
            TblName = "content,categories"
            ColName = "content.id,content.content_title,content.content,content.author,content.content_date,categories.cat_name,content.content,content.category_id,categories.path"
            'olName = "0ontent.id,1ontent.content_title,2ontent.content_intro,3ontent.author,4ontent.content_date,5ontent.categories,6ontent.content"
            WhereSTR = "categories.id=content.category_id AND content.id IN (" & IDs & ")"
            OrderBy = "content_date DESC"

        Else
            TblName = "content,categories"
            ColName = "TOP 50 content.id,content.content_title,content.content,content.author,content.content_date,categories.cat_name,content.content,content.category_id,categories.path"
            'olName = "0ontent.id,1ontent.content_title,2ontent.content_intro,3ontent.author,4ontent.content_date,5ontent.categories,6ontent.content"
            WhereSTR = "categories.id=content.category_id"
            OrderBy = "content_date DESC"
        End If


        Dim SqlStr = MyDBData.DB_SelectSTR(TblName, ColName, WhereSTR, OrderBy)

        Dim DT As System.Data.DataTable
        DT = MyDBData.QueryDataTable(SqlStr)

        Dim MySTR = "", i
        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        If KS > 0 Then
            For i = 0 To KS - 1

                'If i = 50 Then Exit For
                Dim MyPath = DT.Rows(i)("path").ToString & DT.Rows(i)("cat_name").ToString
                Dim Author = DT.Rows(i)("author").ToString
                Dim MovLink = wpdn_v10.MakeURL("topic", MyPath, DT.Rows(i)("content_title").ToString, DT.Rows(i)("id").ToString, BasePath)

                Dim content_intro = DT.Rows(i)("content").ToString
                If Replace(content_intro, "{READ MORE}", "") = content_intro Then
                    content_intro = content_intro
                Else
                    content_intro = fn_general_v30.FindAndCutData_Before(content_intro, "{READ MORE}")
                End If
                Dim MyIntro = content_intro

                Dim ContDate = DT.Rows(i)("content_date").ToString
                Dim MovCat = DT.Rows(i)("cat_name").ToString
                'Dim MovPic = DR.GetValue(5).ToString
                Dim MyID = DT.Rows(i)("id").ToString
                Dim MyTit = DT.Rows(i)("content_title").ToString

                If Author = "" Then Author = " " : If MyTit = "" Then MyTit = " " : If Trim(MyIntro) = "" Then MyIntro = " " : If MovLink = "" Then MovLink = " " : If MovCat = "" Then MovCat = " "

                AddItem(MyID, MyTit, MyIntro, Author, MovLink, ContDate, MovCat, HttpName2)

            Next
        End If



    End Sub

    Sub AddItem(ByVal guid, ByVal title, ByVal desc, ByVal author, ByVal link, ByVal pubDate, ByVal category, ByVal HttpName2)
        Dim MyDate As Date = pubDate
        pubDate = String.Format("{0:R}", MyDate)

        title = Clr_RssItem(title)
        category = Clr_RssItem(category)


        desc = fn_general_v30.HtmlCut(desc, wpdn_v10.IntroLen) & "......"

        Dim MyDESC
        MyDESC = MyDESC & "<content:encoded>" & vbCrLf
        MyDESC = MyDESC & "<![CDATA["

        MyDESC = MyDESC & "<p>" & desc & "</p>" & vbCrLf
        MyDESC = MyDESC & "<p>Category: " & category & "</p>" & vbCrLf
        MyDESC = MyDESC & wpdn_v10.PostTopicForArticle
        MyDESC = MyDESC & "]]></content:encoded>" & vbCrLf


        XMLText = XMLText & "		<item>" & vbCrLf
        XMLText = XMLText & "			<guid isPermaLink='false'>" & link & "</guid>" & vbCrLf 'unique id
        XMLText = XMLText & "			<category>" & category & "</category>" & vbCrLf
        XMLText = XMLText & "			<title>" & title & "</title>" & vbCrLf
        XMLText = XMLText & "			<description>" & MyDESC & "</description>" & vbCrLf
        XMLText = XMLText & "			<link>" & link & "</link>" & vbCrLf
        'XMLText = XMLText & "			<author>" & author & "</author>" & vbCrLf 'Mail adresi olmalı bu yüzden creator kullanıldı
        XMLText = XMLText & "           <dc:creator>" & author & "</dc:creator>" & vbCrLf
        XMLText = XMLText & "			<pubDate>" & pubDate & "</pubDate>" & vbCrLf
        'XMLText = XMLText & tablostring
        XMLText = XMLText & "		</item>" & vbCrLf

    End Sub

    Function Clr_RssItem(ByVal MyTxt)
        MyTxt = Replace(MyTxt, "&", "&amp;")
        Return MyTxt
    End Function

End Class