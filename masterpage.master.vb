

Partial Class hc_MasterPage2
    Inherits System.Web.UI.MasterPage

    Dim MyDBConf As New db_acc_v21_conf
    Dim MyDBData As New db_acc_v21_data



    Dim BasePath



    Sub Globalize()
        Dim CULTURE As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture(Session("lang_code"))
        System.Threading.Thread.CurrentThread.CurrentCulture = CULTURE
        System.Threading.Thread.CurrentThread.CurrentUICulture = CULTURE
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init


        Dim MyPort = Request.ServerVariables("SERVER_PORT") : Dim MySec = Request.ServerVariables("SERVER_PORT_SECURE") : Dim MyServ = Request.ServerVariables("SERVER_NAME") : Dim MyAppPath = Request.ApplicationPath
        BasePath = fn_general_v30.PathYaz(MyPort, MySec, MyServ, MyAppPath)
        AddMetaTag("base", "href", BasePath)

        AddMetaTag("link", "href", "themes/default/css/reset.css", "rel", "stylesheet", "type", "text/css")
        AddMetaTag("link", "href", "themes/default/css/wpdn-v1,0.css", "rel", "stylesheet", "type", "text/css")

        Dim RssLink = BasePath & "rss.aspx" : Dim RssTitle = wpdn_v10.RssTitle
        AddMetaTag("link", "href", RssLink, "rel", "alternate", "type", "application/rss+xml", "title", RssTitle)


        AddMetaTag("script", "src", "http://ajax.googleapis.com/ajax/libs/swfobject/2.2/swfobject.js", "type", "text/javascript")

        If wpdn_v10.ShowFullScreenFlashBG <> "" Then
            AddMetaTag("link", "href", "images/background/flash-full-screen.css", "rel", "stylesheet", "type", "text/css") 'fullscreen background
            WriteFlashBG()
        End If

        'AddMetaTag("script", "src", "scripts/swfobject.js", "type", "text/javascript")


        AddMetaTag("script", "src", "scripts/flowplayer/flowplayer-3.2.6.min.js", "type", "text/javascript")

        AddMetaTag("meta", "property", "fb:admins", "content", "srknbal")



        If Session("lang") = "" Then
            Session_PortalInformations()
            Session_WriteLangTranslations()

        End If

        Globalize()

        If Not Page.IsPostBack Then

            WriteContent()

            AdSense1Txt.Text = wpdn_v10.GetAdsenseCode1()
            Adsense2Txt.Text = wpdn_v10.GetAdsenseCode2()
            WriteReferrals()

            CounterSTR.Text = "</span>" & vbCrLf & wpdn_v10.SayyacSTR & "<span>"
        End If
    _

    End Sub



    Sub AddMetaTag(ByVal Isim, ByVal Var1, ByVal Val1, Optional ByVal Var2 = "", Optional ByVal Val2 = "", Optional ByVal Var3 = "", Optional ByVal Val3 = "", Optional ByVal Var4 = "", Optional ByVal Val4 = "")
        Dim MyTag As New HtmlGenericControl(Isim)
        MyTag.Attributes.Add(Var1, Val1)

        If Var2 <> "" Then MyTag.Attributes.Add(Var2, Val2)
        If Var3 <> "" Then MyTag.Attributes.Add(Var3, Val3)
        If Var4 <> "" Then MyTag.Attributes.Add(Var4, Val4)

        Page.Header.Controls.Add(MyTag)
    End Sub

    'Sub AltKatYaz(Optional ByVal CatID = "")


    '    Dim TblName = "categories"
    '    Dim ColName = "id,cat_name,parent_id,path"
    '    Dim WhereSTR = "parent_id=" & CatID
    '    Dim SqlStr = MyDBData.DB_SelectSTR(TblName, ColName, WhereSTR)

    '    Dim DT As System.Data.DataTable
    '    DT = MyDBData.QueryDataTable(SqlStr)

    '    Dim MySTR = "", k
    '    Dim KS = DT.Rows.Count 'Kayıt Sayısı
    '    If KS > 0 Then
    '        For k = 0 To KS - 1
    '            Dim KatID = DT.Rows(k).Item(0).ToString()
    '            Dim KatADI = DT.Rows(k).Item(1).ToString()
    '            Dim UstKatID = DT.Rows(k).Item(2).ToString()
    '            Dim KatPath = DT.Rows(k).Item(3).ToString()
    '            KatPath = wpdn_v10.MakeURL("tree", , KatADI, KatID, BasePath, , , KatPath)


    '            AddNode2(TreeView1.Nodes, UstKatID, KatID, KatADI, KatPath)
    '        Next

    '    End If
    'End Sub
    Public Function AddNode2(ByRef tnc As TreeNodeCollection, ByVal UstNode As String, ByVal KatID As String, ByVal KatADI As String, ByVal KatPath As String) As String
        Dim tnRec As TreeNode
        Dim strTemp As String
        Dim tnRet As TreeNode
        Dim MyRESP = ""

        For Each tnTemp As TreeNode In tnc
            If tnTemp.Value = UstNode Then
                Dim TN As New TreeNode()
                TN.Text = KatADI : TN.Value = KatID : TN.ToolTip = KatADI

                TN.NavigateUrl = KatPath
                tnTemp.ChildNodes.Add(TN)
                Exit Function
            End If
        Next
        For Each tnRec In tnc
            tnRet = LookupChildNode(tnRec, UstNode, KatID, KatADI)
            If Not tnRet Is Nothing Then
                Dim TN As New TreeNode()
                TN.Text = KatADI : TN.Value = KatID : TN.ToolTip = KatADI

                TN.NavigateUrl = KatPath
                tnRet.ChildNodes.Add(TN)
                Exit Function
            End If
        Next

        'kat ve child yoksa root'a yaz..
        Dim TN2 As New TreeNode()
        TN2.Text = KatADI : TN2.Value = KatID : TN2.ToolTip = KatADI
        TN2.NavigateUrl = KatPath
        tnc.Add(TN2)

    End Function
    Public Function LookupChildNode(ByRef tn As TreeNode, ByVal UstNode As String, ByVal KatID As String, ByVal KatADI As String) As TreeNode
        Dim tnTemp As TreeNode
        Dim tnRec As TreeNode

        For Each tnTemp In tn.ChildNodes
            If tnTemp.Value = UstNode Then
                Return tnTemp
            Else
                If (tnTemp.ChildNodes.Count > 0) Then
                    tnRec = LookupChildNode(tnTemp, UstNode, KatID, KatADI)
                    If Not tnRec Is Nothing Then
                        Return tnRec
                    End If
                End If
            End If
        Next
    End Function
    Sub WriteContent()



        '####### CATEGORIES #############
        Dim TblName = "categories"
        Dim ColName = "id,cat_name,parent_id,path"

        Dim SqlStr = MyDBData.DB_SelectSTR(TblName, ColName)

        Dim DT As System.Data.DataTable
        DT = MyDBData.QueryDataTable(SqlStr)


        Dim MySTR = "", i
        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        If KS > 0 Then
            For i = 0 To KS - 1
                Dim CatID = DT.Rows(i)("id")
                Dim CatName = DT.Rows(i).Item(1).ToString()
                Dim ParentID = DT.Rows(i).Item(2).ToString()
                Dim ParentURL = DT.Rows(i).Item(3).ToString()
                Dim CatPath = wpdn_v10.MakeURL("tree", , CatName, CatID, BasePath, , , ParentURL)


                AddNode2(TreeView1.Nodes, ParentID, CatID, CatName, CatPath)
                'AltKatYaz(CatID)
            Next
        End If


        '####### LINKS #############
        TblName = "links"
        ColName = "id,link_name,http"


        SqlStr = MydBConf.DB_SelectSTR(TblName, ColName)
        DT = MydBConf.QueryDataTable(SqlStr)

        KS = DT.Rows.Count  'Kayıt Sayısı
        If KS > 0 Then
            For i = 0 To KS - 1
                Dim link = DT.Rows(i)("http") : Dim linkname = DT.Rows(i)("link_name")
                If Replace(link, "http://", "") = link Then
                    link = "http://" & link
                End If
                LinksTxt.Text = LinksTxt.Text & "<a class='read_more' href='" & link & "' title='" & aTitle(linkname) & "' target='_blank' >" & linkname & "</a><br />"
            Next
        End If



        '####### ARCHIVE #############

        TblName = "content"
        'ColName = "distinct MONTH(content_date) as cdate"
        ColName = "distinct Format(content_date, 'yyyy MM')  AS cdate"

        SqlStr = MyDBData.DB_SelectSTR(TblName, ColName)
        DT = MyDBData.QueryDataTable(SqlStr)


        Dim MyDatez As String
        KS = DT.Rows.Count   'Kayıt Sayısı
        If KS > 0 Then
            For i = 0 To KS - 1
                Dim s As Date = DT.Rows(i)("cdate") : Dim DBDate = s.ToString("yyyy.MM.dd")
                MyDatez = MyDatez & DBDate & ","
            Next
        End If

        Dim MyDates() = MyDatez.ToString.Split(",")
        Dim Dates() As Date = Array.ConvertAll(MyDates, Function(s) If(IsDate(s.ToString), Convert.ToDateTime(s.ToString), Nothing))
        Dim DateNo = UBound(Dates)
        Array.Sort(Dates)
        Array.Reverse(Dates)

        Dim MyDateSTR
        For i = 0 To DateNo
            Dim MyDate As Date = Dates(i).ToString

            If MyDate.ToString("yyyy") <> "0001" Then
                Dim DateText = MyDate.ToString("yyyy MMM")
                Dim DateVal = MyDate.ToString("yyyy MM")
                Dim DateURL = wpdn_v10.MakeURL("date", , DateVal, , BasePath)
                Dim DateLink = fn_general_v30.MakeLink(DateText, DateURL, "read_more")

                MyDateSTR = MyDateSTR & DateLink & "<br />"

            End If
        Next
        ArchiveTxt.Text = MyDateSTR





        '####### FORM DATA #############


        SiteTitle.Text = "<a class='site_title' href='index.aspx' title='" & aTitle(Session("portal_title")) & "'>" & Session("portal_title") & "</a>"
        SiteSubTitle.Text = Session("portal_subtitle")

        Dim MyURL = ""
        If Session("lang") = "tr" Then
            MyURL = fn_general_v30.MakeImgLink("Ana Sayfa", "index.aspx", "themes/default/images/navigation/home_tr.png")
            MyURL = MyURL & fn_general_v30.MakeImgLink("Hakkımızda", "about.aspx", "themes/default/images/navigation/about_tr.png")
            MyURL = MyURL & fn_general_v30.MakeImgLink("İletişim", "contact.aspx", "themes/default/images/navigation/contact_tr.png")
            MyURL = MyURL & fn_general_v30.MakeImgLink("RSS", "rss.aspx", "themes/default/images/navigation/rss.png")
        Else
            MyURL = fn_general_v30.MakeImgLink("Home", "index.aspx", "themes/default/images/navigation/home.png")
            MyURL = MyURL & fn_general_v30.MakeImgLink("About", "about.aspx", "themes/default/images/navigation/about.png")
            MyURL = MyURL & fn_general_v30.MakeImgLink("Contact", "contact.aspx", "themes/default/images/navigation/contact.png")
            MyURL = MyURL & fn_general_v30.MakeImgLink("RSS", "rss.aspx", "themes/default/images/navigation/rss.png")
        End If

        NavTxt.Text = MyURL

        Dim MyImgUrl = ""
        CatTitle.Text = Session("lang_categories")

        Adsense2Title.Text = Session("lang_adsense2_title")
        ArchiveTitle.Text = Session("lang_archive")
        LinksTitle.Text = Session("lang_links")

        TagTitle.Text = Session("lang_tags")

        SearchTitle.Text = Session("lang_search")


        CopyrightTxt.Text = Session("text_copyright")

        Dim MyKeywords() : MyKeywords = Session("meta_keyw").ToString.Split(",")
        'FootLink.Text = "<a class=""txtlnk"" href=""http://www.google.com/search?q=" & Trim(MyKeywords(0) & "   "">Google</a>"
        FootImgLink.Text = "<a  href='" & Session("http_name") & "' title='" & aTitle(Trim(MyKeywords(0))) & "'> <img  alt='" & aTitle(Trim(MyKeywords(0))) & "'   src='themes/default/images/content/seo/kirmizi.gif'  /></a><a  href='" & Session("http_name") & "' title='" & aTitle(Trim(MyKeywords(1))) & "'><img  alt='" & aTitle(Trim(MyKeywords(1))) & "' src='themes/default/images/content/seo/sari.gif' /></a><a  href='" & Session("http_name") & "' title='" & aTitle(Trim(MyKeywords(2))) & "'><img  alt='" & aTitle(Trim(MyKeywords(2))) & "' src='themes/default/images/content/seo/yesil.gif'  /></a><a title='" & aTitle(Trim(MyKeywords(0))) & "' target='_blank' href=""http://www.google.com/search?q=" & aTitle(Trim(MyKeywords(0))) & """  ><img alt='Google' src='themes/default/images/content/seo/google.gif'  /></a>" & vbCrLf

        LogoTxt.Text = "<a href=""index.aspx"" title='" & aTitle(Session("portal_title")) & "'> <img alt='" & Session("portal_title") & "' src='" & Session("portal_logo") & "'  /></a>"



    End Sub


    Sub Session_PortalInformations()

        Dim TblName = "portal_conf"
        Dim ColName = "conf_name,	conf_value"


        Dim SqlStr = MydBConf.DB_SelectSTR(TblName, ColName)

        Dim DT As System.Data.DataTable
        DT = MyDBConf.QueryDataTable(SqlStr)

        Dim MySTR = "", i
        Dim KS = DT.Rows.Count  'Kayıt Sayısı
        If KS > 0 Then
            For i = 0 To KS - 1

                Dim conf_name = DT.Rows(i)("conf_name") : Dim conf_value = DT.Rows(i)("conf_value")

                If conf_name = "portal_title" Then Session("portal_title") = conf_value
                If conf_name = "portal_subtitle" Then Session("portal_subtitle") = conf_value
                If conf_name = "portal_logo" Then Session("portal_logo") = conf_value
                If conf_name = "lang_code" Then Session("lang_code") = conf_value
                If conf_name = "meta_title" Then Session("meta_title") = conf_value
                If conf_name = "meta_desc" Then Session("meta_desc") = conf_value
                If conf_name = "meta_keyw" Then Session("meta_keyw") = conf_value
                If conf_name = "text_copyright" Then Session("text_copyright") = conf_value
                If conf_name = "meta_desc" Then Session("meta_desc") = conf_value
                If conf_name = "text_slogan" Then Session("text_slogan") = conf_value
                If conf_name = "search_title_prefix" Then Session("search_title_prefix") = conf_value


                If conf_name = "http_name" Then
                    If Replace(conf_value, "http://", "") = conf_value Then conf_value = "http://" & conf_value
                    Session("http_name") = conf_value
                    Session("short_http_name") = Replace(conf_value, "http://", "")
                End If
            Next
        End If






    End Sub


    Sub Session_WriteLangTranslations()

        Dim lang_table


        '####### FIND LANG #############
        Dim TblName = "portal_conf"
        Dim ColName = "conf_value"
        Dim WhereSTR = "conf_name='lang'"

        Dim SqlStr = MydBConf.DB_SelectSTR(TblName, ColName, WhereSTR)
        Session("lang") = MydBConf.QueryExecuteScalar(SqlStr)
        lang_table = "translation_" & Session("lang")




        '####### WRITE TRANSLATIONS #############

        TblName = "lang_translations"
        ColName = "[default], " & lang_table & ""


        SqlStr = MydBConf.DB_SelectSTR(TblName, ColName)
        Dim DT As System.Data.DataTable
        DT = MydBConf.QueryDataTable(SqlStr)

        Dim KS = DT.Rows.Count  'Kayıt Sayısı
        If KS > 0 Then
            For i = 0 To KS - 1

                Dim defaults = DT.Rows(i)("default") : Dim translation = DT.Rows(i)(lang_table)


                'If defaults = "page" Then Session("lang_page") = translation
                'If defaults = "not_found" Then Session("lang_not_found") = translation
                'If defaults = "search" Then Session("lang_search") = translation
                'If defaults = "more" Then Session("lang_more") = translation
                'If defaults = "search_by" Then Session("lang_search_by") = translation
                'If defaults = "date" Then Session("lang_date") = translation
                'If defaults = "not_found_ads" Then Session("lang_not_found_ads") = translation
                'If defaults = "searched_words" Then Session("searched_words") = translation

                Session("lang_" & defaults) = translation
                'her bir translate'in başına lang_ koyarak sessionlarda kullanabilisin..
            Next
        End If




    End Sub


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


    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim ArananKelime = SearchTxt.Text

        If ArananKelime <> "" Then
            Response.Redirect("search.aspx?q=" & ArananKelime)
        Else
            Response.Redirect("search.aspx")
        End If
    End Sub



    Sub WriteReferrals()
        Dim MyDataFromDB As New fn_db_data


        MyDataFromDB.GetTagCloudAndWriteMasterPage(Me.Page, BasePath)


    End Sub






    'Sub WriteReferrals()
    '    Dim TblName2 = "referrals"
    '    Dim ColName2 = "top 20 [id],[searched_word],[page],[datetime]"
    '    Dim OrderBy2 = "[datetime] DESC"


    '    Dim SqlStr = MyDBData.DB_SelectSTR(TblName2, ColName2, , OrderBy2)

    '    Dim DT As System.Data.DataTable
    '    DT = MyDBData.QueryDataTable(SqlStr)

    '    Dim MySTR = "", i
    '    Dim KS = DT.Rows.Count 'Kayıt Sayısı
    '    If KS > 0 Then
    '        For i = 0 To KS - 1
    '            MySTR = MySTR & DT.Rows(i).Item(1).ToString() & ","
    '        Next
    '    End If

    '    WriteTagCloud(MySTR)

    'End Sub


    'Sub WriteTagCloud(ByVal REFS)
    '    Dim REFS2()
    '    REFS2 = Split(REFS, ",") : Dim MyREFS
    '    For i = 0 To UBound(REFS2)
    '        If REFS2(i) <> "" Then
    '            Dim MyURL = wpdn_v10.MakeURL("referrals", , REFS2(i), , BasePath)
    '            MyREFS = MyREFS & fn_general_v30.MakeLink(REFS2(i), MyURL, "topic_keywords") & ", "
    '        End If
    '    Next
    '    MyREFS = "<a class='topic_keywordstext'>Searched Words: </a>" & MyREFS

    '    'MsgBox(MyREFS)

    '    Dim MyID = Request.QueryString("id")
    '    Dim TagJS As New LiteralControl
    '    TagJS.Text = wpdn_v10.MyTagsJS("tag_xml_data.aspx?id=" & MyID & "")
    '    Me.Page.Header.Controls.Add(TagJS)

    '    TagTxt.Text = wpdn_v10.MyTagsWithSWF(MyREFS)
    'End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Trim(wpdn_v10.GoogleAnalytics) <> "" Then
            AnalyticsTxt.Text = wpdn_v10.GoogleAnalytics
        End If
    End Sub

    Sub WriteFlashBG()

        If wpdn_v10.ShowFullScreenFlashBG = "" Then Exit Sub


        Dim MyPic = fn_general_v30.RandomSec(wpdn_v10.ShowFullScreenFlashBG.ToString, 1)

        Dim LoadEffect = fn_general_v30.RandomSec("Fade,Wipe,Iris,PixelDissolve,Photo", 1)



        Dim STR As New StringBuilder
        STR.AppendLine("            <!-- flash background start -->")
        STR.AppendLine("            <div id=""bg"">")
        STR.AppendLine("                    <script type=""text/javascript"">")
        STR.AppendLine("                        var flashvars = {")
        STR.AppendLine("                            //myFile: ""a_bg_swf.swf"", //set the file URL that flash will load")
        STR.AppendLine("                            //myFileType: ""flash"", //set filetype (values: image, flash)")
        STR.AppendLine("                            myFile: ""images/background/" & MyPic & """, //set the file URL that flash will load")
        STR.AppendLine("                            myFileType: ""image"", //set filetype (values: image, flash)")
        STR.AppendLine("                            loadEffect: """ & LoadEffect & """ //set load effect - options: ""Fade"", ""Wipe"", ""Iris"", ""PixelDissolve"", ""Photo""")
        STR.AppendLine("                        };")
        STR.AppendLine("                        var params = {")
        STR.AppendLine("                            id: ""bg"",")
        STR.AppendLine("                            name: ""bg"",")
        STR.AppendLine("                            wmode: ""transparent"",")
        STR.AppendLine("                            menu: ""false""")
        STR.AppendLine("                        };")
        STR.AppendLine("                        var attributes = {")
        STR.AppendLine("                            id: ""bg"",")
        STR.AppendLine("                            name: ""bg"",")
        STR.AppendLine("                            wmode: ""transparent"",")
        STR.AppendLine("                            menu: ""false""")
        STR.AppendLine("                        };")
        STR.AppendLine("                        swfobject.embedSWF(""images/background/bg.swf"", ""bg"", ""100%"", ""100%"", ""10.0.45.2"", ""images/background/expressInstall.swf"", flashvars, params, attributes);")
        STR.AppendLine("                    </script>")
        STR.AppendLine("            </div>")
        STR.AppendLine("            <!-- flash background end -->")

        FlashBgTxt.Text = STR.ToString
    End Sub
End Class





