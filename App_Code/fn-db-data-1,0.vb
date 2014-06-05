Imports Microsoft.VisualBasic

Public Class fn_db_data
    Dim MyDBData As New db_acc_v21_data


    Dim LC As New ListItemCollection

    Dim Bosluk
    Dim BoslukSeviye As Integer




    Public Function ArticleNames_ListBox()

        Dim ListCol As New ListItemCollection

        Dim TblName = "content"
        Dim ColName = "id,content_title"
        Dim OrderBy = "id DESC"

        Dim SqlStr = MyDBData.DB_SelectSTR(TblName, ColName, , OrderBy)

        Dim DT As System.Data.DataTable
        DT = MyDBData.QueryDataTable(SqlStr)



        ListCol.Clear()
        Dim MyWord
        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        If KS > 0 Then
            For i = 0 To KS - 1
                Dim MyTitle = DT.Rows(i).Item(1).ToString()
                Dim MyID = DT.Rows(i).Item(0).ToString()
                Dim S As New ListItem
                S.Text = MyTitle
                S.Value = MyID
                ListCol.Add(S)
            Next
        End If


        Return ListCol

    End Function



    Public Function Delete_Article(ByVal ArticleID)

        Dim TblName = "content"
        Dim WhereStr = "[id]=" & ArticleID

        Dim MyDB As New db_acc_v21_data
        Dim SqlSTR = MyDB.DB_DeleteSTR(TblName, WhereStr)
        MyDB.QueryExecuteNonQuery(SqlSTR)


    End Function

    Public Function Get_ArticleID_ByDate(ByVal MyDate)
        Dim TblName = "content"
        Dim ColName = "id"
        Dim WhereStr = "[content_date]=" & fn_general_v30.TarihForDB(MyDate) & ""

        Dim SqlStr = MyDBData.DB_SelectSTR(TblName, ColName, WhereStr)

        Dim DT As System.Data.DataTable
        DT = MyDBData.QueryDataTable(SqlStr)

        Dim MyWord
        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        If KS > 0 Then
            MyWord = DT.Rows(0).Item(0).ToString
        End If

        Return MyWord
    End Function

    '########################  TREEVIEW - LISTVIEW STUFF START ###############################################
    Public Function GetCategoryTree_TreeView(ByVal BasePath, ByVal treeview_listbox_rootlist)
        Dim TblName = "categories"
        Dim ColName = "id,cat_name,parent_id,path"

        Dim SqlStr = MyDBData.DB_SelectSTR(TblName, ColName)

        Dim DT As System.Data.DataTable
        DT = MyDBData.QueryDataTable(SqlStr)

        Dim MyTree As New TreeView

        Dim MySTR = "", i
        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        If KS > 0 Then
            For i = 0 To KS - 1
                Dim CatID = DT.Rows(i)("id")
                Dim CatName = DT.Rows(i).Item(1).ToString()
                Dim ParentID = DT.Rows(i).Item(2).ToString()
                Dim ParentURL = DT.Rows(i).Item(3).ToString()
                Dim CatPath = wpdn_v10.MakeURL("tree", , CatName, CatID, BasePath, , , ParentURL)


                AddNode2(MyTree.Nodes, ParentID, CatID, CatName, CatPath)
                'AltKatYaz(CatID)
            Next
        End If



        If treeview_listbox_rootlist = "treeview" Then
            Return MyTree
        ElseIf treeview_listbox_rootlist = "listbox" Then
            LC.Clear()
            TraceTree(MyTree)
            Return LC
        ElseIf treeview_listbox_rootlist = "rootlist" Then
            LC.Clear()
            Dim S As New ListItem
            S.Text = "/"
            S.Value = 0
            LC.Add(S)
            TraceTree(MyTree)
            Return LC
        End If

        ''USAGE ########################333
        'Dim MyDataFromDB As New fn_db_data
        'Dim LC As New ListItemCollection
        'LC = MyDataFromDB.GetCategoryTree_TreeView(BasePath, "listbox")
        'CatList.DataSource = LC
        'CatList.DataTextField = "Text" : CatList.DataValueField = "Value"
        'CatList.DataBind()


    End Function
    Private Sub TraceTree(ByVal TV As TreeView)
        For Each tn As TreeNode In TV.Nodes
            TraceChildren(tn, 0)
        Next
    End Sub

    Private Sub TraceChildren(ByVal n As TreeNode, ByVal PassCount As Integer)

        Dim c As Integer = PassCount
        Dim symbol As String = ""

        If c > 0 Then
            For i As Integer = 0 To (c - 1)
                symbol = symbol & "─"

                Dim MyJ
                For j = 0 To i + 1
                    MyJ = MyJ & " "
                Next

                symbol = MyJ & " └" & symbol
                symbol = Replace(symbol, "└ ", "")
            Next
        End If

        If c > 0 Then symbol &= ">"

        '******************************************
        'To EXclude Root Node in Listbox use this:
        'If c > 0 Then LB.Items.Add(symbol & n.Text)

        'To INclude Root Node in ListBox use this:

        Dim S As New ListItem
        S.Text = symbol & n.Text
        S.Value = n.Value
        LC.Add(S)
        '******************************************

        Dim ctn As TreeNode
        c += 1

        For Each ctn In n.ChildNodes
            TraceChildren(ctn, c)
        Next

    End Sub

    Function Treeview_GetNodes(ByRef TNC As TreeNodeCollection)

        For Each MainNodez As TreeNode In TNC

            Dim S As New ListItem
            S.Text = MainNodez.Text
            LC.Add(S)


            If (MainNodez.ChildNodes.Count > 0) Then

                Treeview_GetChildNodes(MainNodez)
            End If
        Next
    End Function
    Function Treeview_GetChildNodes(ByVal MainNodez As TreeNode)
        Bosluk = ""
        For Each ChildNodez In MainNodez.ChildNodes

            Dim S As New ListItem
            S.Text = Bosluk & ChildNodez.Text
            LC.Add(S)

            If (ChildNodez.ChildNodes.Count > 0) Then
                Bosluk = Bosluk & " "
                Treeview_GetChildNodes(ChildNodez)
            End If

        Next
    End Function



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
    '########################  TREEVIEW - LISTVIEW STUFF END ###############################################


    'Sub GetTagCloudSTR(Optional ByVal ContentID)

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

    Public Function GetSearchedWord(ByVal WordID)
        Dim TblName = "referrals"
        Dim ColName = "searched_word"
        Dim WhereStr = "[id]=" & WordID & ""

        Dim SqlStr = MyDBData.DB_SelectSTR(TblName, ColName, WhereStr)

        Dim DT As System.Data.DataTable
        DT = MyDBData.QueryDataTable(SqlStr)

        Dim MyWord
        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        If KS > 0 Then
            MyWord = DT.Rows(0).Item(0).ToString
        End If

        Return MyWord
    End Function

    Public Function GetTopicURL(ByVal TopicID, ByVal BasePath)
        Dim TblName = "content"
        Dim ColName = "content_title,category_id"
        Dim WhereStr = "[id]=" & TopicID & ""

        Dim SqlStr = MyDBData.DB_SelectSTR(TblName, ColName, WhereStr)
        If TopicID = "" Then SqlStr = MyDBData.DB_SelectSTR(TblName, ColName)


        Dim DT As System.Data.DataTable
        DT = MyDBData.QueryDataTable(SqlStr)

        Dim TopicURL
        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        If KS > 0 Then

            Dim CatID = DT.Rows(0).Item(1).ToString
            Dim content_title = DT.Rows(0).Item(0).ToString

            Dim MyDataFromDB As New fn_db_data
            Dim MyCatz As New class_decl_v10.ParentCatNamez
            MyCatz = MyDataFromDB.FindBreadCrumb(CatID, BasePath, "topic_keywords")
            Dim CatLink = MyCatz.CatWithLink
            Dim CatForUrl = MyCatz.cat_parent_url & MyCatz.cat_name
            TopicURL = wpdn_v10.MakeURL("topic", CatForUrl, content_title, TopicID, BasePath)
        End If
        Return TopicURL
    End Function



    Public Function GetTagCloudAndWriteMasterPage(ByVal oPage As Page, ByVal BasePath As String, Optional ByVal TopicID As String = "", Optional ByVal TopicURL As String = "")

        Dim MyRESP As New class_decl_v10.Referalz

        Dim TblName = "referrals"
        Dim ColName = "TOP 20 [id],[searched_word],[page],[datetime]"
        Dim WhereStr = "[page]=" & TopicID & ""

        Dim SqlStr = MyDBData.DB_SelectSTR(TblName, ColName, WhereStr)
        If TopicID = "" Then SqlStr = MyDBData.DB_SelectSTR(TblName, ColName)


        Dim DT As System.Data.DataTable
        DT = MyDBData.QueryDataTable(SqlStr)

        Dim RefWithLinks, RefWithoutComma
        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        If KS > 0 Then
            For i = 0 To KS - 1

                Dim SWordID = DT.Rows(i).Item(0).ToString : Dim SWord = DT.Rows(i).Item(1).ToString
                SWord = HttpUtility.HtmlDecode(SWord)
                Dim RefURL = wpdn_v10.MakeURL("referrals", , SWord, SWordID, BasePath, , , , TopicURL)
                Dim RefLink = fn_general_v30.MakeLink(SWord, RefURL, "topic_keywords")
                RefWithLinks = RefWithLinks & RefLink & ", "
                RefWithoutComma = RefWithoutComma & SWord & " "

            Next
        End If

        Dim TagTxt = "<a class='topic_keywordstext'>Searched Words: </a>" & RefWithLinks 'Masterdeki TagTxt
        wpdn_v10.WriteMasterPageData("tags", MyTagsWithSWF(TagTxt), oPage) 'TagTxt.Text i yazıyoruz.


        Dim TagJS As New LiteralControl
        TagJS.Text = MyTagsJS("tag_xml_data.aspx?id=" & TopicID & "") 'ID ye göre XML oluşturuyoruz ve.. id yoksa da çalışır.. 
        oPage.Page.Header.Controls.Add(TagJS) 'header 'e js yi gömüyoruz 


        MyRESP.WorldsWithoutComma = RefWithoutComma
        Return MyRESP
    End Function


    Public Shared Function MyTagsJS(ByVal XMLSheet)
        Dim STR As New StringBuilder
        STR.AppendLine("<script type=""text/javascript"">" & vbCrLf)
        STR.AppendLine("swfobject.addDomLoadEvent(function() {" & vbCrLf)
        STR.AppendLine("  swfobject.embedSWF(" & vbCrLf)
        STR.AppendLine("					""tag_text_and_image_cloud.swf"", ""myContent4""," & vbCrLf)
        STR.AppendLine("					""275"", ""230""," & vbCrLf)
        STR.AppendLine("					""10"", ""tag_expressInstall.swf""," & vbCrLf)
        STR.AppendLine("					{" & vbCrLf)
        STR.AppendLine("						cloud_data:""" & XMLSheet & """," & vbCrLf)
        STR.AppendLine("						tcolor:""0xFA9100""," & vbCrLf)
        STR.AppendLine("						tcolor2:""0xFF5900""," & vbCrLf)
        STR.AppendLine("						hicolor:""0xA63A00""," & vbCrLf)
        STR.AppendLine("						tspeed:""250""," & vbCrLf)
        STR.AppendLine("						fontFace:""Impact""" & vbCrLf)
        STR.AppendLine("					}," & vbCrLf)
        STR.AppendLine("					{wmode: ""window"", menu: ""false"", quality: ""best""}" & vbCrLf)
        STR.AppendLine("					);" & vbCrLf)
        STR.AppendLine("});" & vbCrLf)
        STR.AppendLine("</script>" & vbCrLf)
        STR.AppendLine("" & vbCrLf)

        Return STR.ToString
    End Function
    Public Shared Function MyTagsWithSWF(ByVal Alt)
        Dim MyTxt
        MyTxt = MyTxt & "	<div>" & vbCrLf
        MyTxt = MyTxt & "		<div id=""myContent4"">" & vbCrLf
        MyTxt = MyTxt & "			" & Alt & "" & vbCrLf
        MyTxt = MyTxt & "			<p><a href=""http://www.adobe.com/go/getflashplayer""><img src=""http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif"" alt=""Get Adobe Flash player"" /></a></p>" & vbCrLf
        MyTxt = MyTxt & "		</div>" & vbCrLf
        MyTxt = MyTxt & "	</div>" & vbCrLf
        MyTxt = MyTxt & "" & vbCrLf
        Return MyTxt
    End Function




    Public Sub ReferralKaydet(ByVal REFF As String, Optional ByVal TopicID As String = "")
        'sadece topic sayfasına gelenleri tutalım, zaten index bir işe yaramıyor..
        If Trim(REFF) = "" Then Exit Sub

        Dim Q(5)
        Q(1) = Left(fn_general_v30.ClearLink(REFF, "q=", "&"), 100)
        Q(2) = TopicID
        Q(3) = fn_general_v30.TarihForDB(DateTime.Now)


        Q(1) = fn_general_v30.DB_ClearText(Q(1))
        Q(1) = fn_general_v30.ForSearch(Q(1))

        If Trim(Q(1)) = "" Or Trim(Q(1)) = "FALSE" Then Exit Sub

        Dim TblName = "referrals"
        Dim ColNames = "[searched_word],[page],[datetime]"
        Dim ValNames = "'" + Q(1) + "','" + Q(2) + "'," + Q(3) + ""

        Dim SqlStr = MyDBData.DB_InsertSTR(TblName, ColNames, ValNames)
        MyDBData.QueryExecuteNonQuery(SqlStr)

    End Sub



    Public Function GetTotalContentIDsSearched(ByVal WhereSTR As String)
        Dim MyRESP As New class_decl_v10.ContentIDs
        Dim TblName = "content"
        Dim ColName = "id"
        Dim OrderBy = "content_date DESC" 'performance açısından sorun yok :) (1.000.000 kayıt)

        Dim SqlStr = MyDBData.DB_SelectSTR(TblName, ColName, WhereSTR, OrderBy)
        Dim DT As System.Data.DataTable
        DT = MyDBData.QueryDataTable(SqlStr)

        Dim IDsFromDB As New StringBuilder
        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        MyRESP.RecordCount = KS

        If KS > 0 Then
            For i = 0 To KS - 1
                IDsFromDB.Append(DT.Rows(i).Item(0).ToString & ",")
            Next
            MyRESP.ContentIDs = IDsFromDB.ToString
        Else
            MyRESP.ContentIDs = ""
            Return MyRESP
        End If

        Return MyRESP

        'Dim pc As New System.Diagnostics.PerformanceCounter("ASP.NET Applications", "Cache % Machine Memory Limit Used", True)
        'pc.InstanceName = "__TOTAL__"
        'MsgBox(String.Format("{0:0.00}%", pc.NextValue()))
    End Function

    Public Function FindTag(ByVal TagID)
        Dim MyRESP As String = ""

        Dim TblName = "content_keywords"
        Dim ColName = "id,article_id,keyw"
        Dim WhereSTR = "id=" & TagID & ""

        Dim SqlStr = MyDBData.DB_SelectSTR(TblName, ColName, WhereSTR)
        Dim DT As System.Data.DataTable
        DT = MyDBData.QueryDataTable(SqlStr)

        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        If KS > 0 Then MyRESP = DT.Rows(0).Item(2).ToString()

        Return MyRESP
    End Function



    Public Function PagingAndContentIDs(ByVal CurPage, ByVal MyIDz, ByVal lang_previous_record, ByVal lang_next_record, ByVal lang_no_record, ByVal lang_first_record, ByVal lang_page, ByVal lang_last_record, ByVal lang_not_found_ads, ByVal BasePath)
        'Sayfalamayı her sayfayı çağırdığında yapıyoruz bu yüzden, .net paging işe yaramıyor..
        Dim MyRESP As New class_decl_v10.Paging


        Dim MyIDs() As String = MyIDz.ToString.Split(",")

        Dim ListSBK = wpdn_v10.ListSBK 'sayfa başına kayıt
        If String.IsNullOrEmpty(CurPage) Then CurPage = 0

        Dim RC As Integer = UBound(MyIDs)  'record count
        If RC = 0 Then GoTo PagingStart

        If wpdn_v10.MixedContent = "yes" Then GoTo PagingStart

        Dim StartRec As Integer = (CurPage * ListSBK) + 1 'Starting Record
        Dim EndRec As Integer = (CurPage * ListSBK) + ListSBK 'Ending Record

        Dim LastRecForArray = RC - 1
        StartRec = StartRec - 1 : EndRec = EndRec - 1 'For ARRAY
        If StartRec > LastRecForArray Then StartRec = LastRecForArray
        If EndRec > LastRecForArray Then EndRec = LastRecForArray


        Dim IDs As String
        Dim i As Integer
        For i = StartRec To EndRec
            IDs = IDs & MyIDs(i).ToString & ","

        Next



