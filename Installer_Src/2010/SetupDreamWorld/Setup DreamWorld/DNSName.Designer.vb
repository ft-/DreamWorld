<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DNSName
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.NextNameButton = New System.Windows.Forms.Button()
        Me.PublicBox = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(6, 10)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(202, 20)
        Me.TextBox1.TabIndex = 1
        '
        'SaveButton
        '
        Me.SaveButton.Location = New System.Drawing.Point(235, 35)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(64, 23)
        Me.SaveButton.TabIndex = 5
        Me.SaveButton.Text = "Save"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'NextNameButton
        '
        Me.NextNameButton.Location = New System.Drawing.Point(6, 35)
        Me.NextNameButton.Name = "NextNameButton"
        Me.NextNameButton.Size = New System.Drawing.Size(78, 23)
        Me.NextNameButton.TabIndex = 6
        Me.NextNameButton.Text = "Next Name"
        Me.NextNameButton.UseVisualStyleBackColor = True
        '
        'PublicBox
        '
        Me.PublicBox.AutoSize = True
        Me.PublicBox.Location = New System.Drawing.Point(235, 10)
        Me.PublicBox.Name = "PublicBox"
        Me.PublicBox.Size = New System.Drawing.Size(85, 17)
        Me.PublicBox.TabIndex = 7
        Me.PublicBox.Text = "Make Public"
        Me.PublicBox.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipTitle = "If marked Public, this sim will be published to an online directory so others peo" &
    "pkle on the hypergrid can find it."
        '
        'DNSName
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 74)
        Me.Controls.Add(Me.PublicBox)
        Me.Controls.Add(Me.NextNameButton)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "DNSName"
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents SaveButton As Button
    Friend WithEvents NextNameButton As Button
    Friend WithEvents PublicBox As CheckBox
    Friend WithEvents ToolTip1 As ToolTip
End Class
