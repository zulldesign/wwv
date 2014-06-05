
Imports fn_general_v30
Imports html_tidy_v10


Partial Class admin_tags_fill
    Inherits System.Web.UI.Page

    Dim MyDB As New db_acc_v21_data


    Dim PrefixWords = ""
    'Dim SuffixWords = "holiday choices,holiday,vacation,holiday lettings,holiday rentals,beach holidays,city life holidays,golf holidays,quiet holidays,fishing holidays,nightlife holidays,horse riding holidays,letting,rental,foodie holidays,long let,cheap holiday homes,sailing holidays,short break,Unusual and Interesting properties,baby friendly holiday,toddler friendly,courses and classes holidays,caravan holidays,family farm stays,off the beaten tracks,eco-friendly holidays,spring in the mountains,summer in the mountains,holistic holidays,wine tasting holidays,holiday home swaps,going solo,Hen or stag breaks,Pet-friendly holiday,Large groups holiday,Family fun,Romantic break,Catered holidays,Explore the Norfolk Broads,Villas with pools,Wheelchair adapted holiday,Ski holidays,snowboard holidays,ski and snowboard holidays,Winter sun holiday,Rural retreats,Water sport holiday,Christmas holiday,New Year break,Pyrenees,Winter wonderlands"
    Dim SuffixWords As String = "recipes,  ingredients, healthy recipes,baking recipes, cooking recipes, easy recipes, veggie recipes, cooking tips,рецепты, ингредиенты, здоровые рецепты, выпечка рецепты, кулинарные рецепты, рецепты легко, вегетарианские рецепты, готовя подсказки,وصفات, والمكونات, وصفات صحية, وصفات الخبز, وصفات الطبخ, وصفات سهلة وصفات الخضروات, نصائح الطبخ,配方,配料,健康食谱,烘焙食谱,烹饪食谱,食谱,素食食谱,烹饪技巧,ricette, ingredienti, ricette sane, ricette da forno, ricette cucina, ricette facili, ricette vegetariane, consigli di cucina"


    Function WriteKeyws(ByVal MyVal)

        Dim PreX() : Dim k As Integer
        PreX = PrefixWords.ToString.Split(",")
        Dim SufX() : Dim j As Integer
        SufX = SuffixWords.ToString.Split(",")

        Dim MyTags
        For k = 0 To UBound(PreX)
            For j = 0 To UBound(SufX)
                Dim TagName = PreX(k) & " " & MyVal & " " & SufX(j) & ", "
                MyTags = MyTags & TagName
            Next
        Next

        MyTags = Trim(MyTags)
        MyTags = SonSil(MyTags, ",")

        Return MyTags
    End Function


    Public Shared Function SonSil(ByVal MyTxt As String, ByVal MySymb As String)
        If Trim(MyTxt) = "" Then Return MyTxt

        If Left(MyTxt, 1) = MySymb Then MyTxt = Right(MyTxt, Len(MyTxt) - 1)
        If Right(MyTxt, 1) = MySymb Then MyTxt = Left(MyTxt, Len(MyTxt) - 1)

        Return MyTxt
    End Function

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'OkuVeYaz()
    End Sub

    Sub OkuVeYaz()


        Dim TblName = "content"
        Dim ColName = "top 10 id,[keywords],keywords_url"


        Dim SqlStr = MyDB.DB_SelectSTR(TblName, ColName)
        Dim DT As System.Data.DataTable
        DT = MyDB.QueryDataTable(SqlStr)


        Dim MySTR = "", i
        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        If KS > 0 Then
            For i = 0 To KS - 1

                NewDB(DT.Rows(i)("id").ToString, DT.Rows(i)("keywords").ToString)
            Next
        End If


  

            WarnTxt.Text = "Tamamlandı!"
    End Sub

    Sub NewDB(ByVal MyID, ByVal MyTags)

        Dim Q(50)

        Q(1) = TextToURL(MyTags, "tags")

        Dim TblName = "content"
        Dim ColName = "keywords_url"
        Dim ValName = "'" & Q(1) & "'"
        Dim WhereStr = "[id]=" & MyID & ""


        Dim SqlStr = MyDB.DB_UpdateSTR(TblName, ColName, ValName, WhereStr)

        MsgBox(SqlStr)
        MyDB.QueryExecuteNonQuery(SqlStr)


    End Sub




















    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        TagOlustur()

    End Sub

    Sub TagOlustur()

        Dim TblName = "content"
        'Dim ColName = "top 1 id,[content_title]"
        Dim ColName = "id,[content_title]"

        Dim SqlStr = MyDB.DB_SelectSTR(TblName, ColName)
        Dim DT As System.Data.DataTable
        DT = MyDB.QueryDataTable(SqlStr)


        Dim MySTR = "", i
        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        If KS > 0 Then
            For i = 0 To KS - 1
                Dim MyTitle = DT.Rows(i)("content_title").ToString
                Dim MyID = DT.Rows(i)("id").ToString

                Dim MyKeyws = WriteKeyws(MyTitle)
                'Response.Write(MyKeyws)
                InsertKeywToDB(MyID, MyKeyws)
            Next
        End If

 

        WarnTxt.Text = "Tamamlandı!"
    End Sub

    Sub InsertKeywToDB(ByVal ContentID, ByVal Keyws)

        Dim MyKeyws() = Keyws.ToString.Split(",")

        For i = 0 To UBound(MyKeyws) - 1

            If Trim(MyKeyws(i).ToString) <> "" Then
                Dim MyKeyw = Trim(MyKeyws(i).ToString)
                TagToDB(ContentID, MyKeyw)
            End If
        Next

    End Sub


    Sub TagToDB(ByVal ContentID, ByVal MyKeyw)

        ContentID = fn_general_v30.DB_ClearText(ContentID)
        MyKeyw = fn_general_v30.DB_ClearText(MyKeyw)

        Dim TblName = "content_keywords"
        Dim ColName = "article_id,keyw"
        Dim ValName = "'" & ContentID & "','" & MyKeyw & "'"


        Dim SqlStr = MyDB.DB_InsertSTR(TblName, ColName, ValName)


        MyDB.QueryExecuteNonQuery(SqlStr)

    End Sub


 




    Sub CatOkuVeYaz()


        Dim TblName = "content"
        Dim ColName = "id,content_intro"



        Dim SqlStr = MyDB.DB_SelectSTR(TblName, ColName)
        Dim DT As System.Data.DataTable
        DT = MyDB.QueryDataTable(SqlStr)


        Dim MySTR = "", i
        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        If KS > 0 Then
            For i = 0 To KS - 1
                CatNewDB(DT.Rows(i)("id").ToString, DT.Rows(i)("content_intro").ToString)
            Next
        End If




        WarnTxt.Text = "Tamamlandı!"
    End Sub

    Sub CatNewDB(ByVal MyID, ByVal MyTags)

        Dim Q(50)

        Q(1) = ClearCat(MyTags)

        Dim TblName = "content"
        Dim ColName = "categories"
        Dim ValName = "'" & Q(1) & "'"
        Dim WhereStr = "[id]=" & MyID & ""

        Dim SqlStr = MyDB.DB_UpdateSTR(TblName, ColName, ValName, WhereStr)
        MyDB.QueryExecuteNonQuery(SqlStr)

    End Sub

    Function ClearCat(ByVal MyTxt)
        MyTxt = GetStringBetween(MyTxt, "games in Category: ", " and much more")
        Return MyTxt
    End Function

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        'CatOkuVeYaz()
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim TblName = "content"
        Dim ColName = "id"
        Dim OrderBy = "id DESC"
        Dim MyRecs As New Collection '1 den başlar

        Dim SqlStr = MyDB.DB_SelectSTR(TblName, ColName, , OrderBy)
        Dim DT As System.Data.DataTable
        DT = MyDB.QueryDataTable(SqlStr)

        Dim MySTR = "", i
        Dim KS = DT.Rows.Count 'Kayıt Sayısı
        If KS > 0 Then
            For i = 0 To KS - 1
                MyRecs.Add(DT.Rows(i)("id").ToString)
            Next
        End If

        MsgBox(MyRecs.Item(0).ToString)
        WarnTxt.Text = "Tamamlandı!"
    End Sub
End Class
