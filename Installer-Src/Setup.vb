Imports System
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Net.Sockets

Public Class Form1

    Private Declare Sub Sleep Lib "kernel32.dll" (ByVal Milliseconds As Integer)

    Dim CurDrive    ' Holds the current drive that we are on F:\
    Dim InstallTo  ' Holds a drive we need to copy files to
    Dim Webpage As String
    Dim ctr As Integer
    Dim DreamWorldName As String
    Dim Opensim As Process

    ' Needed for some systems to clean up the stack, better be safe
    Private Sub Form1_Leave(sender As Object, e As System.EventArgs) Handles Me.Leave
        System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim location As String = System.Environment.GetCommandLineArgs()(0)
        Dim appName As String = System.IO.Path.GetFileName(location)

        ' locate the Start XXX name so we can install to XXX

        Dim l As Integer
        Dim appString = Mid(appName, InStr(appName, " "))
        If (Len(appName)) Then
            l = InStr(appString, ".")
            DreamWorldName = Mid(appString, 1, l - 1)
        Else
            MsgBox("Cannot locate file name: " + appName, vbAbort)
        End If

        Me.Text = "Setup " & DreamWorldName
        Dim installed As Integer

        ctr = 0
        installed = False
        ComboBox1.Visible = False

        InstallButton.Visible = False
        StartButton.Visible = False
        StopButton.Visible = False
        BusyButton.Visible = False

        Label.Visible = False
        CurDrive = Path.GetPathRoot(My.Application.Info.DirectoryPath)

        ' Find out if we are running this on the Installed Drive
        If Dir(CurDrive & "\" & DreamWorldName & "\") <> "" Then
            installed = True
            Buttons(StartButton)
            Me.Text = "Start " & DreamWorldName
        Else
            Buttons(InstallButton)
            Dim allDrives() As DriveInfo = DriveInfo.GetDrives()
            Dim d As DriveInfo
            Dim enough As Boolean

            enough = False ' enough space?
            For Each d In allDrives
                If d.IsReady = True Then
                    If (d.TotalFreeSpace > 3000000.0 And (d.DriveType = 3 Or d.DriveType = 4)) Then
                        ComboBox1.Items.Add(d.Name)
                        enough = True
                    End If
                End If
            Next
            If enough = True Then
                ComboBox1.SelectedIndex = 0
                ComboBox1.Visible = True
                Label.Visible = True
                Buttons(InstallButton)
            Else
                CurDrive = Path.GetPathRoot(My.Application.Info.DirectoryPath)
                ComboBox1.Visible = False
                Label.Visible = False
                MsgBox("No enough disk free space to install on any drive, needs 3 Gigs", vbAbort)
                End
            End If
        End If

    End Sub

    Private Sub Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        ' Start Mowes, which starts MySql and Apache automatically.
        Buttons(BusyButton)

        Label.Visible = True
        Label.Text = "Starting Mowes"

        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = ""

        If Not Console.Checked Then
            pi.WindowStyle = ProcessWindowStyle.Hidden
        End If
        pi.FileName = CurDrive & DreamWorldName & "\Mowes.exe"
        p.StartInfo = pi
        p.Start()

        Dim iSRunning As Integer
        iSRunning = 30000
        Dim Status = 0

        ' wait for Mowes to come up on port 62535
        While iSRunning > 0
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
                Label.Text = "MySql is Up"
            End If
        End While
        ctr = 0 ' retry counter reset - lets give them a minute to get on
        WebBrowser1.Navigate("http://127.0.0.1:62535/start/up.htm")

    End Sub

    Private Sub Install_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstallButton.Click

        Dim Dir As String
        Dir = CurDir()

        Buttons(BusyButton)

        Label.Visible = True
        Label.Text = "Installing Files to " + InstallTo & DreamWorldName

        ' FKB debug only
        Dir = "C:\Opensim\DreamWorld-GitHub"

        My.Computer.FileSystem.CreateDirectory(InstallTo & DreamWorldName)
        My.Computer.FileSystem.CopyDirectory(Dir & "\DreamWorldFiles", InstallTo & DreamWorldName, showUI:=FileIO.UIOption.AllDialogs)

        Label.Text = "Installing Onlook Viewer"

        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = ""
        pi.FileName = Dir & "\Viewer\Onlook.exe"
        p.StartInfo = pi
        p.Start()


        Label.Text = "Installing Grid Info"
        Dim appData As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData
        Dim path As String
        path = Mid(appData, 1, InStr(appData, "AppData") - 1)

        My.Computer.FileSystem.CopyFile(Dir & "\Viewer\grids_sg1.xml", path + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml", True)

        CurDrive = InstallTo

        ' allow them to launch now
        Label.Text = "Ready to Launch"
        Buttons(StartButton)

        ComboBox1.Visible = False

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

            Label.Text = "Starting Opensimulator"

            '  Launch(OpenSim)
            ChDir(CurDrive & DreamWorldName & "\Opensim\bin\")

            Dim p As Process = New Process()
            Dim pi As ProcessStartInfo = New ProcessStartInfo()

            ' http://opensimulator.org/wiki/OpenSim.exe_Command_Line_Options

            If Not Console.Checked Then
                pi.Arguments = "-console rest -background True "
                pi.WindowStyle = ProcessWindowStyle.Hidden
            End If

            pi.FileName = CurDrive & DreamWorldName & "\Opensim\bin\OpenSim.exe"
            p.StartInfo = pi
            p.Start()

            Sleep(5000)
            ctr = 0 ' retry counter - lets give them a minute to get on
            WebBrowser2.Navigate("http://127.0.0.1:9100/wifi/up.html")
        Else
            MsgBox("Simulator did not start", vbCritical)
            Buttons(StopButton)
            ZapAll()
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        InstallTo = ComboBox1.SelectedItem
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
            Label.Text = "Starting Onlook viewer"
            ctr = 0
            Dim Viewer
            Viewer = Shell(CurDrive & "Program Files (x86)\Onlook\OnLookViewer.exe")
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
            Sleep(1000)
            WebBrowser2.Navigate("http://127.0.0.1:9100/wifi/up.html")
        End If

    End Sub


    Private Sub StopButton_Click(sender As System.Object, e As System.EventArgs) Handles StopButton.Click

        Label.Visible = True
        Label.Text = "Stopping"
        Buttons(BusyButton)

        ZapAll()
        
        Buttons(StartButton)
        Label.Text = ""

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

        Label.Text = "Stopping " + process
        ' Kill process by name
        For Each P As Process In System.Diagnostics.Process.GetProcessesByName(process)
            P.Kill()
        Next
        Label.Text = ""
        Return True

    End Function


    Private Sub Busy_Click(sender As System.Object, e As System.EventArgs) Handles BusyButton.Click

        ' Busy click shows we are busy

        Dim result As Integer = MessageBox.Show("Do you want to Abort?", "caption", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Label.Visible = True
            Label.Text = "Stopping"
            ZapAll()
            Buttons(StartButton)
            Label.Text = ""
            Label.Visible = False
        End If

    End Sub

    Private Function Buttons(button As System.Object) As Boolean

        ' Turns off all 4 stacked buttons, then enables one of them
        BusyButton.Visible = False
        StopButton.Visible = False
        StartButton.Visible = False
        InstallButton.Visible = False
        button.Visible = True
        Label.Text = ""
        Label.Visible = False
        Application.DoEvents()

        Return True

    End Function

    Private Function ZapAll() As Boolean

        zap("OpenSim")
        zap("mysqld-nt")
        zap("httpd")
        zap("Mowes")

        Return True
    End Function

End Class
