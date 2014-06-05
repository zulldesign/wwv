
Partial Class admin_articles
    Inherits System.Web.UI.Page






    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then FillData()
    End Sub

    Sub FillData()

        Dim MyDBData As New db_acc_v21_data

        Dim TblName = "content"
        Dim ColName = "id,content_title"
        Dim Orderby = "content_title ASC"
        Dim SqlStr = MyDBData.DB_SelectSTR(TblName, ColName, , Orderby)

        Dim DT As System.Data.DataTable
        DT = MyDBData.QueryDataTable(SqlStr)


        Dim MySTR = "", i
        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        If KS > 0 Then
            For i = 0 To KS - 1
                Dim CatID = DT.Rows(i)("id")
                Dim CatName = DT.Rows(i).Item(1).ToString()
           

                ListBox1.Items.Add(CatName)

                'AltKatYaz(CatID)
            Next
        End If

        Label1.Text = KS.ToString & " Adet makale eklendi!"
    End Sub
End Class
