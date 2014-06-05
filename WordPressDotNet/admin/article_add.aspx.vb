Imports fn_general_v17
Imports db_acc_wpdn_v15
Imports wpdn_v10

Partial Class admin_makale_ekle
    Inherits System.Web.UI.Page

    Dim BasePath



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = "Admin Panel | Add Article"
        RegisterScripts()
        BasePath = PathYaz(Request.ServerVariables("SERVER_PORT"), Request.ServerVariables("SERVER_PORT_SECURE"), Request.ServerVariables("SERVER_NAME"), Request.ApplicationPath)
        ConfigFckEditor()


        If Not Page.IsPostBack Then

            FillForm()
        End If



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

    Sub RegisterScripts()
        Button1.Attributes.Add("onclick", "return confirm('Bilgileri kaydetmek istediğinize emin misiniz?');")
    End Sub

    Sub FillForm()
        TarihTxt.Text = DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss")

        WriteCategories()
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
            KategoriTxt.Items.Add(s)
        End While
        DR.Close()
    End Sub



    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim q1, q2, q3, q4, q5, q6, q7

        q1 = BaslikTxt.Text
        q2 = ASCIItoTextHTML(DB_ClearText(SummaryFCK.Value.ToString))
        q3 = ASCIItoTextHTML(DB_ClearText(ContentFCK.Value.ToString))
        q4 = YazarTxt.Text
        q5 = TarihForDB(TarihTxt.Text)
        q6 = KategoriTxt.SelectedItem.Value
        q7 = KeywTxt.Text


        Dim TblName = "content"
        Dim ColNames = "content_title,content_intro,content,author,content_date,categories,keywords"
        Dim ValNames = "'" & q1 & "','" & q2 & "','" & q3 & "','" & q4 & "'," & q5 & ",'" & q6 & "','" & q7 & "'"
        DB_INSERT(TblName, ColNames, ValNames)

        WarnTxt.Text = Warn("Makale Eklendi!")

    End Sub
End Class
