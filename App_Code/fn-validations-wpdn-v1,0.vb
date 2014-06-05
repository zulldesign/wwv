Imports Microsoft.VisualBasic

Public Class fn_validations_wpdn_v10

    Public Function Validate_NewCategory(ByVal NameTxt, ByVal DescTxt, ByVal KeywTxt, ByVal CategoryID)
        Dim MyRESP As String = ""

        If Trim(NameTxt) = "" Then MyRESP = "Please enter valid Name. <br />"
        If Trim(DescTxt) = "" Then MyRESP = MyRESP & "Please enter valid Description.<br />" & vbCrLf
        If Trim(KeywTxt) = "" Then MyRESP = MyRESP & "Please enter valid Keywords.<br />" & vbCrLf

        If Trim(CategoryID) = "" Or Not IsNumeric(Trim(CategoryID)) Then MyRESP = MyRESP & "Please select valid Category.<br />" & vbCrLf

        'Dim MyDataFromDB As New fn_from_db_wpdn_10
        'Dim MyID = MyDataFromDB.Get_ArticleID_ByDate(DateTxt)
        'If Trim(MyID) <> "" Then MyRESP = MyRESP & "You already have an article with this date.<br />" & vbCrLf

        Return MyRESP
    End Function

    Public Function Validate_NewArticle(ByVal TitleTxt, ByVal ContentTxt, ByVal KeywordsTxt, ByVal AuthorTxt, ByVal DateTxt, ByVal CategoryID)
        Dim MyRESP As String = ""

        If Trim(TitleTxt) = "" Then MyRESP = "Please enter valid Title. <br />"

        If Trim(ContentTxt) = "" Then MyRESP = MyRESP & "Please enter valid Content.<br />" & vbCrLf
        If Trim(KeywordsTxt) = "" Then MyRESP = MyRESP & "Please enter valid Keywords.<br />" & vbCrLf
        If Trim(AuthorTxt) = "" Then MyRESP = MyRESP & "Please enter valid Author.<br />" & vbCrLf
        If Trim(DateTxt) = "" Then MyRESP = MyRESP & "Please enter valid Date.<br />" & vbCrLf
        If Trim(CategoryID) = "" Or Not IsNumeric(Trim(CategoryID)) Then MyRESP = MyRESP & "Please select valid Category.<br />" & vbCrLf

        Dim KeywCount As Integer
        Dim MyKeyws()
        MyKeyws = KeywordsTxt.ToString.Split(",")
        For i = 0 To UBound(MyKeyws)
            Dim MyText = MyKeyws(i).ToString
            If Trim(MyText) <> "" Then
                KeywCount = KeywCount + 1
            End If
        Next
        If KeywCount < 3 Then MyRESP = MyRESP & "Please enter at least 3 Keywords.<br />" & vbCrLf

        Dim MyDataFromDB As New fn_db_data
        Dim MyID = MyDataFromDB.Get_ArticleID_ByDate(DateTxt)
        If Trim(MyID) <> "" Then MyRESP = MyRESP & "You already have an article with this date.<br />" & vbCrLf

        Return MyRESP
    End Function
    Public Function Validate_UserLogin(ByVal UserName, ByVal Pass)
        Dim MyRESP As String = ""

        If Trim(UserName) = "" Then MyRESP = "Please enter valid User Name. <br />"
        If Trim(Pass) = "" Then MyRESP = MyRESP & "Please enter valid Password.<br />" & vbCrLf


        Return MyRESP
    End Function
End Class
