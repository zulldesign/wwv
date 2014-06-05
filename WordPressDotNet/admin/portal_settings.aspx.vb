Imports db_acc_wpdn_v15
Imports fn_general_v17

Partial Class admin_portal_settings2
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = "Admin Panel | Modify Categories"

        Button1.Attributes.Add("onclick", "return confirm('Bilgileri silmek istediğinize emin misiniz?');")
        Button2.Attributes.Add("onclick", "return confirm('Bilgileri kaydetmek istediğinize emin misiniz?');")
        ListBoxAttributeYaz()

        If Not Page.IsPostBack Then
            FillData()
        End If
    End Sub

    Sub ListBoxAttributeYaz()
        CatList.Attributes.Add("ondblclick", ClientScript.GetPostBackEventReference(CatList, "FillSelected"))
        If Request("__EVENTARGUMENT") <> "" And Request("__EVENTARGUMENT") = "FillSelected" Then

            Dim idx = CatList.SelectedIndex
            Dim item As ListItem = CatList.SelectedItem
            'TalepBirimList.Items.Remove(item)
            FillData(item.Value)
        End If
    End Sub

    Sub FillData(Optional ByVal CatID = "")
        'CATEGORIES ===============================================================================================

        Dim TblName = "portal_conf"
        Dim ColName = "id,conf_name,conf_value"
        Dim WhereStr = "id=" & CatID & " "
        Dim OrderBy = "id ASC"


        Dim DR As System.Data.OleDb.OleDbDataReader
        If CatID = "" Then
            DR = DB_SELECT(TblName, ColName, , OrderBy)
        Else
            DR = DB_SELECT(TblName, ColName, WhereStr, OrderBy)
        End If


        If CatID = "" Then
            CatList.Items.Clear()
            While DR.Read = True
                Dim s As New ListItem
                s.Value = DR.GetValue(0).ToString
                s.Text = DR.GetValue(1).ToString & " | " & Left(DR.GetValue(2).ToString, 50)
                CatList.Items.Add(s)
            End While

        Else
            While DR.Read = True
                CatIDTxt.Text = DR.GetValue(0).ToString
                CatName.Text = DR.GetValue(1).ToString
                CatDesc.Text = DR.GetValue(2).ToString

            End While
        End If
        DR.Close()


    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SiteId
        SiteId = CatList.SelectedItem.Value

        Dim TblName = "portal_conf"
        Dim WhereStr = "id=" & SiteId & ""
        DB_DELETE(TblName, WhereStr)

        Label1.Text = Warn("Kategori Silindi!")

        FillData()

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        CheckIfExist()
    End Sub
    Sub CheckIfExist()

        Dim TblName = "portal_conf"
        Dim ColName = "id"

        Dim DR As System.Data.OleDb.OleDbDataReader
        DR = DB_SELECT(TblName, ColName)

        Dim Bulundu = "hayir"
        While dr.Read = True
            If dr.GetValue(0).ToString = CatIDTxt.Text Then
                Bulundu = "evet"
                Exit While
            End If
        End While

        dr.Close()

        If Bulundu = "evet" Then
            UpdateYap()
        Else
            Kaydet()
        End If

    End Sub
    Sub UpdateYap()
        Dim q1, q2, q3, q4, q5, q6, q7, q8, q9, q10, q11, q12, q13
        q1 = CatIDTxt.Text
        q2 = CatName.Text
        q3 = CatDesc.Text


        Dim TblName = "portal_conf"
        Dim ColNames = "conf_name¦¦conf_value"
        Dim ValNames = "'" + q2 + "'¦¦'" + q3 + "'"
        Dim WhereStr = "[id]=" & q1 & ""

        DB_UPDATE(TblName, ColNames, ValNames, WhereStr)

        TxtClear()
        Label1.Text = Warn("Kayıt Düzenlendi!")

        CatList.Items.Clear()
        FillData()
    End Sub
    Sub Kaydet()

        Dim q1, q2, q3, q4, q5, q6, q7, q8, q9, q10, q11, q12, q13
        'id, web_word,	title,	desc,	keywords,	site1,	link1,	site2,	link2,	site3,	link3 
        q1 = CatIDTxt.Text
        q2 = CatName.Text
        q3 = CatDesc.Text


        Dim TblName = "portal_conf"
        Dim ColNames = "conf_name,conf_value"
        Dim ValNames = "'" + q2 + "','" + q3 + "'"
        DB_INSERT(TblName, ColNames, ValNames)


        TxtClear()
        Label1.Text = Warn("Kayıt Eklendi!")

        CatList.Items.Clear()
        FillData()
    End Sub
    Sub TxtClear()
        CatIDTxt.Text = ""
        CatName.Text = ""
        CatDesc.Text = ""


    End Sub



    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Response.Redirect("categories.aspx")
    End Sub

End Class
