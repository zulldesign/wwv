Imports System.Data.OleDb

Partial Class index
    Inherits System.Web.UI.Page

    Dim DatabaseIsim = "../databases/database.mdb"
    Dim DatabaseSifre = "extremeteam"
    Dim DBPath = Server.MapPath(DatabaseIsim)

    Dim ContentTable

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("tr-TR")
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("tr-TR")

        ''####### REDIRECT START ##############
        'Dim HOST = Request.ServerVariables("HTTP_HOST")
        'If Replace(HOST, "holidaychoices.net", "") = HOST Then
        '    Response.Redirect("http://" & HOST)
        'End If
        ''####### REDIRECT END ##############

    End Sub


    Sub SessionBul()

        'If Trim(Request.QueryString("tag")) <> "" Then
        '    MetalariBulveYaz()
        'End If

    End Sub
    'Sub PathYaz()
    '    Dim Port = Request.ServerVariables("SERVER_PORT")
    '    If Port = "" Or Port = "80" Or Port = "443" Then
    '        Port = ""
    '    Else
    '        Port = ":" + Port
    '    End If

    '    Dim Protocol = Request.ServerVariables("SERVER_PORT_SECURE")
    '    If Protocol = "" Or Protocol = "0" Then
    '        Protocol = "http://"
    '    Else
    '        Protocol = "https://"
    '    End If


    '    BasePath = Protocol + Request.ServerVariables("SERVER_NAME") + Port + Request.ApplicationPath

    '    If Right(Trim(BasePath), 1) <> "/" Then
    '        BasePath = BasePath & "/"
    '    End If

    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'PathYaz()
        SessionBul()
        DefaultMetaYaz()

        If Not Page.IsPostBack Then
            'ContentYaz()

        End If


    End Sub


    'Sub ContentYaz()
    '    Dim MyConn, RS, SQL

    '    MyConn = Server.CreateObject("ADODB.Connection")
    '    RS = Server.CreateObject("ADODB.Recordset")
    '    MyConn.Open("PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA SOURCE=" + DBPath & ";Jet OLEDB:Database Password=" & DatabaseSifre & "")

    '    SQL = "SELECT id,	cat_id,	cat_name,	content_title,	content,	author,	content_date,	keywords from content order by content_date DESC"

    '    RS.Open(SQL, MyConn, 1, 3)


    '    TabloString = TabloString & "<table ><tr><td valign='top'>"


    '    Dim SBK = Int(RS.recordcount / 4) 'Sütun başına kayıt


    '    Dim i As Integer, ColumnNumber As Integer
    '    While Not RS.EOF

    '        Dim NormalUlkeAdi = RS.Fields("Country").Value.ToString
    '        TemizUlkeAdi = IsimTemizle(RS.Fields("Country").Value.ToString)
    '        Dim UlkeId = RS.Fields("CountryId").Value.ToString

    '        'Dim Linkimiz = BasePath & "hc/en/destination/" & TemizUlkeAdi & "/" & UlkeId & "/" & UrlWords
    '        Dim Linkimiz = BasePath & "hc/en/destination/" & TemizUlkeAdi & "/" & UlkeId
    '        Linkimiz = Left(Linkimiz, 280)

    '        i = i + 1
    '        If i = SBK Or i = (SBK * 2) Or i = (SBK * 3) Then
    '            ColumnNumber = ColumnNumber + 1
    '            TabloString = TabloString & "</td><td valign='top'><a title='" & NormalUlkeAdi & " Holiday' class='mavituruncu12' href='" & Linkimiz & "'>" & NormalUlkeAdi & "</a><br>"
    '        Else
    '            TabloString = TabloString & "<a title='" & NormalUlkeAdi & " Holiday' class='mavituruncu12' href='" & Linkimiz & "'>" & NormalUlkeAdi & "</a><br>"
    '        End If

    '        RS.MoveNext()

    '    End While

    '    RS.Close()
    '    MyConn.Close()

    '    For i = 1 To ColumnNumber
    '        TabloString = TabloString & "</td>"
    '    Next
    '    TabloString = TabloString & "</tr></table>"
    '    CountriesTxt.Text = TabloString

    'End Sub
    Function IsimTemizle(ByVal KirliAd)
        Dim TemizIsim
        TemizIsim = LCase(KirliAd)
        TemizIsim = Trim(TemizIsim)
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


    'Sub BottomInfoYaz()
    '    Dim conn As OleDbConnection
    '    conn = New OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA SOURCE=" + DBPath & ";Jet OLEDB:Database Password=" & DatabaseSifre & "")

    '    Dim comm As OleDbCommand
    '    comm = New OleDbCommand("SELECT keyw from meta_tags", conn)
    '    conn.Open()

    '    Dim dr As OleDbDataReader
    '    dr = comm.ExecuteReader

    '    Dim BottomString, Kelime() As String
    '    While dr.Read = True
    '        Kelime = dr.GetValue(0).ToString.Split(",")
    '    End While
    '    dr.Close()
    '    conn.Close()

    '    Dim i
    '    For i = 0 To UBound(Kelime)
    '        Dim kelime2 = IsimTemizle(Kelime(i))
    '        'BottomString = BottomString & "<a class='acikgri-koyugri10' href ='http://www.holidaychoices.net/hc/en/tags/" & kelime2 & "'><b>" & Kelime(i) & "</b></a>"
    '        BottomString = BottomString & "<a class='acikgri-koyugri10' href ='http://www.holidaychoices.net/hc/en/search/" & kelime2 & "'><b>" & Kelime(i) & "</b></a>"
    '    Next

    '    BottomInfoTxt.Text = BottomString

    'End Sub





    Sub MetalariYaz()

        'Dim conn As OleDbConnection
        'conn = New OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA SOURCE=" + DBPath & ";Jet OLEDB:Database Password=" & DatabaseSifre & "")

        'Dim comm As OleDbCommand
        'comm = New OleDbCommand("SELECT title,keyw,desc from meta_tags", conn)
        'conn.Open()

        'Dim dr As OleDbDataReader
        'dr = comm.ExecuteReader


        'Dim DefaultTitle, DefaultKeyw, DefaultDesc
        'While dr.Read = True
        '    DefaultTitle = dr.GetValue(0).ToString
        '    DefaultKeyw = dr.GetValue(1).ToString
        '    DefaultDesc = dr.GetValue(2).ToString
        'End While
        'dr.Close()
        'conn.Close()


        'If Trim(Basligimiz) <> "" Then
        '    Me.Title = Basligimiz & DbTitle
        'Else
        '    Me.Title = DbTitle
        'End If


        'If Trim(KeywString) <> "" Then
        '    MetaEkle("keywords", KeywString)
        'Else
        '    KeywString = "holiday rentals, holiday lettings, holiday villas, holiday apartments to rent, apartments to let, vacation accommodation, country cottages, holiday, letting"
        '    MetaEkle("keywords", KeywString)
        'End If


        'If Trim(DescString) <> "" Then
        '    MetaEkle("description", DescString)
        'Else
        '    DescString = "HolidayChoices.net advertises holiday villas, apartments and cottages to rent, let, exchange direct from owners. Rent, Let, Exchange holiday accommodation in Spain, France, Italy, England, Canada, USA, Turkey, Cyprus and other countries worldwide."
        '    MetaEkle("description", DescString)
        'End If

        'MetaEkle("robots", "index, follow, NOODP") 'Open Directory Project'ten almasin bilgileri.

    End Sub


    Sub DefaultMetaYaz()
        Dim Titlemiz, Desc, Keywords

        Dim conn As OleDbConnection
        conn = New OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA SOURCE=" + DBPath & ";Jet OLEDB:Database Password=" & DatabaseSifre & "")

        Dim comm As OleDbCommand
        comm = New OleDbCommand("SELECT meta_title,meta_desc,meta_keyw from portal_conf", conn)
        conn.Open()

        Dim dr As OleDbDataReader
        dr = comm.ExecuteReader


        While dr.Read = True
            Titlemiz = dr.GetValue(0).ToString
            Desc = dr.GetValue(1).ToString
            Keywords = dr.GetValue(2).ToString
        End While
        dr.Close()
        conn.Close()



        Me.Title = Titlemiz
        MetaEkle("description", Desc)
        MetaEkle("keywords", Keywords)

        MetaEkle("robots", "index, follow, NOODP") 'Open Directory Project'ten almasin bilgileri.



    End Sub

    Sub MetaEkle(ByVal meta_adi As String, ByVal meta_icerik As String)

        Dim yenimeta As New HtmlMeta()
        yenimeta.Name = meta_adi
        yenimeta.Content = meta_icerik
        Page.Header.Controls.Add(yenimeta)

    End Sub




End Class
