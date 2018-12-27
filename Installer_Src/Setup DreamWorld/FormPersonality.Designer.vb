<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPersonality
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
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.PersonalityHelp = New System.Windows.Forms.PictureBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TimerInterval = New System.Windows.Forms.TextBox()
        Me.ChatSpeed = New System.Windows.Forms.ComboBox()
        Me.GroupBox5.SuspendLayout()
        CType(Me.PersonalityHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.PersonalityHelp)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.TimerInterval)
        Me.GroupBox5.Controls.Add(Me.ChatSpeed)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(257, 115)
        Me.GroupBox5.TabIndex = 1864
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Personality"
        '
        'PersonalityHelp
        '
        Me.PersonalityHelp.Image = Global.Outworldz.My.Resources.Resources.about
        Me.PersonalityHelp.Location = New System.Drawing.Point(152, 10)
        Me.PersonalityHelp.Name = "PersonalityHelp"
        Me.PersonalityHelp.Size = New System.Drawing.Size(28, 32)
        Me.PersonalityHelp.TabIndex = 1858
        Me.PersonalityHelp.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 73)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(116, 13)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "Wallpaper Time (0=Off)"
        '
        'TimerInterval
        '
        Me.TimerInterval.Location = New System.Drawing.Point(141, 66)
        Me.TimerInterval.Name = "TimerInterval"
        Me.TimerInterval.Size = New System.Drawing.Size(39, 20)
        Me.TimerInterval.TabIndex = 6
        '
        'ChatSpeed
        '
        Me.ChatSpeed.FormattingEnabled = True
        Me.ChatSpeed.Items.AddRange(New Object() {"Sleepy", "Awake", "After Coffee", "Too much Coffee"})
        Me.ChatSpeed.Location = New System.Drawing.Point(9, 21)
        Me.ChatSpeed.Name = "ChatSpeed"
        Me.ChatSpeed.Size = New System.Drawing.Size(113, 21)
        Me.ChatSpeed.TabIndex = 5
        '
        'FormPersonality
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(293, 139)
        Me.Controls.Add(Me.GroupBox5)
        Me.Name = "FormPersonality"
        Me.Text = "Personality / Wallpaper"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.PersonalityHelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents PersonalityHelp As PictureBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TimerInterval As TextBox
    Friend WithEvents ChatSpeed As ComboBox
End Class
