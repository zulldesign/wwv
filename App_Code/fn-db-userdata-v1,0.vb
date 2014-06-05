Imports Microsoft.VisualBasic

Public Class fn_db_userdata

    Dim MyDBUserData As New db_acc_v21_user_data


    Function IQ(ByVal MyTxt)
        Return "'" & MyTxt & "'"
    End Function


    Public Function InsertImgToDB(ByVal TempArticleID, ByVal ImgName)

        Try

            Dim q(20)

            q(1) = TempArticleID
            q(2) = ImgName
    

            Dim TblName = "content_images"
            Dim ColNames = "content_tmp_id,	image_name"

            Dim ValNames = "'" & q(1) & "','" & q(2) & "'"


            Dim SqlStr = MyDBUserData.DB_InsertSTR(TblName, ColNames, ValNames)
            MyDBUserData.QueryExecuteNonQuery(SqlStr)


            Return q(4)
        Catch ex As Exception

            Return ex.Message.ToString
        End Try


    End Function

    Public Function SaveArticleAsAndReturnArticleID(ByVal ArticleID, ByVal content_title, ByVal Content, ByVal authorID, ByVal category_id, ByVal keywords, ByVal status, ByVal MyPicName)

        If Trim(ArticleID) = "" Then
            Dim ArticleDate = System.DateTime.Now
            InsertArticle(content_title, Content, authorID, ArticleDate, category_id, keywords, status) 'save as template

            ArticleID = Get_ArticleID_ByDate(ArticleDate)
        End If

        If Trim(MyPicName) <> "" Then SavePicture(ArticleID, MyPicName)

        Return ArticleID
    End Function

    Sub SavePicture(ByVal ArticleID, ByVal MyPicName)
        Dim q(20)
        q(1) = ArticleID
        q(2) = MyPicName

        Dim TblName = "[content_images]"
        Dim ColNames = "[content_id],[image_name]"

        Dim ValNames = "" & q(1) & ",'" & q(2) & "'"

        Dim SqlStr = MyDBUserData.DB_InsertSTR(TblName, ColNames, ValNames)
        MyDBUserData.QueryExecuteNonQuery(SqlStr)
    End Sub


    Public Function InsertTempArticleAndReturnTempID(ByVal authorID, ByVal content_date)

        Try

            Dim q(20)
  
            q(1) = authorID
            q(2) = fn_general_v30.TarihForDB(content_date)
            q(3) = "template" ' template | published | accepted | deleted
            q(4) = fn_general_v30.Session_GetID(16)


    
            Dim TblName = "content"
            Dim ColNames = "author,content_date,[status],temp_id"

            Dim ValNames = "" & q(1) & "," & q(2) & ",'" & q(3) & "','" & q(4) & "'"


            Dim SqlStr = MyDBUserData.DB_InsertSTR(TblName, ColNames, ValNames)
            MyDBUserData.QueryExecuteNonQuery(SqlStr)


            Return q(4)
        Catch ex As Exception

            Return ex.Message.ToString
        End Try


    End Function

    Public Function InsertArticle(ByVal content_title, ByVal content, ByVal authorID, ByVal content_date, ByVal category_id, ByVal keywords, ByVal status)
        Dim MyRESP As String
        'article_id,	keyw

        Try

            Dim q(20)
            q(1) = content_title

            q(3) = fn_general_v30.ASCIItoTextHTML(content)
            q(4) = authorID
            q(5) = fn_general_v30.TarihForDB(content_date)
            q(6) = category_id
            q(7) = status ' template | published | accepted | deleted


            For i = 1 To 20
                q(i) = fn_general_v30.DB_ClearText(q(i))
            Next

            q(1) = IQ(q(1)) : q(3) = IQ(q(3)) : q(7) = IQ(q(7))

       
            For i = 1 To 20
                If q(i) = "" Then q(i) = "NULL"
            Next

            Dim TblName = "content"
            Dim ColNames = "content_title,content,author,content_date,category_id,[status]"

            Dim ValNames = "" & q(1) & "," & q(3) & "," & q(4) & "," & q(5) & "," & q(6) & "," & q(7) & ""


            Dim SqlStr = MyDBUserData.DB_InsertSTR(TblName, ColNames, ValNames)
            MyDBUserData.QueryExecuteNonQuery(SqlStr)

            '#### Keywords ####
            If Trim(keywords) <> "" Then
                Dim MyUserDataFromDB As New fn_db_userdata
                Dim MyID = MyUserDataFromDB.Get_ArticleID_ByDate(content_date)
                InsertKeywords(MyID, keywords)
            End If
            '#### Keywords ####

            MyRESP = "Article Added!"
        Catch ex As Exception

            MyRESP = ex.Message.ToString
        End Try

        Return MyRESP

    End Function
    Sub InsertKeywords(ByVal ArticleID, ByVal Keyw)

        Dim q(20)
        q(1) = ArticleID
        q(2) = Keyw


        Dim MyKeys()
        MyKeys = Keyw.ToString.Split(",")

        For i = 0 To UBound(MyKeys)
            Dim MyKey = MyKeys(i).ToString
            If Trim(MyKey) <> "" Then

                MyKey = fn_general_v30.DB_ClearText(MyKey)

                Dim TblName = "content_keywords"
                Dim ColNames = "article_id,	keyw"

                Dim ValNames = "" & q(1) & ",'" & MyKey & "'"

                Dim SqlStr = MyDBUserData.DB_InsertSTR(TblName, ColNames, ValNames)
                MyDBUserData.QueryExecuteNonQuery(SqlStr)
            End If
        Next


    End Sub




    Public Function Get_User_Info(Optional ByVal UserID = "", Optional ByVal MyEmail = "", Optional ByVal MySess = "")

        'id	name	nick_name	email	password	mobile_no	role	resim	status	sess	pref_lang


        Dim TblName = "[users]"
        Dim ColName = "[id],[name],[email],password,[role],resim,[status],sess"
        Dim WhereStr

        If UserID <> "" Then WhereStr = "[id]=" & UserID & ""
        If MyEmail <> "" Then
            MyEmail = fn_general_v30.DB_ClearText(MyEmail)
            WhereStr = "[email]='" & MyEmail & "'"
        End If
        If MySess <> "" Then WhereStr = "[sess]='" & MySess & "'"

        Dim SqlStr = MyDBUserData.DB_SelectSTR(TblName, ColName, WhereStr)

        Dim DT As System.Data.DataTable
        DT = MyDBUserData.QueryDataTable(SqlStr)


        Dim MyRESP As New class_decl_v10.UserDetails
        Dim MyWord
        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        If KS > 0 Then
            MyRESP.MyID = DT.Rows(0).Item(0).ToString
            MyRESP.MyName = DT.Rows(0).Item(1).ToString
            MyRESP.MyEmail = DT.Rows(0).Item(2).ToString
            MyRESP.MyPass = DT.Rows(0).Item(3).ToString
            MyRESP.MyRole = DT.Rows(0).Item(4).ToString
            MyRESP.MyResim = DT.Rows(0).Item(5).ToString
            MyRESP.MyStatus = DT.Rows(0).Item(6).ToString
            MyRESP.MySess = DT.Rows(0).Item(7).ToString
        End If


        Return MyRESP
    End Function



    Public Function Get_ArticleID_ByDate(ByVal MyDate)
        Dim TblName = "content"
        Dim ColName = "id"
        Dim WhereStr = "[content_date]=" & fn_general_v30.TarihForDB(MyDate) & ""

        Dim SqlStr = MyDBUserData.DB_SelectSTR(TblName, ColName, WhereStr)

        Dim DT As System.Data.DataTable
        DT = MyDBUserData.QueryDataTable(SqlStr)

        Dim MyWord
        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        If KS > 0 Then
            MyWord = DT.Rows(0).Item(0).ToString
        End If

        Return MyWord
    End Function








    Public Function InsertUser(ByVal namez, ByVal emailz, ByVal passwordz, ByVal rolez, ByVal nickname, Optional ByVal resim = "", Optional ByVal mobile_no = "")
        Dim MyRESP As String
        'article_id,	keyw

        Dim MyDBUserData As New db_acc_v21_user_data

        Try

            Dim q(20)
            q(1) = namez
            q(2) = emailz
            q(3) = passwordz
            q(4) = mobile_no
            q(5) = rolez
            q(6) = resim
            q(7) = nickname
            q(8) = "active"
            q(9) = fn_general_v30.Session_GetID(20)

            For i = 1 To 20
                q(i) = fn_general_v30.DB_ClearText(q(i))
            Next

            Dim TblName = "[users]"
            Dim ColNames = "[name],[email],[password],mobile_no,[role],resim,nick_name,[status],sess"

            Dim ValNames = "'" & q(1) & "','" & q(2) & "','" & q(3) & "','" & q(4) & "','" & q(5) & "','" & q(6) & "','" & q(7) & "','" & q(8) & "','" & q(9) & "'"



            Dim SqlStr = MyDBUserData.DB_InsertSTR(TblName, ColNames, ValNames)
            MyDBUserData.QueryExecuteNonQuery(SqlStr)



            MyRESP = "User Added!"
        Catch ex As Exception

            MyRESP = ex.Message.ToString
        End Try

        Return MyRESP

    End Function
End Class
