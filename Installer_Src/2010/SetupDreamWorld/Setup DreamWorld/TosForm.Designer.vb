<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TosForm
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
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.ShowToHGUsersCheckbox = New System.Windows.Forms.CheckBox()
        Me.ShowToLocalUsersCheckbox = New System.Windows.Forms.CheckBox()
        Me.TOSEnable = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(13, 117)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(556, 276)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'ShowToHGUsersCheckbox
        '
        Me.ShowToHGUsersCheckbox.AutoSize = True
        Me.ShowToHGUsersCheckbox.Location = New System.Drawing.Point(24, 81)
        Me.ShowToHGUsersCheckbox.Name = "ShowToHGUsersCheckbox"
        Me.ShowToHGUsersCheckbox.Size = New System.Drawing.Size(263, 17)
        Me.ShowToHGUsersCheckbox.TabIndex = 1
        Me.ShowToHGUsersCheckbox.Text = "Show TOS To Hypergrid Users on First HG Login?"
        Me.ShowToHGUsersCheckbox.UseVisualStyleBackColor = True
        '
        'ShowToLocalUsersCheckbox
        '
        Me.ShowToLocalUsersCheckbox.AutoSize = True
        Me.ShowToLocalUsersCheckbox.Location = New System.Drawing.Point(24, 58)
        Me.ShowToLocalUsersCheckbox.Name = "ShowToLocalUsersCheckbox"
        Me.ShowToLocalUsersCheckbox.Size = New System.Drawing.Size(225, 17)
        Me.ShowToLocalUsersCheckbox.TabIndex = 2
        Me.ShowToLocalUsersCheckbox.Text = "Show TOS To Local Users on First Login?"
        Me.ShowToLocalUsersCheckbox.UseVisualStyleBackColor = True
        '
        'TOSEnable
        '
        Me.TOSEnable.AutoSize = True
        Me.TOSEnable.Location = New System.Drawing.Point(24, 35)
        Me.TOSEnable.Name = "TOSEnable"
        Me.TOSEnable.Size = New System.Drawing.Size(121, 17)
        Me.TOSEnable.TabIndex = 3
        Me.TOSEnable.Text = "Enable TOS module"
        Me.TOSEnable.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(350, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "The TOS module shows your users and/or visitors the HTML text  below."
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(24, 399)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(121, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Preview in Browser"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 431)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TOSEnable)
        Me.Controls.Add(Me.ShowToLocalUsersCheckbox)
        Me.Controls.Add(Me.ShowToHGUsersCheckbox)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Name = "TosForm"
        Me.Text = "Terms of Service"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents ShowToHGUsersCheckbox As CheckBox
    Friend WithEvents ShowToLocalUsersCheckbox As CheckBox
    Friend WithEvents TOSEnable As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
End Class
