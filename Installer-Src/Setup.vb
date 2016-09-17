Imports System.IO
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

    Dim gCurDir    ' Holds the current folder that we are running in
    Dim gCounter As Integer  ' global retry counter
    Dim gRunning As Boolean ' global running flag

    Private Declare Sub Sleep Lib "kernel32.dll" (ByVal Milliseconds As Integer)
    Dim gXMLpath As String

    Private Sub Form1_Leave(sender As Object, e As System.EventArgs) Handles Me.Leave

        ' Needed to stop Opensim
        ZapAll()
        End

    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        gRunning = False ' global flag is true when opensim is running
        gCurDir = My.Application.Info.DirectoryPath

        ' I would like to buy an argument
        Dim arguments As String() = Environment.GetCommandLineArgs()

        If arguments.Length > 1 Then
            ' for debugging when compiling
            If arguments(1) = "clean" Then
                ' Clean up the file system
                CleanAll()
            ElseIf arguments(1) = "debug" Then
                gCurDir = "\DreamWorld" ' for testing, as the compiler buries itself in ../../../debug
            End If
        End If

        ' Set the INI files for the selected grid
        SetGridValues()

        ' Find out if the viewer is installed 
        If System.IO.File.Exists(gCurDir & "\DreamworldFiles\Init") Then
            Buttons(StartButton)
            TextBox1.Text = "Opensimulator Is ready To start In " & My.Settings.Grid & " Mode"
        Else
            Dim fs As FileStream = System.IO.File.Create(gCurDir & "\DreamworldFiles\Init")
            Buttons(InstallButton)
        End If
        Application.DoEvents()

    End Sub
    Private Sub StartButton_Click(sender As System.Object, e As System.EventArgs) Handles StartButton.Click

        ' Start Mowes, which starts MySql and Apache automatically.
        Print("DreamWorlds Is starting the web server And database engines.")

        Buttons(BusyButton)
        gRunning = True

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

        Print("Starting Database And Web Server")
        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = ""

        If mnuHide.Checked Then
            pi.WindowStyle = ProcessWindowStyle.Hidden
        End If
        pi.FileName = gCurDir & "\DreamWorldFiles\Mowes.exe"
        p.StartInfo = pi
        p.Start()


        ' Check for MySql operation
        gCounter = 30
        Dim Mysql = False
        ' wait for MySql to come up 
        While Not Mysql
            gCounter = gCounter - 1
            Application.DoEvents()
            If gCounter = 0 Then
                MsgBox("Timeout running MySQL - cannot continue", vbAbort)
                ZapAll()
                Buttons(StartButton)
                Return
            End If
            Print("Starting MySql Database: " + Str(gCounter))
            Mysql = CheckMySQL()
            Sleep(1000)
        End While

        Print("Database Is Up")
        gCounter = 60 ' retry counter reset - lets give them a minute to get on
        ' Apache should be on port 62535
        Dim client As New System.Net.WebClient
        Dim Webpage = ""
        Try
            Webpage = client.DownloadString("http://127.0.0.1:62535/start/up.htm?id=" + Random())
        Catch
        End Try

        While Webpage <> "Up"
            Sleep(1000)
            Application.DoEvents()
            gCounter = gCounter - 1
            If gCounter = 0 Then
                Print("Apache web server failed to load")
                ZapAll()
                Buttons(StartButton)
                Return
            End If
            Print("Starting Apache Web Server: " + Str(gCounter))
            Try
                Webpage = client.DownloadString("http://127.0.0.1:62535/start/up.htm?id=" + Random())
            Catch
            End Try
        End While

        ' Set Public Port
        My.Settings.PublicIP = client.DownloadString("https://api.ipify.org")
        My.Settings.PublicPort = GetIni(My.Settings.Grid & "\bin\Opensim.ini", "Const", "PublicPort")
        Print("HyperGrid Address is " + My.Settings.PublicIP + ":" + My.Settings.PublicPort)

        SetIni(My.Settings.Grid & "\bin\Regions\RegionConfig.ini", "DreamWorld", "InternalPort", My.Settings.PublicPort)
        SetIni(My.Settings.Grid & "\bin\Regions\RegionConfig.ini", "DreamWorld", "ExternalHostName", My.Settings.PublicIP)


        ChDir(gCurDir & "\DreamWorldFiles\" & My.Settings.Grid & "\bin\")

        If mnuHide.Checked Then
            pi.Arguments = "-console rest -background True "
            pi.WindowStyle = ProcessWindowStyle.Hidden
        End If

        pi.FileName = gCurDir & "\DreamWorldFiles\" & My.Settings.Grid & "\bin\OpenSim.exe"
        p.StartInfo = pi
        p.Start()

        ' Wait for Opensim to start listening via wifi
        gCounter = 30 ' retry counter - lets give them a minute to get on
        Dim Up = ""
        Try
            Up = client.DownloadString("http: //127.0.0.1:9000/wifi/up.html?r=" + Random())
        Catch
        End Try

        While Up <> "Up"
            Application.DoEvents()
            gCounter = gCounter - 1
            If gCounter = 0 Then
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
            Print("Starting simulator: " + Str(gCounter))
            Try
                Up = client.DownloadString("http://127.0.0.1:9000/wifi/up.html?r=" + Random())
            Catch
            End Try

        End While

        Print("Starting Onlook viewer")

        pi.Arguments = ""
        pi.FileName = "C:\Program Files (x86)\Onlook\OnLookViewer.exe"
        pi.WindowStyle = ProcessWindowStyle.Normal
        p.StartInfo = pi
        p.Start()

        ' Show the web console
        If mnuAdminShow.Checked Then
            Dim webAddress As String = "http://127.0.0.1:9000/wifi"
            Process.Start(webAddress)
        End If

        Buttons(StopButton)
        Print("Login as 'Simona Stick', password is '123'")
        ' done with bootup

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
        gRunning = False
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

        Print("Opensim is Stopped. ")

        Buttons(BusyButton)
        Print("Stopping")
        ZapAll()
        Buttons(StartButton)
        Print("")

    End Sub

    Private Sub InstallButton_Click(sender As System.Object, e As System.EventArgs) Handles InstallButton.Click

        Buttons(BusyButton)
        Print("Installing...")

        OpenPorts() ' Open router ports

        Print("Installing Shortcut")
        Create_ShortCut(gCurDir & "\Start.exe")
        Print("Installing Onlook Viewer")

        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = ""
        pi.FileName = gCurDir & "\Viewer\Onlook.exe"
        p.StartInfo = pi
        p.Start()

        Print("Installing Grid Info...")

        Dim appData As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData

        gXMLpath = Mid(appData, 1, InStr(appData, "AppData") - 1)

        My.Computer.FileSystem.CopyFile(gCurDir & "\Viewer\grids_sg1.xml", gXMLpath + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml", True)

        ' allow them to launch now
        Print("Ready to Launch. Click 'Start' to boot Opensimulator.")
        Buttons(StartButton)

    End Sub

    Private Sub ShowToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles mnuShow.Click

        Print("The Opensimulator Console will be shown when the system is running.")
        mnuShow.Checked = True
        mnuHide.Checked = False
        My.Settings.Console = mnuShow.Checked
        My.Settings.Save()

        If gRunning Then
            Print("The Opensimulator Console will be shown the next time the system is started.")
        End If

    End Sub

    Private Sub mnuHide_Click(sender As System.Object, e As System.EventArgs) Handles mnuHide.Click

        Print("The Opensimulator Console will not be shown. You can still interact with it with Opensimulator->View UI")
        mnuShow.Checked = False
        mnuHide.Checked = True
        My.Settings.Save()

        If gRunning Then
            Print("The Opensimulator Console will not be shown. Change will occur when the system is restarted")
        End If

    End Sub

    Private Sub mnuEasy_Click_1(sender As System.Object, e As System.EventArgs) Handles mnuEasy.Click

        Print("Onlook Viewer is set for Easy UI mode.")
        mnuEasy.Checked = True
        mnuFull.Checked = False
        My.Settings.Viewer = mnuEasy.Checked
        My.Settings.Save()

        SetIni(My.Settings.Grid & "\bin\Opensim.ini", "SpecialUIModule", "enabled", "true")

        If gRunning Then
            MsgBox("Onlook Viewer is set for Easy UI mode. Change will occur when the sim is restarted", vbInformation)
        End If

    End Sub

    Private Sub mnuFull_Click(sender As System.Object, e As System.EventArgs) Handles mnuFull.Click

        Print("Onlook Viewer is set for the Full UI mode.")
        mnuEasy.Checked = False
        mnuFull.Checked = True
        My.Settings.Viewer = mnuEasy.Checked
        My.Settings.Save()

        SetIni(My.Settings.Grid & "\bin\Opensim.ini", "SpecialUIModule", "enabled", "false")

        If gRunning Then
            MsgBox("Onlook Viewer is set for the Full UI mode. Change will occur when the sim is restarted", vbInformation)
        End If

    End Sub

    Private Sub NoneToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles mnuNoAvatar.Click

        Print("Your Avatar will not be shown. Use the Arrow keys to move around. Use Page Up and Page Down to move the camera Up and Down.")

        mnuNoAvatar.Checked = True
        mnuYesAvatar.Checked = False

        My.Settings.Avatar = False
        My.Settings.Save()

        SetIni(My.Settings.Grid & "\bin\Opensim.ini", "CameraOnlyModeModule", "enabled", "true")

        If gRunning Then
            MsgBox("Your Avatar will not be shown when you log in. Change will occur when the Viewer is next logged in.", vbInformation)
        End If

    End Sub

    Private Sub VisibleToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles mnuYesAvatar.Click

        Print("Your Avatar will be shown when you log in. Use the Arrow keys to move around. Use Page Up and Page Down to move the camera Up and Down.  Change will occur when the Viewer is next logged in")
        mnuYesAvatar.Checked = True
        mnuNoAvatar.Checked = False

        My.Settings.Avatar = True
        My.Settings.Save()

        SetIni(My.Settings.Grid & "\bin\Opensim.ini", "CameraOnlyModeModule", "enabled", "false")

        If gRunning Then
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
        If gRunning Then
            Dim webAddress As String = "http://127.0.0.1:9000/wifi"
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

        Dim Data = parser.ReadFile(gCurDir + "\DreamWorldFiles\" & filepath)
        Dim value = Data(section)(key)
        Return value

    End Function

    Private Function SetIni(filepath As String, section As String, key As String, value As String) As Boolean

        ' sets values into any INI file
        Dim parser = New FileIniDataParser()
        parser.Parser.Configuration.CommentString = ";" ' Opensim uses semicolons
        parser.Parser.Configuration.SkipInvalidLines = True

        Dim Data = parser.ReadFile(gCurDir + "\DreamWorldFiles\" & filepath)

        Try
            Dim oldvalue = Data(section)(key)
            Data(section)(key) = value ' replace it and save it
            parser.WriteFile(gCurDir + "\DreamWorldFiles\" & filepath, Data)
        Catch
            MsgBox("Cannot locate '" + key + "' in section '" + section + "' in file " + filepath, vbOK)
        End Try

        Return True

    End Function
    Private Function CleanAll()
        Clean("HyperGrid")
        Clean("OsGrid")
        Return True
    End Function
    Private Function Clean(AGrid As String)

        Try
            System.IO.Directory.Delete(gCurDir & "\DreamWorldFiles\" & AGrid & "\bin\addin-db-002", True)
        Catch
        End Try
        Try
            System.IO.Directory.Delete(gCurDir & "\DreamWorldFiles\" & AGrid & "\bin\assetcache", True)
        Catch
        End Try
        Try
            System.IO.Directory.Delete(gCurDir & "\DreamWorldFiles\" & AGrid & "\bin\DataSnapshot", True)
        Catch
        End Try
        Try
            System.IO.Directory.Delete(gCurDir & "\DreamWorldFiles\" & AGrid & "\bin\ScriptEngines", True)
        Catch
        End Try
        Try
            System.IO.Directory.Delete(gCurDir & "\DreamWorldFiles\" & AGrid & "\bin\MapTiles", True)
        Catch
        End Try

        Try
            My.Computer.FileSystem.DeleteFile(gCurDir + "\DreamWorldFiles" & AGrid & "\bin\Opensim.log")
        Catch ex As Exception
            ' do nothing
        End Try
        Try
            My.Computer.FileSystem.DeleteFile(gCurDir + "\DreamWorldFiles\" & AGrid & "\bin\OpenSimConsoleHistory.txt")
        Catch ex As Exception
        End Try
        Try
            My.Computer.FileSystem.DeleteFile(gCurDir + "\DreamWorldFiles\Init")
        Catch ex As Exception
        End Try

        MsgBox("System Is Clean")
        End
    End Function

    Private Sub mnuOsGrid_Click(sender As Object, e As EventArgs) Handles mnuOsGrid.Click
        My.Settings.Grid = "OsGrid"
        My.Settings.Grid = My.Settings.Grid
        My.Settings.Save()
        mnuOsGrid.Checked = True
        mnuHyperGrid.Checked = False
        SetGridValues()
        Print("DreamWorlds will connect to OsGrid.org. You must log in with an Avatar name registered with OsGrid.org. You must also 'Port Forward' your router to this machine on port 8000 for Tcp and Udp traffic")
            My.Computer.FileSystem.CopyFile(gCurDir & "\Viewer\grids_sg_OsGrid.xml", gXMLpath + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml", True)

    End Sub

    Private Sub mnuHyperGrid_Click(sender As Object, e As EventArgs) Handles mnuHyperGrid.Click
        My.Settings.Grid = "HyperGrid"
        My.Settings.Grid = My.Settings.Grid
        My.Settings.Save()
        mnuOsGrid.Checked = False
        mnuHyperGrid.Checked = True
        SetGridValues()
        Print("DreamWorlds will connect to your own locally hosted hypergridded sim. You must log in with the name 'Simon Stick' with a password of 123'")
        My.Computer.FileSystem.CopyFile(gCurDir & "\Viewer\grids_sg_HyperGrid.xml", gXMLpath + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml", True)

    End Sub

    Private Function SetGridValues()

        'mnuShow shows the DOS box for Opensimulator
        mnuShow.Checked = My.Settings.Console
        mnuHide.Checked = Not My.Settings.Console

        ' Admin shows the Web UI
        mnuAdminShow.Checked = My.Settings.Admin
        mnuAdminHide.Checked = Not My.Settings.Admin

        ' Viewer UI shows the full viewer UI
        If My.Settings.Viewer Then
            SetIni(My.Settings.Grid & "\bin\Opensim.ini", "SpecialUIModule", "enabled", "false")
        Else
            SetIni(My.Settings.Grid & "\bin\Opensim.ini", "SpecialUIModule", "enabled", "true")
        End If
        mnuFull.Checked = My.Settings.Viewer
        mnuEasy.Checked = Not My.Settings.Viewer

        'Avatar visible?
        If My.Settings.Avatar Then
            SetIni(My.Settings.Grid & "\bin\Opensim.ini", "CameraOnlyModeModule", "enabled", "false")
        Else
            SetIni(My.Settings.Grid & "\bin\Opensim.ini", "CameraOnlyModeModule", "enabled", "true")
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
            SetIni(My.Settings.Grid & "\bin\Opensim.ini", "AutoBackupModule", "AutoBackup", "true")
            AutoYes.Checked = True
            AutoNo.Checked = False
            My.Settings.AutoBackup = True
        Else
            SetIni(My.Settings.Grid & "\bin\Opensim.ini", "AutoBackupModule", "AutoBackup", "false")
            AutoYes.Checked = False
            AutoNo.Checked = True
            My.Settings.AutoBackup = False
        End If

       
        Return True
    End Function

    Private Sub YesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoYes.Click
        Print("DreamWorlds is set Autoback the sim into an OAR every 24 hours. Oars are saved in the AutoBackup folder")
        AutoYes.Checked = True
        AutoNo.Checked = False
        SetIni(My.Settings.Grid & "\bin\Opensim.ini", "AutoBackupModule", "AutoBackup", "true")
        My.Settings.AutoBackup = True
        My.Settings.Save()
    End Sub

    Private Sub AutoNo_Click(sender As Object, e As EventArgs) Handles AutoNo.Click
        Print("Backups disabled")
        AutoYes.Checked = False
        AutoNo.Checked = True
        SetIni(My.Settings.Grid & "\bin\Opensim.ini", "AutoBackupModule", "AutoBackup", "false")
        My.Settings.AutoBackup = False
        My.Settings.Save()
    End Sub

    Function AllowFirewall() As Boolean
        Dim MyUPnPMap As New UPnP
        Dim portcount = 0
        If MyUPnPMap.Exists(My.Settings.PublicPort, UPnP.Protocol.UDP) Then
            portcount = portcount + 1
        Else
            MyUPnPMap.Add(UPnP.LocalIP, My.Settings.PublicPort, UPnP.Protocol.UDP, "Opensim")
            portcount = portcount + 1
        End If

        If MyUPnPMap.Exists(My.Settings.PublicPort, UPnP.Protocol.TCP) Then
            portcount = portcount + 1
        Else
            MyUPnPMap.Add(UPnP.LocalIP, My.Settings.PublicPort, UPnP.Protocol.TCP, "Opensim")
            portcount = portcount + 1
        End If

        If (portcount = 2) Then
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
        Catch
            Print("Router is blocking port " + My.Settings.PublicPort + " so hypergrid may not be available")
            Return False
        End Try
    End Function

End Class
