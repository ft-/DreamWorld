Imports System
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Net.Sockets


Public Class Form1

    Private Declare Sub Sleep Lib "kernel32.dll" (ByVal Milliseconds As Integer)

    Dim CurDrive    ' Holds the current drive that we are on F:\
    Dim InstallTo  ' Holds a drive we need to copy files to
    Dim Thumb = False ' if true, only copy and setup Phoenix 
    Dim Webpage
    Dim ctr
    Dim DreamWorldName

    Private Sub Form1_Leave(sender As Object, e As System.EventArgs) Handles Me.Leave
        System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim location As String = System.Environment.GetCommandLineArgs()(0)
        Dim appName As String = System.IO.Path.GetFileName(location)

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
        StopButton.Visible = False

        Label.Visible = False
        CurDrive = Path.GetPathRoot(My.Application.Info.DirectoryPath)

        ' Find out if we are running this on the Installed Drive
        If Dir(CurDrive & "\" & DreamWorldName & "\") <> "" Then
            installed = True
            Install.Visible = False
            Start.Visible = True

            Me.Text = "Start " & DreamWorldName
        Else
            Install.Visible = True
            Start.Visible = False

            Dim allDrives() As DriveInfo = DriveInfo.GetDrives()
            Dim d As DriveInfo
            Dim enough As Boolean

            enough = False ' enough space?
            For Each d In allDrives
                If d.IsReady = True Then
                    If (d.TotalFreeSpace > 2000000.0 And (d.DriveType = 3 Or d.DriveType = 4)) Then
                        ComboBox1.Items.Add(d.Name)
                        enough = True
                    End If
                End If
            Next
            If enough = True Then
                ComboBox1.SelectedIndex = 0
                ComboBox1.Visible = True
                Label.Visible = True
            Else
                CurDrive = Path.GetPathRoot(My.Application.Info.DirectoryPath)
                Thumb = True
                ComboBox1.Visible = False
                Label.Visible = False
            End If
        End If

    End Sub

    Private Sub Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Start.Click

        Dim mowes
        StopButton.Visible = True
        mowes = Shell(CurDrive & DreamWorldName & "\Mowes.exe")


        If (mowes > 0) Then
            ' success

            Dim iSRunning As Integer
            iSRunning = 30000
            Dim Status = 0

            While iSRunning > 0
                Sleep(10000)
                iSRunning = iSRunning - 1
                Status = CheckMySQL()
                If Status Then
                    iSRunning = 0
                End If

            End While


            ctr = 0 ' retry counter - lets give them a minute to get on

            WebBrowser1.Navigate("http://127.0.0.1:62535/start/up.htm")

        Else
            MsgBox("Something went wrong. Cannot launch '" & CurDrive & DreamWorldName & "\Mowes.exe'", vbAbort)
        End If


    End Sub

    Private Sub Install_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Install.Click
        Dim response
        response = MsgBox("Press Yes to begin to copy files", vbYesNo, "File copy")
        If response = vbYes Then

            Dim Dir As String
            Dir = CurDir()

            ' debug only
            Dir = "C:\Opensim\DreamWorld-GitHub"

            My.Computer.FileSystem.CreateDirectory(InstallTo & DreamWorldName)
            My.Computer.FileSystem.CopyDirectory(Dir & "\DreamWorldFiles", InstallTo & DreamWorldName, showUI:=FileIO.UIOption.AllDialogs)

            Dim p As Process = New Process()
            Dim pi As ProcessStartInfo = New ProcessStartInfo()
            pi.Arguments = ""
            pi.FileName = Dir & "\Viewer\Onlook.exe"
            p.StartInfo = pi
            p.Start()

            Dim appData As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData

            Dim path As String
            path = Mid(appData, 1, InStr(appData, "AppData") - 1)

            My.Computer.FileSystem.CopyFile(Dir & "\Viewer\grids_sg1.xml", path + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml", True)

            CurDrive = InstallTo

            ' allow them to launch now
            Install.Visible = False
            Start.Visible = True

            ComboBox1.Visible = False
            Label.Visible = False

        End If

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

        'When webbrower finish opening the page, source page is diplayed in text box
        
        Webpage = WebBrowser1.DocumentText

        ctr = ctr + 1
        If ctr > 60 Then
            MsgBox("Database and Web Server did not start", vbCritical)
            End
        End If

        If Webpage = "Up" Then

            '  Launch(OpenSim)
            ' need to detect 32 vs 64 bit here, for now, 64

            ChDir(CurDrive & DreamWorldName & "\Opensim\bin\")

            Dim p As Process = New Process()
            Dim pi As ProcessStartInfo = New ProcessStartInfo()

            ' http://opensimulator.org/wiki/OpenSim.exe_Command_Line_Options
            ' -console=rest
            ' -background=True 

            pi.Arguments = ""
            pi.FileName = CurDrive & DreamWorldName & "\Opensim\bin\OpenSim.exe"
            p.StartInfo = pi
            p.Start()

            Sleep(10000)
            ctr = 0 ' retry counter - lets give them a minute to get on
            WebBrowser2.Navigate("http://127.0.0.1:9100/wifi/up.html")
        Else
            MsgBox("Simulator did not start", vbCritical)
            End
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        InstallTo = ComboBox1.SelectedItem
    End Sub


    Private Sub WebBrowser2_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser2.DocumentCompleted

        Webpage = WebBrowser2.DocumentText

        ctr = ctr + 1
        If ctr > 60 Then
            MsgBox("Database and Web Server did not start", vbCritical)
            End
        End If

        If Webpage = "Up" Then

            ctr = 0
            Dim Viewer
            Viewer = Shell(CurDrive & "Program Files (x86)\Onlook\OnLookViewer.exe")
            If (Viewer) Then
                ' Show the console
                Dim webAddress As String = "http://127.0.0.1:9100/wifi"
                Process.Start(webAddress)
                StopButton.Visible = True
            Else
                MsgBox("Cannot launch the Onlook viewer,  You can try to run it (or another viewer) and add http://127.0.0.1:9100' in the Grid Manager.  Exiting", vbCritical)
                End
            End If

        Else
            Sleep(1000)

            WebBrowser2.Navigate("http://127.0.0.1:9100/wifi/up.html")
        End If

    End Sub


    Private Sub StopButton_Click(sender As System.Object, e As System.EventArgs) Handles StopButton.Click

        Shell("""C:\Windows\System32\taskkill.exe /FI ""IMAGENAME eq OpenSim.*""", AppWinStyle.MinimizedFocus, True)
        Shell("""C:\Windows\System32\taskkill.exe /F /FI ""IMAGENAME eq mysqld-nt.*""", AppWinStyle.MinimizedFocus, True)
        Shell("""C:\Windows\System32\taskkill.exe /FI ""IMAGENAME eq httpd.*""", AppWinStyle.MinimizedFocus, True)
        Shell("""C:\Windows\System32\taskkill.exe /FI ""IMAGENAME eq Mowes*""", AppWinStyle.MinimizedFocus, True)
        End
    End Sub

    Private Function CheckMySQL() As Boolean

        Dim ClientSocket As New TcpClient
        Dim ServerAddress As String = "127.0.0.1" ' Set the IP address of the server
        Dim PortNumber As Integer = 3307 ' Set the port number used by the server

        Try
            ClientSocket.Connect(ServerAddress, PortNumber)
        Catch ex As Exception
            Return False
        End Try

        Return (True)

    End Function

End Class
