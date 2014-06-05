

Partial Class tags_xml_data
    Inherits System.Web.UI.Page
    Dim BasePath
    Dim STR As New StringBuilder
    Dim LinkSayisi As Integer
    Dim Tarihimiz

    Dim MyDB As New db_acc_v21_data

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim MyPort = Request.ServerVariables("SERVER_PORT") : Dim MySec = Request.ServerVariables("SERVER_PORT_SECURE") : Dim MyServ = Request.ServerVariables("SERVER_NAME") : Dim MyAppPath = Request.ApplicationPath
        BasePath = fn_general_v30.PathYaz(MyPort, MySec, MyServ, MyAppPath)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        If Not Page.IsPostBack Then
            WriteSiteMap()

        End If


    End Sub

    Sub WriteSiteMap()
        SiteMapStart()

        XMLData_Content()

        SiteMapEnd()
        SiteMapGenerate()
    End Sub


    Sub SiteMapGenerate()
        Response.ContentType = "text/xml"
        Response.Write(STR.ToString())
        Response.End()
        STR.Length = 0
    End Sub

    Sub SiteMapStart()
        STR.AppendLine("<tags>")
    End Sub
    Sub SiteMapEnd()
        STR.AppendLine("</tags>")
        STR.AppendLine("<!-- Total Link: " & LinkSayisi & " -->")
    End Sub




    Sub XMLData_Content()


        Dim TblName = "referrals" 'id	searched_word	page	datetime
        Dim ColName, WhereSTR, OrderBy

        Dim TopicID = Request.QueryString("id")
        If TopicID <> "" Then
            ColName = "top 20 [id],[searched_word]"
            WhereSTR = "page=" & TopicID & ""
        Else
            ColName = "top 20 [id],[searched_word]"
        End If

        OrderBy = "id DESC"
        Dim SqlStr = MyDB.DB_SelectSTR(TblName, ColName, WhereSTR, OrderBy)


        Dim PreURL = ""
        If TopicID <> "" Then
            Dim MyDataFromDB As New fn_db_data
            Dim TopicURL = MyDataFromDB.GetTopicURL(TopicID, BasePath)
            PreURL = TopicURL
        End If


        Dim DT As System.Data.DataTable
        DT = MyDB.QueryDataTable(SqlStr)

        Dim MySTR = "", i
        Dim KS = DT.Rows.Count  'Kayıt Sayısı
        If KS > 0 Then
            For i = 0 To KS - 1
                Dim MyText = DT.Rows(i).Item(1).ToString()

                Dim MyID = DT.Rows(i).Item(0).ToString()

                Dim MyURL = wpdn_v10.MakeURL("referrals", , MyText, MyID, BasePath, , , , PreURL)
                UrlEkle(MyText, MyURL)
            Next
        End If


    End Sub


    Sub UrlEkle(ByVal Txt, ByVal URL)
        URL = Replace(URL, "&", "&amp;")

        Dim FontSize = fn_general_v30.RandomNumber2(18, 10)
        Dim RN = Right(LinkSayisi, 1)
        Dim Col, HiCol
        If RN = 1 Then
            Col = "0xccff00" : HiCol = "0xccff00"
        ElseIf RN = 2 Then
            Col = "0x123456" : HiCol = "0x123456"
        ElseIf RN = 3 Then
            Col = "0xff0099" : HiCol = "0xff0099"
        ElseIf RN = 4 Then
            Col = "0xffffff" : HiCol = "0xffffff"
        ElseIf RN = 4 Then
            Col = "0x3E9ADE" : HiCol = "0x3E9ADE"
        ElseIf RN = 5 Then
            Col = "0xccff00" : HiCol = "0xccff00"
        ElseIf RN = 6 Then
            Col = "0x123456" : HiCol = "0x123456"
        ElseIf RN = 7 Then
            Col = "0xff0099" : HiCol = "0xff0099"
        ElseIf RN = 8 Then
            Col = "0xffffff" : HiCol = "0xffffff"
        ElseIf RN = 9 Then
            Col = "0x3E9ADE" : HiCol = "0x3E9ADE"
        Else
            Col = "0x000099" : HiCol = "0x000099"
        End If

        STR.AppendLine("<a href=""" & URL & """ color=""" & Col & """ hicolor=""" & HiCol & """ style=""font-size: " & FontSize & "pt;"">" & Txt & "</a>")

        LinkSayisi = LinkSayisi + 1
    End Sub

   


End Class




