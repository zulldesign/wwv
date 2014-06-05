Imports System.IO
Imports TidyNet

Public Class html_tidy_v10

    Public Shared Function HTML_Tidy(ByVal MyText)

        If String.IsNullOrEmpty(MyText) Then Return MyText

        Dim tidy As New Tidy()
        ' Set the options you want 
        tidy.Options.DocType = DocType.Strict
        tidy.Options.DropFontTags = True
        tidy.Options.LogicalEmphasis = True
        tidy.Options.Xhtml = True
        tidy.Options.XmlOut = True
        tidy.Options.MakeClean = True
        tidy.Options.TidyMark = False

        ' Declare the parameters that is needed 

        Dim tmc As New TidyMessageCollection()
        Dim input As New MemoryStream()
        Dim output As New MemoryStream()

        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(MyText)
        input.Write(byteArray, 0, byteArray.Length)
        input.Position = 0
        tidy.Parse(input, output, tmc)

        Dim result As String = Encoding.UTF8.GetString(output.ToArray())



        Dim ClrSTR As String = result
        ClrSTR = Replace(ClrSTR, "<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Strict//EN""", "")
        ClrSTR = Replace(ClrSTR, "    ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"">", "")
        ClrSTR = Replace(ClrSTR, "<html xmlns=""http://www.w3.org/1999/xhtml"">", "")
        ClrSTR = Replace(ClrSTR, "<head>", "")
        ClrSTR = Replace(ClrSTR, "<meta http-equiv=""Content-Type""", "")
        ClrSTR = Replace(ClrSTR, "content=""text/html; charset=utf-16"" />", "")
        ClrSTR = Replace(ClrSTR, "<title></title>", "")
        ClrSTR = Replace(ClrSTR, "</head>", "")
        ClrSTR = Replace(ClrSTR, "<body>", "")
        ClrSTR = Replace(ClrSTR, "</body>", "")
        ClrSTR = Replace(ClrSTR, "</html>", "")

        ClrSTR = Replace(ClrSTR, vbCrLf & vbCrLf, "") 'boşlukları al


        Return ClrSTR
    End Function

End Class
