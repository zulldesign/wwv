Imports db_acc_wpdn_v15
Imports fn_general_v17

Partial Class test
    Inherits System.Web.UI.Page




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WriteTopic()
    End Sub

    Sub WriteTopic()

        Dim TopicId = Request.QueryString("id")


        Dim TblName = "categories"
        'Dim ColName = "id,content_title,content,author,content_date,keywords,categories"
        'Dim TblName = "content,categories"
        'Dim WhereStr = "id=" & TopicId & " "
        Dim ColName = "TOP 5 cat_name"



        Dim DR As System.Data.OleDb.OleDbDataReader
        DR = DB_SELECT(TblName, ColName)




        While dr.Read = True
            Response.Write(DR.GetValue(0).ToString & "<br>")
        End While




    End Sub
End Class
