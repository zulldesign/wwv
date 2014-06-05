Imports Microsoft.VisualBasic

Public Class db_structure_v10
    Dim MyDBConf As New db_acc_v21_data

    Public Class Tbl_Users
       

        Public ColCount As Integer = 3

        Dim MyCols As String = "id,name,resim"
        Public Controlz() As String = MyCols.ToString.Split(",")




    End Class


    Public Function FindTag(ByVal TagID)
        'Dim MyRESP As New db_structure_v10.Tbl_Users

        'Dim TblName = "content_keywords"
        'Dim ColName = "id,article_id,keyw"
        'Dim WhereSTR = "id=" & TagID & ""

        'Dim SqlStr = MyDBConf.DB_SelectSTR(TblName, ColName, WhereSTR)
        'Dim DT As System.Data.DataTable
        'DT = MyDBConf.QueryDataTable(SqlStr)

        'Dim KS = DT.Rows.Count 'Kayıt Sayısı
        'If KS > 0 Then MyRESP = DT.Rows(0).Item(2).ToString()

        'Return MyRESP
    End Function
End Class
