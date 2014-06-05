
Partial Class modules_file_upload
    Inherits System.Web.UI.UserControl






    Protected Sub AsyncFileUpload1_UploadedComplete1(ByVal sender As Object, ByVal e As AjaxControlToolkit.AsyncFileUploadEventArgs) Handles AsyncFileUpload1.UploadedComplete


        If AsyncFileUpload1.HasFile Then
            System.Threading.Thread.Sleep(1000)

            Dim Prefix = fn_general_v30.Session_GetID(16)
            Dim MyExt = fn_general_v30.File_GetExtension(AsyncFileUpload1.FileName)
            Dim MyFileName = Prefix & MyExt

            Dim SavePath As String = wpdn_v10.UserImgPath & MyFileName
            AsyncFileUpload1.SaveAs(SavePath)



            'Dim TempArticleID = CheckForTempArticleID()
            'MsgBox(TempArticleID)
            'SaveImg(AsyncFileUpload1.FileName, "sdf")


        End If

    End Sub


    Function CheckForTempArticleID()

        Dim UserID = Session("user_id")
        Dim TempArticleID = Request.QueryString("tmpid")
        If TempArticleID = "" Then
            Dim MyDB As New fn_db_userdata
            TempArticleID = MyDB.InsertTempArticleAndReturnTempID(UserID, DateTime.Now)
        End If

        Return TempArticleID
    End Function
    Sub SaveImg(FileNamez As String, TempArticleID As String)

        System.Threading.Thread.Sleep(1000)

        Dim Prefix = fn_general_v30.Session_GetID(16)
        Dim MyExt = fn_general_v30.File_GetExtension(FileNamez)
        Dim MyFileName = Prefix & MyExt

        Dim SavePath As String = wpdn_v10.UserImgPath & MyFileName
        AsyncFileUpload1.SaveAs(SavePath)


        Dim MyDB As New fn_db_userdata
        MyDB.InsertImgToDB(TempArticleID, MyFileName)

    End Sub

    Protected Sub btnShowUploadResult_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowUploadResult.Click



        'ResTxt.Text = Session("ss")
        MsgBox(Request.QueryString("aid"))
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


End Class
