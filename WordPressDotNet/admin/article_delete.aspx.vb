Imports db_acc_wpdn_v15
Imports fn_general_v17

Partial Class admin_makale_sil
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = "Admin Panel | Delete Article"
        RegisterScripts()
        If Not Page.IsPostBack Then
            FillForm()
        End If


    End Sub
    Sub RegisterScripts()
        Button1.Attributes.Add("onclick", "return confirm('Bilgileri silmek istediğinize emin misiniz?');")
    End Sub
    Sub FillForm()
        WriteArticles()
    End Sub


    Sub WriteArticles()
        ArticleTxt.Items.Clear()

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
        Dim ArticleId = ArticleTxt.SelectedItem.Value
        DelSelectedArticle(ArticleId)

    End Sub
    Sub DELSelectedArticle(Optional ByVal ArticleId = "NO")

        Dim TblName = "content"
        Dim WhereStr = "id=" & ArticleId

        DB_DELETE(TblName, WhereStr)

        WriteArticles()
        WarnTxt.Text = Warn("Makale Silindi!")

    End Sub
End Class
