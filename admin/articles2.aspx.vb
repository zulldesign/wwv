
Partial Class admin_articles
    Inherits System.Web.UI.Page



    Sub InitiateControls()



        Dim I As Integer
        For I = 1 To 3
            Dim myTextBox As New TextBox
            myTextBox.ID = "txtDynamic" & I
            myTextBox.Text = "Control Number:" & I
            Me.Label1.Controls.Add(myTextBox)
            Dim myLiteral As New LiteralControl
            myLiteral.Text = "<BR><BR>"
            Me.Label1.Controls.Add(myLiteral)
        Next
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            InitiateControls2()
        End If


    End Sub



    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        InitiateControls()


        ' Find control on page.
        Dim myControl1 As Control = Me.Master.FindControl("ContentPlaceHolder1").FindControl("txtDynamic1")
        If (Not myControl1 Is Nothing) Then
            Dim s As TextBox
            s = myControl1
            MsgBox(s.Text)
        Else
            Response.Write("Control not found.....")
        End If


    End Sub

    Sub InitiateControls2()

        Dim MyTable As New db_structure_v10.Tbl_Users

        Dim ColCount As Integer = MyTable.ColCount 'columns count

        Dim Columnz() = MyTable.Controlz

        Dim i As Integer
        For i = 0 To UBound(Columnz)

            Dim myTextBox As New TextBox
            myTextBox.ID = Columnz(i).ToString
            myTextBox.Text = Columnz(i).ToString

            Me.Label1.Controls.Add(myTextBox)
            Dim myLiteral As New LiteralControl
            myLiteral.Text = "<br /><br />"
            Me.Label1.Controls.Add(myLiteral)
        Next
    End Sub



End Class
