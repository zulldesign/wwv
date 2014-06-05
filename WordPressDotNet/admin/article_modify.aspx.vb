Imports db_acc_wpdn_v15
Imports fn_general_v17
Imports wpdn_v10

Partial Class admin_makale_duzenle
    Inherits System.Web.UI.Page

    Dim BasePath

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = "Admin Panel | Modify Article"
        RegisterScripts()
        BasePath = PathYaz(Request.ServerVariables("SERVER_PORT"), Request.ServerVariables("SERVER_PORT_SECURE"), Request.ServerVariables("SERVER_NAME"), Request.ApplicationPath)
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

        Dim DR As System.Data.OleDb.OleDbDataReader
        DR = DB_SELECT(TblName, ColName)

        If DR.HasRows = "False" Then
            Exit Sub
        End If
        While DR.Read = True
            Dim s As New ListItem
            s.Value = DR.GetValue(0).ToString
            s.Text = DR.GetValue(1).ToString
            CategoryTxt.Items.Add(s)
        End While
        DR.Close()
    End Sub
    Sub WriteArticles()
        Dim TblName = "content"
        Dim ColName = "id,content_title"
        Dim OrderBy = "content_date DESC"

        Dim DR As System.Data.OleDb.OleDbDataReader
        DR = DB_SELECT(TblName, ColName, , OrderBy)

        If DR.HasRows = "False" Then
            Exit Sub
        End If
        While DR.Read = True
            Dim s As New ListItem
            s.Value = DR.GetValue(0).ToString
            s.Text = DR.GetValue(1).ToString
            ArticleTxt.Items.Add(s)
        End While
        DR.Close()
    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim q1, q2, q3, q4, q5, q6, q7

        Dim ArticleId = ArticleTxt.SelectedItem.Value

        q1 = HeadingTxt.Text
        q2 = ASCIItoTextHTML(DB_ClearText(SummaryFCK.Value.ToString))
        q3 = ASCIItoTextHTML(DB_ClearText(ContentFCK.Value.ToString))
        q4 = AuthorTxt.Text
        q5 = TarihForDB(DateTxt.Text)
        q6 = CategoryTxt.SelectedItem.Value
        q7 = KeywTxt.Text




        Dim TblName = "content"
        Dim ColNames = "content_title¦¦content_intro¦¦content¦¦author¦¦content_date¦¦categories¦¦keywords"
        Dim ValNames = "'" & q1 & "'¦¦'" & q2 & "'¦¦'" & q3 & "'¦¦'" & q4 & "'¦¦" & q5 & "¦¦'" & q6 & "'¦¦'" & q7 & "'"
        Dim WhereStr = "[id]=" & ArticleId & ""

        DB_UPDATE(TblName, ColNames, ValNames, WhereStr)
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

        Dim DR As System.Data.OleDb.OleDbDataReader
        DR = DB_SELECT(TblName, ColName, WhereStr)

        If DR.HasRows = "False" Then
            Exit Sub
        End If
        While DR.Read = True
            HeadingTxt.Text = DR.GetValue(1).ToString
            SummaryFCK.Value = DR.GetValue(2).ToString
            ContentFCK.Value = DR.GetValue(3).ToString
            AuthorTxt.Text = DR.GetValue(4).ToString
            DateTxt.Text = DR.GetValue(5).ToString
            CategoryTxt.SelectedValue = Val(DR.GetValue(6).ToString)
            KeywTxt.Text = DR.GetValue(7).ToString
        End While
        DR.Close()

    End Sub
End Class
