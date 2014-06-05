

Partial Class referrals
    Inherits System.Web.UI.Page

    Dim RecordsSTR, KacinciKayit
    Dim MyDB As New db_acc_v21_data

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = "Referrals"
        If Not Page.IsPostBack Then
            LoadData()
        End If
    End Sub

    Sub LoadData()
        Dim TblName = "referrals"
        Dim ColName = "[id],[link],[page],[datetime]"
        Dim OrderBy = "[datetime] DESC"

        Dim SqlStr = MyDB.DB_SelectSTR(TblName, ColName, , OrderBy)

        Dim DS As System.Data.DataSet
        DS = MyDB.QueryDataSet(SqlStr)

        ListView1.DataSource = DS.Tables(0).DefaultView
        ListView1.DataBind()
        DS.Dispose()


        RecordsSTR = "<table >" & RecordsSTR & "</table>"
        TopicTxt.Text = RecordsSTR
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
            Dim rowView As System.Data.DataRowView = CType(dataItem.DataItem, System.Data.DataRowView)

            Dim R(3), i
            For i = 0 To 3
                R(i) = rowView(i).ToString()
                R(i) = fn_general_v30.DB_ReturnText(R(i))
            Next

            RecordsSTR = RecordsSTR & TopicData(R(0).ToString, R(1).ToString, R(2).ToString, R(3).ToString)
        End If
    End Sub
    Function TopicData(ByVal id, ByVal link, ByVal page, ByVal datetime)
        Dim MySTR = ""

        MySTR = "<tr ><td >" & id & "</td><td> | <a target='_blank' href='http://google.com/search?q=" & link & "'>" & link & "</a></td><td> | " & page & "</td><td> | " & datetime & "</td></tr>"

        Return MySTR
    End Function
End Class
