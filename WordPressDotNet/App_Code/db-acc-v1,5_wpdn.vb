Imports Microsoft.VisualBasic
Imports System.Data.OleDb


Public Class db_acc_wpdn_v15

    Public Shared DBPass = "extremeteam"
    Public Shared ServerPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath
    Public Shared DBPath = ServerPath & "databases/database.mdb"
    'Shared DBPath = ServerPath & "cubuk-tursusu/blog/databases/database.mdb"

    Shared ConnSTR As String = "PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA SOURCE=" + DBPath & ";Jet OLEDB:Database Password=" & DBPass & ""
    Shared CONN As OleDbConnection = New OleDbConnection(ConnSTR)

    Public Shared Sub DB_CONN_CLOSE()
        If CONN.State <> Data.ConnectionState.Closed Then CONN.Close()
    End Sub


    Public Shared Function DB_SELECT(ByVal TableName, ByVal ColumnNames, Optional ByVal WhereStr = "NO", Optional ByVal OrderBy = "NO", Optional ByVal KeepConnected = "NO")

        Dim DR As OleDbDataReader
        Dim SQLStr

        If WhereStr = "NO" Then
            SQLStr = "SELECT " & ColumnNames & " FROM " & TableName
        Else
            SQLStr = "SELECT " & ColumnNames & " FROM " & TableName & " WHERE " & WhereStr
        End If
        If OrderBy <> "NO" Then
            SQLStr = SQLStr & " ORDER BY " & OrderBy
        End If

        Dim CMD As OleDbCommand = New OleDbCommand(SQLStr, CONN)
        If CONN.State <> Data.ConnectionState.Open Then CONN.Open()
        DR = CMD.ExecuteReader
        Return DR

        'DR.Close() ### BUNLAR ZATEN ÇALIŞMIYOR (MANUEL KAPAT) ####
        'CONN.Close()

        ''DB_SELECT USAGE ******************************
        'Dim TblName = "users"
        'Dim ColName = "sifre,email"
        'Dim WhereStr = "email='" & UserTxt.Text & "'"

        'Dim DR As System.Data.OleDb.OleDbDataReader
        'DR = DB_SELECT( TblName, ColName, WhereStr) 'DR.Close() :  DB_CONN_CLOSE()

        'If DR.HasRows = "False" Then
        '    Label1.Text = "<a class='wrong'>Kullanıcı Adı veya Şifre Yanlış!</a>"
        '    DR.Close() : Exit Function
        'End If

        'Dim Result
        'While DR.Read = True
        '    Result = DR.GetValue(0).ToString 'Şifre
        'End While
        'DR.Close() : DB_CONN_CLOSE()
        ''DB_SELECT USAGE *****************************

    End Function

    Public Shared Sub DB_INSERT(ByVal TableName, ByVal ColumnNames, ByVal Values, Optional ByVal KeepConnected = "NO")

        Dim SQLStr = "INSERT INTO " & TableName & " (" & ColumnNames & ") VALUES " & "(" & Values & ")"
        Dim CMD As OleDbCommand = New OleDbCommand(SQLStr, CONN)

        If CONN.State <> Data.ConnectionState.Open Then CONN.Open()
        CMD.ExecuteNonQuery()
        If KeepConnected = "NO" Then
            CONN.Close()
        End If

        ''DB_INSERT USAGE ***********************************************************************
        'Q(1) = "ss@ss.com"
        'Q(2) = "serkan"
        'Q(3) = "serkan"
        'Q(4) = "serkan"
        'Dim i
        'For i = 1 To 4
        '    DB_ClearText(Q(i))
        'Next
        'Dim TblName = "users"
        'Dim ColNames = "[email],	[password], [name],	[surname]"
        'Dim ValNames = "'" & Q(1) & "','" & Q(2) & "','" & Q(3) & "','" & Q(4) & "'"
        'DB_INSERT(TblName, ColNames, ValNames)
        ''DB_INSERT USAGE ***********************************************************************
    End Sub

    Public Shared Sub DB_DELETE(ByVal TableName, ByVal WhereStr, Optional ByVal ColumnNames = "*", Optional ByVal KeepConnected = "NO")

        Dim SQLStr = "DELETE " & ColumnNames & " FROM " & TableName & " WHERE " & WhereStr
        Dim CMD As OleDbCommand = New OleDbCommand(SQLStr, CONN)

        If CONN.State <> Data.ConnectionState.Open Then CONN.Open()
        CMD.ExecuteNonQuery()
        If KeepConnected = "NO" Then
            CONN.Close()
        End If

        ''DB_DELETE USAGE ******************************
        'Dim TblName = "referral"
        'Dim WhereStr = "sayfa=2233234"
        'DB_DELETE( TblName, WhereStr)
        ''DB_DELETE USAGE ******************************
    End Sub

    Public Shared Sub DB_UPDATE(ByVal TableName, ByVal ColumnNames, ByVal Values, Optional ByVal WhereStr = "NO", Optional ByVal KeepConnected = "NO")
        Dim Columnlar(), Valueler(), SETStr, i

        Columnlar = ColumnNames.ToString.Split("¦¦")
        Valueler = Values.ToString.Split("¦¦")

        If UBound(Columnlar) <> UBound(Valueler) Then
            MsgBox("Column Sayisi Value Sayisina Esit Degil")
            Exit Sub
        End If

        For i = 0 To UBound(Columnlar)
            If Trim(Columnlar(i).ToString) <> "" Then
                SETStr = SETStr & Columnlar(i).ToString & "=" & Valueler(i).ToString & ","
            End If
        Next
        SETStr = Left(SETStr, (Len(SETStr) - 1)) 'Son virgülden kurtarıyoruz.
        'MsgBox(SETStr)

        Dim SQLStr

        If WhereStr = "NO" Then
            SQLStr = "UPDATE " & TableName & " SET " & SETStr & ""
        Else
            SQLStr = "UPDATE " & TableName & " SET " & SETStr & " WHERE  " & WhereStr & ""
        End If

        Dim CMD As OleDbCommand = New OleDbCommand(SQLStr, CONN)
        If CONN.State <> Data.ConnectionState.Open Then CONN.Open()
        CMD.ExecuteNonQuery()

        If KeepConnected = "NO" Then
            CONN.Close()
        End If

        ''DB_UPDATE USAGE **********************************************************
        'Q(1) = "ss@ss.com"
        'Q(2) = "serkan"
        'Q(3) = "serkan"
        'Q(4) = "serkan"
        'Dim i
        'For i = 1 To 4
        '    DB_ClearText(Q(i))
        'Next
        'Dim TblName = "users"
        'Dim ColName = "[email]¦¦[password]¦¦[name]¦¦[surname]"
        'Dim ValName = "'" & Q(1) & "'¦¦'" & Q(2) & "'¦¦'" & Q(3) & "'¦¦'" & Q(4) & "'"
        'Dim WhereStr = "[id]=" & Session("UserId") & ""


        'DB_UPDATE(TblName, ColName, ValName,WhereStr)
        ''DB_UPDATE USAGE **********************************************************

    End Sub









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
        If StrToClear = "" Then Exit Function
        Dim TemizData = Trim(StrToClear)
        'TemizData = Replace(TemizData, "'", "''") '  (') işareti
        'TemizData = Replace(TemizData, Chr(34), Chr(148)) '  (") işareti (”) ile
        'TemizData = Replace(TemizData, Chr(39), Chr(146)) '  (') işaretini (’) ile
        'TemizData = Replace(TemizData, Chr(44), Chr(130)) '  (,) işaretini (‚) ile
        TemizData = Replace(TemizData, Chr(34), """") '  (") işareti
        TemizData = Replace(TemizData, "'", "''") '  (') işareti
        Return TemizData
    End Function


End Class
