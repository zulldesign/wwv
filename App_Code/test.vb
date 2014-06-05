Imports Microsoft.VisualBasic


Public Class Infoz

    Public Class MilesResponse
        Friend CurrentMiles As String
        Friend CurrentDays As String
    End Class

    Public Function Getmiles(ByVal journal As String) As MilesResponse
        Dim conn As New Data.SqlClient.SqlConnection
        Dim sql As String
        Dim objSql As Data.SqlClient.SqlCommand
        Dim MyDataReader As Data.SqlClient.SqlDataReader
        conn.ConnectionString = ConfigurationManager.ConnectionStrings("JournalCS").ConnectionString
        Dim _currmiles As String = Nothing
        Dim _currdays As String = Nothing
        sql = "SELECT cast(SUM(mile) as varchar(4)) AS milesum, cast(COUNT(mile) as varchar(3)) AS milecnt FROM Journal WHERE (mile <> 0)"
        objSql = New Data.SqlClient.SqlCommand(sql, conn)
        conn.Open()
        MyDataReader = objSql.ExecuteReader

        ' Declare return object
        Dim rsp As New MilesResponse

        While (MyDataReader.Read())
            '_currmiles = MyDataReader.Item("milesum")
            '_currdays = MyDataReader.Item("milecnt")
            ' Set object values
            rsp.CurrentMiles = MyDataReader.Item("milesum")
            rsp.CurrentDays = MyDataReader.Item("milecnt")

        End While
        conn.Close()

        Return rsp ' return Object of type MilesResponse
        'Return _currmiles.ToString
        'Return _currdays.ToString

    End Function

End Class