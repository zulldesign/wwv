Imports System.Data.OleDb
Partial Class executive_message_read
    Inherits System.Web.UI.Page

    Dim DatabaseIsim = "databases/database.mdb"
    Dim DatabaseSifre = "tyg"
    Dim DBPath = Server.MapPath(DatabaseIsim)

    Dim MesajId
    Dim UserName, Isim


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SessionBul()
        Me.Title = "ÝÝYG PORTAL | Mesajlar | Mesaj Oku"
        Button1.Attributes.Add("onclick", "return confirm('Mesajý silmek istediðinize emin misiniz?');")

        GeriTxt.Text = "<a href='message_inbox.aspx' class='turuncu12'><-- Mesaj Kutusuna Geri Dön </a>"
    End Sub
    Sub SessionBul()
        If Session("auth") <> "218w2s48df6w8s6df13s2d1f8w6sd" Then
            Response.Redirect("./login.aspx")
        End If

        UserName = Session("user")
        Isim = Session("isim")

        MesajId = Request.QueryString("id")
        If Trim(MesajId) <> "" Then
            MesajOku()
        End If
    End Sub


    Sub MesajOku()

        Dim conn As OleDbConnection
        conn = New OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA SOURCE=" + DBPath & ";Jet OLEDB:Database Password=" & DatabaseSifre & "")

        Dim comm As OleDbCommand
        comm = New OleDbCommand("SELECT mesajlar.id,[users].name,[users].surname,mesajlar.alici,mesajlar.mesaj,mesajlar.tarih,[users].name from mesajlar,[users] where [users.sicil]=mesajlar.gonderen and mesajlar.id = " & MesajId & " order by tarih DESC", conn)
        conn.Open()

        Dim dr As OleDbDataReader
        dr = comm.ExecuteReader


        Dim i As Integer, ColumnNumber As Integer
        While dr.Read = True
            Dim Tarih As DateTime
            Tarih = dr.GetValue(5).ToString
            Dim Gonderen = dr.GetValue(1).ToString & " " & dr.GetValue(2).ToString
            TarihTxt.Text = Tarih.ToString("dd.MM.yyyy ; hh:mm")
            GonderenTxt.Text = Gonderen
            MesajTxt.Text = dr.GetValue(4).ToString

        End While

        dr.Close()
        conn.Close()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Sil()
    End Sub

    Sub Sil()

        Dim ConnString As String = "PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA SOURCE=" + DBPath & ";Jet OLEDB:Database Password=" & DatabaseSifre & ""
        Dim QueryString As String = "DELETE * from mesajlar where [id]=" & MesajId & ""
        Dim CONN As OleDbConnection = New OleDbConnection(ConnString)
        Dim CMD As OleDbCommand = New OleDbCommand(QueryString, CONN)
        CONN.Open()
        CMD.ExecuteNonQuery()
        CONN.Close()

        Response.Redirect ("message_inbox.aspx")

    End Sub
End Class
