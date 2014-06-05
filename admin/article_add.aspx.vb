



Partial Class admin_makale_ekle
    Inherits System.Web.UI.Page

    Dim BasePath As String
 
    Sub ConfigFckEditor()

        Dim FCKFullPath = wpdn_v10.FCKPathYaz(Request.ServerVariables("SERVER_PORT"), Request.ServerVariables("SERVER_PORT_SECURE"), Request.ServerVariables("SERVER_NAME"), Request.ApplicationPath)
        'Response.Write(FCKFullPath)
        ContentFCK.BasePath = FCKFullPath


        ContentFCK.ImageBrowserURL = FCKFullPath & wpdn_v10.FCKImageBrowserURL & FCKFullPath & wpdn_v10.FCKConnectorPath
        ContentFCK.ID = wpdn_v10.FCKID & "1"
        ContentFCK.SkinPath = wpdn_v10.FCKSkinPath
        ContentFCK.ToolbarSet = wpdn_v10.FCKToolbarSet
        Session("FCKeditor:UserFilesPath") = wpdn_v10.FCKSessionUserFilesPath

    

    End Sub
    Sub RegisterScripts()
        Button1.Attributes.Add("onclick", "return confirm('Bilgileri kaydetmek istediğinize emin misiniz?');")
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim MyPort = Request.ServerVariables("SERVER_PORT") : Dim MySec = Request.ServerVariables("SERVER_PORT_SECURE") : Dim MyServ = Request.ServerVariables("SERVER_NAME") : Dim MyAppPath = Request.ApplicationPath
        BasePath = fn_general_v30.PathYaz(MyPort, MySec, MyServ, MyAppPath)


    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = "Admin Panel | Add Article"

        RegisterScripts()
        ConfigFckEditor()

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

        Fill_ListBox()
        Fill_Sessions()

    End Sub
    Sub Fill_Sessions()
        AuthorTxt.Text = "Admin"
    End Sub
    Sub Fill_ListBox()

        Dim MyDataFromDB As New fn_db_data
        Dim LC As New ListItemCollection
        LC = MyDataFromDB.GetCategoryTree_TreeView(BasePath, "listbox")
        CatList.DataSource = LC
        CatList.DataTextField = "Text" : CatList.DataValueField = "Value"
        CatList.DataBind()


    End Sub



    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim MyValidation As New fn_validations_wpdn_v10
        Dim ListResp
        If CatList.SelectedIndex = -1 Then ListResp = ""
        If CatList.SelectedIndex <> -1 Then ListResp = CatList.SelectedItem.Value
        Dim IsValid = MyValidation.Validate_NewArticle(TitleTxt.Text, ContentFCK.Value.ToString, KeywTxt.Text, AuthorTxt.Text, DateTxt.Text, ListResp)

        If IsValid <> "" Then WarnTxt.Text = fn_general_v30.Warn(IsValid)
        If IsValid <> "" Then Exit Sub

        Dim AuthorID = "1"

        Dim MyDataToDB As New fn_db_data
        Dim MyRESP = MyDataToDB.InsertArticle(TitleTxt.Text, ContentFCK.Value.ToString, AuthorID, DateTxt.Text, ListResp, KeywTxt.Text)



        WarnTxt.Text = fn_general_v30.Warn(MyRESP)
    End Sub









End Class
