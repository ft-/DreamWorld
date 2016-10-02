
Imports System.Net
Imports System.Text
Imports System.IO
Imports System.Net.Sockets
Imports IWshRuntimeLibrary
Imports IniParser
Imports System.Threading
Imports Ionic.Zip

' Copyright 2014 Fred Beckhusen  
' Redistribution and use in binary and source form is permitted provided 
' that ALL the licenses in the text files are followed and included in all copies

' Command line args:
'     '-clean' makes it wipe out Opensim files that are not needed for zipping
'     '-debug' forces this to use the \Outworldzs folder for testing 
'     '-nodiag' skips all the diagnostics and UPnP. requires ports to be manually opened

Public Class Form1

#Region "Declarations"
    Dim MyVersion As Single = 0.5
    Dim remoteUri As String = "http://www.outworldz.com/Outworldz_Installer/" ' requires trailing slash
    Dim gCurDir    ' Holds the current folder that we are running in
    Dim gCurSlashDir As String '  holds the current directory info in Unix format
    Dim isRunning As Boolean = False
    Dim DiagFailed As Boolean = False
    Dim ws As Net
    Public gChatTime As Integer = 1500
    Dim ContentLoading As Boolean = False
    Dim client As New System.Net.WebClient
    Dim pMySql As Process = New Process()
    Dim pOpensim As Process = New Process()
    Dim pOnlook As Process = New Process()
    Private Shared m_ActiveForm As Form
#End Region


#Region "Properties"
    Public Property Running() As Boolean
        Get
            Return isRunning
        End Get
        Set(ByVal Value As Boolean)
            isRunning = Value
        End Set
    End Property
    Public Property MyFolder() As String
        Get
            Return gCurDir
        End Get
        Set(ByVal Value As String)
            gCurDir = Value
        End Set
    End Property

    Public Shared Property ActualForm() As Form
        Get
            ActualForm = m_ActiveForm
        End Get
        Set(ByVal Value As Form)
            m_ActiveForm = Value
        End Set
    End Property
#End Region

