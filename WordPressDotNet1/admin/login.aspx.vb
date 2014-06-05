Imports System.Data.OleDb

Partial Class executive_login
    Inherits System.Web.UI.Page


    Dim DatabaseIsim = "databases/database.mdb"
    Dim DatabaseSifre = "tyg"
    Dim DBPath = Server.MapPath(DatabaseIsim)

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        KullaniciBul()
    End Sub

    Sub KullaniciBul()
        Dim conn As OleDbConnection
        conn = New OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA SOURCE=" + DBPath & ";Jet OLEDB:Database Password=" & DatabaseSifre & "")

        Dim comm As OleDbCommand
        comm = New OleDbCommand("SELECT sicil,[password],[name],surname,resim from users", conn)

        conn.Open()

        Dim dr As OleDbDataReader
        dr = comm.ExecuteReader

        Dim Kullanici, Sifre, Isim
        Dim i As Integer, ColumnNumber As Integer
        While dr.Read = True
            Kullanici = dr.GetValue(0).ToString
            Sifre = dr.GetValue(1).ToString
            Isim = dr.GetValue(2).ToString & " " & dr.GetValue(3).ToString
            If Kullanici = TextBox1.Text And Sifre = TextBox2.Text Then
                Session("auth") = "218w2s48df6w8s6df13s2d1f8w6sd"
                Session("user") = Kullanici
                Session("isim") = Isim
                If Trim(dr.GetValue(4).ToString) = "" Then
                    Session("resim") = "images/resimler/resimyok.gif"
                Else
                    Session("resim") = dr.GetValue(4).ToString
                End If

                dr.Close()
                conn.Close()

                If Session("LastURL") = "" Then
                    Response.Redirect("./index.aspx")
                Else
                    Response.Redirect(Session("LastURL"))
                End If
            End If
        End While

        dr.Close()
        conn.Close()

        Label1.Text = "<a><font color='#FF0000'><b>Kullanıcı adı veya şifre yanlış!</b></font></a>"

    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = "İİYG PORTAL | Login"
    End Sub


End Class
