Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.Xml


Public Class NetServer
    Private running As Integer = False
    Private LocalTCPListener As TcpListener
    Dim listen As Boolean = True
    Private LocalAddress As IPAddress
    Private WebThread As Thread
    Private Shared blnFlag As Boolean
    Private Shared singleWebserver As NetServer
    Private Myfolder As String
    Private IP As String = Nothing
    Dim RegionClass As RegionMaker = RegionMaker.Instance

    Private Sub New()

        'create a singleton

    End Sub

    Public Sub StartServer(folder As String, IP As String)

        LocalAddress = IPAddress.Parse(IP)

        If running Then Return
        Myfolder = folder
        Try
            Log("Info:Starting Diagnostic Webserver")
            WebThread = New Thread(AddressOf Looper)
            WebThread.SetApartmentState(ApartmentState.STA)
            WebThread.Start()
            running = True
        Catch ex As Exception
            Log(ex.Message)
        End Try

    End Sub

    Private Sub Looper()

        Dim oaddress = LocalAddress
        Log("Info:IP:" + oaddress.ToString)
        listen = True
        Try
            LocalTCPListener = New TcpListener(oaddress, Form1.MySetting.DiagnosticPort)
        Catch ex As Exception
            Log(ex.Message)
            Return
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
                    Try
                        numberOfBytesRead = stream.Read(myReadBuffer, 0, myReadBuffer.Length)
                    Catch
                    End Try

                    myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead))
                Loop While stream.DataAvailable

                ' Print out the received message to the console.
                'Log("Received:" + myCompleteMessage.ToString())
                Response = RegionClass.ParsePost(myCompleteMessage.ToString())
            Else
                Log("Error:Cannot read from this NetworkStream.")
            End If

            Try
                Dim data As String = "HTTP/1.0 200 OK" + vbCrLf + vbCrLf + Response
                Dim msg As Byte() = System.Text.Encoding.ASCII.GetBytes(data)
                stream.Write(msg, 0, msg.Length) ' Send back a response.
                'Log([String].Format("Response:{0}", Data))
            Catch
            End Try

            'Shutdown And end connection
            client.Close()
            ' Log("Info:Connection Closed")

        End While

        LocalTCPListener.Stop()
        Log("Info:Webthread ending")
        running = False

    End Sub

    Public Sub StopWebServer()

        Log("Info:Stopping Webserver")
        listen = False
        Application.DoEvents()

        WebThread.Join()
        Log("Info:Shutdown Complete")

    End Sub

    Friend Shared Function GetWebServer() As NetServer

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