#Region "Methods"
    Private Sub Form1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Log("Info:Exit")
        ProgressBar1.Value = 90
        Print("Hold fast to your dreams ...")
        ExitAll()
        ProgressBar1.Value = 25
        Print("I'll tell you my next dream when I wake up.")
        Sleep(1000)
        ProgressBar1.Value = 0
        Print("Zzzzzz....")
        Sleep(1000)
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Buttons(BusyButton)

        ' hide updater
        UpdaterGo.Visible = False
        UpdaterCancel.Visible = False

        'hide the pulldowns as there is no content yet
        MnuContent.Visible = False
        mnuSettings.Visible = False

        'hide progress
        ProgressBar1.Visible = False
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = 100
        ProgressBar1.Value = 0

        Me.Show()

        Me.AllowDrop = True
        TextBox1.AllowDrop = True

        Running = False ' true when opensim is running

        MyFolder = My.Application.Info.DirectoryPath

        gCurSlashDir = MyFolder.Replace("\", "/")    ' because Mysql uses unix like slashes, that's why

        ' I would like to buy an argument
        Dim arguments As String() = Environment.GetCommandLineArgs()

        If arguments.Length > 1 Then
            ' for debugging when compiling
            If arguments(1) = "-clean" Then
                ' Clean up the file system
                CleanAll()
            ElseIf arguments(1) = "-debug" Then
                MyFolder = "\Outworldz" ' for testing, as the compiler buries itself in ../../../debug
                Log("Info:Using Debug folder \Outworldz")
                gCurSlashDir = "/Outworldz"
            ElseIf arguments(1) = "-nodiag" Then
                My.Settings.Diagnostics = False
            End If
        End If

        SaySomething()

        ProgressBar1.Visible = True
        ProgressBar1.Value = 5
        Sleep(5000)
        Log("Info: Loading Web Server")
        ws = Net.getWebServer
        Log("Info: Starting Web Server")
        ws.StartServer(MyFolder)

        ProgressBar1.Value = 10
        GetPubIP(15)
        SetINIFromSettings(20)
        mnuSettings.Visible = True
        SetIAROARContent(30) ' load IAR and OAR web content
        MnuContent.Visible = True
        InstallGridXML(40)

        ' Find out if the viewer is installed
        If System.IO.File.Exists(MyFolder & "\OutworldzFiles\Init.txt") Then

            ' Diagnose the system
            DiagFailed = False
            OpenPorts(45) ' Open router ports with uPnP
            ProbePublicPort(50)
            Loopback(60)    ' test the loopback on the router. If it fails, use localhost, no Hg
            If (DiagFailed) Then
                Print("Diagnostics can be re-run in the Help menu 'Diagnostics' at any time")
                Sleep(3000)
            End If

            StartMySql(100) ' boot up MySql, and wait for it to start listening

            Buttons(StartButton)
            ProgressBar1.Value = 100
            Print("Outworldz Opensimulator is ready to start.")
            Log("Info:Ready to start")

            CheckForUpdates(False) ' don't text if no update

        Else
            Print("Installing Desktop Icon")
            Create_ShortCut(MyFolder & "\Start.exe")
            ProgressBar1.Value = 60

            Try
                ' mark the system as read        
                Using outputFile As New StreamWriter(MyFolder & "\OutworldzFiles\Init.txt", True)
                    outputFile.WriteLine("This file lets Outworldz know it has been installed and to benchmark the network loopback")
                End Using
            Catch ex As Exception
                Log("Could not create Init.txt:" + ex.Message)
            End Try

            Print("Installing Onlook Viewer")
            Dim pi As ProcessStartInfo = New ProcessStartInfo()
            pi.Arguments = ""
            pi.FileName = MyFolder & "\Viewer\Onlook.exe"
            pOnlook.StartInfo = pi
            Try
                Log("Info:Launching Onlook installer")
                pOnlook.Start()
            Catch ex As Exception
                Log("Error:Onlook installer failed to load:" + ex.Message)
            End Try

            ProgressBar1.Value = 62
            Print("Please Install and Start the Onlook Viewer")
            Dim toggle As Boolean = False
            While Not System.IO.File.Exists(xmlPath() + "\AppData\Roaming\Onlook\user_settings\settings_onlook.xml") And ProgressBar1.Value < 99
                Application.DoEvents()
                Sleep(4000)
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
                    Print("You win. Proceeding with Outworldz Installation. You may need to add the grid manually.")
                    toggle = True
                End If
            End While

            ProgressBar1.Value = 100
            Print("Ready to Launch! Click 'Start' to begin the dreaming in the Outworldz.")
            Buttons(StartButton)
        End If

    End Sub
    Private Sub StartButton_Click(sender As System.Object, e As System.EventArgs) Handles StartButton.Click

        ContentLoading = False
        Try
            My.Computer.FileSystem.DeleteFile(MyFolder & "\OutworldzFiles\Outworldz.log")
        Catch
        End Try
        Try
            My.Computer.FileSystem.DeleteFile(MyFolder & "\OutworldzFiles\Server.log")
        Catch ex As Exception
        End Try

        ' Set up the progres bar for 0-100
        ProgressBar1.Visible = True
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = 100
        ProgressBar1.Value = 0

        Buttons(BusyButton)
        Running = True

        LogFiles(5) ' clear log fles

        SetINIFromSettings(10)    ' set up the INI files

        OpenPorts(20)

        Start_Opensimulator(40) ' Launch the rocket

        Onlook(100)

        Buttons(StopButton)
        If My.Settings.PublicIP = "127.0.0.1" Then
            Log("Info:PublicIP = 127.0.0.1")
            Print("Access to the Hypergrid is disabled because of your router. See Help->Loopback to see why.")
        Else
            Log("Info:Ready for login")
            Print("Outworldz is ready for you to log in. Hypergrid address is " + My.Settings.PublicIP + ":" + My.Settings.PublicPort)
        End If

        ' done with bootup
        ProgressBar1.Value = 100

    End Sub

    Private Function CheckPort(ServerAddress As String, Port As Integer) As Boolean

        ' tried to probe MySQL port. If available, return true
        Dim ClientSocket As New TcpClient

        Try
            ClientSocket.Connect(ServerAddress, Port)
        Catch ex As Exception
            Log("Error:MySql port probe failed on port " + My.Settings.MySqlPort)
            Return False
        End Try

        If ClientSocket.Connected Then
            Return True
        End If
        CheckPort = False

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
            ProgressBar1.Value = 100
            KillAll()
            Buttons(StartButton)
            Print("Stopped")
            ProgressBar1.Value = 0
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
        MyShortcut = CType(WshShell.CreateShortcut(DesktopFolder & "\Outworldz.lnk"), IWshRuntimeLibrary.IWshShortcut)
        MyShortcut.TargetPath = sTargetPath
        MyShortcut.IconLocation = WshShell.ExpandEnvironmentStrings(MyFolder & "\Start.exe, 0 ")
        MyShortcut.WorkingDirectory = MyFolder
        MyShortcut.Save()

    End Sub

    Private Sub Print(Value As String)
        Log("Info:" + Value)
        TextBox1.Text = Value
        Application.DoEvents()
        Sleep(gChatTime)  ' time to read
    End Sub

    Private Sub mnuExit_Click(sender As System.Object, e As System.EventArgs) Handles mnuExit.Click
        Log("Info:Exiting")
        End
    End Sub

    Private Sub mnuLogin_Click(sender As System.Object, e As System.EventArgs) Handles mnuLogin.Click
        Print("You can use 'Help->Web Interface' to create a new avatar or change passwords.")
    End Sub

    Private Sub mnuAbout_Click(sender As System.Object, e As System.EventArgs) Handles mnuAbout.Click
        Print("(c) 2014 www.Outworldz.com")
        Dim webAddress As String = "http://www.outworldz.com/Outworldz_Installer"
        Process.Start(webAddress)
    End Sub

    Private Sub StopButton_Click_1(sender As System.Object, e As System.EventArgs) Handles StopButton.Click
        Print("Stopping")
        ProgressBar1.Value = 100
        Buttons(BusyButton)
        KillAll()
        Buttons(StartButton)
        Print("Stopped")
        ProgressBar1.Value = 0
    End Sub

    Private Sub ShowToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles mnuShow.Click
        Print("The Opensimulator Console will be shown when Opensim is running.")
        mnuShow.Checked = True
        mnuHide.Checked = False
        ConsoleTool.Visible = False
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

        ' fkb !! not yet functional 
        'ConsoleTool.Visible = True

        My.Settings.ConsoleShow = mnuShow.Checked
        My.Settings.Save()
        If Running Then
            Print("The Opensimulator Console will not be shown. Change will occur when Opensim is restarted")
        End If
    End Sub

    Private Sub mnuEasy_Click_1(sender As System.Object, e As System.EventArgs) Handles mnuEasy.Click
        mnuEasy.Checked = True
        mnuFull.Checked = False
        My.Settings.ViewerEase = True
        My.Settings.Save()
        Print("Onlook Viewer is set for Easy UI mode. Change will occur when the sim is restarted")
    End Sub

    Private Sub mnuFull_Click(sender As System.Object, e As System.EventArgs) Handles mnuFull.Click
        mnuEasy.Checked = False
        mnuFull.Checked = True
        My.Settings.ViewerEase = False
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
        Randomize()
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
        KillAll()
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
            Data(section)(key) = value ' replace it and save it
            Log("Info:Writing section '" + section + "' in file '" + filepath + "' in key '" + key + "' with value of '" + value + "'")
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
            System.IO.Directory.Delete(MyFolder & "\OutworldzFiles\" & AGrid & "\bin\addin-db-002", True)
        Catch ex As Exception
            Log("Info:addin-db-002 was empty")
        End Try
        Try
            System.IO.Directory.Delete(MyFolder & "\OutworldzFiles\" & AGrid & "\bin\assetcache", True)
        Catch ex As Exception
            Log("Info:Assetcache had nothing in it")
        End Try
        Try
            System.IO.Directory.Delete(MyFolder & "\OutworldzFiles\" & AGrid & "\bin\DataSnapshot", True)
        Catch ex As Exception
            Log("Info:Nothing in DataSnapshot")
        End Try

        Try
            System.IO.Directory.Delete(MyFolder & "\OutworldzFiles\" & AGrid & "\bin\ScriptEngines", True)
        Catch ex As Exception
            Log("Info:Empty scriptengines")
        End Try
        Try
            System.IO.Directory.Delete(MyFolder & "\OutworldzFiles\" & AGrid & "\bin\MapTiles", True)
        Catch ex As Exception
            Log("Info:No Maptiles to delete")
        End Try
        Try
            My.Computer.FileSystem.DeleteFile(MyFolder + "\OutworldzFiles" & AGrid & "\bin\Opensim.log")
        Catch ex As Exception
            Log("Info:Opensim.log is empty")
        End Try

        Try
            My.Computer.FileSystem.DeleteFile(MyFolder + "\OutworldzFiles\" & AGrid & "\bin\OpenSimConsoleHistory.txt")
        Catch ex As Exception
            Log("Info:Console history is empty")
        End Try
        Try
            My.Computer.FileSystem.DeleteFile(MyFolder + "\OutworldzFiles\Init.txt")
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
        Print("Outworldz will connect to OsGrid.org. You must log in with an Avatar name registered with OsGrid.org. You must also 'Port Forward' your router to this machine on port 8000 for Tcp and Udp traffic")
        Try
            My.Computer.FileSystem.CopyFile(MyFolder & "\Viewer\grids_sg_OsGrid.xml", xmlPath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml", True)
        Catch
            Log("Error:Cannot copy " + MyFolder & "\Viewer\grids_sg_OsGrid.xml to " + xmlPath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml")
        End Try
    End Sub

    Private Sub mnuHyperGrid_Click(sender As Object, e As EventArgs) Handles mnuHyperGrid.Click
        My.Settings.GridFolder = "HyperGrid"
        My.Settings.GridFolder = My.Settings.GridFolder
        My.Settings.Save()
        mnuOsGrid.Checked = False
        mnuHyperGrid.Checked = True

        Print("Outworldz will connect as a locally hosted hypergridded sim.")
        Log("Outworldz will connect as a locally hosted hypergridded sim.")
        My.Computer.FileSystem.CopyFile(MyFolder & "\Viewer\grids_sg_HyperGrid.xml", xmlPath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml", True)
    End Sub

    Private Sub SetINIFromSettings(iProgress As Integer)
        'mnuShow shows the DOS box for Opensimulator
        mnuShow.Checked = My.Settings.ConsoleShow
        mnuHide.Checked = Not My.Settings.ConsoleShow
        If My.Settings.ConsoleShow Then
            Log("Info:Console will be shown")
        Else
            Log("Info:Console will not be shown")
        End If

        ' Viewer UI shows the full viewer UI
        If My.Settings.ViewerEase Then
            Log("Info:Viewer set to Easy")
            SetIni(MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\Opensim.ini", "SpecialUIModule", "enabled", "false", ";")
        Else
            Log("Info:Viewer set to Normal")
            SetIni(MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\Opensim.ini", "SpecialUIModule", "enabled", "true", ";")
        End If



        mnuFull.Checked = Not My.Settings.ViewerEase
        mnuEasy.Checked = My.Settings.ViewerEase

        'Avatar visible?
        If My.Settings.AvatarShow Then
            Log("Info:Showing the avatar")
            SetIni(MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\Opensim.ini", "CameraOnlyModeModule", "enabled", "false", ";")
        Else
            Log("Info:Set to not show avatar")
            SetIni(MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\Opensim.ini", "CameraOnlyModeModule", "enabled", "true", ";")
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
            SetIni(MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\Opensim.ini", "AutoBackupModule", "AutoBackup", "true", ";")
        Else
            Log("Info:Autobackup is Off")
            SetIni(MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\Opensim.ini", "AutoBackupModule", "AutoBackup", "false", ";")
        End If

        SetIni(MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\Opensim.ini", "AutoBackupModule", "AutoBackupInterval", My.Settings.AutobackupInterval, ";")
        SetIni(MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\Opensim.ini", "AutoBackupModule", "AutoBackupKeepFilesForDays", My.Settings.KeepForDays, ";")

        ' RegionConfig
        SetIni(MyFolder + "\OutworldzFiles\" + My.Settings.GridFolder + "\bin\Regions\RegionConfig.ini", "Outworldz", "SizeY", My.Settings.SizeY, ";")
        SetIni(MyFolder + "\OutworldzFiles\" + My.Settings.GridFolder + "\bin\Regions\RegionConfig.ini", "Outworldz", "SizeX", My.Settings.SizeX, ";")



        Log("Info:Public IP is " + My.Settings.PublicIP)
        SetIni(MyFolder + "\OutworldzFiles\" + My.Settings.GridFolder + "\bin\Regions\RegionConfig.ini", "Outworldz", "ExternalHostName", My.Settings.PublicIP, ";")
        SetIni(MyFolder + "\OutworldzFiles\" + My.Settings.GridFolder + "\bin\Opensim.ini", "Const", "BaseURL", My.Settings.PublicIP, ";")

        Log("Info:Public Port is " + My.Settings.PublicPort)
        SetIni(MyFolder + "\OutworldzFiles\" + My.Settings.GridFolder + "\bin\Opensim.ini", "Const", "PublicPort", My.Settings.PublicPort, ";")
        SetIni(MyFolder + "\OutworldzFiles\" + My.Settings.GridFolder + "\bin\Regions\RegionConfig.ini", "Outworldz", "InternalPort", My.Settings.RegionPort, ";")

        Log("Info:Wifi Port is " + My.Settings.WifiPort)
        SetIni(MyFolder + "\OutworldzFiles\" + My.Settings.GridFolder + "\bin\Opensim.ini", "Const", "WifiPort", My.Settings.WifiPort, ";")

        Log("Info:Saving Wifi Admin for " + My.Settings.AdminFirst + " " + My.Settings.AdminLast)
        SetIni(MyFolder + "\OutworldzFiles\" + My.Settings.GridFolder + "\bin\config-include\MyWorld.ini", "WifiService", "AdminFirst", """" + My.Settings.AdminFirst + """", ";")
        SetIni(MyFolder + "\OutworldzFiles\" + My.Settings.GridFolder + "\bin\config-include\MyWorld.ini", "WifiService", "AdminLast", """" + My.Settings.AdminLast + """", ";")
        SetIni(MyFolder + "\OutworldzFiles\" + My.Settings.GridFolder + "\bin\config-include\MyWorld.ini", "WifiService", "AdminPassword", """" + My.Settings.Password + """", ";")
        SetIni(MyFolder + "\OutworldzFiles\" + My.Settings.GridFolder + "\bin\config-include\MyWorld.ini", "WifiService", "AdminPassword", """" + My.Settings.Password + """", ";")
        SetIni(MyFolder + "\OutworldzFiles\" + My.Settings.GridFolder + "\bin\config-include\MyWorld.ini", "Network", "ConsoleUser", """" + My.Settings.ConsoleUser + """", ";")
        SetIni(MyFolder + "\OutworldzFiles\" + My.Settings.GridFolder + "\bin\config-include\MyWorld.ini", "Network", "ConsolePass", """" + My.Settings.ConsolePass + """", ";")

        ProgressBar1.Value = iProgress
    End Sub
    Function CloseFirewall() As Boolean

        Dim MyUPnPMap As New UPNP

        Try
            If MyUPnPMap.Exists(My.Settings.PublicPort, UPNP.Protocol.UDP) Then
                MyUPnPMap.Remove(UPNP.LocalIP, My.Settings.PublicPort)
                DiagLog("uPnp:PublicPort.UDP Removed ")
            End If

            If MyUPnPMap.Exists(My.Settings.PublicPort, UPNP.Protocol.TCP) Then
                MyUPnPMap.Remove(UPNP.LocalIP, My.Settings.PublicPort)
                DiagLog("uPnp:PublicPort.TCP Removed ")
            End If

            If MyUPnPMap.Exists(My.Settings.WifiPort, UPNP.Protocol.TCP) Then
                MyUPnPMap.Remove(UPNP.LocalIP, My.Settings.WifiPort)
                DiagLog("uPnp:LoopBack.TCP Removed ")
            End If

            If MyUPnPMap.Exists(My.Settings.LoopBack, UPNP.Protocol.TCP) Then
                MyUPnPMap.Remove(UPNP.LocalIP, My.Settings.LoopBack)
                DiagLog("uPnp:LoopBack.TCP Removed ")
            End If

            If MyUPnPMap.Exists(My.Settings.RegionPort, UPNP.Protocol.TCP) Then
                MyUPnPMap.Remove(UPNP.LocalIP, My.Settings.RegionPort)
                DiagLog("uPnp:LoopBack.TCP Removed ")
            End If

        Catch e As Exception
            Log("uPnp:UPnP Exception caught: " + e.Message)
            Return False
        End Try
        Return True 'successfully added
    End Function
    Function AllowFirewall() As Boolean
        Log("uPnp:probing")
        Dim MyUPnPMap As New UPNP

        Try
            If MyUPnPMap.Exists(My.Settings.PublicPort, UPNP.Protocol.UDP) Then
                DiagLog("uPnp:PublicPort.UDP exists")
            Else
                MyUPnPMap.Add(UPNP.LocalIP, My.Settings.PublicPort, UPNP.Protocol.UDP, "Opensim UDP Public")
                DiagLog("uPnp:PublicPort.UDP added")
            End If

            If MyUPnPMap.Exists(My.Settings.PublicPort, UPNP.Protocol.TCP) Then
                DiagLog("uPnp:PublicPort.TCP exists")
            Else
                MyUPnPMap.Add(UPNP.LocalIP, My.Settings.PublicPort, UPNP.Protocol.TCP, "Opensim TCP Public")
                DiagLog("uPnp:PublicPort.TCP added")
            End If

            If MyUPnPMap.Exists(My.Settings.WifiPort, UPNP.Protocol.TCP) Then
                DiagLog("uPnp:WifiPort.TCP exists")
            Else
                MyUPnPMap.Add(UPNP.LocalIP, My.Settings.WifiPort, UPNP.Protocol.TCP, "Opensim TCP Wifi")
                DiagLog("uPnp:PublicPort.TCP added")
            End If

            If MyUPnPMap.Exists(My.Settings.LoopBack, UPNP.Protocol.TCP) Then
                DiagLog("uPnp:LoopBack.TCP exists")
            Else
                MyUPnPMap.Add(UPNP.LocalIP, My.Settings.LoopBack, UPNP.Protocol.TCP, "Opensim TCP Region")
                DiagLog("uPnp:LoopBack.TCP Added ")
            End If

            If MyUPnPMap.Exists(My.Settings.RegionPort, UPNP.Protocol.TCP) Then
                DiagLog("uPnp:Regionport.TCP exists")
            Else
                Log("uPnp:LoopBack.TCP Added ")
                MyUPnPMap.Add(UPNP.LocalIP, My.Settings.RegionPort, UPNP.Protocol.TCP, "Opensim UDP Region")
            End If

            If MyUPnPMap.Exists(My.Settings.RegionPort, UPNP.Protocol.UDP) Then
                DiagLog("uPnp:Regionport.UDP exists")
            Else
                MyUPnPMap.Add(UPNP.LocalIP, My.Settings.RegionPort, UPNP.Protocol.UDP, "Opensim Region")
                DiagLog("uPnp:LoopBack.UDP Added ")
            End If

        Catch e As Exception
            DiagLog("uPnp:UPnP Exception caught: " + e.Message)
            Return False
        End Try
        Return True 'successfully added
    End Function

    Private Function OpenPorts(progress As Integer)
        Print("The human is instructed to wait while I check out this cute router I see ...")
        Try
            If AllowFirewall() Then ' open uPNP port
                DiagLog("uPnp:Ok")
                ProgressBar1.Value = progress
                Print("Okay! looking good ...")
                Return True
            Else
                DiagLog("uPnP:fail")
                ProgressBar1.Value = progress
                Print("UPnP Port forwarding is not enabled.  Ports can be manually opened in the router to compensate.")
                Return False
            End If
        Catch e As Exception
            DiagLog("Error:uPnP Exception:" + e.Message)
            ProgressBar1.Value = progress
            Print("Router is blocking a port so hypergrid may not be available")
            Return False
        End Try
        ProgressBar1.Value = progress
    End Function

    Private Sub BusyButton_Click(sender As Object, e As EventArgs) Handles BusyButton.Click

        Print("Stopping")
        Application.DoEvents()
        KillAll()
        Buttons(StartButton)
        Print("Opensim is Stopped")
        Log("Info:Stopped")
    End Sub

    Private Function xmlPath() As String
        ' gets the path to the %APPDATA% folder on windows so we can seek out the Onlook folders
        Dim appData As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData
        Return Mid(appData, 1, InStr(appData, "AppData") - 1)
    End Function

    Private Sub AdminUIToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AdminUIToolStripMenuItem1.Click
        If (Running) Then
            Dim webAddress As String = "http://127.0.0.1:" + My.Settings.PublicPort
            Process.Start(webAddress)
            Print("Log in as '" + My.Settings.AdminFirst + " " + My.Settings.AdminLast + "' with a password of '" + My.Settings.Password + "'to add user accounts.")
        Else
            Print("Opensim is not running. Cannot open the Web Interface.")
        End If
    End Sub
    Private Sub SimContent(thing As String, type As String)

        ' remove the console startup file
        ContentLoading = False
        ClearOar()

        Try
            If type = "oar" Then
                Using outputFile As New StreamWriter(MyFolder & "\OutworldzFiles\" + My.Settings.GridFolder & "\bin\startup_commands.txt", True)
                    outputFile.WriteLine("alert New content is loading")
                    outputFile.WriteLine("load " + type + "  " + Chr(34) + thing + Chr(34))
                    outputFile.WriteLine("alert New content is loaded")
                    ContentLoading = True
                End Using
            End If
        Catch
            Log("Error:iar or oar file write failure")
        End Try
    End Sub
    Private Sub IARContent(user As String, password As String, thing As String)
        ' remove the console startup file

        ContentLoading = False
        ClearOar()

        Try
            Using outputFile As New StreamWriter(MyFolder & "\OutworldzFiles\" + My.Settings.GridFolder & "\bin\startup_commands.txt", True)
                outputFile.WriteLine("load iar --merge " + user + " / " + password + " " + Chr(34) + thing + Chr(34))
                outputFile.WriteLine("alert IAR content is loaded")
                ContentLoading = True
            End Using
        Catch
            Log("Error:iar or oar file write failure")
        End Try
    End Sub

    Private Sub KillAll()
        ClearOar()
        pOpensim.Close()
        Sleep(3000)
        zap("OpenSim")
        pOnlook.Close()

        Application.DoEvents()
        Running = False
    End Sub

    Private Sub TextBox1_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles TextBox1.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each pathname In files
            pathname.Replace("\", "/")
            Dim extension = Path.GetExtension(pathname)
            extension = Mid(extension, 2, 5)
            If extension.ToLower = "iar" Then
                Dim user = InputBox("User name that wil get this IAR?")
                Dim password = InputBox("Password for user " + user)
                If user.Length And password.Length Then
                    IARContent(user, password, pathname)
                    Log("Info:Load iar " + pathname)
                    Print("Opensim will load your file when it is restarted. This may take time to load. You will find it in your inventory.")
                End If
            ElseIf extension.ToLower = "oar" Then
                SimContent(pathname, extension)
                Log("Info:Load oar " + pathname)
                Print("Opensim will load your file when it is restarted. This may take time to load.")
            ElseIf extension.ToLower = ".gz" Then
                Log("Info:Load oar " + pathname)
                SimContent(pathname, extension)
                Log("Info:Load gz " + pathname)
                Print("Opensim will load your file when it is restarted. This may take time to load.")
            ElseIf extension.ToLower = ".tgz" Then
                Log("Info:Load oar " + pathname)
                SimContent(pathname, extension)
                Log("Info:Load tgz " + pathname)
                Print("Opensim will load your file when it is restarted. This may take time to load.")
            Else
                Log("Info:Unrecognized file type:" + extension)
                Print("Unrecognized file type:" + extension + ".  Drag and drop any OAR,GZ,TGZ, or IAR files to load them when the sim starts")
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

    Private Sub LoopBackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoopBackToolStripMenuItem.Click
        Dim webAddress As String = "http://www.outworldz.com/Outworldz_Installer/Loopback.htm"
        Process.Start(webAddress)
    End Sub

    Private Sub MoreContentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoreContentToolStripMenuItem.Click
        Dim webAddress As String = "http://www.outworldz.com/cgi/freesculpts.plx"
        Process.Start(webAddress)
        Print(" Drag and drop OAR or IAR files here to load them whenever the sim starts")
    End Sub
    Private Sub ExitAll()

        ws.StopWebServer()

        Log("Info:using mysqladmin tio close db")
        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = "-u root shutdown"
        pi.FileName = MyFolder + "\OutworldzFiles\mysql\bin\mysqladmin.exe"
        pi.WindowStyle = ProcessWindowStyle.Minimized
        p.StartInfo = pi
        Try
            p.Start()
        Catch
            Log("Error:mysqladmin failed to stop opensim")
        End Try

        CloseFirewall()

        Try
            RemoveGrid()    ' puts Onlook back to default
        Catch
            Log("Info:grid settings set back to defaults")
        End Try

        ' Needed to stop Opensim
        KillAll()
    End Sub
    Private Sub LogFiles(progress As Integer)
        ' clear out the log files
        Try
            My.Computer.FileSystem.DeleteFile(MyFolder + "\OutworldzFiles" & My.Settings.GridFolder & "\bin\Opensim.log")
        Catch ex As Exception
            Log("Info:Opensim Log file did not exist")
        End Try

        Try
            My.Computer.FileSystem.DeleteFile(MyFolder + "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\OpenSimConsoleHistory.txt")
        Catch ex As Exception
            Log("Info:Console history was not empty")
        End Try
        ProgressBar1.Value = progress
    End Sub

    Private Sub StartMySql(progress As Integer)
        ' Start MySql in background.  

        Dim StartValue = ProgressBar1.Value

        Print("Starting Database")

        SetIni(MyFolder & "\OutworldzFiles\mysql\my.ini", "mysqld", "basedir", """" + gCurSlashDir + "/OutworldzFiles/Mysql" + """", "#")
        SetIni(MyFolder & "\OutworldzFiles\mysql\My.ini", "mysqld", "datadir", """" + gCurSlashDir + "/OutworldzFiles/Mysql/Data" + """", "#")
        SetIni(MyFolder & "\OutworldzFiles\mysql\My.ini", "client", "port", My.Settings.MySqlPort, "#")

        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = "--defaults-file=" + gCurSlashDir + "/OutworldzFiles/mysql/my.ini"
        pi.WindowStyle = ProcessWindowStyle.Hidden
        pi.FileName = MyFolder & "\OutworldzFiles\mysql\bin\mysqld-nt.exe"
        pMySql.StartInfo = pi
        pMySql.Start()

        ProgressBar1.Value = progress / 2

        ' Check for MySql operation
        Dim Mysql = False
        ' wait for MySql to come up 
        Mysql = CheckPort("127.0.0.1", My.Settings.MySqlPort) ' !!!
        While Not Mysql
            ProgressBar1.Value = ProgressBar1.Value + 1
            Application.DoEvents()

            Dim MysqlLog As String = MyFolder + "\OutworldzFiles\mysql\data"
            If ProgressBar1.Value > StartValue + 10 Then ' about 30 seconds when it fails
                Dim yesno = MsgBox("The database did not start. Do you want to see the log file?", vbYesNo)
                If (yesno = vbYes) Then
                    Dim files() As String
                    files = Directory.GetFiles(MysqlLog, "*.err", SearchOption.TopDirectoryOnly)
                    For Each FileName As String In files
                        System.Diagnostics.Process.Start("wordpad.exe", FileName)
                    Next
                End If

                KillAll()
                Buttons(StartButton)
                Return
            End If

            ' check again
            Sleep(1000)
            Mysql = CheckPort("127.0.0.1", My.Settings.MySqlPort)
        End While
        ProgressBar1.Value = progress

    End Sub
    Private Sub GetPubIP(iProgress As Integer)

        ' Set Public Port
        Try
            My.Settings.PublicIP = client.DownloadString("https://api.ipify.org/?r=" + Random())
            Log("Public IP=" + My.Settings.PublicIP)
        Catch ex As Exception
            Print("Cannot reach the Internet? Proceeding locally")
            My.Settings.PublicIP = "127.0.0.1"
        End Try
        ProgressBar1.Value = iProgress

    End Sub
    Private Sub Loopback(progress As Integer)

        'Print("Opensim needs to be able to loop back to itself. ")
        If CheckPort(My.Settings.PublicIP, My.Settings.LoopBack) Then
            Print("Yay it works!  The Hypergrid is whispering in my ear. Let's go!")
        Else
            Application.DoEvents()
            DiagFailed = True
            Print("Hypergrid travel requires a router with 'loopback'. It seems to be missing from yours. See the Help section for 'Loopback' and how to enable it in Windows. Opensim can still continue, but without Hypergrid.")
            MsgBox("See Info on screen about Loopback. Opensim can still continue, but without Hypergrid", vbExclamation)
            My.Settings.PublicIP = "127.0.0.1" ' dang it, we cannot go to the hypergird
        End If
        ProgressBar1.Value = progress

    End Sub

    Private Sub Start_Opensimulator(iProgress As Integer)

        Print("Starting Opensimulator")
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.WorkingDirectory = MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\"

        If ContentLoading Then
            Log("Info:Opensim console is forced visible")
            pi.Arguments = ""
            pi.WindowStyle = ProcessWindowStyle.Normal
            Print("Please wait for the console to show 'LOGINS ENABLED'. It will take a while to load. ")
        ElseIf mnuHide.Checked Then
            Log("Info:Opensim console is hidden")
            pi.Arguments = "-console rest -background True "
            pi.WindowStyle = ProcessWindowStyle.Hidden
        Else
            Log("Info:Opensim console is visible")
            pi.Arguments = ""
            pi.WindowStyle = ProcessWindowStyle.Normal
        End If

        pi.FileName = MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\OpenSim.exe"
        pOpensim.StartInfo = pi

        Try
            pOpensim.Start()
        Catch
            Dim yesno = MsgBox("Opensim did not start. Do you want to see the log file?", vbYesNo)
            If (yesno = vbYes) Then
                Dim Log As String = MyFolder + "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\OpenSim.log"
                System.Diagnostics.Process.Start("wordpad.exe", Log)
            End If
            KillAll()
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
                KillAll()
                Buttons(StartButton)
                Dim yesno = MsgBox("Opensim did not start. Do you want to see the log file?", vbYesNo)
                If (yesno = vbYes) Then
                    Dim Log As String = MyFolder + "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\OpenSim.log"
                    System.Diagnostics.Process.Start("wordpad.exe", Log)
                End If
                Buttons(StartButton)
                Return
            End If
            Application.DoEvents()
            Sleep(4000)

            Try
                Up = client.DownloadString("http://127.0.0.1:" + My.Settings.PublicPort + "/?r=" + Random())
            Catch ex As Exception
                Up = ""
            End Try
        End While
        ProgressBar1.Value = iProgress

    End Sub

    Private Sub Onlook(progess As Integer)
        If My.Settings.Onlook Then
            Print("Starting Onlook viewer")
            Dim pi As ProcessStartInfo = New ProcessStartInfo()
            pi.Arguments = ""
            pi.FileName = "C: \Program Files (x86)\Onlook\OnLookViewer.exe"
            pi.WindowStyle = ProcessWindowStyle.Normal
            pOnlook.StartInfo = pi
            Try
                pOnlook.Start()
            Catch
                Log("Error:Onlook failed to launch")
            End Try
        End If
        ProgressBar1.Value = 95
    End Sub

    Private Sub AdvancedSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdvancedSettingsToolStripMenuItem.Click
        ActualForm = New AdvancedForm ' Bring the form into memory 
        ' Set the new form's desktop location so it appears below and 
        ' to the right of the current form.
        ActualForm.SetDesktopLocation(300, 200)
        ActualForm.Activate()
        ActualForm.Visible = True
    End Sub

    Private Sub ConsoleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsoleTool.Click
        ActualForm = New ConsoleForm ' Bring the form into memory 
        ' Set the new form's desktop location so it appears below and 
        ' to the right of the current form.
        ConsoleForm.SetDesktopLocation(200, 200)
        ConsoleForm.Activate()
        ConsoleForm.Visible = True
    End Sub

    Private Sub InstallGridXML(iProgress As Integer)

        ' we have to change the viewer Grid settings if we are on localhost
        Print("Setting Grid Info...")
        Try
            My.Computer.FileSystem.CopyFile(xmlPath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml", xmlPath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml.xml.bak", True)
        Catch
            Log("Error:Failed to back up onlook XML")
        End Try

        Try
            My.Computer.FileSystem.CopyFile(MyFolder & "\Viewer\Hypergrid.xml", xmlPath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml", True)
        Catch ex As Exception
            Log("Error:Failed to install onlook XML")
        End Try
        ProgressBar1.Value = iProgress

    End Sub

    Private Sub RemoveGrid()
        ' restore backup - they may have changed it. Outworldzs is supposed to be simple. If they launch the viewer by itself, they can change grids
        Try
            My.Computer.FileSystem.CopyFile(xmlPath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml.bak", xmlPath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml", True)
        Catch
            Log("Error:failed to restore Onlook xml backup")
        End Try

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim webAddress As String = "http://www.outworldz.com/Outworldz_Installer/PortForwarding.htm"
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
        Try
            Using outputFile As New StreamWriter(MyFolder & "\OutworldzFiles\Outworldz.log", True)
                outputFile.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + message)
            End Using
        Catch
        End Try
        Return True

    End Function

    Public Function DiagLog(message As String)
        Try
            Using outputFile As New StreamWriter(MyFolder & "\OutworldzFiles\Diagnostics.log", True)
                outputFile.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + message)
            End Using
        Catch
        End Try
        Return True

    End Function

    Private Sub SetIAROARContent(iProgress As String)

        IslandToolStripMenuItem.Visible = False
        ClothingInventoryToolStripMenuItem.Visible = False

        Print("Dreaming up new content for your sim")
        Dim oars As String = ""
        Try
            oars = client.DownloadString("http://www.outworldz.com/Outworldz_Installer/Content.plx?type=OAR&r=" + Random())
        Catch ex As Exception
            Log("No Oars, dang")
        End Try

        Dim oarreader = New System.IO.StringReader(oars)
        Dim line As String = ""
        Dim ContentAvailable As Boolean = True
        While ContentAvailable
            line = oarreader.ReadLine()
            If line <> Nothing Then
                Log(line)
                Dim OarMenu As New ToolStripMenuItem
                OarMenu.Text = line
                OarMenu.ToolTipText = "CLick to load this content the next time the simulator is started"
                OarMenu.DisplayStyle = ToolStripItemDisplayStyle.Text
                AddHandler OarMenu.Click, New EventHandler(AddressOf OarCick)
                IslandToolStripMenuItem.Visible = True
                IslandToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {OarMenu})
            Else
                ContentAvailable = False
            End If
        End While


        Print("Dreaming up some clothes and items for your avatar")
        Dim iars As String = ""
        Try
            iars = client.DownloadString("http://www.outworldz.com/Outworldz_Installer/Content.plx?type=IAR&r=" + Random())
        Catch ex As Exception
            Log("No IARS, dang")
        End Try

        Dim iarreader = New System.IO.StringReader(iars)
        ContentAvailable = True
        While ContentAvailable
            line = iarreader.ReadLine()
            If line <> Nothing Then
                Log(line)
                Dim IarMenu As New ToolStripMenuItem
                IarMenu.Text = line
                IarMenu.ToolTipText = "CLick to load this content the next time the simulator is started"
                IarMenu.DisplayStyle = ToolStripItemDisplayStyle.Text
                AddHandler IarMenu.Click, New EventHandler(AddressOf IarClick)
                ClothingInventoryToolStripMenuItem.Visible = True
                ClothingInventoryToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {IarMenu})
            Else
                ContentAvailable = False
            End If
        End While

        ProgressBar1.Value = iProgress
    End Sub

    Private Sub OarCick(sender As Object, e As EventArgs)
        Dim file = Mid(sender.text, 1, InStr(sender.text, "|") - 2)
        file = "http://www.Outworldz.com/Outworldz_Installer/OAR/" + file 'make a real URL
        SimContent(file, "oar")
        sender.checked = True
        Print("Opensimulator will load " + file + " when restarted.  This may take time to load.")
    End Sub
    Private Sub IarClick(sender As Object, e As EventArgs)
        Dim file = Mid(sender.text, 1, InStr(sender.text, "|") - 2)
        file = "http://www.Outworldz.com/Outworldz_Installer/IAR/" + file 'make a real URL
        SimContent(file, "iar")
        sender.checked = True
        Print("Opensimulator will load " + file + " when restarted.  This may take time to load.")
    End Sub

    Private Sub SaySomething()

        Dim Prefix() As String = {
                                  "Mmmm?  Yawns ...",
                                  "Yawns, and stretches ...",
                                  "Wakes up and rolls over ...",
                                  "You look more beautiful every time I wake up.",
                                  "Zzzz... !!! Ooooh, I need coffee before I go to work.",
                                  "Nooo  is it already time to wake up?",
                                  "Mmmm, I was sleeping...",
                                  "What a dream that was!",
                                  "Do you ever dream of better worlds? I just did.",
                                  ""
                                }

        Dim Array() As String = {"I dreamt I ate a giant marshmallow. Hey! Where's my pillow??",
                                  "I dreamt we were both flying a dragon in the Outworldz. You flamed me. I tried to get even. I lost. ",
                                 "I dreamt we were chatting at OsGrid.org. It's the largest hypergrid-enabled virtual world.",
                                 "I dreamt some friends and you were riding a rollercoaster in the Great Canadian Grid.",
                                 "I dreamt I was watching a pretty particle exhibit with you on the Metropolis grid.",
                                 "I dreamt we were discussing politics in German, Dutch, and French using a free translator.",
                                 "I dreamt you took the hypergrid safari to visit the mountains of Africa in the Virunga sim.",
                                 "I dreamt you won a race while riding a silly cow at the Outworldz 'Frankie' sim.",
                                 "I dreamt you are wonderful singer. I loved to hear your voice singing into the voice-chat system.",
                                 "The spaceport at Gravity sim in OsGrid was really hopping. And floating. And then I fell. ",
                                 "I was dreaming that you were a mermaid in the Lost Worlds.",
                                 "I deamt that you made a pile of prims that you simply will not believe!",
                                 "I was asked when I was going to straighten out the castle. You said, 'Why? Is it tilted?'",
                                 "I dreamt you made a 'mesh' of it.",
                                 "I dreamt I saw a man without a shirt attached to a eagle flying up in the air. Always rez before you attach!",
                                 "I forgot the dream already. I remember I woke up in it.",
                                 "I was thinking I had no clothes on.  No shirt, shoes, or hair.  The worst part was there was no facelight! I looked hideous!",
                                 "I dreamt that I was floating in a river and a scripted mesh crocodile chased me.",
                                 "I dreamt I drove our car into the ocean. You found a pose ball, and we both grabbed onto it.",
                                 "There was a animated mesh zebra in my bathtub!",
                                 "I had dreamed a fairy was my best friend.",
                                 "I dreamed that there were non players characters attacking my house, so I decided to fly away. ",
                                 "I had a dream that there were pimples all over my face.  So I switched skins and looked perfect!",
                                 "I had a dream where I had lost my free snow boots, so I was asking everybody where I got them on the hypergrid.",
                                 "I had a dream that i was sitting on my roof with my crush and we stood up and both fell off. But I hit Pg Up and flew away.",
                                 ""
                                }
        Randomize()

        Dim value1 As Integer = CInt(Int((Prefix.Length - 1) * Rnd()))
        Dim value2 As Integer = CInt(Int((Array.Length - 1) * Rnd()))
        Dim whattosay = Prefix(value1) + vbCrLf + vbCrLf + Array(value2) + " ... and then I woke up."
        Print(whattosay)

    End Sub

    Private Sub ProbePublicPort(iProgress As Integer)

        Log("Info:Starting Diagnostic server")

        Dim isPortOpen As String = ""
        Try
            isPortOpen = client.DownloadString("http://www.outworldz.com/Outworldz_Installer/probe.plx?Port=" + My.Settings.LoopBack + "&r=" + Random())
        Catch ex As Exception
            DiagLog("Dang:The Outworldz web site cannot find a path back")
            DiagFailed = True
        End Try

        If isPortOpen <> "yes" Then
            DiagLog(isPortOpen)
            DiagLog("Warn:Port " + My.Settings.PublicPort + " is not open")
            DiagFailed = True
            Print("Port " + My.Settings.PublicPort + " is not open, so Hypergrid is not available :-(   Opensimulator is set for standalone ops. This can possibly be fixed by 'Port Forwards' in your router in the Help menu")
        Else
            Print("Hypergrid seems to be possible.  One more check..")
        End If
        ProgressBar1.Value = iProgress

    End Sub

    Private Sub DiagnosticsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DiagnosticsToolStripMenuItem.Click

        DiagFailed = False
        ProgressBar1.Value = 0
        OpenPorts(25) ' Open router ports
        Sleep(1)
        ProbePublicPort(50)
        Sleep(1)
        Loopback(100)    ' test the loopback on the router. If it fails, use localhost, no Hg
        If DiagFailed = True Then
            Print("Network tests failed")
        Else
            Print("Tests passed")
        End If
    End Sub

    Private Function PostURL(URL As String, postdata As String)
        Dim s As HttpWebRequest
        Dim enc As UTF8Encoding
        Dim postdatabytes As Byte()

        s = HttpWebRequest.Create(URL)
        enc = New System.Text.UTF8Encoding()
        postdatabytes = enc.GetBytes(postdata)
        s.Method = "POST"
        s.ContentType = "application/x-www-form-urlencoded"
        s.ContentLength = postdatabytes.Length

        Using stream = s.GetRequestStream()
            stream.Write(postdatabytes, 0, postdatabytes.Length)
        End Using
        Return s.GetResponse()
    End Function

    Sub Sleep(value As Integer)
        Thread.Sleep(value)
    End Sub

    Sub ClearOar()
        If Not ContentLoading Then
            ' remove the console startup file
            Try
                My.Computer.FileSystem.DeleteFile(MyFolder & "\OutworldzFiles\" + My.Settings.GridFolder & "\bin\startup_commands.txt")
            Catch ex As Exception
                Log("Info:no Opensim startup commands located")
            End Try
        End If

    End Sub
    Private Sub CHeckForUpdatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CHeckForUpdatesToolStripMenuItem.Click

        CheckForUpdates(True) 'be chatty = true

    End Sub
    Private Sub UpdaterCancel_Click(sender As Object, e As EventArgs) Handles UpdaterCancel.Click
        UpdaterGo.Visible = False
        UpdaterCancel.Visible = False
    End Sub

    Private Sub UpdaterGo_Click(sender As Object, e As EventArgs) Handles UpdaterGo.Click

        UpdaterGo.Enabled = False
        UpdaterCancel.Visible = False
        Dim fileloaded As String = Download()
        If (fileloaded.length) Then
            Dim pUpdate As Process = New Process()
            Dim pi As ProcessStartInfo = New ProcessStartInfo()
            pi.Arguments = ""
            pi.FileName = MyFolder + "\" + fileloaded
            pUpdate.StartInfo = pi
            Try
                Print("I'll see you again when I wake up all fresh and new!")
                Log("Info:Launch Updater and exiting")
                pUpdate.Start()
            Catch ex As Exception
                Print("Error: Could not launch " + fileloaded + ". Perhaps you can can exit this program and launch it manually.")
                Log("Error: installer failed to launch:" + ex.Message)
            End Try
            End ' quit program
        Else
            Print("Uh Oh!  The files I need could not be found online. The gnomes have absconded with them!   Please check again, some other time.")
            UpdaterGo.Visible = False
            UpdaterGo.Enabled = True
        End If

    End Sub
    Private Function Download()

        Dim fileName As String = "Updater.exe"

        Try
            My.Computer.FileSystem.DeleteFile(MyFolder + fileName)
        Catch
            Log("Warn:Could not delete " + fileName)
        End Try

        Try
            fileName = client.DownloadString(remoteUri + "GetUpdater.plx?r=" + Random())
        Catch
            Return ""
        End Try

        Try
            Dim myWebClient As New WebClient()
            Print("Downloading new updater, this will take a moment")
            ' The DownloadFile() method downloads the Web resource and saves it into the current file-system folder.
            myWebClient.DownloadFile(remoteUri + fileName, fileName)
        Catch e As Exception
            Log("Warn:" + e.Message)
            Return ""
        End Try
        Return fileName

    End Function

    Sub CheckForUpdates(chatty As Boolean)

        Dim Update As String = ""
        Try
            Update = client.DownloadString(remoteUri + "/Update.plx?Ver=" + Str(MyVersion) + "&r=" + Random())
        Catch ex As Exception
            Log("Dang:The Outworld web site is down")
        End Try
        If (Update = "") Then Update = "0"
        If CSng(Update) > MyVersion Then
            Print("I am Outworldz version " + Str(MyVersion) + vbCrLf + "A dreamier version " + Update + " is available.")
            UpdaterGo.Visible = True
            UpdaterGo.Enabled = True
            UpdaterCancel.Visible = True
        Else
            If chatty Then
                Print("I am the dreamiest version available.")
            End If
        End If

    End Sub
#End Region

End Class

