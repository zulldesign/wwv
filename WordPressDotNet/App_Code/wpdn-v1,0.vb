Imports Microsoft.VisualBasic

Public Class wpdn_v10


    Public Const FCKPath = "fckeditor/" 'local
    Public Const FCKSessionUserFilesPath = "~/userfiles/" 'local
    Public Const FCKImageBrowserURL = "editor/filemanager/browser/default/browser.html?Type=Image&Connector="
    'Public Const FCKPath = "scripts/fckeditor/"
    'Public Const FCKSessionUserFilesPath = "~/cubuk-tursusu/userfiles/"
    'Public Const FCKImageBrowserURL = "editor/filemanager/browser/default/browser.aspx?Type=Image&Connector="

    Public Const FCKConnectorPath = "editor/filemanager/connectors/aspx/connector.aspx"
    Public Const FCKID = "dynamicname"
    Public Const FCKSkinPath = "skins/silver/"
    Public Const FCKToolbarSet = "Serkan" 'Basic | Default | Serkan





    Public Shared Function FCKPathYaz(ByVal Port1, ByVal Protocol1, ByVal ServerName1, ByVal AppPath)
        'USAGE ####
        'PathYaz (Request.ServerVariables("SERVER_PORT"),Request.ServerVariables("SERVER_PORT_SECURE"),Request.ServerVariables("SERVER_NAME"),Request.ApplicationPath)
        Dim Port = Port1
        Dim Protocol = Protocol1
        Dim ServerName = ServerName1
        Dim BasePath

        If Port = "" Or Port = "80" Or Port = "443" Then
            Port = ""
        Else
            Port = ":" + Port
        End If
        If Protocol = "" Or Protocol = "0" Then
            Protocol = "http://"
        Else
            Protocol = "https://"
        End If

        BasePath = Protocol + ServerName + Port + AppPath

        If Right(Trim(BasePath), 1) <> "/" Then
            BasePath = BasePath & "/"
        End If
        Return BasePath & FCKPath
    End Function

End Class
