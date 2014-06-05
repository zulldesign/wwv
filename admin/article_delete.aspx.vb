

Partial Class admin_makale_sil
    Inherits System.Web.UI.Page

    Dim BasePath


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init


        Dim MyPort = Request.ServerVariables("SERVER_PORT") : Dim MySec = Request.ServerVariables("SERVER_PORT_SECURE") : Dim MyServ = Request.ServerVariables("SERVER_NAME") : Dim MyAppPath = Request.ApplicationPath
        BasePath = fn_general_v30.PathYaz(MyPort, MySec, MyServ, MyAppPath)
    End Sub


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


        Dim MyDataFromDB As New fn_db_data
        Dim LC As New ListItemCollection
        LC = MyDataFromDB.ArticleNames_ListBox
        ArticleTxt.DataSource = LC
        ArticleTxt.DataTextField = "Text" : ArticleTxt.DataValueField = "Value"
        ArticleTxt.DataBind()


    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ArticleId = ArticleTxt.SelectedItem.Value

        Dim MyDataFromDB As New fn_db_data
        MyDataFromDB.Delete_Article(ArticleId)


        WriteArticles()
        WarnTxt.Text = fn_general_v30.Warn("Makale Silindi!")
    End Sub
    Sub DELSelectedArticle(Optional ByVal ArticleId = "NO")

   

   

    End Sub
End Class
