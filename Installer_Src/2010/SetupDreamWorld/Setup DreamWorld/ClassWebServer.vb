Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.Xml


Public Class NetServer
    Private Shared running = False
    Private LocalTCPListener As TcpListener
    Dim listen As Boolean = True
    Private LocalAddress As IPAddress
    Private WebThread As Thread
    Private Shared blnFlag As Boolean
    Private Shared singleWebserver As NetServer
    Private Myfolder As String
    Private IP As String = Nothing

    Public Property MyIP() As String
        Get
            Return IP
        End Get
        Set(ByVal Value As String)
            IP = Value
        End Set
    End Property


    Private Sub New()

        'create a singleton

    End Sub

    Public Sub StartServer(folder As String)

        If running Then Return
        Myfolder = folder
        Try
            Log("Info:Starting Diagnostic Webserver")
            WebThread = New Thread(AddressOf looper)
            WebThread.SetApartmentState(ApartmentState.STA)
            WebThread.Start()
            running = True
        Catch ex As Exception
            Log(ex.Message)
        End Try

    End Sub

    Private Function looper()

        Dim oaddress = GetIPv4Address()
        Log("Info:IP:" + oaddress.ToString)
        listen = True


        Try

                LocalTCPListener = New TcpListener(oaddress, My.Settings.DiagnosticPort)
            Catch ex As Exception
                Log(ex.Message)
                Return True
            End Try

            LocalTCPListener.Start()
            Log("Info:Listener Started")

        While listen

            If Not LocalTCPListener.Pending() Then
                Thread.Sleep(100) ' choose a number (In milliseconds) that makes sense
                Continue While  ' skip To Next iteration Of Loop
            End If

            Dim client As TcpClient = LocalTCPListener.AcceptTcpClient()
            Log("Info:Accepted client")

            Dim stream As NetworkStream = client.GetStream() ' Get a stream object for reading and writing
            Dim Response As String = ""
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
                Log("Received:" + myCompleteMessage.ToString())
                Response = Form1.ParsePost(myCompleteMessage.ToString())
            Else
                Log("Error:Cannot read from this NetworkStream.")
            End If

            Try
                Dim data As String = "HTTP/1.0 200 OK" + vbCrLf + vbCrLf + Response
                Dim msg As Byte() = System.Text.Encoding.ASCII.GetBytes(data)
                stream.Write(msg, 0, msg.Length) ' Send back a response.
                Log([String].Format("Response:{0}", Data))
            Catch
            End Try

            'Shutdown And end connection
            client.Close()
            Log("Info:Connection Closed")

        End While

        LocalTCPListener.Stop()
        Log("Info:Webthread ending")
        running = False
        Return False

    End Function

    Private Function GetIPv4Address() As IPAddress

        If MyIP = Nothing Then
            GetIPv4Address = Nothing
            Dim strHostName As String = System.Net.Dns.GetHostName()
            Log("Info:Hostname is " & strHostName)
            Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)
            For Each ipheal As System.Net.IPAddress In iphe.AddressList
                If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                    GetIPv4Address = ipheal
                    MyIP = ipheal.ToString
                End If
            Next
        Else
            Return IPAddress.Parse(MyIP) ' return cached string IP
        End If

    End Function

    Public Sub StopWebServer()

        Log("Info:Stopping Webserver")
        listen = False
        Application.DoEvents()

        WebThread.Join()
        Log("Info:Shutdown Complete")

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

    Public Sub Log(message As String)
        Debug.Print(message)
        Try
            Using outputFile As New StreamWriter(Myfolder & "\Outworldzfiles\Http.log", True)
                outputFile.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + message)
            End Using
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

End Class
