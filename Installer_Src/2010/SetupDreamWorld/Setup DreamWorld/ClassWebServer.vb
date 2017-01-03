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
    Private gMyFolder As String

    Private Sub New()
        'create a singleton
    End Sub
    Public Sub StartServer(MyFolder As String)
        gMyFolder = MyFolder
        Try
            Form1.DiagLog("Starting Diagnostic Webserver")
            WebThread = New Thread(AddressOf looper)
            WebThread.SetApartmentState(ApartmentState.STA)
            WebThread.Start()
        Catch ex As Exception
            Form1.DiagLog(ex.Message)
        End Try

    End Sub
    Private Function looper()

        Dim counter As Integer = 60 ' wait up to 30 seconds, then abord
        Try
            Dim oaddress = GetIPv4Address()
            Form1.DiagLog("IP:" + oaddress.ToString)
            LocalTCPListener = New TcpListener(oaddress, My.Settings.LoopBack)
        Catch ex As Exception
            Form1.DiagLog(ex.Message)
            Return True
        End Try

        LocalTCPListener.Start()
        Form1.DiagLog("Listener Started")
        Dim data As String = "HTTP/1.0 200 OK" + vbCrLf + vbCrLf + "Test completed"
        Dim msg As Byte() = System.Text.Encoding.ASCII.GetBytes(data)
        listen = True
        While listen
            If Not LocalTCPListener.Pending() Then
                Thread.Sleep(500) ' choose a number (In milliseconds) that makes sense
                Form1.DiagLog("No connection requests have arrived")
                counter -= 1
                If counter > 0 Then
                    Continue While  ' skip To Next iteration Of Loop
                End If
                Form1.DiagLog("Aborting due to no connections")
            End If

            Dim client As TcpClient = LocalTCPListener.AcceptTcpClient()
            Form1.DiagLog("Accepted client")

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
                Form1.DiagLog(("You received the following message : " + myCompleteMessage.ToString()))
            Else
                Form1.DiagLog("Sorry. Cannot read from this NetworkStream.")
            End If

            Try
                stream.Write(msg, 0, msg.Length) ' Send back a response.
                Form1.DiagLog([String].Format("Sent: {0}", data))
            Catch
            End Try

            ' Shutdown and end connection
            client.Close()
            Form1.DiagLog("Client Closed")
            listen = False
        End While

        LocalTCPListener.Stop()
        Form1.DiagLog("Thread ending")
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
        Form1.DiagLog("Stopping Webserver")
        listen = False
        WebThread.Join()
        Form1.DiagLog("Stopped Webserver on command")
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
