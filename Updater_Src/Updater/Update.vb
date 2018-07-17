Imports System.Net
Imports System.IO
Imports Ionic.Zip
Imports System.Threading

' Copyright 2014 Fred Beckhusen  
' Redistribution and use in binary and source form is permitted provided 
' that ALL the licenses in the text files are followed and included in all copies

' Command line args:
'     '-debug' forces this to use the \Outworldzs folder for testing 

Public Class Update

    Dim BLKSIZE As Integer = 32767

    Dim Version As String = "2.21"
    Dim Type As String = "UpdateGrid"  ' possible server-side choices are "Update", "UpdateGrid" and "Installer"
    'Dim Type As String = "Update"  
    'Dim Type As String = "Install"  

    Dim gCurDir = Nothing   ' Holds the current folder that we are running in
    Dim gFileName As String = Nothing
    Dim whereToSave As String = Nothing 'Where the program save the file

    Delegate Sub ChangeTextsSafe(ByVal length As Long, ByVal position As Integer, ByVal percent As Integer, ByVal speed As Double)
    Delegate Sub DownloadCompleteSafe(ByVal cancelled As Boolean)

    Public Property MyFolder() As String
        Get
            Return gCurDir
        End Get
        Set(ByVal Value As String)
            gCurDir = Value
        End Set
    End Property

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Log("Version " + Version)

        Me.Text = "Outworldz " + Type + " V " + Version
        MyFolder = My.Application.Info.DirectoryPath
        ' I would like to buy an argument
        Dim arguments As String() = Environment.GetCommandLineArgs()
        If arguments.Length > 1 Then
            ' for debugging when compiling
            If arguments(1) = "-debug" Then
                MyFolder = "C:\Opensim\Outworldz 2.15 to 2.2" ' for testing, as the compiler buries itself in ../../../debug
                ChDir(MyFolder)
            End If
        End If

        Label1.Text = ""
        Label2.Text = ""
        Label3.Text = ""

        btnCancel.Visible = True

        StopMYSQL()

        Dim filename = Nothing
        Try
            Dim client As New System.Net.WebClient
            filename = client.DownloadString("http://www.outworldz.com/Outworldz_Installer/GetUpdate.plx?t=" + Type + "&r= " + Random())
        Catch ex As Exception
            Label1.Text = "Drat!  The Outworldz web site won't talk to me.  No " + Type + "file found"

        End Try

        gFileName = "http://www.outworldz.com/Outworldz_Installer/Grid/" + filename
        If filename.length Then
            BackgroundWorker1.RunWorkerAsync() 'Start download
        Else
            Label1.Text = "Drat!  The Outworldz web site won't talk to me.  No " + Type + "file found"
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Log("Cancel requested")
        BackgroundWorker1.CancelAsync() 'Send cancel request
    End Sub

    Public Sub ChangeTexts(ByVal length As Long, ByVal position As Integer, ByVal percent As Integer, ByVal speed As Double)

        Try
            Label1.Text = "Downloading Update, please wait..."
            'Label3.Text = "File Size: " & Math.Round((length / 1024), 2) & " KB"
            Label2.Text = "Downloaded " & Math.Round((position / 1024), 2) & " KB of " & Math.Round((length / 1024), 2) & "KB "

            Application.DoEvents()
            If speed = -1 Then
                Label3.Text = "Speed: calculating..."
            Else
                Label3.Text = "Speed: " & Math.Round((speed / 1024), 2) & " KB/s"
            End If

            Application.DoEvents()
        Catch ex As Exception
            MsgBox("Exception: " + ex.Message)
            Log("Exception: " + ex.Message)
        End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        'Creating the request and getting the response

        Dim theResponse As HttpWebResponse
        Dim theRequest As HttpWebRequest
        Try 'Checks if the file exist

            theRequest = WebRequest.Create(gFileName)
            Debug.Print(gFileName)
            theResponse = theRequest.GetResponse
        Catch ex As Exception
            Log(ex.Message)
            MessageBox.Show("An error occurred while downloading file. Possible causes:" & ControlChars.CrLf &
                    "1) File doesn't exist" & ControlChars.CrLf &
                    "2) Remote server error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Dim cancelDelegate As New DownloadCompleteSafe(AddressOf DownloadComplete)
            Invoke(cancelDelegate, True)

            Exit Sub
        End Try
        Dim length As Long = theResponse.ContentLength 'Size of the response (in bytes)
        If length = 0 Then
            Log("File len = 0")
            MessageBox.Show("An error occurred while downloading file. Possible causes:" & ControlChars.CrLf &
                   "1) File doesn't exist" & ControlChars.CrLf &
                   "2) Remote server error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

        Dim safedelegate As New ChangeTextsSafe(AddressOf ChangeTexts)
        Invoke(safedelegate, length, 0, 0, 0) 'Invoke the TreadsafeDelegate

        whereToSave = MyFolder + "\" + "tmp.zip"
        Log("Saving to " + whereToSave)
        Debug.Print("Saving to " + whereToSave)
        Dim writeStream As New IO.FileStream(whereToSave, IO.FileMode.Create)

        'Replacement for Stream.Position (webResponse stream doesn't support seek)
        Dim nRead As Integer

        'To calculate the download speed
        Dim speedtimer As New Stopwatch
        Dim currentspeed As Double = -1
        Dim readings As Integer = 0

        Do
            Application.DoEvents()

            If BackgroundWorker1.CancellationPending Then 'If user abort download
                Exit Do
            End If
            speedtimer.Start()

            Dim readBytes(BLKSIZE) As Byte
            Dim bytesread As Integer = theResponse.GetResponseStream.Read(readBytes, 0, 4096)

            nRead += bytesread
            Dim percent As Short = nRead / length

            Invoke(safedelegate, length, nRead, percent, currentspeed)

            If bytesread = 0 Then
                Debug.Print("Exit do")
                Exit Do
            End If

            writeStream.Write(readBytes, 0, bytesread)

            speedtimer.Stop()

            readings += 1
            If readings >= 100 Then 'For increase precision, the speed it's calculated only every 100 cycles
                currentspeed = bytesread / (speedtimer.ElapsedMilliseconds / 1000)
                speedtimer.Reset()
                readings = 0
            End If
        Loop

        Log("Download Complete")
        Debug.Print("Close stream")
        'Close the streams
        theResponse.GetResponseStream.Close()
        writeStream.Close()

        If BackgroundWorker1.CancellationPending Then
            Log("Deleteing " + whereToSave)
            IO.File.Delete(whereToSave)

            Dim cancelDelegate As New DownloadCompleteSafe(AddressOf DownloadComplete)
            Invoke(cancelDelegate, True)
            Exit Sub
        End If

        Dim completeDelegate As New DownloadCompleteSafe(AddressOf DownloadComplete)
        Invoke(completeDelegate, False)

    End Sub

    Public Sub DownloadComplete(ByVal cancelled As Boolean)
        Log("Prepping for install")
        btnCancel.Visible = False
        If cancelled Then
            Log("Aborted")
            MessageBox.Show("Download aborted", "Aborted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Label2.Text = ""
            Label3.Text = ""
            End
        Else
            Thread.Sleep(1000)
            Label1.Text = ""
            Label2.Text = ""
            Label3.Text = ""

            Dim ctr As Integer
            Try
                Log("Opening zip " + MyFolder + "\tmp.zip")
                Using zip As ZipFile = ZipFile.Read(MyFolder + "\tmp.zip")
                    Debug.Print("Received " + Str(zip.Entries.Count) + " files. Extracting to disk.")
                    Log("Received " + Str(zip.Entries.Count) + " files. Extracting to disk.")
                    For Each ZipEntry In zip
                        Application.DoEvents()
                        ctr = ctr + 1
                        Label1.Text = "Extracting " + Path.GetFileName(ZipEntry.FileName)
                        Log("Extracting " + Path.GetFileName(ZipEntry.FileName))
                        ZipEntry.Extract(MyFolder, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently)
                    Next
                End Using
            Catch ex As Exception
                Log("Update Aborted: " + ex.Message)
                Label1.Text = "Update Aborted: " + ex.Message
            End Try
            Log("Extract Complete")

            Try
                My.Computer.FileSystem.DeleteFile(MyFolder + "\" + "tmp.zip")
            Catch
                Log("Could not delete " + gFileName)
                Label1.Text = "Could not delete " + gFileName
            End Try

            Label1.Text = "Update Complete.  Waking up the Outworldz..."
            Dim newDream As New Process()
            Try
                newDream.StartInfo.UseShellExecute = False
                newDream.StartInfo.FileName = "Start.exe"
                newDream.Start()
            Catch e As Exception
                Label1.Text = ""
                Label2.Text = ""
                Label3.Text = ""
                Label1.Text = "How odd, there seems to be nothing to run!"
                Return
            End Try
            Thread.Sleep(1000)
            Log("Exit Done")
            End
        End If
    End Sub
    Private Function Random() As String
        Randomize()
        Dim value As Integer = CInt(Int((6000 * Rnd()) + 1))
        Random = Str(value)
    End Function


    Public Function Log(message As String)
        Try
            Using outputFile As New StreamWriter(MyFolder & "\" + Type + ".log", True)
                outputFile.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + message)
            End Using
        Catch
        End Try
        Return True

    End Function


    Private Sub StopMYSQL()

        Log("Info:using mysqladmin to close db")
        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = "-u root shutdown"
        pi.FileName = MyFolder + "\OutworldzFiles\mysql\bin\mysqladmin.exe"
        pi.WindowStyle = ProcessWindowStyle.Minimized
        p.StartInfo = pi
        Try
            p.Start()
        Catch
            Log("Error:mysqladmin failed to stop mysql")
        End Try

    End Sub

End Class


