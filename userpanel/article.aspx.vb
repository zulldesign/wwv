Imports fn_general_v30

Imports wpdn_v10
Imports html_tidy_v10


Partial Class admin_makale_ekle
    Inherits System.Web.UI.Page

    Dim BasePath As String
    Dim MyDB As New db_acc_v21_data

    'Sub ConfigFckEditor()

    '    Dim FCKFullPath = FCKPathYaz(Request.ServerVariables("SERVER_PORT"), Request.ServerVariables("SERVER_PORT_SECURE"), Request.ServerVariables("SERVER_NAME"), Request.ApplicationPath)
    '    'Response.Write(FCKFullPath)
    '    ContentFCK.BasePath = FCKFullPath
    '    ContentFCK.ImageBrowserURL = FCKFullPath & FCKImageBrowserURL & FCKFullPath & FCKConnectorPath
    '    ContentFCK.ID = FCKID & "1"
    '    ContentFCK.SkinPath = FCKSkinPath
    '    ContentFCK.ToolbarSet = FCKToolbarSet
    '    Session("FCKeditor:UserFilesPath") = FCKSessionUserFilesPath



    'End Sub
    Sub RegisterScripts()
        'SaveBtn.Attributes.Add("onclick", "return confirm('Bilgileri kaydetmek istediğinize emin misiniz?');")
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init


        Dim MyPort = Request.ServerVariables("SERVER_PORT") : Dim MySec = Request.ServerVariables("SERVER_PORT_SECURE") : Dim MyServ = Request.ServerVariables("SERVER_NAME") : Dim MyAppPath = Request.ApplicationPath
        BasePath = fn_general_v30.PathYaz(MyPort, MySec, MyServ, MyAppPath)



    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = "Admin Panel | Add Article"

        RegisterScripts()
        'ConfigFckEditor()

        If Not Page.IsPostBack Then

            FillForm()

        End If



        'Dim myTree As New TreeView : myTree = MyDataFromDB.GetCategoryTree_TreeView(BasePath)
        'TreePanel.Controls.Add(myTree)
        ''Treeview_GetNodes(myTree.Nodes)
        'TraceTree(myTree, ListBox1)
        'Dim MyDataFromDB As New fn_from_db_wpdn_10

        'Dim MyListBox As New ListBox
        'MyListBox = MyDataFromDB.GetCategoryTree_TreeView(BasePath)

        'TreePanel.Controls.Add(MyListBox)




    End Sub







    Sub FillForm()
        DateTxt.Text = DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss")
        SaveTypeTxt.Items.Add("template") ' | published | accepted | deleted
        SaveTypeTxt.Items.Add("published")
        SaveTypeTxt.Items.Add("accepted")
        SaveTypeTxt.Items.Add("deleted")

        Fill_ListBox()
        Fill_Sessions()

    End Sub
    Sub Fill_Sessions()
        AuthorTxt.Text = Session("user_name")
    End Sub
    Sub Fill_ListBox()

        Dim MyDataFromDB As New fn_db_data
        Dim LC As New ListItemCollection
        LC = MyDataFromDB.GetCategoryTree_TreeView(BasePath, "listbox")
        CatList.DataSource = LC
        CatList.DataTextField = "Text" : CatList.DataValueField = "Value"
        CatList.DataBind()


    End Sub


    Function CatListSelected()
        Dim ListResp
        If CatList.SelectedIndex = -1 Then ListResp = ""
        If CatList.SelectedIndex <> -1 Then ListResp = CatList.SelectedItem.Value
        Return ListResp
    End Function




    'Protected Sub AsyncFileUpload1_UploadedComplete1(ByVal sender As Object, ByVal e As AjaxControlToolkit.AsyncFileUploadEventArgs) Handles AsyncFileUpload1.UploadedComplete

    '    System.Threading.Thread.Sleep(1000)
    '    If AsyncFileUpload1.HasFile Then

    '        Dim Prefix = fn_general_v30.Session_GetID(16)
    '        Dim MyExt = fn_general_v30.File_GetExtension(AsyncFileUpload1.FileName)
    '        Dim MyPicName = Prefix & MyExt

    '        Dim SavePath As String = wpdn_v10.UserImgPath & MyPicName
    '        AsyncFileUpload1.SaveAs(SavePath)


    '        'SaveArticle(MyPicName, "template")

    '    End If

    'End Sub


    'Protected Sub btnShowUploadResult_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowUploadResult.Click
    '    MsgBox("test")
    'End Sub


    Function GetImageTable(ByVal ImgName)

        Dim STR As New StringBuilder

        STR.AppendLine("	<table cellspacing='5px' style=' width: 100%'>")
        STR.AppendLine("		<tr>")
        STR.AppendLine("			<td class=' pic_box '><img class='pic_box_img' src='http://resim.bilgiustam.info/uploads/1346-vao.png'  /></td>")
        STR.AppendLine("		</tr>")
        STR.AppendLine("	</table>")
        STR.AppendLine("naber")

        Return STR.ToString
    End Function


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles SaveBtn.Click


        'Dim MyValidation As New fn_validations_wpdn_v10

        'Dim CatID = CatListSelected()
        'Dim IsValid = MyValidation.Validate_NewArticle(TitleTxt.Text, ArticleTxt.Text, KeywTxt.Text, AuthorTxt.Text, DateTxt.Text, CatID)

        'If IsValid <> "" Then WarnTxt.Text = fn_general_v30.Warn(IsValid)
        'If IsValid <> "" Then Exit Sub

        'Dim AuthorID = Session("user_id")

        'Dim MyDataToDB As New fn_db_data
        'Dim MyRESP = MyDataToDB.InsertArticle(TitleTxt.Text, ArticleTxt.Text, AuthorID, DateTxt.Text, CatID, KeywTxt.Text)



        'WarnTxt.Text = fn_general_v30.Warn(MyRESP)

        SaveArticle()
    End Sub



    Sub SaveArticle(Optional ByVal MyPicName = "", Optional ByVal status = "")

        If status = "template" Then SaveTypeTxt.SelectedIndex = 0 'template

        Dim ArticleID = Request.QueryString("aid")
        If Trim(ArticleID) = "" Then
            ArticleID = SaveArticleAsTemplate(MyPicName)
        Else
            UpdateArticleAsTemplate(ArticleID, MyPicName)
        End If

        Response.Redirect("article.aspx" & Session("user_sess_url") & "&aid=" & ArticleID)
    End Sub

    Function SaveArticleAsTemplate(Optional ByVal MyPicName = "")


        Dim MyFN As New fn_db_userdata
        Dim MyNewArticleID = MyFN.SaveArticleAsAndReturnArticleID("", TitleTxt.Text, ArticleTxt.Text, Session("user_id"), CatListSelected(), KeywTxt.Text, "template", MyPicName)

        Return MyNewArticleID
    End Function

    Sub UpdateArticleAsTemplate(ByVal ArticleID, ByVal MyPicName)

    End Sub



  

End Class
