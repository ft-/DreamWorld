
Imports Mysql.Data.MySqlClient
Imports System.IO

Public Class Mysql

    Public Sub New()

        Dim connStr = "server=" + "localhost" _
            + ";database=" + My.Settings.RobustMySqlName _
            + ";port=" + My.Settings.MySqlPort _
            + ";user=" + My.Settings.RobustMySqlUsername _
            + ";password=" + My.Settings.RobustMySqlPassword

        'Dim connStr = "server=localhost;user=root;database=opensim;port=" + My.Settings.MySqlPort + ";password=opensimpassword"
        Dim conn As New MySqlConnection(connStr)

        Try
            Debug.Print("Connecting to MySQL...")
            conn.Open()
            ' Perform database operations

        Catch ex As Exception

            Debug.Print(ex.Message)

            conn.Close()
            Debug.Print("Done.")
        End Try
    End Sub

End Class
