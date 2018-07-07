<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            If disposing AndAlso MyUPnpMap IsNot Nothing Then
                MyUPnpMap.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.WebBrowser2 = New System.Windows.Forms.WebBrowser()
        Me.StopButton = New System.Windows.Forms.Button()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.InstallButton = New System.Windows.Forms.Button()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsoleToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHide = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdvancedSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowHyperGridAddressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ConsoleCOmmandsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CommonConsoleCommandsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendAlertToAllUsersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DebugToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.All = New System.Windows.Forms.ToolStripMenuItem()
        Me.Debug = New System.Windows.Forms.ToolStripMenuItem()
        Me.Info = New System.Windows.Forms.ToolStripMenuItem()
        Me.Warn = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fatal1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Off1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewWebUI = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoopBackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CHeckForUpdatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearCachesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DiagnosticsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MnuContent = New System.Windows.Forms.ToolStripMenuItem()
        Me.IslandToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClothingInventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoreContentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BackupRestoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackupDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestoreDatabaseToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OARToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadRegionOarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveRegionOARToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllTheRegionsOarsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IARToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadInventoryIARToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveInventoryIARToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WebBrowser3 = New System.Windows.Forms.WebBrowser()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.BusyButton = New System.Windows.Forms.Button()
        Me.UpdaterGo = New System.Windows.Forms.Button()
        Me.UpdaterCancel = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.TextBox1 = New System.Windows.Forms.RichTextBox()
        Me.LogButton = New System.Windows.Forms.Button()
        Me.IgnoreButton = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(215, 341)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(105, 53)
        Me.WebBrowser1.TabIndex = 2
        '
        'WebBrowser2
        '
        Me.WebBrowser2.Location = New System.Drawing.Point(53, 341)
        Me.WebBrowser2.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser2.Name = "WebBrowser2"
        Me.WebBrowser2.Size = New System.Drawing.Size(125, 53)
        Me.WebBrowser2.TabIndex = 8
        '
        'StopButton
        '
        Me.StopButton.Location = New System.Drawing.Point(232, 0)
        Me.StopButton.Name = "StopButton"
        Me.StopButton.Size = New System.Drawing.Size(63, 23)
        Me.StopButton.TabIndex = 17
        Me.StopButton.Text = "Stop"
        Me.StopButton.UseVisualStyleBackColor = True
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(232, 0)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(63, 23)
        Me.StartButton.TabIndex = 16
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'InstallButton
        '
        Me.InstallButton.Location = New System.Drawing.Point(232, 0)
        Me.InstallButton.Name = "InstallButton"
        Me.InstallButton.Size = New System.Drawing.Size(63, 23)
        Me.InstallButton.TabIndex = 15
        Me.InstallButton.Text = "Install"
        Me.InstallButton.UseVisualStyleBackColor = True
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExit})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(92, 22)
        Me.mnuExit.Text = "Exit"
        '
        'mnuSettings
        '
        Me.mnuSettings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegionsToolStripMenuItem, Me.ConsoleToolStripMenuItem1, Me.AdvancedSettingsToolStripMenuItem})
        Me.mnuSettings.Name = "mnuSettings"
        Me.mnuSettings.Size = New System.Drawing.Size(61, 20)
        Me.mnuSettings.Text = "Settings"
        '
        'RegionsToolStripMenuItem
        '
        Me.RegionsToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.server_gWSCLient
        Me.RegionsToolStripMenuItem.Name = "RegionsToolStripMenuItem"
        Me.RegionsToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.RegionsToolStripMenuItem.Text = "Regions"
        '
        'ConsoleToolStripMenuItem1
        '
        Me.ConsoleToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHide, Me.mnuShow})
        Me.ConsoleToolStripMenuItem1.Image = Global.Outworldz.My.Resources.Resources.window_add
        Me.ConsoleToolStripMenuItem1.Name = "ConsoleToolStripMenuItem1"
        Me.ConsoleToolStripMenuItem1.Size = New System.Drawing.Size(122, 22)
        Me.ConsoleToolStripMenuItem1.Text = "Consoles"
        Me.ConsoleToolStripMenuItem1.ToolTipText = "The Opensim Dos Box can be minimized automatically"
        '
        'mnuHide
        '
        Me.mnuHide.Checked = True
        Me.mnuHide.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuHide.Name = "mnuHide"
        Me.mnuHide.Size = New System.Drawing.Size(103, 22)
        Me.mnuHide.Text = "Hide"
        '
        'mnuShow
        '
        Me.mnuShow.Name = "mnuShow"
        Me.mnuShow.Size = New System.Drawing.Size(103, 22)
        Me.mnuShow.Text = "Show"
        '
        'AdvancedSettingsToolStripMenuItem
        '
        Me.AdvancedSettingsToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.earth_network
        Me.AdvancedSettingsToolStripMenuItem.Name = "AdvancedSettingsToolStripMenuItem"
        Me.AdvancedSettingsToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.AdvancedSettingsToolStripMenuItem.Text = "Settings"
        Me.AdvancedSettingsToolStripMenuItem.ToolTipText = "Deep stuff."
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowHyperGridAddressToolStripMenuItem, Me.ToolStripSeparator1, Me.ConsoleCOmmandsToolStripMenuItem1, Me.CommonConsoleCommandsToolStripMenuItem, Me.ViewWebUI, Me.LoopBackToolStripMenuItem, Me.ToolStripMenuItem1, Me.ToolStripSeparator2, Me.CHeckForUpdatesToolStripMenuItem, Me.CheckDatabaseToolStripMenuItem, Me.ClearCachesToolStripMenuItem, Me.DiagnosticsToolStripMenuItem, Me.ToolStripMenuItem2, Me.mnuAbout})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'ShowHyperGridAddressToolStripMenuItem
        '
        Me.ShowHyperGridAddressToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.window_environment
        Me.ShowHyperGridAddressToolStripMenuItem.Name = "ShowHyperGridAddressToolStripMenuItem"
        Me.ShowHyperGridAddressToolStripMenuItem.Size = New System.Drawing.Size(240, 26)
        Me.ShowHyperGridAddressToolStripMenuItem.Text = "Show HyperGrid Address"
        Me.ShowHyperGridAddressToolStripMenuItem.ToolTipText = "You can give this address out to people and they can visit your grid"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(237, 6)
        '
        'ConsoleCOmmandsToolStripMenuItem1
        '
        Me.ConsoleCOmmandsToolStripMenuItem1.Image = Global.Outworldz.My.Resources.Resources.document_view
        Me.ConsoleCOmmandsToolStripMenuItem1.Name = "ConsoleCOmmandsToolStripMenuItem1"
        Me.ConsoleCOmmandsToolStripMenuItem1.Size = New System.Drawing.Size(240, 26)
        Me.ConsoleCOmmandsToolStripMenuItem1.Text = "View Console Commands"
        '
        'CommonConsoleCommandsToolStripMenuItem
        '
        Me.CommonConsoleCommandsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SendAlertToAllUsersToolStripMenuItem, Me.DebugToolStripMenuItem})
        Me.CommonConsoleCommandsToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.box_new
        Me.CommonConsoleCommandsToolStripMenuItem.Name = "CommonConsoleCommandsToolStripMenuItem"
        Me.CommonConsoleCommandsToolStripMenuItem.Size = New System.Drawing.Size(240, 26)
        Me.CommonConsoleCommandsToolStripMenuItem.Text = "Common Console Commands"
        '
        'SendAlertToAllUsersToolStripMenuItem
        '
        Me.SendAlertToAllUsersToolStripMenuItem.Name = "SendAlertToAllUsersToolStripMenuItem"
        Me.SendAlertToAllUsersToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.SendAlertToAllUsersToolStripMenuItem.Text = "Send Alert to All users"
        '
        'DebugToolStripMenuItem
        '
        Me.DebugToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.All, Me.Debug, Me.Info, Me.Warn, Me.ErrorToolStripMenuItem, Me.Fatal1, Me.Off1})
        Me.DebugToolStripMenuItem.Name = "DebugToolStripMenuItem"
        Me.DebugToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.DebugToolStripMenuItem.Text = "Set Debug Level"
        '
        'All
        '
        Me.All.Name = "All"
        Me.All.Size = New System.Drawing.Size(152, 22)
        Me.All.Text = "All"
        '
        'Debug
        '
        Me.Debug.Name = "Debug"
        Me.Debug.Size = New System.Drawing.Size(152, 22)
        Me.Debug.Text = "Debug"
        '
        'Info
        '
        Me.Info.Name = "Info"
        Me.Info.Size = New System.Drawing.Size(152, 22)
        Me.Info.Text = "Info"
        '
        'Warn
        '
        Me.Warn.Name = "Warn"
        Me.Warn.Size = New System.Drawing.Size(152, 22)
        Me.Warn.Text = "Warn"
        '
        'ErrorToolStripMenuItem
        '
        Me.ErrorToolStripMenuItem.Name = "ErrorToolStripMenuItem"
        Me.ErrorToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ErrorToolStripMenuItem.Text = "Error"
        '
        'Fatal1
        '
        Me.Fatal1.Name = "Fatal1"
        Me.Fatal1.Size = New System.Drawing.Size(152, 22)
        Me.Fatal1.Text = "Fatal"
        '
        'Off1
        '
        Me.Off1.Name = "Off1"
        Me.Off1.Size = New System.Drawing.Size(152, 22)
        Me.Off1.Text = "Off"
        '
        'ViewWebUI
        '
        Me.ViewWebUI.Image = Global.Outworldz.My.Resources.Resources.document_view
        Me.ViewWebUI.Name = "ViewWebUI"
        Me.ViewWebUI.Size = New System.Drawing.Size(240, 26)
        Me.ViewWebUI.Text = "View Web Interface"
        Me.ViewWebUI.ToolTipText = "The WIfi Interface can be used to add new users"
        '
        'LoopBackToolStripMenuItem
        '
        Me.LoopBackToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.refresh
        Me.LoopBackToolStripMenuItem.Name = "LoopBackToolStripMenuItem"
        Me.LoopBackToolStripMenuItem.Size = New System.Drawing.Size(240, 26)
        Me.LoopBackToolStripMenuItem.Text = "Help on LoopBack "
        Me.LoopBackToolStripMenuItem.ToolTipText = "How to fix Loopback on Windows"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = Global.Outworldz.My.Resources.Resources.document_connection
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(240, 26)
        Me.ToolStripMenuItem1.Text = "Help on Port Forwarding"
        Me.ToolStripMenuItem1.ToolTipText = "Web Help for Port Forwarding"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(237, 6)
        '
        'CHeckForUpdatesToolStripMenuItem
        '
        Me.CHeckForUpdatesToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.download
        Me.CHeckForUpdatesToolStripMenuItem.Name = "CHeckForUpdatesToolStripMenuItem"
        Me.CHeckForUpdatesToolStripMenuItem.Size = New System.Drawing.Size(240, 26)
        Me.CHeckForUpdatesToolStripMenuItem.Text = "Check for Updates"
        '
        'CheckDatabaseToolStripMenuItem
        '
        Me.CheckDatabaseToolStripMenuItem.Image = CType(resources.GetObject("CheckDatabaseToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CheckDatabaseToolStripMenuItem.Name = "CheckDatabaseToolStripMenuItem"
        Me.CheckDatabaseToolStripMenuItem.Size = New System.Drawing.Size(240, 26)
        Me.CheckDatabaseToolStripMenuItem.Text = "Check Database"
        Me.CheckDatabaseToolStripMenuItem.ToolTipText = "Repairs corrupt MySQL table"
        '
        'ClearCachesToolStripMenuItem
        '
        Me.ClearCachesToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.exit_icon
        Me.ClearCachesToolStripMenuItem.Name = "ClearCachesToolStripMenuItem"
        Me.ClearCachesToolStripMenuItem.Size = New System.Drawing.Size(240, 26)
        Me.ClearCachesToolStripMenuItem.Text = "Clear Server Caches"
        '
        'DiagnosticsToolStripMenuItem
        '
        Me.DiagnosticsToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.server_gWSCLient
        Me.DiagnosticsToolStripMenuItem.Name = "DiagnosticsToolStripMenuItem"
        Me.DiagnosticsToolStripMenuItem.Size = New System.Drawing.Size(240, 26)
        Me.DiagnosticsToolStripMenuItem.Text = "Network Diagnostics"
        Me.DiagnosticsToolStripMenuItem.ToolTipText = "Re-Run the installation diagnostics"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = Global.Outworldz.My.Resources.Resources.earth_network
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(240, 26)
        Me.ToolStripMenuItem2.Text = "Port/UPnp Setup"
        '
        'mnuAbout
        '
        Me.mnuAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.mnuAbout.Image = Global.Outworldz.My.Resources.Resources.question_and_answer
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Size = New System.Drawing.Size(240, 26)
        Me.mnuAbout.Text = "About"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.mnuSettings, Me.MnuContent, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(320, 24)
        Me.MenuStrip1.TabIndex = 21
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MnuContent
        '
        Me.MnuContent.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IslandToolStripMenuItem, Me.ClothingInventoryToolStripMenuItem, Me.MoreContentToolStripMenuItem, Me.ToolStripSeparator3, Me.BackupRestoreToolStripMenuItem, Me.OARToolStripMenuItem, Me.IARToolStripMenuItem})
        Me.MnuContent.Name = "MnuContent"
        Me.MnuContent.Size = New System.Drawing.Size(62, 20)
        Me.MnuContent.Text = "Content"
        '
        'IslandToolStripMenuItem
        '
        Me.IslandToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.box_tall
        Me.IslandToolStripMenuItem.Name = "IslandToolStripMenuItem"
        Me.IslandToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.IslandToolStripMenuItem.Text = "Load Free Dreamworld OAR"
        Me.IslandToolStripMenuItem.ToolTipText = "OAR files are backups of entire Islands"
        '
        'ClothingInventoryToolStripMenuItem
        '
        Me.ClothingInventoryToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.user1_into
        Me.ClothingInventoryToolStripMenuItem.Name = "ClothingInventoryToolStripMenuItem"
        Me.ClothingInventoryToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.ClothingInventoryToolStripMenuItem.Text = "Load Free Avatar Parts"
        Me.ClothingInventoryToolStripMenuItem.ToolTipText = "IAR files are backups of inventory items"
        '
        'MoreContentToolStripMenuItem
        '
        Me.MoreContentToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.download
        Me.MoreContentToolStripMenuItem.Name = "MoreContentToolStripMenuItem"
        Me.MoreContentToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.MoreContentToolStripMenuItem.Text = "More Free Islands and Parts"
        Me.MoreContentToolStripMenuItem.ToolTipText = "Outworldz has free DLC"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(217, 6)
        '
        'BackupRestoreToolStripMenuItem
        '
        Me.BackupRestoreToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BackupDatabaseToolStripMenuItem, Me.RestoreDatabaseToolStripMenuItem1})
        Me.BackupRestoreToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.disk_blue
        Me.BackupRestoreToolStripMenuItem.Name = "BackupRestoreToolStripMenuItem"
        Me.BackupRestoreToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.BackupRestoreToolStripMenuItem.Text = "Database Backup/Restore"
        '
        'BackupDatabaseToolStripMenuItem
        '
        Me.BackupDatabaseToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.disk_blue
        Me.BackupDatabaseToolStripMenuItem.Name = "BackupDatabaseToolStripMenuItem"
        Me.BackupDatabaseToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.BackupDatabaseToolStripMenuItem.Text = "Backup Databases"
        '
        'RestoreDatabaseToolStripMenuItem1
        '
        Me.RestoreDatabaseToolStripMenuItem1.Image = Global.Outworldz.My.Resources.Resources.cube_blue
        Me.RestoreDatabaseToolStripMenuItem1.Name = "RestoreDatabaseToolStripMenuItem1"
        Me.RestoreDatabaseToolStripMenuItem1.Size = New System.Drawing.Size(169, 22)
        Me.RestoreDatabaseToolStripMenuItem1.Text = "Restore Database"
        '
        'OARToolStripMenuItem
        '
        Me.OARToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadRegionOarToolStripMenuItem, Me.SaveRegionOARToolStripMenuItem, Me.AllTheRegionsOarsToolStripMenuItem})
        Me.OARToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.disk_green
        Me.OARToolStripMenuItem.Name = "OARToolStripMenuItem"
        Me.OARToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.OARToolStripMenuItem.Text = "OAR"
        '
        'LoadRegionOarToolStripMenuItem
        '
        Me.LoadRegionOarToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.data
        Me.LoadRegionOarToolStripMenuItem.Name = "LoadRegionOarToolStripMenuItem"
        Me.LoadRegionOarToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.LoadRegionOarToolStripMenuItem.Text = "Load Region OAR"
        '
        'SaveRegionOARToolStripMenuItem
        '
        Me.SaveRegionOARToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.disk_green
        Me.SaveRegionOARToolStripMenuItem.Name = "SaveRegionOARToolStripMenuItem"
        Me.SaveRegionOARToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.SaveRegionOARToolStripMenuItem.Text = "Save Region OAR"
        '
        'AllTheRegionsOarsToolStripMenuItem
        '
        Me.AllTheRegionsOarsToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.disk_green
        Me.AllTheRegionsOarsToolStripMenuItem.Name = "AllTheRegionsOarsToolStripMenuItem"
        Me.AllTheRegionsOarsToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.AllTheRegionsOarsToolStripMenuItem.Text = "All Regions => OARs"
        '
        'IARToolStripMenuItem
        '
        Me.IARToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadInventoryIARToolStripMenuItem, Me.SaveInventoryIARToolStripMenuItem})
        Me.IARToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.disk_yellow
        Me.IARToolStripMenuItem.Name = "IARToolStripMenuItem"
        Me.IARToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.IARToolStripMenuItem.Text = "IAR"
        '
        'LoadInventoryIARToolStripMenuItem
        '
        Me.LoadInventoryIARToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.data
        Me.LoadInventoryIARToolStripMenuItem.Name = "LoadInventoryIARToolStripMenuItem"
        Me.LoadInventoryIARToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.LoadInventoryIARToolStripMenuItem.Text = "Load Inventory IAR"
        '
        'SaveInventoryIARToolStripMenuItem
        '
        Me.SaveInventoryIARToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.disk_yellow
        Me.SaveInventoryIARToolStripMenuItem.Name = "SaveInventoryIARToolStripMenuItem"
        Me.SaveInventoryIARToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.SaveInventoryIARToolStripMenuItem.Text = "Save Inventory IAR"
        '
        'WebBrowser3
        '
        Me.WebBrowser3.Location = New System.Drawing.Point(339, 341)
        Me.WebBrowser3.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser3.Name = "WebBrowser3"
        Me.WebBrowser3.Size = New System.Drawing.Size(105, 53)
        Me.WebBrowser3.TabIndex = 23
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(15, 30)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(280, 13)
        Me.ProgressBar1.TabIndex = 24
        '
        'BusyButton
        '
        Me.BusyButton.Location = New System.Drawing.Point(232, 1)
        Me.BusyButton.Name = "BusyButton"
        Me.BusyButton.Size = New System.Drawing.Size(63, 23)
        Me.BusyButton.TabIndex = 18
        Me.BusyButton.Text = "Busy"
        Me.BusyButton.UseVisualStyleBackColor = True
        '
        'UpdaterGo
        '
        Me.UpdaterGo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpdaterGo.Location = New System.Drawing.Point(62, 169)
        Me.UpdaterGo.Name = "UpdaterGo"
        Me.UpdaterGo.Size = New System.Drawing.Size(115, 30)
        Me.UpdaterGo.TabIndex = 25
        Me.UpdaterGo.Text = "Update Available"
        Me.UpdaterGo.UseVisualStyleBackColor = True
        '
        'UpdaterCancel
        '
        Me.UpdaterCancel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpdaterCancel.Location = New System.Drawing.Point(200, 169)
        Me.UpdaterCancel.Name = "UpdaterCancel"
        Me.UpdaterCancel.Size = New System.Drawing.Size(51, 30)
        Me.UpdaterCancel.TabIndex = 26
        Me.UpdaterCancel.Text = "Skip"
        Me.UpdaterCancel.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog2"
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(12, 49)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(296, 150)
        Me.TextBox1.TabIndex = 29
        Me.TextBox1.Text = ""
        '
        'LogButton
        '
        Me.LogButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogButton.Location = New System.Drawing.Point(62, 169)
        Me.LogButton.Name = "LogButton"
        Me.LogButton.Size = New System.Drawing.Size(115, 30)
        Me.LogButton.TabIndex = 30
        Me.LogButton.Text = "Show Log"
        Me.LogButton.UseVisualStyleBackColor = True
        '
        'IgnoreButton
        '
        Me.IgnoreButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IgnoreButton.Location = New System.Drawing.Point(183, 169)
        Me.IgnoreButton.Name = "IgnoreButton"
        Me.IgnoreButton.Size = New System.Drawing.Size(85, 30)
        Me.IgnoreButton.TabIndex = 31
        Me.IgnoreButton.Text = "Ignore"
        Me.IgnoreButton.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.ErrorImage = Global.Outworldz.My.Resources.Resources.wp_51
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(0, 30)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(320, 180)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 27
        Me.PictureBox1.TabStop = False
        '
        'Form1
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(320, 206)
        Me.Controls.Add(Me.IgnoreButton)
        Me.Controls.Add(Me.LogButton)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.UpdaterGo)
        Me.Controls.Add(Me.UpdaterCancel)
        Me.Controls.Add(Me.WebBrowser3)
        Me.Controls.Add(Me.BusyButton)
        Me.Controls.Add(Me.StopButton)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.InstallButton)
        Me.Controls.Add(Me.WebBrowser2)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(336, 245)
        Me.MinimumSize = New System.Drawing.Size(336, 245)
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Outworldz DreamGrid"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents WebBrowser2 As System.Windows.Forms.WebBrowser
    Friend WithEvents BusyButton As System.Windows.Forms.Button
    Friend WithEvents StopButton As System.Windows.Forms.Button
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents InstallButton As System.Windows.Forms.Button
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuExit As ToolStripMenuItem
    Friend WithEvents mnuSettings As ToolStripMenuItem
    Friend WithEvents ConsoleToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents mnuHide As ToolStripMenuItem
    Friend WithEvents mnuShow As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuAbout As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents WebBrowser3 As WebBrowser
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ViewWebUI As ToolStripMenuItem
    Friend WithEvents MnuContent As ToolStripMenuItem
    Friend WithEvents IslandToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClothingInventoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MensClothingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FemaleClothingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoopBackToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MoreContentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AdvancedSettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CHeckForUpdatesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DiagnosticsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdaterGo As Button
    Friend WithEvents UpdaterCancel As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents OpenFileDialog2 As OpenFileDialog
    Friend WithEvents CheckDatabaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShowHyperGridAddressToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TextBox1 As RichTextBox
    Friend WithEvents LogButton As Button
    Friend WithEvents IgnoreButton As Button
    Friend WithEvents ConsoleCOmmandsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents RegionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BackupRestoreToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BackupDatabaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RestoreDatabaseToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents OARToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveRegionOARToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoadRegionOarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IARToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoadInventoryIARToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveInventoryIARToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ClearCachesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllTheRegionsOarsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CommonConsoleCommandsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SendAlertToAllUsersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DebugToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents All As ToolStripMenuItem
    Friend WithEvents Debug As ToolStripMenuItem
    Friend WithEvents Info As ToolStripMenuItem
    Friend WithEvents Warn As ToolStripMenuItem
    Friend WithEvents ErrorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Fatal1 As ToolStripMenuItem
    Friend WithEvents Off1 As ToolStripMenuItem
End Class
