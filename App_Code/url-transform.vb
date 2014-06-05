Imports Intelligencia.UrlRewriter
Imports System.Web

Namespace url_transform
    ''' <summary>
    ''' Convert a car name into its ID value
    ''' </summary>
    Public Class url_transform
        Implements IRewriteTransform
        ''' <summary>
        ''' The name you reference this custom transform by
        ''' </summary>
        Public ReadOnly Property Name As String Implements IRewriteTransform.Name
            Get
                Return "UrlTransform"
            End Get
        End Property

        ''' <summary>
        ''' Apply the transform
        ''' </summary>
        ''' <param name="input"></param>
        ''' <returns></returns>
        Public Function ApplyTransform(input As String) As String Implements IRewriteTransform.ApplyTransform
            Dim DefaultURL = input

            Dim MyRESP As String = ""


            'Dim Exc As String = ".css,.gif,.jpg,.png,"
            'Dim Excepts() = Exc.ToString.Split(",")
            'For i = 0 To UBound(Excepts)
            '    If Replace(input.ToString, Excepts(i).ToString, "") <> input.ToString Then Return ""
            'Next

            Dim MyURL = input.ToString
            MyURL = "http://serkan.com/" & MyURL  ': MsgBox(MyURL)
            Dim MyUri As New Uri(MyURL)

            Dim Seg() = MyUri.Segments
            Dim MaxSeg = UBound(Seg)


            'Buradan başla


            '<rewrite url="~/konu/(.+)/(.+)/(.+)/(.+)/(.+)/" to="~/topic.aspx?id=$3&amp;tag_id=$5" />
            '<rewrite url="~/konu/(.+)/(.+)/(.+)/" to="~/topic.aspx?id=$3" />

            If Replace(MyURL, "/konu/", "") <> MyURL Then

                If Replace(MyURL, "tag=", "") <> MyURL Then

                    For i = 1 To UBound(Seg)
                        If Replace(Seg(i).ToString, "_", "") <> Seg(i).ToString Then
                            Dim MySeg = Seg(i).ToString
                            'Dim TopicID = Trim(fn_general_v30.IlkBulVeDegistir(MySeg, "_", "!"))
                            'MsgBox(TopicID)
                            'TopicID = Trim(fn_general_v30.GetStringBetween(TopicID, "", "!"))
                            Dim TopicID = Trim(fn_general_v30.GetStringBetween(MySeg, "", "_"))
                            Dim TagID = Trim(fn_general_v30.GetStringBetween(MyURL, "tag=", "-"))

                            MyRESP = "topic.aspx?id=" & TopicID & "&tag_id=" & TagID

                        End If
                    Next


                ElseIf Replace(MyURL, "searched=", "") <> MyURL Then

                    For i = 1 To UBound(Seg)
                        If Replace(Seg(i).ToString, "_", "") <> Seg(i).ToString Then
                            Dim MySeg = Seg(i).ToString
                            'Dim TopicID = Trim(fn_general_v30.IlkBulVeDegistir(MySeg, "_", "!"))
                            'MsgBox(TopicID)
                            'TopicID = Trim(fn_general_v30.GetStringBetween(TopicID, "", "!"))
                            Dim TopicID = Trim(fn_general_v30.GetStringBetween(MySeg, "", "_"))
                            Dim TagID = Trim(fn_general_v30.GetStringBetween(MyURL, "searched=", "-"))

                            MyRESP = "topic.aspx?id=" & TopicID & "&searched_id=" & TagID

                        End If
                    Next


                Else
                    For i = 1 To UBound(Seg)
                        If Replace(Seg(i).ToString, "_", "") <> Seg(i).ToString Then
                            Dim MySeg = Seg(i).ToString
                            Dim TopicID = Trim(fn_general_v30.GetStringBetween(MySeg, "", "_"))
                            MyRESP = "topic.aspx?id=" & TopicID
                        End If
                    Next
                End If





            ElseIf Replace(MyURL, "/category/", "") <> MyURL Then
                Dim MySeg = Seg(UBound(Seg)).ToString
                Dim CatID = Replace(MySeg, "/", "")
                MyRESP = "search.aspx?cat_id=" & CatID

            ElseIf Replace(MyURL, "/archive/", "") <> MyURL Then
                Dim MySeg = Seg(UBound(Seg)).ToString
                Dim CatID = Replace(MySeg, "/", "")
                MyRESP = "search.aspx?date=" & CatID

            ElseIf Replace(MyURL, "/search/", "") <> MyURL Then
                Dim MySeg = Seg(2).ToString
                Dim SearchedID = Replace(MySeg, "/", "")
                MyRESP = "search.aspx?searched_id=" & SearchedID


          





            ElseIf Replace(MyURL, "sitemap.xml", "") <> MyURL Then
                MyRESP = "sitemap.aspx"


            Else
                MyRESP = DefaultURL
            End If









            Return MyRESP

        End Function





    End Class
End Namespace
