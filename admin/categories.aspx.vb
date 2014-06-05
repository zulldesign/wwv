
Partial Class admin_categories2
    Inherits System.Web.UI.Page

    Dim BasePath



    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim MyPort = Request.ServerVariables("SERVER_PORT") : Dim MySec = Request.ServerVariables("SERVER_PORT_SECURE") : Dim MyServ = Request.ServerVariables("SERVER_NAME") : Dim MyAppPath = Request.ApplicationPath
        BasePath = fn_general_v30.PathYaz(MyPort, MySec, MyServ, MyAppPath)

        Button2.Attributes.Add("onclick", "return confirm('Bilgileri silmek istediğinize emin misiniz?');")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            FillForm()
        End If
    End Sub

    Sub FillForm()
        Fill_ListBox()
    End Sub
    Sub Fill_ListBox()
        CatList.Items.Clear()

        Dim MyDataFromDB As New fn_db_data
        Dim LC As New ListItemCollection
        LC = MyDataFromDB.GetCategoryTree_TreeView(BasePath, "rootlist")
        CatList.DataSource = LC
        CatList.DataTextField = "Text" : CatList.DataValueField = "Value"
        CatList.DataBind()

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim MyValidation As New fn_validations_wpdn_v10
        Dim ListResp
        If CatList.SelectedIndex = -1 Then ListResp = ""
        If CatList.SelectedIndex <> -1 Then ListResp = CatList.SelectedItem.Value
        Dim Validated = MyValidation.Validate_NewCategory(CatName.Text, CatDesc.Text, CatKeyw.Text, ListResp)


        If Validated <> "" Then WarnTxt.Text = fn_general_v30.Warn(Validated)
        If Validated <> "" Then Exit Sub

        Dim ParentCatID = ListResp
        Dim MyDataToDB As New fn_db_data
        Dim MyRESP = MyDataToDB.InsertCategory(CatName.Text, CatDesc.Text, CatKeyw.Text, ParentCatID)

        Fill_ListBox()
        WarnTxt.Text = fn_general_v30.Warn(MyRESP)
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

  
        Dim CatID
        If CatList.SelectedIndex = -1 Then CatID = ""
        If CatList.SelectedIndex <> -1 Then CatID = CatList.SelectedItem.Value

        If CatID = "" Then
            WarnTxt.Text = fn_general_v30.Warn("Please select a category!")
            Exit Sub
        End If
   

        Dim MyDataToDB As New fn_db_data
        Dim MyRESP = MyDataToDB.Category_Delete(CatID)

        Fill_ListBox()
        WarnTxt.Text = fn_general_v30.Warn("Category Deleted!")

    End Sub
End Class
