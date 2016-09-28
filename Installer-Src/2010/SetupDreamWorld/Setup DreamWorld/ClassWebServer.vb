Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.Xml

Public Class Net
    Private LocalTCPListener As TcpListener
    Dim listen As Boolean = True
    Private LocalPort As Integer
    Private LocalAddress As IPAddress
    Private WebThread As Thread
    Private Shared blnFlag As Boolean
    Private Shared singleWebserver As Net

    Private Sub New()
        'create a singleton
    End Sub
    Public Sub StartServer()

        Try
            WebThread = New Thread(AddressOf looper)
            WebThread.Start()
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try

    End Sub
    Private Function looper()

        Try
            LocalTCPListener = New TcpListener(GetIPAddress(), My.Settings.LoopBack)
        Catch ex As Exception
            Debug.Print(ex.Message)
            Return True
        End Try

        LocalTCPListener.Start()

        Dim data As String = "200 OK" + vbCrLf + vbCrLf + "Test completed"
        Dim msg As Byte() = System.Text.Encoding.ASCII.GetBytes(data)

        While listen
            If Not LocalTCPListener.Pending() Then
                Thread.Sleep(500) ' choose a number (In milliseconds) that makes sense
                ' Debug.Print("No connection requests have arrived")
                Continue While  ' skip To Next iteration Of Loop
            End If
            Dim client As TcpClient = LocalTCPListener.AcceptTcpClient()
            Debug.Print("******** Accepted client ***********")

            Dim stream As NetworkStream = client.GetStream() ' Get a stream object for reading and writing

            Debug.Print([String].Format("Received: {0}", data))

            stream.Write(msg, 0, msg.Length) ' Send back a response.
            Debug.Print([String].Format("Sent: {0}", data))

            ' Shutdown and end connection
            client.Close()
        End While

        LocalTCPListener.Stop()

        Return False
    End Function

    Private Function GetIPAddress() As IPAddress
        Dim oAddr As System.Net.IPAddress = New IPAddress(0)

        With System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())
            If .AddressList.Length > 0 Then
                oAddr = New IPAddress(.AddressList.GetLowerBound(0))
            End If
        End With
        GetIPAddress = oAddr

    End Function

    Public Sub StopWebServer()

        listen = False
        WebThread.Join()

    End Sub

    Friend Shared Function getWebServer() As Net
        If Not blnFlag Then
            singleWebserver = New Net
            blnFlag = True
            Return singleWebserver
        Else
            Return singleWebserver
        End If
    End Function

End Class
