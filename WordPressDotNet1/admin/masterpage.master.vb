Imports System.Data.OleDb
Partial Class admin_masterpage
    Inherits System.Web.UI.MasterPage

    Dim DatabaseIsim = "../databases/database.mdb"
    Dim DatabaseSifre = "extremeteam"
    Dim DBPath


    Public UserName
    Dim NodeNr As Integer


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("tr-TR")
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("tr-TR")
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SessionBul()

        If Not Page.IsPostBack Then

            KullaniciYaz()


            NodeNr = -1
            If Session("role") = "admin" Then
                AdminMenuYaz()
            End If
            TreeYaz()


 
        End If



    End Sub

    Sub SessionBul()
        UserName = Session("user")
    End Sub

    Sub KullaniciYaz()
        DBPath = Server.MapPath("databases/database.mdb")

        Dim conn As OleDbConnection
        conn = New OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA SOURCE=" + DBPath & ";Jet OLEDB:Database Password=" & DatabaseSifre & "")

        Dim comm As OleDbCommand
        comm = New OleDbCommand("Select [name],surname,[role] from [users] where sicil='" & UserName & "'", conn)
        conn.Open()

        Dim dr As OleDbDataReader
        dr = comm.ExecuteReader

        While dr.Read = True
            KullTxt.Text = "<a class='grisiyah12'>Hoşgeldiniz " & dr.GetValue(0) & " " & dr.GetValue(1) & "</a>, <a class='turuncu12' href='./change_password.aspx'>[Şifre Değiştir]<a class='grisiyah12'> | </a><a class='turuncu12' href='./login.aspx'>[Çıkış Yap]</a></a>"
            Session("role") = dr.GetValue(2).ToString
        End While
        dr.Close()
        conn.Close()

        AnaSayfa.Text = "<a class='turuncu12' href='./index.aspx'>[ Ana Sayfa ]</a>"

    End Sub

    Sub AdminMenuYaz()
        NodeNr = NodeNr + 1
        TreeView1.Nodes.Add(New TreeNode("YÖNETİCİ MENÜSÜ"))
        TreeView1.Nodes(NodeNr).NavigateUrl = "#"
        'TreeView1.Nodes(NodeNr).Collapse()



        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("EXEC. DASHBOARD"))
        TreeView1.Nodes(NodeNr).ChildNodes(0).NavigateUrl = "#"
        TreeView1.Nodes(NodeNr).ChildNodes(0).ChildNodes.Add(New TreeNode("Açık Talepler"))
        TreeView1.Nodes(NodeNr).ChildNodes(0).ChildNodes(0).NavigateUrl = "admin_requests_open.aspx"
        TreeView1.Nodes(NodeNr).ChildNodes(0).ChildNodes.Add(New TreeNode("Kapalı Talepler"))
        TreeView1.Nodes(NodeNr).ChildNodes(0).ChildNodes(1).NavigateUrl = "admin_requests_closed.aspx"
        TreeView1.Nodes(NodeNr).ChildNodes(0).ChildNodes.Add(New TreeNode("Güncellemeler"))
        TreeView1.Nodes(NodeNr).ChildNodes(0).ChildNodes(2).NavigateUrl = "admin_exec_takip.aspx"
        TreeView1.Nodes(NodeNr).ChildNodes(0).ChildNodes.Add(New TreeNode("Tarihsel Kontrol"))
        TreeView1.Nodes(NodeNr).ChildNodes(0).ChildNodes(3).NavigateUrl = "admin_requests_date_control.aspx"

        TreeView1.Nodes(NodeNr).ChildNodes(0).ChildNodes.Add(New TreeNode("ARŞİV"))
        TreeView1.Nodes(NodeNr).ChildNodes(0).ChildNodes(4).NavigateUrl = "#"
        TreeView1.Nodes(NodeNr).ChildNodes(0).ChildNodes(4).ChildNodes.Add(New TreeNode("Arşiv Ara"))
        TreeView1.Nodes(NodeNr).ChildNodes(0).ChildNodes(4).ChildNodes(0).NavigateUrl = "admin_archive_search.aspx"
        TreeView1.Nodes(NodeNr).ChildNodes(0).ChildNodes(4).ChildNodes.Add(New TreeNode("Arşivle"))
        TreeView1.Nodes(NodeNr).ChildNodes(0).ChildNodes(4).ChildNodes(1).NavigateUrl = "admin_archive_create.aspx"

        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("STATÜ RAPORLARI"))
        TreeView1.Nodes(NodeNr).ChildNodes(1).ChildNodes.Add(New TreeNode("Statü Raporları"))
        TreeView1.Nodes(NodeNr).ChildNodes(1).ChildNodes(0).NavigateUrl = "admin_status_reportall.aspx"
        TreeView1.Nodes(NodeNr).ChildNodes(1).ChildNodes.Add(New TreeNode("Tarihsel Kontrol"))
        TreeView1.Nodes(NodeNr).ChildNodes(1).ChildNodes(1).NavigateUrl = "admin_status_date_control.aspx"

        TreeView1.Nodes(NodeNr).ChildNodes(1).ChildNodes.Add(New TreeNode("ARŞİV"))
        TreeView1.Nodes(NodeNr).ChildNodes(1).ChildNodes(2).NavigateUrl = "admin_status_report_archive.aspx"
        'TreeView1.Nodes(NodeNr).ChildNodes(1).ChildNodes.Add(New TreeNode("Statü Rapor Detayları"))
        'TreeView1.Nodes(NodeNr).ChildNodes(1).ChildNodes(1).NavigateUrl = "admin_status_report_details.aspx"


        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("PORTAL AYARLARI"))
        TreeView1.Nodes(NodeNr).ChildNodes(2).NavigateUrl = "#"
        TreeView1.Nodes(NodeNr).ChildNodes(2).Collapse()
        TreeView1.Nodes(NodeNr).ChildNodes(2).ChildNodes.Add(New TreeNode("Sıralama Kriteri"))
        TreeView1.Nodes(NodeNr).ChildNodes(2).ChildNodes(0).NavigateUrl = "admin_orderby.aspx"
        TreeView1.Nodes(NodeNr).ChildNodes(2).ChildNodes.Add(New TreeNode("YEDEKLEME"))
        TreeView1.Nodes(NodeNr).ChildNodes(2).ChildNodes(1).NavigateUrl = "backup_create.aspx"



    End Sub

    Sub TreeYaz()
        NodeNr = NodeNr + 1
        TreeView1.Nodes.Add(New TreeNode("EXECUTIVE DASHBOARD"))
        TreeView1.Nodes(NodeNr).NavigateUrl = "#"
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Açık Talepler"))
        TreeView1.Nodes(NodeNr).ChildNodes(0).NavigateUrl = "project_open.aspx"
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Kapanan Talepler"))
        TreeView1.Nodes(NodeNr).ChildNodes(1).NavigateUrl = "project_closed.aspx"

        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Benim Taleplerim"))
        TreeView1.Nodes(NodeNr).ChildNodes(2).NavigateUrl = "project_mine.aspx"

        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Yeni Talep Ekle"))
        TreeView1.Nodes(NodeNr).ChildNodes(3).NavigateUrl = "project_new.aspx"
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Talep Sil"))
        TreeView1.Nodes(NodeNr).ChildNodes(4).NavigateUrl = "project_del.aspx"

        'TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Proje Bilgilerini Güncelle"))
        'TreeView1.Nodes(NodeNr).ChildNodes(1).NavigateUrl = "project_updateinfo.aspx"



        NodeNr = NodeNr + 1
        TreeView1.Nodes.Add(New TreeNode("STATÜ RAPORLARI"))
        TreeView1.Nodes(NodeNr).NavigateUrl = "#"
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Yeni İş Ekle"))
        TreeView1.Nodes(NodeNr).ChildNodes(0).NavigateUrl = "status_addnew.aspx"
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Üzerimdeki İşler (Düzenle)"))
        TreeView1.Nodes(NodeNr).ChildNodes(1).NavigateUrl = "status_mine.aspx"
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("İş Sil"))
        TreeView1.Nodes(NodeNr).ChildNodes(2).NavigateUrl = "status_del.aspx"
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("STATÜ/İŞ BAZINDA DETAYLAR"))
        TreeView1.Nodes(NodeNr).ChildNodes(3).NavigateUrl = "#"
        TreeView1.Nodes(NodeNr).ChildNodes(3).ChildNodes.Add(New TreeNode("Statü Detayı Ekle"))
        TreeView1.Nodes(NodeNr).ChildNodes(3).ChildNodes(0).NavigateUrl = "status_detail_add.aspx"
        TreeView1.Nodes(NodeNr).ChildNodes(3).ChildNodes.Add(New TreeNode("Statü Detayı Sil"))
        TreeView1.Nodes(NodeNr).ChildNodes(3).ChildNodes(1).NavigateUrl = "status_detail_delete.aspx"


        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("STATÜ RAPORUM"))
        TreeView1.Nodes(NodeNr).ChildNodes(4).NavigateUrl = "status_report_mine.aspx"

        NodeNr = NodeNr + 1
        TreeView1.Nodes.Add(New TreeNode("BİLGİ PAYLAŞIMI"))
        TreeView1.Nodes(NodeNr).NavigateUrl = "#"
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Büyük Projelerle İlgili Bilgiler"))
        TreeView1.Nodes(NodeNr).ChildNodes(0).NavigateUrl = "information_topics.aspx?topic=Proje"
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Küçük Projelerle İlgili Bilgiler"))
        TreeView1.Nodes(NodeNr).ChildNodes(1).NavigateUrl = "information_topics.aspx?topic=Talep"
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Telekom Birimleri Hakkında Bilgiler"))
        TreeView1.Nodes(NodeNr).ChildNodes(2).NavigateUrl = "information_topics.aspx?topic=TelekomBirim"
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Telekom Sistemleri Hakkında Bilgiler"))
        TreeView1.Nodes(NodeNr).ChildNodes(3).NavigateUrl = "information_topics.aspx?topic=TelekomSistem"

        NodeNr = NodeNr + 1
        TreeView1.Nodes.Add(New TreeNode("DOSYA PAYLAŞIMI"))
        TreeView1.Nodes(NodeNr).NavigateUrl = "#"
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Proje Dökümanları"))
        TreeView1.Nodes(NodeNr).ChildNodes(0).NavigateUrl = "#"
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Bilgilendirme Amaçlı Dökümanlar"))
        TreeView1.Nodes(NodeNr).ChildNodes(1).NavigateUrl = "#"

        NodeNr = NodeNr + 1
        TreeView1.Nodes.Add(New TreeNode("MESAJLAR"))
        TreeView1.Nodes(NodeNr).NavigateUrl = "#"
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Mesaj Gönder"))
        TreeView1.Nodes(NodeNr).ChildNodes(0).NavigateUrl = "message_send.aspx"
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Gelen Mesajlar"))
        TreeView1.Nodes(NodeNr).ChildNodes(1).NavigateUrl = "message_inbox.aspx"
        'TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Gönderilmiş Mesajlar"))
        'TreeView1.Nodes(NodeNr).ChildNodes(2).NavigateUrl = "message_sent.aspx"


        NodeNr = NodeNr + 1
        TreeView1.Nodes.Add(New TreeNode("İSTATİSTİKLER"))
        TreeView1.Nodes(NodeNr).NavigateUrl = "#"
        TreeView1.Nodes(NodeNr).Collapse()
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("İstatistikler - 1"))
        TreeView1.Nodes(NodeNr).ChildNodes(0).NavigateUrl = "statistics.aspx"
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("İstatistikler - 2"))
        TreeView1.Nodes(NodeNr).ChildNodes(1).NavigateUrl = "statistics.aspx"

        NodeNr = NodeNr + 1
        TreeView1.Nodes.Add(New TreeNode("KULLANICILAR"))
        TreeView1.Nodes(NodeNr).NavigateUrl = "#"
        TreeView1.Nodes(NodeNr).Collapse()
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Profil Görüntüle"))
        TreeView1.Nodes(NodeNr).ChildNodes(0).NavigateUrl = "members_profile.aspx"
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Doğum Günleri"))
        TreeView1.Nodes(NodeNr).ChildNodes(1).NavigateUrl = "members_birthday.aspx"

        NodeNr = NodeNr + 1
        TreeView1.Nodes.Add(New TreeNode("AYARLAR"))
        TreeView1.Nodes(NodeNr).NavigateUrl = "#"
        TreeView1.Nodes(NodeNr).Collapse()
        TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Şifre Değiştir"))
        TreeView1.Nodes(NodeNr).ChildNodes(0).NavigateUrl = "change_password.aspx"

        'NodeNr = NodeNr + 1
        'TreeView1.Nodes.Add(New TreeNode("S.S.S."))
        'TreeView1.Nodes(NodeNr).NavigateUrl = "#"
        'TreeView1.Nodes(NodeNr).Collapse()
        'TreeView1.Nodes(NodeNr).ChildNodes.Add(New TreeNode("Rules & Regulations"))
        'TreeView1.Nodes(NodeNr).ChildNodes(0).NavigateUrl = "rules_regulations.aspx"

    End Sub






End Class


