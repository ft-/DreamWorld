Imports System
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Net.Sockets
Imports IWshRuntimeLibrary


Public Class Form1

    Private Declare Sub Sleep Lib "kernel32.dll" (ByVal Milliseconds As Integer)

    Dim CurDir    ' Holds the current folder that we are running in
    Dim InstallTo  ' Holds a drive we need to copy files to
    Dim Webpage As String
    Dim ctr As Integer
    Dim Opensim As Process

    Private Sub Form1_Leave(sender As Object, e As System.EventArgs) Handles Me.Leave
        ' Needed for some systems to clean up the stack, better be safe
        System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim location As String = System.Environment.GetCommandLineArgs()(0)
        Dim appName As String = System.IO.Path.GetFileName(location)

        CurDir = My.Application.Info.DirectoryPath
        ' for debugging when compiling
       
        ' FKB debug only
        CurDir = "C:\DreamWorld"
        ChDir(CurDir)

        Me.Text = "Opensimulator DreamWorld"

        ctr = 0

        Label.Visible = True
        Buttons(InstallButton)

        ' Find out if we are running this on the Installed Drive
        If System.IO.File.Exists("Init") Then
            Buttons(StartButton)
            Me.Text = "Start Dreamworld"
        Else
            Dim fs As FileStream = System.IO.File.Create("Init")
            Dim info As Byte() = New UTF8Encoding(True).GetBytes("This file exists when things are all set up")
            fs.Write(info, 0, info.Length)
            fs.Close()

            Buttons(InstallButton)
        End If
        Application.DoEvents()
    End Sub

    Private Sub Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        ' Start Mowes, which starts MySql and Apache automatically.
        Buttons(BusyButton)

        My.Computer.FileSystem.DeleteFile(CurDir + "\DreamWorldFiles\Opensim\Opensim.log")
        My.Computer.FileSystem.DeleteFile(CurDir + "\DreamWorldFiles\Opensim\OpenSimConsoleHistory.txt")




        Label.Visible = True
        Print("Starting Mowes")

        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = ""

        If Not Console.Checked Then
            pi.WindowStyle = ProcessWindowStyle.Minimized
        End If
        pi.FileName = CurDir & "\DreamWorldFiles\Mowes.exe"
        p.StartInfo = pi
        p.Start()

        Dim iSRunning As Integer
        iSRunning = 30000
        Dim Status = 0

        ' wait for Mowes to come up on port 62535
        While iSRunning > 0
            Application.DoEvents()
            Sleep(1000)
            iSRunning = iSRunning - 1
            If iSRunning = 0 Then
                MsgBox("Timeout running Mowes - cannot continue", vbAbort)
                ZapAll()
                Buttons(StopButton)
                Return
            End If

            ' now check that SQL server has started
            Status = CheckMySQL()
            If Status Then
                iSRunning = 0
                Print("MySql is Up")
            End If
        End While
        ctr = 0 ' retry counter reset - lets give them a minute to get on
        WebBrowser1.Navigate("http://127.0.0.1:62535/start/up.htm")
        Application.DoEvents()
    End Sub

    Private Sub Install_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstallButton.Click

        Buttons(BusyButton)

        Create_ShortCut(InstallTo & "DreamWorldFiles\Setup\Start.exe", _
                      "Desktop", _
                     "DreamWorld", _
                    "", _
                   InstallTo & "DreamWorldFiles\Setup", _
                 WshWindowStyle.WshNormalFocus, _
                 0)


        'ByVal sTargetPath As String, _
        '                        ByVal sShortCutPath As String, _
        '                        ByVal sShortCutName As String, _
        '                        Optional ByVal sArguments As String = "", _
        '                        Optional ByVal sWorkPath As String = "", _
        '                        Optional ByVal eWinStyle As WshWindowStyle = vbNormalFocus, _
        '                        Optional ByVal iIconNum As Integer = 0

        Print("Installing Onlook Viewer")

        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = ""
        pi.FileName = CurDir & "\Viewer\Onlook.exe"
        p.StartInfo = pi
        p.Start()

        Print("Installing Grid Info")

        Dim appData As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData

        Dim path As String
        path = Mid(appData, 1, InStr(appData, "AppData") - 1)

        My.Computer.FileSystem.CopyFile(CurDir & "\Viewer\grids_sg1.xml", path + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml", True)

        ' allow them to launch now
        Print("Ready to Launch")
        Buttons(StartButton)
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

        'When webbrower finish opening the page, source page is diplayed in text box

        Webpage = WebBrowser1.DocumentText

        ctr = ctr + 1
        If ctr > 60 Then
            MsgBox("Database did not start", vbCritical)
            Buttons(StopButton)
            ZapAll()
            Return
        End If

        If Webpage = "Up" Then
            '  Launch(OpenSim)
            Print("Starting Opensimulator")
            ChDir(CurDir & "\DreamWorldFiles\Opensim\bin\")

            Dim p As Process = New Process()
            Dim pi As ProcessStartInfo = New ProcessStartInfo()

            ' http://opensimulator.org/wiki/OpenSim.exe_Command_Line_Options

            If Not Console.Checked Then
                pi.Arguments = "-console rest -background True "
                pi.WindowStyle = ProcessWindowStyle.Hidden
            End If

            pi.FileName = CurDir & "\DreamWorldFiles\Opensim\bin\OpenSim.exe"
            p.StartInfo = pi
            p.Start()
            Application.DoEvents()
            Sleep(5000)

            ctr = 0 ' retry counter - lets give them a minute to get on
            WebBrowser2.Navigate("http://127.0.0.1:9100/wifi/up.html")
        Else
            MsgBox("Simulator did not start", vbCritical)
            Buttons(StopButton)
            ZapAll()
        End If
        Application.DoEvents()
    End Sub

    


    Private Sub WebBrowser2_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser2.DocumentCompleted

        Webpage = WebBrowser2.DocumentText

        ctr = ctr + 1
        If ctr > 60 Then
            MsgBox("Web Server did not start", vbCritical)
            Buttons(StopButton)
            ZapAll()
            Return
        End If

        If Webpage = "Up" Then
            Print("Starting Onlook viewer")
            ctr = 0
            Dim Viewer = Shell("C:\Program Files (x86)\Onlook\OnLookViewer.exe")
            If (Viewer) Then
                ' Show the console
                Dim webAddress As String = "http://127.0.0.1:9100/wifi"
                Process.Start(webAddress)
                Buttons(StopButton)
            Else
                MsgBox("Cannot launch the Onlook viewer,  You can try to run it (or another viewer) and add http://127.0.0.1:9100' in the Grid Manager.  Exiting", vbCritical)
                Buttons(StopButton)
            End If
        Else
            Application.DoEvents()
            Sleep(1000)
            WebBrowser2.Navigate("http://127.0.0.1:9100/wifi/up.html")
        End If
        Application.DoEvents()

    End Sub

    Private Sub StopButton_Click(sender As System.Object, e As System.EventArgs) Handles StopButton.Click

        Buttons(BusyButton)
        Print("Stopping")
        ZapAll()
        Buttons(StartButton)
        Print("")

    End Sub

    Private Function CheckMySQL() As Boolean

        ' tried to probe MySQL  port 3307. If available, return true
        ' if not, retries for 30 seconds

        Dim ClientSocket As New TcpClient
        Dim ServerAddress As String = "127.0.0.1" ' Set the IP address of the server
        Dim PortNumber As Integer = 3307 ' Set the port number used by the server

        Try
            ClientSocket.Connect(ServerAddress, PortNumber)
        Catch ex As Exception
            Return False
        End Try
        Return True

    End Function

    Private Function zap(process As String) As Boolean

        Print("Stopping " + process)
        ' Kill process by name
        For Each P As Process In System.Diagnostics.Process.GetProcessesByName(process)
            P.Kill()
        Next
        Print("")
        Return True
    End Function


    Private Sub Busy_Click(sender As System.Object, e As System.EventArgs) Handles BusyButton.Click

        ' Busy click shows we are busy

        Dim result As Integer = MessageBox.Show("Do you want to Abort?", "caption", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Print("Stopping")
            Application.DoEvents()
            ZapAll()
            Buttons(StartButton)
            Print("")
        End If
    End Sub

    Private Function Buttons(button As System.Object) As Boolean

        ' Turns off all 4 stacked buttons, then enables one of them
        BusyButton.Visible = False
        StopButton.Visible = False
        StartButton.Visible = False
        InstallButton.Visible = False
        button.Visible = True
        Print("")
        Return True

    End Function

    Private Function ZapAll()

        zap("OpenSim")
        zap("mysqld-nt")
        zap("httpd")
        zap("Mowes")
        Application.DoEvents()
        Return True
    End Function



    Private Sub Create_ShortCut(ByVal sTargetPath As String, _
                                ByVal sShortCutPath As String, _
                                ByVal sShortCutName As String, _
                                Optional ByVal sArguments As String = "", _
                                Optional ByVal sWorkPath As String = "", _
                                Optional ByVal eWinStyle As WshWindowStyle = vbNormalFocus, _
                                Optional ByVal iIconNum As Integer = 0)

        ' Requires reference to Windows Script Host Object Model
        Dim oShell As IWshRuntimeLibrary.WshShell
        Dim oShortCut As IWshRuntimeLibrary.WshShortcut

        oShell = New IWshRuntimeLibrary.WshShell
        oShortCut = oShell.CreateShortcut(oShell.SpecialFolders(sShortCutPath) & _
                                              "\" & sShortCutName & ".lnk")
        With oShortCut
            .TargetPath = sTargetPath
            .Arguments = sArguments
            .WorkingDirectory = sWorkPath
            .WindowStyle = eWinStyle
            .IconLocation = sTargetPath & "," & iIconNum
            .Save()
        End With

        oShortCut = Nothing : oShell = Nothing
    End Sub

    Private Sub Print(Value As String)
        Label.Text = Value
        Application.DoEvents()
    End Sub
End Class

