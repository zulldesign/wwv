
Partial Class admin_users
    Inherits System.Web.UI.Page




    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then FillData()
    End Sub

    Sub FillData()

        Dim MyDBData As New db_acc_v21_user_data

        Dim TblName = "users"
        Dim ColName = "id,	name,	nick_name,	email,	password,	mobile_no	,role	,resim	,status	,sess,	pref_lang"
        Dim Orderby = "id DESC"
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


    End Sub


    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim MyDB As New db_acc_v21_user_data

        Dim Q(10)

        Dim ArticleId = 1

        Q(1) = "Admin"
     



        Dim TblName = "users"
        Dim ColNames = "[name]"
        Dim ValNames = "'" & Q(1) & "'"
        Dim WhereStr = "[id]=" & ArticleId & ""



        Dim SqlStr = MyDB.DB_UpdateSTR(TblName, ColNames, ValNames, WhereStr)
        MyDB.QueryExecuteNonQuery(SqlStr)

   
    End Sub
End Class
