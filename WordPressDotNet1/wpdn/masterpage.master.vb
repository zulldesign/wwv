Imports System.Data.OleDb

Partial Class masterpage
    Inherits System.Web.UI.MasterPage


    Dim DatabaseIsim = "../databases/database.mdb"
    Dim DatabaseSifre = "extremeteam"
    Dim DBPath



    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("tr-TR")
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("tr-TR")

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            PortalInformations()
            WriteContent()
        End If


    End Sub

    Sub PortalInformations()
        DBPath = Server.MapPath("../databases/database.mdb")

        Dim conn As OleDbConnection
        conn = New OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA SOURCE=" + DBPath & ";Jet OLEDB:Database Password=" & DatabaseSifre & "")

        Dim comm As OleDbCommand
        comm = New OleDbCommand("Select title,	subtitle,	lang_categories,	lang_adsense1,	lang_adsense2,	lang_adsense3,	lang_links,	lang_archive from portal_conf ", conn)
        'omm = New OleDbCommand("Select 0itle,	1ubtitle,	2ang_categories,	3ang_adsense1,	4ang_adsense2,	5ang_adsense3,	6ang_links,	7ang_archive from portal_conf ", conn)
        conn.Open()

        Dim dr As OleDbDataReader
        dr = comm.ExecuteReader

        'DropDownList1.Items.Add("")
        While dr.Read = True
            SiteTitle.Text = dr.GetValue(0).ToString
            SiteSubTitle.Text = dr.GetValue(1).ToString
            CatTitle.Text = dr.GetValue(2).ToString
            Adsense2Title.Text = dr.GetValue(4).ToString
            ArchiveTitle.Text = dr.GetValue(7).ToString
            LinksTitle.Text = dr.GetValue(6).ToString

        End While
        dr.Close()
        conn.Close()

    End Sub

    Sub WriteContent()
        DBPath = Server.MapPath("../databases/database.mdb")

        '####### CATEGORIES #############
        Dim conn As OleDbConnection
        conn = New OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA SOURCE=" + DBPath & ";Jet OLEDB:Database Password=" & DatabaseSifre & "")

        Dim comm As OleDbCommand
        comm = New OleDbCommand("Select id,cat_name from categories ", conn)
        conn.Open()

        Dim dr As OleDbDataReader
        dr = comm.ExecuteReader
        While dr.Read = True
            CatTxt.Text = CatTxt.Text & "<a class='read_more' href='categories.aspx?cat_id=" & dr.GetValue(0).ToString & "' title='" & dr.GetValue(1).ToString & "'>" & dr.GetValue(1).ToString & "</a><br />"
        End While
        dr.Close()


        '####### LINKS #############
        comm = New OleDbCommand("Select id,link_name,http from links ", conn)
        dr = comm.ExecuteReader
        While dr.Read = True
            Dim link = dr.GetValue(2).ToString : Dim linkname = dr.GetValue(1).ToString
            If Replace(link, "http://", "") = link Then
                link = "http://" & link
            End If
            LinksTxt.Text = LinksTxt.Text & "<a class='read_more' href='" & link & "' title='" & linkname & "' target='_blank' >" & linkname & "</a><br />"
        End While
        dr.Close()

        '####### ARCHIVE #############
        comm = New OleDbCommand("Select distinct(content_date) from content order by content_date DESC", conn)
        dr = comm.ExecuteReader
        Dim Dates
        While dr.Read = True
            Dim sDate As Date, s
            sDate = dr.GetValue(0).ToString
            s = sDate.ToString("yyyy MMM")
            If Replace(Dates, s, "") = Dates Then
                Dates = Dates & "<a class='read_more' href='archive.aspx?date=" & ClearText(s) & "' title='" & s & "' >" & s & "<br />"
            End If
            ArchiveTxt.Text = Dates
        End While
        dr.Close()



        conn.Close()
    End Sub

    Function ClearText(ByVal DirtyText)
        Dim TemizIsim
        TemizIsim = LCase(DirtyText)
        TemizIsim = Replace(TemizIsim, " ", "-")
        TemizIsim = Replace(TemizIsim, ";", "")
        TemizIsim = Replace(TemizIsim, ".", "")
        TemizIsim = Replace(TemizIsim, ",", "")
        TemizIsim = Replace(TemizIsim, "'", "-")
        TemizIsim = Replace(TemizIsim, "(", "")
        TemizIsim = Replace(TemizIsim, ")", "")

        TemizIsim = Replace(TemizIsim, "é", "e")
        TemizIsim = Replace(TemizIsim, "ã", "a")
        TemizIsim = Replace(TemizIsim, "í", "i")
        TemizIsim = Replace(TemizIsim, "ä", "a")
        TemizIsim = Replace(TemizIsim, "ü", "u")
        TemizIsim = Replace(TemizIsim, "ş", "s")
        TemizIsim = Replace(TemizIsim, "ı", "i")
        TemizIsim = Replace(TemizIsim, "ğ", "g")
        TemizIsim = Replace(TemizIsim, "ö", "o")
        TemizIsim = Replace(TemizIsim, "ñ", "n")

        Return TemizIsim
    End Function

End Class




