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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TosForm))
        Me.ShowToHGUsersCheckbox = New System.Windows.Forms.CheckBox()
        Me.ShowToLocalUsersCheckbox = New System.Windows.Forms.CheckBox()
        Me.TOSEnable = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Editor1 = New LiveSwitch.TextControl.Editor()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.ApplyButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ShowToHGUsersCheckbox
        '
        Me.ShowToHGUsersCheckbox.AutoSize = True
        Me.ShowToHGUsersCheckbox.Location = New System.Drawing.Point(24, 81)
        Me.ShowToHGUsersCheckbox.Name = "ShowToHGUsersCheckbox"
        Me.ShowToHGUsersCheckbox.Size = New System.Drawing.Size(292, 17)
        Me.ShowToHGUsersCheckbox.TabIndex = 3
        Me.ShowToHGUsersCheckbox.Text = "Show TOS To Hypergrid Users on First Hypergrid Login?"
        Me.ShowToHGUsersCheckbox.UseVisualStyleBackColor = True
        Me.ShowToHGUsersCheckbox.Visible = False
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
        Me.ShowToLocalUsersCheckbox.Visible = False
        '
        'TOSEnable
        '
        Me.TOSEnable.AutoSize = True
        Me.TOSEnable.Location = New System.Drawing.Point(24, 35)
        Me.TOSEnable.Name = "TOSEnable"
        Me.TOSEnable.Size = New System.Drawing.Size(121, 17)
        Me.TOSEnable.TabIndex = 1
        Me.TOSEnable.Text = "Enable TOS module"
        Me.TOSEnable.UseVisualStyleBackColor = True
        Me.TOSEnable.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(317, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "The TOS module shows your users and/or visitors this HTML text."
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(253, 461)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(121, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Preview in Browser"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(413, 461)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(227, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Require all users to re-agree to the TOS"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Editor1
        '
        Me.Editor1.BodyBackgroundColor = System.Drawing.Color.White
        Me.Editor1.BodyHtml = Nothing
        Me.Editor1.BodyText = Nothing
        Me.Editor1.DocumentText = resources.GetString("Editor1.DocumentText")
        Me.Editor1.EditorBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Editor1.EditorForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Editor1.FontSize = LiveSwitch.TextControl.FontSize.Three
        Me.Editor1.Html = Nothing
        Me.Editor1.Location = New System.Drawing.Point(12, 104)
        Me.Editor1.Name = "Editor1"
        Me.Editor1.Size = New System.Drawing.Size(627, 338)
        Me.Editor1.TabIndex = 7
        '
        'SaveButton
        '
        Me.SaveButton.Location = New System.Drawing.Point(12, 461)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(75, 23)
        Me.SaveButton.TabIndex = 8
        Me.SaveButton.Text = "Ok"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'ApplyButton
        '
        Me.ApplyButton.Location = New System.Drawing.Point(111, 461)
        Me.ApplyButton.Name = "ApplyButton"
        Me.ApplyButton.Size = New System.Drawing.Size(75, 23)
        Me.ApplyButton.TabIndex = 9
        Me.ApplyButton.Text = "Apply"
        Me.ApplyButton.UseVisualStyleBackColor = True
        '
        'TosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(660, 500)
        Me.Controls.Add(Me.ApplyButton)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.Editor1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TOSEnable)
        Me.Controls.Add(Me.ShowToLocalUsersCheckbox)
        Me.Controls.Add(Me.ShowToHGUsersCheckbox)
        Me.MaximizeBox = False
        Me.Name = "TosForm"
        Me.Text = "Terms of Service"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ShowToHGUsersCheckbox As CheckBox
    Friend WithEvents ShowToLocalUsersCheckbox As CheckBox
    Friend WithEvents TOSEnable As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Editor1 As LiveSwitch.TextControl.Editor
    Friend WithEvents SaveButton As Button
    Friend WithEvents ApplyButton As Button
End Class
