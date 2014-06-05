
Partial Class admin_test
    Inherits System.Web.UI.Page



    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'MsgBox(wpdn_v10.UserImgPath)
        'MsgBox(System.IO.Path.GetExtension("alsdjfşasdj.txt"))


        'Dim MyDB As New fn_db_userdata
        'Dim myresp = MyDB.SaveEmptyArticleAndGetTempArticleID("1")
        'MsgBox(myresp)


        'MsgBox(s)


        'Dim MyFNfromDBUserData As New fn_db_userdata_from

        'Dim ArticleID = MyFNfromDBUserData.Get_ArticleID_ByDate("04.05.2012 10:56:52")
        'MsgBox(ArticleID)

    End Sub





    Public Sub UploadComplete_CUST(ByVal sender As Object, ByVal e As AjaxControlToolkit.AsyncFileUploadEventArgs)
        MsgBox("nber")

    End Sub

    Function GetImageTable(ByVal ImgName)

        Dim STR As New StringBuilder

        STR.AppendLine("	<table cellspacing='5px' style=' width: 100%'>")
        STR.AppendLine("		<tr>")
        STR.AppendLine("			<td class=' pic_box '><img class='pic_box_img' src='http://resim.bilgiustam.info/uploads/1346-vao.png'  /></td>")
        STR.AppendLine("		</tr>")
        STR.AppendLine("	</table>")
        STR.AppendLine("naber")

        Return STR.ToString
    End Function

    Protected Sub AsyncFileUpload1_UploadedComplete1(ByVal sender As Object, ByVal e As AjaxControlToolkit.AsyncFileUploadEventArgs) Handles AsyncFileUpload1.UploadedComplete

        System.Threading.Thread.Sleep(1000)
        If AsyncFileUpload1.HasFile Then

            Dim Prefix = fn_general_v30.Session_GetID(16)
            Dim MyExt = fn_general_v30.File_GetExtension(AsyncFileUpload1.FileName)
            Dim MyFileName = Prefix & MyExt

            Dim SavePath As String = wpdn_v10.UserImgPath & MyFileName
            AsyncFileUpload1.SaveAs(SavePath)





        End If

    End Sub



    Protected Sub btnShowUploadResult_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowUploadResult.Click



        ResTxt.Text = Session("ss")
        'MsgBox("naber")
    End Sub
End Class
