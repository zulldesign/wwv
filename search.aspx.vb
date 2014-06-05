

Imports System.Data

Partial Class search
    Inherits System.Web.UI.Page

    Dim MyDB As New db_acc_v21_data

    Dim KacinciKayit, RecordsSTR

    Dim BasePath
    Dim SecondChance 'For search



    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Dim MyPort = Request.ServerVariables("SERVER_PORT") : Dim MySec = Request.ServerVariables("SERVER_PORT_SECURE") : Dim MyServ = Request.ServerVariables("SERVER_NAME") : Dim MyAppPath = Request.ApplicationPath
        BasePath = fn_general_v30.PathYaz(MyPort, MySec, MyServ, MyAppPath)


        Dim CULTURE As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture(Session("lang_code"))
        System.Threading.Thread.CurrentThread.CurrentCulture = CULTURE
        System.Threading.Thread.CurrentThread.CurrentUICulture = CULTURE

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Page.IsPostBack Then
            TopicTxt.Text = wpdn_v10.GetAdsenseCodeAFS()


            FindCriteriaAndSearch()


        End If



    End Sub


    Sub FindCriteriaAndSearch()
        Dim CatID, MyDate

        CatID = Request.QueryString("cat_id")


        If CatID <> "" And IsNumeric(CatID) Then
            FindCatAndWriteMeta(CatID)
            WriteResults("ByCat", CatID)

        ElseIf Request.QueryString("date") <> "" Then
            WriteResults("ByDate", Request.QueryString("date"))



        Else

            Dim MyTag
            If Request.QueryString("tag") <> "" Then MyTag = Request.QueryString("tag")
            If Request.QueryString("q") <> "" Then MyTag = Request.QueryString("q")

            If Request.QueryString("searched_id") <> "" Then
                Dim MyDataFromDB As New fn_db_data
                Dim WordID = Request.QueryString("searched_id")
                MyTag = MyDataFromDB.GetSearchedWord(WordID) : MyTag = HttpUtility.UrlDecode(MyTag)
            End If


            If Request.QueryString("cx") = "" Then 'adsense url'sinde miyiz, yoksa sadece q= mi?
                Dim MyQuery = wpdn_v10.GetAdsenseCodeAFSQuery(fn_general_v30.ForSearch(MyTag), "http:%2F%2F" & wpdn_v10.MySite & "%2Fsearch.aspx")
                Response.Redirect(BasePath & "search.aspx?" & MyQuery)

            Else

                SearchTxt.Text = fn_general_v30.ForSearch(MyTag)
                WriteMeta("BySearch", MyTag)
            End If



        End If



    End Sub




    Sub WriteResults(ByVal MySearch, ByVal MyVal)

        Dim WhereSTR As String = ""

        If MySearch = "ByCat" Then
            Dim MyDataFromDB As New fn_db_data
            Dim MySubCatz As New class_decl_v10.SubCatNamez

            MySubCatz = MyDataFromDB.GetCatFORW(MyVal)
            Dim MySubCatIDz = MySubCatz.SubCatIDz

            WhereSTR = WhereSTR & " content.category_id IN (" & MySubCatIDz & ")"

        ElseIf MySearch = "ByDate" Then
            Dim BasTarih, SonTarih
            Dim MyDate = MyVal
            MyDate = Left(MyDate, 4) & "-" & Right(MyDate, 2) & "-01"
            Dim s As Date = MyDate
            BasTarih = fn_general_v30.TarihForDB(MyDate)
            SonTarih = fn_general_v30.TarihForDB(s.AddMonths(1))

            WhereSTR = WhereSTR & " content.content_date >= " & BasTarih & " AND content.content_date < " & SonTarih & ""

            MyVal = s.ToString("yyyy MMM")
            WriteMeta("ByDate", MyVal)

        End If




        FindIDsAndPaging(WhereSTR)


    End Sub

    Sub FindIDsAndPaging(ByVal WhereSTR)

        Dim MyDataFromDB As New fn_db_data


        Dim MyANSW As New class_decl_v10.ContentIDs
        MyANSW = MyDataFromDB.GetTotalContentIDsSearched(WhereSTR)


        '############### PAGING & PAGED DATA START ##################################
        'Sayfalamayı her sayfayı çağırdığında yapıyoruz bu yüzden, .net paging işe yaramıyor..

        Dim RC As Integer = Val(MyANSW.RecordCount) 'RecordCount

        Dim MyPage = Request.QueryString("p")
        Dim PagingAndArticleIDz As New class_decl_v10.Paging
        PagingAndArticleIDz = MyDataFromDB.PagingAndContentIDs(MyPage, MyANSW.ContentIDs, Session("lang_previous_record"), Session("lang_next_record"), Session("lang_no_record"), Session("lang_first_record"), Session("lang_page"), Session("lang_last_record"), Session("lang_not_found_ads"), BasePath)

        If RC <> 0 Then
            WriteArticles(PagingAndArticleIDz.ArticleIDs) 'kayıtlar ComputeSum ile RecordsSTR 'e yazılır.. *10 kayıt gönderilir.
            PagingTxt.Text = PagingAndArticleIDz.PagingSTR
        Else
            PagingTxt.Text = PagingAndArticleIDz.PagingSTR
        End If
        '############### PAGING & PAGED DATA END ##################################

    End Sub
    Sub WriteArticles(ByVal IDs) 'gönderilen 10 kaydı yazar..
        Dim MyRESP As String

        Dim MyDataFromDB As New fn_db_data
        MyRESP = MyDataFromDB.GetContentInfos_Total_Short(IDs, Session("lang_tags"), Session("lang_categories"), Session("short_http_name"), Session("lang_more"), Session("lang_author"), BasePath)

        TopicTxt.Text = MyRESP
    End Sub

    'Sub WriteResults3(Optional ByVal MySearch = "", Optional ByVal MyVal = "")
    '    MyVal = Trim(MyVal)
    '    If MyVal = "" Then Exit Sub

    '    Dim SearchWords()
    '    Dim MyVal2 = Replace(MyVal, "-", " ")
    '    SearchWords = MyVal2.ToString.Split(" ")
    '    'MsgBox(MyVal2 & "|" & SearchWords(0).ToString)

    '    Dim TblName = "content"
    '    Dim ColName = "top 50 content.id,content.content_title,content.content_intro,content.author,content.content_date,content.keywords,content.categories,content.keywords_url,content.content"
    '    'im ColName = "TOP 2  0ontent.id,1ontent.content_title,2ontent.content_intro,3ontent.author,4ontent.content_date,5ontent.keywords,6ategories.cat_name"
    '    Dim WhereSTR = ""


    '    If MySearch = "ByCat" Then
    '        Dim MyCat = MyVal
    '        WhereSTR = WhereSTR & " content.categories='" & MyCat & "'"
    '        'WhereSTR = WhereSTR & " content.categories like '%" & MyCat & "%'"

    '    ElseIf MySearch = "ByDate" Then
    '        Dim BasTarih, SonTarih
    '        Dim MyDate = MyVal
    '        MyDate = Left(MyDate, 4) & "-" & Right(MyDate, 3) & "-01"
    '        Dim s As Date = MyDate
    '        BasTarih = fn_general_v30.TarihForDB(MyDate)
    '        SonTarih = fn_general_v30.TarihForDB(s.AddMonths(1))

    '        WhereSTR = WhereSTR & " content.content_date >= " & BasTarih & " AND content.content_date < " & SonTarih & ""
    '    ElseIf MySearch = "BySearch" Then
    '        Dim MyTag = MyVal
    '        WhereSTR = WhereSTR & " "
    '        WhereSTR = WhereSTR & " content.content_title like '%" & MyTag & "%'"
    '        WhereSTR = WhereSTR & " or content.content like '%" & MyTag & "%'"
    '        WhereSTR = WhereSTR & " or content.keywords like '%" & MyTag & "%'"

    '        'WhereSTR = WhereSTR & "content.keywords_url like '%" & MyVal & "%'"
    '        WhereSTR = WhereSTR & " "
    '    Else

    '        Dim MyTag = MyVal : MyTag = Replace(MyTag, "-", " ")
    '        WhereSTR = WhereSTR & " "
    '        WhereSTR = WhereSTR & " content.content_title like '%" & MyTag & "%'"
    '        WhereSTR = WhereSTR & " or content.content like '%" & MyTag & "%'"
    '        WhereSTR = WhereSTR & " or content.keywords like '%" & MyTag & "%'"
    '        WhereSTR = WhereSTR & " or content.keywords_url like '%" & MyVal & "%'"
    '        'WhereSTR = WhereSTR & "content.keywords_url like '%" & MyVal & "%'"
    '        WhereSTR = WhereSTR & " "
    '    End If

    '    Dim OrderBy = "content_date DESC"


    '    Dim SqlStr = MyDB.DB_SelectSTR(TblName, ColName, WhereSTR, OrderBy)

    '    'MsgBox(SqlStr)



    '    Dim DT As System.Data.DataTable
    '    DT = MyDB.QueryDataTable(SqlStr)

    '    Dim KS = DT.Rows.Count 'Kayıt Sayısı

    '    If KS > 0 Then
    '        ListView1.DataSource = DT.DefaultView
    '        ListView1.DataBind()



    '        RecordsSTR = wpdn_v10.TopicStart() & RecordsSTR & wpdn_v10.TopicEnd()
    '        TopicTxt.Text = RecordsSTR
    '    Else
    '        'MsgBox("were here")
    '        If UBound(SearchWords) > 1 Then '2 Tane Word varsa
    '            Dim MW = Trim(SearchWords(0).ToString)
    '            'FindCriteriaAndSearch(MW)
    '        Else
    '            Dim MySTR = "No Result(s) Found. You may interested in Ads below. <br /><br />"
    '            MySTR = MySTR & wpdn_v10.AdsenseInTopic()
    '            GoogleSearchTxt.Text = MySTR
    '        End If
    '    End If



    'End Sub



    'Sub WriteArticle3(ByVal IDs)

    '    Dim TblName = "content,categories"
    '    Dim ColName = "content.id,content.content_title,content.content_intro,content.author,content.content_date,categories.cat_name,content.content,content.category_id"
    '    'im ColName = "0ontent.id,1ontent.content_title,2ontent.content_intro,3ontent.author,4ontent.content_date,5ontent.categories,6ontent.content"
    '    'Dim WhereSTR = "id BETWEEN " & FA & " AND " & LA & ""
    '    Dim WhereSTR = "content.id IN (" & IDs & ") AND categories.id=content.category_id"
    '    Dim OrderBy = "content.id DESC"

    '    Dim SqlStr = MyDB.DB_SelectSTR(TblName, ColName, WhereSTR, OrderBy)

    '    Dim DT As System.Data.DataTable
    '    DT = MyDB.QueryDataTable(SqlStr)
    '    ListView1.DataSource = DT.DefaultView
    '    ListView1.DataBind()


    '    RecordsSTR = wpdn_v10.TopicStart() & RecordsSTR & wpdn_v10.TopicEnd()

    '    TopicTxt.Text = RecordsSTR

    'End Sub

    ''Sub WriteArticles(ByVal IDs)

    ''    Dim TblName = "content,categories"
    ''    Dim ColName = "content.id,content.content_title,content.content_intro,content.author,content.content_date,content.keywords,content.categories,content.keywords_url,content.content"
    ''    'im ColName = "0ontent.id,1ontent.content_title,2ontent.content_intro,3ontent.author,4ontent.content_date,5ontent.keywords,content.6ategories,7ontent.keywords_url,8ontent.content"
    ''    'Dim WhereSTR = "id BETWEEN " & FA & " AND " & LA & ""
    ''    Dim WhereSTR = "id IN (" & IDs & ")"

    ''    Dim SqlStr = MyDB.DB_SelectSTR(TblName, ColName, WhereSTR)

    ''    Dim DT As System.Data.DataTable
    ''    DT = MyDB.QueryDataTable(SqlStr)
    ''    ListView1.DataSource = DT.DefaultView
    ''    ListView1.DataBind()

    ''    'Data Bind edilirken RecordsSTR yazılıyor, sonrasında aşağıdaki gibi birleştiriyoruz..
    ''    RecordsSTR = wpdn_v10.TopicStart() & RecordsSTR & wpdn_v10.TopicEnd()

    ''    TopicTxt.Text = RecordsSTR

    ''End Sub







    'Public Sub PagePropertiesChanging(ByVal sender As Object, ByVal e As PagePropertiesChangingEventArgs)
    '    RecordsSTR = ""


    '    ListView1.DataBind()
    'End Sub


    'Public Sub ComputeSum(ByVal sender As Object, ByVal e As ListViewItemEventArgs)
    '    If e.Item.ItemType = ListViewItemType.DataItem Then
    '        KacinciKayit = KacinciKayit + 1
    '        Dim dataItem As ListViewDataItem = CType(e.Item, ListViewDataItem)
    '        Dim rowView As System.Data.DataRowView = CType(dataItem.DataItem, System.Data.DataRowView)

    '        Dim MyDataNo As Integer = 7

    '        Dim R(MyDataNo), i
    '        For i = 0 To MyDataNo
    '            R(i) = rowView(i).ToString()
    '            R(i) = fn_general_v30.DB_ReturnText(R(i).ToString)
    '            If R(i) = "" Then R(i) = " "
    '        Next

    '        If Trim(R(2).ToString) = "" Then 'r(6) = content
    '            R(2) = fn_general_v30.HtmlCut(R(6), wpdn_v10.IntroLen)
    '            If R(2) = "" Then R(2) = " "
    '        End If

    '        If KacinciKayit = 1 Then
    '            RecordsSTR = RecordsSTR & wpdn_v10.TopicData(R(0).ToString, R(1).ToString, R(2).ToString, R(3).ToString, R(4).ToString, "", R(5).ToString, R(5).ToString, BasePath, Session("lang_tags"), Session("lang_categories"), Session("short_http_name"), Session("lang_more"), "yes", , "yes", , , , , , , , , , Session("short_http_name"), R(7).ToString)
    '        Else
    '            RecordsSTR = RecordsSTR & wpdn_v10.TopicData(R(0).ToString, R(1).ToString, R(2).ToString, R(3).ToString, R(4).ToString, "", R(5).ToString, R(5).ToString, BasePath, Session("lang_tags"), Session("lang_categories"), Session("short_http_name"), Session("lang_more"), , , "yes", , , , , , , , , , Session("short_http_name"), R(7).ToString)
    '        End If



    '    End If
    'End Sub




    Sub FindCatAndWriteMeta(ByVal CatID)
        Dim MyRESP As New class_decl_v10.ParentCatNamez

        Dim MyDataFromDB As New fn_db_data
        MyRESP = MyDataFromDB.FindBreadCrumb(CatID, BasePath)

        Dim DBTitle = MyRESP.CatWithoutLink
        Dim DBDesc = MyRESP.cat_desc
        Dim DBKeyw = MyRESP.cat_keyw

        WriteMeta("ByCat", , DBTitle, DBDesc, DBKeyw)

    End Sub

    Sub WriteMeta(Optional ByVal MyCat = "", Optional ByVal MyVal = "", Optional ByVal DBTitle = "", Optional ByVal DBDesc = "", Optional ByVal DBKeyw = "")
        Dim PreTitle = "", PreDesc = "", PreKeyw = "", PreMaster 'pre:prepared

        Dim DefaultTitle = Session("meta_title")
        Dim DefaultDesc = Session("meta_desc")
        Dim DefaultKeyw = Session("meta_keyw")
        Dim ShortHTTP = Session("short_http_name")


        If MyCat = "ByCat" Then
            PreTitle = Session("search_title_prefix") & " " & Session("lang_search_by") & " " & Session("lang_category") & ": " & DBTitle & " | " & ShortHTTP
            PreDesc = Session("search_title_prefix") & " " & Session("lang_search_by") & " " & Session("lang_category") & ": " & DBTitle & " | " & DBDesc
            PreKeyw = PreTitle & ", " & DBKeyw
            PreMaster = Session("search_title_prefix") & " " & Session("lang_search_by") & " " & Session("lang_category") & ": " & DBTitle

        ElseIf MyCat = "ByDate" Then
            PreTitle = Session("search_title_prefix") & " " & Session("lang_search_by") & " " & Session("lang_date") & ": " & StrConv(Replace(MyVal, "-", " "), vbProperCase) & " | " & ShortHTTP
            PreDesc = PreTitle
            PreKeyw = PreTitle
            PreMaster = Session("search_title_prefix") & " " & Session("lang_search_by") & " " & Session("lang_date") & ": " & StrConv(Replace(MyVal, "-", " "), vbProperCase)

        ElseIf MyCat = "BySearch" Then
            PreTitle = Session("search_title_prefix") & " " & Session("searched_words") & ": " & StrConv(Replace(MyVal, "-", " "), vbProperCase) & " | " & ShortHTTP
            PreDesc = PreTitle & " | " & DefaultDesc
            PreKeyw = PreTitle & "," & DefaultKeyw
            PreMaster = Session("search_title_prefix") & " " & Session("searched_words") & ": " & StrConv(Replace(MyVal, "-", " "), vbProperCase)
        Else
            PreTitle = Session("lang_search") & " | " & DefaultTitle & " | " & ShortHTTP
            PreDesc = Session("lang_search") & " | " & DefaultDesc
            PreKeyw = Session("lang_search") & " , " & DefaultKeyw
            PreMaster = PreTitle



        End If



        Me.Title = PreTitle
        MetaEkle("description", PreDesc)
        MetaEkle("keywords", PreKeyw)

        WriteMasterFooter(PreMaster)

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
    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim ArananKelime = SearchTxt.Text

        If ArananKelime <> "" Then
            Dim MyQuery = wpdn_v10.GetAdsenseCodeAFSQuery(ArananKelime, "http:%2F%2Fholidaychoices.net%2Fsearch.aspx")
            Response.Redirect("search.aspx?" & MyQuery)
        Else
            TopicTxt.Text = ""
            Response.Redirect("search.aspx")
        End If
    End Sub


End Class

