﻿Imports System.Data.OleDb

Partial Class executive_message_inbox
    Inherits System.Web.UI.Page

    Dim TabloString

    Dim DatabaseIsim = "databases/database.mdb"
    Dim DatabaseSifre = "tyg"
    Dim DBPath = Server.MapPath(DatabaseIsim)

    Dim UserName, Isim

    Sub SessionBul()
        If Session("auth") <> "218w2s48df6w8s6df13s2d1f8w6sd" Then
            Response.Redirect("./login.aspx")
        End If

        UserName = Session("user")
        Isim = Session("isim")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = "İİYG PORTAL | Mesajlar | Gelen Mesajlar"
        SessionBul()
        If Not Page.IsPostBack Then
            MesajlariYaz()
        End If
    End Sub

    Sub MesajlariYaz()

        Dim conn As OleDbConnection
        conn = New OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA SOURCE=" + DBPath & ";Jet OLEDB:Database Password=" & DatabaseSifre & "")

        Dim comm As OleDbCommand
        comm = New OleDbCommand("SELECT mesajlar.id,[users].name,[users].surname,mesajlar.alici,mesajlar.mesaj,mesajlar.tarih,[users].name from mesajlar,[users] where mesajlar.alici='" & UserName & "' and [users.sicil]=mesajlar.gonderen order by tarih DESC", conn)
        conn.Open()

        Dim dr As OleDbDataReader
        dr = comm.ExecuteReader


        TabloBaslangic()

        Dim i As Integer, ColumnNumber As Integer
        While dr.Read = True
            Dim Tarih As DateTime
            Tarih = dr.GetValue(5).ToString
            Dim Gonderen = dr.GetValue(1).ToString & " " & dr.GetValue(2).ToString
            TabloDataYaz(Tarih.ToString("dd.MM.yyyy ; hh:mm"), Gonderen, Left(dr.GetValue(4).ToString, 100), dr.GetValue(0).ToString)

        End While

        dr.Close()
        conn.Close()



        TabloBitis()
    End Sub

    Sub TabloBaslangic()
        TabloString = "<table style='border-collapse:collapse; width: 700px; background-color: #EFEFEF' cellspacing='0' cellpadding='0' class='style1'>"
        TabloString = TabloString & "<tr bgcolor='#C0C0C0'>"
        TabloString = TabloString & "<td  style='width:150px;border-style: dotted; border-width: 1px;border-color:#999999;'>"
        TabloString = TabloString & "<b>Tarih:</b></td>"
        TabloString = TabloString & "<td  style='width:200px;border-style: dotted; border-width: 1px;border-color:#999999;'>"
        TabloString = TabloString & "<b>Gönderen:</b></td>"
        TabloString = TabloString & "<td style='border-style: dotted; border-width: 1px;border-color:#999999;'>"
        TabloString = TabloString & "<b>Konu:</b></td>"
        TabloString = TabloString & "<td style='border-style: dotted; border-width: 1px;border-color:#999999;'>"
        TabloString = TabloString & "</td>"
        TabloString = TabloString & "</tr>"
    End Sub

    Sub TabloDataYaz(ByVal tarih, ByVal gonderen, ByVal konu, ByVal mesajid)

        TabloString = TabloString & "<tr onclick=location.href='message_read.aspx?id=" & mesajid & "' onmouseover = this.bgColor='#FF9900' onmouseout = this.bgColor='#EFEFEF' >"
        TabloString = TabloString & "<td  style='border-style: dotted; border-width: 1px;border-color:#999999;'>"
        TabloString = TabloString & tarih & "</td>"
        TabloString = TabloString & "<td  style='border-style: dotted; border-width: 1px;border-color:#999999;'>"
        TabloString = TabloString & gonderen & "</td>"
        TabloString = TabloString & "<td style='border-style: dotted; border-width: 1px;border-color:#999999;'>"
        TabloString = TabloString & konu & "</td>"
        TabloString = TabloString & "<td style='border-style: dotted; border-width: 1px;border-color:#999999;'>"
        TabloString = TabloString & "</td>"
        TabloString = TabloString & "</tr>"

    End Sub

    Sub TabloBitis()
        TabloString = TabloString & "</table>"
        MesajlarTxt.Text = TabloString
    End Sub


End Class
