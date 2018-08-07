<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormVoice
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RequestPassword = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.VivoxEnable = New System.Windows.Forms.CheckBox()
        Me.VivoxPassword = New System.Windows.Forms.TextBox()
        Me.VivoxUserName = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RequestPassword)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.VivoxEnable)
        Me.GroupBox1.Controls.Add(Me.VivoxPassword)
        Me.GroupBox1.Controls.Add(Me.VivoxUserName)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(245, 135)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Vivox Voice"
        '
        'RequestPassword
        '
        Me.RequestPassword.Location = New System.Drawing.Point(6, 18)
        Me.RequestPassword.Name = "RequestPassword"
        Me.RequestPassword.Size = New System.Drawing.Size(225, 23)
        Me.RequestPassword.TabIndex = 0
        Me.RequestPassword.Text = "Click to Request a Free Voice Service"
        Me.RequestPassword.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Password"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "User ID"
        '
        'VivoxEnable
        '
        Me.VivoxEnable.AutoSize = True
        Me.VivoxEnable.Location = New System.Drawing.Point(9, 51)
        Me.VivoxEnable.Name = "VivoxEnable"
        Me.VivoxEnable.Size = New System.Drawing.Size(59, 17)
        Me.VivoxEnable.TabIndex = 1
        Me.VivoxEnable.Text = "Enable"
        Me.VivoxEnable.UseVisualStyleBackColor = True
        '
        'VivoxPassword
        '
        Me.VivoxPassword.Location = New System.Drawing.Point(109, 101)
        Me.VivoxPassword.Name = "VivoxPassword"
        Me.VivoxPassword.Size = New System.Drawing.Size(130, 20)
        Me.VivoxPassword.TabIndex = 3
        Me.VivoxPassword.UseSystemPasswordChar = True
        '
        'VivoxUserName
        '
        Me.VivoxUserName.Location = New System.Drawing.Point(109, 76)
        Me.VivoxUserName.Name = "VivoxUserName"
        Me.VivoxUserName.Size = New System.Drawing.Size(130, 20)
        Me.VivoxUserName.TabIndex = 2
        '
        'FormVoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(272, 171)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.Name = "FormVoice"
        Me.Text = "Form2"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents VivoxEnable As CheckBox
    Friend WithEvents VivoxPassword As TextBox
    Friend WithEvents VivoxUserName As TextBox
    Friend WithEvents RequestPassword As Button
End Class
