
#Region "Copyright"
' Copyright 2014 Fred Beckhusen for Outworldz.com
' https://opensource.org/licenses/MIT 
'Permission Is hereby granted, free Of charge, to any person obtaining a copy of this software 
' And associated documentation files (the "Software"), to deal in the Software without restriction, 
'including without limitation the rights To use, copy, modify, merge, publish, distribute, sublicense,
'And/Or sell copies Of the Software, And To permit persons To whom the Software Is furnished To 
'Do so, subject To the following conditions:

'The above copyright notice And this permission notice shall be included In all copies Or '
'substantial portions Of the Software.

'THE SOFTWARE Is PROVIDED "AS IS", WITHOUT WARRANTY Of ANY KIND, EXPRESS Or IMPLIED, 
' INCLUDING BUT Not LIMITED To THE WARRANTIES Of MERCHANTABILITY, FITNESS For A PARTICULAR 
'PURPOSE And NONINFRINGEMENT.In NO Event SHALL THE AUTHORS Or COPYRIGHT HOLDERS BE LIABLE 
'For ANY CLAIM, DAMAGES Or OTHER LIABILITY, WHETHER In AN ACTION Of CONTRACT, TORT Or 
'OTHERWISE, ARISING FROM, OUT Of Or In CONNECTION With THE SOFTWARE Or THE USE Or OTHER 
'DEALINGS IN THE SOFTWARE.Imports System

#End Region

Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Net.Sockets
Imports IWshRuntimeLibrary
Imports IniParser
Imports System.Threading
Imports Ionic.Zip
Imports System.Timers

Public Class Form1

    ' Command line args:
    '
    '     '-debug' forces this to use the DebugPath folder for testing
    '

#Region "Declarations"

    Dim MyVersion As String = "1.61"
    Dim DebugPath As String = "C:\Opensim\Outworldz Test" ' Note that this uses spaces
    Public Domain As String = "http://www.outworldz.com"
    Dim RevNotesFile As String = "Update_Notes_" + MyVersion + ".rtf"
    Private gFailDebug1 = False ' set to true to fail diagnostic
    Private gFailDebug2 = False ' set to true to fail diagnostic
    Private gFailDebug3 = False ' set to true to fail diagnostic

    Public MyFolder As String   ' Holds the current folder that we are running in
    Dim gCurSlashDir As String '  holds the current directory info in Unix format
    Public isRunning As Boolean = False
    Dim Arnd = New Random()
    Public gChatTime As Integer
    Dim client As New System.Net.WebClient

    ' Processes
    Dim pMySqlDiag As Process = New Process()
    Dim pOnlook As Process = New Process()
    Public Shared ActualForm As AdvancedForm

    ' with events
    Private pMySql As Process = New Process()
    Public Event Exited As EventHandler

    Dim Data As IniParser.Model.IniData
    Private randomnum As New Random
    Dim parser As FileIniDataParser
    Dim gINI As String  ' the name of the current INI file we are writing
    Dim OpensimProcID As Integer
    Private images =
    New List(Of Image) From {My.Resources.tangled, My.Resources.wp_habitat, My.Resources.wp_Mooferd,
                             My.Resources.wp_To_Piers_Anthony,
                             My.Resources.wp_wavy_love_of_animals, My.Resources.wp_zebra,
                             My.Resources.wp_Que, My.Resources.wp_1, My.Resources.wp_2,
                             My.Resources.wp_3, My.Resources.wp_4, My.Resources.wp_5,
                             My.Resources.wp_6, My.Resources.wp_7, My.Resources.wp_8,
                             My.Resources.wp_9, My.Resources.wp_10, My.Resources.wp_11,
                             My.Resources.wp_12, My.Resources.wp_13, My.Resources.wp_14,
                             My.Resources.wp_15, My.Resources.wp_16, My.Resources.wp_17,
                             My.Resources.wp_18, My.Resources.wp_19, My.Resources.wp_20,
                             My.Resources.wp_21, My.Resources.wp_22, My.Resources.wp_23,
                             My.Resources.wp_24, My.Resources.wp_25, My.Resources.wp_26,
                             My.Resources.wp_27, My.Resources.wp_28, My.Resources.wp_29,
                             My.Resources.wp_30, My.Resources.wp_31, My.Resources.wp_32,
                             My.Resources.wp_33, My.Resources.wp_34, My.Resources.wp_35,
                             My.Resources.wp_36, My.Resources.wp_37, My.Resources.wp_38,
                             My.Resources.wp_39, My.Resources.wp_40, My.Resources.wp_41,
                             My.Resources.wp_42, My.Resources.wp_43, My.Resources.wp_44,
                             My.Resources.wp_45, My.Resources.wp_46, My.Resources.wp_47,
                             My.Resources.wp_48, My.Resources.wp_49, My.Resources.wp_50,
                             My.Resources.wp_51, My.Resources.wp_52, My.Resources.wp_53,
                             My.Resources.wp_54, My.Resources.wp_55, My.Resources.wp_56,
                             My.Resources.wp_57
                            }
    Dim gDebug = False       ' toggled by -debug flag on command line
    Dim gContentAvailable As Boolean = False ' assume there is no OAR and IAR data available
    Dim MyUPnPMap

    Public aRegion(0) As Object

    Private Class Region_data
        Public RegionName As String
        Public UUID As String
        Public CoordX As Integer
        Public CoordY As String
        Public RegionPort As Integer
        Public SizeX As Integer
        Public SizeY As Integer
    End Class


#End Region

#Region "Properties"

    Public Property Splashpage() As String
        Get
            Return My.Settings.SplashPage
        End Get
        Set(ByVal Value As String)
            My.Settings.SplashPage = Value
            My.Settings.Save()
        End Set
    End Property

    ' Save a random machine ID - we don't want any data to be sent that's personal or identifiable,  but it needs to be unique
    Public Property Machine() As String
        Get
            Return My.Settings.MachineID
        End Get
        Set(ByVal Value As String)
            If (My.Settings.MachineID = "") Then
                My.Settings.MachineID = Value
                My.Settings.Save()
            End If
        End Set
    End Property

    Public Property Running() As Boolean
        Get
            Return isRunning
        End Get
        Set(ByVal Value As Boolean)
            isRunning = Value
        End Set
    End Property



#End Region

