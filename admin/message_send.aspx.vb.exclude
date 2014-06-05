Imports System.Data.OleDb
Partial Class executive_message_send
    Inherits System.Web.UI.Page

    Dim DatabaseIsim = "databases/database.mdb"
    Dim DatabaseSifre = "tyg"
    Dim DBPath = Server.MapPath(DatabaseIsim)

    Dim UserName, Isim

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("tr-TR")
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("tr-TR")
    End Sub
    Sub SessionBul()
        If Session("auth") <> "218w2s48df6w8s6df13s2d1f8w6sd" Then
            Response.Redirect("./login.aspx")
        End If

        UserName = Session("user")
        Isim = Session("isim")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SessionBul()
        Me.Title = "İİYG PORTAL | Mesajlar | Mesaj Gönder"

        Button1.Attributes.Add("onclick", "return confirm('Mesajı göndermek istediğinize emin misiniz?');")

        If Not Page.IsPostBack Then
            IsimDoldur()
        End If

    End Sub



    Sub IsimDoldur()
        Dim conn As OleDbConnection
        conn = New OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA SOURCE=" + DBPath & ";Jet OLEDB:Database Password=" & DatabaseSifre & "")

        Dim comm As OleDbCommand
        comm = New OleDbCommand("SELECT sicil,[name],surname,email from [users]  order by [name] ASC", conn)
        conn.Open()

        Dim dr As OleDbDataReader
        dr = comm.ExecuteReader


        Dim i As Integer, ColumnNumber As Integer
        While dr.Read = True
            Dim s As New ListItem
            s.Value = dr.GetValue(0).ToString
            s.Text = dr.GetValue(1).ToString & " " & dr.GetValue(2).ToString
            DropDownList1.Items.Add(s)
        End While

        dr.Close()
        conn.Close()



    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Gonder()
    End Sub

    Public Sub TexleriDuzenle(ByVal root As Control)
        For Each ctrl As Control In root.Controls
            TexleriDuzenle(ctrl)
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Text = Replace(CType(ctrl, TextBox).Text, "'", "´")
                CType(ctrl, TextBox).Text = Trim(CType(ctrl, TextBox).Text)
            End If
        Next ctrl
    End Sub

    Sub Gonder()
        TexleriDuzenle(Me)
        Dim Q0, Q1, Q2
        Dim Q3

        Q0 = username
        Q1 = DropDownList1.SelectedItem.Value
        Q2 = TextBox1.Text
        Q3 = "#" & DateTime.Now.ToString("yyyy-MM-dd hh:mm:ssss") & "#"

        Dim ConnString As String = "PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA SOURCE=" + DBPath & ";Jet OLEDB:Database Password=" & DatabaseSifre & ""
        Dim QueryString As String = "Insert into mesajlar (gonderen,alici,mesaj,tarih) Values ('" + Q0 + "','" + Q1 + "','" + Q2 + "'," + Q3 + ")"

        Dim CONN As OleDbConnection = New OleDbConnection(ConnString)
        Dim CMD As OleDbCommand = New OleDbCommand(QueryString, CONN)
        CONN.Open()
        CMD.ExecuteNonQuery()
        CONN.Close()


        TextBox1.Text = ""
        Label1.Text = "Mesaj Gönderildi!"

    End Sub
End Class

