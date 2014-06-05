
Imports wpdn_v10

Partial Class wpdn_topic
    Inherits System.Web.UI.Page

    Dim MyDB As New db_acc_v21_data
    Dim MyDataFromDB As New fn_db_data

    Dim BasePath



    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Dim MyPort = Request.ServerVariables("SERVER_PORT") : Dim MySec = Request.ServerVariables("SERVER_PORT_SECURE") : Dim MyServ = Request.ServerVariables("SERVER_NAME") : Dim MyAppPath = Request.ApplicationPath
        BasePath = fn_general_v30.PathYaz(MyPort, MySec, MyServ, MyAppPath)


        Dim CULTURE As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture(Session("lang_code"))
        System.Threading.Thread.CurrentThread.CurrentCulture = CULTURE
        System.Threading.Thread.CurrentThread.CurrentUICulture = CULTURE

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'MsgBox(Request.Url.ToString)

        If Not Page.IsPostBack Then
            ' MsgBox(Request.QueryString("id"))
            Dim MyID = Request.QueryString("id")
            If Trim(MyID) <> "" And IsNumeric(Trim(MyID)) Then

                WriteTopic()

            ElseIf Trim(MyID) <> "" Then
                'son arama sonuçlarında önceki (silinmesi gereken) sonuçlar gelmekte bunları search a yönlendir.
                Dim Referans = MyID
                Dim MyQuery = GetAdsenseCodeAFSQuery(fn_general_v30.ForSearch(Referans), "http:%2F%2F" & MySite & "%2Fsearch.aspx")
                Response.Redirect(BasePath & "search.aspx?" & MyQuery)
            Else

                If Not String.IsNullOrEmpty(Request.ServerVariables("HTTP_REFERER")) Then
                    Dim Referans = Request.ServerVariables("HTTP_REFERER")
                    Referans = Left(fn_general_v30.ClearLink(Referans, "q=", "&"), 100)
                    Dim MyQuery = GetAdsenseCodeAFSQuery(fn_general_v30.ForSearch(Referans), "http:%2F%2F" & MySite & "%2Fsearch.aspx")
                    Response.Redirect(BasePath & "search.aspx?" & MyQuery)
                End If


            End If

        End If

    End Sub


    Sub WriteTopic()
        Dim MyDataFromDB As New fn_db_data



        Dim TopicID = Request.QueryString("id")

        Dim TagID = Request.QueryString("tag_id"), MyTag As String
        If TagID <> "" Then
            MyTag = MyDataFromDB.FindTag(TagID)
        End If

        Dim MySearchedID = Request.QueryString("searched_id") : Dim MySearchedWord = ""
        If MySearchedID <> "" Then
            MySearchedWord = MyDataFromDB.GetSearchedWord(MySearchedID)
        End If

        Dim MyRESP As New class_decl_v10.TopicPage
        MyRESP = MyDataFromDB.GetContentInfos_SingleREC_Long(TopicID, Session("lang_tags"), Session("lang_categories"), Session("short_http_name"), Session("lang_more"), Session("lang_author"), BasePath, MyTag, MySearchedWord)


        If MyRESP.RecordCount > 0 Then

            TopicTxt.Text = MyRESP.TopicSTR



            If Not String.IsNullOrEmpty(Request.ServerVariables("HTTP_REFERER")) Then
                Dim REFF = Request.ServerVariables("HTTP_REFERER").ToString
                MyDataFromDB.ReferralKaydet(REFF, TopicID)
            End If






            Dim MyCatz As New class_decl_v10.ParentCatNamez
            MyCatz = MyDataFromDB.FindBreadCrumb(MyRESP.ContentCatID, BasePath, "topic_keywords")

            Dim CatForUrl = MyCatz.cat_parent_url & MyCatz.cat_name
            Dim TopicURL = MakeURL("topic", CatForUrl, MyRESP.ContentTitle, TopicID, BasePath)


            Dim TopicImg = BasePath & "videos/intro-" & TopicID & ".gif"
            TopicImg = MyRESP.ImageInTopic
            If wpdn_v10.ExternalImages = "yes" Then TopicImg = BasePath & "content/images/" & TopicID & ".jpg"

            ReviewYaz(MyRESP.ContentTitle, TopicImg, fn_general_v30.RandomNumber2(9, 7), fn_general_v30.RandomNumber2(8, 2), fn_general_v30.RandomNumber2(4, 0), TopicURL)
            CommentYaz(TopicURL)

            If wpdn_v10.ShowDummyVideo <> "no" Then WriteVideo(TopicID)

            Dim SearchedWords As New class_decl_v10.Referalz
            SearchedWords = MyDataFromDB.GetTagCloudAndWriteMasterPage(Me, BasePath, TopicID, TopicURL) 'SearchedTags..  


            '########## META & Title vs.. ###########
            Dim DbTitle, DbDesc, DbKeyw
            'DbTitle = MyRESP.ContentTitle : DbDesc = Left(fn_general_v30.HTMLtoTEXT(MyRESP.ContentDesc), 200).ToString : DbKeyw = MyRESP.KeywWithoutLink
            DbTitle = MyRESP.ContentTitle : DbDesc = Left(fn_general_v30.HTMLtoTEXT(MyRESP.KeywWithoutLink), 200).ToString : DbKeyw = MyRESP.KeywWithoutLink

            If TagID <> "" Then DbTitle = MyTag & " - " & DbTitle : DbDesc = MyTag & " - " & Left(fn_general_v30.HTMLtoTEXT(DbDesc), 200) : DbKeyw = MyTag & " - " & DbKeyw
            If MySearchedWord <> "" Then DbTitle = MySearchedWord & " - " & DbTitle : DbDesc = MySearchedWord & " - " & Left(fn_general_v30.HTMLtoTEXT(DbDesc), 200) : DbKeyw = MySearchedWord & " - " & DbKeyw

            WriteTopicMeta(DbTitle, DbDesc, DbKeyw)
            '########## META & Title vs.. ###########

            'MsgBox(SearchedWords.WorldsWithoutComma)
            RefzTxt.Text = fn_general_v30.Text_Thin(SearchedWords.WorldsWithoutComma, "thinner")

        Else
            Response.Redirect("search.aspx")
        End If







    End Sub









    Sub WriteTopicMeta(ByVal DbTitle, ByVal DbDesc, ByVal DbKeyw)



        Dim HttpName = Session("http_name")

        DbTitle = DbTitle & " | " & Replace(HttpName, "http://", "")
        DbDesc = DbDesc & " |  " & Replace(HttpName, "http://", "")
        DbKeyw = DbKeyw & " |  " & Replace(HttpName, "http://", "")


        DbTitle = fn_general_v30.HTMLtoTEXT(DbTitle)
        Me.Title = DbTitle

        MetaEkle("description", DbDesc)
        MetaEkle("keywords", DbKeyw)




        wpdn_v10.WriteMasterPageData("footer", DbTitle, Me)



    End Sub



    Sub MetaEkle(ByVal meta_adi As String, ByVal meta_icerik As String)

        Dim yenimeta As New HtmlMeta()
        yenimeta.Name = meta_adi
        yenimeta.Content = meta_icerik
        Page.Header.Controls.Add(yenimeta)

    End Sub







    Sub WriteVideo(ByVal MyID)

        Dim MyPath = BasePath & "videos/intro-" & MyID & ".flv"

        Dim MyTxt
        MyTxt = MyTxt & "		<a  " & vbCrLf
        MyTxt = MyTxt & "			 href='" & MyPath & "'" & vbCrLf
        MyTxt = MyTxt & "			 style=""display:block;width:520px;height:330px""  " & vbCrLf
        MyTxt = MyTxt & "			 id=""player""> " & vbCrLf
        MyTxt = MyTxt & "		</a> " & vbCrLf
        MyTxt = MyTxt & "	" & vbCrLf
        MyTxt = MyTxt & "		<!-- this will install flowplayer inside previous A- tag. -->" & vbCrLf
        MyTxt = MyTxt & "		<script type=""text/javascript"">" & vbCrLf
        MyTxt = MyTxt & "			flowplayer(""player"", ""scripts/flowplayer/flowplayer-3.2.7.swf"");" & vbCrLf
        MyTxt = MyTxt & "		</script>" & vbCrLf
        MyTxt = MyTxt & "" & vbCrLf

        VideoTxt.Text = MyTxt

    End Sub

    Sub ReviewYaz(ByVal isim, ByVal resim, ByVal ortalama, ByVal toplam_oy, ByVal inceleme_sayisi, ByVal TopicURL)
        inceleme_sayisi = "<fb:comments-count href=" & TopicURL & " /></fb:comments-count>"

        Dim STR As New StringBuilder
        STR.AppendLine("  <div itemscope itemtype=""http://data-vocabulary.org/Review-aggregate"">")
        STR.AppendLine("    <span itemprop=""itemreviewed"">" & isim & "</span>")
        STR.AppendLine("    <img alt=""" & fn_general_v30.aTitle(isim) & """ itemprop=""photo"" src=""" & resim & """ style='width:50px;height:50px;' />")
        STR.AppendLine("    <span itemprop=""rating"" itemscope itemtype=""http://data-vocabulary.org/Rating"">")
        STR.AppendLine("      <span itemprop=""average"">" & ortalama & "</span>")
        STR.AppendLine("      out of <span itemprop=""best"">10</span>")
        STR.AppendLine("    </span>")
        STR.AppendLine("    based on <span itemprop=""votes"">" & toplam_oy & "</span> ratings.")
        STR.AppendLine("    <span itemprop=""count"">" & inceleme_sayisi & "</span> user reviews.")
        STR.AppendLine("  </div>    ")
        ReviewTxt.Text = STR.ToString : STR.Length = 0
    End Sub
    Sub CommentYaz(ByVal TopicURL)

        Dim STR As New StringBuilder
        STR.AppendLine("<div id=""fb-root""></div><script src=""http://connect.facebook.net/en_US/all.js#xfbml=1""></script><fb:comments href=""" & TopicURL & """ num_posts=""5"" width=""500""></fb:comments>")
        SocialTxt.Text = STR.ToString
    End Sub


End Class
