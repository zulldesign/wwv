Imports System.Data.OleDb

Partial Class masterpage
    Inherits System.Web.UI.MasterPage


    Dim DatabaseIsim = "databases/database.mdb"
    Dim DatabaseSifre = "extremeteam"
    Dim DBPath




    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        'Lang = Request.QueryString("lang")
        'If Trim(Lang) = "" Then Lang = "tr"



        If Not Page.IsPostBack Then
            PortalInformations()
            WriteTranslations()
            WriteContent()
        End If

        Dim CULTURE As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture(Session("lang_code"))
        'MsgBox(Session("lang_code"))
        System.Threading.Thread.CurrentThread.CurrentCulture = CULTURE
        System.Threading.Thread.CurrentThread.CurrentUICulture = CULTURE



        '      CultureInfo as  culture = 
        '   CultureInfo.CreateSpecificCulture("fr-FR");
        'System.Threading.Thread.CurrentThread.CurrentCulture = 
        '  culture;

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



    End Sub

    Sub PortalInformations()
        DBPath = Server.MapPath("databases/database.mdb")

        Dim conn As OleDbConnection
        conn = New OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA SOURCE=" + DBPath & ";Jet OLEDB:Database Password=" & DatabaseSifre & "")

        Dim comm As OleDbCommand
        comm = New OleDbCommand("Select conf_name,	conf_value from portal_conf ", conn)

        conn.Open()

        Dim dr As OleDbDataReader
        dr = comm.ExecuteReader

        'DropDownList1.Items.Add("")
        While dr.Read = True

            Dim conf_name = dr.GetValue(0).ToString : Dim conf_value = dr.GetValue(1).ToString
            If Replace(conf_name, "portal_title", "") <> conf_name Then
                SiteTitle.Text = "<a class='site_title' href='index.aspx' title=" & conf_value & ">" & conf_value & "</a>"
            ElseIf Replace(conf_name, "portal_subtitle", "") <> conf_name Then
                SiteSubTitle.Text = conf_value
            ElseIf Replace(conf_name, "http_name", "") <> conf_name Then
                Session("http_name") = conf_value
            ElseIf Replace(conf_name, "lang_code", "") <> conf_name Then
                Session("lang_code") = conf_value






            End If


        End While
        dr.Close()
        conn.Close()

    End Sub

    Sub WriteTranslations()

        Dim lang_table

        DBPath = Server.MapPath("databases/database.mdb")

        Dim conn As OleDbConnection, comm As OleDbCommand
        conn = New OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA SOURCE=" + DBPath & ";Jet OLEDB:Database Password=" & DatabaseSifre & "")
        comm = New OleDbCommand("SELECT conf_value from portal_conf where conf_name='lang'", conn)
        conn.Open()


        '####### FIND LANG #############
        Dim dr As OleDbDataReader
        dr = comm.ExecuteReader
        While dr.Read = True
            Session("lang") = dr.GetValue(0).ToString
            lang_table = "translation_" & dr.GetValue(0).ToString
        End While



        '####### WRITE TRANSLATIONS #############
        comm = New OleDbCommand("Select [default], " & lang_table & " from lang_translations ", conn)
        dr = comm.ExecuteReader
        While dr.Read = True


            Dim defaults = dr.GetValue(0).ToString : Dim translation = dr.GetValue(1).ToString
            If Replace(defaults, "tags", "") <> defaults Then
                Session("lang_tags") = translation
            ElseIf Replace(defaults, "tag", "") <> defaults Then
                Session("lang_tag") = translation
            ElseIf Replace(defaults, "categories", "") <> defaults Then
                CatTitle.Text = translation
                Session("lang_categories") = translation
            ElseIf Replace(defaults, "category", "") <> defaults Then
                CatTitle.Text = translation
                Session("lang_category") = translation
            ElseIf Replace(defaults, "adsense1_title", "") <> defaults Then
                'No title yet
            ElseIf Replace(defaults, "adsense2_title", "") <> defaults Then
                Adsense2Title.Text = translation
            ElseIf Replace(defaults, "adsense3_title", "") <> defaults Then
                'No title yet
            ElseIf Replace(defaults, "links", "") <> defaults Then
                LinksTitle.Text = translation
            ElseIf Replace(defaults, "archive", "") <> defaults Then
                ArchiveTitle.Text = translation
            ElseIf Replace(defaults, "next_record", "") <> defaults Then
                Session("lang_next_record") = translation
            ElseIf Replace(defaults, "previous_record", "") <> defaults Then
                Session("lang_previous_record") = translation
            ElseIf Replace(defaults, "no_record", "") <> defaults Then
                Session("lang_no_record") = translation
            ElseIf Replace(defaults, "showing_all_results", "") <> defaults Then
                Session("lang_showing_all_results") = translation
            ElseIf Replace(defaults, "page", "") <> defaults Then
                Session("lang_page") = translation
            ElseIf Replace(defaults, "not_found", "") <> defaults Then
                Session("lang_not_found") = translation
            ElseIf Replace(defaults, "search", "") <> defaults Then
                Session("lang_search") = translation



            End If



        End While
        dr.Close()




        conn.Close()




    End Sub


    Sub WriteContent()
        DBPath = Server.MapPath("databases/database.mdb")

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




