
Partial Class admin_test3
    Inherits System.Web.UI.Page





    Protected Sub SaveBtn_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles SaveBtn2.Click
        MsgBox("naber")
    End Sub

    Protected Sub AsyncFileUpload1_UploadedComplete1(ByVal sender As Object, ByVal e As AjaxControlToolkit.AsyncFileUploadEventArgs) Handles AsyncFileUpload1.UploadedComplete

        System.Threading.Thread.Sleep(1000)
        If AsyncFileUpload1.HasFile Then

            Dim Prefix = fn_general_v30.Session_GetID(16)
            Dim MyExt = fn_general_v30.File_GetExtension(AsyncFileUpload1.FileName)
            Dim MyPicName = Prefix & MyExt

            Dim SavePath As String = wpdn_v10.UserImgPath & MyPicName
            AsyncFileUpload1.SaveAs(SavePath)


        End If

    End Sub
End Class
