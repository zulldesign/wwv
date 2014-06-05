Imports Microsoft.VisualBasic
Imports System.IO

Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class fn_general_v30



    Public Shared Function MakeThumb(ByVal src As String, ByVal dest As String, ByVal w As Integer, Optional ByVal h As Integer = 0) As Boolean
        Dim imgTmp As System.Drawing.Image
        Dim sf As Double
        Dim imgFoto As System.Drawing.Bitmap


        imgTmp = System.Drawing.Image.FromFile(src)
        If (imgTmp.Width > w) Then
            sf = imgTmp.Width / w



            imgFoto = New System.Drawing.Bitmap(w, CInt(imgTmp.Height / sf))
            Dim recDest As New Rectangle(0, 0, w, imgFoto.Height)
            Dim gphCrop As Graphics = Graphics.FromImage(imgFoto)
            gphCrop.SmoothingMode = SmoothingMode.HighQuality
            gphCrop.CompositingQuality = CompositingQuality.HighQuality
            gphCrop.InterpolationMode = InterpolationMode.HighQualityBicubic '.High


            Dim MyHeight = imgTmp.Height
            If h <> 0 Then MyHeight = h

            gphCrop.DrawImage(imgTmp, recDest, 0, 0, imgTmp.Width, MyHeight, GraphicsUnit.Pixel)
        Else
            imgFoto = imgTmp
        End If
        'Dim myImageCodecInfo As System.Drawing.Imaging.ImageCodecInfo


        Dim arrayICI() As System.Drawing.Imaging.ImageCodecInfo = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()
        Dim jpegICI As System.Drawing.Imaging.ImageCodecInfo = Nothing
        Dim x As Integer = 0
        For x = 0 To arrayICI.Length - 1
            If (arrayICI(x).FormatDescription.Equals("JPEG")) Then
                jpegICI = arrayICI(x)
                Exit For
            End If
        Next

        Dim myEncoder As System.Drawing.Imaging.Encoder
        Dim myEncoderParameter As System.Drawing.Imaging.EncoderParameter
        Dim myEncoderParameters As System.Drawing.Imaging.EncoderParameters

        myEncoder = System.Drawing.Imaging.Encoder.Quality
        myEncoderParameters = New System.Drawing.Imaging.EncoderParameters(1)
        myEncoderParameter = New System.Drawing.Imaging.EncoderParameter(myEncoder, 60L)
        myEncoderParameters.Param(0) = myEncoderParameter


        'imgFoto.SetResolution(72, 72)
        imgFoto.Save(dest, jpegICI, myEncoderParameters)
        imgFoto.Dispose()
        imgTmp.Dispose()
        Return True
    End Function



    Public Shared Function Get_YouTubePlayer(VideoURL As String) As String

        Dim YoutubeVideoRegex As New Regex("youtu(?:\.be|be\.com)/(?:(.*)v(/|=)|(.*/)?)([a-zA-Z0-9-_]+)", RegexOptions.IgnoreCase)

        Dim youtubeMatch As Match = YoutubeVideoRegex.Match(VideoURL)

        Dim ID
        If youtubeMatch.Success Then ID = youtubeMatch.Groups(4).Value


        Dim scr As String = "<object width='320' height='240'> "
        scr = scr & "<param name='movie' value='http://www.youtube.com/v/" & ID & "'></param> "
        scr = scr & "<param name='allowFullScreen' value='true'></param> "
        scr = scr & "<param name='allowscriptaccess' value='always'></param> "
        scr = scr & "<embed src='http://www.youtube.com/v/" & ID & "' "
        scr = scr & "type='application/x-shockwave-flash' allowscriptaccess='always' "
        scr = scr & "allowfullscreen='true' width='320' height='240'> "
        scr = scr & "</embed></object>"
        Return scr

    End Function

    Public Shared Function Image_FindSingleFromAllHTML(ByVal MyTxt As String, Optional Ext As String = ".jpg") As String

        MyTxt = Replace(MyTxt, Chr(34), "HHHH")
        MyTxt = Replace(MyTxt, "'", "HHHH")
        Dim MyImgURL = fn_general_v30.GetStringBetween(MyTxt, "img src=HHHH", "HHHH ")
        MyImgURL = Replace(MyImgURL, "'", "")
        MyImgURL = Trim(MyImgURL)

        Return MyImgURL
    End Function

    Public Shared Function Image_FindSingleFromAllURL(ByVal txt As String, Optional Ext As String = ".jpg") As String
        'Dim regx As New Regex("http(s)?://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&amp;\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?", RegexOptions.IgnoreCase)
        Dim regx As New Regex("http(s)?://([\w+?\.\w+])+([a-zA-Z0-9İıÖöÜüĞğŞşÇç\~\!\@\#\$\%\^\&\*\(\)_\-\0\=\+\\\/\?\.\,\:\;\']*)?", RegexOptions.IgnoreCase)

        Dim mactches As MatchCollection = regx.Matches(txt)

        Dim MyTxt
        For Each match As Match In mactches

            MyTxt = match.Value

        Next
        Return MyTxt
    End Function



    'Function ConvertTextToImage(MyText As String, AdvID As String, Optional MW As Integer = 200, Optional MH As Integer = 20, Optional FontSize As Integer = 10)
    '    'Imports System.Drawing
    '    'Imports System.Drawing.Text
    '    'Imports System.Drawing.Imaging

    '    Dim oBitmap As Bitmap = New Bitmap(MW, MH)
    '    Dim oGraphic As Graphics = Graphics.FromImage(oBitmap)
    '    Dim oColor As System.Drawing.Color


    '    oColor = Color.White 'Request("BackgroundColor") 

    '    Dim sText As String = MyText 'Request("Text")
    '    Dim sFont As String = "Georgia"  'Request("Font")



    '    Dim oBrush As New SolidBrush(oColor)
    '    Dim oBrushWrite As New SolidBrush(Color.Black)

    '    oGraphic.FillRectangle(oBrush, 0, 0, MW, MH)
    '    oGraphic.TextRenderingHint = TextRenderingHint.AntiAlias

    '    Dim oFont As New Font(sFont, FontSize)
    '    Dim oPoint As New PointF(5.0F, 5.0F)

    '    oGraphic.DrawString(sText, oFont, oBrushWrite, oPoint)


    '    'Response.ContentType = "image/jpeg"
    '    'oBitmap.Save (Response.OutputStream, ImageFormat.Jpeg)

    '    Dim ImgPath = fn_dl.ImgEmailPath
    '    Dim FileName = AdvID & ".gif"
    '    Dim FullImgPath = ImgPath & FileName

    '    oBitmap.Save(FullImgPath, ImageFormat.Gif)

    '    Return FileName
    'End Function



    Public Shared Function Clear_GoogleSearch(ByVal SearchString As String) As String
        Dim MyRESP = SearchString


        If Not String.IsNullOrEmpty(MyRESP) Then
            MyRESP = Left(fn_general_v30.ClearLink(MyRESP, "q=", "&"), 255)
        End If
        If Not String.IsNullOrEmpty(MyRESP) Then
            MyRESP = fn_general_v30.DB_ClearText(MyRESP)
        End If
        If Not String.IsNullOrEmpty(MyRESP) Then
            MyRESP = fn_general_v30.ForSearch(MyRESP)
        End If



        Return MyRESP
    End Function

    Public Shared Function validate_email(ByVal emailAddress As String) As Boolean
        emailAddress = Trim(emailAddress)
        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        Dim emailAddressMatch As Match = Regex.Match(emailAddress, pattern)
        If emailAddressMatch.Success Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function validate_url(ByVal wwwAddress As String) As Boolean
        Dim MyRESP As Boolean
        wwwAddress = Trim(wwwAddress)

        If Replace(wwwAddress, "http://", "") = wwwAddress Then
            wwwAddress = "http://" & wwwAddress
        End If




        'Dim pattern As String = "^(http|https):/{2}[a-zA-Z./&\d_-]+"
        Dim pattern As String = "http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"

        Dim reg As New Regex(pattern, RegexOptions.IgnoreCase Or RegexOptions.ExplicitCapture)
        If reg.IsMatch(wwwAddress) = False Then
            MyRESP = False
        Else
            MyRESP = True
        End If

        Return MyRESP
    End Function


    Public Shared Function File_RENAME(FilePath As String, Optional NewFilePath As String = "")
        Dim NewFileName
        Try

            Dim JustFileName = System.IO.Path.GetFileNameWithoutExtension(FilePath)
            Dim FolderPath = System.IO.Path.GetDirectoryName(FilePath)
            Dim FileExtension = System.IO.Path.GetExtension(FilePath)


            If NewFilePath = "" Then
                NewFileName = fn_general_v30.TextToProperFilename(JustFileName, True)
                NewFilePath = FolderPath & "\" & NewFileName & FileExtension
            End If


            File.Move(FilePath, NewFilePath)
            Return "success"
        Catch ex As Exception
            Return "failure"
        End Try
        '###########USAGE ###################
        'For i = 0 To ListBox1.Items.Count - 1
        '    Dim FilePath = ListBox1.Items(i).ToString
        '    fn_general_v30.File_RENAME(FilePath)
        'Next
        '###########USAGE ###################
    End Function


    Public Shared Function TextToProperFilename(ByVal MyText, Optional ByVal IncludeDot = False)


        Dim ClearedText = MyText
        ClearedText = LCase(ClearedText)
        ClearedText = Trim(ClearedText)

        Dim i
        For i = 1 To 10
            ClearedText = Replace(ClearedText, "  ", " ") 'tüm çift boşlukları teke indirmek için
        Next

        Dim M = ClearedText



        M = Replace(M, ",", "")

        If IncludeDot = True Then
            M = Replace(M, ".", "-")
        End If

        M = Replace(M, "_", "-")
        M = Replace(M, " ", "-")
        M = Replace(M, ":", "") : M = Replace(M, ";", "")
        M = Replace(M, "'", "-") : M = Replace(M, Chr(34), "-") : M = Replace(M, "’", "-")
        M = Replace(M, "(", "-") : M = Replace(M, ")", "-") : M = Replace(M, "\", "-")
        M = Replace(M, "[", "-") : M = Replace(M, "]", "-") : M = Replace(M, "{", "-") : M = Replace(M, "}", "-")
        M = Replace(M, "?", "") : M = Replace(M, "&", "-") : M = Replace(M, "^", "-")
        M = Replace(M, "$", "") : M = Replace(M, "%", "") : M = Replace(M, "#", "") : M = Replace(M, "@", "")
        M = Replace(M, "!", "") : M = Replace(M, "*", "") : M = Replace(M, "~", "")
        M = Replace(M, "`", "") : M = Replace(M, "+", "") : M = Replace(M, "=", "")
        M = Replace(M, "|", "-") : M = Replace(M, "<", "-") : M = Replace(M, ">", "-")


        '$%#@!*?;:~`+=()[]{}|\'<>,/^&

        M = Replace(M, "ã", "a") : M = Replace(M, "ä", "a") : M = Replace(M, "ñ", "n")
        M = Replace(M, "é", "e") : M = Replace(M, "í", "i")
        M = Replace(M, "ö", "o") : M = Replace(M, "ş", "s") : M = Replace(M, "ı", "i") : M = Replace(M, "ğ", "g") : M = Replace(M, "ç", "c") : M = Replace(M, "ü", "u")



        ClearedText = M
        Dim j
        For j = 1 To 10
            ClearedText = Replace(ClearedText, "--", "-") 'çift -- > tek -
        Next

        If Left(ClearedText, 1) = "-" Then ClearedText = Right(ClearedText, Len(ClearedText) - 1)
        If Right(ClearedText, 1) = "-" Then ClearedText = Left(ClearedText, Len(ClearedText) - 1)

        ClearedText = Trim(ClearedText)

        Return ClearedText
    End Function

    'Public Shared Function CheckDate(ByVal DateToCheck)
    '    Dim MyRESP

    '    Dim dt = DateToCheck
    '    Dim Culture As IFormatProvider : Culture = New CultureInfo("tr-TR", True)
    '    Dim MyDate
    '    Try
    '        MyDate = DateTime.ParseExact(dt, "dd.MM.yyyy", Culture, DateTimeStyles.NoCurrentDateDefault)
    '        MyRESP = True
    '    Catch ex As Exception
    '        MyRESP = False
    '    End Try


    '    Return MyRESP
    'End Function

    Public Shared Function Text_Style(ByVal Text, ByVal CSS)
        Dim MyRESP = "<span class=""" & CSS & """>" & Text & "</span>"
        Return MyRESP
    End Function

    Public Shared Function Tablo_Olustur(ByVal SS, ByVal MyData, ByVal BasePath, Optional ByVal TblClass = "")
        '¥=sutun § =id
        'KS Kayıt Sayısı        'SS Sutun Sayısı
        Dim MyDat()
        MyDat = MyData.ToString.Split("¥")

        Dim KS = UBound(MyDat)
        Dim SBK = Int(KS / (SS - 1)) 'Sütun başına kayıt

        Dim STR As New StringBuilder
        STR.AppendLine("<table  style=""table-layout: fixed;width:100%; margin-left:0px;margin-top:0px;"" cellspacing=""0"" cellpadding=""0""  class=""" & TblClass & """ ><tr><td>")

        Dim i As Integer, ColumnNumber As Integer

        For i = 0 To KS - 1

            Dim MyItem = MyDat(i).ToString

            Dim j
            Dim Eklendi = "hayir"
            For j = 1 To 50 '50 kolona kadar check ediyoruz
                If i = (SBK * j) Then
                    Eklendi = "evet"
                    STR.AppendLine("</td><td>" & MyItem & "<br />")
                End If
            Next

            If Eklendi = "hayir" Then
                STR.AppendLine("" & MyItem & "<br />")
            End If


        Next

        STR.AppendLine("</td></tr></table>")

        Return STR.ToString
    End Function

    Public Shared Function TarihForDB(ByVal DateToConvert)
        Dim DT As Date, MyDate
        If Len(DateToConvert) = 4 Then
            MyDate = "#" & DateToConvert & "-01-01#"
            Return MyDate
            Exit Function
        End If

        DT = Convert.ToDateTime(DateToConvert)
        MyDate = DT.ToString("#yyyy-MM-dd HH:mm:ss#")


        Return MyDate
    End Function

    Public Shared Function DB_ClearText(ByVal StrToClear)
        If String.IsNullOrEmpty(StrToClear) Then Return ""

        Dim TemizData = Trim(StrToClear)
        TemizData = Replace(TemizData, "'", "''") '  (') işareti
        'TemizData = Replace(TemizData, Chr(34), Chr(148)) '  (") işareti (”) ile
        'TemizData = Replace(TemizData, Chr(39), Chr(146)) '  (') işaretini (’) ile
        'TemizData = Replace(TemizData, Chr(44), Chr(130)) '  (,) işaretini (‚) ile
        TemizData = Replace(TemizData, Chr(34), """") '  (") işareti
        'TemizData = Replace(TemizData, "'", Chr(146)) ' (') işaretini (’) ile

        TemizData = Replace(TemizData, "title=""code"">", "title=""code: (double click and CTRL+C to copy)"" >") ' (') işaretini (’) ile

        Return TemizData
    End Function
    Public Shared Function DB_ReturnText(ByVal StrToClear)
        If StrToClear = "" Then Exit Function
        Dim TemizData = StrToClear
        TemizData = Replace(TemizData, Chr(146), "'") ' (') işaretini (’) ile
        Return TemizData
    End Function

    Public Shared Function File_GetExtension(ByVal FileNamez As String)
        Dim MyRESP = System.IO.Path.GetExtension(FileNamez)
        Return MyRESP
    End Function


    Public Shared Function Session_GetID(ByVal KeyLen As Integer)
        Dim MySTR
        Dim MyChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefgjijklmnopqrstuvwxyz1234567890"
        Dim i As Integer
        For i = 1 To KeyLen
            Dim RN As Integer = RandomNumber2(62, 1)
            MySTR = MySTR & Mid(MyChars, RN, 1)
        Next
        Return MySTR
    End Function

    Public Shared Function Text_Thin(ByVal Text, ByVal CSS)
        Dim MyRESP = "<span class=""" & CSS & """>" & Text & "</span>"
        Return MyRESP
    End Function
    Public Shared Function MakeImg(ByVal ImgName, ByVal ImgPath, Optional ByVal Img_Class = "", Optional ByVal w = "", Optional ByVal h = "")
        Dim MySize = ""
        If w <> "" Then MySize = "width=""" & w & """ height=""" & h & """"
        Dim MyURL = "<img " & MySize & "  class=""" & Img_Class & """ alt=""" & aTitle(ImgName) & """  src=""" & ImgPath & """ />"
        Return MyURL
    End Function

    Public Shared Function HTMLtoTEXT(ByVal Metin)
        Dim TemizText = System.Text.RegularExpressions.Regex.Replace(Metin, "<[^>]*>", "")
        TemizText = Replace(TemizText, "&nbsp;", "")
        TemizText = Replace(TemizText, "&nbsp", "")

        Return TemizText
    End Function



    Public Shared Function Encodingz()
        'Dim iso As Encoding = Encoding.GetEncoding("iso-8859-5") 'bulg
        'Dim unicode As Encoding = Encoding.UTF8
        'Dim isoBytes() As Byte = iso.GetBytes(MyTag)
        'Dim MySTR2 = unicode.GetString(isoBytes)


        'Dim MySourceCharCode = Encoding.GetEncoding("iso-8859-1")
        'Dim MyDestinCharCode = Encoding.UTF8

        'Dim MySourceByte() As Byte = MySourceCharCode.GetBytes(MyTag)
        'Dim MyDestinByte() As Byte = Encoding.Convert(MySourceCharCode, MyDestinCharCode, MySourceByte)

        'Dim MySTR2 = MyDestinCharCode.GetString(MyDestinByte)


        'Response.Write(MySTR2)
    End Function



    Public Shared Function MakePageNo(ByVal KS, ByVal PagingUrl, ByVal CurPage, ByVal PrevStr, ByVal NextStr, ByVal NoRecStr, ByVal PageStr, ByVal FirstRecStr, ByVal LastRecStr)
        Dim ListSTR As String = ""

        If String.IsNullOrEmpty(CurPage) Then CurPage = 0

        Dim SS As Integer 'sayfa sayısı
        SS = Val(KS) / Val(wpdn_v10.ListSBK) 'sayfa başına kayıt

        'MakePageNo(KS, PagingUrl,Session("lang_previous_record"),Session("lang_next_record"),Session("lang_no_record"),Session("lang_page"),Session("lang_first_record"),Session("lang_last_record"))

        Dim BackText = PrevStr : Dim NextText = NextStr
        Dim NoRec = NoRecStr
        Dim LangPage = PageStr
        Dim FirstRec = FirstRecStr : Dim LastRec = LastRecStr

        Dim PLS = 5 ' page link size 1 | 2 | 3 = 3
        Dim RecSTR As String, i As Integer
        For i = 1 To PLS
            Dim PgNo = CurPage + i - 1
            If PgNo > SS - 1 Then
            Else
                RecSTR = RecSTR & fn_general_v30.MakeLink(PgNo & " | ", Replace(PagingUrl, "[PN]", PgNo), , LangPage & ": " & PgNo)
            End If
        Next
        ListSTR = fn_general_v30.MakeLink(FirstRec, Replace(PagingUrl, "[PN]", "0")) & " | " & RecSTR & fn_general_v30.MakeLink(LastRec, Replace(PagingUrl, "[PN]", SS - 1))

        Return ListSTR
    End Function


    Public Shared Function ClearNum(ByVal MyNum) As String
        MyNum = Replace(MyNum, ",", ".")
        Return MyNum
    End Function

    Public Shared Function Link_FindSingle(ByVal txt) As String
        'Dim regx As New Regex("http(s)?://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&amp;\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?", RegexOptions.IgnoreCase)
        Dim regx As New Regex("http(s)?://([\w+?\.\w+])+([a-zA-Z0-9İıÖöÜüĞğŞşÇç\~\!\@\#\$\%\^\&\*\(\)_\-\0\=\+\\\/\?\.\,\:\;\']*)?", RegexOptions.IgnoreCase)

        Dim mactches As MatchCollection = regx.Matches(txt)

        Dim MyTxt
        For Each match As Match In mactches
            MyTxt = match.Value

        Next
        Return MyTxt
    End Function

    Public Shared Function FindAndCutData_Before(ByVal WholeSTR, ByVal LookupSTR)
        Dim RetSTR As String

        Dim MyMatch As MatchCollection = Regex.Matches(WholeSTR, LookupSTR)
        If MyMatch.Count = 0 Then
            RetSTR = ""
            GoTo ThisWayExit
        End If
        Dim StartPoint As Integer = 0
        Dim EndPoint As Integer = MyMatch.Item(0).Index()

        RetSTR = Strings.Left(WholeSTR, EndPoint)
        'RetSTR = Mid$(WholeSTR, StartPoint, Len(WholeSTR) - StartPoint)

ThisWayExit:
        Return RetSTR
    End Function


    Public Shared Function FindAndCutData(ByVal WholeSTR, ByVal LookupSTR)
        Dim RetSTR As String

        Dim MyMatch As MatchCollection = Regex.Matches(WholeSTR, LookupSTR)
        If MyMatch.Count = 0 Then
            RetSTR = ""
            GoTo ThisWayExit
        End If
        Dim StartPoint As Integer = MyMatch.Item(0).Index() + Len(LookupSTR)

        RetSTR = Strings.Left(WholeSTR, Len(WholeSTR) - StartPoint)
        'RetSTR = Mid$(WholeSTR, StartPoint, Len(WholeSTR) - StartPoint)

ThisWayExit:
        Return RetSTR
    End Function


    Public Shared Function GetStringBetween(ByVal InputText As String, ByVal starttext As String, ByVal endtext As String)
        Dim RetSTR


        Dim BasMatch As MatchCollection = Regex.Matches(InputText, starttext)
        If BasMatch.Count = 0 Then
            RetSTR = ""
            GoTo ThisWayExit
        End If
        Dim BasIndex As Integer = 0
        Dim StartPoint As Integer = BasMatch.Item(0).Index() 'Karakter sayısı

        Dim SonMatch As MatchCollection = Regex.Matches(InputText, endtext)
        If SonMatch.Count = 0 Then
            RetSTR = ""
            GoTo ThisWayExit
        End If
        Dim SonIndex As Integer = SonMatch.Count - 1
        Dim EndPoint As Integer = SonMatch.Item(SonIndex).Index()

        Dim MatchCount = SonMatch.Count
        Dim OrjTxt = InputText


        If MatchCount > 1 Then


            Dim i, MyStartCount As Integer, MyEndCount As Integer, MyTagCount As Integer
            For i = 1 To Len(InputText)

                Dim mystr = Mid(InputText, i, Len(starttext))
                If mystr = starttext Then
                    MyTagCount = MyTagCount + 1
                    MyStartCount = MyStartCount + 1
                    If MyStartCount = 1 Then
                        StartPoint = i
                    End If
                    'MsgBox("start:" & MyTagCount & "-" & i & "-" & mystr)
                End If
                If MyTagCount >= 1 Then ' eğer bitane start bulmuşsak bakıyoruz...
                    Dim mystr2 = Mid(InputText, i, Len(endtext))
                    If mystr2 = endtext Then
                        'MsgBox("end:" & MyTagCount & "-" & i & "-" & mystr2)
                        If MyTagCount = 1 Then
                            EndPoint = i
                            'MsgBox("were done")
                            Exit For
                        End If

                        MyTagCount = MyTagCount - 1

                    End If
                End If

            Next
            'MsgBox(MyTagCount)

            StartPoint = StartPoint + Len(starttext)
            EndPoint = EndPoint
            If (EndPoint - StartPoint) < 1 Then GoTo ThisWayExit
            RetSTR = Mid$(InputText, StartPoint, EndPoint - StartPoint)
        ElseIf MatchCount = 1 Then
            'MsgBox("bir")
            StartPoint = StartPoint + Len(starttext) + 1
            EndPoint = EndPoint + 1

            If (EndPoint - StartPoint) < 1 Then GoTo ThisWayExit
            RetSTR = Mid$(InputText, StartPoint, EndPoint - StartPoint)
        Else
            RetSTR = ""
        End If

ThisWayExit:
        Return RetSTR
    End Function

    Public Shared Function BoslukSil(ByVal MyText)
        MyText = Replace(MyText, vbTab, "")
        MyText = Replace(MyText, vbCrLf, "")
        MyText = Replace(MyText, Environment.NewLine, "")
        MyText = Replace(MyText, vbLf, "")
        MyText = Replace(MyText, Chr(160), "")
        Dim i
        For i = 1 To 10
            MyText = Replace(MyText, "  ", " ") 'tüm çift boşlukları teke indirmek için
        Next

        MyText = Trim(MyText)
        Return MyText
    End Function


    Public Shared Function NoFollow(ByVal MyTxt)
        MyTxt = Replace(MyTxt, "href=", "rel=""nofollow"" href=")
        Return MyTxt
    End Function

    Public Shared Function HtmlCut(ByVal MyTxt, ByVal MyLen)
        MyTxt = Left(MyTxt, MyLen)
        MyTxt = html_tidy_v10.HTML_Tidy(MyTxt)
        Return MyTxt
    End Function


    Public Shared Function MetaEkle(ByVal meta_adi As String, ByVal meta_icerik As String, ByVal oPage As Page)

        Dim yenimeta As New HtmlMeta()
        yenimeta.Name = meta_adi
        yenimeta.Content = meta_icerik
        oPage.Header.Controls.Add(yenimeta)

    End Function
    Public Shared Function MetaCikar(ByVal oPage As Page, ByVal sName As String) As Boolean
        For i As Integer = 1 To oPage.Header.Controls.Count
            If TypeOf (oPage.Header.Controls(i - 1)) Is HtmlMeta Then
                Dim oHtmlMeta As HtmlMeta = oPage.Header.Controls(i - 1)
                If oHtmlMeta.Name.ToUpper = sName.ToUpper Then
                    oPage.Header.Controls.RemoveAt(i - 1)
                    Return True
                End If
            End If
        Next
    End Function




    Public Shared Function ClearLink(ByVal MyLink, Optional ByVal StrTxt = "", Optional ByVal EndTxt = "")

        Dim TemizLink = LCase(MyLink)

        TemizLink = Replace(TemizLink, "aq=", "")
        If StrTxt <> "" Then TemizLink = GetStringBetween(TemizLink, StrTxt, EndTxt)

        TemizLink = Replace(TemizLink, "+", " ")
        TemizLink = Replace(TemizLink, "%20", " ")
        TemizLink = Replace(TemizLink, "%2b", " ")
        TemizLink = Replace(TemizLink, "%2b", " ")
        TemizLink = Replace(TemizLink, "%26", "&")
        TemizLink = Replace(TemizLink, "%2f", "/")
        TemizLink = Replace(TemizLink, "%2c", " ")
        TemizLink = Replace(TemizLink, "%22", "")

        TemizLink = HttpUtility.UrlDecode(TemizLink)


        TemizLink = Replace(TemizLink, "%c3%a5", "å")
        TemizLink = Replace(TemizLink, "%c4%b1", "ı")
        TemizLink = Replace(TemizLink, "%c5%9f", "ş")
        TemizLink = Replace(TemizLink, "%c5%9e", "ş") 'Ş
        TemizLink = Replace(TemizLink, "%c3%a7", "ç")
        TemizLink = Replace(TemizLink, "%c3%bc", "ü")
        TemizLink = Replace(TemizLink, "%c4%9f", "ğ")
        TemizLink = Replace(TemizLink, "%c4%b0", "i") 'İ
        TemizLink = Replace(TemizLink, "%c3%b6", "ö") 'ö


        TemizLink = HttpUtility.UrlDecode(TemizLink)


        TemizLink = Trim(TemizLink)

        'YANLISLAR
        If StrTxt <> "" And TemizLink <> "" Then 'linkin Belli bir kısmını alıyorsak içinde link olmasın (örn: q= den sonrası)
            Dim YanlisKelimeler, YK()
            YanlisKelimeler = "www,http,.com,.net,.org,.eu,.tr,.info,.us"
            YK = Split(YanlisKelimeler, ",")
            For i = 0 To UBound(YK)
                If Replace(TemizLink, YK(i), "") <> TemizLink Then
                    Return ""
                    Exit Function
                End If
            Next
        End If

        Return TemizLink
    End Function


    Public Shared Function RemoveLink(ByVal txt As String) As String
        Dim regx As New Regex("http://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&amp;\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?", RegexOptions.IgnoreCase)

        Dim mactches As MatchCollection = regx.Matches(txt)

        Dim MyExc(), MySTR
        MySTR = ".jpg,.gif,.png,.pdf,.flv,google.com,macromedia.com"
        MyExc = MySTR.ToString.Split(",")

        For Each match As Match In mactches
            Dim i, MyCheck
            For i = 0 To UBound(MyExc)
                If Replace(match.Value, MyExc(i).ToString, "") <> match.Value Then 'varsa
                    MyCheck = "bulundu"
                End If
            Next

            If MyCheck <> "bulundu" Then txt = txt.Replace(match.Value, "http://yerel.gercekportal.com")
        Next

        Return txt
    End Function


    Public Shared Function MakeImgLink(ByVal LinkName, ByVal LinkWWW, ByVal ImgURL, Optional ByVal a_Class = "", Optional ByVal Img_Class = "", Optional ByVal w = "", Optional ByVal h = "")
        Dim MySize = ""
        If w <> "" Then MySize = "width=""" & w & """ height=""" & h & """"
        Dim ImgUrl1 = "<img " & MySize & "  class=""" & Img_Class & """ alt=""" & aTitle(LinkName) & """  src=""" & ImgURL & """ />"
        Dim MyLink = "<a  title=""" & aTitle(LinkName) & """ href=""" & LinkWWW & """>" & ImgUrl1 & "</a>"
        If a_Class <> "" Then MyLink = "<a class=""" & a_Class & """ title=""" & aTitle(LinkName) & """ href=""" & LinkWWW & """>" & ImgUrl1 & "</a>"
        Return MyLink
    End Function

    Public Shared Function MakeLink(ByVal LinkName, ByVal LinkWWW, Optional ByVal Classs = "", Optional ByVal LinkTitle = "", Optional ByVal hTag = "")
        If LinkTitle = "" Then LinkTitle = LinkName
        Dim MyLink = "<a  title=""" & aTitle(LinkTitle) & """ href=""" & LinkWWW & """>" & LinkName & "</a>"
        If Classs <> "" Then MyLink = "<a class=""" & Classs & """ title=""" & aTitle(LinkTitle) & """ href=""" & LinkWWW & """>" & LinkName & "</a>"
        If hTag <> "" Then MyLink = "<" & hTag & ">" & MyLink & "</" & hTag & ">"
        Return MyLink
    End Function

    Public Shared Sub Folder_CREATE(ByVal PATH)
        Directory.CreateDirectory(PATH)
    End Sub


    Public Shared Sub File_APPEND(ByVal PATH, ByVal MSG)
        'Get a StreamWriter class that can be used to write to the file
        Dim objStreamWriter As StreamWriter
        objStreamWriter = File.AppendText(PATH)
        objStreamWriter.WriteLine(MSG)
        objStreamWriter.Close()
    End Sub
    Public Shared Function File_READ(ByVal PATH)
        Dim objStreamReader As StreamReader
        objStreamReader = File.OpenText(PATH)
        Dim CONTENTS As String = objStreamReader.ReadToEnd()
        objStreamReader.Close()
        Return CONTENTS.Replace(vbCrLf, "<br />")
    End Function

    Public Shared Sub File_WRITE(ByVal PATH, ByVal MSG)
        File.WriteAllText(PATH, MSG)
        'Dim MyDir = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath & "sitemap.xml"
        'fn_general_v30.File_WRITE(MyDir, Str.ToString)
    End Sub



    Public Shared Function SonSil(ByVal MyTxt As String)
        If Trim(MyTxt) = "" Then Return MyTxt
        MyTxt = Left(MyTxt, Len(MyTxt) - 1)
        Return MyTxt
    End Function





    Public Shared Function File_DELETE(ByVal FilePath)
        Try
            Dim TheFile As FileInfo = New FileInfo(FilePath)
            If TheFile.Exists Then
                File.Delete(FilePath)
                Return "True"
            Else
                Throw New FileNotFoundException()
            End If

        Catch ex As FileNotFoundException
            Return "File Not Found!"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Shared Function IsIncluded(ByVal TumKelime As String, ByVal Aranacak As String) As String
        TumKelime = LCase(TumKelime) : Aranacak = LCase(Aranacak)
        If Replace(TumKelime, Aranacak, "") <> TumKelime Then
            Return True
        Else
            Return False
        End If
    End Function


    Public Shared Function SariBack(ByVal MSG)
        Return ("<a style='background-color: yellow'>" & MSG & "</a>")
    End Function

    '############## File Upload ####################
    '* aspx side 
    '<input id="File1" runat="server" name="File1" style="width: 392px; height: 22px" type="file" />

    '* aspx.vb side
    'Sub UploadPicture()
    '    'Dim FilePath = UserFilesPathForAdmin '../movies
    '    Dim LocalFilePath, FileName, JustFileName, FileExt
    '    Dim ThumbFilePath = "../movies/" 'bazen hata alıyoruz..
    '    Dim TempFilePath = "../movies/temp/" 'bazen hata alıyoruz..
    '    Dim RN = RandomNumber(5)

    '    If Not File1.PostedFile Is Nothing And File1.PostedFile.ContentLength > 0 Then 'Eğer bir döküman varsa
    '        FileName = System.IO.Path.GetFileName(File1.PostedFile.FileName)
    '        FileExt = System.IO.Path.GetExtension(File1.PostedFile.FileName)
    '        JustFileName = Replace(FileName, FileExt, "")

    '        Dim MyFileName = IsimTemizle(AdTxt.Text) & "_" & IsimTemizle(JustFileName) & FileExt

    '        Dim SaveLocationTemp As String = Server.MapPath(TempFilePath) & MyFileName
    '        File1.PostedFile.SaveAs(SaveLocationTemp)

    '        Dim SaveLocationThumb = Server.MapPath(ThumbFilePath) & MyFileName
    '        MakeThumb(SaveLocationTemp, SaveLocationThumb, 270)
    '    End If

    'End Sub
    'Sub UpdateUserDocInfo(ByVal FileLink)
    '    Dim TblName = "[users]"
    '    Dim ColNames = "cv_link"
    '    Dim ValNames = "'" & FileLink & "'"
    '    Dim WhereStr = "[id]=" & Session("UserId") & ""

    '    DB_UPDATE(DBPath, TblName, ColNames, ValNames, WhereStr)
    '    'WarnTxt.Text = Warn("Değişiklikler Kaydedildi!")
    'End Sub


    Public Shared Function MakeMassLink(ByVal TopluLink, ByVal AYRAC, ByVal LinkWWW, Optional ByVal KLAS = "", Optional ByVal OutputAYRAC = "")
        Dim MyLinks() = TopluLink.ToString.Split(AYRAC)
        Dim MyTopluLink = ""
        Dim i
        For i = 0 To UBound(MyLinks)
            Dim LinkText, TitLink, ForSRCH
            Dim MyLink = Trim(MyLinks(i).ToString)
            LinkText = MyLink
            TitLink = aTitle(MyLink)
            ForSRCH = TextToURL(MyLink)

            If OutputAYRAC <> "" Then
                MyTopluLink = MyTopluLink & "<a class='" & KLAS & "' target='_self' title='" & TitLink & "' href='" & LinkWWW & ForSRCH & "'>" & LinkText & "</a>" & OutputAYRAC
            Else
                MyTopluLink = MyTopluLink & "<a class='" & KLAS & "' target='_self' title='" & TitLink & "' href='" & LinkWWW & ForSRCH & "'>" & LinkText & "</a>"
            End If

        Next
        Return Left(MyTopluLink, Len(MyTopluLink) - 2)
    End Function

    Public Shared Function aTitle(ByVal LinkName)
        LinkName = Replace(LinkName, "'", "")
        LinkName = Replace(LinkName, Chr(34), "")
        LinkName = Replace(LinkName, ")", "")
        LinkName = Replace(LinkName, "(", "")
        LinkName = Replace(LinkName, ".", "")
        LinkName = Replace(LinkName, ",", "")
        LinkName = Replace(LinkName, ";", " ")
        LinkName = Trim(LinkName)
        Return LinkName
    End Function
    Public Shared Function FixedLenght(ByVal MyText, ByVal MyLen)
        If Len(MyText) > MyLen Then
            MyText = Left(MyText, MyLen)
        ElseIf Len(MyText) < MyLen Then
            Dim bosluk = MyLen - Len(MyText)
            Dim MySpace
            Dim i
            For i = 1 To bosluk
                MySpace = MySpace & Chr(160)
            Next
            MyText = MyText & MySpace
        Else
            MyText = MyText
        End If
        Return MyText
    End Function


    Public Shared Function StripText(ByVal MyText)
        MyText = Replace(MyText, vbTab, "")
        MyText = Replace(MyText, vbCrLf, "")
        MyText = Replace(MyText, vbLf, "")
        MyText = Replace(MyText, Chr(160), "")
        MyText = Trim(MyText)

        If Right(MyText, 1) = "," Then MyText = Left(MyText, Len(MyText) - 1)
        Return MyText
    End Function

    Public Shared Function STRCompare(ByVal first, ByVal second)
        If String.Compare(first, second, False) = 0 Then
            Return "esit"
        Else
            Return "esit degil"
        End If
    End Function

    Public Shared Function ASCIItoTextHTML(ByVal STR) As String
        STR = Replace(STR, "&ouml;", "ö")
        STR = Replace(STR, "&Ouml;", "Ö")
        STR = Replace(STR, "&uuml;", "ü")
        STR = Replace(STR, "&Uuml;", "Ü")
        STR = Replace(STR, "&ccedil;", "ç")
        STR = Replace(STR, "&Ccedil;", "Ç")
        Return STR
    End Function
    Public Shared Function ASCIItoTextURL(ByVal STR) As String
        STR = Replace(STR, "%c4%b1", "ı")
        STR = Replace(STR, "%c5%9f", "ş")
        STR = Replace(STR, "%c5%9e", "ş") 'Ş
        STR = Replace(STR, "%c3%a7", "ç")
        STR = Replace(STR, "%c3%bc", "ü")
        STR = Replace(STR, "%c4%9f", "ğ")
        STR = Replace(STR, "%c4%b0", "i") 'İ
        STR = Replace(STR, "%c3%b6", "ö") 'ö
        Return STR
    End Function



    Public Shared Function ListFiles(ByVal ListPath)
        Dim storefile As Directory
        Dim directory As String
        Dim files As String()
        Dim File As String

        files = storefile.GetFiles(ListPath, "*")

        Dim MyFiles
        For Each File In files
            MyFiles = MyFiles & File & "¦¦"
        Next
        Return MyFiles
        'USAGE ======================================================================================================
        'Dim MyFiles() = Split(ListFiles(Server.MapPath("album")), "¦¦")
        'Dim i
        'For i = 0 To UBound(MyFiles)
        '    Response.Write(MyFiles(i) & "<br>")
        'Next
    End Function




    Public Shared Function Proper(ByVal STR)
        Return StrConv(STR, vbProperCase)
    End Function

    Public Shared Function RedirectHTTP(ByVal FullURL)
        'USAGE ======================================================================================================
        'If RedirectWWW(Request.Url.ToString()) <> "False" Then Response.Redirect(RedirectWWW(Request.Url.ToString()))
        If Replace(FullURL, "localhost", "") <> FullURL Then
            Return "False"
            Exit Function
        End If


        Dim ClearURL = FullURL
        ClearURL = Replace(ClearURL, "http://", "")
        If Replace(ClearURL, "www.", "") = ClearURL Then 'www. yoksa 
            Return "False"
        Else
            ClearURL = Replace(ClearURL, "www.", "")
            ClearURL = "http://" & ClearURL
            Return ClearURL
        End If

    End Function
    Public Shared Function RedirectWWW(ByVal FullURL)
        'USAGE ======================================================================================================
        'If RedirectWWW(Request.Url.ToString()) <> "False" Then Response.Redirect(RedirectWWW(Request.Url.ToString()))
        If Replace(FullURL, "localhost", "") <> FullURL Then
            Return "False"
            Exit Function
        End If

        Dim ClearURL = FullURL
        ClearURL = Replace(ClearURL, "http://", "")
        If Replace(ClearURL, "www.", "") = ClearURL Then
            ClearURL = "http://www." & ClearURL
            Return ClearURL
        Else
            Return "False"
        End If
    End Function

    Public Shared Function RestrictedZone(ByVal HOST, ByVal MyDomain)
        'USAGE ======================================================================================================
        'If RestrictedZone(Request.ServerVariables("HTTP_HOST"), "onlinenakliyat") = True Then Response.Redirect("http://" & Request.ServerVariables("HTTP_HOST"))
        If Replace(HOST, "localhost", "") <> HOST Then
            Return False
            Exit Function
        End If
        If Replace(HOST, MyDomain, "") = HOST Then
            Return True
        Else
            Return False
        End If
    End Function



    Public Shared Function PathYaz(ByVal Port1, ByVal Protocol1, ByVal ServerName1, ByVal AppPath)
        'USAGE ####
        'Dim MyPort = Request.ServerVariables("SERVER_PORT") : Dim MySec = Request.ServerVariables("SERVER_PORT_SECURE") : Dim MyServ = Request.ServerVariables("SERVER_NAME") : 	'Dim MyAppPath = Request.ApplicationPath
        'Dim MyPath = PathYaz(MyPort, MySec, MyServ, MyAppPath)

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
        Return BasePath
    End Function


    Public Shared Function SPANCI(ByVal KirliData)
        Dim TemizData As String = KirliData
        TemizData = "</span>" & TemizData & "<span>"
        Return TemizData
    End Function



    Public Shared Function Warn(ByVal StrToWarn)
        Dim ReturnText = "<a style='font-weight: bold; font-style: italic ; color: Red;'>" & StrToWarn & "</a>"
        Return ReturnText
    End Function

    Public Shared Function CheckMail(ByVal emailAddress As String) As Boolean
        emailAddress = Trim(emailAddress)
        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        Dim emailAddressMatch As Match = Regex.Match(emailAddress, pattern)
        If emailAddressMatch.Success Then
            Return True
        Else
            Return False
        End If
    End Function


    Public Shared Function TextToURL(ByVal MyText, Optional ByVal MyCase = "")


        Dim ClearedText = MyText
        ClearedText = LCase(ClearedText)
        ClearedText = Trim(ClearedText)

        Dim i
        For i = 1 To 10
            ClearedText = Replace(ClearedText, "  ", " ") 'tüm çift boşlukları teke indirmek için
        Next

        Dim M = ClearedText

        If MyCase <> "tags" Then
            M = Replace(M, ",", "")
        End If

        M = Replace(M, " ", "-")
        M = Replace(M, ":", "") : M = Replace(M, ";", "") : M = Replace(M, ".", "-")
        M = Replace(M, "'", "-") : M = Replace(M, Chr(34), "-") : M = Replace(M, "’", "-")
        M = Replace(M, "(", "-") : M = Replace(M, ")", "-") : M = Replace(M, "\", "-")
        M = Replace(M, "[", "-") : M = Replace(M, "]", "-") : M = Replace(M, "{", "-") : M = Replace(M, "}", "-")
        M = Replace(M, "?", "") : M = Replace(M, "&", "-") : M = Replace(M, "^", "-")
        M = Replace(M, "$", "") : M = Replace(M, "%", "") : M = Replace(M, "#", "") : M = Replace(M, "@", "")
        M = Replace(M, "!", "") : M = Replace(M, "*", "") : M = Replace(M, "~", "")
        M = Replace(M, "`", "") : M = Replace(M, "+", "") : M = Replace(M, "=", "")
        M = Replace(M, "|", "-") : M = Replace(M, "<", "-") : M = Replace(M, ">", "-")
        M = Replace(M, "_", "-")

        '$%#@!*?;:~`+=()[]{}|\'<>,/^&

        M = Replace(M, "ã", "a") : M = Replace(M, "ä", "a") : M = Replace(M, "ñ", "n")
        M = Replace(M, "é", "e") : M = Replace(M, "í", "i")
        M = Replace(M, "ö", "o") : M = Replace(M, "ş", "s") : M = Replace(M, "ı", "i") : M = Replace(M, "ğ", "g") : M = Replace(M, "ç", "c") : M = Replace(M, "ü", "u")



        ClearedText = M
        Dim j
        For j = 1 To 10
            ClearedText = Replace(ClearedText, "--", "-") 'çift -- > tek -
        Next

        If Left(ClearedText, 1) = "-" Then ClearedText = Right(ClearedText, Len(ClearedText) - 1)
        If Right(ClearedText, 1) = "-" Then ClearedText = Left(ClearedText, Len(ClearedText) - 1)

        ClearedText = Trim(ClearedText)
        ClearedText = HttpUtility.UrlEncode(ClearedText)

        If MyCase = "IncludeSlash" Then
            ClearedText = Replace(ClearedText, "%2f", "/")
        End If

        Return ClearedText
    End Function

    Public Shared Function ForSearch(ByVal KirliAd)
        Dim TemizIsim = KirliAd
        TemizIsim = Replace(TemizIsim, "'", " ")
        TemizIsim = Replace(TemizIsim, ":", " ")
        TemizIsim = Replace(TemizIsim, "_", " ")
        TemizIsim = Replace(TemizIsim, "-", " ")
        TemizIsim = Replace(TemizIsim, ".", " ")
        TemizIsim = Replace(TemizIsim, "/", " ")
        TemizIsim = Replace(TemizIsim, "  ", " ")
        TemizIsim = Replace(TemizIsim, Chr(34), " ")
        TemizIsim = HttpUtility.UrlDecode(TemizIsim)
        TemizIsim = Trim(TemizIsim)
        Return TemizIsim
    End Function

    Public Shared Function WikiNameFormat(ByVal DirtyWiki)
        Dim TemizWiki = DirtyWiki
        TemizWiki = Replace(DirtyWiki, " ", "_")

        Return TemizWiki
    End Function








    Public Shared Function DescFormat(ByVal KirliFormat)
        Dim TemizFormat = KirliFormat


        TemizFormat = Replace(TemizFormat, "/wiki/File:", "http://www.holidaychoices.net/hc/pictures.aspx?pic=")
        TemizFormat = Replace(TemizFormat, "/wiki/", "http://www.holidaychoices.net/hc/en/search/")
        'TemizFormat = Replace(TemizFormat, "/wiki/", "./hc/en/search/")

        TemizFormat = Replace(TemizFormat, "href=" & Chr(34) & "/w/index.php?title=", "title=" & Chr(34))
        TemizFormat = Replace(TemizFormat, "Wikipedia:", "")



        TemizFormat = Replace(TemizFormat, "<div class=""thumb tright"">", "<div style='float: left;width:auto;margin-right:5px'>")
        TemizFormat = Replace(TemizFormat, "<div class=""thumb tleft"">", "<div style='float: left;width:auto;margin-right:5px'>")

        TemizFormat = Replace(TemizFormat, "<br>", "<br />")
        TemizFormat = Replace(TemizFormat, "<br /><br />", "<br />")
        TemizFormat = Replace(TemizFormat, vbCrLf & vbCrLf, vbCrLf)

        Return TemizFormat
    End Function




    Public Shared Function HtmlTemizle(ByVal Metin)
        Dim TemizData = Metin
        TemizData = System.Text.RegularExpressions.Regex.Replace(TemizData, "<[^>]*>", String.Empty)
        TemizData = Replace(TemizData, "&nbsp;", " ")
        Return TemizData
    End Function


    Public Shared Function RandomSec(ByVal Liste, ByVal KacTaneSec) 'Liste virgülle ayrılmış, son virgül şart
        Dim ReturnTxt

        Dim MyArr()
        MyArr = Liste.ToString.Split(",")

        Dim SecilenSayisi As Integer
        While Not UBound(MyArr) = 0
            Dim KS = UBound(MyArr) + 1 'kayit sayisi
            Dim RN As New Random(GetSeed())
            Dim MW = MyArr(RN.Next(0, KS))
            ReturnTxt = ReturnTxt & MW & ","

            Liste = Replace(Liste, MW & ",", "")
            MyArr = Liste.ToString.Split(",")

            SecilenSayisi = SecilenSayisi + 1
            If SecilenSayisi = KacTaneSec Then Exit While
        End While

        ReturnTxt = SonSil(ReturnTxt)
        Return ReturnTxt
    End Function
    Public Shared Function RandomNumber(ByVal KacHane As Integer, Optional ByVal MaxNumber As Integer = 9, Optional ByVal MinNumber As Integer = 0) As Integer

        Dim RandomSayi
        Dim r As New Random(GetSeed())
        Dim i
        For i = 1 To KacHane
            If MinNumber > MaxNumber Then
                Dim t As Integer = MinNumber
                MinNumber = MaxNumber
                MaxNumber = t
            End If
            RandomSayi = RandomSayi & r.Next(MinNumber, MaxNumber)
        Next
        Return RandomSayi
    End Function

    Public Shared Function RandomNumber2(ByVal MaxNumber As Integer, Optional ByVal MinNumber As Integer = 0) As Integer
        Dim RandomClass As New Random(GetSeed())
        Dim RN As Integer = RandomClass.Next(MinNumber, MaxNumber)
        Return RN
    End Function

    Shared Function GetSeed()
        Dim ByteArray As Byte() = New Byte(4) {}
        Dim rnd As New System.Security.Cryptography.RNGCryptoServiceProvider()
        rnd.GetBytes(ByteArray)
        Dim MySeed As Integer = CStr(BitConverter.ToInt32(ByteArray, 0))
        MySeed = Replace(MySeed, "-", "")
        Return MySeed
    End Function

    Public Shared Function KacTane(ByVal TumKelime, ByVal Aranacak)
        Dim MATCHES As MatchCollection = Regex.Matches(TumKelime, Aranacak)
        Return MATCHES.Count.ToString()


    End Function


    Public Shared Function IlkBulVeDegistir(ByVal TumKelime, ByVal Aranacak, ByVal YeniKelime)
        Dim TemizData As String = TumKelime

        Dim MatchCount As Integer, KacinciBulunanDegisecek, DegisecekKelime, DegisecekKelimeIndex

        Dim MATCHES As MatchCollection = Regex.Matches(TumKelime, Aranacak)
        MatchCount = MATCHES.Count.ToString()

        If MatchCount > 1 Then

            KacinciBulunanDegisecek = 0
            DegisecekKelime = MATCHES.Item(KacinciBulunanDegisecek).ToString
            DegisecekKelimeIndex = MATCHES.Item(KacinciBulunanDegisecek).Index

            TemizData = TemizData.Remove(DegisecekKelimeIndex, Len(DegisecekKelime))
            TemizData = TemizData.Insert(DegisecekKelimeIndex, YeniKelime)

            Return TemizData
        Else
            Return TemizData
        End If

    End Function
    Public Shared Function BulVeDegistir(ByVal TumKelime, ByVal Aranacak, ByVal YeniKelime, ByVal KacinciDegisecek)
        Dim TemizData As String = TumKelime

        Dim MatchCount As Integer, KacinciBulunanDegisecek, DegisecekKelime, DegisecekKelimeIndex

        Dim MATCHES As MatchCollection = Regex.Matches(TumKelime, Aranacak)
        MatchCount = MATCHES.Count.ToString()

        If MatchCount > 1 Then

            KacinciBulunanDegisecek = KacinciDegisecek
            DegisecekKelime = MATCHES.Item(KacinciBulunanDegisecek).ToString
            DegisecekKelimeIndex = MATCHES.Item(KacinciBulunanDegisecek).Index

            TemizData = TemizData.Remove(DegisecekKelimeIndex, Len(DegisecekKelime))
            TemizData = TemizData.Insert(DegisecekKelimeIndex, YeniKelime)

            Return TemizData
        Else
            Return TemizData
        End If

    End Function
    Public Shared Function BulVeRandomDegistir(ByVal TumKelime, ByVal Aranacak, ByVal YeniKelime)
        Dim TemizData As String = TumKelime

        Dim MatchCount As Integer, KacinciBulunanDegisecek, DegisecekKelime, DegisecekKelimeIndex

        Dim MATCHES As MatchCollection = Regex.Matches(TumKelime, Aranacak)
        MatchCount = MATCHES.Count.ToString()

        If MatchCount > 1 Then

            KacinciBulunanDegisecek = RandomNumber2(MatchCount, 1)
            DegisecekKelime = MATCHES.Item(KacinciBulunanDegisecek).ToString
            DegisecekKelimeIndex = MATCHES.Item(KacinciBulunanDegisecek).Index

            TemizData = TemizData.Remove(DegisecekKelimeIndex, Len(DegisecekKelime))
            TemizData = TemizData.Insert(DegisecekKelimeIndex, YeniKelime)

            Return TemizData
        Else
            Return TemizData
        End If

    End Function



    Public Shared Function BulVeSonunaEkle(ByVal TumKelime, ByVal Aranacak, ByVal YeniKelime)
        Dim TemizData As String = TumKelime

        Dim MatchCount As Integer, KacinciBulunanDegisecek, DegisecekKelime, DegisecekKelimeIndex

        Dim MATCHES As MatchCollection = Regex.Matches(TumKelime, Aranacak)
        MatchCount = MATCHES.Count.ToString()

        If MatchCount > 1 Then

            KacinciBulunanDegisecek = RandomNumber2(MatchCount, 1)
            DegisecekKelime = MATCHES.Item(KacinciBulunanDegisecek).ToString
            DegisecekKelimeIndex = MATCHES.Item(KacinciBulunanDegisecek).Index

            DegisecekKelimeIndex = DegisecekKelimeIndex + Len(DegisecekKelime)
            'TemizData = TemizData.Remove(DegisecekKelimeIndex, Len(DegisecekKelime))
            TemizData = TemizData.Insert(DegisecekKelimeIndex, YeniKelime)

            Return TemizData
        Else
            Return TemizData
        End If

    End Function





    Public Shared Function HighLight(ByVal TumKelime As String, ByVal Aranacak As String) As String
        Dim StartTag = "<span title='" & aTitle(Aranacak) & "' style=""color:black;background-color: yellow"">"
        Dim EndTag = "</span>"
        Dim YeniKelime = StartTag & Aranacak & EndTag

        Dim replacedString = Regex.Replace(TumKelime, Aranacak, YeniKelime, RegexOptions.IgnoreCase)
        Return replacedString
    End Function



    'Public Shared Sub DownloadFile(ByVal FilePath)
    '    FilePath = Server.MapPath(FilePath)

    '    Dim FILE As New FileInfo(FilePath)
    '    If (FILE.Exists) Then
    '        Response.ClearContent()

    '        'Response.AddHeader("Content-Disposition", "inline; filename=" + file.Name)
    '        Response.AddHeader("Content-Disposition", "attachment; filename=" + FILE.Name)
    '        Response.AddHeader("Content-Length", FILE.Length.ToString())


    '        'Response.ContentType = ReturnExtension(file.Extension.ToLower())

    '        Response.TransmitFile(FILE.FullName)
    '        Response.End()
    '    End If
    'End Sub


    'Public Shared Sub PrintForm() 'Use this in the form

    '    Dim sb As New StringBuilder()
    '    Dim oFormObject As System.Web.UI.Control
    '    Dim sMsg = "<script language=javascript>window.print()</script>"
    '    sb = New StringBuilder() : sb.Append(sMsg)

    '    For Each oFormObject In Me.Controls
    '        If TypeOf oFormObject Is HtmlForm Then
    '            Exit For
    '        End If
    '    Next
    '    oFormObject.Controls.AddAt(oFormObject.Controls.Count, New LiteralControl(sb.ToString()))
    'End Sub

    'Sub RegisterScripts()
    '    Button4.Attributes.Add("onclick", "return confirm('Bilgileri silmek istediğinize emin misiniz?');")
    'End Sub


    'Public Sub UserMsgBox(ByVal sMsg As String)

    '    Dim sb As New StringBuilder()
    '    Dim oFormObject As System.Web.UI.Control

    '    sMsg = sMsg.Replace("'", "\'")
    '    sMsg = sMsg.Replace(Chr(34), "\" & Chr(34))
    '    sMsg = sMsg.Replace(vbCrLf, "\n")
    '    sMsg = "<script language=javascript>alert(""" & sMsg & """)</script>"

    '    sb = New StringBuilder()
    '    sb.Append(sMsg)

    '    For Each oFormObject In Me.Controls
    '        If TypeOf oFormObject Is HtmlForm Then
    '            Exit For
    '        End If
    '    Next

    '    oFormObject.Controls.AddAt(oFormObject.Controls.Count, New LiteralControl(sb.ToString()))
    'End Sub

End Class