PagingStart:
        Dim PagingSTR As String
        If RC > 0 Then
            PagingSTR = fn_general_v30.MakePageNo(RC, BasePath & "page/[PN]/", CurPage, lang_previous_record, lang_next_record, lang_no_record, lang_page, lang_first_record, lang_last_record)
        Else
            PagingSTR = wpdn_v10.Ads_GetNotFoundString(lang_not_found_ads)
        End If


        If wpdn_v10.MixedContent = "yes" Then
            IDs = fn_general_v30.RandomSec(MyIDz, wpdn_v10.ListSBK)
        End If



        MyRESP.ArticleIDs = IDs
        MyRESP.PagingSTR = PagingSTR 'paging numberz


        Return MyRESP

        'Dim MyTempIDs() = IDsFromDB.ToString.Split(",")
        'Dim MyIDs() As Integer = Array.ConvertAll(MyTempIDs, Function(s) If(IsNumeric(s.ToString), Convert.ToInt32(s.ToString), Nothing))
        'Array.Sort(MyIDs)
        'Array.Reverse(MyIDs) 'son topic gelen önce.
    End Function


    Public Function GetContentInfos_SingleREC_Long(ByVal MyID, ByVal lang_tags, ByVal lang_categories, ByVal short_http_name, ByVal lang_more, ByVal lang_author, ByVal BasePath, ByVal MyTag, ByVal MySearch)
        Dim MyRESP As New class_decl_v10.TopicPage

        Dim TblName = "content,categories"
        Dim ColName = "content.id, content.content_title,content.id,content.author,content.content_date,categories.cat_name,content.content,content.category_id"
        'im ColName = "0ontent.id,1ontent.content_title,2ontent.,3ontent.author,4ontent.content_date,5ontent.categories,6ontent.content"
        'Dim WhereSTR = "id BETWEEN " & FA & " AND " & LA & ""
        Dim WhereSTR = "content.id=" & MyID & " AND categories.id=content.category_id"

        Dim SqlStr = MyDBData.DB_SelectSTR(TblName, ColName, WhereSTR)

        Dim DT As System.Data.DataTable
        DT = MyDBData.QueryDataTable(SqlStr)

        Dim RecordsSTR As New StringBuilder
        Dim i As Integer
        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        MyRESP.RecordCount = KS
        If KS > 0 Then
            For i = 0 To KS - 1

                Dim MyDataFromDB As New fn_db_data
                Dim MyKeys As New class_decl_v10.Keywordz
                MyKeys = MyDataFromDB.FindKeywWithLink(DT.Rows(i).Item(0).ToString, DT.Rows(i).Item(5).ToString, DT.Rows(i).Item(1).ToString, lang_tags, BasePath)


                Dim TopicID = DT.Rows(i).Item(0).ToString
                Dim CatID = DT.Rows(i).Item(7).ToString
                Dim TopicData = DT.Rows(0).Item(6).ToString
                ''RecordsSTR.Append(wpdn_v10.TopicData(DT.Rows(i).Item(0).ToString, DT.Rows(i).Item(1).ToString, DT.Rows(i).Item(2).ToString, DT.Rows(i).Item(3).ToString, DT.Rows(i).Item(4).ToString, MyKeys.KeywWithLink, "", "", BasePath, lang_tags, lang_categories, short_http_name, lang_more, , , "yes", , , , MyKeys.Keyw1, MyKeys.Keyw1ID, MyKeys.Keyw2, MyKeys.Keyw2ID, MyKeys.Keyw3, MyKeys.Keyw3ID, short_http_name, CatID, lang_author))

                'RecordsSTR.Append(wpdn_v10.TopicData(TopicID, DT.Rows(0).Item(1).ToString, DT.Rows(0).Item(2).ToString, DT.Rows(0).Item(3).ToString, DT.Rows(0).Item(4).ToString, DT.Rows(0).Item(6).ToString, BasePath, lang_tags, lang_categories, lang_more, "yes", , , MyTag, MySearch, short_http_name, CatID, lang_author))
                RecordsSTR.Append(wpdn_v10.TopicData(TopicID, DT.Rows(0).Item(1).ToString, DT.Rows(0).Item(2).ToString, DT.Rows(0).Item(3).ToString, DT.Rows(0).Item(4).ToString, DT.Rows(0).Item(6).ToString, BasePath, lang_tags, lang_categories, lang_more, "yes", , , MyTag, MySearch, short_http_name, CatID, lang_author))

                'RecordsSTR.Append(wpdn_v10.TopicData(TopicID, DT.Rows(i).Item(1).ToString, DT.Rows(i).Item(2).ToString, DT.Rows(i).Item(3).ToString, DT.Rows(i).Item(4).ToString, "", BasePath, lang_tags, lang_categories, lang_more, , , "yes", , , short_http_name, CatID, lang_author))
                MyRESP.ContentCat = DT.Rows(i).Item(5).ToString
                MyRESP.ContentCatID = DT.Rows(i).Item(7).ToString
                MyRESP.KeywWithoutLink = MyKeys.KeywWithoutLink
                MyRESP.ContentTitle = DT.Rows(0).Item(1).ToString
                MyRESP.ContentDesc = DT.Rows(0).Item(2).ToString

                MyRESP.ImageInTopic = fn_general_v30.Image_FindSingleFromAllHTML(TopicData)

            Next
        End If

        MyRESP.TopicSTR = wpdn_v10.TopicStart() & RecordsSTR.ToString & wpdn_v10.TopicEnd()

        Return MyRESP
    End Function

    Public Function GetContentInfos_Total_Short(ByVal IDs, ByVal lang_tags, ByVal lang_categories, ByVal short_http_name, ByVal lang_more, ByVal lang_author, ByVal BasePath)
        Dim MyRESP As String
        Dim TblName = "content,categories"
        Dim ColName = "content.id,content.content_title,content.content,content.author,content.content_date,categories.cat_name,content.id,content.category_id"
        'im ColName = "0ontent.id,1ontent.content_title,2ontent.,3ontent.author,4ontent.content_date,5ontent.categories,6ontent.content"
        'Dim WhereSTR = "id BETWEEN " & FA & " AND " & LA & ""
        Dim WhereSTR = "content.id IN (" & IDs & ") AND categories.id=content.category_id"
        Dim OrderBy = "content.content_date DESC"

        Dim SqlStr = MyDBData.DB_SelectSTR(TblName, ColName, WhereSTR, OrderBy)

        Dim DT As System.Data.DataTable
        DT = MyDBData.QueryDataTable(SqlStr)

        Dim RecordsSTR As New StringBuilder
        Dim i As Integer
        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        If KS > 0 Then
            For i = 0 To KS - 1
                Dim TopicID = DT.Rows(i).Item(0).ToString
                Dim CatID = DT.Rows(i).Item(7).ToString


                RecordsSTR.Append(wpdn_v10.TopicData(TopicID, DT.Rows(i).Item(1).ToString, DT.Rows(i).Item(2).ToString, DT.Rows(i).Item(3).ToString, DT.Rows(i).Item(4).ToString, "", BasePath, lang_tags, lang_categories, lang_more, , , "yes", , , short_http_name, CatID, lang_author))

            Next
        End If

        MyRESP = wpdn_v10.TopicStart() & RecordsSTR.ToString & wpdn_v10.TopicEnd()

        Return MyRESP
    End Function


    Public Function GetTotalContentIDs()
        Dim MyRESP As New class_decl_v10.ContentIDs
        Dim TblName = "content"
        Dim ColName = "id"
        Dim OrderBy = "content_date DESC" 'performance açısından sorun yok :) (100.000 kayıt)

        Dim SqlStr = MyDBData.DB_SelectSTR(TblName, ColName, , OrderBy)
        Dim DT As System.Data.DataTable
        DT = MyDBData.QueryDataTable(SqlStr)

        Dim IDsFromDB As New StringBuilder
        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        MyRESP.RecordCount = KS

        If KS > 0 Then
            For i = 0 To KS - 1
                IDsFromDB.Append(DT.Rows(i).Item(0).ToString & ",")
            Next
            MyRESP.ContentIDs = IDsFromDB.ToString
        Else
            MyRESP.ContentIDs = ""
            Return MyRESP
        End If

        Return MyRESP

        'Dim pc As New System.Diagnostics.PerformanceCounter("ASP.NET Applications", "Cache % Machine Memory Limit Used", True)
        'pc.InstanceName = "__TOTAL__"
        'MsgBox(String.Format("{0:0.00}%", pc.NextValue()))
    End Function

    Public Function FindKeywWithLink(ByVal ArticleID, ByVal CatName, ByVal content_title, ByVal SESS_lang_tags, ByVal BasePath)

        Dim MyRESP As New class_decl_v10.Keywordz

        Dim TblName = "content_keywords"
        Dim ColName = "id,article_id,keyw"
        Dim WhereSTR = "article_id=" & ArticleID & ""

        Dim SqlStr = MyDBData.DB_SelectSTR(TblName, ColName, WhereSTR)
        Dim DT As System.Data.DataTable
        DT = MyDBData.QueryDataTable(SqlStr)


        Dim MySTR, KeyWithoutLink, TotalKeywWithURLz
        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        If KS > 0 Then
            For i = 0 To KS - 1
                Dim MyTagID = DT.Rows(i).Item(0).ToString()
                Dim MyTag = DT.Rows(i).Item(2).ToString()
                Dim MyURL = wpdn_v10.MakeURL("search", CatName, content_title, ArticleID, BasePath, MyTag, MyTagID)

                TotalKeywWithURLz = TotalKeywWithURLz & MyURL & "¥"
                MySTR = MySTR & fn_general_v30.MakeLink(MyTag, MyURL, "topic_keywords", , "h3") & ", "
                KeyWithoutLink = KeyWithoutLink & ", " & MyTag

                If i = 0 Then
                    MyRESP.Keyw1 = MyTag : MyRESP.Keyw1ID = MyTagID
                End If
                If i = 1 Then
                    MyRESP.Keyw2 = MyTag : MyRESP.Keyw2ID = MyTagID
                End If
                If i = 2 Then
                    MyRESP.Keyw3 = MyTag : MyRESP.Keyw3ID = MyTagID
                End If
            Next
        End If

        MyRESP.KeywWithLink = "<a class='topic_keywordstext'>" & SESS_lang_tags & ": </a>" & MySTR
        MyRESP.KeywWithoutLink = KeyWithoutLink
        MyRESP.TotalKeywWithURLz = TotalKeywWithURLz
        Return MyRESP
    End Function


    Public Function Get_ParentURL(ByVal KatID)
        Dim MyRESP As New class_decl_v10.ParentCatNamez

        Dim MyANSW As New class_decl_v10.ParentCatNamez
        MyANSW = GetCatBACK(KatID)


        Dim CatForUrl = MyANSW.cat_parent_url & fn_general_v30.TextToURL(MyANSW.cat_name) & "/"

        MyRESP.cat_parent_url = CatForUrl

        Return MyRESP
        'WriteMeta(BreadCrumbJustText, MyDescx, Replace(BreadCrumbJustText, " ", ","))
    End Function
    Public Function FindBreadCrumb(ByVal KatID, ByVal BasePath, Optional ByVal MyCSS = "")
        Dim MyRESP As New class_decl_v10.ParentCatNamez

        Dim MyANSW As New class_decl_v10.ParentCatNamez
        MyANSW = GetCatBACK(KatID)


        MyRESP.cat_name = MyANSW.cat_name
        MyRESP.cat_desc = MyANSW.cat_desc
        MyRESP.cat_keyw = MyANSW.cat_keyw
        MyRESP.cat_parent_url = MyANSW.cat_parent_url

        Dim BreadCrumb = MyANSW.CatNameWrap


        Dim BreadCrumbJustText, CatNamezForURL

        Dim Cats() = BreadCrumb.ToString.Split("¦")
        Dim i : BreadCrumb = ""
        For i = UBound(Cats) - 1 To 0 Step -1

            Dim Temps() = Cats(i).ToString.Split("¥")
            Dim CatName1 = Temps(0).ToString : Dim CatID = Temps(1).ToString 'katadı & katid

            Dim Temps2() = CatName1.ToString.Split("§")
            Dim CatName = Temps2(0).ToString : Dim ParentURL = Temps2(1).ToString 'katadı & katpath



            Dim CatURL = wpdn_v10.MakeURL("tree", , CatName, CatID, BasePath, , , ParentURL)

            Dim MyLink = fn_general_v30.MakeLink(CatName, CatURL, MyCSS)
            Dim BreadText = CatName

            If i <> 0 Then
                BreadCrumb = BreadCrumb & MyLink & " -> "
                BreadCrumbJustText = BreadCrumbJustText & BreadText & " -> " 'just text
            Else
                BreadCrumb = BreadCrumb & MyLink
                BreadCrumbJustText = BreadText & " -> " & BreadCrumbJustText   'just text
            End If

        Next

        If Right(BreadCrumbJustText, 3) = "-> " Then BreadCrumbJustText = Left(BreadCrumbJustText, Len(BreadCrumbJustText) - 3)
        If Right(BreadCrumb, 3) = "-> " Then BreadCrumb = Left(BreadCrumb, Len(BreadCrumb) - 3)

        MyRESP.CatWithLink = BreadCrumb
        MyRESP.CatWithoutLink = BreadCrumbJustText


        Return MyRESP
        'WriteMeta(BreadCrumbJustText, MyDescx, Replace(BreadCrumbJustText, " ", ","))
    End Function
    Private Function GetCatBACK(ByVal KategoriId As Integer)

        Dim MyRESP As New class_decl_v10.ParentCatNamez

        Dim MySTR As New StringBuilder

        Dim TblName = "categories"
        Dim ColName = "id,cat_name,parent_id,path,cat_desc,cat_keyw"
        Dim WhereSTR = "id=" & KategoriId
        Dim SqlStr = MyDBData.DB_SelectSTR(TblName, ColName, WhereSTR)

        Dim DT As System.Data.DataTable
        DT = MyDBData.QueryDataTable(SqlStr)

        Dim KatID, KatADI, UstKatID, KatPath

        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        If KS > 0 Then
            KatID = DT.Rows(0).Item(0).ToString()
            KatADI = DT.Rows(0).Item(1).ToString()
            UstKatID = DT.Rows(0).Item(2).ToString()
            KatPath = DT.Rows(0).Item(3).ToString()

            MyRESP.cat_parent_url = KatPath
            MyRESP.cat_name = KatADI
            MyRESP.cat_desc = DT.Rows(0).Item(4).ToString()
            MyRESP.cat_keyw = DT.Rows(0).Item(4).ToString()

            MySTR.Append(KatADI & "§" & KatPath & "¥" & KatID & "¦")
        Else
            Return "" ' exit function
        End If

        While Not UstKatID = 0 Or UstKatID = ""

            Dim TblName2 = "categories"
            Dim ColName2 = "id,cat_name,parent_id,path"
            Dim WhereSTR2 = "id=" & UstKatID
            Dim SqlStr2 = MyDBData.DB_SelectSTR(TblName2, ColName2, WhereSTR2)

            Dim DT2 As System.Data.DataTable
            DT2 = MyDBData.QueryDataTable(SqlStr2)

            Dim KS2 = DT2.Rows.Count 'Kayıt Sayısı
            If KS2 > 0 Then
                KatID = DT2.Rows(0).Item(0).ToString()
                KatADI = DT2.Rows(0).Item(1).ToString()
                UstKatID = DT2.Rows(0).Item(2).ToString()
                KatPath = DT2.Rows(0).Item(3).ToString()

                MySTR.Append(KatADI & "§" & KatPath & "¥" & KatID & "¦")
            Else
                Exit While
            End If

        End While

        MyRESP.CatNameWrap = MySTR.ToString

        Return MyRESP

        'USAGE ######################################
        'Dim BreadCrumb = GetKategori(11)
        'Dim Cats() = BreadCrumb.ToString.Split("¦")
        'Dim i : BreadCrumb = ""
        'For i = UBound(Cats) To 0 Step -1
        '    Dim Temp = Cats(i)
        '    BreadCrumb = BreadCrumb & Temp & "<br >"
        'Next
        'Label1.Text = BreadCrumb
    End Function


    Public Function GetCatFORW(ByVal KatID, Optional ByVal BasePath = "", Optional ByVal MyCSS = "")
        Dim MyRESP As New class_decl_v10.SubCatNamez

        Dim MyANSW As New class_decl_v10.SubCatNamez
        MyANSW = GetCatFORW_SubProcess(KatID)

        MyRESP.SubCatIDz = MyANSW.SubCatIDz

        Return MyRESP

    End Function

    Private Function GetCatFORW_SubProcess(ByVal KategoriId As Integer)
        Dim MyRESP As New class_decl_v10.SubCatNamez


        Dim JustIDs, CatWrap

        Dim TblName = "categories"
        Dim ColName = "id,cat_name,parent_id"
        Dim WhereSTR = "id=" & KategoriId
        Dim SqlStr = MyDBData.DB_SelectSTR(TblName, ColName, WhereSTR)

        Dim DT As System.Data.DataTable
        DT = MyDBData.QueryDataTable(SqlStr)

        Dim KatID, KatADI, UstKatID

        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        If KS > 0 Then
            KatID = DT.Rows(0).Item(0).ToString()
            KatADI = DT.Rows(0).Item(1).ToString()
            UstKatID = DT.Rows(0).Item(2).ToString()


            JustIDs = JustIDs & KatID & ","
            CatWrap = CatWrap & KatADI & "¥" & KatID & "¦"

        Else
            Return "" ' exit function
        End If


        UstKatID = KatID 'kendimizden başlayıp..
        While Not UstKatID = ""

            Dim TblName2 = "categories"
            Dim ColName2 = "id,cat_name,parent_id"
            Dim WhereSTR2 = "parent_id=" & UstKatID
            Dim SqlStr2 = MyDBData.DB_SelectSTR(TblName2, ColName2, WhereSTR2)

            Dim DT2 As System.Data.DataTable
            DT2 = MyDBData.QueryDataTable(SqlStr2)

            Dim KS2 = DT2.Rows.Count 'Kayıt Sayısı
            If KS2 > 0 Then
                For i = 0 To KS2 - 1
                    KatID = DT2.Rows(i).Item(0).ToString()
                    KatADI = DT2.Rows(i).Item(1).ToString()
                    'UstKatID = DT2.Rows(0).Item(2).ToString()
                    UstKatID = KatID


                    JustIDs = JustIDs & KatID & ","
                    CatWrap = CatWrap & KatADI & "¥" & KatID & "¦"

                Next
            Else
                Exit While
            End If

        End While

        MyRESP.SubCatIDz = JustIDs
        MyRESP.CatNameWrap = CatWrap

        Return MyRESP


    End Function






    Public Function Category_Delete(ByVal cat_id)

        Dim TblName = "categories"
        Dim WhereStr = "[id]=" & cat_id

        Dim MyDB As New db_acc_v21_data
        Dim SqlSTR = MyDB.DB_DeleteSTR(TblName, WhereStr)
        MyDB.QueryExecuteNonQuery(SqlSTR)


    End Function

    Public Function InsertCategory(ByVal cat_name, ByVal cat_desc, ByVal cat_keyw, ByVal parent_id)
        Dim MyRESP As String
        'article_id,	keyw

        Try

            Dim q(20)
            q(1) = cat_name
            q(2) = cat_desc
            q(3) = cat_keyw
            q(4) = parent_id

            Dim ParentCatID = parent_id
            If ParentCatID <> 0 Then
                Dim MyDataFromDB As New fn_db_data
                Dim MyANSW As New class_decl_v10.ParentCatNamez
                MyANSW = MyDataFromDB.Get_ParentURL(ParentCatID)

                q(5) = MyANSW.cat_parent_url
            Else
                q(5) = ""
            End If



            For i = 1 To 20
                q(i) = fn_general_v30.DB_ClearText(q(i))
            Next

            Dim TblName = "[categories]"
            Dim ColNames = "cat_name,cat_desc,cat_keyw,parent_id,[path]"

            Dim ValNames = "'" & q(1) & "','" & q(2) & "','" & q(3) & "'," & q(4) & ",'" & q(5) & "'"

            Dim SqlStr = MyDBData.DB_InsertSTR(TblName, ColNames, ValNames)
            MyDBData.QueryExecuteNonQuery(SqlStr)



            MyRESP = "Category Added!"
        Catch ex As Exception

            MyRESP = ex.Message.ToString
        End Try

        Return MyRESP

    End Function


    Public Function InsertArticle(ByVal content_title, ByVal content, ByVal authorID, ByVal content_date, ByVal category_id, ByVal keywords)
        Dim MyRESP As String
        'article_id,	keyw

        Try

            Dim q(20)
            q(1) = content_title

            q(3) = fn_general_v30.ASCIItoTextHTML(content)
            q(4) = authorID
            q(5) = fn_general_v30.TarihForDB(content_date)
            q(6) = category_id

            For i = 1 To 20
                q(i) = fn_general_v30.DB_ClearText(q(i))
            Next

            Dim TblName = "content"
            Dim ColNames = "content_title,content,author,content_date,category_id"

            Dim ValNames = "'" & q(1) & "','" & q(3) & "'," & q(4) & "," & q(5) & "," & q(6) & ""



            Dim SqlStr = MyDBData.DB_InsertSTR(TblName, ColNames, ValNames)

            MyDBData.QueryExecuteNonQuery(SqlStr)


            '#### Keywords ####
            If Trim(keywords) <> "" Then
                Dim MyDataFromDB As New fn_db_data
                Dim MyID = MyDataFromDB.Get_ArticleID_ByDate(content_date)
                InsertKeywords(MyID, keywords)
            End If
            '#### Keywords ####

            MyRESP = "Article Added!"
        Catch ex As Exception

            MyRESP = ex.Message.ToString
        End Try

        Return MyRESP

    End Function
    Sub InsertKeywords(ByVal ArticleID, ByVal Keyw)

        Dim q(20)
        q(1) = ArticleID
        q(2) = Keyw


        Dim MyKeys()
        MyKeys = Keyw.ToString.Split(",")

        For i = 0 To UBound(MyKeys)
            Dim MyKey = MyKeys(i).ToString
            If Trim(MyKey) <> "" Then

                MyKey = fn_general_v30.DB_ClearText(MyKey)

                Dim TblName = "content_keywords"
                Dim ColNames = "article_id,	keyw"

                Dim ValNames = "" & q(1) & ",'" & MyKey & "'"

                Dim SqlStr = MyDBData.DB_InsertSTR(TblName, ColNames, ValNames)
                MyDBData.QueryExecuteNonQuery(SqlStr)
            End If
        Next


    End Sub





End Class
