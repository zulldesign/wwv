Imports Microsoft.VisualBasic
Imports System.IO


Public Class fn_general_v17


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
    End Sub

    'Button1.Attributes.Add("onclick", "return confirm('Bilgileri kaydetmek istediğinize emin misiniz?');")

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

    Public Shared Function SonSil(ByVal MyTxt As String)
        MyTxt = Left(MyTxt, Len(MyTxt) - 1)
        Return MyTxt
    End Function



    Public Shared Function RandomSec(ByVal Liste, ByVal KacTaneSec) 'Liste virgülle ayrılmış, son virgül şart
        Dim ReturnTxt

        Dim MyArr()
        MyArr = Liste.ToString.Split(",")

        Dim SecilenSayisi As Integer
        While Not UBound(MyArr) = 0
            Dim KS = UBound(MyArr) 'kayit sayisi
            Dim RN As New Random()
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
        Dim MyTopluLink
        For i = 0 To UBound(MyLinks)
            Dim LinkText, TitLink, ForSRCH
            Dim MyLink = Trim(MyLinks(i).ToString)
            LinkText = MyLink
            TitLink = aTitle(MyLink)
            ForSRCH = ForURL(MyLink)

            If OutputAYRAC <> "" Then
                MyTopluLink = MyTopluLink & "<a class='" & KLAS & "' target='_self' title='" & TitLink & "' href='" & LinkWWW & ForSRCH & "'>" & LinkText & "</a>" & OutputAYRAC
            Else
                MyTopluLink = MyTopluLink & "<a class='" & KLAS & "' target='_self' title='" & TitLink & "' href='" & LinkWWW & ForSRCH & "'>" & LinkText & "</a>"
            End If

        Next
        Return Left(MyTopluLink, Len(MyTopluLink) - 2)
    End Function
    Public Shared Function MakeLink(ByVal LinkName, ByVal LinkWWW)
        Dim OrjLink = LinkName
        LinkName = Replace(LinkName, "'", "")
        LinkName = Replace(LinkName, Chr(34), "")
        LinkName = Replace(LinkName, ")", "")
        LinkName = Replace(LinkName, "(", "")
        LinkName = Replace(LinkName, ".", "")
        LinkName = Replace(LinkName, ",", "")
        LinkName = Trim(LinkName)
        Dim MyLink = "<a target='_blank' title='" & LinkName & "' href='" & LinkWWW & "'>" & OrjLink & "</a>"
        Return MyLink
    End Function
    Public Shared Function aTitle(ByVal LinkName)
        LinkName = Replace(LinkName, "'", "")
        LinkName = Replace(LinkName, Chr(34), "")
        LinkName = Replace(LinkName, ")", "")
        LinkName = Replace(LinkName, "(", "")
        LinkName = Replace(LinkName, ".", "")
        LinkName = Replace(LinkName, ",", "")
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

    Public Shared Function FileNameFromPath(ByVal FileFullPath As String) As String
        'EXAMPLE: input ="C:\winnt\system32\kernel.dll, 
        'output = kernel.dll

        Dim intPos As Integer
        intPos = FileFullPath.LastIndexOfAny("\")
        intPos += 1
        Return FileFullPath.Substring(intPos, _
            (Len(FileFullPath) - intPos))
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
            Return False
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


    Public Shared Function ForURL(ByVal UrlText)
        Dim Cleared = Trim(UrlText)

        Cleared = LCase(Cleared)
        Cleared = Trim(Cleared)


        Cleared = Replace(Cleared, Chr(34), "")
        Cleared = Replace(Cleared, ",", "%2C")
        'Cleared = Replace(Cleared, ",", "")
        'Cleared = Replace(Cleared, " ", "%20")
        Cleared = Replace(Cleared, " ", "-")
        Cleared = Replace(Cleared, ":", "")
        Cleared = Replace(Cleared, ";", "")
        Cleared = Replace(Cleared, ".", "")
        Cleared = Replace(Cleared, "'", "%27")
        'Cleared = Replace(Cleared, "'", "-")

        'Cleared = Replace(Cleared, "(", "-")
        'Cleared = Replace(Cleared, ")", "-")

        Cleared = Replace(Cleared, "/", "%2F")


        Cleared = Replace(Cleared, "ã", "a")
        Cleared = Replace(Cleared, "ä", "a")
        Cleared = Replace(Cleared, "ç", "c")
        Cleared = Replace(Cleared, "é", "e")
        Cleared = Replace(Cleared, "í", "i")
        Cleared = Replace(Cleared, "ü", "u")
        Cleared = Replace(Cleared, "ş", "s")
        Cleared = Replace(Cleared, "ı", "i")
        Cleared = Replace(Cleared, "ğ", "g")
        Cleared = Replace(Cleared, "ö", "o")
        Cleared = Replace(Cleared, "ñ", "n")

        Cleared = Trim(Cleared)
        Return Cleared
    End Function

    Public Shared Function ForSearch(ByVal KirliAd)
        Dim TemizIsim = KirliAd
        TemizIsim = Replace(TemizIsim, "'", " ")
        TemizIsim = Replace(TemizIsim, ":", " ")
        TemizIsim = Replace(TemizIsim, "_", " ")
        TemizIsim = Replace(TemizIsim, "-", " ")
        TemizIsim = Replace(TemizIsim, ".", " ")
        TemizIsim = Replace(TemizIsim, Chr(34), " ")
        TemizIsim = Trim(TemizIsim)
        Return TemizIsim
    End Function

    Public Shared Function WikiNameFormat(ByVal DirtyWiki)
        Dim TemizWiki = DirtyWiki
        TemizWiki = Replace(DirtyWiki, " ", "_")

        Return TemizWiki
    End Function



    Public Shared Function LinkTemizle(ByVal Linkimiz)

        Dim TemizLink = LCase(Linkimiz)
        TemizLink = Replace(TemizLink, "aq=", "")

        Dim SP As Integer, EP As Integer 'StartPoint, EndPoint
        Dim i
        For i = 1 To Len(TemizLink)
            If Mid(TemizLink, i, 2) = "q=" Then
                SP = i + 2
                Exit For
            End If
        Next

        If SP > 0 Then
            For i = SP To Len(TemizLink)
                If Mid(TemizLink, i, 1) = "&" Then
                    EP = i
                    Exit For
                End If
            Next
        End If

        'MsgBox(EP & "-" & SP)

        If EP = SP Or SP = 0 Or EP = 0 Then
            Return "YANLIS"
            Exit Function
        End If


        TemizLink = Mid(TemizLink, SP, (EP - SP))
        TemizLink = Replace(TemizLink, "+", " ")



        TemizLink = Replace(TemizLink, "%22", "")
        TemizLink = Replace(TemizLink, "%20", " ")
        TemizLink = Replace(TemizLink, "%2b", " ")
        'TemizLink = Replace(TemizLink, "%2f", "/")

        'TemizLink = Replace(TemizLink, "%c3%b6", "ö")
        'TemizLink = Replace(TemizLink, "%c3%a5", "å")


        'YANLISLAR
        Dim YanlisKelimeler, YK()
        YanlisKelimeler = "www,http,.com,.net,.org,.eu,.tr,.info"
        YK = Split(YanlisKelimeler, ",")
        For i = 0 To UBound(YK)
            If Replace(TemizLink, YK(i), "") <> TemizLink Then
                Return "YANLIS"
                Exit Function
            End If
        Next

        Return TemizLink

        'Return Linkimiz

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


    Public Shared Function RandomNumber(ByVal KacHane As Integer, Optional ByVal MaxNumber As Integer = 9, Optional ByVal MinNumber As Integer = 0) As Integer

        Dim RandomSayi
        Dim r As New Random(System.DateTime.Now.Millisecond)
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

        Dim r As New Random(System.DateTime.Now.Millisecond)
        If MinNumber > MaxNumber Then
            Dim t As Integer = MinNumber
            MinNumber = MaxNumber
            MaxNumber = t
        End If
        Return r.Next(MinNumber, MaxNumber)
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


End Class
