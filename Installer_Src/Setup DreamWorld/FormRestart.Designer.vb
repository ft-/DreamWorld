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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormRestart))
        Me.AutoStart = New System.Windows.Forms.GroupBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.AutoRestartBox = New System.Windows.Forms.TextBox()
        Me.RunOnBoot = New System.Windows.Forms.PictureBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.BootStart = New System.Windows.Forms.CheckBox()
        Me.AutoStartCheckbox = New System.Windows.Forms.CheckBox()
        Me.AutoStart.SuspendLayout()
        CType(Me.RunOnBoot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AutoStart
        '
        Me.AutoStart.Controls.Add(Me.Label25)
        Me.AutoStart.Controls.Add(Me.AutoRestartBox)
        Me.AutoStart.Controls.Add(Me.RunOnBoot)
        Me.AutoStart.Controls.Add(Me.Label13)
        Me.AutoStart.Controls.Add(Me.BootStart)
        Me.AutoStart.Controls.Add(Me.AutoStartCheckbox)
        Me.AutoStart.Location = New System.Drawing.Point(12, 12)
        Me.AutoStart.Name = "AutoStart"
        Me.AutoStart.Size = New System.Drawing.Size(223, 173)
        Me.AutoStart.TabIndex = 45
        Me.AutoStart.TabStop = False
        Me.AutoStart.Text = "Auto Restart"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(22, 40)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(104, 13)
        Me.Label25.TabIndex = 1862
        Me.Label25.Text = "Auto Restart Interval"
        '
        'AutoRestartBox
        '
        Me.AutoRestartBox.Location = New System.Drawing.Point(25, 57)
        Me.AutoRestartBox.Name = "AutoRestartBox"
        Me.AutoRestartBox.Size = New System.Drawing.Size(57, 20)
        Me.AutoRestartBox.TabIndex = 47
        '
        'RunOnBoot
        '
        Me.RunOnBoot.Image = Global.Outworldz.My.Resources.Resources.about
        Me.RunOnBoot.Location = New System.Drawing.Point(132, 19)
        Me.RunOnBoot.Name = "RunOnBoot"
        Me.RunOnBoot.Size = New System.Drawing.Size(30, 34)
        Me.RunOnBoot.TabIndex = 1859
        Me.RunOnBoot.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(78, 173)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(0, 13)
        Me.Label13.TabIndex = 24
        '
        'BootStart
        '
        Me.BootStart.AutoSize = True
        Me.BootStart.Location = New System.Drawing.Point(25, 135)
        Me.BootStart.Name = "BootStart"
        Me.BootStart.Size = New System.Drawing.Size(172, 17)
        Me.BootStart.TabIndex = 46
        Me.BootStart.Text = "Install Task to Run on PC Boot"
        Me.BootStart.UseVisualStyleBackColor = True
        '
        'AutoStartCheckbox
        '
        Me.AutoStartCheckbox.AutoSize = True
        Me.AutoStartCheckbox.Location = New System.Drawing.Point(25, 112)
        Me.AutoStartCheckbox.Name = "AutoStartCheckbox"
        Me.AutoStartCheckbox.Size = New System.Drawing.Size(133, 17)
        Me.AutoStartCheckbox.TabIndex = 45
        Me.AutoStartCheckbox.Text = "Enable One Click Start"
        Me.AutoStartCheckbox.UseVisualStyleBackColor = True
        '
        'FormRestart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(249, 207)
        Me.Controls.Add(Me.AutoStart)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FormRestart"
        Me.Text = "Restart"
        Me.AutoStart.ResumeLayout(False)
        Me.AutoStart.PerformLayout()
        CType(Me.RunOnBoot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AutoStart As GroupBox
    Friend WithEvents Label25 As Label
    Friend WithEvents AutoRestartBox As TextBox
    Friend WithEvents RunOnBoot As PictureBox
    Friend WithEvents Label13 As Label
    Friend WithEvents BootStart As CheckBox
    Friend WithEvents AutoStartCheckbox As CheckBox
End Class
