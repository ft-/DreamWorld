Imports System
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Net.Sockets
Imports IWshRuntimeLibrary
Imports IniParser

' Copyright 2014 Fred Beckhusen  
' Redistribution and use in binary and source form is permitted provided 
' that ALL the licenses in the text files are followed and included in all copies
'
' revision 0.2.1 2014-01-1 Initial Dreamworld with horse
' revision 0.2.1 2016-09-05 Initial release in new form as a bare sim
' revision 0.2.2 2016-09-06 Zap all process if forced closed by X
' revision 0.2.3 2016-09-10 Add Icons and messages
' revision 0.2.4 2016-09-10 Handle Opensim.ini for camera and viewer UI
' revision 0.3.0 2016-09-10 Released new UI
' revision 0.3.1 2016-09-11 Standalone + OsGrid

' Command line args:
' clean makes it wipe out Opensim files that are not needed for zipping
' debug forces this to use the \Dreamworlds folder for testing 

Public Class Form1

    Dim CurDir    ' Holds the current folder that we are running in
    Dim ctr As Integer  ' global retry counter
    Dim Running As Boolean ' global running flag
    Dim MyGrid ' holds the Grid folder name
    Private Declare Sub Sleep Lib "kernel32.dll" (ByVal Milliseconds As Integer)

    Private Sub Form1_Leave(sender As Object, e As System.EventArgs) Handles Me.Leave

        ' Needed to stop Opensim
        ZapAll()
        End

    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim arguments As String() = Environment.GetCommandLineArgs()

        Running = False ' global flag is true when opensim is running

        CurDir = My.Application.Info.DirectoryPath


        If arguments.Length > 1 Then
            ' for debugging when compiling
            If arguments(1) = "clean" Then
                ' Clean up the file system
                CleanAll()
            ElseIf arguments(1) = "debug" Then
                CurDir = "\DreamWorld"
            End If
        End If

        ' Set the INI files for the selected grid
        SetGridValues()

        ' Find out if the viewer is installed 
        If System.IO.File.Exists(CurDir & "\DreamworldFiles\Init") Then
            Buttons(StartButton)
            TextBox1.Text = "Opensimulator is ready to start in " & MyGrid & " Mode"
        Else
            Dim fs As FileStream = System.IO.File.Create(CurDir & "\DreamworldFiles\Init")
            Buttons(InstallButton)
        End If
        Application.DoEvents()

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

        ' start Opensimulator
        Dim Webpage = WebBrowser1.DocumentText

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
            ChDir(CurDir & "\DreamWorldFiles\" & MyGrid & "\bin\")

            Dim p As Process = New Process()
            Dim pi As ProcessStartInfo = New ProcessStartInfo()

            ' http://opensimulator.org/wiki/OpenSim.exe_Command_Line_Options

            If mnuHide.Checked Then
                pi.Arguments = "-console rest -background True "
                pi.WindowStyle = ProcessWindowStyle.Hidden
            End If

            pi.FileName = CurDir & "\DreamWorldFiles\" & MyGrid & "\bin\OpenSim.exe"
            p.StartInfo = pi
            p.Start()
            Application.DoEvents()
            Sleep(5000)

            ctr = 0 ' retry counter - lets give them a minute to get on
            WebBrowser2.Navigate("http://127.0.0.1:9100/wifi/up.html")
            WebBrowser2.Refresh(WebBrowserRefreshOption.Completely)
        Else
            MsgBox("Simulator did not start", vbCritical)
            Buttons(StopButton)
            ZapAll()
        End If
        Application.DoEvents()

    End Sub

    Private Sub WebBrowser2_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser2.DocumentCompleted

        ' Start Onlook Viewer
        Dim Webpage = WebBrowser2.DocumentText

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

            Dim p As Process = New Process()
            Dim pi As ProcessStartInfo = New ProcessStartInfo()
            pi.Arguments = ""
            pi.FileName = "C:\Program Files (x86)\Onlook\OnLookViewer.exe"
            pi.WindowStyle = ProcessWindowStyle.Normal
            p.StartInfo = pi
            p.Start()

            ' Show the web console
            If mnuAdminShow.Checked Then
                Dim webAddress As String = "http://127.0.0.1:9100/wifi"
                Process.Start(webAddress)
            End If

            Buttons(StopButton)

            Print("Login as 'Simon Stick', password is '123'")
            Sleep(5)
            Print("")

        Else
            Application.DoEvents()
            Sleep(1000)
            WebBrowser2.Navigate("http://127.0.0.1:9100/wifi/up.html")
            WebBrowser2.Refresh(WebBrowserRefreshOption.Completely)
        End If
        Application.DoEvents()

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
            Try
                P.Kill()
            Catch
                ' nothing
            End Try

        Next
        Print("")
        Return True

    End Function


    Private Sub Busy_Click(sender As System.Object, e As System.EventArgs)

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
        Running = False
        Return True

    End Function

    Private Sub Create_ShortCut(ByVal sTargetPath As String)

        ' Requires reference to Windows Script Host Object Model
        Dim WshShell As WshShellClass = New WshShellClass
        Dim MyShortcut As IWshRuntimeLibrary.IWshShortcut

        ' The shortcut will be created on the desktop
        Dim DesktopFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
        MyShortcut = CType(WshShell.CreateShortcut(DesktopFolder & "\Dreamworld.lnk"), IWshRuntimeLibrary.IWshShortcut)
        MyShortcut.TargetPath = sTargetPath
        MyShortcut.IconLocation = WshShell.ExpandEnvironmentStrings(CurDir & "\Start.exe, 0 ")
        MyShortcut.WorkingDirectory = CurDir
        MyShortcut.Save()

    End Sub

    Private Sub Print(Value As String)

        TextBox1.Text = Value
        Application.DoEvents()
        Sleep(100)  ' time to read

    End Sub

    Private Sub mnuExit_Click(sender As System.Object, e As System.EventArgs) Handles mnuExit.Click

        Print("Stopping")
        Application.DoEvents()
        ZapAll()
        Buttons(StartButton)
        Print("")
        End

    End Sub

    Private Sub mnuLogin_Click(sender As System.Object, e As System.EventArgs) Handles mnuLogin.Click

        Print("Use to OnLook Viewer to log in.  User 'Simona Stick' has a password of '123'. You can use the Web UI Interface to create a new avatar.")

    End Sub

    Private Sub mnuAbout_Click(sender As System.Object, e As System.EventArgs) Handles mnuAbout.Click

        Print("(c) 2014 www.Outworldz.com")
        Dim webAddress As String = "http://www.outworldz.com/Dreamworld"
        Process.Start(webAddress)

    End Sub

    Private Sub StartButton_Click(sender As System.Object, e As System.EventArgs) Handles StartButton.Click

        ' Start Mowes, which starts MySql and Apache automatically.
        Print("DreamWorlds is starting the web server and database engines.")

        Buttons(BusyButton)
        Running = True

        Try
            My.Computer.FileSystem.DeleteFile(CurDir + "\DreamWorldFiles" & MyGrid & "\bin\Opensim.log")
        Catch ex As Exception
            ' do nothing
        End Try

        Try
            My.Computer.FileSystem.DeleteFile(CurDir + "\DreamWorldFiles\" & MyGrid & "\bin\OpenSimConsoleHistory.txt")
        Catch ex As Exception
            ' do nothing
        End Try

        Print("Starting Database And Web Server")

        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = ""

        If mnuHide.Checked Then
            pi.WindowStyle = ProcessWindowStyle.Hidden
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
                MsgBox("Timeout running MySQL - cannot continue", vbAbort)
                ZapAll()
                Buttons(StopButton)
                Return
            End If

            ' now check that SQL server has started

            Status = CheckMySQL()
            If Status Then
                iSRunning = 0
                Print("Database Is Up")
            End If
        End While
        ctr = 0 ' retry counter reset - lets give them a minute to get on
        WebBrowser1.Navigate("http: //127.0.0.1:62535/start/up.htm?id=" + Random())

        Application.DoEvents()

    End Sub

    Private Sub StopButton_Click_1(sender As System.Object, e As System.EventArgs) Handles StopButton.Click

        Print("Opensim is Stopped. Click Start.")

        Buttons(BusyButton)
        Print("Stopping")
        ZapAll()
        Buttons(StartButton)
        Print("")

    End Sub

    Private Sub InstallButton_Click(sender As System.Object, e As System.EventArgs) Handles InstallButton.Click

        Buttons(BusyButton)
        Print("Installing...")

        Print("Installing Shortcut")
        Create_ShortCut(CurDir & "\Start.exe")
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
        Print("Ready to Launch. Click 'Start' to boot Opensimulator")
        Buttons(StartButton)

    End Sub


    Private Sub ShowToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles mnuShow.Click

        Print("The Opensimulator Console will be shown when the system is running")
        mnuShow.Checked = True
        mnuHide.Checked = False
        My.Settings.Console = mnuShow.Checked
        My.Settings.Save()

        If Running Then
            Print("The Opensimulator Console will be shown the next time the system is started")
        End If

    End Sub

    Private Sub mnuHide_Click(sender As System.Object, e As System.EventArgs) Handles mnuHide.Click

        Print("The Opensimulator Console will not be shown. You can still interact with it with Opensimulator->View UI")
        mnuShow.Checked = False
        mnuHide.Checked = True
        My.Settings.Save()

        If Running Then
            Print("The Opensimulator Console will not be shown. Change will occur when the system is restarted")
        End If

    End Sub

    Private Sub mnuEasy_Click_1(sender As System.Object, e As System.EventArgs) Handles mnuEasy.Click

        Print("Onlook Viewer is set for Easy UI mode.")
        mnuEasy.Checked = True
        mnuFull.Checked = False
        My.Settings.Viewer = mnuEasy.Checked
        My.Settings.Save()

        SetIni(MyGrid & "\bin\Opensim.ini", "SpecialUIModule", "enabled", "true")

        If Running Then
            MsgBox("Onlook Viewer is set for Easy UI mode. Change will occur when the sim is restarted", vbInformation)
        End If

    End Sub

    Private Sub mnuFull_Click(sender As System.Object, e As System.EventArgs) Handles mnuFull.Click

        Print("Onlook Viewer is set for the Full UI mode.")
        mnuEasy.Checked = False
        mnuFull.Checked = True
        My.Settings.Viewer = mnuEasy.Checked
        My.Settings.Save()

        SetIni(MyGrid & "\bin\Opensim.ini", "SpecialUIModule", "enabled", "false")

        If Running Then
            MsgBox("Onlook Viewer is set for the Full UI mode. Change will occur when the sim is restarted", vbInformation)
        End If

    End Sub

    Private Sub NoneToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles mnuNoAvatar.Click

        Print("Your Avatar will not be shown. Use the Arrow keys to move around. Use Page Up and Page Down to move the camera Up and Down.")

        mnuNoAvatar.Checked = True
        mnuYesAvatar.Checked = False

        My.Settings.Avatar = False
        My.Settings.Save()

        SetIni(MyGrid & "\bin\Opensim.ini", "CameraOnlyModeModule", "enabled", "true")

        If Running Then
            MsgBox("Your Avatar will not be shown when you log in. Change will occur when the Viewer is next logged in.", vbInformation)
        End If

    End Sub

    Private Sub VisibleToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles mnuYesAvatar.Click

        Print("Your Avatar will be shown when you log in. Use the Arrow keys to move around. Use Page Up and Page Down to move the camera Up and Down.  Change will occur when the Viewer is next logged in")
        mnuYesAvatar.Checked = True
        mnuNoAvatar.Checked = false

        My.Settings.Avatar = True
        My.Settings.Save()

        SetIni(MyGrid & "\bin\Opensim.ini", "CameraOnlyModeModule", "enabled", "false")

        If Running Then
            MsgBox("Your Avatar will be shown. Change will occur when the Viewer is next logged in. ", vbInformation)
        End If

    End Sub

    Private Sub HideToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles mnuAdminHide.Click

        Print("DreamWorlds is set to hide the Opensimulator Web Admin page. You can still access the console via the web interface.")
        mnuAdminShow.Checked = False
        mnuAdminHide.Checked = True
        My.Settings.Admin = mnuAdminShow.Checked
        My.Settings.Save()

    End Sub

    Private Sub ShowToolStripMenuItem_Click_1(sender As System.Object, e As System.EventArgs) Handles mnuAdminShow.Click

        Print("DreamWorlds is set to show the Openimulator Web interface after it starts.")
        mnuAdminShow.Checked = True
        mnuAdminHide.Checked = False
        My.Settings.Admin = mnuAdminShow.Checked
        My.Settings.Save()

    End Sub

    Private Function Random() As String

        Dim value As Integer = CInt(Int((6000 * Rnd()) + 1))
        Return Str(value)

    End Function


    Private Sub WebUIToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WebUi.Click

        Print("The Web UI lets you add or view settings for the default avatar. ")
        If Running Then
            Dim webAddress As String = "http://127.0.0.1:9100/wifi"
            Process.Start(webAddress)
        End If

    End Sub

    Private Sub ShutdownNowToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ShutdownNowToolStripMenuItem.Click

        Print("Stopping")
        Application.DoEvents()
        ZapAll()
        Buttons(StartButton)
        Print("")

    End Sub

    Private Function GetIni(filepath As String, section As String, key As String) As String

        ' gets values from an INI file
        Dim parser = New FileIniDataParser()
        parser.Parser.Configuration.CommentString = ";" ' Opensim uses semicolons

        Dim Data = parser.ReadFile(CurDir + "\DreamWorldFiles\" & filepath)
        Dim value = Data(section)(key)
        Return value

    End Function

    Private Function SetIni(filepath As String, section As String, key As String, value As String) As Boolean

        ' sets values into any INI file
        Dim parser = New FileIniDataParser()
        parser.Parser.Configuration.CommentString = ";" ' Opensim uses semicolons
        parser.Parser.Configuration.SkipInvalidLines = True

        Dim Data = parser.ReadFile(CurDir + "\DreamWorldFiles\" & filepath)

        Dim oldvalue = Data(section)(key)

        Data(section)(key) = value ' replace it and save it
        parser.WriteFile(CurDir + "\DreamWorldFiles\" & filepath, Data)
        Return True
        '
    End Function
    Private Function CleanAll()
        Clean("Local")
        Clean("OsGrid")
        Return True
    End Function
    Private Function Clean(AGrid As String)

        Try
            System.IO.Directory.Delete(CurDir & "\DreamWorldFiles\" & AGrid & "\bin\addin-db-002", True)
        Catch
        End Try
        Try
            System.IO.Directory.Delete(CurDir & "\DreamWorldFiles\" & AGrid & "\bin\assetcache", True)
        Catch
        End Try
        Try
            System.IO.Directory.Delete(CurDir & "\DreamWorldFiles\" & AGrid & "\bin\DataSnapshot", True)
        Catch
        End Try
        Try
            System.IO.Directory.Delete(CurDir & "\DreamWorldFiles\" & AGrid & "\bin\ScriptEngines", True)
        Catch
        End Try
        Try
            System.IO.Directory.Delete(CurDir & "\DreamWorldFiles\" & AGrid & "\bin\MapTiles", True)
        Catch
        End Try

        Try
            My.Computer.FileSystem.DeleteFile(CurDir + "\DreamWorldFiles" & AGrid & "\bin\Opensim.log")
        Catch ex As Exception
            ' do nothing
        End Try
        Try
            My.Computer.FileSystem.DeleteFile(CurDir + "\DreamWorldFiles\" & AGrid & "\bin\OpenSimConsoleHistory.txt")
        Catch ex As Exception
        End Try
        Try
            My.Computer.FileSystem.DeleteFile(CurDir + "\DreamWorldFiles\Init")
        Catch ex As Exception
        End Try

        MsgBox("System is Clean")
        End
    End Function

    Private Sub mnuOsGrid_Click(sender As Object, e As EventArgs) Handles mnuOsGrid.Click
        MyGrid = "OsGrid"
        My.Settings.Grid = MyGrid
        My.Settings.Save()
        mnuOsGrid.Checked = True
        mnuLocal.Checked = False
        SetGridValues()
        Print("DreamWorlds will connect to OsGrid.org. You must log in with an Avatar name registered with OsGrid.org. You must also 'Port Forward' your router to this machine on port 8000 for Tcp and Udp traffic")
    End Sub

    Private Sub mnuLocal_Click(sender As Object, e As EventArgs) Handles mnuLocal.Click
        MyGrid = "Local"
        My.Settings.Grid = MyGrid
        My.Settings.Save()
        mnuOsGrid.Checked = False
        mnuLocal.Checked = True
        SetGridValues()
        Print("DreamWorlds will connect to your own locally hosted sim. You must log in with the name 'Simon Stick' with a password of 123'")
    End Sub

    Private Function SetGridValues()

        MyGrid = My.Settings.Grid       ' which grid are we running, OsGrid, or 'Local' folder Opensim

        'mnuShow shows the DOS box for Opensimulator
        mnuShow.Checked = My.Settings.Console
        mnuHide.Checked = Not My.Settings.Console

        ' Admin shows the Web UI
        mnuAdminShow.Checked = My.Settings.Admin
        mnuAdminHide.Checked = Not My.Settings.Admin

        ' Viewer UI shows the full viewer UI
        If My.Settings.Viewer Then
            SetIni(MyGrid & "\bin\Opensim.ini", "SpecialUIModule", "enabled", "false")
        Else
            SetIni(MyGrid & "\bin\Opensim.ini", "SpecialUIModule", "enabled", "true")
        End If
        mnuFull.Checked = My.Settings.Viewer
        mnuEasy.Checked = Not My.Settings.Viewer


        'Avatar visible?
        If My.Settings.Avatar Then
            SetIni(MyGrid & "\bin\Opensim.ini", "CameraOnlyModeModule", "enabled", "false")
        Else
            SetIni(MyGrid & "\bin\Opensim.ini", "CameraOnlyModeModule", "enabled", "true")
        End If
        mnuYesAvatar.Checked = My.Settings.Avatar
        mnuNoAvatar.Checked = Not My.Settings.Avatar

        ' Grid
        If MyGrid = "Local" Then
            mnuLocal.Checked = True
            mnuOsGrid.Checked = False
        Else
            mnuLocal.Checked = False
            mnuOsGrid.Checked = True
        End If

        ' Autobackup
        If My.Settings.AutoBackup Then
            SetIni(MyGrid & "\bin\Opensim.ini", "AutoBackupModule", "AutoBackupModuleEnabled", "true")
            AutoYes.Checked = True
            AutoNo.Checked = False
            My.Settings.AutoBackup = True
        Else
            SetIni(MyGrid & "\bin\Opensim.ini", "AutoBackupModule", "AutoBackupModuleEnabled", "false")
            AutoYes.Checked = False
            AutoNo.Checked = True
            My.Settings.AutoBackup = False
        End If

        Return True
    End Function

    Private Sub YesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoYes.Click
        Print("DreamWorlds is set Autoback the sim into an OAR every 24 hours. Oars are saved in \bin\AutoBackup")
        AutoYes.Checked = True
        AutoNo.Checked = False
        My.Settings.AutoBackup = True
        My.Settings.Save()
    End Sub

    Private Sub AutoNo_Click(sender As Object, e As EventArgs) Handles AutoNo.Click
        Print("Backups disabled")
        AutoYes.Checked = False
        AutoNo.Checked = True
        My.Settings.AutoBackup = False
        My.Settings.Save()
    End Sub
End Class

