Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.Xml



Public Class NetServer
    Private LocalTCPListener As TcpListener
    Dim listen As Boolean = True
    Private LocalAddress As IPAddress
    Private WebThread As Thread
    Private Shared blnFlag As Boolean
    Private Shared singleWebserver As NetServer


    Private Sub New()
        'create a singleton
    End Sub
    Public Sub StartServer()
        Try
            Form1.Log("Info:Starting Diagnostic Webserver")
            WebThread = New Thread(AddressOf looper)
            WebThread.SetApartmentState(ApartmentState.STA)
            WebThread.Start()
        Catch ex As Exception
            Form1.Log(ex.Message)
        End Try

    End Sub
    Private Function looper()

        'Dim counter As Integer = 60 ' wait up to 30 seconds, then abort
        Try
            Dim oaddress = GetIPv4Address()
            Form1.Log("Info:IP:" + oaddress.ToString)
            LocalTCPListener = New TcpListener(oaddress, My.Settings.DiagnosticPort)
        Catch ex As Exception
            Form1.Log(ex.Message)
            Return True
        End Try

        LocalTCPListener.Start()
        Form1.Log("Info:Listener Started")
        Dim data As String = "HTTP/1.0 200 OK" + vbCrLf + vbCrLf + "Test completed"
        Dim msg As Byte() = System.Text.Encoding.ASCII.GetBytes(data)
        listen = True
        While listen
            If Not LocalTCPListener.Pending() Then
                Thread.Sleep(100) ' choose a number (In milliseconds) that makes sense
                Continue While  ' skip To Next iteration Of Loop
            End If

            Dim client As TcpClient = LocalTCPListener.AcceptTcpClient()
            Form1.Log("Info:Accepted client")

            Dim stream As NetworkStream = client.GetStream() ' Get a stream object for reading and writing

            If stream.CanRead Then
                Dim myReadBuffer(1024) As Byte
                Dim myCompleteMessage As StringBuilder = New StringBuilder()
                Dim numberOfBytesRead As Integer = 0

                ' Incoming message may be larger than the buffer size.
                Do
                    numberOfBytesRead = stream.Read(myReadBuffer, 0, myReadBuffer.Length)
                    myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead))
                Loop While stream.DataAvailable

                ' Print out the received message to the console.
                Form1.Log(("Info:You received the following message : " + myCompleteMessage.ToString()))

                Form1.ParsePost(myCompleteMessage.ToString())
            Else
                Form1.Log("Error:Cannot read from this NetworkStream.")
            End If

            Try
                stream.Write(msg, 0, msg.Length) ' Send back a response.
                Form1.Log([String].Format("Info: {0}", data))
            Catch
            End Try

            'Shutdown And end connection
            client.Close()
            Form1.Log("Info:WebClient Closed")
            ' listen = False
        End While

        listen = False
        LocalTCPListener.Stop()
        Form1.Log("Info:Webthread ending")
        Return False
    End Function

    Private Function GetIPv4Address() As IPAddress

        GetIPv4Address = Nothing
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)

        For Each ipheal As System.Net.IPAddress In iphe.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                GetIPv4Address = ipheal
            End If
        Next

    End Function

    Public Sub StopWebServer()
        Form1.Log("Info:Stopping Webserver")
        listen = False
        Application.DoEvents()

        WebThread.Join()
        Form1.Log("Info:Stopped Webserver on command")
    End Sub

    Friend Shared Function getWebServer() As NetServer
        If Not blnFlag Then
            singleWebserver = New NetServer
            blnFlag = True
            Return singleWebserver
        Else
            Return singleWebserver
        End If
    End Function


End Class
