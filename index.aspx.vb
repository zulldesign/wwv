

Partial Class index
    Inherits System.Web.UI.Page

    Dim MyDB As New db_acc_v21_data



    Dim Lang As String
    Dim BasePath As String


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Dim MyPort = Request.ServerVariables("SERVER_PORT") : Dim MySec = Request.ServerVariables("SERVER_PORT_SECURE") : Dim MyServ = Request.ServerVariables("SERVER_NAME") : Dim MyAppPath = Request.ApplicationPath
        BasePath = fn_general_v30.PathYaz(MyPort, MySec, MyServ, MyAppPath)


        Dim CULTURE As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture(Session("lang_code"))
        System.Threading.Thread.CurrentThread.CurrentCulture = CULTURE
        System.Threading.Thread.CurrentThread.CurrentUICulture = CULTURE

    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WriteMeta()
        If Not Page.IsPostBack Then


            WriteDataFromDB()


        End If


    End Sub

    Sub WriteDataFromDB()
        FindIDsAndPaging()


    End Sub


    Sub FindIDsAndPaging()

        Dim MyDataFromDB As New fn_db_data

        If Session("IDsFromDB") = "" Then
            Dim MyANSW As New class_decl_v10.ContentIDs
            MyANSW = MyDataFromDB.GetTotalContentIDs
            Session("IDsFromDB") = MyANSW.ContentIDs
            Session("IDsFromDB_RC") = MyANSW.RecordCount
        End If


        '############### PAGING & PAGED DATA START ##################################
        'Sayfalamayı her sayfayı çağırdığında yapıyoruz bu yüzden, .net paging işe yaramıyor..
        Dim MyPage = Request.QueryString("p")


        'total content id'ler atılır ve paging'e gore ilgililer çekilir
        Dim PagingAndArticleIDz As New class_decl_v10.Paging
        PagingAndArticleIDz = MyDataFromDB.PagingAndContentIDs(MyPage, Session("IDsFromDB"), Session("lang_previous_record"), Session("lang_next_record"), Session("lang_no_record"), Session("lang_first_record"), Session("lang_page"), Session("lang_last_record"), Session("lang_not_found_ads"), BasePath)


        Dim RC As Integer = Val(Session("IDsFromDB_RC")) 'RecordCount
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



  

    Sub WriteMeta()

        Me.Title = Session("meta_title") & " | " & Session("short_http_name")
        MetaEkle("description", Session("meta_desc"))
        MetaEkle("keywords", Session("meta_keyw"))


        wpdn_v10.WriteMasterPageData("footer", Session("meta_title"), Me)
    End Sub



    Sub MetaEkle(ByVal meta_adi As String, ByVal meta_icerik As String)

        Dim yenimeta As New HtmlMeta()
        yenimeta.Name = meta_adi
        yenimeta.Content = meta_icerik
        Page.Header.Controls.Add(yenimeta)

    End Sub












End Class
