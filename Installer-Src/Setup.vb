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
    Dim DreamWorldName

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim location As String = System.Environment.GetCommandLineArgs()(0)
        Dim appName As String = System.IO.Path.GetFileName(location)

        appName = Mid(appName, InStr(appName, " "))
        DreamWorldName = Mid(appName, 1, InStr(appName, ".vshost") - 1)

        Me.Text = "Setup " & DreamWorldName
        Dim installed As Integer

        ctr = 0
        installed = False
        ComboBox1.Visible = False
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
        mowes = Shell(CurDrive & DreamWorldName & "\Mowes.exe")

        If (mowes > 0) Then
            ' success
            ctr = 0 ' retry counter - lets give them a minute to get on
            Sleep(10000)
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

            ' Shell(Dir & "\Viewer\Phoenix_Firestorm.exe", AppWinStyle.NormalFocus, True)


            Dim appData As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData
            
            Dim path As String
            path = Mid(appData, 1, InStr(appData, "AppData") - 1)

            ' System.Windows.Forms.Application.UserAppDataPath

            My.Computer.FileSystem.CopyFile(Dir & "\Viewer\grids_sg1.xml", path + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml", Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)


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
            Dim OpenSim
            ChDir(CurDrive & DreamWorldName & "\Opensim\bin\")

            OpenSim = Shell(CurDrive & DreamWorldName & "\Opensim\bin\OpenSim.exe")

            If (OpenSim > 0) Then
                Sleep(10000)
                ctr = 0 ' retry counter - lets give them a minute to get on
                WebBrowser2.Navigate("http://127.0.0.1:9100/wifi/up.html")
            Else
                MsgBox("Simulator did not start", vbCritical)
                End
            End If

        Else
            ' retry 
            Sleep(1000)
            WebBrowser1.Navigate("http://127.0.0.1:62535/start/up.html")
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
            Dim Phoenix
            Phoenix = Shell(CurDrive & "Program Files (x86)\Onlook\OnLookViewer.exe")
            If (Phoenix) Then
                End
            Else
                MsgBox("Cannot launch the Onlook viewer,  You can try to run it (or another viewer) and add http://127.0.0.1:9100' in the Grid Manager.  Exiting", vbCritical)
                End
            End If

        Else
            Sleep(1000)

            WebBrowser2.Navigate("http://127.0.0.1:9100/wifi/up.html")
        End If

    End Sub

   
End Class

