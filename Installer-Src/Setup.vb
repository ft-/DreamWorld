Imports System.IO
Imports System.Net.Sockets
Imports IWshRuntimeLibrary
Imports IniParser


' Copyright 2014 Fred Beckhusen  
' Redistribution and use in binary and source form is permitted provided 
' that ALL the licenses in the text files are followed and included in all copies

' Command line args:
' clean makes it wipe out Opensim files that are not needed for zipping
' debug forces this to use the \Dreamworlds folder for testing 

Public Class Form1

    Dim gCurDir    ' Holds the current folder that we are running in
    Dim gCurSlashDir As String '  holds the current directory info in Unix format
    Dim isRunning As Boolean
    Private Declare Sub Sleep Lib "kernel32.dll" (ByVal Milliseconds As Integer)
    Dim ws As WebServer

    Private Sub Form1_Leave(sender As Object, e As System.EventArgs) Handles Me.Leave

        ws.StopWebServer()
        ' Needed to stop Opensim
        ZapAll()
        End

    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ZapAll()
        Running = False ' true when opensim is running
        gCurDir = My.Application.Info.DirectoryPath
        gCurSlashDir = gCurDir.Replace("\", "/")    ' becuase Mysql uses unix like slashes, that's why

        ProgressBar1.Visible = False
        ' I would like to buy an argument
        Dim arguments As String() = Environment.GetCommandLineArgs()

        If arguments.Length > 1 Then
            ' for debugging when compiling
            If arguments(1) = "clean" Then
                ' Clean up the file system
                CleanAll()
            ElseIf arguments(1) = "debug" Then
                gCurDir = "\DreamWorld" ' for testing, as the compiler buries itself in ../../../debug
                gCurSlashDir = "/DreamWorld"
            End If
        End If

        ' Set the INI files for the selected grid
        SetGridValues()

        Dim client As New System.Net.WebClient

        Try
            My.Settings.PublicIP = client.DownloadString("https://api.ipify.org")
        Catch ex As exception
            MsgBox("Cannot connect to the Internet", vbAbort)
            ZapAll()
            Buttons(StartButton)
            Return
        End Try

        ' Find out if the viewer is installed, make a file we can benchmark to
        If System.IO.File.Exists(gCurDir & "\DreamworldFiles\Init.txt") Then
            Buttons(StartButton)
            TextBox1.Text = "Opensimulator Is ready to start"
        Else
            Using outputFile As New StreamWriter(gCurDir & "\DreamworldFiles\Init.txt", True)
                Dim counter As Integer = 100
                While counter
                    outputFile.WriteLine("This file lets Dreamworld know it has been installed and to benchmark network loopback")
                    counter = counter - 1
                End While
            End Using
            Buttons(InstallButton)
        End If

        ws = WebServer.getWebServer
        ws.VirtualRoot = gCurDir & "\DreamWorldFiles\"
        ws.StartWebServer()

    End Sub
    Private Sub StartButton_Click(sender As System.Object, e As System.EventArgs) Handles StartButton.Click

        ProgressBar1.Visible = True
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = 100
        ProgressBar1.Value = 0

        Buttons(BusyButton)
        Running = True

        OpenPorts() ' Open router ports


        ' clear out the log files
        Try
            My.Computer.FileSystem.DeleteFile(gCurDir + "\DreamWorldFiles" & My.Settings.Grid & "\bin\Opensim.log")
        Catch ex As Exception
            ' do nothing
        End Try

        Try
            My.Computer.FileSystem.DeleteFile(gCurDir + "\DreamWorldFiles\" & My.Settings.Grid & "\bin\OpenSimConsoleHistory.txt")
        Catch ex As Exception
            ' do nothing
        End Try
        ProgressBar1.Value = 5

        ' Start MySql
        Print("Starting Database")

        SetIni(gCurDir & "\DreamWorldFiles\mysql\my.ini", "mysqld", "basedir", gCurSlashDir + "/DreamWorldFiles/mysql", "#")
        SetIni(gCurDir & "\DreamWorldFiles\mysql\My.ini", "mysqld", "datadir", gCurSlashDir + "/DreamWorldFiles/mysql/data", "#")
        ProgressBar1.Value = 8
        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = "--defaults-file=" + gCurSlashDir + "/DreamworldFiles/mysql/my.ini"
        pi.WindowStyle = ProcessWindowStyle.Hidden
        pi.FileName = gCurDir & "\DreamWorldFiles\mysql\bin\mysqld-nt.exe"
        p.StartInfo = pi
        p.Start()

        ProgressBar1.Value = 20

        ' Check for MySql operation

        Dim Mysql = False
        ' wait for MySql to come up 
        Mysql = CheckMySQL()
        While Not Mysql
            ProgressBar1.Value = ProgressBar1.Value + 1
            Application.DoEvents()
            If ProgressBar1.Value = 50 Then
                MsgBox("Timeout running MySQL - cannot Continue", vbAbort)
                ZapAll()
                Buttons(StartButton)
                Return
            End If

            ' check again
            Sleep(1000)
            Mysql = CheckMySQL()

        End While

        ProgressBar1.Value = 50
        Print("Database Is Up")


        ' Set Public Port
        Dim client As New System.Net.WebClient
        Try
            My.Settings.PublicIP = client.DownloadString("https://api.ipify.org")
        Catch ex As Exception
            Print("Cannot reach the Internet. Aborting")
            ZapAll()
            Buttons(StartButton)
        End Try

        Try
            Dim Benchmark = client.DownloadString("http://" & My.Settings.PublicIP & ":8001/Init.txt")
        Catch ex As exception
            MsgBox("See Info on screen about opening up ports in your router", vbExclamation)
            Print("Hypergrid requires that Ports 8001 and 8002 be forwarded to this PC in your router. You can do this manually, or by checking that UPnP is supported and working on your router. ")
            My.Settings.PublicIP = "127.0.0.1" ' dang it, we cannot go to the hypergird
        End Try

        ProgressBar1.Value = 53
        SetIni(gCurDir & "\DreamWorldFiles\" & My.Settings.Grid & "\bin\Opensim.ini", "Const", "BaseURL", My.Settings.PublicIP, ";")
        ProgressBar1.Value = 54
        My.Settings.PublicPort = GetIni(gCurDir & "\DreamWorldFiles\" + My.Settings.Grid & "\bin\Opensim.ini", "Const", "PublicPort")
        ProgressBar1.Value = 55
        SetIni(gCurDir & "\DreamWorldFiles\" & My.Settings.Grid & "\bin\Regions\RegionConfig.ini", "DreamWorld", "InternalPort", My.Settings.PublicPort, ";")
        ProgressBar1.Value = 59
        SetIni(gCurDir & "\DreamWorldFiles\" & My.Settings.Grid & "\bin\Regions\RegionConfig.ini", "DreamWorld", "ExternalHostName", My.Settings.PublicIP, ";")
        ProgressBar1.Value = 60
        ' switch to Opensim folder
        ChDir(gCurDir & "\DreamWorldFiles\" & My.Settings.Grid & "\bin\")

        If mnuHide.Checked Then
            pi.Arguments = "-console rest -background True "
            pi.WindowStyle = ProcessWindowStyle.Hidden
        Else
            pi.Arguments = ""
            pi.WindowStyle = ProcessWindowStyle.Normal
        End If

        pi.FileName = gCurDir & "\DreamWorldFiles\" & My.Settings.Grid & "\bin\OpenSim.exe"
        p.StartInfo = pi
        p.Start()

        ' Wait for Opensim to start listening via wifi
        Dim Up = ""
        Try
            Up = client.DownloadString("http://127.0.0.1:8002/?r=" + Random())
        Catch ex As exception
            Up = ""
        End Try

        While Up.Length = 0
            Application.DoEvents()
            ProgressBar1.Value = ProgressBar1.Value + 1
            If ProgressBar1.Value = 90 Then
                Print("Opensim failed to start")
                ZapAll()
                Buttons(StartButton)
                Dim yesno = MsgBox("Opensim did not start. Do you want to see the log file?", vbYesNo)
                If (yesno = vbYes) Then
                    Dim Log As String = gCurDir + "\DreamWorldFiles\" & My.Settings.Grid & "\bin\OpenSim.log"
                    System.Diagnostics.Process.Start("wordpad.exe", Log)
                End If
                ZapAll()
                Buttons(StartButton)
                Return
            End If
            Application.DoEvents()
            Sleep(1000)

            Try
                Up = client.DownloadString("http://127.0.0.1:8002/?r=" + Random())
            Catch ex As exception
                Up = ""
            End Try

        End While

        ProgressBar1.Value = 90

        Print("Starting Onlook viewer")

        pi.Arguments = ""
        pi.FileName = "C:\Program Files (x86)\Onlook\OnLookViewer.exe"
        pi.WindowStyle = ProcessWindowStyle.Normal
        p.StartInfo = pi
        p.Start()

        ' Show the web console
        If mnuAdminShow.Checked Then
            Dim webAddress As String = "http://127.0.0.1:8002/?r=" + Random()
            Process.Start(webAddress)
        End If

        Buttons(StopButton)
        Print("Login as 'Dream World', password is '123'.  Your simulators HyperGrid address is " + My.Settings.PublicIP + ":" + My.Settings.PublicPort)
        ' done with bootup
        ProgressBar1.Value = 100

    End Sub

    Private Function CheckMySQL() As Boolean

        ' tried to probe MySQL  port 3307. If available, return true
        Dim ClientSocket As New TcpClient
        Dim ServerAddress As String = "127.0.0.1" ' Set the IP address of the server
        Dim PortNumber As Integer = 3307 ' Set the port number used by the server

        Try
            ClientSocket.Connect(ServerAddress, PortNumber)
        Catch ex As Exception
            Return False
        End Try
        CheckMySQL = True

    End Function

    Private Function zap(process As String) As Boolean

        Print("Stopping " + process)
        ' Kill process by name
        For Each P As Process In System.Diagnostics.Process.GetProcessesByName(process)
            Try
                P.Kill()
            Catch ex As exception
                ' nothing
            End Try
        Next
        Print("")
        zap = True

    End Function

    Private Sub Busy_Click(sender As System.Object, e As System.EventArgs)
        ' Busy click shuts us down
        Dim result As Integer = MessageBox.Show("Do you want to Abort?", "caption", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Print("Stopping")
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
        Buttons = True

    End Function

    Private Function ZapAll()

        ProgressBar1.Value = 100
        zap("OpenSim")
        ProgressBar1.Value = 66
        zap("mysqld-nt")
        ProgressBar1.Value = 0
        Application.DoEvents()
        Running = False
        ZapAll = True
    End Function

    Private Sub Create_ShortCut(ByVal sTargetPath As String)

        ' Requires reference to Windows Script Host Object Model
        Dim WshShell As WshShellClass = New WshShellClass
        Dim MyShortcut As IWshRuntimeLibrary.IWshShortcut

        ' The shortcut will be created on the desktop
        Dim DesktopFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
        MyShortcut = CType(WshShell.CreateShortcut(DesktopFolder & "\Dreamworld.lnk"), IWshRuntimeLibrary.IWshShortcut)
        MyShortcut.TargetPath = sTargetPath
        MyShortcut.IconLocation = WshShell.ExpandEnvironmentStrings(gCurDir & "\Start.exe, 0 ")
        MyShortcut.WorkingDirectory = gCurDir
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

    Private Sub StopButton_Click_1(sender As System.Object, e As System.EventArgs) Handles StopButton.Click

        Buttons(BusyButton)
        Print("Stopping")
        ZapAll()
        Buttons(StartButton)
        Print("Opensim is Stopped")

    End Sub

    Private Sub InstallButton_Click(sender As System.Object, e As System.EventArgs) Handles InstallButton.Click

        ProgressBar1.Visible = True
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = 100
        ProgressBar1.Value = 0

        Buttons(BusyButton)
        Print("Installing...")

        ProgressBar1.Value = 10

        Print("Installing Shortcut")
        Create_ShortCut(gCurDir & "\Start.exe")
        ProgressBar1.Value = 20

        Print("Installing Onlook Viewer")
        ProgressBar1.Value = 90
        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = ""
        pi.FileName = gCurDir & "\Viewer\Onlook.exe"
        p.StartInfo = pi
        p.Start()

        Print("Installing Grid Info...")


        My.Computer.FileSystem.CopyFile(gCurDir & "\Viewer\grids_sg_Hypergrid.xml", XMLpath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml", True)

        ' allow them to launch now
        Print("Ready to Launch. Click 'Start' to boot Opensimulator.")
        Buttons(StartButton)
        ProgressBar1.Value = 100

    End Sub

    Private Sub ShowToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles mnuShow.Click

        Print("The Opensimulator Console will be shown when the system is running.")
        mnuShow.Checked = True
        mnuHide.Checked = False
        My.Settings.Console = mnuShow.Checked
        My.Settings.Save()

        If Running Then
            Print("The Opensimulator Console will be shown the next time the system is started.")
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
        mnuEasy.Checked = True
        mnuFull.Checked = False
        My.Settings.Viewer = mnuEasy.Checked
        My.Settings.Save()
        SetIni(gCurDir & "\DreamWorldFiles\" & My.Settings.Grid & "\bin\Opensim.ini", "SpecialUIModule", "enabled", "true", ";")
        Print("Onlook Viewer is set for Easy UI mode. Change will occur when the sim is restarted", vbInformation)
    End Sub

    Private Sub mnuFull_Click(sender As System.Object, e As System.EventArgs) Handles mnuFull.Click

        mnuEasy.Checked = False
        mnuFull.Checked = True
        My.Settings.Viewer = mnuEasy.Checked
        My.Settings.Save()
        SetIni(gCurDir & "\DreamWorldFiles\" & My.Settings.Grid & "\bin\Opensim.ini", "SpecialUIModule", "enabled", "false", ";")
        Print("Onlook Viewer is set for the Full UI mode. Change will occur when the sim is restarted", vbInformation)

    End Sub

    Private Sub NoneToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles mnuNoAvatar.Click


        mnuNoAvatar.Checked = True
        mnuYesAvatar.Checked = False

        My.Settings.Avatar = False
        My.Settings.Save()

        SetIni(gCurDir & "\DreamWorldFiles\" & My.Settings.Grid & "\bin\Opensim.ini", "CameraOnlyModeModule", "enabled", "true", ";")
        Print("Your Avatar will not be shown when you log in. Change will occur when the Viewer is next logged in.", vbInformation)

    End Sub

    Private Sub VisibleToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles mnuYesAvatar.Click

        Print("Your Avatar will be shown when you log in. Use the Arrow keys to move around. Use Page Up and Page Down to move the camera Up and Down.  Change will occur when the Viewer is next logged in")
        mnuYesAvatar.Checked = True
        mnuNoAvatar.Checked = False

        My.Settings.Avatar = True
        My.Settings.Save()

        SetIni(gCurDir & "\DreamWorldFiles\" & My.Settings.Grid & "\bin\Opensim.ini", "CameraOnlyModeModule", "enabled", "false", ";")

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
        Random = Str(value)

    End Function

    Private Sub WebUIToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WebUi.Click

        Print("The Web UI lets you add or view settings for the default avatar. ")
        If Running Then
            Dim webAddress As String = "http://127.0.0.1:8002"
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

        Dim Data = parser.ReadFile(filepath)
        Dim value = Data(section)(key)
        GetIni = value

    End Function

    Private Sub SetIni(filepath As String, section As String, key As String, value As String, delim As String)

        ' sets values into any INI file
        Dim parser = New FileIniDataParser()
        parser.Parser.Configuration.CommentString = delim ' Opensim uses semicolons
        parser.Parser.Configuration.SkipInvalidLines = True
        Dim Data = parser.ReadFile(filepath)
        Try
            Dim oldvalue = Data(section)(key)
            Data(section)(key) = value ' replace it and save it
            parser.WriteFile(filepath, Data)
        Catch ex As Exception
            MsgBox("Cannot locate '" + key + "' in section '" + section + "' in file " + filepath + ". This is not good", vbOK)
        End Try
    End Sub
    Private Sub CleanAll() As Boolean
        Clean("HyperGrid")
        Clean("OsGrid")
    End Sub
    Private Sub Clean(AGrid As String)

        Try
            System.IO.Directory.Delete(gCurDir & "\DreamWorldFiles\" & AGrid & "\bin\addin-db-002", True)
        Catch ex As Exception
        End Try
        Try
            System.IO.Directory.Delete(gCurDir & "\DreamWorldFiles\" & AGrid & "\bin\assetcache", True)
        Catch ex As Exception
        End Try
        Try
            System.IO.Directory.Delete(gCurDir & "\DreamWorldFiles\" & AGrid & "\bin\DataSnapshot", True)
        Catch ex As Exception
        End Try
        Try
            System.IO.Directory.Delete(gCurDir & "\DreamWorldFiles\" & AGrid & "\bin\ScriptEngines", True)
        Catch ex As Exception
        End Try
        Try
            System.IO.Directory.Delete(gCurDir & "\DreamWorldFiles\" & AGrid & "\bin\MapTiles", True)
        Catch ex As Exception
        End Try
        Try
            My.Computer.FileSystem.DeleteFile(gCurDir + "\DreamWorldFiles" & AGrid & "\bin\Opensim.log")
        Catch ex As Exception
        End Try
        Try
            My.Computer.FileSystem.DeleteFile(gCurDir + "\DreamWorldFiles\" & AGrid & "\bin\OpenSimConsoleHistory.txt")
        Catch ex As Exception
        End Try
        Try
            My.Computer.FileSystem.DeleteFile(gCurDir + "\DreamWorldFiles\Init.txt")
        Catch ex As Exception
        End Try

        MsgBox("System Is Clean")
        End
    End Sub

    Private Sub mnuOsGrid_Click(sender As Object, e As EventArgs) Handles mnuOsGrid.Click
        My.Settings.Grid = "OsGrid"
        My.Settings.Grid = My.Settings.Grid
        My.Settings.Save()
        mnuOsGrid.Checked = True
        mnuHyperGrid.Checked = False
        SetGridValues()
        Print("DreamWorlds will connect to OsGrid.org. You must log in with an Avatar name registered with OsGrid.org. You must also 'Port Forward' your router to this machine on port 8000 for Tcp and Udp traffic")
        My.Computer.FileSystem.CopyFile(gCurDir & "\Viewer\grids_sg_OsGrid.xml", xmlPath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml", True)

    End Sub

    Private Sub mnuHyperGrid_Click(sender As Object, e As EventArgs) Handles mnuHyperGrid.Click
        My.Settings.Grid = "HyperGrid"
        My.Settings.Grid = My.Settings.Grid
        My.Settings.Save()
        mnuOsGrid.Checked = False
        mnuHyperGrid.Checked = True
        SetGridValues()
        Print("DreamWorlds will connect as a locally hosted hypergridded sim.")
        My.Computer.FileSystem.CopyFile(gCurDir & "\Viewer\grids_sg_HyperGrid.xml", xmlPath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml", True)
    End Sub

    Private Sub SetGridValues()

        'mnuShow shows the DOS box for Opensimulator
        mnuShow.Checked = My.Settings.Console
        mnuHide.Checked = Not My.Settings.Console

        ' Admin shows the Web UI
        mnuAdminShow.Checked = My.Settings.Admin
        mnuAdminHide.Checked = Not My.Settings.Admin

        ' Viewer UI shows the full viewer UI
        If My.Settings.Viewer Then
            SetIni(gCurDir & "\DreamWorldFiles\" & My.Settings.Grid & "\bin\Opensim.ini", "SpecialUIModule", "enabled", "false", ";")
        Else
            SetIni(gCurDir & "\DreamWorldFiles\" & My.Settings.Grid & "\bin\Opensim.ini", "SpecialUIModule", "enabled", "true", ";")
        End If
        mnuFull.Checked = My.Settings.Viewer
        mnuEasy.Checked = Not My.Settings.Viewer

        'Avatar visible?
        If My.Settings.Avatar Then
            SetIni(gCurDir & "\DreamWorldFiles\" & My.Settings.Grid & "\bin\Opensim.ini", "CameraOnlyModeModule", "enabled", "false", ";")
        Else
            SetIni(gCurDir & "\DreamWorldFiles\" & My.Settings.Grid & "\bin\Opensim.ini", "CameraOnlyModeModule", "enabled", "true", ";")
        End If
        mnuYesAvatar.Checked = My.Settings.Avatar
        mnuNoAvatar.Checked = Not My.Settings.Avatar

        ' Grid
        If My.Settings.Grid = "HyperGrid" Then
            mnuHyperGrid.Checked = True
            mnuOsGrid.Checked = False
        End If

        If My.Settings.Grid = "OsGrid" Then
            mnuHyperGrid.Checked = False
            mnuOsGrid.Checked = True
        End If

        ' Autobackup
        If My.Settings.AutoBackup Then
            SetIni(gCurDir & "\DreamWorldFiles\" & My.Settings.Grid & "\bin\Opensim.ini", "AutoBackupModule", "AutoBackup", "true", ";")
            AutoYes.Checked = True
            AutoNo.Checked = False
            My.Settings.AutoBackup = True
        Else
            SetIni(gCurDir & "\DreamWorldFiles\" & My.Settings.Grid & "\bin\Opensim.ini", "AutoBackupModule", "AutoBackup", "false", ";")
            AutoYes.Checked = False
            AutoNo.Checked = True
            My.Settings.AutoBackup = False
        End If

    End Sub

    Private Sub YesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoYes.Click
        Print("DreamWorlds is set Autoback the sim into an OAR every 24 hours. Oars are saved in the AutoBackup folder")
        AutoYes.Checked = True
        AutoNo.Checked = False
        SetIni(gCurDir & "\DreamWorldFiles\" & My.Settings.Grid & "\bin\Opensim.ini", "AutoBackupModule", "AutoBackup", "true", ";")
        My.Settings.AutoBackup = True
        My.Settings.Save()
    End Sub

    Private Sub AutoNo_Click(sender As Object, e As EventArgs) Handles AutoNo.Click
        Print("Backups disabled")
        AutoYes.Checked = False
        AutoNo.Checked = True
        SetIni(gCurDir & "\DreamWorldFiles\" & My.Settings.Grid & "\bin\Opensim.ini", "AutoBackupModule", "AutoBackup", "false", ";")
        My.Settings.AutoBackup = False
        My.Settings.Save()
    End Sub

    Function AllowFirewall() As Boolean
        Dim MyUPnPMap As New UPnP
        Dim portcount = 0
        If MyUPnPMap.Exists(My.Settings.PublicPort, UPnP.Protocol.UDP) Then
            portcount = portcount + 1
        Else
            MyUPnPMap.Add(UPnP.LocalIP, My.Settings.PublicPort, UPnP.Protocol.UDP, "Opensim UDP")
            portcount = portcount + 1
        End If

        If MyUPnPMap.Exists(My.Settings.PublicPort, UPnP.Protocol.TCP) Then
            portcount = portcount + 1
        Else
            MyUPnPMap.Add(UPnP.LocalIP, My.Settings.PublicPort, UPnP.Protocol.TCP, "Opensim TCP")
            portcount = portcount + 1
        End If

        If MyUPnPMap.Exists(8001, UPnP.Protocol.TCP) Then
            portcount = portcount + 1
        Else
            MyUPnPMap.Add(UPnP.LocalIP, 8001, UPnP.Protocol.TCP, "Opensim Probe")
            portcount = portcount + 1
        End If


        If (portcount = 3) Then
            Return True 'successfully added
        End If

        Return False

    End Function

    Private Function OpenPorts()

        Try
            If AllowFirewall() Then ' open uPNP port
                Print("Firewall Open")
                Return True
            Else
                Print("Firewall Closed")
                Return False
            End If
        Catch e As Exception
            Print("Router is blocking a port so hypergrid may not be available")
            Return False
        End Try
    End Function

    Private Sub BusyButton_Click(sender As Object, e As EventArgs) Handles BusyButton.Click
        Print("Stopping")
        Application.DoEvents()
        ZapAll()
        Buttons(StartButton)
        Print("Opensim is Stopped")

    End Sub

    Private Function xmlPath() As String
        ' gets the path to the %APPDATA% folder on windows so we can seek out the Onlook folders
        Dim appData As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData
        Return Mid(appData, 1, InStr(appData, "AppData") - 1)

    End Function

    Public Property Running() As Boolean
        Get
            Return isRunning
        End Get
        Set(ByVal Value As Boolean)
            isRunning = Value
        End Set
    End Property
End Class