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
        Me.WebBrowser2 = New System.Windows.Forms.WebBrowser()
        Me.StopButton = New System.Windows.Forms.Button()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.InstallButton = New System.Windows.Forms.Button()
        Me.BusyButton = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsoleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsoleToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHide = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.UIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEasy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFull = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdminUIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAdminHide = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAdminShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.AvatarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNoAvatar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuYesAvatar = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpensimulatorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WebUi = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShutdownNowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLogin = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
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
        Me.StopButton.Location = New System.Drawing.Point(183, 0)
        Me.StopButton.Name = "StopButton"
        Me.StopButton.Size = New System.Drawing.Size(75, 23)
        Me.StopButton.TabIndex = 17
        Me.StopButton.Text = "Stop"
        Me.StopButton.UseVisualStyleBackColor = True
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(183, 0)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(75, 23)
        Me.StartButton.TabIndex = 16
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'InstallButton
        '
        Me.InstallButton.Location = New System.Drawing.Point(183, 1)
        Me.InstallButton.Name = "InstallButton"
        Me.InstallButton.Size = New System.Drawing.Size(75, 23)
        Me.InstallButton.TabIndex = 15
        Me.InstallButton.Text = "Install"
        Me.InstallButton.UseVisualStyleBackColor = True
        '
        'BusyButton
        '
        Me.BusyButton.Location = New System.Drawing.Point(183, 1)
        Me.BusyButton.Name = "BusyButton"
        Me.BusyButton.Size = New System.Drawing.Size(75, 23)
        Me.BusyButton.TabIndex = 18
        Me.BusyButton.Text = "Busy"
        Me.BusyButton.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.AcceptsReturn = True
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(12, 43)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(395, 188)
        Me.TextBox1.TabIndex = 22
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
        Me.mnuExit.Image = Global.DreamWorld.My.Resources.Resources._exit
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(92, 22)
        Me.mnuExit.Text = "Exit"
        '
        'ConsoleToolStripMenuItem
        '
        Me.ConsoleToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConsoleToolStripMenuItem1, Me.UIToolStripMenuItem, Me.AdminUIToolStripMenuItem, Me.AvatarToolStripMenuItem, Me.OpensimulatorToolStripMenuItem})
        Me.ConsoleToolStripMenuItem.Name = "ConsoleToolStripMenuItem"
        Me.ConsoleToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.ConsoleToolStripMenuItem.Text = "Settings"
        '
        'ConsoleToolStripMenuItem1
        '
        Me.ConsoleToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHide, Me.mnuShow})
        Me.ConsoleToolStripMenuItem1.Image = Global.DreamWorld.My.Resources.Resources.window_edit
        Me.ConsoleToolStripMenuItem1.Name = "ConsoleToolStripMenuItem1"
        Me.ConsoleToolStripMenuItem1.Size = New System.Drawing.Size(153, 22)
        Me.ConsoleToolStripMenuItem1.Text = "Console"
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
        'UIToolStripMenuItem
        '
        Me.UIToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEasy, Me.mnuFull})
        Me.UIToolStripMenuItem.Image = Global.DreamWorld.My.Resources.Resources.document_connection
        Me.UIToolStripMenuItem.Name = "UIToolStripMenuItem"
        Me.UIToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.UIToolStripMenuItem.Text = "Viewer UI"
        '
        'mnuEasy
        '
        Me.mnuEasy.Checked = True
        Me.mnuEasy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuEasy.Name = "mnuEasy"
        Me.mnuEasy.Size = New System.Drawing.Size(152, 22)
        Me.mnuEasy.Text = "Easy"
        '
        'mnuFull
        '
        Me.mnuFull.Name = "mnuFull"
        Me.mnuFull.Size = New System.Drawing.Size(152, 22)
        Me.mnuFull.Text = "Full"
        '
        'AdminUIToolStripMenuItem
        '
        Me.AdminUIToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAdminHide, Me.mnuAdminShow})
        Me.AdminUIToolStripMenuItem.Image = Global.DreamWorld.My.Resources.Resources.document_view
        Me.AdminUIToolStripMenuItem.Name = "AdminUIToolStripMenuItem"
        Me.AdminUIToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.AdminUIToolStripMenuItem.Text = "Admin UI"
        '
        'mnuAdminHide
        '
        Me.mnuAdminHide.Checked = True
        Me.mnuAdminHide.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuAdminHide.Name = "mnuAdminHide"
        Me.mnuAdminHide.Size = New System.Drawing.Size(152, 22)
        Me.mnuAdminHide.Text = "Hide"
        '
        'mnuAdminShow
        '
        Me.mnuAdminShow.Name = "mnuAdminShow"
        Me.mnuAdminShow.Size = New System.Drawing.Size(152, 22)
        Me.mnuAdminShow.Text = "Show"
        '
        'AvatarToolStripMenuItem
        '
        Me.AvatarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNoAvatar, Me.mnuYesAvatar})
        Me.AvatarToolStripMenuItem.Image = Global.DreamWorld.My.Resources.Resources.users1
        Me.AvatarToolStripMenuItem.Name = "AvatarToolStripMenuItem"
        Me.AvatarToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.AvatarToolStripMenuItem.Text = "Avatar"
        '
        'mnuNoAvatar
        '
        Me.mnuNoAvatar.Checked = True
        Me.mnuNoAvatar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuNoAvatar.Name = "mnuNoAvatar"
        Me.mnuNoAvatar.Size = New System.Drawing.Size(152, 22)
        Me.mnuNoAvatar.Text = "No"
        '
        'mnuYesAvatar
        '
        Me.mnuYesAvatar.Name = "mnuYesAvatar"
        Me.mnuYesAvatar.Size = New System.Drawing.Size(152, 22)
        Me.mnuYesAvatar.Text = "Yes"
        '
        'OpensimulatorToolStripMenuItem
        '
        Me.OpensimulatorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WebUi, Me.ShutdownNowToolStripMenuItem})
        Me.OpensimulatorToolStripMenuItem.Image = Global.DreamWorld.My.Resources.Resources.cube_blue
        Me.OpensimulatorToolStripMenuItem.Name = "OpensimulatorToolStripMenuItem"
        Me.OpensimulatorToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.OpensimulatorToolStripMenuItem.Text = "Opensimulator"
        '
        'WebUi
        '
        Me.WebUi.Image = Global.DreamWorld.My.Resources.Resources.window_add
        Me.WebUi.Name = "WebUi"
        Me.WebUi.Size = New System.Drawing.Size(172, 22)
        Me.WebUi.Text = "Show Web UI Now"
        '
        'ShutdownNowToolStripMenuItem
        '
        Me.ShutdownNowToolStripMenuItem.Image = Global.DreamWorld.My.Resources.Resources._error
        Me.ShutdownNowToolStripMenuItem.Name = "ShutdownNowToolStripMenuItem"
        Me.ShutdownNowToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.ShutdownNowToolStripMenuItem.Text = "Shutdown Now!"
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
        Me.mnuLogin.Image = Global.DreamWorld.My.Resources.Resources.question_and_answer
        Me.mnuLogin.Name = "mnuLogin"
        Me.mnuLogin.Size = New System.Drawing.Size(107, 22)
        Me.mnuLogin.Text = "Login"
        '
        'mnuAbout
        '
        Me.mnuAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.mnuAbout.Image = Global.DreamWorld.My.Resources.Resources.about
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Size = New System.Drawing.Size(107, 22)
        Me.mnuAbout.Text = "About"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ConsoleToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(431, 24)
        Me.MenuStrip1.TabIndex = 21
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(431, 257)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.BusyButton)
        Me.Controls.Add(Me.StopButton)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.InstallButton)
        Me.Controls.Add(Me.WebBrowser2)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "DreamWorld Opensimulator"
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
    Friend WithEvents WebBrowser2 As System.Windows.Forms.WebBrowser
    Friend WithEvents BusyButton As System.Windows.Forms.Button
    Friend WithEvents StopButton As System.Windows.Forms.Button
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents InstallButton As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuExit As ToolStripMenuItem
    Friend WithEvents ConsoleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsoleToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents mnuHide As ToolStripMenuItem
    Friend WithEvents mnuShow As ToolStripMenuItem
    Friend WithEvents UIToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuEasy As ToolStripMenuItem
    Friend WithEvents mnuFull As ToolStripMenuItem
    Friend WithEvents AdminUIToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuAdminHide As ToolStripMenuItem
    Friend WithEvents mnuAdminShow As ToolStripMenuItem
    Friend WithEvents AvatarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuNoAvatar As ToolStripMenuItem
    Friend WithEvents mnuYesAvatar As ToolStripMenuItem
    Friend WithEvents OpensimulatorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WebUi As ToolStripMenuItem
    Friend WithEvents ShutdownNowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuLogin As ToolStripMenuItem
    Friend WithEvents mnuAbout As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
End Class
