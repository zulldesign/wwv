Imports db_acc_wpdn_v15
Imports fn_general_v17

Partial Class wpdn_topic
    Inherits System.Web.UI.Page

    Dim DatabaseIsim = "databases/database.mdb"
    Dim DatabaseSifre = "extremeteam"
    Dim DBPath = Server.MapPath(DatabaseIsim)

    Dim TopicString, Lang
    Dim DefaultTitle, DefaultDesc, DefaultKeyw

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Lang = Request.QueryString("lang")
        'FindTranslations()

        ''####### REDIRECT START ##############
        'Dim HOST = Request.ServerVariables("HTTP_HOST")
        'If Replace(HOST, "holidaychoices.net", "") = HOST Then
        '    Response.Redirect("http://" & HOST)
        'End If
        ''####### REDIRECT END ##############

        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("tr-TR")
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("tr-TR")

    End Sub


    Sub SessionBul()

 

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load




        If Not Page.IsPostBack Then

            If Trim(Request.QueryString("id")) <> "" Then
                WriteTopic()
                WriteTopicMeta()
            End If

        End If


    End Sub


    Sub WriteTopic()

        Dim TopicId = Request.QueryString("id")

        Dim TblName = "content,categories"
        'Dim ColName = "id,content_title,content,author,content_date,keywords,categories"
        'Dim TblName = "content,categories"
        'Dim WhereStr = "id=" & TopicId & " "
        Dim ColName = "content.id,content.content_title,content.content,content.author,content.content_date,content.keywords,categories.cat_name"
        Dim WhereStr = "content.categories = categories.[id] and content.[id]=" & TopicId & ""


        Dim OrderBy = "content_date DESC"

        Dim DR As System.Data.OleDb.OleDbDataReader
        DR = DB_SELECT(TblName, ColName, WhereStr, OrderBy)


        TopicStart()

        While dr.Read = True
            TopicData(DR.GetValue(0).ToString, DR.GetValue(1).ToString, DR.GetValue(2).ToString, DR.GetValue(3).ToString, DR.GetValue(4).ToString, DR.GetValue(5).ToString, DR.GetValue(6).ToString)
        End While

        TopicEnd()

        TopicTxt.Text = TopicString


    End Sub



    Sub WriteTopicMeta()
        
        DefaultTitle = DefaultTitle & " | " & Replace(Session("http_name"), "http://", "")
        DefaultDesc = DefaultDesc & " |  " & Replace(Session("http_name"), "http://", "")
        DefaultKeyw = DefaultKeyw & " |  " & Replace(Session("http_name"), "http://", "")

        Me.Title = DefaultTitle
        MetaEkle("description", DefaultDesc) 
        MetaEkle("keywords", DefaultKeyw)

        MetaEkle("robots", "index, follow, NOODP") 'Open Directory Project'ten almasin bilgileri.

    End Sub

    Sub MetaEkle(ByVal meta_adi As String, ByVal meta_icerik As String)

        Dim yenimeta As New HtmlMeta()
        yenimeta.Name = meta_adi
        yenimeta.Content = meta_icerik
        Page.Header.Controls.Add(yenimeta)

    End Sub

    Sub TopicStart()
        TopicString = TopicString & "<table class=' topic_table'>" & vbCrLf
    End Sub


    Sub TopicData(ByVal id, ByVal content_title, ByVal content, ByVal author, ByVal content_date, ByVal keywords, ByVal categories)
        Dim keywords2(), i
        Dim emphasis(3)

        DefaultTitle = content_title : DefaultDesc = Left(HTMLtoTEXT(content), 200) : DefaultKeyw = keywords

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
                categories = categories & "<a class='topic_keywords' rel='tag' title='" & categories2(i) & "' href='search.aspx?tag=" & ClearText(categories2(i)) & "'>" & categories2(i) & "</a>, "
            End If
        Next
        If Trim(categories) <> "" Then
            categories = "<a class='topic_keywordstext'>" & Session("lang_categories") & ": </a>" & categories
        End If
        
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


        Return TemizIsim
    End Function

    Function HTMLtoTEXT(ByVal Metin)
        Dim TemizText = System.Text.RegularExpressions.Regex.Replace(Metin, "<[^>]*>", "")
        TemizText = Replace(TemizText, "&nbsp;", "")
        TemizText = Replace(TemizText, "&nbsp", "")

        Return TemizText
    End Function


End Class
