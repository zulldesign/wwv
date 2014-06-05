
Imports fn_general_v30
Imports wpdn_v10

Partial Class admin_makale_duzenle
    Inherits System.Web.UI.Page

    Dim MyDB As New db_acc_v21_data


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = "Admin Panel | Modify Article"
        RegisterScripts()

        ConfigFckEditor()

        If Not Page.IsPostBack Then
            FillForm()
            WriteSelectedArticle()
        End If

    End Sub



    Sub RegisterScripts()
        Button1.Attributes.Add("onclick", "return confirm('Bilgileri düzenlemek istediğinize emin misiniz?');")
    End Sub
    Sub ConfigFckEditor()
        Dim FCKFullPath = FCKPathYaz(Request.ServerVariables("SERVER_PORT"), Request.ServerVariables("SERVER_PORT_SECURE"), Request.ServerVariables("SERVER_NAME"), Request.ApplicationPath)
        'Response.Write(FCKFullPath)
        ContentFCK.BasePath = FCKFullPath
        ContentFCK.ImageBrowserURL = FCKFullPath & FCKImageBrowserURL & FCKFullPath & FCKConnectorPath
        ContentFCK.ID = FCKID & "1"
        ContentFCK.SkinPath = FCKSkinPath
        ContentFCK.ToolbarSet = FCKToolbarSet
        Session("FCKeditor:UserFilesPath") = FCKSessionUserFilesPath

        'Response.Write(FCKFullPath)
        SummaryFCK.BasePath = FCKFullPath
        SummaryFCK.ImageBrowserURL = FCKFullPath & FCKImageBrowserURL & FCKFullPath & FCKConnectorPath
        SummaryFCK.ID = FCKID & "2"
        SummaryFCK.SkinPath = FCKSkinPath
        SummaryFCK.ToolbarSet = FCKToolbarSet
    End Sub

    Sub FillForm()
        DateTxt.Text = DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss")
        WriteCategories()
        WriteArticles()
    End Sub

    Sub WriteCategories()
        Dim TblName = "categories"
        Dim ColName = "id,cat_name"

        Dim SqlStr = MyDB.DB_SelectSTR(TblName, ColName)

        Dim DT As System.Data.DataTable
        DT = MyDB.QueryDataTable(SqlStr)

        Dim MySTR = "", i
        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        If KS > 0 Then
            For i = 0 To KS - 1
                CategoryTxt.Text = DT.Rows(i).Item(1).ToString()

            Next
        End If


    End Sub
    Sub WriteArticles()
        Dim TblName = "content"
        Dim ColName = "id,content_title"
        Dim OrderBy = "content_date DESC"




        Dim SqlStr = MyDB.DB_SelectSTR(TblName, ColName, , OrderBy)

        Dim DT As System.Data.DataTable
        DT = MyDB.QueryDataTable(SqlStr)

        Dim MySTR = "", i
        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        If KS > 0 Then
            For i = 0 To KS - 1

                Dim s As New ListItem
                s.Value = DT.Rows(i).Item(0).ToString()
                s.Text = DT.Rows(i).Item(1).ToString()
                ArticleTxt.Items.Add(s)


            Next
        End If



    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Q(10)

        Dim ArticleId = ArticleTxt.SelectedItem.Value

        Q(1) = HeadingTxt.Text
        Q(2) = ASCIItoTextHTML(fn_general_v30.DB_ClearText(SummaryFCK.Value.ToString))
        Q(3) = ASCIItoTextHTML(fn_general_v30.DB_ClearText(ContentFCK.Value.ToString))
        Q(4) = AuthorTxt.Text
        Q(5) = fn_general_v30.TarihForDB(DateTxt.Text)
        Q(6) = CategoryTxt.Text
        Q(7) = KeywTxt.Text


        Dim i
        For i = 1 To 7
            Q(i) = fn_general_v30.DB_ClearText(Q(i))
        Next

        Dim TblName = "content"
        Dim ColNames = "content_title¦¦content_intro¦¦content¦¦author¦¦content_date¦¦categories¦¦keywords"
        Dim ValNames = "'" & Q(1) & "'¦¦'" & Q(2) & "'¦¦'" & Q(3) & "'¦¦'" & Q(4) & "'¦¦" & Q(5) & "¦¦'" & Q(6) & "'¦¦'" & Q(7) & "'"
        Dim WhereStr = "[id]=" & ArticleId & ""



        Dim SqlStr = MyDB.DB_UpdateSTR(TblName, ColNames, ValNames, WhereStr)
        MyDB.QueryExecuteNonQuery(SqlStr)

        WriteSelectedArticle(ArticleId)
        WarnTxt.Text = Warn("Makale Düzenlendi!")

    End Sub

    Protected Sub MakaleTxt_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ArticleTxt.SelectedIndexChanged
        Dim ArticleId = ArticleTxt.SelectedItem.Value
        WriteSelectedArticle(ArticleId)
    End Sub
    Sub WriteSelectedArticle(Optional ByVal ArticleId = "NO")
        If ArticleTxt.Items.Count = 0 Then Exit Sub

        If ArticleId = "NO" Then ArticleId = ArticleTxt.SelectedItem.Value

        Dim TblName = "content"
        Dim ColName = "id,content_title,content_intro,content,author,content_date,categories,keywords"
        Dim WhereStr = "id=" & ArticleId





        Dim SqlStr = MyDB.DB_SelectSTR(TblName, ColName, WhereStr)

        Dim DT As System.Data.DataTable
        DT = MyDB.QueryDataTable(SqlStr)

        Dim MySTR = "", i, R(7)
        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        If KS > 0 Then
            For j = 0 To KS - 1


                For i = 1 To 7
                    R(i) = DT.Rows(j).Item(i).ToString()
                    R(i) = fn_general_v30.DB_ReturnText(R(i))
                Next

                HeadingTxt.Text = R(1)
                SummaryFCK.Value = R(2)
                ContentFCK.Value = R(3)
                AuthorTxt.Text = R(4)
                DateTxt.Text = R(5)
                CategoryTxt.Text = R(6)
                KeywTxt.Text = R(7)



            Next
        End If








    End Sub
End Class