#Region "StartStop"

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'hide progress
        ProgressBar1.Visible = True
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = 100
        ProgressBar1.Value = 0

        LogButton.Hide()
        IgnoreButton.Hide()

        If My.Settings.MyX = 0 And My.Settings.MyY = 0 Then
            Me.CenterToScreen()
        Else
            Me.Location = New Point(My.Settings.MyX, My.Settings.MyY)
        End If

        Buttons(BusyButton)
        ' Save a random machine ID - we don't want any data to be sent that's personal or identifiable,  but it needs to be unique
        Randomize()
        Machine() = Random()

        ' hide updater
        UpdaterGo.Visible = False
        UpdaterCancel.Visible = False

        Me.Text = "Outworldz V" + MyVersion
        PictureBox1.Enabled = True

        'hide the pulldowns as there is no content yet
        MnuContent.Visible = False
        mnuSettings.Visible = False

        gChatTime = My.Settings.ChatTime

        TextBox1.AllowDrop = True
        PictureBox1.AllowDrop = True

        Running = False ' true when opensim is running

        MyFolder = My.Application.Info.DirectoryPath

        ' I would like to buy an argument
        Dim arguments As String() = Environment.GetCommandLineArgs()

        If arguments.Length > 1 Then
            ' for debugging when compiling
            If arguments(1) = "-debug" Then
                gDebug = True
                MyFolder = DebugPath ' for testing, as the compiler buries itself in ../../../debug
            End If
        End If
        gCurSlashDir = MyFolder.Replace("\", "/")    ' because Mysql uses unix like slashes, that's why

        ClearLogFiles() ' clear log fles

        MyUPnPMap = New UPNP(MyFolder)

        Try
            My.Computer.FileSystem.RenameFile(MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\Regions\RegionConfig.ini", "Outworldz.ini")
            Log("Info:Upgraded RegionConfig.ini to Outworldz.ini")
        Catch ex As Exception
            Log("Info:No need to upgrade RegionConfig.ini")
        End Try

        If System.IO.File.Exists(MyFolder + " \ " + RevNotesFile) Then
            System.Diagnostics.Process.Start("wordpad.exe", """" + MyFolder + "\" + RevNotesFile + """")
        End If

        GetAllRegions()

        If (My.Settings.SplashPage = "") Then
            My.Settings.SplashPage = Domain + "/Outworldz_installer/Welcome.htm"
            My.Settings.Save()
        End If

        SaySomething()

        Me.Show()
        ProgressBar1.Value = 100
        ProgressBar1.Value = 0

        If Not My.Settings.SkipUpdateCheck Then
            CheckForUpdates()
        End If

        CheckDefaultPorts()

        ' Run diagnostics, maybe
        If gDebug Then My.Settings.DiagsRun2 = False

        If Not My.Settings.DiagsRun2 Then
            DoDiag()
            My.Settings.DiagsRun2 = True
        End If

        SetINIData()

        mnuSettings.Visible = True
        SetIAROARContent() ' load IAR and OAR web content

        If My.Settings.Password = "secret" Then
            BumpProgress10()
            Dim Password = New PassGen
            My.Settings.Password = Password.GeneratePass()
            My.Settings.Save()
        End If

        ' Find out if the viewer is installed
        If System.IO.File.Exists(MyFolder & "\OutworldzFiles\Init.txt") Then

            Buttons(StartButton)
            ProgressBar1.Value = 100
            Log("Info: Ready to start")
            Print("Ready to Launch! Click 'Start' to begin your adventure in Opensimulator.")
        Else

            My.Settings.HttpPort = 8002
            My.Settings.Save()

            Print("Installing Desktop icon clicky thingy")
            Create_ShortCut(MyFolder & "\Start.exe")
            BumpProgress10()

            Try
                ' mark the system as ready
                Using outputFile As New StreamWriter(MyFolder & "\OutworldzFiles\Init.txt", True)
                    outputFile.WriteLine("This file lets Outworldz know it has been installed")
                End Using
            Catch ex As Exception
                Log("Error:Could not create Init.txt - no permissions to write it:" + ex.Message)
            End Try

            If System.IO.File.Exists(xmlPath() + "\AppData\Roaming\Onlook\user_settings\settings_onlook.xml") Then
                My.Settings.Onlook = True
            Else
                Dim yesno = MsgBox("Do you want to install the Onlook Viewer? (Newcomers to virtual worlds should choose Yes)", vbYesNo)
                If (yesno = vbYes) Then
                    My.Settings.Onlook = True
                    Print("Installing Onlook Viewer")
                    Dim pi As ProcessStartInfo = New ProcessStartInfo()
                    pi.Arguments = ""
                    pi.FileName = """" + MyFolder & "\Viewer\Onlook.exe" + """"
                    pOnlook.StartInfo = pi
                    Try
                        Log("Info:Launching Onlook installer")
                        pOnlook.Start()
                    Catch ex As Exception
                        Log("Error:Onlook installer failed to load:" + ex.Message)
                    End Try

                    ProgressBar1.Value = 0
                    Print("Please Install and Start the Onlook Viewer")
                    Dim toggle As Boolean = False
                    While Not System.IO.File.Exists(xmlPath() + "\AppData\Roaming\Onlook\user_settings\settings_onlook.xml") And ProgressBar1.Value < 99
                        Application.DoEvents()
                        Sleep(2000)
                        If (toggle) Then
                            Print("Attention needed - please Install and Start the Onlook Viewer ")
                            toggle = False
                        Else
                            Print("Start the Onlook Viewer")
                            toggle = False
                            toggle = True
                        End If
                        BumpProgress(1)

                        If ProgressBar1.Value = 100 Then
                            Print("You win. Proceeding with Outworldz Installation. You may need to add the grid manually.")
                            toggle = True
                        End If
                    End While

                    ' close the viewer so the grid will repopulate next time it opens
                    Try
                        zap("OnlookViewer")
                    Catch ex As Exception
                        Log("Error:Failed to zap Onlook:" + ex.Message)
                    End Try

                Else
                    My.Settings.Onlook = False
                End If
            End If
            Print("Ready to Launch! Click 'Start' to begin your adventure in Opensimulator.")
        End If

        ProgressBar1.Value = 100
        Application.DoEvents()


        Buttons(StartButton)

        If (My.Settings.TimerInterval > 0) Then
            Timer1.Interval = My.Settings.TimerInterval * 1000
            Timer1.Start() 'Timer starts functioning
        End If

    End Sub

    Private Sub StartButton_Click(sender As System.Object, e As System.EventArgs) Handles StartButton.Click

        ProgressBar1.Value = 0

        Buttons(BusyButton)
        Running = True
        MnuContent.Visible = True

        GetAllRegions()

        RegisterDNS()

        GetPubIP()

        SetINIData()    ' set up the INI files

        If My.Settings.Onlook Then
            SaveOnlookXMLData()
        End If

        StartMySQL() ' boot up MySql, and wait for it to start listening

        If Not Start_Opensimulator() Then ' Launch the rocket
            'KillAll()
            Return
        End If
        Onlook()

        ' show the IAR and OAR menu when we are up 
        If gContentAvailable Then
            IslandToolStripMenuItem.Visible = True
            ClothingInventoryToolStripMenuItem.Visible = True
        End If

        Buttons(StopButton)

        Print("Outworldz is almost ready for you to log in.  Wait for INITIALIZATION COMPLETE - LOGINS ENABLED to appear in the console, and you can log in." + vbCrLf _
              + " Hypergrid address is http://" + My.Settings.PublicIP + ":" + My.Settings.HttpPort)

        ' done with bootup
        ProgressBar1.Value = 100

        If (My.Settings.TimerInterval > 0) Then
            Timer1.Interval = My.Settings.TimerInterval * 1000
            Timer1.Start() 'Timer starts functioning
        End If

        Me.AllowDrop = True

    End Sub

    Private Sub Form1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        Dim p As Point
        p = Me.Location

        If System.IO.File.Exists("""" + MyFolder + "\" + RevNotesFile + """") Then
            Try
                My.Computer.FileSystem.RenameFile(MyFolder + "\" + RevNotesFile, "Update_Notes_for_Rev_" + MyVersion + ".rtf")
            Catch ex As Exception
                Log("Error: Failed to remove rev notes" + ex.Message)
            End Try

        End If

        My.Settings.MyX = p.X
        My.Settings.MyY = p.Y

        ProgressBar1.Value = 90
        Print("Hold fast to your dreams ...")
        ExitAll()
        ProgressBar1.Value = 25
        Print("I'll tell you my next dream when I wake up.")
        StopMysql()
        Print("Zzzz...")
        ProgressBar1.Value = 0
    End Sub

    Private Sub mnuExit_Click(sender As System.Object, e As System.EventArgs) Handles mnuExit.Click
        Log("Info:Exiting")
        End
    End Sub

    Private Sub ExitAll()

        ' Kill ALL Running processes
        KillAll()

        Try
            RemoveGrid()    ' puts Onlook back to default
        Catch ex As Exception
            Log("Info:grid settings set back to defaults" + ex.Message)
        End Try

    End Sub

    Private Sub ShutdownNowToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Print("Stopping")
        Application.DoEvents()
        KillAll()
        Buttons(StartButton)
        Print("")
    End Sub

    Private Sub KillAll()

        ProgressBar1.Value = 100
        ' close everything as gracefully as possible.

        Try
            pOnlook.CloseMainWindow()
            pOnlook.WaitForExit()
            pOnlook.Close()
        Catch ex As Exception
            Log("Info:Onlook not running:" + ex.Message)
        End Try

        ProgressBar1.Value = 67

        Application.DoEvents()

        Try
            ConsoleCommand("quit{ENTER}")
            Dim ctr = 20
            While IsOpensimRunning() And ctr > 0
                Sleep(1000)
                Try
                    ConsoleCommand("quit{ENTER}")
                Catch
                End Try
                ctr = -1
            End While
            Try
                ConsoleCommand("{ENTER}")
                ConsoleCommand("{ENTER}")
                ConsoleCommand("{ENTER}")
                ConsoleCommand("{ENTER}")
            Catch
            End Try
            Me.Focus()
        Catch ex As Exception
            Log("Warn:Cannot stop a non-running Opensim:" + ex.Message)
        End Try

        ProgressBar1.Value = 33

        'CloseRouterPorts()

        ' cannot load OAR or IAR, either
        IslandToolStripMenuItem.Visible = False
        ClothingInventoryToolStripMenuItem.Visible = False
        MnuContent.Visible = False
        Running = False
        Me.AllowDrop = False

        ProgressBar1.Value = 0
        Application.DoEvents()

    End Sub

    Private Function zap(processName As String) As Boolean
        ' Kill process by name
        For Each P As Process In System.Diagnostics.Process.GetProcessesByName(processName)
            Try
                Log("Info:Stopping process " + processName)
                P.Kill()
                Return True
            Catch ex As Exception
                Log("Info:failed to stop " + processName)
                Return False
            End Try
        Next
        zap = False
    End Function
#End Region

#Region "Menus"

    Private Sub ConsoleCOmmandsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ConsoleCOmmandsToolStripMenuItem1.Click
        Dim webAddress As String = "http://opensimulator.org/wiki/Server_Commands"
        Process.Start(webAddress)
    End Sub


    Private Sub Busy_Click(sender As System.Object, e As System.EventArgs)
        ' Busy click shuts us down
        Dim result As Integer = MessageBox.Show("Do you want to Abort?", "caption", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Print("Stopping")
            KillAll()
            Buttons(StartButton)
            Print("Stopped")
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
        MyShortcut.IconLocation = WshShell.ExpandEnvironmentStrings(MyFolder & "\Start.exe")
        MyShortcut.WorkingDirectory = MyFolder
        MyShortcut.Save()

    End Sub

    Private Sub Print(Value As String)

        Log("Info:" + Value)
        PictureBox1.Visible = False
        TextBox1.Visible = True
        TextBox1.Text = Value
        Application.DoEvents()
        Sleep(gChatTime)  ' time to read

    End Sub


    Private Sub mnuAbout_Click(sender As System.Object, e As System.EventArgs) Handles mnuAbout.Click
        Print("(c) 2014 Outworld.LLC")
        Dim webAddress As String = Domain + "/Outworldz_Installer"
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

    Public Function Random() As String
        Dim value As Integer = CInt(Int((600000000 * Rnd()) + 1))
        Random = System.Convert.ToString(value)
    End Function

    Private Sub WebUIToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Print("The Web UI lets you add or view settings for the default avatar. ")
        If Running Then
            Dim webAddress As String = "http://127.0.0.1:" + My.Settings.HttpPort
            Process.Start(webAddress)
        End If
    End Sub

#End Region

#Region "INI"

    Private Sub LoadIni(filepath As String, delim As String)
        parser = New FileIniDataParser()
        parser.Parser.Configuration.SkipInvalidLines = True
        parser.Parser.Configuration.CommentString = delim ' Opensim uses semicolons

        Data = parser.ReadFile(filepath)
        gINI = filepath
    End Sub

    Private Sub SetIni(section As String, key As String, value As String)
        ' sets values into any INI file
        Try
            Log("Info:Writing '" + gINI + " section [" + section + "] " + key + "=" + value)
            Data(section)(key) = value ' replace it and save it
        Catch ex As Exception
            Log("Info:Cannot locate '" + key + "' in section '" + section + "' in file " + gINI + ". This is not good")
            MsgBox("Cannot locate '" + key + "' in section '" + section + "' in file " + gINI + ". This is not good", vbOK)
        End Try
    End Sub

    Private Sub SaveINI()
        Try
            parser.WriteFile(gINI, Data)
        Catch ex As Exception
            Log("Error:" + ex.Message)
        End Try
    End Sub

    Public Function GetIni(filepath As String, section As String, key As String, delim As String) As String
        ' gets values from an INI file
        Dim parser = New FileIniDataParser()
        parser.Parser.Configuration.SkipInvalidLines = True
        parser.Parser.Configuration.CommentString = delim ' Opensim uses semicolons

        Dim Data = parser.ReadFile(filepath)

        GetIni = Stripqq(Data(section)(key))

        parser = Nothing

    End Function
    Private Sub SetDefaultSims()

        Dim reader As System.IO.StreamReader
        Dim line As String
        Dim INIname As String

        ' Diva 0.8.2 used MyWorld.ini all other versions use StandaloneCommon.ini
        Dim prefix = MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\config-include\"
        If My.Settings.GridFolder = "Opensim-0.9" Then
            INIname = "StandaloneCommon.ini"
        Else
            INIname = "MyWorld.ini"
        End If

        Try

            ' add this sim name as a default to the file as HG regions, and add the other regions as fallback
            Dim DefaultName = aRegion(My.Settings.WelcomeRegion + 1).RegionName
            '(replace spaces with underscore)
            DefaultName = DefaultName.Replace(" ", "_")    ' because this is a screwy thing they did in the INI file

            Dim onceflag As Boolean = False ' only do the DefaultName
            Dim counter As Integer = 1
            Dim L = aRegion.GetUpperBound(0)

            Using outputFile As New StreamWriter(prefix + "File.tmp")
                reader = System.IO.File.OpenText(prefix + INIname)
                'now loop through each line
                While reader.Peek <> -1
                    line = reader.ReadLine()

                    If line.Contains("DefaultRegion, DefaultHGRegion, FallbackRegion") Then
                        ' flag lets us skip multi-lines
                        If onceflag = False Then
                            onceflag = True
                            line = "Region_" + DefaultName + " = " + """" + "DefaultRegion, DefaultHGRegion, FallbackRegion" + """"
                            outputFile.WriteLine(line)
                        End If
                    Else
                        outputFile.WriteLine(line)
                    End If

                End While
            End Using
            'close your reader
            reader.Close()
        Catch
            MsgBox("There are no region files! There must be at least one region")
        End Try

        Try
            My.Computer.FileSystem.DeleteFile(prefix + INIname)
            My.Computer.FileSystem.RenameFile(prefix + "File.tmp", INIname)
        Catch ex As Exception
            Log("Error:SetDefault sims could not rename the file:" + ex.Message)
        End Try

    End Sub

    Private Sub SetINIData()

        'mnuShow shows the DOS box for Opensimulator
        mnuShow.Checked = My.Settings.ConsoleShow
        mnuHide.Checked = Not My.Settings.ConsoleShow

        If My.Settings.ConsoleShow Then
            Log("Info:Console will be shown")
        Else
            Log("Info:Console will not be shown")
        End If

        mnuFull.Checked = Not My.Settings.ViewerEase
        mnuEasy.Checked = My.Settings.ViewerEase
        If mnuFull.Checked Then
            Log("Info:Onlook Menu is set to Full UI")
        Else
            Log("Info:Onlook Menu is set to Minimum")
        End If

        mnuYesAvatar.Checked = My.Settings.AvatarShow
        mnuNoAvatar.Checked = Not My.Settings.AvatarShow
        If mnuYesAvatar.Checked Then
            Log("Info:Avatar will be visible")
        Else
            Log("Info:Avatar will not be visible")
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' set the defaults in the INI for the viewer to use. Painful to do as its a Left hand side edit 

        SetDefaultSims()

        ' Opensim.ini
        LoadIni(MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\Opensim.ini", ";")
        SetIni("Const", "httpPort", My.Settings.HttpPort)
        SetIni("Const", "BaseURL", """" + "http://" + My.Settings.PublicIP + """")
        SetIni("Const", "PublicPort", My.Settings.PublicPort)
        SetIni("Const", "PrivatePort", My.Settings.PrivatePort)
        SetIni("Const", "GridName", """" + My.Settings.SimName + """")

        If My.Settings.MapType = "None" Then
            SetIni("Map", "GenerateMaptiles", "false")
        ElseIf My.Settings.MapType = "Simple" Then
            SetIni("Map", "GenerateMaptiles", "true")
            SetIni("Map", "MapImageModule", "MapImageModule")  ' versus Warp3DImageModule
            SetIni("Map", "TextureOnMapTile", "false")         ' versus true
            SetIni("Map", "DrawPrimOnMapTile", "false")
            SetIni("Map", "TexturePrims", "false")
            SetIni("Map", "RenderMeshes", "false")
        ElseIf My.Settings.MapType = "Good" Then
            SetIni("Map", "GenerateMaptiles", "true")
            SetIni("Map", "MapImageModule", "Warp3DImageModule")  ' versus MapImageModule
            SetIni("Map", "TextureOnMapTile", "false")         ' versus true
            SetIni("Map", "DrawPrimOnMapTile", "false")
            SetIni("Map", "TexturePrims", "false")
            SetIni("Map", "RenderMeshes", "false")
        ElseIf My.Settings.MapType = "Better" Then
            SetIni("Map", "GenerateMaptiles", "true")
            SetIni("Map", "MapImageModule", "Warp3DImageModule")  ' versus MapImageModule
            SetIni("Map", "TextureOnMapTile", "true")         ' versus true
            SetIni("Map", "DrawPrimOnMapTile", "true")
            SetIni("Map", "TexturePrims", "false")
            SetIni("Map", "RenderMeshes", "false")
        ElseIf My.Settings.MapType = "Best" Then
            SetIni("Map", "GenerateMaptiles", "true")
            SetIni("Map", "MapImageModule", "Warp3DImageModule")  ' versus MapImageModule
            SetIni("Map", "TextureOnMapTile", "true")      ' versus true
            SetIni("Map", "DrawPrimOnMapTile", "true")
            SetIni("Map", "TexturePrims", "true")
            SetIni("Map", "RenderMeshes", "true")
        End If


        SaveINI()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        ' Diva 0.8.2 used MyWorld.ini all other versions use StandaloneCommon.ini
        If My.Settings.GridFolder = "Opensim-0.9" Then
            ViewWebUI.Visible = False
            LoadIni(MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\config-include\StandaloneCommon.ini", ";")
        Else
            ViewWebUI.Visible = True
            LoadIni(MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\config-include\MyWorld.ini", ";")
        End If


        ' set viewer Splash Page V 1.54
        SetIni("GridInfoService", "welcome", My.Settings.SplashPage)

        ' Voice
        If My.Settings.VivoxEnabled Then
            SetIni("VivoxVoice", "enabled", "true")
        Else
            SetIni("VivoxVoice", "enabled", "false")
        End If
        SetIni("VivoxVoice", "vivox_admin_user", My.Settings.Vivox_username)
        SetIni("VivoxVoice", "vivox_admin_password", My.Settings.Vivox_password)

        ' Physics
        ' choices for meshmerizer, where Ubit's ODE requires a special one
        ' mesging = ZeroMesher
        ' meshing = Meshmerizer
        ' meshing = ubODEMeshmerizer

        ' 0 = physics = none
        ' 1 = OpenDynamicsEngine
        ' 2 = physics = BulletSim
        ' 3 = physics = BulletSim with threads
        ' 4 = physics = ubODE

        Select Case My.Settings.Physics
            Case 0
                SetIni("Startup", "meshing", "ZeroMesher")
                SetIni("Startup", "physics", "basicphysics")
                SetIni("Startup", "UseSeparatePhysicsThread", "false")
            Case 1
                SetIni("Startup", "meshing", "Meshmerizer")
                SetIni("Startup", "physics", "OpenDynamicsEngine")
                SetIni("Startup", "UseSeparatePhysicsThread", "false")
            Case 2
                SetIni("Startup", "meshing", "Meshmerizer")
                SetIni("Startup", "physics", "BulletSim")
                SetIni("Startup", "UseSeparatePhysicsThread", "false")
            Case 3
                SetIni("Startup", "meshing", "Meshmerizer")
                SetIni("Startup", "physics", "BulletSim")
                SetIni("Startup", "UseSeparatePhysicsThread", "true")
            Case 4
                SetIni("Startup", "meshing", "ubODEMeshmerizer")
                SetIni("Startup", "physics", "ubODE")
                SetIni("Startup", "UseSeparatePhysicsThread", "false")
            Case Else
                SetIni("Startup", "meshing", "Meshmerizer")
                SetIni("Startup", "physics", "BulletSim")
                SetIni("Startup", "UseSeparatePhysicsThread", "true")
        End Select

        ' set MySql
        Dim ConnectionString = """" _
            + "Data Source=" + My.Settings.DBSource _
            + ";Database=" + My.Settings.DBName _
            + ";Port=" + My.Settings.MySqlPort _
            + ";User ID=" + My.Settings.DBUserID _
            + ";Password=" + My.Settings.DBPassword _
            + ";Old Guids=True;Allow Zero Datetime=True;" _
            + """"

        SetIni("DatabaseService", "ConnectionString", ConnectionString)

        If My.Settings.WebStats Then
            SetIni("WebStats", "enabled", "True")
        Else
            SetIni("WebStats", "enabled", "False")
        End If

        ' Viewer UI shows the full viewer UI
        If My.Settings.ViewerEase Then
            Log("Info: Viewer set to Easy")
            SetIni("SpecialUIModule", "enabled", "true")
        Else
            Log("Info:Viewer set to Normal")
            SetIni("SpecialUIModule", "enabled", "false")
        End If

        'Avatar visible?
        If My.Settings.AvatarShow Then
            Log("Info:Showing the avatar")
            SetIni("CameraOnlyModeModule", "enabled", "false")
        Else
            Log("Info:Set to not show avatar")
            SetIni("CameraOnlyModeModule", "enabled", "true")
        End If

        If (My.Settings.allow_grid_gods) Then
            SetIni("Permissions", "allow_grid_gods", "true")
        Else
            SetIni("Permissions", "allow_grid_gods", "false")
        End If

        If (My.Settings.region_owner_is_god) Then
            SetIni("Permissions", "region_owner_is_god", "true")
        Else
            SetIni("Permissions", "region_owner_is_god", "false")
        End If

        If (My.Settings.region_manager_is_god) Then
            SetIni("Permissions", "region_manager_is_god", "true")
        Else
            SetIni("Permissions", "region_manager_is_god", "false")
        End If

        If (My.Settings.parcel_owner_is_god) Then
            SetIni("Permissions", "parcel_owner_is_god", "true")
        Else
            SetIni("Permissions", "parcel_owner_is_god", "false")
        End If

        If My.Settings.GridFolder <> "Opensim-0.9" Then
            SetIni("WifiService", "AdminPassword", """" + My.Settings.Password + """")
            SetIni("WifiService", "AdminEmail", """" + My.Settings.AdminEmail + """")

            If My.Settings.AccountConfirmationRequired Then
                SetIni("WifiService", "AccountConfirmationRequired", "true")
            Else
                SetIni("WifiService", "AccountConfirmationRequired", "false")
            End If
        End If

        ' Autobackup
        If My.Settings.AutoBackup Then
            Log("Info:Autobackup is On")
            SetIni("AutoBackupModule", "AutoBackup", "true")
        Else
            Log("Info:Autobackup is Off")
            SetIni("AutoBackupModule", "AutoBackup", "false")
        End If

        SetIni("AutoBackupModule", "AutoBackupInterval", My.Settings.AutobackupInterval)
        SetIni("AutoBackupModule", "AutoBackupKeepFilesForDays", My.Settings.KeepForDays)

        SaveINI()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Regions - write all region.ini files with public IP and Public port
        Dim counter As Integer = 1
        Dim L = aRegion.GetUpperBound(0)
        While counter <= L
            Dim simName = aRegion(counter).RegionName
            LoadIni(MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\Regions\" + simName + ".ini", ";")
            SetIni(simName, "InternalPort", Convert.ToString(aRegion(counter).RegionPort))
            SetIni(simName, "ExternalHostName", Convert.ToString(My.Settings.PublicIP))
            SaveINI()
            counter += 1
        End While

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'Onlook viewer
        If My.Settings.Onlook = True Then
            Log("Info:Onlook viewer mode")
            mnuOther.Checked = False
            mnuOnlook.Checked = True
            VUI.Visible = True
            AvatarVisible.Visible = True
        Else
            Log("Info:Other viewer mode")
            mnuOther.Checked = True
            mnuOnlook.Checked = False
            VUI.Visible = False
            AvatarVisible.Visible = False
        End If

    End Sub

#End Region

#Region "Regions and Ports"

    Private Sub CheckDefaultPorts()

        If My.Settings.PrivatePort = My.Settings.PublicPort Then
            My.Settings.PublicPort = 8001
            My.Settings.HttpPort = 8002
            My.Settings.PrivatePort = 8003
            MsgBox("Port conflict detected. Public, HTTP and Private Ports have been reset to the default of 8001, 8002 and 8003", vbInformation)
        End If

        If My.Settings.PrivatePort = My.Settings.HttpPort Then
            My.Settings.PublicPort = 8001
            My.Settings.HttpPort = 8002
            My.Settings.PrivatePort = 8003
            MsgBox("Port conflict detected. Public, HTTP and Private Ports have been reset to the default of 8001, 8002 and 8003", vbInformation)
        End If

        If My.Settings.PublicPort = My.Settings.HttpPort Then
            My.Settings.PublicPort = 8001
            My.Settings.HttpPort = 8002
            My.Settings.PrivatePort = 8003
            MsgBox("Port conflict detected. Public, HTTP and Private Ports have been reset to the default of 8001, 8002 and 8003", vbInformation)
        End If

    End Sub

    Public Sub GetAllRegions()

        Dim files() As String
        Dim ini As String = MyFolder + "\OutworldzFiles\" + My.Settings.GridFolder + "\bin\Regions\"
        Array.Resize(aRegion, 1)

        files = Directory.GetFiles(ini, "*.ini", SearchOption.TopDirectoryOnly)
        For Each FileName As String In files
            Try
                Array.Resize(aRegion, aRegion.Length + 1)
                Dim index = aRegion.Length - 1
                aRegion(index) = New Region_data
                Dim pos = InStrRev(FileName, "\")
                Dim name As String = Mid(FileName, pos + 1)
                Dim fname = Mid(name, 1, Len(name) - 4)
                Dim longName = MyFolder + "\OutworldzFiles\" + My.Settings.GridFolder + "\bin\Regions\" + fname + ".ini"

                aRegion(index).RegionName = fname
                aRegion(index).UUID = GetIni(longName, fname, "RegionUUID", ";")
                aRegion(index).SizeX = Convert.ToInt16(GetIni(longName, fname, "SizeX", ";"))
                aRegion(index).SizeY = Convert.ToInt16(GetIni(longName, fname, "SizeY", ";"))
                aRegion(index).RegionPort = Convert.ToInt16(GetIni(longName, fname, "InternalPort", ";"))

                Log("Fetching INI file for Region " + fname)

                ' Location is int,int format.
                Dim C = GetIni(longName, fname, "Location", ";")
                Dim parts As String() = C.Split(New Char() {","c}) ' split at the comma
                aRegion(index).CoordX = parts(0)
                aRegion(index).CoordY = parts(1)
            Catch ex As Exception
                Log("Err:Parse file " + Name + ":" + ex.Message)
            End Try
        Next
    End Sub

#End Region

#Region "ToolBars"


    Private Sub BusyButton_Click(sender As Object, e As EventArgs) Handles BusyButton.Click

        Print("Stopping")
        Application.DoEvents()
        KillAll()
        Buttons(StartButton)
        Print("Opensim Is Stopped")
        Log("Info:Stopped")

    End Sub

    Private Sub AdminUIToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ViewWebUI.Click
        If (Running) Then
            Dim webAddress As String = "http://127.0.0.1:" + My.Settings.HttpPort
            Process.Start(webAddress)
            Print("Log in as '" + My.Settings.AdminFirst + " " + My.Settings.AdminLast + "' with a password of '" + My.Settings.Password + "' to add user accounts.")
        Else
            Print("Opensim is not running. Cannot open the Web Interface.")
        End If
    End Sub

    Private Sub OnlookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuOnlook.Click
        Print("Onlook Viewer will be launched on Startup")
        mnuOther.Checked = False
        mnuOnlook.Checked = True
        My.Settings.Onlook = True
        My.Settings.Save()
        VUI.Visible = True
        AvatarVisible.Visible = True
    End Sub

    Private Sub OtherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuOther.Click
        Print("Onlook Viewer will not be launched on Startup.")
        mnuOther.Checked = True
        mnuOnlook.Checked = False
        My.Settings.Onlook = False
        VUI.Visible = False
        AvatarVisible.Visible = False
        My.Settings.Save()
    End Sub

    Private Sub LoopBackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoopBackToolStripMenuItem.Click
        Dim webAddress As String = Domain + "/Outworldz_Installer/Loopback.htm"
        Process.Start(webAddress)
    End Sub

    Private Sub MoreContentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoreContentToolStripMenuItem.Click
        Dim webAddress As String = Domain + "/cgi/freesculpts.plx"
        Process.Start(webAddress)
        Print("Drag and drop Backup.Oar, or any OAR or IAR files to load into your Sim")
    End Sub

    Private Sub AdvancedSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdvancedSettingsToolStripMenuItem.Click

        ActualForm = New AdvancedForm
        ' Set the new form's desktop location so it appears below and
        ' to the right of the current form.
        ActualForm.SetDesktopLocation(300, 200)
        ActualForm.Activate()
        ActualForm.Visible = True

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim webAddress As String = Domain + "/Outworldz_Installer/PortForwarding.htm"
        Process.Start(webAddress)
    End Sub
#End Region

#Region "Opensimulator"

    Private Function Start_Opensimulator() As Boolean
        If Running = False Then Return True
        Print("Starting Opensimulator")

        Dim ItWorked As Boolean
        If mnuShow.Checked Then
            Log("Info:Opensim console is forced visible")
            Print("Please wait for the console to show 'LOGINS ENABLED'. It will take a while to load. ")
            ItWorked = Boot(AppWinStyle.NormalFocus)
        Else
            ItWorked = Boot(AppWinStyle.MinimizedNoFocus)
            Log("Info:Opensim console is Minimized")
        End If

        If Not ItWorked Then
            Return False
        End If

        ' Wait for Opensim to start listening 
        Dim Up As String
        Try
            Up = client.DownloadString("http://127.0.0.1:" + My.Settings.HttpPort + "/?_Opensim=" + Random())
        Catch ex As Exception
            Up = ""
            Log("Info:Opensim is not yet running, will continue to check every 1/10 second for two minutes")
        End Try
        Dim counter = 0
        While Up.Length = 0 And Running
            Application.DoEvents()
            BumpProgress(1)
            counter = counter + 1
            ' wait a couple of minutes for it to start
            If counter > 1200 Then
                Print("Error:Opensim failed to start")
                KillAll()
                Buttons(StartButton)
                Dim yesno = MsgBox("Opensim did not start. Do you want to see the log file?", vbYesNo)
                If (yesno = vbYes) Then
                    Dim Log As String = """" + MyFolder + "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\OpenSim.log" + """"
                    System.Diagnostics.Process.Start("wordpad.exe", Log)
                End If
                Buttons(StartButton)
                Return False
            End If
            Application.DoEvents()
            Sleep(100)

            Try
                Up = client.DownloadString("http://127.0.0.1:" + My.Settings.HttpPort + "/?_Opensim=" + Random())
            Catch ex As Exception
                Log("Info:Opensim is not yet running, waiting for it to start listening")
                Up = ""
                If InStr(ex.Message, "404") Then
                    Up = "Done"
                End If
            End Try
        End While
        Log("Info:Opensim is running")
        Return True

    End Function
    Private Function Boot(Show As AppWinStyle) As Boolean

        Try
            ChDir(MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\")
            OpensimProcID = Shell("""" + MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\StartOpensim.bat" + """", Show)
            ChDir(MyFolder)
        Catch ex As Exception
            Print("Error: Opensim did not start: " + ex.Message)
            KillAll()
            Buttons(StartButton)
            Return False
        End Try
        Return True
    End Function

    Private Function IsOpensimRunning() As Boolean

        Dim Up As String = String.Empty
        Try
            Up = client.DownloadString("http://127.0.0.1:" + My.Settings.HttpPort + "/?_Opensim=" + Random())
        Catch ex As Exception
            Return False
        End Try
        If Up.Length = 0 And Running Then
            Return False
        End If

        Return True
    End Function

#End Region

#Region "Viewers"

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
#End Region

#Region "Logging"
    Private Sub ClearLogFiles()

        Dim Logfiles = New List(Of String) From {
            MyFolder + "\OutworldzFiles\Outworldz.log",
            MyFolder + "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\Opensim.log",
            MyFolder + "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\OpenSimConsoleHistory.txt",
            MyFolder + "\OutworldzFiles\Diagnostics.log",
            MyFolder + "\OutworldzFiles\UPNP.log"
        }

        For Each thing In Logfiles
            ' clear out the log files
            Try
                My.Computer.FileSystem.DeleteFile(thing)
            Catch ex As Exception
                Log("Info:" + thing + " is empty")
            End Try
            BumpProgress10()
        Next
    End Sub

    Public Sub Log(message As String)
        Try
            Using outputFile As New StreamWriter(MyFolder & "\OutworldzFiles\Outworldz.log", True)
                outputFile.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + message)
            End Using
        Catch
        End Try
    End Sub

    Private Sub ShowLog()
        LogButton.Show()
        IgnoreButton.Show()
    End Sub
    Private Sub ShowLogButton_Click(sender As Object, e As EventArgs) Handles LogButton.Click

        System.Diagnostics.Process.Start("wordpad.exe", """" + MyFolder + "/OutworldzFiles/Outworldz.log" + """")

        LogButton.Hide()
        IgnoreButton.Hide()

    End Sub

    Private Sub IgnoreButton_Click(sender As Object, e As EventArgs) Handles IgnoreButton.Click
        LogButton.Hide()
        IgnoreButton.Hide()
    End Sub
#End Region

#Region "Subs"

    Private Function BackupPath() As String

        If My.Settings.BackupFolder = "AutoBackup" Then
            BackupPath = gCurSlashDir + "/OutworldzFiles/Autobackup/"
        Else
            BackupPath = My.Settings.BackupFolder + "/"
            BackupPath = BackupPath.Replace("\", "/")    ' because Opensim uses unix-like slashes, that's why
        End If

    End Function
    Public Sub ConsoleCommand(command As String)
        Try
            AppActivate(OpensimProcID)
            SendKeys.SendWait(command)
        Catch ex As Exception
            Log("Warn:" + ex.Message)
        End Try
    End Sub
    Private Sub SaySomething()
        Dim Prefix() As String = {
                                  "Mmmm?  Yawns ...",
                                  "Yawns, and stretches ...",
                                  "Wakes up and rolls over ...",
                                  "You look more beautiful every time I wake up.",
                                  "Zzzz...  Ooooh, I need coffee before I go to work.",
                                  "Nooo... is it already time to wake up?",
                                  "Mmmm, I was sleeping...",
                                  "What a dream that was!",
                                  "Do you ever dream of better worlds? I just did.",
                                  "Huh?",
                                  "Mumbles..."
                                }

        Dim Array() As String = {
                 "I dreamt we were both flying a dragon in the Outworldz. You flamed me. I tried to get even.  I lost LOL ",
                 "I dreamt we were chatting at OsGrid.org. It's the largest hypergrid-enabled virtual world.",
                 "I dreamt some friends and you were riding a rollercoaster in the Great Canadian Grid.",
                 "I dreamt I was watching a pretty particle exhibit with you on the Metropolis grid.",
                 "I dreamt we walked into a bar discussing politics in Hebrew and Arabic using a free translator.",
                 "I dreamt you took the hypergrid safari to visit the mountains of Africa in the Virunga sim.",
                 "I dreamt you won a race while riding a silly cow at the Outworldz 'Frankie' sim.",
                 "I dreamt you are a wonderful singer. I loved to hear your voice singing into the voice-chat system.",
                 "I remember in my dream that the spaceport at Gravity sim in OsGrid was really hopping. And floating. And then I fell. ",
                 "I was dreaming that you were a mermaid in the Lost Worlds.",
                 "I deamt that you made a pile of prims that you simply will not believe!",
                 "I dreamed that I asked when you were going to straighten out the castle. You said, 'Why? Is it tilted?'",
                 "I saw a dog in my dream. I dreamt you made a 'mesh' of it.",
                 "I dreamt I saw a man without any pants firmly attached to an eagle flying in the air. Always rez before you attach!",
                 "I forgot the dream already. I remember I woke up in it.",
                 "I was thinking I had no clothes on. No shirt, shoes, or hair. The worst part was there was no facelight! I looked hideous!",
                 "I dreamt that I was floating in a river and a scripted mesh crocodile chased me.",
                 "I dreamt I drove our car into the ocean. You found a pose ball, and we both grabbed onto it and were saved.",
                 "I dreamed that there was a animated mesh zebra in my bathtub.",
                 "I had dreamed a fairy was my best friend.",
                 "I dreamed that there were non-player characters living in my house, so I decided to fly away. ",
                 "I had a dream that there were pimples all over my face. So I switched skins and looked perfect!",
                 "I had a dream where I had lost my free mesh boots, so I was asking everybody where I got them on the hypergrid.",
                 "I had a dream that we were sitting on my roof and we stood up and both fell off. But I hit Page Up and flew away."
                  }

        Randomize()

        Dim value1 As Integer = CInt(Int((Prefix.Length - 1) * Rnd()))
        Dim value2 As Integer = CInt(Int((Array.Length - 1) * Rnd()))
        Dim whattosay = Prefix(value1) + vbCrLf + vbCrLf + Array(value2) + " ... and then I woke up."
        Print(whattosay)

    End Sub

    Sub Sleep(value As Integer)
        Thread.Sleep(value)
    End Sub

    Public Sub PaintImage()

        If (My.Settings.TimerInterval > 0) Then
            Dim randomFruit = images(Arnd.Next(0, images.Count))
            ProgressBar1.Visible = False
            TextBox1.Visible = False
            PictureBox1.Enabled = True
            PictureBox1.Image = randomFruit
            PictureBox1.Visible = True
            Timer1.Interval = My.Settings.TimerInterval * 1000
        Else
            PictureBox1.Visible = False
        End If

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        PaintImage()
    End Sub

    Private Sub LoadBackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadBackupToolStripMenuItem.Click
        If (Running) Then

            ChooseRegion()

            ' Create an instance of the open file dialog box.
            Dim openFileDialog1 As OpenFileDialog = New OpenFileDialog

            ' Set filter options and filter index.
            openFileDialog1.InitialDirectory = BackupPath()
            openFileDialog1.Filter = "Opensim OAR(*.OAR,*.GZ,*.TGZ)|*.oar;*.gz;*.tgz;*.OAR;*.GZ;*.TGZ|All Files (*.*)|*.*"
            openFileDialog1.FilterIndex = 1
            openFileDialog1.Multiselect = False

            ' Call the ShowDialog method to show the dialogbox.
            Dim UserClickedOK As Boolean = openFileDialog1.ShowDialog

            ' Process input if the user clicked OK.
            If UserClickedOK = True Then
                Dim backMeUp = MsgBox("Make a backup and then load the new content?", vbYesNo)
                Dim thing = openFileDialog1.FileName
                If thing.Length Then
                    thing = thing.Replace("\", "/")    ' because Opensim uses unix-like slashes, that's why

                    If backMeUp = vbYes Then
                        ConsoleCommand("alert CPU Intensive Backup Started{ENTER}")
                        ConsoleCommand("save oar --perm=CT " + """" + BackupPath() + "Backup_" + DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss") + ".oar" + """" + "{Enter}")
                    End If
                    ConsoleCommand("alert New content is loading..{ENTER}")
                    ConsoleCommand("load oar --force-terrain --force-parcels " + thing + "{ENTER}")
                    ConsoleCommand("alert New content just loaded." + "{ENTER}")
                    Me.Focus()
                End If
            End If
        Else
            Print("Opensim is not running. Cannot load the OAR file.")
        End If


    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PaintImage()
    End Sub

    Private Sub ShowHyperGridAddressToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowHyperGridAddressToolStripMenuItem.Click
        Print("Hypergrid address is http://" + My.Settings.PublicIP + ":" + My.Settings.HttpPort)
    End Sub

    Private Sub WebStatsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WebStatsToolStripMenuItem.Click
        If (Running) Then
            Dim webAddress As String = "http://127.0.0.1:" + My.Settings.HttpPort + "/SStats/"
            Process.Start(webAddress)
        Else
            Print("Opensim is not running. Cannot open the Statistics web page.")
        End If
    End Sub

    Private Sub SaveBackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveBackupToolStripMenuItem.Click
        If (Running) Then

            ChooseRegion()  '1.37

            Dim Message, title, defaultValue As String
            Dim myValue As Object
            ' Set prompt.
            Message = "Enter a name for your backup:"
            title = "Backup to OAR"
            defaultValue = "*.oar"   ' Set default value.

            ' Display message, title, and default value.
            myValue = InputBox(Message, title, defaultValue)
            ' If user has clicked Cancel, set myValue to defaultValue 
            If myValue.length = 0 Then Return
            ConsoleCommand("alert CPU Intensive Backup Started{ENTER}")
            ConsoleCommand("save oar " + """" + BackupPath() + myValue + """" + "{ENTER}")
            Me.Focus()
            Print("Saving " + myValue + " to " + BackupPath())
        Else
            Print("Opensim is not running. Cannot make a backup now.")
        End If
    End Sub

    Private Sub BumpProgress(bump As Integer)
        If ProgressBar1.Value < 100 Then
            ProgressBar1.Value = ProgressBar1.Value + bump
        End If
    End Sub
    Private Sub BumpProgress10()
        If ProgressBar1.Value < 90 Then
            ProgressBar1.Value = ProgressBar1.Value + 10
        Else
            ProgressBar1.Value = 100
        End If
    End Sub

    Private Function Stripqq(input As String) As String
        Return Replace(input, """", "")
    End Function

#End Region

#Region "IAROAR"
    Private Sub LoadInventoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadInventoryToolStripMenuItem.Click
        If Running Then
            ' Create an instance of the open file dialog box.
            Dim openFileDialog1 As OpenFileDialog = New OpenFileDialog

            ' Set filter options and filter index.
            openFileDialog1.InitialDirectory = """" + MyFolder + "/" + """"
            openFileDialog1.Filter = "Inventory IAR (*.iar)|*.iar|All Files (*.*)|*.*"
            openFileDialog1.FilterIndex = 1
            openFileDialog1.Multiselect = False

            ' Call the ShowDialog method to show the dialogbox.
            Dim UserClickedOK As Boolean = openFileDialog1.ShowDialog

            ' Process input if the user clicked OK.
            If UserClickedOK = True Then
                Dim thing = openFileDialog1.FileName
                If thing.Length Then
                    thing = thing.Replace("\", "/")    ' because Opensim uses unix-like slashes, that's why
                    LoadIARContent(thing)
                End If
            End If
        Else
            Print("Opensim is not running. Cannot load an IAR at this time.")
        End If

    End Sub

    Private Sub SaveInventoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveInventoryToolStripMenuItem.Click
        If (Running) Then
            Dim Message, title, defaultValue As String

            '''''''''''''''''''''''
            ' Object Name to back up
            Dim itemName As String
            ' Set prompt.
            Message = "Enter the object name ('/' will  backup everything, and '/Objects/box' will back up box in folder Objects) :"
            title = "Backup Name?"
            defaultValue = "/"   ' Set default value.

            ' Display message, title, and default value.
            itemName = InputBox(Message, title, defaultValue)
            ' If user has clicked Cancel, set myValue to defaultValue 
            If itemName.Length = 0 Then Return

            '''''''''''''''''''''''
            ' Name of the IAR
            Dim backupName As String
            Message = "Backup name? :"
            title = "Backup Name?"
            defaultValue = "backup.iar"   ' Set default value.

            ' Display message, title, and default value.
            backupName = InputBox(Message, title, defaultValue)
            ' If user has clicked Cancel, set myValue to defaultValue 
            If itemName.Length = 0 Then Return

            '''''''''''''''''''''''
            ' Avatar
            Dim Name As String
            Message = "Avatar FirstName and Lastname:"
            title = "FirstName LastName"
            defaultValue = ""   ' Set default value.

            ' Display message, title, and default value.
            Name = InputBox(Message, title, defaultValue)
            ' If user has clicked Cancel, set myValue to defaultValue 
            If Name.Length = 0 Then Return

            '''''''''''''''''''''''
            ' Password
            Dim Password As String
            Message = "Avatar's Password?:"
            title = "Password needed"
            defaultValue = ""   ' Set default value.

            ' Display message, title, and default value.
            Password = InputBox(Message, title, defaultValue)

            '''''''''''''''''''''''

            ConsoleCommand("alert CPU Intensive Backup Started{ENTER}")
            ConsoleCommand("save iar " + Name + " " + """" + itemName + """" + " " + Password + " " + """" + BackupPath() + backupName + """" + "{ENTER}")
            Me.Focus()
            Print("Saving " + backupName + " to " + BackupPath())
        Else
            Print("Opensim is not running. Cannot make a backup now.")
        End If
    End Sub

    Private Sub AllRegionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllRegionsToolStripMenuItem.Click
        If Not Running Then
            Print("Opensim is not running. Cannot load an IAR at this time.")
            Return
        End If

        ConsoleCommand("alert CPU Intensive Backup Started{ENTER}")

        Dim counter = 1
        Dim size = aRegion.GetUpperBound(0)
        While counter <= size
            Dim RegionName As String = aRegion(counter).RegionName
            ConsoleCommand("save oar --perm=CT " + """" + BackupPath() + RegionName + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss") + ".oar" + """" + "{Enter}")
            counter += 1
            Application.DoEvents()
        End While

    End Sub

    Private Sub ChooseRegion()
        If aRegion.GetUpperBound(0) <> 1 Then
            Dim Chooseform As New Chooser ' form for choosing a set of regions
            ' Show testDialog as a modal dialog and determine if DialogResult = OK.
            Chooseform.ShowDialog()
            Try
                ' Read the chosen sim name
                Dim chosen As String = Chooseform.ListBox1.SelectedItem.ToString()
                If chosen.Length Then
                    ConsoleCommand("change region " + """" + chosen + """" + "{ENTER}")
                End If
                Chooseform.Dispose()
            Catch
            End Try

        End If
    End Sub
    Private Sub LoadOARContent(thing As String)


        If Not isRunning Then
            Print("Opensim has to be started to load an OAR file.")
            Return
        End If

        ChooseRegion()

        Dim backMeUp = MsgBox("Make a backup first?", vbYesNo)
        Try
            Print("Opensimulator will load  " + thing + ".  This may take some time.")
            thing = thing.Replace("\", "/")    ' because Opensim uses unix-like slashes, that's why
            If backMeUp = vbYes Then
                ConsoleCommand("alert CPU Intensive Backup Started {ENTER}")
                ConsoleCommand("save oar " + """" + BackupPath() + "Backup_" + DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss") + ".oar" + """" + "{Enter}")
            End If
            ConsoleCommand("alert New content Is loading..{ENTER}")
            ConsoleCommand("load oar --force-terrain --force-parcels " + """" + thing + """" + "{ENTER}")
            ConsoleCommand("alert New content just loaded. {ENTER}")
            Me.Focus()
        Catch ex As Exception
            Log("Error: " + ex.Message)
        End Try
    End Sub
    Private Sub LoadIARContent(thing As String)

        If Running = False Then Return
        If Not isRunning Then
            Print("Opensim has to be started to load an IAR.")
            Return
        End If

        Dim user = InputBox("User name that will get this IAR?")
        Dim password = InputBox("Password for user " + user + "?")
        If user.Length And password.Length Then
            Try
                ConsoleCommand("load iar --merge " + user + " / " + password + " " + """" + thing + """" + "{ENTER}")
                ConsoleCommand("alert IAR content Is loaded{ENTER}")
                Me.Focus()
            Catch ex As Exception
                Log("Error:" + ex.Message)
            End Try

            Print("Opensim is loading your item. You will find it in your inventory in / soon.")
        Else
            Print("Load IAR cancelled - must use the full user name and password.")
        End If

    End Sub

    Private Sub TextBox1_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles TextBox1.DragDrop

        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each pathname In files
            pathname.Replace("\", "/")
            Dim extension = Path.GetExtension(pathname)
            extension = Mid(extension, 2, 5)
            If extension.ToLower = "iar" Then
                LoadIARContent(pathname)
            ElseIf extension.ToLower = "oar" Or extension.ToLower = "gz" Or extension.ToLower = "tgz" Then
                LoadOARContent(pathname)
            Else
                Print("Unrecognized file type:" + extension + ".  Drag and drop any OAR, GZ, TGZ, or IAR files to load them when the sim starts")
            End If
        Next

    End Sub

    Private Sub TextBox1_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles TextBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub


    Private Sub PictureBox1_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles PictureBox1.DragDrop

        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each pathname In files
            pathname.Replace("\", "/")
            Dim extension = Path.GetExtension(pathname)
            extension = Mid(extension, 2, 5)
            If extension.ToLower = "iar" Then
                LoadIARContent(pathname)
            ElseIf extension.ToLower = "oar" Or extension.ToLower = "gz" Or extension.ToLower = "tgz" Then
                LoadOARContent(pathname)
            Else
                Print("Unrecognized file type:" + extension + ".  Drag and drop any OAR, GZ, TGZ, or IAR files to load them when the sim starts")
            End If
        Next

    End Sub

    Private Sub PictureBox1_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles PictureBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub SetIAROARContent()
        IslandToolStripMenuItem.Visible = False
        ClothingInventoryToolStripMenuItem.Visible = False

        Print("Dreaming up new content for your sim")
        Dim oars As String = ""
        Try
            oars = client.DownloadString(Domain + "/Outworldz_Installer/Content.plx?type=OAR&r=" + Random())
        Catch ex As Exception
            Log("No Oars, dang, something is wrong with the Internet :-(")
            Return
        End Try

        Dim oarreader = New System.IO.StringReader(oars)
        Dim line As String = ""
        Dim ContentSeen As Boolean = False
        While Not ContentSeen
            line = oarreader.ReadLine()
            If line <> Nothing Then
                Log("Info:" + line)
                Dim OarMenu As New ToolStripMenuItem
                OarMenu.Text = line
                OarMenu.ToolTipText = "Cick to load this content"
                OarMenu.DisplayStyle = ToolStripItemDisplayStyle.Text
                AddHandler OarMenu.Click, New EventHandler(AddressOf OarClick)
                IslandToolStripMenuItem.Visible = True
                IslandToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {OarMenu})
                gContentAvailable = True
            Else
                ContentSeen = True
            End If
        End While
        BumpProgress10()

        Print("Dreaming up some clothes and items for your avatar")
        Dim iars As String = ""
        Try
            iars = client.DownloadString(Domain + "/Outworldz_Installer/Content.plx?type=IAR&r=" + Random())
        Catch ex As Exception
            Log("Info:No IARS, dang, something is wrong with the Internet :-(")
            Return
        End Try

        Dim iarreader = New System.IO.StringReader(iars)
        ContentSeen = False
        While Not ContentSeen
            line = iarreader.ReadLine()
            If line <> Nothing Then
                Log("Info:" + line)
                Dim IarMenu As New ToolStripMenuItem
                IarMenu.Text = line
                IarMenu.ToolTipText = "Click to load this content the next time the simulator is started"
                IarMenu.DisplayStyle = ToolStripItemDisplayStyle.Text
                AddHandler IarMenu.Click, New EventHandler(AddressOf IarClick)
                ClothingInventoryToolStripMenuItem.Visible = True
                ClothingInventoryToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {IarMenu})
                gContentAvailable = True
            Else
                ContentSeen = True
            End If
        End While
        MnuContent.Visible = True
        BumpProgress10()
    End Sub

    Private Sub OarClick(sender As Object, e As EventArgs)
        Dim File = Mid(sender.text, 1, InStr(sender.text, "|") - 2)
        File = Domain + "/Outworldz_Installer/OAR/" + File 'make a real URL
        LoadOARContent(File)
        sender.checked = True
    End Sub

    Private Sub IarClick(sender As Object, e As EventArgs)
        Dim file = Mid(sender.text, 1, InStr(sender.text, "|") - 2)
        file = Domain + "/Outworldz_Installer/IAR/" + file 'make a real URL
        LoadIARContent(file)
        sender.checked = True
        Print("Opensimulator will load " + file + ".  This may take time to load.")
    End Sub
#End Region

#Region "Updates"

    Private Sub CheckForUpdatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CHeckForUpdatesToolStripMenuItem.Click
        CheckForUpdates()
    End Sub
    Private Sub UpdaterCancel_Click(sender As Object, e As EventArgs) Handles UpdaterCancel.Click

        UpdaterGo.Visible = False
        UpdaterCancel.Visible = False
        My.Settings.SkipUpdateCheck = True
        Print("Update scan is off. You can still check for updates in the Help Menu.")

    End Sub

    Private Sub UpdaterGo_Click(sender As Object, e As EventArgs) Handles UpdaterGo.Click

        UpdaterGo.Enabled = False
        UpdaterCancel.Visible = False
        Dim fileloaded As String = Download()
        If (fileloaded.Length) Then
            Dim pUpdate As Process = New Process()
            Dim pi As ProcessStartInfo = New ProcessStartInfo()
            pi.Arguments = ""
            pi.FileName = """" + MyFolder + "\" + fileloaded + """"
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
            Print("Uh Oh!  The files I need could not be found online. The gnomes have absconded with them!   Please check later.")
            UpdaterGo.Visible = False
            UpdaterGo.Enabled = True
        End If

    End Sub
    Private Function Download() As String

        Dim fileName As String = "Updater.exe"

        Try
            My.Computer.FileSystem.DeleteFile(MyFolder + fileName)
        Catch
            Log("Warn:Could not delete " + fileName)
        End Try

        Try
            fileName = client.DownloadString(Domain + "/Outworldz_Installer/GetUpdater.plx?r=" + Random())
        Catch
            Return ""
        End Try

        Try
            Dim myWebClient As New WebClient()
            Print("Downloading new updater, this will take a moment")
            ' The DownloadFile() method downloads the Web resource and saves it into the current file-system folder.
            myWebClient.DownloadFile(Domain + "/Outworldz_Installer/" + fileName, fileName)
        Catch e As Exception
            Log("Warn:" + e.Message)
            Return ""
        End Try
        Return fileName

    End Function

    Sub CheckForUpdates()

        Dim Update As String = ""
        Dim isPortOpen As String = ""
        Dim Data As String = GetPostData()

        Try
            Update = client.DownloadString(Domain + "/Outworldz_Installer/Update.plx?Ver=" + Str(MyVersion) + Data)
        Catch ex As Exception
            Log("Dang:The Outworld web site is down")
        End Try
        If (Update = "") Then Update = "0"

        Try
            If Convert.ToSingle(Update) > Convert.ToSingle(MyVersion) Then
                Print("A dreamier version " + Update + " is available.")
                UpdaterGo.Visible = True
                UpdaterGo.Enabled = True
                UpdaterCancel.Visible = True
            Else
                Print("I am the dreamiest version available, at V " + MyVersion)
            End If
        Catch
        End Try
        BumpProgress10()

    End Sub

#End Region

#Region "Onlook"

    Private Sub Onlook()
        If Running = False Then Return
        If My.Settings.Onlook Then
            Print("Starting Onlook viewer")
            Dim pi As ProcessStartInfo = New ProcessStartInfo()
            pi.Arguments = ""
            pi.FileName = "C:\Program Files (x86)\Onlook\OnLookViewer.exe"
            pi.WindowStyle = ProcessWindowStyle.Normal
            pOnlook.StartInfo = pi
            Try
                pOnlook.Start()
            Catch ex As Exception
                Log("Error:Onlook failed to launch:" + ex.Message)
            End Try
        End If

    End Sub

    Private Sub SaveOnlookXMLData()

        ' setup Onlook
        If System.IO.File.Exists(xmlPath() + "\AppData\Roaming\Onlook\user_settings\settings_onlook.xml") Then
            My.Settings.ViewerInstalled = True
        End If

        If Not My.Settings.ViewerInstalled Then
            Log("Info:Onlook viewer is not installed")
            Return
        End If
        ' we have to change the viewer Grid settings if we are on localhost
        Print("Setting Grid Info...")


        Dim Opensim8XML As String = "<llsd>
    <array>
        <map>
        <key>default_grids_version</key>
            <integer>22</integer>
        </map>
        <map>
        <key>auto_update</key>
            <boolean>0</boolean>
        <key>gridname</key>
            <string>" + My.Settings.SimName + "</string>
        <key>gridnick</key>
            <string>" + My.Settings.SimName + "</string>
        <key>helperuri</key>
            <string>http://</string>
        <key>inventory_links</key>
            <boolean>0</boolean>
        <key>locked</key>
            <boolean>0</boolean>
        <key>loginpage</key>
            <string>" + Splashpage + "</string>
        <key>loginuri</key>
            <string>http://" + My.Settings.PublicIP + ":" + My.Settings.HttpPort + "/</string>
        <key>password</key>
            <string>http://" + My.Settings.PublicIP + My.Settings.HttpPort + "/wifi/forgotpassword</string>
        <key>platform</key>
            <string>OpenSim</string>
        <key>register</key>
        <key>render_compat</key>
            <boolean>1</boolean>
        <key>search</key>
            <string>http://search.metaverseink.com/opensim/results.jsp?</string>
        <key>support</key>
            <string />
        <key>website</key>
            <string />
        </map>
    </array>
</llsd>
"

        Try
            My.Computer.FileSystem.CopyFile(xmlPath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml", xmlPath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml.bak", True)
        Catch
            Log("Error:Failed to back up onlook XML")
        End Try

        Try
            My.Computer.FileSystem.DeleteFile(xmlPath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml")
            Using outputFile As New StreamWriter(xmlPath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml", True)
                outputFile.WriteLine(Opensim8XML)
                ' outputFile.Close()
            End Using

            'My.Computer.FileSystem.CopyFile(MyFolder & "\Viewer\Hypergrid.xml", xmlPath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml", True)
        Catch ex As Exception
            Log("Error:Failed to install onlook XML:" + ex.Message)
        End Try

    End Sub
    Private Sub RemoveGrid()

        ' restore backup - they may have changed it. Outworldzs is supposed to be simple. If they launch the viewer by itself, they can change grids
        Try
            My.Computer.FileSystem.CopyFile(xmlPath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml.bak", xmlPath() + "\AppData\Roaming\OnLook\user_settings\grids_sg1.xml", True)
        Catch ex As Exception
            Log("Error:failed to restore Onlook xml backup:" + ex.Message)
        End Try
    End Sub
    Private Function xmlPath() As String

        ' gets the path to the %APPDATA% folder on windows so we can seek out the Onlook folders
        Dim appData As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData
        Return Mid(appData, 1, InStr(appData, "AppData") - 1)
    End Function
#End Region

#Region "Diagnostics"

    Private Function CheckPort(ServerAddress As String, Port As String) As Boolean

        Dim iPort As Integer = Convert.ToInt16(Port)
        Dim ClientSocket As New TcpClient

        Try
            ClientSocket.Connect(ServerAddress, iPort)
        Catch ex As Exception
            Log("Info:Unable to connect to server:" + ex.Message)
            Return False
        End Try

        If ClientSocket.Connected Then
            Log("Info: port probe success on port " + Convert.ToString(iPort))
            ClientSocket.Close()
            Return True
        End If
        CheckPort = False

    End Function
    Public Function GetPubIP() As String

        If My.Settings.DnsName.Length Then
            BumpProgress10()
            My.Settings.PublicIP = My.Settings.DnsName
            My.Settings.Save()
            Return My.Settings.DnsName
        End If

        ' Set Public Port
        Try
            Dim ip As String = client.DownloadString("http://api.ipify.org/?r=" + Random())
            BumpProgress10()
            Log("Info:Public IP=" + My.Settings.PublicIP)
            Return ip
        Catch ex As Exception
            Print("Hmm, I cannot reach the Internet? Uh. Okay, continuing." + ex.Message)
            My.Settings.DiagFailed = True
            Log("Info:Public IP=" + "127.0.0.1")
        End Try
        BumpProgress10()
        Return "127.0.0.1"

    End Function
    Private Sub TestLoopback()

        Dim ws As NetServer = NetServer.getWebServer
        Log("Info:Starting Web Server")
        ws.StartServer()
        Sleep(1000)

        BumpProgress10()
        Dim result As String = ""
        Dim loopbacktest As String = "http://" + My.Settings.PublicIP + ":" + My.Settings.PublicPort + "/?_TestLoopback=" + Random()
        Try
            Log(loopbacktest)
            result = client.DownloadString(loopbacktest)
        Catch ex As Exception
            Log("Err:Loopback fail:" + result + ":" + ex.Message)
        End Try

        BumpProgress10()
        ws.StopWebServer()

        If result = "Test completed" And Not gFailDebug2 Then
            Log("Passed:" + result)
            My.Settings.LoopBackDiag = True
            My.Settings.Save()
        Else
            Log("Failed:" + result)
            Print("Router Loopback is disabled. See the Help section for 'Loopback' and how to enable it in Windows. Continuing...")
            My.Settings.LoopBackDiag = False
            My.Settings.PublicIP = "127.0.0.1"
            My.Settings.Save()
        End If

    End Sub

    Private Sub DiagnosticsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DiagnosticsToolStripMenuItem.Click

        If Running Then
            Print("Cannot run dignostics while Opensimulator is running. Click 'Stop' and try again.")
            Return
        End If
        ProgressBar1.Value = 0
        DoDiag()
        If My.Settings.DiagFailed = True Then
            Print("Hypergrid Diagnostics failed. These can be re-run at any time. See Help->Network Diagnostics', 'Loopback', and 'Port Forwards'")
        Else
            Print("Tests passed, Hypergrid should be working.")
        End If
        ProgressBar1.Value = 100

    End Sub
    Private Function ProbePublicPort() As Boolean

        Log("Info:Probe Public Port")
        Dim ip As String = GetPubIP()

        Dim ws As NetServer = NetServer.getWebServer
        Log("Info:Starting Web Server, public port is " + ip)
        ws.StartServer()
        Sleep(1000)
        BumpProgress10()

        Dim isPortOpen As String = ""
        Try
            ' collect some stats and test loopback with a HTTP_ GET to the webserver.
            ' Send unique, anonymous random ID, both of the versions of Opensim and this program, and the diagnostics test results 
            ' See my privacy policy at http://www.outworldz.com/privacy.htm

            Dim Data As String = GetPostData()
            Dim Url = Domain + "/cgi/probetest.plx?IP=" + ip + "&Port=" + My.Settings.PublicPort + Data + "/?r=" + Random()
            Log(Url)
            isPortOpen = client.DownloadString(Url)
        Catch ex As Exception
            Log("Dang:The Outworldz web site cannot find a path back")
            My.Settings.DiagFailed = True
        End Try

        BumpProgress10()
        ws.StopWebServer()
        BumpProgress10()

        If isPortOpen = "yes" And Not gFailDebug1 Then
            My.Settings.PublicIP = ip
            Log("Public IP set to " + ip)
            My.Settings.Save()
            Return True
        Else
            Log("Failed:" + isPortOpen)
            My.Settings.DiagFailed = True
            Print("Internet address " + My.Settings.PublicIP + ":" + My.Settings.PublicPort + " appears to not be forwarded to this machine in your router, so Hypergrid is not available. This can possibly be fixed by 'Port Forwards' in your router.  See Help->Port Forwards.")
            My.Settings.PublicIP = GetIPv4Address() ' failed, so try the machines address
            Log("IP set to " + My.Settings.PublicIP)
            Return False
        End If

    End Function
    Private Sub DoDiag()
        Print("Running Network Diagnostics, please wait")
        My.Settings.DiagFailed = False
        OpenPorts() ' Open router ports with uPnP
        If Not ProbePublicPort() Then ' see if Public loopback works
            TestLoopback()
        End If
        If My.Settings.DiagFailed Then
            ShowLog()
        Else
            NewDNSName()
        End If
        Log("Diagnostics set the Hypergrid address to " + My.Settings.PublicIP)

    End Sub

    Private Function GetIPv4Address() As String
        GetIPv4Address = String.Empty
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim IPList As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)

        For Each IPaddress As System.Net.IPAddress In IPList.AddressList
            If IPaddress.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork AndAlso IsPrivateIP(IPaddress.ToString()) Then
                GetIPv4Address = IPaddress.ToString()
            End If
        Next

    End Function

    ''' <summary>
    ''' Checks to see if an IP address is a local IP address.
    ''' </summary>
    ''' <param name="CheckIP">The IP address to check.</param>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Private Shared Function IsPrivateIP(ByVal CheckIP As String) As Boolean
        Dim Quad1, Quad2 As Integer

        Quad1 = CInt(CheckIP.Substring(0, CheckIP.IndexOf(".")))
        Quad2 = CInt(CheckIP.Substring(CheckIP.IndexOf(".") + 1).Substring(0, CheckIP.IndexOf(".")))
        Select Case Quad1
            Case 10
                Return True
            Case 172
                If Quad2 >= 16 And Quad2 <= 31 Then Return True
            Case 192
                If Quad2 = 168 Then Return True
        End Select
        Return False
    End Function

#End Region

#Region "PnP"

    Function OpenRouterPorts() As Boolean

        Log("Local ip seems to be " + UPNP.LocalIP)

        Try
            If Not MyUPnPMap.Exists(Convert.ToInt16(My.Settings.HttpPort), UPNP.Protocol.TCP) Then
                MyUPnPMap.Add(UPNP.LocalIP, Convert.ToInt16(My.Settings.HttpPort), UPNP.Protocol.TCP, "Opensim TCP grid port")
                Log("uPnp: Grid Port.TCP added")
            Else
                Log("uPnp: HttpPort.TCP " + My.Settings.HttpPort + " is already in uPnP")
            End If
            BumpProgress10()

            If Not MyUPnPMap.Exists(Convert.ToInt16(My.Settings.PublicPort), UPNP.Protocol.UDP) Then
                MyUPnPMap.Add(UPNP.LocalIP, Convert.ToInt16(My.Settings.PublicPort), UPNP.Protocol.UDP, "Opensim UDP Public")
                Log("uPnp: PublicPort.UDP added:")
            Else
                Log("uPnp: PublicPort.UDP " + My.Settings.PublicPort + " is already in uPnP")
            End If
            BumpProgress10()

            If Not MyUPnPMap.Exists(Convert.ToInt16(My.Settings.PublicPort), UPNP.Protocol.TCP) Then
                MyUPnPMap.Add(UPNP.LocalIP, Convert.ToInt16(My.Settings.PublicPort), UPNP.Protocol.TCP, "Opensim TCP Public")
                Log("uPnp: PublicPort.TCP added")
            Else
                Log("uPnp: PublicPort.TCP " + My.Settings.PublicPort + "    is already in uPnP")
            End If
            BumpProgress10()

            Dim counter = 1
            Dim size = aRegion.GetUpperBound(0)
            While counter <= size

                Dim RegionPort As Integer = aRegion(counter).RegionPort

                If Not MyUPnPMap.Exists(RegionPort, UPNP.Protocol.UDP) Then
                    MyUPnPMap.Add(UPNP.LocalIP, RegionPort, UPNP.Protocol.UDP, "Opensim UDP Region")
                    Log("uPnp: RegionPort.UDP Added:" + Convert.ToString(RegionPort))
                Else
                    Log("uPnp: RegionPort.UDP " + Convert.ToString(RegionPort) + " is already in uPnP")
                End If
                BumpProgress10()

                counter += 1
            End While

        Catch e As Exception
            Print("uPnP is not working or enabled in your router. Hypergrid access will require ports to be opened manually.")
            Log("uPnp: UPNP Exception caught:  " + e.Message)
            Return False
        End Try
        Return True 'successfully added
    End Function


    Private Function GetPostData() As String

        Dim SimVersion As String
        If (My.Settings.GridFolder = "Opensim") Then
            SimVersion = "0.8.2.1"
        Else
            SimVersion = "0.9.1"
        End If
        Dim UpNp As String = "Fail"
        If My.Settings.UPnPDiag Then
            UpNp = "Pass"
        End If
        Dim Loopb As String = "Fail"
        If My.Settings.LoopBackDiag Then
            Loopb = "Pass"
        End If
        Dim Pub As String = "No"
        If My.Settings.DNSPublic then
			Pub = "Yes"
		end if

        Dim data
        data = "&r=" + Machine _
            + "&V=" + MyVersion _
            + "&OV=" + SimVersion _
            + "&UpNp=" + UpNp _
            + "&Loop=" + Loopb _
			+ "&Public=" + Pub _
            + "&x=" + Random()
        Return data

    End Function

    Private Function OpenPorts() As Boolean

        'If Running = False Then Return True
        Print("The human is instructed to wait while I check out the router ...")
        Try
            If OpenRouterPorts() Then ' open uPNP port
                Log("uPnpOk")
                'Print("uPnP Ok")
                My.Settings.UPnPDiag = True
                My.Settings.Save()
                BumpProgress10()
                Return True
            Else
                Log("uPnP: fail")
                My.Settings.UPnPDiag = False
                My.Settings.Save()

                BumpProgress10()
                Return False
            End If
        Catch e As Exception
            Log("Error: UPNP Exception: " + e.Message)
            My.Settings.UPnPDiag = False
            My.Settings.Save()
            BumpProgress10()
            Return False
        End Try

    End Function

#End Region

#Region "MySQl"

    Private Sub RestoreDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreDatabaseToolStripMenuItem.Click

        If Running Then
            Print("Cannot restore when Opensim is running. Click [Stop] and try again.")
            Return
        End If
        StartMySQL()

        ' Create an instance of the open file dialog box.
        Dim openFileDialog1 As OpenFileDialog = New OpenFileDialog

        ' Set filter options and filter index.
        openFileDialog1.InitialDirectory = BackupPath()
        openFileDialog1.Filter = "MySqlDump (*.sql)|*.sql|All Files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.Multiselect = False

        ' Call the ShowDialog method to show the dialogbox.
        Dim UserClickedOK As Boolean = openFileDialog1.ShowDialog

        ' Process input if the user clicked OK.
        If UserClickedOK = True Then
            Dim thing = openFileDialog1.FileName
            If thing.Length Then

                Dim yesno = MsgBox("Are you sure?  Your database will re-loaded from the backup and all existing content lost.  Avatars, sims, inventory, all of it.", vbYesNo)
                If yesno = vbYes Then
                    thing = thing.Replace("\", "/")    ' because Opensim uses unix-like slashes, that's why

                    Try
                        My.Computer.FileSystem.DeleteFile(MyFolder & "\OutworldzFiles\mysql\bin\RestoreMysql.bat")
                    Catch
                    End Try
                    Try
                        Dim filename As String = MyFolder & "\OutworldzFiles\mysql\bin\RestoreMysql.bat"
                        Using outputFile As New StreamWriter(filename, True)
                            outputFile.WriteLine("@REM A program to restore Mysql from a backup" + vbCrLf _
                                    + "mysql -u root opensim < %1 " _
                                    + vbCrLf + "@pause" + vbCrLf)
                        End Using
                    Catch ex As Exception
                        Print("Failed to create restore file:" + ex.Message)
                        Return
                    End Try

                    Print("Starting restore - do not interrupt!")
                    Dim pMySqlRestore As Process = New Process()
                    Dim pi As ProcessStartInfo = New ProcessStartInfo()

                    pi.Arguments = thing
                    pi.WindowStyle = ProcessWindowStyle.Normal
                    pi.WorkingDirectory = MyFolder & "\OutworldzFiles\mysql\bin\"

                    pi.FileName = MyFolder & "\OutworldzFiles\mysql\bin\RestoreMysql.bat"
                    pMySqlRestore.StartInfo = pi
                    pMySqlRestore.Start()
                End If
            Else
                Print("Restore cancelled")
            End If
        End If
    End Sub

    Private Sub MysqlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MysqlToolStripMenuItem.Click

        StartMySQL()

        Try
            My.Computer.FileSystem.DeleteFile(MyFolder & "\OutworldzFiles\mysql\bin\BackupMysql.bat")
        Catch
        End Try
        Try
            Dim filename As String = MyFolder & "\OutworldzFiles\mysql\bin\BackupMysql.bat"
            Using outputFile As New StreamWriter(filename, True)

                Dim PathToBackup As String = BackupPath()
                PathToBackup = PathToBackup.Replace("\", "/")    ' because Opensim uses unix-like slashes, that's why
                outputFile.WriteLine("@REM A program to backup Mysql manually" + vbCrLf _
                                    + "mysqldump.exe --opt  -uroot --verbose opensim  > " _
                                    + PathToBackup + "Mysql_" + DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss") + ".sql" + """" _
                                    + vbCrLf + "@pause" + vbCrLf)
            End Using
        Catch ex As Exception
            Print("Failed to create backup:" + ex.Message)
            Return
        End Try

        Print("Starting Backup")
        Dim pMySqlBackup As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = ""
        pi.WindowStyle = ProcessWindowStyle.Normal
        pi.WorkingDirectory = MyFolder & "\OutworldzFiles\mysql\bin\"
        pi.FileName = MyFolder & "\OutworldzFiles\mysql\bin\BackupMysql.bat"
        pMySqlBackup.StartInfo = pi

        pMySqlBackup.Start()

    End Sub

    Private Function StartMySQL() As Boolean
        ' Start MySql in background.
        Dim StartValue = ProgressBar1.Value

        ' Check for MySql operation
        Dim Mysql = False
        ' wait for MySql to come up
        Mysql = CheckPort("127.0.0.1", My.Settings.MySqlPort)
        If Mysql Then
            BumpProgress10()

            Return True
        End If

        Print("Starting Database")

        ' SAVE INI file
        LoadIni(MyFolder & "\OutworldzFiles\mysql\my.ini", "#")
        SetIni("mysqld", "basedir", """" + gCurSlashDir + "/OutworldzFiles/Mysql" + """")
        SetIni("mysqld", "datadir", """" + gCurSlashDir + "/OutworldzFiles/Mysql/Data" + """")
        SetIni("mysqld", "port", My.Settings.MySqlPort)
        SetIni("client", "port", My.Settings.MySqlPort)
        SaveINI()

        ' create test program 
        ' slants the other way:
        Dim testProgram As String = MyFolder & "\OutworldzFiles\Mysql\bin\StartManually.bat"
        Try
            My.Computer.FileSystem.DeleteFile(testProgram)
        Catch ex As Exception
            Log("DeleteFile: " + ex.Message)
        End Try
        Try
            Using outputFile As New StreamWriter(testProgram, True)
                outputFile.WriteLine("@REM A program to run Mysql manually for troubleshooting." + vbCrLf _
                                     + "mysqld.exe --defaults-file=" + """" + gCurSlashDir + "/OutworldzFiles/mysql/my.ini" + """")
            End Using
        Catch ex As Exception
            Log("Error:StartManually" + ex.Message)
        End Try

        BumpProgress(1)

        ' Mysql was not running, so lets start it up.
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = "--defaults-file=" + """" + gCurSlashDir + "/OutworldzFiles/mysql/my.ini" + """"
        pi.WindowStyle = ProcessWindowStyle.Hidden
        pi.FileName = """" + MyFolder & "\OutworldzFiles\mysql\bin\mysqld.exe" + """"
        pMySql.StartInfo = pi
        pMySql.Start()


        ' wait for MySql to come up
        Mysql = CheckPort("127.0.0.1", My.Settings.MySqlPort)
        While Not Mysql

            BumpProgress(1)
            Application.DoEvents()

            Dim MysqlLog As String = """" + MyFolder + "\OutworldzFiles\mysql\data" + """"
            If ProgressBar1.Value = 100 Then ' about 30 seconds when it fails

                Dim yesno = MsgBox("The database did not start. Do you want to see the log file?", vbYesNo)
                If (yesno = vbYes) Then
                    Dim files() As String
                    files = Directory.GetFiles(MysqlLog, "*.err", SearchOption.TopDirectoryOnly)
                    For Each FileName As String In files
                        System.Diagnostics.Process.Start("wordpad.exe", FileName)
                    Next
                End If

                Buttons(StartButton)
                Return False
            End If

            ' check again
            Sleep(1000)
            Mysql = CheckPort("127.0.0.1", My.Settings.MySqlPort)
        End While
        Sleep(2000) ' hacky, but may work
        Return True
    End Function

    Private Sub StopMysql()

        Log("Info:using mysqladmin to close db")
        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = "-u root shutdown"
        pi.FileName = """" + MyFolder + "\OutworldzFiles\mysql\bin\mysqladmin.exe" + """"
        pi.WindowStyle = ProcessWindowStyle.Minimized
        p.StartInfo = pi
        Try
            p.Start()
            p.WaitForExit()
            p.Close()
        Catch ex As Exception
            Log("Error:mysqladmin failed to stop mysql:" + ex.Message)
        End Try

        Dim Mysql = CheckPort("127.0.0.1", My.Settings.MySqlPort)
        If Mysql Then
            Sleep(4000)
            Try
                pMySql.Close()
            Catch ex2 As Exception
                Log("Error:Process pMySql.Close() " + ex2.Message)
            End Try
        End If

        '   Mysql = CheckPort("127.0.0.1", My.Settings.MySqlPort)
        '   If Not Mysql Then
        '  For Each stuckP As Process In System.Diagnostics.Process.GetProcessesByName("mysqld")
        ' 'stuckP.Kill()
        ' Log("Warn:Forced to Zap mySQL")
        ' Next
        ' End If

    End Sub

#End Region

#Region "DNS"
    Public Sub RegisterDNS()

        If My.Settings.DnsName = String.Empty Then
            Return
        End If

        Dim client As New System.Net.WebClient
        Dim Checkname As String = String.Empty
        Dim pub As String
        If My.Settings.DNSPublic Then
            pub = "1"
        Else
            pub = "0"
        End If
        Try
            Log("Checking DNS name " + My.Settings.DnsName)
            Checkname = client.DownloadString("http://outworldz.net/dns.plx/?GridName=" + My.Settings.DnsName + "&Public=" + pub + "&r=" + Random())
        Catch ex As Exception
            Log("Warn:Cannot check the DNS Name" + ex.Message)
        End Try

        DoGetHostAddresses(My.Settings.DnsName)
        BumpProgress10()
    End Sub

    Public Function DoGetHostAddresses(hostName As [String]) As String

        Dim ips As IPAddress()
        Try
            ips = Dns.GetHostAddresses(hostName)
            Dim index As Integer
            For index = 0 To ips.Length - 1
                Debug.Print(ips(index).ToString())
                Dim str = ips(index).ToString()
                Return str
            Next index

        Catch ex As Exception
            Log("Warn:Unable to resolve name:" + ex.Message)
        End Try
        Return String.Empty

    End Function
    Public Function GetNewDnsName() As String

        Dim client As New System.Net.WebClient
        Dim Checkname As String = String.Empty
        Try
            Checkname = client.DownloadString("http://outworldz.net/getnewname.plx/?r=" + Random())
        Catch ex As Exception
            Log("Warn:Cannot get new name:" + ex.Message)
        End Try
        Return Checkname
    End Function

    Public Function RegisterName(name As String) As String
        Dim pub As String
        Dim Checkname As String = String.Empty
        If My.Settings.DNSPublic Then
            pub = "1"
        Else
            pub = "0"
        End If
        Try
            Checkname = client.DownloadString("http://outworldz.net/dns.plx/?GridName=" + name + "&Public=" + pub + "&r=" + Random())
        Catch ex As Exception
            Log("Warn:Cannot check the DNS Name" + ex.Message)
        End Try
        If Checkname = "NEW" Or Checkname = "UPDATED" Then
            Return name
        End If
        Return ""
    End Function
    Private Sub NewDNSName()
        If My.Settings.DnsName = "" Then
            Dim newname = GetNewDnsName()
            If newname <> "" Then
                If RegisterName(newname) <> "" Then
                    BumpProgress10()
                    My.Settings.DnsName = newname
                    My.Settings.Save()
                    MsgBox("Your system's name has been set to " + newname + ". You can change the name in the Advanced menu at any time")
                End If
            End If
            BumpProgress10()
        End If
    End Sub



#End Region

End Class
