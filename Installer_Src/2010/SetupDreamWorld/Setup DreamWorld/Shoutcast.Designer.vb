<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Shoutcast
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
        Me.components = New System.ComponentModel.Container()
        Me.ShoutcastEnable = New System.Windows.Forms.CheckBox()
        Me.ShoutcastPassword = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.AutoBackupHelp = New System.Windows.Forms.PictureBox()
        Me.LoadURL = New System.Windows.Forms.Button()
        Me.SC_Show = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.AdminPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ShoutcastPort = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AutoBackupHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ShoutcastEnable
        '
        Me.ShoutcastEnable.AutoSize = True
        Me.ShoutcastEnable.Location = New System.Drawing.Point(28, 42)
        Me.ShoutcastEnable.Margin = New System.Windows.Forms.Padding(4)
        Me.ShoutcastEnable.Name = "ShoutcastEnable"
        Me.ShoutcastEnable.Size = New System.Drawing.Size(74, 21)
        Me.ShoutcastEnable.TabIndex = 0
        Me.ShoutcastEnable.Text = "Enable"
        Me.ShoutcastEnable.UseVisualStyleBackColor = True
        '
        'ShoutcastPassword
        '
        Me.ShoutcastPassword.Location = New System.Drawing.Point(132, 135)
        Me.ShoutcastPassword.Margin = New System.Windows.Forms.Padding(4)
        Me.ShoutcastPassword.Name = "ShoutcastPassword"
        Me.ShoutcastPassword.Size = New System.Drawing.Size(132, 22)
        Me.ShoutcastPassword.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(54, 140)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Password"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.AutoBackupHelp)
        Me.GroupBox1.Controls.Add(Me.LoadURL)
        Me.GroupBox1.Controls.Add(Me.SC_Show)
        Me.GroupBox1.Controls.Add(Me.ShoutcastEnable)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.AdminPassword)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ShoutcastPort)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ShoutcastPassword)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(285, 244)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Shoutcast Server"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Outworldz.My.Resources.Resources.about
        Me.PictureBox1.Location = New System.Drawing.Point(249, 12)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(28, 33)
        Me.PictureBox1.TabIndex = 1859
        Me.PictureBox1.TabStop = False
        '
        'AutoBackupHelp
        '
        Me.AutoBackupHelp.Image = Global.Outworldz.My.Resources.Resources.about
        Me.AutoBackupHelp.Location = New System.Drawing.Point(255, 162)
        Me.AutoBackupHelp.Margin = New System.Windows.Forms.Padding(4)
        Me.AutoBackupHelp.Name = "AutoBackupHelp"
        Me.AutoBackupHelp.Size = New System.Drawing.Size(28, 33)
        Me.AutoBackupHelp.TabIndex = 1858
        Me.AutoBackupHelp.TabStop = False
        '
        'LoadURL
        '
        Me.LoadURL.Location = New System.Drawing.Point(55, 179)
        Me.LoadURL.Name = "LoadURL"
        Me.LoadURL.Size = New System.Drawing.Size(193, 43)
        Me.LoadURL.TabIndex = 8
        Me.LoadURL.Text = "Control, View and Listen"
        Me.LoadURL.UseVisualStyleBackColor = True
        '
        'SC_Show
        '
        Me.SC_Show.AutoSize = True
        Me.SC_Show.Location = New System.Drawing.Point(156, 46)
        Me.SC_Show.Margin = New System.Windows.Forms.Padding(4)
        Me.SC_Show.Name = "SC_Show"
        Me.SC_Show.Size = New System.Drawing.Size(108, 21)
        Me.SC_Show.TabIndex = 7
        Me.SC_Show.Text = "Show Status"
        Me.SC_Show.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 109)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Admin Password"
        '
        'AdminPassword
        '
        Me.AdminPassword.Location = New System.Drawing.Point(132, 105)
        Me.AdminPassword.Margin = New System.Windows.Forms.Padding(4)
        Me.AdminPassword.Name = "AdminPassword"
        Me.AdminPassword.Size = New System.Drawing.Size(132, 22)
        Me.AdminPassword.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(154, 78)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Port"
        '
        'ShoutcastPort
        '
        Me.ShoutcastPort.Location = New System.Drawing.Point(196, 75)
        Me.ShoutcastPort.Margin = New System.Windows.Forms.Padding(4)
        Me.ShoutcastPort.Name = "ShoutcastPort"
        Me.ShoutcastPort.Size = New System.Drawing.Size(68, 22)
        Me.ShoutcastPort.TabIndex = 3
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'Shoutcast
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(317, 273)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Shoutcast"
        Me.Text = "Shoutcast"
        Me.ToolTip1.SetToolTip(Me, "Click for help on setting up Shouitcast")
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AutoBackupHelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ShoutcastEnable As CheckBox
    Friend WithEvents ShoutcastPassword As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ShoutcastPort As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents AdminPassword As TextBox
    Friend WithEvents AutoBackupHelp As PictureBox
    Friend WithEvents SC_Show As CheckBox
    Friend WithEvents LoadURL As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents PictureBox1 As PictureBox
End Class
