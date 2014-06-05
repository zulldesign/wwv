﻿
Partial Class admin_masterpage2
    Inherits System.Web.UI.MasterPage



    Dim NodeNr As Integer


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("tr-TR")
        'System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("tr-TR")

        CheckSessions()


    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Server.ScriptTimeout = "3600"

        CheckSessions()
        If Not Page.IsPostBack Then
            WriteTree()
        End If

    End Sub
    Sub CheckSessions()


        Dim MySess = Request.QueryString("sess")

        MsgBox("ses" & MySess) 'hata burda, modül içerisindeki button postback yapınca boş geliyo.. 
        'If MySess = "" Then Response.Redirect("login.aspx")


        If Session("logged") = "" Then
            Dim MyDataFromDB As New fn_db_userdata
            Dim MyRESP As New class_decl_v10.UserDetails
            MyRESP = MyDataFromDB.Get_User_Info(, , MySess)

            If Trim(MyRESP.MyName) = "" Then

                Response.Redirect("login.aspx")
            Else
                Session("logged") = "yes"
                Session("user_id") = MyRESP.MyID
                Session("user_name") = MyRESP.MyName
                Session("user_email") = MyRESP.MyEmail
                Session("user_role") = MyRESP.MyRole
                Session("user_sess") = MyRESP.MySess
                Session("user_sess_url") = "?sess=" & Session("user_sess")

                UserTxt.Text = "Welcome back, " & Session("user_name")
            End If
        End If






    End Sub

    Sub WriteTree()


        Dim MySessURL = Session("sess")

        NodeNr = 0
        TreeView1.Nodes.Add(New TreeNode("CATEGORIES"))
        TreeView1.Nodes(NodeNr).NavigateUrl = "categories.aspx" & MySessURL

        NodeNr = NodeNr + 1
        TreeView1.Nodes.Add(New TreeNode("ARTICLES"))
        TreeView1.Nodes(NodeNr).NavigateUrl = "#"
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Add Article"))
        TreeView1.Nodes(NodeNr).ChildNodes(0).NavigateUrl = "article.aspx" & MySessURL
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("My Articles"))
        TreeView1.Nodes(NodeNr).ChildNodes(1).NavigateUrl = "article_my.aspx" & MySessURL

        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("My Earnings"))
        TreeView1.Nodes(NodeNr).ChildNodes(2).NavigateUrl = "my_earnings.aspx" & MySessURL

        If Session("user_role") = "superadmin" Then
            NodeNr = NodeNr + 1
            TreeView1.Nodes.Add(New TreeNode("PORTAL CONFIG"))
            TreeView1.Nodes(NodeNr).NavigateUrl = "#"
            TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Portal Settings"))
            TreeView1.Nodes(NodeNr).ChildNodes(0).NavigateUrl = "portal_settings.aspx" & MySessURL
            TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Languages"))
            TreeView1.Nodes(NodeNr).ChildNodes(1).NavigateUrl = "languages.aspx" & MySessURL
            TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Links"))
            TreeView1.Nodes(NodeNr).ChildNodes(2).NavigateUrl = "links.aspx" & MySessURL

            'NodeNr = NodeNr + 1
            'TreeView1.Nodes.Add(New TreeNode("VALIDATE"))
            'TreeView1.Nodes(NodeNr).NavigateUrl = "#"
            'TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("CheckDuplicate"))
            'TreeView1.Nodes(NodeNr).ChildNodes(0).NavigateUrl = "check_duplicate.aspx" & MySessURL

            NodeNr = NodeNr + 1
            TreeView1.Nodes.Add(New TreeNode("USERS"))
            TreeView1.Nodes(NodeNr).NavigateUrl = "#"
            TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Add User"))
            TreeView1.Nodes(NodeNr).ChildNodes(0).NavigateUrl = "user_add.aspx" & MySessURL
            TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Remove User"))
            TreeView1.Nodes(NodeNr).ChildNodes(1).NavigateUrl = "user_remove.aspx" & MySessURL
        End If




        'NodeNr = NodeNr + 1
        'TreeView1.Nodes.Add(New TreeNode("STATÜ RAPORLARI"))
        'TreeView1.Nodes(NodeNr).NavigateUrl = "#"
        'TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Yeni İş Ekle"))
        'TreeView1.Nodes(NodeNr).ChildNodes(0).NavigateUrl = "status_addnew.aspx"
        'TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Üzerimdeki İşler (Düzenle)"))
        'TreeView1.Nodes(NodeNr).ChildNodes(1).NavigateUrl = "status_mine.aspx"
        'TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("İş Sil"))
        'TreeView1.Nodes(NodeNr).ChildNodes(2).NavigateUrl = "status_del.aspx"
        'TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("STATÜ/İŞ BAZINDA DETAYLAR"))
        'TreeView1.Nodes(NodeNr).ChildNodes(3).NavigateUrl = "#"
        'TreeView1.Nodes(NodeNr).ChildNodes(3).ChildNodes.Add(New TreeNode("Statü Detayı Ekle"))
        'TreeView1.Nodes(NodeNr).ChildNodes(3).ChildNodes(0).NavigateUrl = "status_detail_add.aspx"
        'TreeView1.Nodes(NodeNr).ChildNodes(3).ChildNodes.Add(New TreeNode("Statü Detayı Sil"))
        'TreeView1.Nodes(NodeNr).ChildNodes(3).ChildNodes(1).NavigateUrl = "status_detail_delete.aspx"



    End Sub




    'Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

    '    Session("session_ping") = DateTime.Now.ToString
    '    Label1.Text = "session last updated at: " & DateTime.Now.ToString
    '    'Response.Redirect("index.aspx")
    'End Sub

End Class


