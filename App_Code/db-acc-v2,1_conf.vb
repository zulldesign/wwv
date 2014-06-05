Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.Configuration

Public Class db_acc_v21_conf

    Private objConn As OleDbConnection
    Private objCmd As OleDbCommand
    Private Trans As OleDbTransaction


    'Public Shared ServerPath As String = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath

    Private Const DBPath = wpdn_v10.MyDBConfPath
    Private Const DBPass = wpdn_v10.MyDBPass

    Private Const ConnSTR As String = "PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA SOURCE=" + DBPath & ";Jet OLEDB:Database Password=" & DBPass & ";OLE DB Services=-1"





    Sub ConnOpen()
        objConn = New OleDbConnection
        objConn.ConnectionString = ConnSTR
        objConn.Open()
    End Sub

    Public Sub ConnClose()
        If objConn IsNot Nothing Then
            objConn.Close()
            objConn = Nothing
        End If
    End Sub

    Public Function TruncateTable(ByVal TableName As String, Optional AutoIncColumnName As String = "")

        Dim SQLStr1 = "DELETE * FROM " & TableName & ""

        Dim SQLStr2 = "ALTER TABLE " & TableName & " ALTER COLUMN " & AutoIncColumnName & " COUNTER(1,1)"

        ConnOpen()


        If AutoIncColumnName <> "" Then
            objCmd = New OleDbCommand()
            With objCmd
                .Connection = objConn
                .CommandType = CommandType.Text
                .CommandText = SQLStr1
            End With
            objCmd.ExecuteNonQuery()

            objCmd = New OleDbCommand()
            With objCmd
                .Connection = objConn
                .CommandType = CommandType.Text
                .CommandText = SQLStr2
            End With
            objCmd.ExecuteNonQuery()

        Else
            objCmd = New OleDbCommand()
            With objCmd
                .Connection = objConn
                .CommandType = CommandType.Text
                .CommandText = SQLStr1
            End With
            objCmd.ExecuteNonQuery()
        End If


        ConnClose()


    End Function

    Public Function QueryDataReader(ByVal strSQL As String) As OleDbDataReader

        ConnOpen()
        objCmd = New OleDbCommand(strSQL, objConn)

        Dim dtReader As OleDbDataReader
        dtReader = objCmd.ExecuteReader()

        ConnClose()
        Return dtReader '*** Return DataReader ***'
    End Function

    Public Function QueryDataSet(ByVal strSQL As String) As DataSet
        ConnOpen()

        objCmd = New OleDbCommand
        With objCmd
            .Connection = objConn
            .CommandText = strSQL
            .CommandType = CommandType.Text
        End With

        Dim dtAdapter As New OleDbDataAdapter : Dim ds As New DataSet
        dtAdapter.SelectCommand = objCmd
        dtAdapter.Fill(ds)

        ConnClose()
        Return ds   '*** Return DataSet ***'
    End Function

    Public Function QueryDataTable(ByVal strSQL As String) As DataTable

        ConnOpen()

        Dim dtAdapter As OleDbDataAdapter : Dim dt As New DataTable
        dtAdapter = New OleDbDataAdapter(strSQL, objConn)
        dtAdapter.Fill(dt)

        ConnClose()
        Return dt '*** Return DataTable ***'
    End Function

    Public Function QueryExecuteNonQuery(ByVal strSQL As String) As Boolean
        ConnOpen()

        objCmd = New OleDbCommand()
        With objCmd
            .Connection = objConn
            .CommandType = CommandType.Text
            .CommandText = strSQL
        End With
        objCmd.ExecuteNonQuery()

        ConnClose()
    End Function

    Public Function QueryExecuteScalar(ByVal strSQL As String) As Object

        ConnOpen()

        objCmd = New OleDbCommand()
        With objCmd
            .Connection = objConn
            .CommandType = CommandType.Text
            .CommandText = strSQL
        End With

        Dim obj As Object
        obj = objCmd.ExecuteScalar()  '*** Return Scalar ***'

        ConnClose()
        Return obj

    End Function

    Public Function TransStart()
        ConnOpen()
        Trans = objConn.BeginTransaction(IsolationLevel.ReadCommitted)
    End Function

    Public Function TransExecute(ByVal strSQL As String) As Boolean
        objCmd = New OleDbCommand()
        With objCmd
            .Connection = objConn
            .Transaction = Trans
            .CommandType = CommandType.Text
            .CommandText = strSQL
        End With
        objCmd.ExecuteNonQuery()
    End Function

    Public Function TransRollBack()
        Trans.Rollback()
    End Function

    Public Function TransCommit()
        Trans.Commit()

        ConnClose()
    End Function




    Public Function DB_SelectSTR(ByVal TableName, ByVal ColumnNames, Optional ByVal WhereStr = "", Optional ByVal OrderBy = "")
        'QueryType = DataReader | DataSet | DataTable 
        Dim SQLStr = "SELECT " & ColumnNames & " FROM " & TableName
        If WhereStr <> "" Then SQLStr = SQLStr & " WHERE " & WhereStr & ""
        If OrderBy <> "" Then SQLStr = SQLStr & " ORDER BY " & OrderBy & ""
        Return SQLStr


        '############ DataReader USAGE ###############################################
        'Dim TblName = "cards"
        'Dim ColName = "id,	word,	tabu1,	tabu2,	tabu3,	tabu4,	tabu5,	difficulty"
        'Dim SqlStr = MyDB.DB_SelectSTR(TblName, ColName, , OrderBy)
        'Dim DR As System.Data.OleDb.OleDbDataReader
        'DR = MyDB.QueryDataReader(SqlStr)


        'Dim DataTable1 As New System.Data.DataTable()
        'DataTable1.Load(DR)
        'DR.Close()

        'ListView1.DataSource = DataTable1
        'ListView1.DataBind()
        '############ DataReader USAGE END ###############################################


        '############ DataSet USAGE ###############################################
        'Dim TblName = "cards"
        'Dim ColName = "id,	word,	tabu1,	tabu2,	tabu3,	tabu4,	tabu5,	difficulty"
        'Dim SqlStr = MyDB.DB_SelectSTR(TblName, ColName, , OrderBy)
        'Dim DS As System.Data.DataSet
        'DS = MyDB.QueryDataSet(SqlStr)
        'ListView1.DataSource = DS.Tables(0).DefaultView
        'ListView1.DataBind()
        'Dim MySTR = "", i
        'Dim KS = ds.Tables(0).Rows.Count 'Kayıt Sayısı
        'If KS > 0 Then
        '    For i = 0 To KS - 1
        '        MySTR = MySTR & ds.Tables(0).Rows(i)("link") & ","
        '    Next
        'End If
        'ds.Dispose()
        '############ DataSet USAGE END ###############################################


        '############ DataTable USAGE ###############################################
        'Dim TblName = "cards"
        'Dim ColName = "id,	word,	tabu1,	tabu2,	tabu3,	tabu4,	tabu5,	difficulty"
        'Dim SqlStr = MyDB.DB_SelectSTR(TblName, ColName, , OrderBy)

        'Dim DT As System.Data.DataTable
        'DT = MyDB.QueryDataTable(SqlStr)

        'Dim MySTR = "", i
        'Dim KS = DT.Rows.Count 'Kayıt Sayısı
        'If KS > 0 Then
        '    For i = 0 To KS - 1
        '        MySTR = MySTR & DT.Rows(i)("link") & ","
        '        MySTR2 = DT.Rows(i).Item(1).ToString()
        '    Next
        'End If
        '############ DataTable USAGE END ###############################################
    End Function
    Public Function DB_InsertSTR(ByVal TableName, ByVal ColumnNames, ByVal Values)
        Dim SQLStr = "INSERT INTO " & TableName & " (" & ColumnNames & ") VALUES " & "(" & Values & ")"
        Return SQLStr

        ''############ USAGE ###############################################
        'Dim Q(10)

        'For i = 1 To 10
        '    Q(i) = fn_general_v30.DB_ClearText(Q(i))
        'Next

        'Dim TblName = "referrals"
        'Dim ColNames = "link,[page],[datetime]"
        'Dim ValNames = "'" + Q(1) + "','" + Q(2) + "'," + Q(3) + ""

        'Dim SqlStr = MyDB.DB_InsertSTR(TblName, ColNames, ValNames)
        'MyDB.QueryExecuteNonQuery(SqlStr)

    End Function
    Public Function DB_UpdateSTR(ByVal TableName, ByVal ColumnNames, ByVal Values, Optional ByVal WhereStr = "NO")
        Dim Columnlar(), Valueler(), SETStr, i

        Columnlar = ColumnNames.ToString.Split("¦¦")
        Valueler = Values.ToString.Split("¦¦")

        If UBound(Columnlar) <> UBound(Valueler) Then
            MsgBox("Column Sayisi Value Sayisina Esit Degil")
            Exit Function
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
        Return SQLStr

        ''############ USAGE ###############################################
        'Dim Q(10)
        'For i = 1 To 10
        '    Q(i) = fn_general_v30.DB_ClearText(Q(i))
        'Next
        'Dim TblName = "users"
        'Dim ColName = "[email]¦¦[password]¦¦[name]¦¦[surname]"
        'Dim ValName = "'" & Q(1) & "'¦¦'" & Q(2) & "'¦¦'" & Q(3) & "'¦¦'" & Q(4) & "'"
        'Dim WhereStr = "[id]=" & Session("UserId") & ""

        'Dim SqlStr = MyDB.DB_UpdateSTR(TblName, ColName, ValName, WhereStr)
        'MyDB.QueryExecuteNonQuery(SqlStr)
    End Function
    Public Function DB_DeleteSTR(ByVal TableName, ByVal WhereStr, Optional ByVal ColumnNames = "*")
        Dim SQLStr = "DELETE " & ColumnNames & " FROM " & TableName & " WHERE " & WhereStr
        Return SQLStr


        ''############ USAGE ###############################################
        'Dim TblName = "content"
        'Dim WhereStr = "[id]=" & MyID

        'Dim SqlSTR = MyDB.DB_DeleteSTR(TblName, WhereStr)
        'MyDB.QueryExecuteNonQuery(SqlSTR)
    End Function


End Class