Imports db_acc_wpdn_v15

Imports System.Data

Partial Class index
    Inherits System.Web.UI.Page

    Dim RecordsSTR, KacinciKayit


    Dim Lang


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Lang = Request.QueryString("lang")
        'FindTranslations()

        ''####### REDIRECT START ##############
        'Dim HOST = Request.ServerVariables("HTTP_HOST")
        'If Replace(HOST, "holidaychoices.net", "") = HOST Then
        '    Response.Redirect("http://" & HOST)
        'End If
        ''####### REDIRECT END ##############

        'System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        'System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("en-US")

    End Sub


    Sub SessionBul()

        'If Trim(Request.QueryString("tag")) <> "" Then
        '    MetalariBulveYaz()
        'End If


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SessionBul()
        If Not Page.IsPostBack Then
            WriteMeta()
            WriteTopics()

        End If


    End Sub

    Public Sub PagePropertiesChanging(ByVal sender As Object, ByVal e As PagePropertiesChangingEventArgs)
        RecordsSTR = ""

        DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, False)
        ListView1.DataBind()
    End Sub


    Public Sub ComputeSum(ByVal sender As Object, ByVal e As ListViewItemEventArgs)
        If e.Item.ItemType = ListViewItemType.DataItem Then
            KacinciKayit = KacinciKayit + 1
            Dim dataItem As ListViewDataItem = CType(e.Item, ListViewDataItem)
            Dim rowView As DataRowView = CType(dataItem.DataItem, DataRowView)

            RecordsSTR = RecordsSTR & TopicData(rowView(0).ToString, rowView(1).ToString, rowView(2).ToString, rowView(3).ToString, rowView(4).ToString, rowView(5).ToString, rowView(6).ToString)
        End If
    End Sub


    Sub WriteTopics()


        Dim TblName = "content,categories"
        Dim ColName = "content.id,content.content_title,content.content_intro,content.author,content.content_date,content.keywords,categories.cat_name"
        'im ColName = "TOP 2 0ontent.id,1ontent.content_title,2ontent.content_intro,3ontent.author,4ontent.content_date,5ontent.keywords,6ategories.cat_name"
        Dim WhereStr = "content.categories = categories.[id]"
        Dim OrderBy = "content_date DESC"

        Dim DR As System.Data.OleDb.OleDbDataReader
        DR = DB_SELECT(TblName, ColName, WhereStr, OrderBy) 'DR.Close() : DB_CONN_CLOSE()

        Dim DataTable1 As New DataTable()
        DataTable1.Load(DR)
        DR.Close() : DB_CONN_CLOSE()

        ListView1.DataSource = DataTable1
        ListView1.DataBind()


        RecordsSTR = TopicStart() & RecordsSTR & TopicEnd()

        TopicTxt.Text = RecordsSTR

    End Sub
   





    Function TopicStart()
        Dim TopicString
        TopicString = TopicString & "<table class=' topic_table'>" & vbCrLf
        Return TopicString
    End Function


    Function TopicData(ByVal id, ByVal content_title, ByVal content, ByVal author, ByVal content_date, ByVal keywords, ByVal categories)
        Dim keywords2(), i
        Dim emphasis(3)

        keywords2 = Split(keywords, ",")
        keywords = ""
        For i = 0 To UBound(keywords2)
            If keywords2(i) <> "" Then
                keywords2(i) = Trim(keywords2(i))
                keywords = keywords & "<a class='topic_keywords' rel='tag' title='" & keywords2(i) & "' href='search.aspx?tag=" & ForURL(keywords2(i)) & "'>" & keywords2(i) & "</a>, "
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
                categories = categories & "<a class='topic_keywords' rel='categories' title='" & categories2(i) & "' href='categories.aspx?category=" & ForURL(categories2(i)) & "'>" & categories2(i) & "</a>, "
            End If
        Next
        If Trim(categories) <> "" Then
            categories = "<a class='topic_keywordstext'>" & Session("lang_categories") & ": </a>" & categories
        End If



        Dim gun, ay, yil : Dim tarih As Date
        tarih = content_date
        gun = tarih.ToString("dd") : ay = tarih.ToString("MMM") : yil = tarih.ToString("yyyy")
        Dim TopicString
        TopicString = TopicString & "	<tr>" & vbCrLf
        TopicString = TopicString & "		<td class='table_kesik_alt_cizgi'>" & vbCrLf

        TopicString = TopicString & "<table><tr>"
        TopicString = TopicString & "<td >"

        TopicString = TopicString & "<table class='time_table' >" & vbCrLf
        TopicString = TopicString & "	<tr>" & vbCrLf
        TopicString = TopicString & "		<td class='time_backg' >" & vbCrLf
        TopicString = TopicString & "           <small class='PostTime'>"
        TopicString = TopicString & "           <strong class='day'>" & gun & "</strong>"
        TopicString = TopicString & "           <strong class='month'>" & ay & "</strong>"
        TopicString = TopicString & "           <strong class='year'>" & yil & "</strong></small>"
        TopicString = TopicString & "	    </td>" & vbCrLf
        TopicString = TopicString & "	</tr>" & vbCrLf
        TopicString = TopicString & "</table>" & vbCrLf

        TopicString = TopicString & "</td>"



        TopicString = TopicString & "<td valign='top'>"
        TopicString = TopicString & "		<h3 >" & vbCrLf
        TopicString = TopicString & "		    <a class='topic_title'  rel='bookmark'  href='topic.aspx?id=" & id & "' title='" & content_title & "'>" & vbCrLf
        TopicString = TopicString & "            " & content_title & "</a>" & vbCrLf
        TopicString = TopicString & "		<a  href='search.aspx?tag=" & emphasis(1) & "' title='" & emphasis(1) & "'> <img class='topic_images' alt='" & emphasis(1) & "'   src='images/alt/kirmizi.gif'  /></a><a  href='search.aspx?tag=" & emphasis(2) & "' title='" & emphasis(2) & "'><img class='topic_images' alt='" & emphasis(2) & "' src='images/alt/sari.gif' /></a><a  href='search.aspx?tag=" & emphasis(3) & "' title='" & emphasis(3) & "'><img class='topic_images' alt='" & emphasis(3) & "' src='images/alt/yesil.gif'  /></a>" & vbCrLf
        TopicString = TopicString & "		<br />"
        TopicString = TopicString & "		</h3>" & vbCrLf
        TopicString = TopicString & "</td>"
        TopicString = TopicString & "</tr></table>"

        TopicString = TopicString & "		" & categories & "" & vbCrLf
        TopicString = TopicString & "				<p class='topic_content'>" & vbCrLf
        TopicString = TopicString & "               " & content & vbCrLf
        TopicString = TopicString & "				<a class='read_more' href='topic.aspx?id=" & id & "' >Devamını oku»</a></p>" & vbCrLf
        TopicString = TopicString & "	    <p>"
        TopicString = TopicString & "		" & keywords & "<br />"
        TopicString = TopicString & "		</p>" & vbCrLf

        TopicString = TopicString & "		</td>" & vbCrLf
        TopicString = TopicString & "	</tr>" & vbCrLf
        Return TopicString
    End Function

    Function TopicEnd()
        Dim TopicString
        TopicString = TopicString & "	</table>" & vbCrLf
        Return TopicString
    End Function


    Public Shared Function ForURL(ByVal UrlText)
        Dim Cleared = Trim(UrlText)

        Cleared = LCase(Cleared)
        Cleared = Trim(Cleared)


        Cleared = Replace(Cleared, Chr(34), "")
        Cleared = Replace(Cleared, ",", "%2C")
        'Cleared = Replace(Cleared, ",", "")
        'Cleared = Replace(Cleared, " ", "%20")
        Cleared = Replace(Cleared, " ", "-")
        Cleared = Replace(Cleared, ":", "")
        Cleared = Replace(Cleared, ";", "")
        Cleared = Replace(Cleared, ".", "")
        Cleared = Replace(Cleared, "'", "%27")
        'Cleared = Replace(Cleared, "'", "-")

        'Cleared = Replace(Cleared, "(", "-")
        'Cleared = Replace(Cleared, ")", "-")

        Cleared = Replace(Cleared, "/", "%2F")


        Cleared = Replace(Cleared, "ã", "a")
        Cleared = Replace(Cleared, "ä", "a")
        Cleared = Replace(Cleared, "ç", "c")
        Cleared = Replace(Cleared, "é", "e")
        Cleared = Replace(Cleared, "í", "i")
        Cleared = Replace(Cleared, "ü", "u")
        Cleared = Replace(Cleared, "ş", "s")
        Cleared = Replace(Cleared, "ı", "i")
        Cleared = Replace(Cleared, "ğ", "g")
        Cleared = Replace(Cleared, "ö", "o")
        Cleared = Replace(Cleared, "ñ", "n")

        Cleared = Trim(Cleared)
        Return Cleared
    End Function
 

    Sub WriteMeta()
        Dim Titlemiz, Desc, Keywords


        Dim TblName = "portal_conf"
        Dim ColName = "conf_name,conf_value"

        Dim DR As System.Data.OleDb.OleDbDataReader
        DR = DB_SELECT(TblName, ColName)


        Dim DefaultTitle, DefaultDesc, DefaultKeyw, HttpName
        While DR.Read = True

            Dim conf_name = DR.GetValue(0).ToString : Dim conf_value = DR.GetValue(1).ToString

            If Replace(conf_name, "meta_title", "") <> conf_name Then DefaultTitle = conf_value
            If Replace(conf_name, "meta_desc", "") <> conf_name Then DefaultDesc = conf_value
            If Replace(conf_name, "meta_keyw", "") <> conf_name Then DefaultKeyw = conf_value
            If Replace(conf_name, "http_name", "") <> conf_name Then HttpName = conf_value

        End While
        DR.Close() : DB_CONN_CLOSE()


        Me.Title = DefaultTitle & " | " & HttpName
        MetaEkle("description", DefaultDesc)
        MetaEkle("keywords", DefaultKeyw)

    End Sub



    Sub MetaEkle(ByVal meta_adi As String, ByVal meta_icerik As String)

        Dim yenimeta As New HtmlMeta()
        yenimeta.Name = meta_adi
        yenimeta.Content = meta_icerik
        Page.Header.Controls.Add(yenimeta)

    End Sub

End Class
