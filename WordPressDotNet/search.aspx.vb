Imports System.Data.OleDb
Partial Class search
    Inherits System.Web.UI.Page


    Dim DatabaseIsim = "databases/database.mdb"
    Dim DatabaseSifre = "extremeteam"
    Dim DBPath = Server.MapPath(DatabaseIsim)

    Dim Tagz, DefaultTitle, DefaultDesc, DefaultKeyw
    Dim TopicString


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("en-US")
    End Sub

    Sub SessionBul()
        Tagz = Trim(Request.QueryString("tag"))
        Tagz = Replace(Tagz, "-", " ")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SessionBul()


        If Not Page.IsPostBack Then
            WriteMeta()
            If Trim(Tagz) <> "" Then
                WriteResults()
            End If
        End If

    End Sub


    Sub WriteMeta()
        Dim Titlemiz, Desc, Keywords

        Dim conn As OleDbConnection
        conn = New OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA SOURCE=" + DBPath & ";Jet OLEDB:Database Password=" & DatabaseSifre & "")

        Dim comm As OleDbCommand
        comm = New OleDbCommand("Select conf_name,	conf_value from portal_conf ", conn)

        conn.Open()

        Dim dr As OleDbDataReader
        dr = comm.ExecuteReader

        'DropDownList1.Items.Add("")
        While dr.Read = True

            Dim conf_name = dr.GetValue(0).ToString : Dim conf_value = dr.GetValue(1).ToString
            If Replace(conf_name, "meta_title", "") <> conf_name Then
                DefaultTitle = conf_value
            ElseIf Replace(conf_name, "meta_desc", "") <> conf_name Then
                DefaultDesc = conf_value
            ElseIf Replace(conf_name, "meta_keyw", "") <> conf_name Then
                DefaultKeyw = conf_value

            End If


        End While
        dr.Close()
        conn.Close()


        If Trim(Tagz) = "" Then
            Me.Title = Session("lang_search") & " | " & DefaultTitle
            MetaEkle("description", Session("lang_search") & " | " & DefaultDesc)
            MetaEkle("keywords", DefaultKeyw)
        Else
            Me.Title = Tagz & " - " & DefaultTitle
            MetaEkle("description", Tagz & " - " & DefaultDesc)
            MetaEkle("keywords", Tagz & " - " & DefaultKeyw)
        End If
    End Sub

    Sub MetaEkle(ByVal meta_adi As String, ByVal meta_icerik As String)
        Dim yenimeta As New HtmlMeta()
        yenimeta.Name = meta_adi
        yenimeta.Content = meta_icerik
        Page.Header.Controls.Add(yenimeta)
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim ArananKelime = ClearText(SearchTxt.Text)
        If ArananKelime <> "" Then
            Response.Redirect("search.aspx?tag=" & ArananKelime)
        Else
            ResultsTxt.Text = ""
            SayfalamaTxt.Text = ""
            WriteMeta()
        End If
    End Sub


    Sub WriteResults()

        SearchTxt.Text = Tagz
        Dim AnahtarKelime = Tagz


        Dim MyConn, RS, SQL

        MyConn = Server.CreateObject("ADODB.Connection")
        RS = Server.CreateObject("ADODB.Recordset")
        MyConn.Open("PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA SOURCE=" + DBPath & ";Jet OLEDB:Database Password=" & DatabaseSifre & "")


        SQL = "SELECT id,	content_title,	content,	author,	content_date,	keywords from content where "
        SQL = SQL & "content_title like '%" & AnahtarKelime & "%'"
        SQL = SQL & " or content like '%" & AnahtarKelime & "%'"
        SQL = SQL & " order by content_title"

        RS.Open(SQL, MyConn, 1, 3)

        TopicStart()

        Dim SayfalamaString
        Dim KS = 5 'Sayfadaki kayıt sayısı - Number of records on a page
        Dim Sayfa = Request.QueryString("page") 'Bulunulan sayfa - Page number found

        RS.PageSize = KS 'Sayfada kaç kayıt olsun? - Number of records on a page


        If Trim(Sayfa) = "" Then Sayfa = 1
        If Sayfa > RS.PageCount Then
            SayfalamaTxt.Text = Tagz & " " & Session("lang_not_found")
            Exit Sub
        Else
            RS.AbsolutePage = Sayfa 'Bulunulan sayfa - Number of page found
        End If


        Dim TabloString, i

        Do While Not RS.EOF
            If RS.AbsolutePage <> Sayfa Then
                Exit Do
            End If

            TopicData(RS.Fields(0).Value.ToString, RS.Fields(1).Value.ToString, RS.Fields(2).Value.ToString, RS.Fields(3).Value.ToString, RS.Fields(4).Value.ToString, RS.Fields(5).Value.ToString)
            'TopicData(RS.Fields("id").ToString, RS.Fields("cat_id").ToString, RS.Fields("cat_name").ToString, RS.Fields("content_title").ToString, RS.Fields("content").ToString, RS.Fields("author").ToString, RS.Fields("content_date").ToString, RS.Fields("keywords").ToString)

            RS.MoveNext()

        Loop

        SayfalamaString = SayfalamaString & Session("lang_page") & " " & Sayfa & " / " & RS.PageCount & "<br><br>"

        Dim BackImg = "themes/default/images/navigation/back.gif"
        Dim NextImg = "themes/default/images/navigation/next.gif"
        Dim BackText = Session("lang_previous_record")
        Dim NextText = Session("lang_next_record")
        Dim NoRec = Session("lang_no_record")

        If Sayfa = 1 And Sayfa = RS.PageCount Then
            SayfalamaString = Session("lang_showing_all_results")
        ElseIf Sayfa = 1 Then
            SayfalamaString = SayfalamaString & "<a title='" & NoRec & "'><img  border='0' alt='" & NoRec & "' src='" & BackImg & "' /></a><a title='" & NextText & "' href='?page=" & Val(Sayfa) + 1 & "'><img  border='0' alt='" & NextText & "' src='" & NextImg & "' /></a>"
        ElseIf Sayfa = RS.PageCount Then
            SayfalamaString = SayfalamaString & "<a title='" & BackText & "' href='?page=" & Val(Sayfa) - 1 & "' ><img  border='0' alt='" & BackText & "' src='" & BackImg & "' /></a><a title='" & NoRec & "'><img  border='0' alt='" & NoRec & "' src='" & NextImg & "' /></a>"
        Else
            SayfalamaString = SayfalamaString & "<a title='" & BackText & "' href='?page=" & Val(Sayfa) - 1 & "' ><img  border='0' alt='" & BackText & "' src='" & BackImg & "' /></a><a title='" & NextText & "' href='?page=" & Val(Sayfa) + 1 & "'><img  border='0' alt='" & NextText & "' src='" & NextImg & "' /></a>"
        End If


        RS.Close()
        MyConn.Close()

        TopicEnd()

        ResultsTxt.Text = TopicString
        SayfalamaTxt.Text = SayfalamaString



    End Sub

    Sub TopicStart()
        TopicString = TopicString & "<table class=' topic_table'>" & vbCrLf
    End Sub


    Sub TopicData(ByVal id, ByVal content_title, ByVal content, ByVal author, ByVal content_date, ByVal keywords)
        Dim keywords2(), i

        content = Left(content, 500)

        TopicString = TopicString & "	<tr>" & vbCrLf
        TopicString = TopicString & "		<td class='table_kesik_alt_cizgi'>" & vbCrLf
        TopicString = TopicString & "		<h3 >" & vbCrLf
        TopicString = TopicString & "		    <a class='topic_title'  href='gelinlikler-4/default.htm' rel='bookmark' title='GELİNLİKLER'>" & vbCrLf
        TopicString = TopicString & "            " & content_title & "</a>" & vbCrLf
        TopicString = TopicString & "		<span style='vertical-align:middle;'>" & vbCrLf
        TopicString = TopicString & "		<img class=' topic_images' alt='Holiday Rentals' height='23'  src='images/alt/kirmizi.gif' width='27' /><img class='topic_images' alt='Holiday Apartments' height='23' src='images/alt/sari.gif' width='27' /><img class='topic_images' alt='Holiday Cottages' height='23' src='images/alt/yesil.gif' width='28' />" & vbCrLf
        TopicString = TopicString & "		</span><br /></h3>" & vbCrLf
        TopicString = TopicString & "				<p class='topic_content'>" & vbCrLf
        TopicString = TopicString & "               " & content & vbCrLf
        TopicString = TopicString & "				<a class='read_more' href='topic.aspx?id=" & id & "' >Devamını oku»</a></p>" & vbCrLf

        TopicString = TopicString & "		</td>" & vbCrLf
        TopicString = TopicString & "	</tr>" & vbCrLf

    End Sub
    Sub TopicEnd()
        TopicString = TopicString & "	</table>" & vbCrLf
    End Sub



    Function ClearText(ByVal DirtyText)
        Dim TemizIsim
        TemizIsim = LCase(DirtyText)
        TemizIsim = Replace(TemizIsim, " ", "-")
        TemizIsim = Replace(TemizIsim, ";", "")
        TemizIsim = Replace(TemizIsim, ".", "")
        TemizIsim = Replace(TemizIsim, ",", "")
        TemizIsim = Replace(TemizIsim, "'", "-")
        TemizIsim = Replace(TemizIsim, "(", "")
        TemizIsim = Replace(TemizIsim, ")", "")

        TemizIsim = Replace(TemizIsim, "ã", "a")
        TemizIsim = Replace(TemizIsim, "ä", "a")
        TemizIsim = Replace(TemizIsim, "ç", "c")
        TemizIsim = Replace(TemizIsim, "é", "e")
        TemizIsim = Replace(TemizIsim, "ğ", "g")

        TemizIsim = Replace(TemizIsim, "ı", "i")
        TemizIsim = Replace(TemizIsim, "í", "i")
        TemizIsim = Replace(TemizIsim, "ñ", "n")
        TemizIsim = Replace(TemizIsim, "ş", "s")
        TemizIsim = Replace(TemizIsim, "ö", "o")

        TemizIsim = Replace(TemizIsim, "ü", "u")


        Return TemizIsim
    End Function



End Class

