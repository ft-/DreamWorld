
Imports Mysql.Data.MySqlClient


Public Class Mysql
    Implements IDisposable

    Dim MysqlConn As MySqlConnection

    Public Sub New()

        Dim robustconnStr = "server=" + "localhost" _
            + ";database=" + My.Settings.RobustMySqlName _
            + ";port=" + My.Settings.MySqlPort _
            + ";user=" + My.Settings.RobustMySqlUsername _
            + ";password=" + My.Settings.RobustMySqlPassword

        MysqlConn = New MySqlConnection(robustconnStr)
        Try
            Debug.Print("Connecting to MySQL...")
            MysqlConn.Open()

        Catch ex As MySqlException
            Debug.Print("Error: " & ex.ToString())
            MysqlConn.Close()
        End Try


    End Sub
    Public Function isMySqlRunning() As String
        Dim version = QueryString("SELECT VERSION()")
        Debug.Print("MySQL version: {0}", version)
        Return version
    End Function

    Private Function QueryString(SQL As String) As String

        Try
            Dim cmd As MySqlCommand = New MySqlCommand(SQL, MysqlConn)
            Dim v = Convert.ToString(cmd.ExecuteScalar())
            Return v
        Catch ex As Exception
            Debug.Print(ex.Message)
        Finally
            MysqlConn.Close()
        End Try
        Return Nothing
    End Function


#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' TODO: uncomment the following line if Finalize() is overridden above.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
