<%@ WebHandler Language="VB" Class="FileUpload" %>

Imports System
Imports System.Web

Public Class FileUpload : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        If context.Request.Files.Count > 0 Then
            
            For a As Integer = 0 To context.Request.Files.Count - 1

                Dim file As HttpPostedFile = context.Request.Files(a)


                Dim Prefix = fn_general_v30.Session_GetID(16)
                Dim MyExt = fn_general_v30.File_GetExtension(file.FileName)
                Dim MyPicName = Prefix & MyExt

                'msgbox(wpdn_v10.UserImgPath & file.FileName)
                file.SaveAs( wpdn_v10.UserImgPath & MyPicName)

            Next
        End If
        
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class