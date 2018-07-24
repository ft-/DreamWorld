
Imports System.Net
Imports System.Text
Imports System.IO
Imports System.Xml

Public Class ConsoleForm
    Dim gSessionID As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim Session As String = ""
        Session = PostURL("http://127.0.0.1:" + My.Settings.PublicPort + "/StartSession/", "USER=" + My.Settings.ConsoleUser + "&PASS=" + My.Settings.ConsolePass)
        gSessionID = readXML(Session, "ConsoleSession")
        ConsoleText.Text = "Session ID:  " + gSessionID

        Session = PostURL("http://127.0.0.1:" + My.Settings.PublicPort + "/SessionCommand/" + gSessionID, "ID=" + gSessionID + "&COMMAND=show stats")
        If Session.Length Then
            ConsoleText.Text = Session
        End If

        Dim counter = 0
        While counter < 100
            Session = PostURL("http://127.0.0.1:" + My.Settings.PublicPort + "/ReadResponses/" + gSessionID, "")
            If Session.Length Then
                ConsoleText.Text = Session
            End If
            counter = counter + 1
        End While


    End Sub

    Private Sub Console1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        PostURL("http://127.0.0.1:" + My.Settings.PublicPort + "/CloseSession/", "")
        gSessionID = Nothing

    End Sub

    Private Function PostURL(URL As String, postdata As String)
        Dim s As HttpWebRequest
        Dim enc As UTF8Encoding
        Dim postdatabytes As Byte()

        Debug.Print(URL)
        Debug.Print(postdata)
        s = HttpWebRequest.Create(URL)
        enc = New System.Text.UTF8Encoding()
        postdatabytes = enc.GetBytes(postdata)
        s.Method = "POST"
        s.ContentType = "application/x-www-form-urlencoded"
        s.ContentLength = postdatabytes.Length
        Dim Text As String

        Try
            Using stream = s.GetRequestStream()
                stream.Write(postdatabytes, 0, postdatabytes.Length)
            End Using

            Dim response As HttpWebResponse = CType(s.GetResponse(), HttpWebResponse)
            Debug.Print("Content length is {0}", response.ContentLength)
            Debug.Print("Content type is {0}", response.ContentType)

            ' Get the stream associated with the response.
            Dim receiveStream As Stream = response.GetResponseStream()

            ' Pipes the stream to a higher level stream reader with the required encoding format. 
            Dim readStream As New StreamReader(receiveStream, Encoding.UTF8)

            Debug.Print("Response stream received.")
            Text = readStream.ReadToEnd()
            response.Close()
            readStream.Close()
            Return Text
        Catch ex As Exception
            Return ex.Message
        End Try
        Return "Opensim is not running"

    End Function

    Private Function readXML(xml As String, seek As String)
        Dim nextnode As Boolean = False
        Dim stream As System.IO.StringReader
        stream = New StringReader(xml)
        Dim reader As XmlTextReader = New XmlTextReader(stream)
        Try
            Do While (reader.Read())
                Select Case reader.NodeType
                    Case XmlNodeType.Element 'Display beginning of element.
                        Debug.Print("<" + reader.Name)
                        Debug.Print(">")
                        If (reader.Name = seek) Then
                            nextnode = True
                        End If
                    Case XmlNodeType.Text 'Display the text in each element.
                        If (nextnode) Then
                            Debug.Print(reader.Value)
                            Return reader.Value
                        End If
                    Case XmlNodeType.EndElement 'Display end of element.
                        Debug.Print("</" + reader.Name)
                        Debug.Print(">")
                End Select
            Loop
        Catch ex As Exception
            Return ex.Message
        End Try

        Return ""
    End Function

End Class