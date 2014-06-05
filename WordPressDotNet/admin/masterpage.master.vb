
Partial Class admin_masterpage
    Inherits System.Web.UI.MasterPage

    Dim NodeNr As Integer


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("tr-TR")
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("tr-TR")
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            WriteTree()
        End If

    End Sub
   

    Sub WriteTree()

        NodeNr = 0
        TreeView1.Nodes.Add(New TreeNode("CATEGORIES"))
        TreeView1.Nodes(NodeNr).NavigateUrl = "categories.aspx"

        NodeNr = NodeNr + 1
        TreeView1.Nodes.Add(New TreeNode("ARTICLES"))
        TreeView1.Nodes(NodeNr).NavigateUrl = "#"
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Add Article"))
        TreeView1.Nodes(NodeNr).ChildNodes(0).NavigateUrl = "article_add.aspx"
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Modify Article"))
        TreeView1.Nodes(NodeNr).ChildNodes(1).NavigateUrl = "article_modify.aspx"
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Delete Article"))
        TreeView1.Nodes(NodeNr).ChildNodes(2).NavigateUrl = "article_delete.aspx"
        
        NodeNr = NodeNr + 1
        TreeView1.Nodes.Add(New TreeNode("PORTAL CONFIG"))
        TreeView1.Nodes(NodeNr).NavigateUrl = "#"
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Portal Settings"))
        TreeView1.Nodes(NodeNr).ChildNodes(0).NavigateUrl = "portal_settings.aspx"


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






End Class


