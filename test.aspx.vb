Imports html_tidy_v10

Imports System.Data
Imports System.Data.OleDb


Partial Class test
    Inherits System.Web.UI.Page

    Dim MyDB As New db_acc_v21_data
    Dim RecordsSTR, KacinciKayit

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click


        Dim MyHTML = ""
        MyHTML = MyHTML & "<html>"
        MyHTML = MyHTML & "<head> "
        MyHTML = MyHTML & "<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-16""> "
        MyHTML = MyHTML & "</head> "
        MyHTML = MyHTML & "<body>"
        MyHTML = MyHTML & "<p>Hello, <b><i>With German</b></i>: ���. Some Chinese: &#35754;.</p><br>"
        MyHTML = MyHTML & "<body>"
        MyHTML = MyHTML & "</html>"


       
        TextBox1.Text = HTML_Tidy(MyHTML)
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Dim M = "sErkan?kq[;,\\\\/:*?\""<>|&']+şlj&        '$%#@!*?;:~`+=()[]{}|\'<>,/^&jklşsd?,,:"

        'M = fn_general_v30.TextToURL(M)
        'MsgBox(M)

        Dim s = ""
        MsgBox(Left(s, 355))
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        myDataSet()
    End Sub
    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        myDataSet()
        'myDataReader()

    End Sub




    '*** DataReader ***'
    Sub myDataReader()
        Dim strSQL As String
        Dim DR As OleDbDataReader
        strSQL = "SELECT id,cat_name FROM categories "
        DR = MyDB.QueryDataReader(strSQL)

        Dim DataTable1 As New DataTable()
        DataTable1.Load(DR)
        ListView1.DataSource = DataTable1
        ListView1.DataBind()

        '*** Bind Rows ***'
        'If DR.HasRows = True Then
        '    Me.lblCustomerID.Text = dtReader.Item("CustomerID")
        '    Me.lblName.Text = dtReader.Item("Name")
        '    Me.lblEmail.Text = dtReader.Item("Email")
        '    Me.lblCountryCode.Text = dtReader.Item("CountryCode")
        '    Me.lblBudget.Text = dtReader.Item("Budget")
        '    Me.lblUsed.Text = dtReader.Item("Used")
        'End If

    End Sub

    '*** DataSet ***'
    Sub myDataSet()

        Dim TblName = "categories"
        Dim ColName = "id,cat_name"

        Dim strSQL As String

        strSQL = "SELECT id,cat_name FROM categories "
        Dim DS As DataSet
        DS = MyDB.QueryDataSet(strSQL)
        'Me.myGridView2.DataSource = ds.Tables(0).DefaultView
        'Me.myGridView2.DataBind()

        ListView1.DataSource = DS.Tables(0).DefaultView
        ListView1.DataBind()
        DS.Dispose()

        '*** Bind Rows ***'
        'Dim MySTR = "", i
        'Dim KS = DS.Tables(0).Rows.Count - 1 'Kayıt Sayısı
        'If KS > 0 Then
        '    For i = 0 To KS
        '        MySTR = MySTR & DS.Tables(0).Rows(i)("cat_name")
        '    Next
        '    Label1.Text = MySTR & i
        'End If

    End Sub

    '*** DataTable ***'
    Sub myDataTable()
        Dim strSQL As String
        Dim dt As DataTable
        strSQL = "SELECT * FROM customer "
        dt = MyDB.QueryDataTable(strSQL)
        'Me.myGridView3.DataSource = dt
        'Me.myGridView3.DataBind()

        ''*** Bind Rows ***'
        'If dt.Rows.Count > 0 Then
        '    Me.lblCustomerID.Text = dt.Rows(0)("CustomerID")
        '    Me.lblName.Text = dt.Rows(0)("Name")
        '    Me.lblEmail.Text = dt.Rows(0)("Email")
        '    Me.lblCountryCode.Text = dt.Rows(0)("CountryCode")
        '    Me.lblBudget.Text = dt.Rows(0)("Budget")
        '    Me.lblUsed.Text = dt.Rows(0)("Used")
        'End If


    End Sub

    '*** Execute Scalar ***'
    Sub myQueryExecuteScalar()
        Dim strSQL As String
        strSQL = "SELECT MAX(Budget) FROM customer "
        'Me.lblText.Text = MyDB.QueryExecuteScalar(strSQL)

    End Sub

    '*** ExecuteNonQuery ***'
    Sub myExecuteNonQuery()
        Dim strSQL1, strSQL2, strSQL3 As String

        '*** Insert ***'
        strSQL1 = "INSERT INTO customer (CustomerID,Name,Email,CountryCode,Budget,Used) " & _
        " VALUES('C005','Weerachai Nukitram','webmaster@thaicreate.com','TH','200000','100000')"
        If MyDB.QueryExecuteNonQuery(strSQL1) = True Then
            '*** Condition Success ***'
        Else
            '*** Condition Error ***'
        End If


        '*** Update ***'
        strSQL2 = "UPDATE customer SET Budget = '3000000' WHERE CustomerID = 'C005' "
        If MyDB.QueryExecuteNonQuery(strSQL2) = True Then
            '*** Condition Success ***'
        Else
            '*** Condition Error ***'
        End If


        '*** Delete ***'
        strSQL3 = "DELETE FROM customer WHERE CustomerID = 'C005' "
        If MyDB.QueryExecuteNonQuery(strSQL3) = True Then
            '*** Condition Success ***'
        Else
            '*** Condition Error ***'
        End If

    End Sub

    '*** Execute Transaction ***'
    Sub myExecuteTransaction()
        Dim strSQL1, strSQL2, strSQL3 As String

        '*** Start Transaction ***'
        MyDB.TransStart()

        Try
            '*** Insert ***'
            strSQL1 = "INSERT INTO customer (CustomerID,Name,Email,CountryCode,Budget,Used) " & _
            " VALUES('C005','Weerachai Nukitram','webmaster@thaicreate.com','TH','200000','100000')"
            MyDB.TransExecute(strSQL1) '*** Execute Query 1 ***'

            '*** Update ***'
            strSQL2 = "UPDATE customer SET Budget = '3000000' WHERE CustomerID = 'C005' "
            MyDB.TransExecute(strSQL2) '*** Execute Query 2 ***

            '*** Delete ***'
            strSQL3 = "DELETE FROM customer WHERE CustomerID = 'C005' "
            MyDB.TransExecute(strSQL3) '*** Execute Query 3 ***

            '*** Commit Transaction ***'
            MyDB.TransCommit()

        Catch ex As Exception
            '*** RollBack Transaction ***'
            MyDB.TransRollBack()
        End Try

    End Sub


    Public Sub PagePropertiesChanging(ByVal sender As Object, ByVal e As PagePropertiesChangingEventArgs)
        RecordsSTR = ""

        DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, False)
        ListView1.DataBind()
    End Sub


    Public Sub ComputeSum(ByVal sender As Object, ByVal e As ListViewItemEventArgs)
        If e.Item.ItemType = ListViewItemType.DataItem Then
            KacinciKayit = KacinciKayit + 1
            Dim dataItem As ListViewDataItem = CType(e.Item, ListViewDataItem)
            Dim rowView As DataRowView = CType(dataItem.DataItem, DataRowView)

            Dim R(8), i
            For i = 0 To 1
                R(i) = rowView(i).ToString()
                R(i) = DB_ReturnText(R(i))
            Next

            RecordsSTR = RecordsSTR & TopicData(R(0).ToString)

        End If
    End Sub
    Public Shared Function DB_ReturnText(ByVal StrToClear)
        If StrToClear = "" Then Exit Function
        Dim TemizData = StrToClear
        TemizData = Replace(TemizData, Chr(146), "'") ' (') işaretini (’) ile
        Return TemizData
    End Function

    Function TopicData(ByVal s1)

        Return s1
    End Function


    Public Shared Function GetDataFromWeb(ByVal wwwLink) 'KirliAd
        Dim URL As String = Trim(wwwLink)

        If Replace(URL, "http", "") <> URL Then
            URL = wwwLink
        Else
            URL = "http://" & wwwLink
        End If

        Dim xmlhttp = CreateObject("MSXML2.ServerXMLHTTP")
        xmlhttp.open("GET", URL, False)
        'Mozilla/4.0 (compatible; MSIE 8.0;)
        'xmlhttp.setRequestHeader("User-Agent", "eXtreme Browser")
        'xmlhttp.setRequestHeader("User-Agent", "Opera/9.00 (Windows NT 5.1; U; en)")
        xmlhttp.setRequestHeader("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)")
        xmlhttp.send("")

        Dim strVeri = xmlhttp.responseText

        xmlhttp = Nothing

        Return strVeri

    End Function



    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        TextBox1.Text = GetDataFromWeb("http://www.ex.gen.tr")
    End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
        'MsgBox(HttpUtility.UrlEncode("serjasdışfajşö"))
        MsgBox(HttpUtility.UrlDecode("cem-adrian-al-fadimem-%d9%83%d9%84%d9%85%d8%a7%d8%aa/"))
    End Sub
End Class

