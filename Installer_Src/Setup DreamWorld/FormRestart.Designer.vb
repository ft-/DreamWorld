<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRestart
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
        Me.AutoStart = New System.Windows.Forms.GroupBox()
        Me.AutoRestart = New System.Windows.Forms.PictureBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.AutoRestartBox = New System.Windows.Forms.TextBox()
        Me.RunOnBoot = New System.Windows.Forms.PictureBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BootStart = New System.Windows.Forms.CheckBox()
        Me.AutoStartCheckbox = New System.Windows.Forms.CheckBox()
        Me.AutoStart.SuspendLayout()
        CType(Me.AutoRestart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RunOnBoot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AutoStart
        '
        Me.AutoStart.Controls.Add(Me.AutoRestart)
        Me.AutoStart.Controls.Add(Me.Label25)
        Me.AutoStart.Controls.Add(Me.AutoRestartBox)
        Me.AutoStart.Controls.Add(Me.RunOnBoot)
        Me.AutoStart.Controls.Add(Me.Label13)
        Me.AutoStart.Controls.Add(Me.Label6)
        Me.AutoStart.Controls.Add(Me.BootStart)
        Me.AutoStart.Controls.Add(Me.AutoStartCheckbox)
        Me.AutoStart.Location = New System.Drawing.Point(12, 23)
        Me.AutoStart.Name = "AutoStart"
        Me.AutoStart.Size = New System.Drawing.Size(243, 139)
        Me.AutoStart.TabIndex = 45
        Me.AutoStart.TabStop = False
        Me.AutoStart.Text = "Auto Start and Start on Boot"
        '
        'AutoRestart
        '
        Me.AutoRestart.Image = Global.Outworldz.My.Resources.Resources.about
        Me.AutoRestart.Location = New System.Drawing.Point(208, 82)
        Me.AutoRestart.Name = "AutoRestart"
        Me.AutoRestart.Size = New System.Drawing.Size(30, 34)
        Me.AutoRestart.TabIndex = 1863
        Me.AutoRestart.TabStop = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(22, 99)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(104, 13)
        Me.Label25.TabIndex = 1862
        Me.Label25.Text = "Auto Restart Interval"
        '
        'AutoRestartBox
        '
        Me.AutoRestartBox.Location = New System.Drawing.Point(135, 96)
        Me.AutoRestartBox.Name = "AutoRestartBox"
        Me.AutoRestartBox.Size = New System.Drawing.Size(57, 20)
        Me.AutoRestartBox.TabIndex = 47
        '
        'RunOnBoot
        '
        Me.RunOnBoot.Image = Global.Outworldz.My.Resources.Resources.about
        Me.RunOnBoot.Location = New System.Drawing.Point(208, 19)
        Me.RunOnBoot.Name = "RunOnBoot"
        Me.RunOnBoot.Size = New System.Drawing.Size(30, 34)
        Me.RunOnBoot.TabIndex = 1859
        Me.RunOnBoot.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(10, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "One Click Start"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(118, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Run on PC Boot"
        '
        'BootStart
        '
        Me.BootStart.AutoSize = True
        Me.BootStart.Location = New System.Drawing.Point(122, 34)
        Me.BootStart.Name = "BootStart"
        Me.BootStart.Size = New System.Drawing.Size(59, 17)
        Me.BootStart.TabIndex = 46
        Me.BootStart.Text = "Enable"
        Me.BootStart.UseVisualStyleBackColor = True
        '
        'AutoStartCheckbox
        '
        Me.AutoStartCheckbox.AutoSize = True
        Me.AutoStartCheckbox.Location = New System.Drawing.Point(13, 34)
        Me.AutoStartCheckbox.Name = "AutoStartCheckbox"
        Me.AutoStartCheckbox.Size = New System.Drawing.Size(59, 17)
        Me.AutoStartCheckbox.TabIndex = 45
        Me.AutoStartCheckbox.Text = "Enable"
        Me.AutoStartCheckbox.UseVisualStyleBackColor = True
        '
        'FormRestart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 175)
        Me.Controls.Add(Me.AutoStart)
        Me.Name = "FormRestart"
        Me.Text = "FormRestart"
        Me.AutoStart.ResumeLayout(False)
        Me.AutoStart.PerformLayout()
        CType(Me.AutoRestart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RunOnBoot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AutoStart As GroupBox
    Friend WithEvents AutoRestart As PictureBox
    Friend WithEvents Label25 As Label
    Friend WithEvents AutoRestartBox As TextBox
    Friend WithEvents RunOnBoot As PictureBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents BootStart As CheckBox
    Friend WithEvents AutoStartCheckbox As CheckBox
End Class
