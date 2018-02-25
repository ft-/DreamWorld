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
        Me.ShoutcastEnable = New System.Windows.Forms.CheckBox()
        Me.ShoutcastPassword = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.AdminPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ShoutcastPort = New System.Windows.Forms.TextBox()
        Me.AutoBackupHelp = New System.Windows.Forms.PictureBox()
        Me.SC_Show = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.AutoBackupHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ShoutcastEnable
        '
        Me.ShoutcastEnable.AutoSize = True
        Me.ShoutcastEnable.Location = New System.Drawing.Point(21, 34)
        Me.ShoutcastEnable.Name = "ShoutcastEnable"
        Me.ShoutcastEnable.Size = New System.Drawing.Size(59, 17)
        Me.ShoutcastEnable.TabIndex = 0
        Me.ShoutcastEnable.Text = "Enable"
        Me.ShoutcastEnable.UseVisualStyleBackColor = True
        '
        'ShoutcastPassword
        '
        Me.ShoutcastPassword.Location = New System.Drawing.Point(93, 122)
        Me.ShoutcastPassword.Name = "ShoutcastPassword"
        Me.ShoutcastPassword.Size = New System.Drawing.Size(100, 20)
        Me.ShoutcastPassword.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Password"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SC_Show)
        Me.GroupBox1.Controls.Add(Me.ShoutcastEnable)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.AdminPassword)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ShoutcastPort)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ShoutcastPassword)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(214, 163)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Shoutcast Server"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Admin Password"
        '
        'AdminPassword
        '
        Me.AdminPassword.Location = New System.Drawing.Point(93, 96)
        Me.AdminPassword.Name = "AdminPassword"
        Me.AdminPassword.Size = New System.Drawing.Size(100, 20)
        Me.AdminPassword.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(90, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Port"
        '
        'ShoutcastPort
        '
        Me.ShoutcastPort.Location = New System.Drawing.Point(141, 70)
        Me.ShoutcastPort.Name = "ShoutcastPort"
        Me.ShoutcastPort.Size = New System.Drawing.Size(52, 20)
        Me.ShoutcastPort.TabIndex = 3
        '
        'AutoBackupHelp
        '
        Me.AutoBackupHelp.Image = Global.Outworldz.My.Resources.Resources.about
        Me.AutoBackupHelp.Location = New System.Drawing.Point(115, 12)
        Me.AutoBackupHelp.Name = "AutoBackupHelp"
        Me.AutoBackupHelp.Size = New System.Drawing.Size(28, 32)
        Me.AutoBackupHelp.TabIndex = 1858
        Me.AutoBackupHelp.TabStop = False
        '
        'SC_Show
        '
        Me.SC_Show.AutoSize = True
        Me.SC_Show.Location = New System.Drawing.Point(134, 34)
        Me.SC_Show.Name = "SC_Show"
        Me.SC_Show.Size = New System.Drawing.Size(53, 17)
        Me.SC_Show.TabIndex = 7
        Me.SC_Show.Text = "Show"
        Me.SC_Show.UseVisualStyleBackColor = True
        '
        'Shoutcast
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(242, 198)
        Me.Controls.Add(Me.AutoBackupHelp)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Shoutcast"
        Me.Text = "Shoutcast"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
End Class
