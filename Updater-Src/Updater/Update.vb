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

    Dim Version As String = "1.0"

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

        TextBox1.Visible = False
        Me.Text = "Outworldz Updater Version " + Version
        MyFolder = My.Application.Info.DirectoryPath
        ' I would like to buy an argument
        Dim arguments As String() = Environment.GetCommandLineArgs()
        If arguments.Length > 1 Then
            ' for debugging when compiling
            If arguments(1) = "-debug" Then
                MyFolder = "\Outworldz" ' for testing, as the compiler buries itself in ../../../debug
            End If
        End If

        Label1.Text = ""
        Label2.Text = ""
        Label3.Text = ""

        ProgressBar1.Maximum = 100
        ProgressBar1.Minimum = 0
        ProgressBar1.Visible = False

        ProgressBar1.Visible = False
        btnCancel.Visible = False

    End Sub

    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        btnDownload.Visible = False
        btnCancel.Visible = True

        ProgressBar1.Visible = True
        Dim filename
        Try
            Dim client As New System.Net.WebClient
            filename = client.DownloadString("http://www.outworldz.com/Outworldz_Installer/GetUpdate.plx?r= " + Random())
        Catch ex As Exception
            Print("Drat!  The Outworldz web site won;t talk to me.")
            ProgressBar1.Value = 100
        End Try

        gFileName = filename

        BackgroundWorker1.RunWorkerAsync() 'Start download
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        BackgroundWorker1.CancelAsync() 'Send cancel request
    End Sub

    Public Sub ChangeTexts(ByVal length As Long, ByVal position As Integer, ByVal percent As Integer, ByVal speed As Double)

        Try
            Label1.Text = "Downloading Update, please wait..."
            'Label3.Text = "File Size: " & Math.Round((length / 1024), 2) & " KB"
            Label2.Text = "Downloaded " & Math.Round((position / 1024), 2) & " KB of " & Math.Round((length / 1024), 2) & "KB (" & ProgressBar1.Value & "%)"

            Application.DoEvents()
            If speed = -1 Then
                Label3.Text = "Speed: calculating..."
            Else
                Label3.Text = "Speed: " & Math.Round((speed / 1024), 2) & " KB/s"
            End If

            ProgressBar1.Value = percent * 100
        Catch ex As Exception
            MsgBox("Exception: " + ex.Message)
        End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        'Creating the request and getting the response

        Dim theResponse As HttpWebResponse
        Dim theRequest As HttpWebRequest
        Try 'Checks if the file exist

            theRequest = WebRequest.Create("http://www.outworldz.com/" + gFileName)
            Debug.Print(gFileName)
            theResponse = theRequest.GetResponse
        Catch ex As Exception

            MessageBox.Show("An error occurred while downloading file. Possible causes:" & ControlChars.CrLf &
                    "1) File doesn't exist" & ControlChars.CrLf &
                    "2) Remote server error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Dim cancelDelegate As New DownloadCompleteSafe(AddressOf DownloadComplete)
            Invoke(cancelDelegate, True)

            Exit Sub
        End Try
        Dim length As Long = theResponse.ContentLength 'Size of the response (in bytes)
        If length = 0 Then

            MessageBox.Show("An error occurred while downloading file. Possible causes:" & ControlChars.CrLf &
                   "1) File doesn't exist" & ControlChars.CrLf &
                   "2) Remote server error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

        Dim safedelegate As New ChangeTextsSafe(AddressOf ChangeTexts)
        Invoke(safedelegate, length, 0, 0, 0) 'Invoke the TreadsafeDelegate

        whereToSave = MyFolder + "\" + "Update.zip"

        Debug.Print("Saving to " + whereToSave)
        Dim writeStream As New IO.FileStream(whereToSave, IO.FileMode.Create)

        'Replacement for Stream.Position (webResponse stream doesn't support seek)
        Dim nRead As Integer

        'To calculate the download speed
        Dim speedtimer As New Stopwatch
        Dim currentspeed As Double = -1
        Dim readings As Integer = 0

        Do
            If BackgroundWorker1.CancellationPending Then 'If user abort download
                Exit Do
            End If

            Debug.Print("speedtimer.Start")

            speedtimer.Start()

            Dim readBytes(16000) As Byte
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
            If readings >= 5 Then 'For increase precision, the speed it's calculated only every five cycles
                currentspeed = 20480 / (speedtimer.ElapsedMilliseconds / 1000)
                speedtimer.Reset()
                readings = 0
            End If
        Loop

        ProgressBar1.Value = 100

        Debug.Print("Close stream")
        'Close the streams
        theResponse.GetResponseStream.Close()
        writeStream.Close()

        If BackgroundWorker1.CancellationPending Then
            IO.File.Delete(whereToSave)

            Dim cancelDelegate As New DownloadCompleteSafe(AddressOf DownloadComplete)
            Invoke(cancelDelegate, True)
            Exit Sub
        End If

        Dim completeDelegate As New DownloadCompleteSafe(AddressOf DownloadComplete)
        Invoke(completeDelegate, False)

    End Sub

    Public Sub DownloadComplete(ByVal cancelled As Boolean)

        btnCancel.Visible = False
        If cancelled Then
            Label1.Text = "Cancelled"
            MessageBox.Show("Download aborted", "Aborted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Label2.Text = ""
            Label3.Text = ""
            ProgressBar1.Visible = False
            btnDownload.Visible = True
        Else
            Print("Successfully downloaded")
            Thread.Sleep(1000)
            InstallUpdate()
        End If
    End Sub
    Private Sub InstallUpdate()

        Label1.Text = ""
        Label2.Text = ""
        Label3.Text = ""
        ProgressBar1.Value = 0

        Dim ctr As Integer
        Using zip As ZipFile = ZipFile.Read(MyFolder + "\Update.zip")
            Debug.Print("Received " + Str(zip.Entries.Count) + " files. Extracting to disk.")

            For Each ZipEntry In zip
                Application.DoEvents()
                Label1.Text = "Extracting " + Path.GetFileName(ZipEntry.FileName)
                ZipEntry.Extract(MyFolder, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently)
                ProgressBar1.Value = ctr / zip.Entries.Count * 100
                ctr = ctr + 1
            Next
        End Using
        ProgressBar1.Value = 100

        Try
            My.Computer.FileSystem.DeleteFile(MyFolder + "\Update.zip")
        Catch
            Label1.Text = "Could not delete " + gFileName
        End Try

        Print("Update Complete.  Waking up the Outworldz...")
        Dim newDream As New Process()
        Try
            newDream.StartInfo.UseShellExecute = False
            newDream.StartInfo.FileName = "Start.exe"
            newDream.Start()
        Catch e As Exception
            Label1.Text = ""
            Label2.Text = ""
            Label3.Text = ""
            Print("How odd, there seems to be nothing to run!")
            Return
        End Try
        Thread.Sleep(1000)
        End

    End Sub
    Private Function Random() As String
        Randomize()
        Dim value As Integer = CInt(Int((6000 * Rnd()) + 1))
        Random = Str(value)
    End Function

    Private Sub Print(Value As String)
        TextBox1.Text = Value
        TextBox1.Visible = True
    End Sub

End Class


