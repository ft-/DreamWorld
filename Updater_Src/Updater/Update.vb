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

    Dim BLKSIZE As Integer = 1000000

    Dim Version As String = "3"
    Dim Type As String = "UpdateGrid"  ' possible server-side choices are "Update", "UpdateGrid" and "Installer"
    'Dim Type As String = "Update"  
    'Dim Type As String = "Install"  

    Dim gCurDir = Nothing   ' Holds the current folder that we are running in
    Dim gFileName As String = Nothing
    Dim whereToSave As String = Nothing 'Where the program save the file
    Dim gshortfilename = Nothing    ' the short name
    Dim Cancelled As Boolean = False
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
        Me.Show()
        Me.Text = "Outworldz " + Type + " Updater V" + Version
        MyFolder = My.Application.Info.DirectoryPath
        ' I would like to buy an argument
        Dim arguments As String() = Environment.GetCommandLineArgs()
        If arguments.Length > 1 Then
            ' for debugging when compiling
            If arguments(1) = "-debug" Then
                MyFolder = "E:" ' for testing, as the compiler buries itself in ../../../debug
                ChDir(MyFolder)
            End If
        End If

        Label1.Text = ""

        btnCancel.Visible = True
        StopMYSQL()

        Application.DoEvents()

        Try
            Dim client As New System.Net.WebClient
            gshortfilename = client.DownloadString("http://www.outworldz.com/Outworldz_Installer/GetUpdate.plx?t=" + Type + "&r= " + Random())
        Catch ex As Exception
            Label1.Text = "Drat!  The Outworldz web site won't talk to me.  No " + Type + "file found"
        End Try

        If gshortfilename = "DreamGrid-Update.zip" Then
            gFileName = "https://www.outworldz.com/Outworldz_Installer/Grid/" + gshortfilename
            Dim Name As Uri = New Uri(gFileName)
            Try

                Label1.Text = "Downloading File " + gshortfilename
                Application.DoEvents()
                Dim client As WebClient
                client = New WebClient()
                client.Credentials = New NetworkCredential("", "")
                client.DownloadFile(Name, gshortfilename)
                Application.DoEvents()

            Catch ex As TimeoutException
                MessageBox.Show("Download Timeout", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End
                Exit Try

            Catch ex As WebException
                MessageBox.Show("The request was denied by the Outworldz web server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End
                Exit Try

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try


            Log("Download Complete")

            Label1.Text = "Download Complete"
            Application.DoEvents()
            Thread.Sleep(1000)
            Dim ctr As Integer
            Try
                Log("Opening zip " + MyFolder + "\tmp.zip")
                Using zip As ZipFile = ZipFile.Read(MyFolder + "\" + gshortfilename)
                    Debug.Print("Received " + Str(zip.Entries.Count) + " files. Extracting To disk.")
                    Log("Received " + Str(zip.Entries.Count) + " files. Extracting To disk.")

                    Try
                        My.Computer.FileSystem.DeleteDirectory(MyFolder + "\Outworldzfiles\opensim\bin\addin-db-002", FileIO.DeleteDirectoryOption.DeleteAllContents)
                    Catch
                    End Try

                    For Each ZipEntry In zip
                        If Cancelled = False Then
                            Application.DoEvents()
                            ctr = ctr + 1
                            Label1.Text = "Extracting " + Path.GetFileName(ZipEntry.FileName)
                            Application.DoEvents()
                            ZipEntry.Extract(MyFolder, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently)
                        End If

                    Next
                End Using
            Catch ex As Exception
                Log("Update Aborted: " + ex.Message)
                Label1.Text = "Update Aborted: " + ex.Message
                Application.DoEvents()
                Thread.Sleep(2000)
                Log("Exit")
            End Try
            Log("Extract Complete")

            If Not Cancelled Then

                Label1.Text = "Update Complete.  Waking up the Outworldz..."
                Application.DoEvents()
                Dim newDream As New Process()
                Try
                    newDream.StartInfo.UseShellExecute = False
                    newDream.StartInfo.FileName = "Start.exe"
                    newDream.Start()
                Catch ex As Exception
                    Label1.Text = "How odd, there seems to be no Start.exe to run!"
                    Log("No Start.exe Exit")
                    Application.DoEvents()
                    Thread.Sleep(2000)
                    End
                End Try
                Log("Normal Exit")
                End

            End If
            Label1.Text = "Cancelled"
            Application.DoEvents()
            Thread.Sleep(2000)
            Log("Cancelled Exit")
            End
        Else
            Label1.Text = "Drat!  The Outworldz web site won't talk to me.  No " + Type + "file found"
            Application.DoEvents()
            Thread.Sleep(2000)
            Log("Web Page Exit")
            End
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Log("Cancelled")
        Cancelled = True
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

        Label1.Text = "Stopping database to prep for update"
        Application.DoEvents()
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

        p.WaitForExit()
        p.Close()


    End Sub

End Class


