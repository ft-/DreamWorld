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
    Dim ContentLoading As Boolean
    Dim client As New System.Net.WebClient
    Dim Adv As New Advanced ' Bring the form into memory 
    Dim pMySql As Process = New Process()
    Dim pOpensim As Process = New Process()
    Dim pOnlook As Process = New Process()

    Private Sub Form1_Leave(sender As Object, e As System.EventArgs) Handles Me.Leave
        Log("Info:Exit")
        ExitAll()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Buttons(BusyButton)
        ProgressBar1.Visible = False

        Me.Show()

        Me.AllowDrop = True
        TextBox1.AllowDrop = True

        Running = False ' true when opensim is running

        MyFolder = My.Application.Info.DirectoryPath

        gCurSlashDir = MyFolder.Replace("\", "/")    ' becuase Mysql uses unix like slashes, that's why

        ' I would like to buy an argument
        Dim arguments As String() = Environment.GetCommandLineArgs()

        If arguments.Length > 1 Then
            ' for debugging when compiling
            If arguments(1) = "clean" Then
                ' Clean up the file system
                CleanAll()
            ElseIf arguments(1) = "debug" Then
                MyFolder = "\DreamWorld" ' for testing, as the compiler buries itself in ../../../debug
                Log("Info:Using Debug folder \Dreamworld")
                gCurSlashDir = "/DreamWorld"
            End If
        End If
        ZapAll()

        Try
            My.Settings.PublicIP = client.DownloadString("https://api.ipify.org?a=b" + Random())
        Catch ex As Exception
            My.Settings.PublicIP = "127.0.0.1"
        End Try

        Log("Info:Public Ip is " + My.Settings.PublicIP)

        SetINIFromSettings()

        InstallGridXML()

        ' Find out if the viewer is installed, make a file we can benchmark to
        If System.IO.File.Exists(gCurDir & "\DreamworldFiles\Init.txt") Then
            Buttons(StartButton)
            Print("Opensimulator is ready to start.")
            Log("Info:Ready to start")

        Else
            Buttons(InstallButton)

            OpenPorts() ' Open router ports

            SetINIFromSettings()

            ProgressBar1.Visible = True
            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = 100
            ProgressBar1.Value = 0

            Buttons(BusyButton)
            Print("Installing...")

            ProgressBar1.Value = 0
            Me.Show()

            Print("Installing Desktop Shortcut")
            Create_ShortCut(gCurDir & "\Start.exe")
            ProgressBar1.Value = 10

            Print("Installing Onlook Viewer")

            Dim pi As ProcessStartInfo = New ProcessStartInfo()
            pi.Arguments = ""
            pi.FileName = gCurDir & "\Viewer\Onlook.exe"
            pOnlook.StartInfo = pi
            Try
                Log("Info:Launching Onlook installer")
                pOnlook.Start()
            Catch
                Log("Error:Onlook installer failed to load")
            End Try

            ProgressBar1.Value = 11
            Print("Please Install and Start the Onlook Viewer")
            Dim toggle As Boolean = False
            While Not System.IO.File.Exists(xmlPath() + "\AppData\Roaming\Onlook\user_settings\settings_onlook.xml")
                Application.DoEvents()
                Sleep(1000)
                If (toggle) Then
                    Print("Attention needed - please Install and Start the Onlook Viewer ")
                    toggle = False
                Else
                    Print("Start the Onlook Viewer")
                    toggle = False
                    toggle = True
                End If

                ProgressBar1.Value = ProgressBar1.Value + 1
                If ProgressBar1.Value = 100 Then
                    ProgressBar1.Value = 0
                    Print("Cannot continue until you start the Onlook viewer")
                    Sleep(5000)
                End If
            End While

            Log("Info:Ready to Launch")
            Print("Ready to Launch! Click 'Start' to begin your adventure in Opensimulator.")
            Buttons(StartButton)
            ProgressBar1.Value = 100

            ' mark the system as ready
            Using outputFile As New StreamWriter(gCurDir & "\DreamworldFiles\Init.txt", True)
                outputFile.WriteLine("This file lets Dreamworld know it has been installed and to benchmark the network loopback")
            End Using

        End If

    End Sub
    Private Sub StartButton_Click(sender As System.Object, e As System.EventArgs) Handles StartButton.Click

        Try
            My.Computer.FileSystem.DeleteFile(gCurDir & "\DreamWorldFiles\DreamWorld.log")
        Catch
            Log("Warn:Could not find the DreamWorld Log file")
        End Try



        ' Set up the progres bar for 0-100
        ProgressBar1.Visible = True
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = 100
        ProgressBar1.Value = 0

        Buttons(BusyButton)
        Running = True

        zap("OnlookViewer")

        OpenPorts() ' Open router ports

        Log("Info:Starting webserver")
        ws = WebServer.getWebServer
        ws.VirtualRoot = gCurDir & "\DreamWorldFiles\"
        ws.StartWebServer()

        Dim isPortOpen As String = ""
        Try
            isPortOpen = client.DownloadString("http://www.outworldz.com/cgi/probe.plx?Port=8001")
        Catch ex As Exception
            Log("Dang:The Outworld web site is down")
        End Try

        If isPortOpen <> "yes" Then
            Log("Warn:Port " + My.Settings.PublicPort + " is not open")
            Print("Port " + My.Settings.PublicPort + " is not open, so Hypergrid is not available.  Opensimulator will continue in standalone mode.")
        Else
            Log("Info:Hypergird port " + My.Settings.PublicPort + "is open")
            Print("Hypergrid Ports are open")
        End If

        LogFiles(5) ' clear log fles
        StartMySql(15) ' boot up MySql, and wait for it to start listening

        GetPubIP(20)    ' we need this if we are HG enabled
        Loopback(30)    ' test he loopback on the router. If it fails, use localhost, no Hg

        Log("Info:Stop Web Server")
        ws.StopWebServer()

        SetINIFromSettings()    ' set up the INI files
        ContentLoading = True ' set this flag so we do not save the oar automatically.

        Start_Opensimulator(98) ' Launch the rocket

        Onlook(100)

        Buttons(StopButton)
        If My.Settings.PublicIP = "127.0.0.1" Then
            Log("Info:PublicIP = 127.0.0.1")
            Print("Access to the Hypergrid is disabled because of your router. See Help->Loopback to see why.")
        Else
            Log("Info:Ready for login")
            Print("DreamWorld is ready for you to log in.  The Hypergrid address is " + My.Settings.PublicIP + ":" + My.Settings.PublicPort)
        End If

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
            Log("Error:MySql port probe failed on port 3307")
            Return False
        End Try
        Log("Info:MySql is Up")
        CheckMySQL = True

    End Function

    Private Function zap(processName As String) As Boolean

        ' Kill process by name
        For Each P As Process In System.Diagnostics.Process.GetProcessesByName(processName)
            Try
                Log("Info:Stopping process " + processName)
                P.Kill()
            Catch ex As Exception
                Log("Info:failed to stop " + processName)
            End Try
        Next
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
        Buttons = True
    End Function

    Private Sub Create_ShortCut(ByVal sTargetPath As String)

        ' Requires reference to Windows Script Host Object Model
        Dim WshShell As WshShellClass = New WshShellClass
        Dim MyShortcut As IWshRuntimeLibrary.IWshShortcut
        Log("Info:creating shortcut on desktop")
        ' The shortcut will be created on the desktop
        Dim DesktopFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
        MyShortcut = CType(WshShell.CreateShortcut(DesktopFolder & "\Dreamworld.lnk"), IWshRuntimeLibrary.IWshShortcut)
        MyShortcut.TargetPath = sTargetPath
        MyShortcut.IconLocation = WshShell.ExpandEnvironmentStrings(gCurDir & "\Start.exe, 0 ")
        MyShortcut.WorkingDirectory = gCurDir
        MyShortcut.Save()

    End Sub

    Private Sub Print(Value As String)
        Log("Info:" + Value)
        TextBox1.Text = Value
        Application.DoEvents()
        Sleep(1000)  ' time to read
    End Sub

    Private Sub mnuExit_Click(sender As System.Object, e As System.EventArgs) Handles mnuExit.Click
        Log("Info:Exiting")
        ExitAll()
    End Sub

    Private Sub mnuLogin_Click(sender As System.Object, e As System.EventArgs) Handles mnuLogin.Click
        Print("UserID 'Dream World' has a password of '123'. You can also use Help->Opensim Console to create a new avatar.")
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

    Private Sub ShowToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles mnuShow.Click
        Print("The Opensimulator Console will be shown when Opensim is running.")
        mnuShow.Checked = True
        mnuHide.Checked = False
        My.Settings.ConsoleShow = mnuShow.Checked
        My.Settings.Save()
        If Running Then
            Print("The Opensimulator Console will be shown the next time the system is started.")
        End If
    End Sub

    Private Sub mnuHide_Click(sender As System.Object, e As System.EventArgs) Handles mnuHide.Click
        Print("The Opensimulator Console will not be shown. You can still interact with it with Help->Opensim Console")
        mnuShow.Checked = False
        mnuHide.Checked = True
        My.Settings.ConsoleShow = mnuShow.Checked
        My.Settings.Save()
        If Running Then
            Print("The Opensimulator Console will not be shown. Change will occur when Opensim is restarted")
        End If
    End Sub

    Private Sub mnuEasy_Click_1(sender As System.Object, e As System.EventArgs) Handles mnuEasy.Click
        mnuEasy.Checked = True
        mnuFull.Checked = False
        My.Settings.ViewerEase = mnuEasy.Checked
        My.Settings.Save()
        Print("Onlook Viewer is set for Easy UI mode. Change will occur when the sim is restarted")
    End Sub

    Private Sub mnuFull_Click(sender As System.Object, e As System.EventArgs) Handles mnuFull.Click
        mnuEasy.Checked = False
        mnuFull.Checked = True
        My.Settings.ViewerEase = mnuEasy.Checked
        My.Settings.Save()
        Print("Onlook Viewer is set for the Full UI mode. Change will occur when the sim is restarted")
    End Sub

    Private Sub NoneToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles mnuNoAvatar.Click
        mnuNoAvatar.Checked = True
        mnuYesAvatar.Checked = False
        My.Settings.AvatarShow = False
        My.Settings.Save()
        Print("Your Avatar will not be shown when you log in. Change will occur when the Viewer is next logged in.")
    End Sub

    Private Sub VisibleToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles mnuYesAvatar.Click
        Print("Your Avatar will be shown when you log in. Use the Arrow keys to move around. Use Page Up and Page Down to move the camera Up and Down.  Change will occur when the Viewer is next logged in")
        mnuYesAvatar.Checked = True
        mnuNoAvatar.Checked = False
        My.Settings.AvatarShow = True
        My.Settings.Save()
    End Sub

    Private Function Random() As String
        Dim value As Integer = CInt(Int((6000 * Rnd()) + 1))
        Random = Str(value)
    End Function

    Private Sub WebUIToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Print("The Web UI lets you add or view settings for the default avatar. ")
        If Running Then
            Dim webAddress As String = "http://127.0.0.1:" + My.Settings.WifiPort
            Process.Start(webAddress)
        End If
    End Sub

    Private Sub ShutdownNowToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
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
        GetIni = Data(section)(key)
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
            Log("Info:Writing " + key + "' in section '" + section + "' in file " + filepath)
            parser.WriteFile(filepath, Data)
        Catch ex As Exception
            Log("Info:Cannot locate '" + key + "' in section '" + section + "' in file " + filepath + ". This is not good")
            MsgBox("Cannot locate '" + key + "' in section '" + section + "' in file " + filepath + ". This is not good", vbOK)
        End Try
    End Sub
    Private Sub CleanAll()
        Clean("HyperGrid")
        Clean("OsGrid")
    End Sub
    Private Sub Clean(AGrid As String)
        Try
            System.IO.Directory.Delete(gCurDir & "\DreamWorldFiles\" & AGrid & "\bin\addin-db-002", True)
        Catch ex As Exception
            Log("Info:addin-db-002 was empty")
        End Try
        Try
            System.IO.Directory.Delete(gCurDir & "\DreamWorldFiles\" & AGrid & "\bin\assetcache", True)
        Catch ex As Exception
            Log("Info:Assetcache had nothing in it")
        End Try
        Try
            System.IO.Directory.Delete(gCurDir & "\DreamWorldFiles\" & AGrid & "\bin\DataSnapshot", True)
        Catch ex As Exception
            Log("Info:Nothing in DataSnapshot")
        End Try

        Try
            System.IO.Directory.Delete(gCurDir & "\DreamWorldFiles\" & AGrid & "\bin\ScriptEngines", True)
        Catch ex As Exception
            Log("Info:Empty scriptengines")
        End Try
        Try
            System.IO.Directory.Delete(gCurDir & "\DreamWorldFiles\" & AGrid & "\bin\MapTiles", True)
        Catch ex As Exception
            Log("Info:No Maptiles to delete")
        End Try
        Try
            My.Computer.FileSystem.DeleteFile(gCurDir + "\DreamWorldFiles" & AGrid & "\bin\Opensim.log")
        Catch ex As Exception
            Log("Info:Opensim.log is empty")
        End Try

        Try
            My.Computer.FileSystem.DeleteFile(gCurDir + "\DreamWorldFiles\" & AGrid & "\bin\OpenSimConsoleHistory.txt")
        Catch ex As Exception
            Log("Info:Console history is empty")
        End Try
        Try
            My.Computer.FileSystem.DeleteFile(gCurDir + "\DreamWorldFiles\Init.txt")
        Catch ex As Exception
            Log("Info:Never initted")
        End Try

        MsgBox("Info:System Is Clean")
        End
    End Sub

    Private Sub mnuOsGrid_Click(sender As Object, e As EventArgs) Handles mnuOsGrid.Click
        My.Settings.GridFolder = "OsGrid"
        My.Settings.GridFolder = My.Settings.GridFolder
        My.Settings.Save()
        mnuOsGrid.Checked = True
        mnuHyperGrid.Checked = False
        Print("DreamWorlds will connect to OsGrid.org. You must log in with an Avatar name registered with OsGrid.org. You must also 'Port Forward' your router to this machine on port 8000 for Tcp and Udp traffic")
        Try
            My.Computer.FileSystem.CopyFile(gCurDir & "\Viewer\grids_sg_OsGrid.xml", xmlPath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml", True)
        Catch
            Log("Error:Cannot copy " + gCurDir & "\Viewer\grids_sg_OsGrid.xml to " + xmlPath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml")
        End Try
    End Sub

    Private Sub mnuHyperGrid_Click(sender As Object, e As EventArgs) Handles mnuHyperGrid.Click
        My.Settings.GridFolder = "HyperGrid"
        My.Settings.GridFolder = My.Settings.GridFolder
        My.Settings.Save()
        mnuOsGrid.Checked = False
        mnuHyperGrid.Checked = True

        Print("DreamWorlds will connect as a locally hosted hypergridded sim.")
        Log("DreamWorlds will connect as a locally hosted hypergridded sim.")
        My.Computer.FileSystem.CopyFile(gCurDir & "\Viewer\grids_sg_HyperGrid.xml", xmlPath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml", True)
    End Sub

    Private Sub SetINIFromSettings()

        'mnuShow shows the DOS box for Opensimulator
        mnuShow.Checked = My.Settings.ConsoleShow
        mnuHide.Checked = Not My.Settings.ConsoleShow
        If My.Settings.ConsoleShow Then
            Log("Info:Console will be shown")
        End If

        ' Viewer UI shows the full viewer UI
        If My.Settings.ViewerEase Then
            Log("Info:Viewer set to Easy")
            SetIni(gCurDir & "\DreamWorldFiles\" & My.Settings.GridFolder & "\bin\Opensim.ini", "SpecialUIModule", "enabled", "false", ";")
        Else
            Log("Info:Viewer set to Normal")
            SetIni(gCurDir & "\DreamWorldFiles\" & My.Settings.GridFolder & "\bin\Opensim.ini", "SpecialUIModule", "enabled", "true", ";")
        End If
        mnuFull.Checked = My.Settings.ViewerEase
        mnuEasy.Checked = Not My.Settings.ViewerEase

        'Avatar visible?
        If My.Settings.AvatarShow Then
            Log("Info:Showing the avatar")
            SetIni(gCurDir & "\DreamWorldFiles\" & My.Settings.GridFolder & "\bin\Opensim.ini", "CameraOnlyModeModule", "enabled", "false", ";")
        Else
            Log("Info:Set to not show avatar")
            SetIni(gCurDir & "\DreamWorldFiles\" & My.Settings.GridFolder & "\bin\Opensim.ini", "CameraOnlyModeModule", "enabled", "true", ";")
        End If
        mnuYesAvatar.Checked = My.Settings.AvatarShow
        mnuNoAvatar.Checked = Not My.Settings.AvatarShow

        ' Grid
        If My.Settings.GridFolder = "HyperGrid" Then
            Log("Info:Local Hypergrid enabled")
            mnuHyperGrid.Checked = True
            mnuOsGrid.Checked = False
        End If

        If My.Settings.GridFolder = "OsGrid" Then
            Log("osgrid enabled")
            mnuHyperGrid.Checked = False
            mnuOsGrid.Checked = True
        End If

        'Onlook viewer
        If My.Settings.Onlook = True Then
            Log("Info:Onlook viewer mode")
            mnuOther.Checked = False
            mnuOnlook.Checked = True
        Else
            Log("Info:Other viewer mode")
            mnuOther.Checked = True
            mnuOnlook.Checked = False
        End If

        ' Autobackup
        If My.Settings.AutoBackup Then
            Log("Info:Autobackup is On")
            SetIni(gCurDir & "\DreamWorldFiles\" & My.Settings.GridFolder & "\bin\Opensim.ini", "AutoBackupModule", "AutoBackup", "true", ";")
            AutoYes.Checked = True
            AutoNo.Checked = False
            My.Settings.AutoBackup = True
        Else
            Log("Info:Autobackup is Off")
            SetIni(gCurDir & "\DreamWorldFiles\" & My.Settings.GridFolder & "\bin\Opensim.ini", "AutoBackupModule", "AutoBackup", "false", ";")
            AutoYes.Checked = False
            AutoNo.Checked = True
            My.Settings.AutoBackup = False
        End If

        If My.Settings.SizeX = 256 And My.Settings.SizeY = 256 Then
            Log("Info:Grid is 256X256")
            Adv.Check256.Checked = True
            Adv.Check512.Checked = False
            Adv.Check1024.Checked = False
        ElseIf My.Settings.SizeX = 512 And My.Settings.SizeY = 512 Then
            Log("Info:Grid is 512X512")
            Adv.Check256.Checked = False
            Adv.Check512.Checked = True
            Adv.Check1024.Checked = False
        ElseIf My.Settings.SizeX = 1024 And My.Settings.SizeY = 1024 Then
            Log("Info:Grid is 1024X1024")
            Adv.Check256.Checked = False
            Adv.Check512.Checked = False
            Adv.Check1024.Checked = True
        Else
            Log("Info:Grid is manually set to " + My.Settings.SizeX + My.Settings.SizeY)
            Adv.Check256.Checked = False
            Adv.Check512.Checked = False
            Adv.Check1024.Checked = False
            Adv.SizeX.Text = My.Settings.SizeX
            Adv.SizeY.Text = My.Settings.SizeY
        End If


        ' RegionConfig
        SetIni(gCurDir + "\DreamWorldFiles\" + My.Settings.GridFolder + "\bin\Regions\RegionConfig.ini", "DreamWorld", "SizeY", My.Settings.SizeY, ";")
        SetIni(gCurDir + "\DreamWorldFiles\" + My.Settings.GridFolder + "\bin\Regions\RegionConfig.ini", "DreamWorld", "SizeX", My.Settings.SizeX, ";")

        Log("Info:Public IP is " + My.Settings.PublicIP)
        SetIni(gCurDir + "\DreamWorldFiles\" + My.Settings.GridFolder + "\bin\Regions\RegionConfig.ini", "DreamWorld", "ExternalHostName", My.Settings.PublicIP, ";")
        SetIni(gCurDir + "\DreamWorldFiles\" + My.Settings.GridFolder + "\bin\Opensim.ini", "Const", "BaseURL", My.Settings.PublicIP, ";")

        Log("Info:Public Port is " + My.Settings.PublicPort)
        SetIni(gCurDir + "\DreamWorldFiles\" + My.Settings.GridFolder + "\bin\Opensim.ini", "Const", "PublicPort", My.Settings.PublicPort, ";")
        SetIni(gCurDir + "\DreamWorldFiles\" + My.Settings.GridFolder + "\bin\Regions\RegionConfig.ini", "DreamWorld", "InternalPort", My.Settings.PublicPort, ";")


    End Sub

    Private Sub YesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoYes.Click
        Print("DreamWorlds Is set Autoback the sim into an OAR every 24 hours. Backups will be saved in the AutoBackup folder")
        Log("Info:Backups are enabled")
        AutoYes.Checked = True
        AutoNo.Checked = False
        My.Settings.AutoBackup = True
        My.Settings.Save()
    End Sub

    Private Sub AutoNo_Click(sender As Object, e As EventArgs) Handles AutoNo.Click
        Print("Backups disabled")
        Log("Info:Backups are disabled")
        AutoYes.Checked = False
        AutoNo.Checked = True
        My.Settings.AutoBackup = False
        My.Settings.Save()
    End Sub

    Function AllowFirewall() As Boolean
        Log("uPnp:probing")
        Dim MyUPnPMap As New UPnP
        Dim portcount = 0
        Try
            If MyUPnPMap.Exists(My.Settings.PublicPort, UPnP.Protocol.UDP) Then
                Log("uPnp:PublicPort.UDP exists")
                MyUPnPMap.Remove(My.Settings.PublicPort, UPnP.Protocol.UDP)
                MyUPnPMap.Add(UPnP.LocalIP, My.Settings.PublicPort, UPnP.Protocol.UDP, "Opensim UDP")
            Else
                Log("uPnp:PublicPort.UDP added")
                MyUPnPMap.Add(UPnP.LocalIP, My.Settings.PublicPort, UPnP.Protocol.UDP, "Opensim UDP")
            End If

            If MyUPnPMap.Exists(My.Settings.PublicPort, UPnP.Protocol.TCP) Then
                Log("uPnp:PublicPort.TCP exists")
                MyUPnPMap.Remove(My.Settings.PublicPort, UPnP.Protocol.TCP)
                MyUPnPMap.Add(UPnP.LocalIP, My.Settings.PublicPort, UPnP.Protocol.TCP, "Opensim TCP")
            Else
                Log("uPnp:PublicPort.UDP added")
                MyUPnPMap.Add(UPnP.LocalIP, My.Settings.PublicPort, UPnP.Protocol.TCP, "Opensim TCP")
            End If

            If MyUPnPMap.Exists(8001, UPnP.Protocol.TCP) Then
                Log("uPnp:8001.TCP exists")
                MyUPnPMap.Remove(8001, UPnP.Protocol.TCP)
                MyUPnPMap.Add(UPnP.LocalIP, 8001, UPnP.Protocol.TCP, "Opensim Probe")
            Else
                Log("uPnp:8001.TCP Added ")
                MyUPnPMap.Add(UPnP.LocalIP, 8001, UPnP.Protocol.TCP, "Opensim Probe")
            End If
        Catch
            Log("uPnp:UPnP Exception caught")
            Return False
        End Try
        Return True 'successfully added
    End Function

    Private Function OpenPorts()

        Print("Human is instructed to wait while I say hello to your router ...")
        Try
            If AllowFirewall() Then ' open uPNP port
                Log("uPnp:Ok")
                Print("Ok, looking good ...")
                Return True
            Else
                Log("uPnP:fail")
                Print("UPnP Port forwarding is not enabled. Opensimulator is installing as a stand alone application.")
                Return False
            End If
        Catch e As Exception
            Log("Error:uPnP Exception")
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
        Log("Info:Stopped")
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

    Private Sub AdminUIToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AdminUIToolStripMenuItem1.Click
        If (Running) Then
            Dim webAddress As String = "http://127.0.0.1:" + My.Settings.PublicPort + "/?r=" + Random()
            Process.Start(webAddress)
            Print("Log in as 'Wifi Administrator' with a password of 'secret' to add users")
        Else
            Print("Opensim is not running")
        End If
    End Sub
    Private Sub SimContent(thing As String, type As String)
        ' remove the console startup file
        Try
            My.Computer.FileSystem.DeleteFile(gCurDir & "\DreamworldFiles\" + My.Settings.GridFolder & "\bin\startup_commands.txt")
        Catch ex As Exception
            Log("Info:no Opensim startup commands located")
        End Try
        Try
            If type = "iar" Then
                Using outputFile As New StreamWriter(gCurDir & "\DreamworldFiles\" + My.Settings.GridFolder & "\bin\startup_commands.txt", True)
                    outputFile.WriteLine("load iar --merge Dream World / 123 " + Chr(34) + thing + Chr(34))
                    outputFile.WriteLine("show stats")
                End Using
            ElseIf type = "oar" Then
                Using outputFile As New StreamWriter(gCurDir & "\DreamworldFiles\" + My.Settings.GridFolder & "\bin\startup_commands.txt", True)
                    outputFile.WriteLine("load " + type + "  " + Chr(34) + thing + Chr(34))
                    outputFile.WriteLine("show stats")
                End Using
            End If
        Catch
            Log("Error:iar or oar file write failure")
        End Try

    End Sub

    Private Sub ZapAll()



        ' remove the console startup file
        Try
            My.Computer.FileSystem.DeleteFile(gCurDir & "\DreamworldFiles\" + My.Settings.GridFolder & "\bin\startup_commands.txt")
        Catch ex As Exception
            Log("Warn:There was no startup_commands.txt file")
        End Try
        Try
            If ContentLoading = False Then
                Using outputFile As New StreamWriter(gCurDir & "\DreamworldFiles\" + My.Settings.GridFolder & "\bin\startup_commands.txt", True)
                    outputFile.WriteLine("save oar " + gCurDir & "\DreamworldFiles\Autobackup\DreamWorldBackup.oar")
                    outputFile.WriteLine("show stats")
                    ContentLoading = False
                End Using
            End If

        Catch ex As Exception
            Log("Error:writing of the Backup OAR command failed")
        End Try

        ProgressBar1.Value = 100
        pOpensim.Close()
        ' zap("OpenSim")
        ProgressBar1.Value = 50
        'zap("mysqld-nt")
        pMySql.Close()

        'zap("OnlookViewer")
        pOnlook.Close()
        ProgressBar1.Value = 0
        Application.DoEvents()
        Running = False
        Print("Opensimulator is stopped.")
    End Sub

    Private Sub TextBox1_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles TextBox1.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        ContentLoading = True

        For Each pathname In files
            pathname.Replace("\", "/")
            Dim extension = Path.GetExtension(pathname)
            extension = Mid(extension, 2, 5)
            If extension.ToLower = "iar" Then
                SimContent(pathname, extension)
                Log("Info:Load iar " + pathname)
                Print("Opensim will load your file when it is restarted. This may take time to load. You will find it in your inventory.")
            ElseIf extension.ToLower = "oar" Then
                SimContent(pathname, extension)
                Log("Info:Load oar " + pathname)
                Print("Opensim will load your file when it is restarted. This may take time to load.")
            ElseIf extension.ToLower = ".gz" Then
                Log("Info:Load oar " + pathname)
                SimContent(pathname, extension)
                Log("Info:Load gz " + pathname)
                Print("Opensim will load your file when it is restarted. This may take time to load.")
            Else
                Log("Info:Unrecognized file type:" + extension)
                Print("Unrecognized file type:" + extension + ".  Drag and drop any OAR or IAR files to load them when the sim starts")
                ContentLoading = False
            End If
        Next
    End Sub

    Private Sub TextBox1_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles TextBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub OnlookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuOnlook.Click
        Print("Onlook Viewer will be launched on Startup")
        mnuOther.Checked = False
        mnuOnlook.Checked = True
        My.Settings.Onlook = True
        My.Settings.Save()
        VUI.Visible = True
    End Sub

    Private Sub OtherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuOther.Click
        Print("Onlook Viewer will not be launched on Startup.")
        mnuOther.Checked = True
        mnuOnlook.Checked = False
        My.Settings.Onlook = False
        VUI.Visible = False
        My.Settings.Save()
    End Sub

    Private Sub LoadPirateIslandToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadPirateIslandToolStripMenuItem.Click
        SimContent("http://www.outworldz.com/DreamWorld/OAR/LonelyIsland.oar", "oar")
        Print("Opensim will load LonelyIsland.oar when it is restarted. This may take time to load.")
    End Sub

    Private Sub LoadStorrmhavenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadStormhavenToolStripMenuItem.Click
        SimContent("http://www.outworldz.com/DreamWorld/OAR/Stormhaven Port Aurora.oar", "oar")
        Print("Opensim will load Stormhaven Port Aurora by Arcadia Asylum when restarted. This may take time to load.")
    End Sub
    Private Sub FantasyIslandToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FantasyIslandToolStripMenuItem.Click
        SimContent("http://www.outworldz.com/DreamWorld/OAR/Fantasy OAR.gz", "oar")
        Print("Opensim will load Fantasy Island by Linda Kellie when restarted. This may take time to load.")
    End Sub

    Private Sub EducationSimToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuUndersea.Click
        SimContent("http://www.outworldz.com/DreamWorld/OAR/Undersea_Observatory.oar", "oar")
        Print("Opensim will load Doomed City by J.P. van de Giessen  when restarted. This may take time to load.")
    End Sub

    Private Sub SteamIslandToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SteamIslandToolStripMenuItem.Click
        SimContent("http://www.outworldz.com/DreamWorld/OAR/OAR-Steam Factory.oar", "oar")
        Print("Opensim will load Steam Factory when restarted. This may take time to load.")
    End Sub

    Private Sub MayaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MayaToolStripMenuItem.Click
        SimContent("http://www.outworldz.com/DreamWorld/OAR/Maya OAR.oar", "oar")
        Print("Opensim will load Maya by Dave Pentecost when restarted. Includes large houses with courtyards, small thatched palapas, and a model of the Temple of the Inscriptions Maya pyramid from Palenque, Mexico.  This may take time to load.")
    End Sub

    Private Sub BlankSimToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupToolStripMenuItem.Click
        SimContent(gCurDir & "\DreamworldFiles\Autobackup\DreamWorldBackup.oar", "oar")
        Print("Opensim will load \Autobackup\DreamWorldBackup.oar when it is restarted. This may take time to load.")
    End Sub

    Private Sub MensClothingToolStripMenuItem_Click(sender As Object, e As EventArgs)
        SimContent("http://www.outworldz.com/DreamWorld/OAR/LK-MENS-CLOTHING.iar", "iar")
        Print("Opensim will load LK-MENS-CLOTHING.iar by Linda Kellie when it is restarted. This may take time to load. You will find it in your inventory.")
    End Sub

    Private Sub FullAvatarsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FullAvatarsToolStripMenuItem.Click
        SimContent("http://www.outworldz.com/DreamWorld/OAR/FULLAVATARS.iar", "iar")
        Print("Opensim will load FULLAVATARS.iar by Linda Kellie when it is restarted. This may take time to load. You will find it in your inventory.")
    End Sub

    Private Sub FemaleClothingToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FemaleClothingToolStripMenuItem1.Click
        SimContent("http://www.outworldz.com/DreamWorld/OAR/LK-WOMENS-CLOTHING.iar", "iar")
        Print("Opensim will load LK-WOMENS-CLOTHING.iar by Linda Kellie when it is restarted. This may take time to load. You will find it in your inventory.")
    End Sub

    Private Sub ConferenceCenterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConferenceCenterToolStripMenuItem.Click
        SimContent("http://www.outworldz.com/DreamWorld/OAR/ConferenceCenter.gz", "oar")
        Print("Opensim will load  ConferenceCenter.gz by Linda Kellie when it is restarted. This may take a long time to load. ")
    End Sub

    Private Sub LoopBackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoopBackToolStripMenuItem.Click
        Dim webAddress As String = "http://www.outworldz.com/Dreamworld/Loopback.htm"
        Process.Start(webAddress)
    End Sub

    Private Sub MoreContentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoreContentToolStripMenuItem.Click
        Dim webAddress As String = "http://www.outworldz.com/cgi/freesculpts.plx"
        Process.Start(webAddress)
        Print(" Drag and drop  OAR or IAR files here to load them whenever the sim starts")
    End Sub
    Private Sub ExitAll()
        Print("Stopping")
        Try
            RemoveGrid()
            ws.StopWebServer()
            Log("Info:Webserver stopped.")
        Catch
            Log("Error:Webserver failed to stop")
        End Try

        ' Needed to stop Opensim
        ZapAll()
        End
    End Sub
    Private Sub LogFiles(progress As Integer)
        ' clear out the log files
        Try
            My.Computer.FileSystem.DeleteFile(gCurDir + "\DreamWorldFiles" & My.Settings.GridFolder & "\bin\Opensim.log")
        Catch ex As Exception
            Log("Info:Opensim Log file did not exist")
        End Try

        Try
            My.Computer.FileSystem.DeleteFile(gCurDir + "\DreamWorldFiles\" & My.Settings.GridFolder & "\bin\OpenSimConsoleHistory.txt")
        Catch ex As Exception
            Log("Info:Console history was not empty")
        End Try
        ProgressBar1.Value = progress
    End Sub

    Private Sub StartMySql(progress As Integer)
        ' Start MySql in background.  
        Print("Starting Database")

        SetIni(gCurDir & "\DreamWorldFiles\mysql\my.ini", "mysqld", "basedir", """" + gCurSlashDir + "/DreamWorldFiles/Mysql" + """", "#")
        SetIni(gCurDir & "\DreamWorldFiles\mysql\My.ini", "mysqld", "datadir", """" + gCurSlashDir + "/DreamWorldFiles/Mysql/Data" + """", "#")


        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = "--defaults-file=" + gCurSlashDir + "/DreamworldFiles/mysql/my.ini"
        pi.WindowStyle = ProcessWindowStyle.Hidden
        pi.FileName = gCurDir & "\DreamWorldFiles\mysql\bin\mysqld-nt.exe"
        pMySql.StartInfo = pi
        pMySql.Start()

        ProgressBar1.Value = progress / 2

        ' Check for MySql operation

        Dim Mysql = False
        ' wait for MySql to come up 
        Mysql = CheckMySQL()
        While Not Mysql
            ProgressBar1.Value = ProgressBar1.Value + 1
            Application.DoEvents()
            If ProgressBar1.Value = 100 Then
                MsgBox("Timeout running MySQL - cannot Continue", vbAbort)
                ZapAll()
                Buttons(StartButton)
                Return
            End If

            ' check again
            Sleep(1000)
            Mysql = CheckMySQL()
        End While
        ProgressBar1.Value = progress
    End Sub
    Private Sub GetPubIP(progress As Integer)

        Print("Getting Public IP")
        ' Set Public Port
        Try
            My.Settings.PublicIP = client.DownloadString("https://api.ipify.org")
        Catch ex As Exception
            Print("Cannot reach the Internet? Proceeding locally")
            My.Settings.PublicIP = "127.0.0.1"
        End Try

        ProgressBar1.Value = progress
    End Sub
    Private Sub Loopback(progress As Integer)
        Print("Testing Loopback")
        Try
            Application.DoEvents()
            Dim Benchmark = client.DownloadString("http://" & My.Settings.PublicIP & ":8001/Init.txt")
            Application.DoEvents()
        Catch ex As Exception

            Application.DoEvents()
            Print("Hypergrid travel requires a router with 'loopback'. It seems to be missing from yours. See the Help section for 'Loopback' and how to enable it in Windows. Opensim can still continue, but without Hypergrid.")
            MsgBox("See Info on screen about Loopback. Opensim can still continue, but without Hypergrid", vbExclamation)
            My.Settings.PublicIP = "127.0.0.1" ' dang it, we cannot go to the hypergird
        End Try
        ProgressBar1.Value = progress
    End Sub

    Private Sub Start_Opensimulator(progress As Integer)
        Print("Starting Opensimulator")


        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.WorkingDirectory = gCurDir & "\DreamWorldFiles\" & My.Settings.GridFolder & "\bin\"
        If mnuHide.Checked Then
            Log("Info:Opensim console is hidden")
            pi.Arguments = "-console rest -background True "
            pi.WindowStyle = ProcessWindowStyle.Hidden
        Else
            Log("Info:Opensim console is visible")
            pi.Arguments = ""
            pi.WindowStyle = ProcessWindowStyle.Normal
        End If

        pi.FileName = gCurDir & "\DreamWorldFiles\" & My.Settings.GridFolder & "\bin\OpenSim.exe"
        pOpensim.StartInfo = pi

        Try
            pOpensim.Start()
        Catch
            Dim yesno = MsgBox("Opensim did not start. Do you want to see the log file?", vbYesNo)
            If (yesno = vbYes) Then
                Dim Log As String = gCurDir + "\DreamWorldFiles\" & My.Settings.GridFolder & "\bin\OpenSim.log"
                System.Diagnostics.Process.Start("wordpad.exe", Log)
            End If
            ZapAll()
            Buttons(StartButton)
            Return
        End Try

        ' Wait for Opensim to start listening via wifi
        Dim Up = ""
        Try
            Up = client.DownloadString("http://127.0.0.1:" + +My.Settings.WifiPort + "/?r=" + Random())
        Catch ex As Exception
            Up = ""
        End Try

        While Up.Length = 0
            Application.DoEvents()
            ProgressBar1.Value = ProgressBar1.Value + 1
            If ProgressBar1.Value > 90 Then
                Print("Opensim failed to start")
                ZapAll()
                Buttons(StartButton)
                Dim yesno = MsgBox("Opensim did not start. Do you want to see the log file?", vbYesNo)
                If (yesno = vbYes) Then
                    Dim Log As String = gCurDir + "\DreamWorldFiles\" & My.Settings.GridFolder & "\bin\OpenSim.log"
                    System.Diagnostics.Process.Start("wordpad.exe", Log)
                End If
                ZapAll()
                Buttons(StartButton)
                Return
            End If
            Application.DoEvents()
            Sleep(3000)

            Try
                Up = client.DownloadString("http://127.0.0.1:8002/?r=" + Random())
            Catch ex As Exception
                Up = ""
            End Try

        End While

        ContentLoading = False ' the server is now loaded, so flip the content switch off.  The server will do a Autobackup on the next startup.
        ProgressBar1.Value = progress

    End Sub

    Private Sub Onlook(progess As Integer)

        If My.Settings.Onlook Then
            Print("Starting Onlook viewer")
            Dim p As Process = New Process()
            Dim pi As ProcessStartInfo = New ProcessStartInfo()
            pi.Arguments = ""
            pi.FileName = "C:\Program Files (x86)\Onlook\OnLookViewer.exe"
            pi.WindowStyle = ProcessWindowStyle.Normal
            p.StartInfo = pi
            Try
                p.Start()
            Catch
                Log("Error:Onlook failed to launch")
            End Try

        End If

        ProgressBar1.Value = 95
    End Sub


    Private Sub AdvancedSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdvancedSettingsToolStripMenuItem.Click

        Adv.Visible = True

        ' Set the new form's desktop location so it appears below and 
        ' to the right of the current form.
        Adv.SetDesktopLocation(200, 200)

        ' Keep the current form active by calling the Activate method.
        Adv.Activate()
    End Sub

    Private Sub InstallGridXML()

        ' we have to change the viewer Grid settings  if we are on localhost

        Print("Setting Grid Info...")

        Try
            My.Computer.FileSystem.CopyFile(xmlPath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml", xmlPath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml.xml.bak", True)
        Catch
            Log("Error:Failed to back up onlook XML")
        End Try

        Try
            My.Computer.FileSystem.CopyFile(gCurDir & "\Viewer\Hypergrid.xml", xmlPath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml", True)
        Catch ex As Exception
            Log("Error:Failed to install onlook XML")
        End Try

    End Sub

    Private Sub RemoveGrid()

        ' restore backup - they may have changed it. Dreamworlds is supposed to be simple. If they launch the viewer by itself, they can change grids
        Try
            My.Computer.FileSystem.CopyFile(xmlPath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml.bak", xmlPath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml", True)
        Catch
            Log("Error:failed to restore Onlook xml backup")
        End Try

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim webAddress As String = "http://www.outworldz.com/Dreamworld/PortForwarding.htm"
        Process.Start(webAddress)
    End Sub

    Private Sub SingularityToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SingularityToolStripMenuItem.Click
        Dim webAddress As String = "http://www.singularityviewer.org/"
        Process.Start(webAddress)
    End Sub

    Private Sub CatznipToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CatznipToolStripMenuItem.Click
        Dim webAddress As String = "http://catznip.com/"
        Process.Start(webAddress)
    End Sub

    Private Sub KokuaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KokuaToolStripMenuItem.Click
        Dim webAddress As String = "http://blog.kokuaviewer.org/"
        Process.Start(webAddress)
    End Sub


    Private Sub UKanDoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UKanDoToolStripMenuItem.Click
        Dim webAddress As String = "http://www.ukando.info/"
        Process.Start(webAddress)
    End Sub

    Private Sub FirestormToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FirestormToolStripMenuItem.Click
        Dim webAddress As String = "http://www.firestormviewer.org/"
        Process.Start(webAddress)
    End Sub

    Private Sub AlchemyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlchemyToolStripMenuItem.Click
        Dim webAddress As String = "https://www.alchemyviewer.org/"
        Process.Start(webAddress)
    End Sub

    Private Sub BlackDragonToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim webAddress As String = "https://bitbucket.org/NiranV/black-dragon-viewer/wiki/Home"
        Process.Start(webAddress)
    End Sub

    Public Function Log(message As String)
        Using outputFile As New StreamWriter(gCurDir & "\DreamworldFiles\DreamWorld.log", True)
            outputFile.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + message)
        End Using
        Return True
    End Function


    Public Property MyFolder() As String
        Get
            Return gCurDir
        End Get
        Set(ByVal Value As String)
            gCurDir = Value
        End Set
    End Property

End Class


