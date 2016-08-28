Imports System
Imports System.IO
Imports System.Text
Imports System.Threading



Public Class Form1

    Private Declare Sub Sleep Lib "kernel32.dll" (ByVal Milliseconds As Integer)

    Dim CurDrive    ' Holds the current drive that we are on F:\
    Dim InstallTo  ' Holds a drive we need to copy files to
    Dim Thumb = False ' if true, only copy and setup Phoenix 
    Dim Webpage
    Dim ctr
    Dim DreamWorld

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim location As String = System.Environment.GetCommandLineArgs()(0)
        Dim appName As String = System.IO.Path.GetFileName(location)

        appName = Mid(appName, InStr(appName, " "))
        DreamWorld = Mid(appName, 1, InStr(appName, ".exe") - 1)

        Me.Text = "Setup " & DreamWorld
        Dim installed As Integer

        ctr = 0
        installed = False
        ComboBox1.Visible = False
        Label.Visible = False
        CurDrive = Path.GetPathRoot(My.Application.Info.DirectoryPath)

        ' Find out if we are running this on the Installed Drive
        If Dir(CurDrive & "\" & DreamWorld & "\") <> "" Then
            installed = True
            Install.Visible = False
            Start.Visible = True

            Me.Text = "Start " & DreamWorld
        Else
            Install.Visible = True
            Start.Visible = False

            Dim allDrives() As DriveInfo = DriveInfo.GetDrives()
            Dim d As DriveInfo
            Dim enough As Boolean

            'MsgBox(Path.GetPathRoot(My.Application.Info.DirectoryPath))

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
        mowes = Shell(CurDrive & DreamWorld & "\Mowes.exe")

        If (mowes > 0) Then
            ' success
            WebBrowser1.Navigate("http://127.0.0.1:62535/start/up.htm")
        Else
            MsgBox("Something went wrong. Cannot launch '" & CurDrive & DreamWorld & "\Mowes.exe'", vbAbort)
        End If


    End Sub

    Private Sub Install_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Install.Click
        Dim response
        response = MsgBox("Press Yes to begin to copy files", vbYesNo, "File copy")
        If response = vbYes Then
            Dim allDrives() As DriveInfo = DriveInfo.GetDrives()
            Dim d As DriveInfo

            For Each d In allDrives
                If d.IsReady = True Then

                    Dim isThere
                    isThere = My.Computer.FileSystem.FileExists(d.Name & "How_to_Start_and_Login.txt")
                    If isThere Then
                        CurDrive = d.Name
                        My.Computer.FileSystem.CreateDirectory(InstallTo & DreamWorld)
                        My.Computer.FileSystem.CopyDirectory(CurDrive & "DreamWorldFiles", InstallTo & DreamWorld, showUI:=FileIO.UIOption.AllDialogs)
                        My.Computer.FileSystem.CopyDirectory(CurDrive & "Setup", InstallTo & DreamWorld, showUI:=FileIO.UIOption.AllDialogs)
                        Shell(CurDrive & "Firestorm\Phoenix_Firestorm.exe", AppWinStyle.NormalFocus, True)

                        CurDrive = InstallTo

                        ' allow them to launch now
                        Install.Visible = False
                        Start.Visible = True

                        ComboBox1.Visible = False
                        Label.Visible = False
                    End If
                End If
            Next


          


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
            Dim OpenSim
            ChDir(CurDrive & DreamWorld & "\diva-r20232-b\bin\")

            If Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Windows) & "\SysWOW64") Then
                OpenSim = Shell(CurDrive & DreamWorld & "\diva-r20232-b\bin\OpenSim.32BitLaunch.exe")
            Else
                OpenSim = Shell(CurDrive & DreamWorld & "\diva-r20232-b\bin\OpenSim.exe")
            End If

            If (OpenSim > 0) Then
                Sleep(30000)
                ctr = 0
                WebBrowser2.Navigate("http://127.0.0.1:9100/wifi/up.htm")
            Else
                MsgBox("Simulator did not start", vbCritical)
                End
            End If

        Else
            Sleep(1000)
            WebBrowser1.Navigate("http://127.0.0.1:62535/start/up.htm")
        End If


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        InstallTo = ComboBox1.SelectedItem

    End Sub


    Private Sub WebBrowser2_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser2.DocumentCompleted

        Webpage = WebBrowser1.DocumentText

        ctr = ctr + 1
        If ctr > 60 Then
            MsgBox("Database and Web Server did not start", vbCritical)
            End
        End If

        If Webpage = "Up" Then

            ctr = 0
            Dim Phoenix
            Phoenix = Shell(CurDrive & "Program Files (x86)\Firestorm-Release\Firestorm-Release.exe --channel Firestorm-Release  --settings settings_firestorm-release_v4.xml --set InstallLanguage en --loginuri http://127.0.0.1:9100  --loginpage http://127.0.0.1:9100/wifi")
            If (Phoenix) Then
                End
            Else
                MsgBox("Cannot launch the Phoenix viewer,  You can run it or another viewer with the parameter '--loginuri http://127.0.0.1:9100' added to the end of the shortcut.  Exiting", vbCritical)
                End
            End If

        Else
            Sleep(1000)

            WebBrowser2.Navigate("http://127.0.0.1:9100/wifi/up.htm")
        End If

    End Sub

   
End Class

