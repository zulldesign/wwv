


Partial Class test3
    Inherits System.Web.UI.Page

    Dim docLogic As New fn_db_data
  




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'test1()
        'test2()
    End Sub
    Sub test1()
        Dim MyDataFromDB As New fn_db_data
        Dim MySubCatz As New class_decl_v10.SubCatNamez

        MySubCatz = MyDataFromDB.GetCatFORW(160)


        MsgBox(MySubCatz.SubCatIDz)
    End Sub

    Sub test2()

        Dim mystr As New StringBuilder
        For i = 1 To 10000000
            mystr = mystr.Append(i & ",")
        Next

        Dim MyTempIDs() = mystr.ToString.Split(",")

        Dim MyIDs() As Integer = Array.ConvertAll(MyTempIDs, Function(s) If(IsNumeric(s.ToString), Convert.ToInt32(s.ToString), Nothing))
        Array.Sort(MyIDs)
        Array.Reverse(MyIDs) 'son topic gelen önce.

        MsgBox(MyTempIDs(UBound(MyIDs) - 1).ToString)
        'MsgBox(MyIDs(456).ToString)
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox("%e9%a3%9f%e8%ad%9c")
        MsgBox(HttpUtility.UrlDecode("lamb neck goulash/  page"))

    End Sub
End Class
