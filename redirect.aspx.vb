
Partial Class redirect
    Inherits System.Web.UI.Page
    Dim MyDB As New db_acc_v21_data

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Not Page.IsPostBack Then
            WriteTopic()
        End If
    End Sub


    Sub WriteTopic()
        Dim MyPort = Request.ServerVariables("SERVER_PORT") : Dim MySec = Request.ServerVariables("SERVER_PORT_SECURE") : Dim MyServ = Request.ServerVariables("SERVER_NAME") : Dim MyAppPath = Request.ApplicationPath
        Dim BasePath = fn_general_v30.PathYaz(MyPort, MySec, MyServ, MyAppPath)


        Dim TopicId = Request.QueryString("id")

        If IsNumeric(TopicId) Then
            Dim TopicURL As String

            Dim MyDBFromData As New fn_db_data

            TopicURL = MyDBFromData.GetTopicURL(TopicId, BasePath)
            If Trim(TopicURL) = "" Then Response.Redirect("search.aspx")

            Response.Redirect(TopicURL)

        End If


  
    End Sub
End Class
