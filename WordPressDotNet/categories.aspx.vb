Imports System.Data.OleDb

Partial Class wpdn_categories
    Inherits System.Web.UI.Page




    Dim DatabaseIsim = "databases/database.mdb"
    Dim DatabaseSifre = "extremeteam"
    Dim DBPath = Server.MapPath(DatabaseIsim)

    Dim Categoriez, MyTitle, MyDesc, MyKeyw
    Dim TopicString


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("en-US")
    End Sub

    Sub SessionBul()
        Categoriez = Trim(Request.QueryString("category"))
        'Categoriez = Replace(Categoriez, "-", " ")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SessionBul()


        If Not Page.IsPostBack Then
            WriteMeta()
            If Trim(Categoriez) <> "" Then
                WriteResults()
            End If
        End If

    End Sub


    Sub WriteMeta()
        Dim Titlemiz, Desc, Keywords

        Dim CatName = Session("dirty_" & Categoriez)

        Dim conn As OleDbConnection
        conn = New OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA SOURCE=" + DBPath & ";Jet OLEDB:Database Password=" & DatabaseSifre & "")

        Dim comm As OleDbCommand
        comm = New OleDbCommand("Select cat_name, cat_desc, cat_keyw from categories where cat_name  like '%" & CatName & "%' ", conn)

        conn.Open()

        Dim dr As OleDbDataReader
        dr = comm.ExecuteReader

        'DropDownList1.Items.Add("")
        While dr.Read = True
            MyTitle = Session("lang_category") & ": " & dr.GetValue(0).ToString & " | " & Replace(Session("http_name"), "http://", "")
            MyDesc = dr.GetValue(1).ToString & " | " & Replace(Session("http_name"), "http://", "")
            MyKeyw = dr.GetValue(2).ToString & ", " & Replace(Session("http_name"), "http://", "")
        End While
        dr.Close()
        conn.Close()


        Me.Title = MyTitle
        MetaEkle("description", MyDesc)
        MetaEkle("keywords", MyKeyw)

    End Sub

    Sub MetaEkle(ByVal meta_adi As String, ByVal meta_icerik As String)
        Dim yenimeta As New HtmlMeta()
        yenimeta.Name = meta_adi
        yenimeta.Content = meta_icerik
        Page.Header.Controls.Add(yenimeta)
    End Sub

    'Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
    '    Dim ArananKelime = ClearText(SearchTxt.Text)
    '    If ArananKelime <> "" Then
    '        Response.Redirect("search.aspx?tag=" & ArananKelime)
    '    Else
    '        ResultsTxt.Text = ""
    '        SayfalamaTxt.Text = ""
    '        WriteMeta()
    '    End If
    'End Sub


    Sub WriteResults()

        'SearchTxt.Text = Categoriez
        Dim AnahtarKelime = Session("dirty_" & Categoriez)



        Dim MyConn, RS, SQL

        MyConn = Server.CreateObject("ADODB.Connection")
        RS = Server.CreateObject("ADODB.Recordset")
        MyConn.Open("PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA SOURCE=" + DBPath & ";Jet OLEDB:Database Password=" & DatabaseSifre & "")


        SQL = "SELECT id,	content_title,	content,	author,	content_date,	keywords,categories from content where "
        SQL = SQL & " categories like '%" & AnahtarKelime & "%'"
        'SQL = SQL & " or content like '%" & AnahtarKelime & "%'"
        SQL = SQL & " order by content_date DESC"

        RS.Open(SQL, MyConn, 1, 3)

        TopicStart()

        Dim SayfalamaString
        Dim KS = 5 'Sayfadaki kayıt sayısı - Number of records on a page
        Dim Sayfa = Request.QueryString("page") 'Bulunulan sayfa - Page number found

        RS.PageSize = KS 'Sayfada kaç kayıt olsun? - Number of records on a page


        If Trim(Sayfa) = "" Then Sayfa = 1
        If Sayfa > RS.PageCount Then
            SayfalamaTxt.Text = Categoriez & " " & Session("lang_not_found")
            Exit Sub
        Else
            RS.AbsolutePage = Sayfa 'Bulunulan sayfa - Number of page found
        End If


        Dim TabloString, i

        Do While Not RS.EOF
            If RS.AbsolutePage <> Sayfa Then
                Exit Do
            End If

            TopicData(RS.Fields(0).Value.ToString, RS.Fields(1).Value.ToString, RS.Fields(2).Value.ToString, RS.Fields(3).Value.ToString, RS.Fields(4).Value.ToString, RS.Fields(5).Value.ToString, RS.Fields(6).Value.ToString)
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


    Sub TopicData(ByVal id, ByVal content_title, ByVal content, ByVal author, ByVal content_date, ByVal keywords, ByVal categories)
        Dim keywords2(), i
        Dim emphasis(3)


        keywords2 = Split(keywords, ",")
        keywords = ""
        For i = 0 To UBound(keywords2)
            If keywords2(i) <> "" Then
                keywords2(i) = Trim(keywords2(i))
                keywords = keywords & "<a class='topic_keywords' rel='tag' title='" & keywords2(i) & "' href='search.aspx?tag=" & ClearText(keywords2(i)) & "'>" & keywords2(i) & "</a>, "
                If i = 0 Or i = 1 Or i = 2 Then
                    emphasis(i + 1) = keywords2(i)
                End If
            End If
        Next
        If Trim(keywords) <> "" Then
            keywords = "<a class='topic_keywordstext'>" & Session("lang_tags") & ": </a>" & keywords
        End If



        Dim categories2()
        categories2 = Split(categories, ",")
        categories = ""
        For i = 0 To UBound(categories2)
            If categories2(i) <> "" Then
                categories2(i) = Trim(categories2(i))
                categories = categories & "<a class='topic_keywords' rel='categories' title='" & categories2(i) & "' href='categories.aspx?category=" & ClearText(categories2(i)) & "'>" & categories2(i) & "</a>, "
            End If
        Next
        If Trim(categories) <> "" Then
            categories = "<a class='topic_keywordstext'>" & Session("lang_categories") & ": </a>" & categories
        End If
        content = Left(content, 500)

        TopicString = TopicString & "	<tr>" & vbCrLf
        TopicString = TopicString & "		<td class='table_kesik_alt_cizgi'>" & vbCrLf
        TopicString = TopicString & "		<h3 >" & vbCrLf
        TopicString = TopicString & "		    <a class='topic_title'  rel='bookmark'  href='topic.aspx?id=" & id & "' title='" & content_title & "'>" & vbCrLf
        TopicString = TopicString & "            " & content_title & "</a>" & vbCrLf
        TopicString = TopicString & "		<a  href='search.aspx?tag=" & emphasis(1) & "' title='" & emphasis(1) & "'> <img class='topic_images' alt='" & emphasis(1) & "'   src='images/alt/kirmizi.gif'  /></a><a  href='search.aspx?tag=" & emphasis(2) & "' title='" & emphasis(2) & "'><img class='topic_images' alt='" & emphasis(2) & "' src='images/alt/sari.gif' /></a><a  href='search.aspx?tag=" & emphasis(3) & "' title='" & emphasis(3) & "'><img class='topic_images' alt='" & emphasis(3) & "' src='images/alt/yesil.gif'  /></a>" & vbCrLf
        TopicString = TopicString & "		<br />"
        TopicString = TopicString & "		</h3>" & vbCrLf
        TopicString = TopicString & "		" & categories & "" & vbCrLf
        TopicString = TopicString & "				<p class='topic_content'>" & vbCrLf
        TopicString = TopicString & "               " & content & vbCrLf
        TopicString = TopicString & "				<a class='read_more' href='topic.aspx?id=" & id & "' >Devamını oku»</a></p>" & vbCrLf
        TopicString = TopicString & "	    <p>"
        TopicString = TopicString & "		" & keywords & "<br />"
        TopicString = TopicString & "		</p>" & vbCrLf

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

        Session("dirty_" & TemizIsim) = DirtyText

        Return TemizIsim


    End Function

    Function HTMLtoTEXT(ByVal Metin)
        Dim TemizText = System.Text.RegularExpressions.Regex.Replace(Metin, "<[^>]*>", "")
        TemizText = Replace(TemizText, "&nbsp;", "")
        TemizText = Replace(TemizText, "&nbsp", "")

        Return TemizText
    End Function


End Class

