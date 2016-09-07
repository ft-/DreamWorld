<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.Label = New System.Windows.Forms.Label()
        Me.WebBrowser2 = New System.Windows.Forms.WebBrowser()
        Me.WebBrowser3 = New System.Windows.Forms.WebBrowser()
        Me.BusyButton = New System.Windows.Forms.Button()
        Me.StopButton = New System.Windows.Forms.Button()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.InstallButton = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsoleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHide = New System.Windows.Forms.ToolStripMenuItem()
        Me.EasyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEasy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFull = New System.Windows.Forms.ToolStripMenuItem()
        Me.AvatarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuVisible = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInvisible = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLogin = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
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
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.BackColor = System.Drawing.Color.Black
        Me.Label.ForeColor = System.Drawing.Color.White
        Me.Label.Location = New System.Drawing.Point(12, 279)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(0, 13)
        Me.Label.TabIndex = 6
        '
        'WebBrowser2
        '
        Me.WebBrowser2.Location = New System.Drawing.Point(53, 341)
        Me.WebBrowser2.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser2.Name = "WebBrowser2"
        Me.WebBrowser2.Size = New System.Drawing.Size(125, 53)
        Me.WebBrowser2.TabIndex = 8
        '
        'WebBrowser3
        '
        Me.WebBrowser3.Location = New System.Drawing.Point(2, 57)
        Me.WebBrowser3.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser3.Name = "WebBrowser3"
        Me.WebBrowser3.ScriptErrorsSuppressed = True
        Me.WebBrowser3.ScrollBarsEnabled = False
        Me.WebBrowser3.Size = New System.Drawing.Size(400, 270)
        Me.WebBrowser3.TabIndex = 14
        Me.WebBrowser3.Url = New System.Uri("http://www.outworldz.com/DreamWorld/Home.htm", System.UriKind.Absolute)
        '
        'BusyButton
        '
        Me.BusyButton.Location = New System.Drawing.Point(201, 28)
        Me.BusyButton.Name = "BusyButton"
        Me.BusyButton.Size = New System.Drawing.Size(75, 23)
        Me.BusyButton.TabIndex = 18
        Me.BusyButton.Text = "Busy"
        Me.BusyButton.UseVisualStyleBackColor = True
        '
        'StopButton
        '
        Me.StopButton.Location = New System.Drawing.Point(303, 28)
        Me.StopButton.Name = "StopButton"
        Me.StopButton.Size = New System.Drawing.Size(75, 23)
        Me.StopButton.TabIndex = 17
        Me.StopButton.Text = "Stop"
        Me.StopButton.UseVisualStyleBackColor = True
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(105, 28)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(75, 23)
        Me.StartButton.TabIndex = 16
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'InstallButton
        '
        Me.InstallButton.Location = New System.Drawing.Point(24, 27)
        Me.InstallButton.Name = "InstallButton"
        Me.InstallButton.Size = New System.Drawing.Size(75, 23)
        Me.InstallButton.TabIndex = 15
        Me.InstallButton.Text = "Install"
        Me.InstallButton.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ConsoleToolStripMenuItem, Me.EasyToolStripMenuItem, Me.AvatarToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(402, 24)
        Me.MenuStrip1.TabIndex = 21
        Me.MenuStrip1.Text = "MenuStrip1"
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
        'ConsoleToolStripMenuItem
        '
        Me.ConsoleToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuShow, Me.mnuHide})
        Me.ConsoleToolStripMenuItem.Name = "ConsoleToolStripMenuItem"
        Me.ConsoleToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.ConsoleToolStripMenuItem.Text = "Console"
        '
        'mnuShow
        '
        Me.mnuShow.Name = "mnuShow"
        Me.mnuShow.Size = New System.Drawing.Size(103, 22)
        Me.mnuShow.Text = "Show"
        '
        'mnuHide
        '
        Me.mnuHide.Checked = True
        Me.mnuHide.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuHide.Name = "mnuHide"
        Me.mnuHide.Size = New System.Drawing.Size(103, 22)
        Me.mnuHide.Text = "Hide"
        '
        'EasyToolStripMenuItem
        '
        Me.EasyToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.EasyToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEasy, Me.mnuFull})
        Me.EasyToolStripMenuItem.Name = "EasyToolStripMenuItem"
        Me.EasyToolStripMenuItem.Size = New System.Drawing.Size(30, 20)
        Me.EasyToolStripMenuItem.Text = "UI"
        '
        'mnuEasy
        '
        Me.mnuEasy.Checked = True
        Me.mnuEasy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuEasy.Name = "mnuEasy"
        Me.mnuEasy.Size = New System.Drawing.Size(107, 22)
        Me.mnuEasy.Text = "Easy"
        '
        'mnuFull
        '
        Me.mnuFull.Name = "mnuFull"
        Me.mnuFull.Size = New System.Drawing.Size(107, 22)
        Me.mnuFull.Text = "Full UI"
        '
        'AvatarToolStripMenuItem
        '
        Me.AvatarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuVisible, Me.mnuInvisible})
        Me.AvatarToolStripMenuItem.Name = "AvatarToolStripMenuItem"
        Me.AvatarToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.AvatarToolStripMenuItem.Text = "Avatar"
        '
        'mnuVisible
        '
        Me.mnuVisible.Name = "mnuVisible"
        Me.mnuVisible.Size = New System.Drawing.Size(117, 22)
        Me.mnuVisible.Text = "Visible"
        '
        'mnuInvisible
        '
        Me.mnuInvisible.Checked = True
        Me.mnuInvisible.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuInvisible.Name = "mnuInvisible"
        Me.mnuInvisible.Size = New System.Drawing.Size(117, 22)
        Me.mnuInvisible.Text = "Invisible"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLogin, Me.mnuAbout})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'mnuLogin
        '
        Me.mnuLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.mnuLogin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuLogin.Name = "mnuLogin"
        Me.mnuLogin.Size = New System.Drawing.Size(107, 22)
        Me.mnuLogin.Text = "Login"
        '
        'mnuAbout
        '
        Me.mnuAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Size = New System.Drawing.Size(107, 22)
        Me.mnuAbout.Text = "About"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(402, 328)
        Me.Controls.Add(Me.Label)
        Me.Controls.Add(Me.BusyButton)
        Me.Controls.Add(Me.StopButton)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.InstallButton)
        Me.Controls.Add(Me.WebBrowser2)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.WebBrowser3)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Setup DreamWorldFiles"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents Label As System.Windows.Forms.Label
    Friend WithEvents WebBrowser2 As System.Windows.Forms.WebBrowser
    Friend WithEvents WebBrowser3 As System.Windows.Forms.WebBrowser
    Friend WithEvents BusyButton As System.Windows.Forms.Button
    Friend WithEvents StopButton As System.Windows.Forms.Button
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents InstallButton As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents EasyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEasy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFull As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsoleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuShow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHide As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLogin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AvatarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuVisible As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuInvisible As System.Windows.Forms.ToolStripMenuItem
End Class
