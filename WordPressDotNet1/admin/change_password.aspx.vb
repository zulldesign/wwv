Imports System.Data.OleDb

Partial Class user_sifredegistir
    Inherits System.Web.UI.Page

    Dim DatabaseIsim = "databases/database.mdb"
    Dim DatabaseSifre = "tyg"
    Dim DBPath = Server.MapPath(DatabaseIsim)

    Public UserName, Isim, SifreDogru


    Sub SessionBul()
        If Session("auth") <> "218w2s48df6w8s6df13s2d1f8w6sd" Then
            Response.Redirect("./login.aspx")
        End If

        UserName = Session("user")
        Isim = Session("isim")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = "İİYG PORTAL | Şifre İşlemleri"
        'Button1.Attributes.Add("onclick", "return confirm('Bilgileri kaydetmek istediğinize emin misiniz?');")
        SessionBul()

    End Sub



    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        CheckYap()
    End Sub


    Sub SifreyeBak()
        Dim conn As OleDbConnection
        conn = New OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA SOURCE=" + DBPath & ";Jet OLEDB:Database Password=" & DatabaseSifre & "")

        Dim comm As OleDbCommand
        comm = New OleDbCommand("Select password from users where sicil='" & UserName & "'", conn)
        conn.Open()

        Dim dr As OleDbDataReader
        dr = comm.ExecuteReader

        While dr.Read = True
            If TextBox1.Text = dr.GetValue(0).ToString Then
                SifreDogru = "Evet"
            Else
                SifreDogru = "Hayir"
            End If
        End While
        dr.Close()
        conn.Close()
    End Sub


    Sub CheckYap()
        If TextBox2.Text <> TextBox3.Text Then
            Response.Write("<script>alert('Girdiğiniz şifreler birbirininden farklı, Lütfen tekrar deneyiniz!')</script>")
            Exit Sub
        Else
            SifreyeBak()
            If SifreDogru = "Hayir" Then
                Response.Write("<script>alert('Eski şifrenizi yanlış girdiniz, Lütfen tekrar deneyiniz!')</script>")
                Exit Sub
            ElseIf SifreDogru = "Evet" Then
                Kaydet()
            End If
        End If
    End Sub

    Sub Kaydet()
        Dim Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, Q10, Q11, Q12, Q13, Q14, Q15
        Dim Q16, Q17, Q18, Q19, Q20

        Q1 = Trim(TextBox2.Text)

        Dim ConnString As String = "PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA SOURCE=" + DBPath & ";Jet OLEDB:Database Password=" & DatabaseSifre & ""
        Dim QueryString As String = "Update [users] set [password]= '" & Q1 & "' where sicil='" & UserName & "'"

        Dim CONN As OleDbConnection = New OleDbConnection(ConnString)
        Dim CMD As OleDbCommand = New OleDbCommand(QueryString, CONN)
        CONN.Open()
        CMD.ExecuteNonQuery()
        CONN.Close()

        Response.Write("<script>alert('Şifreniz değiştirildi!')</script>")

 
    End Sub



End Class