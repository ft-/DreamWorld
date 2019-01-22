<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRegionPopup
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.EditButton1 = New System.Windows.Forms.Button()
        Me.StartButton3 = New System.Windows.Forms.Button()
        Me.RecycleButton2 = New System.Windows.Forms.Button()
        Me.StopButton1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.EditButton1)
        Me.GroupBox1.Controls.Add(Me.StartButton3)
        Me.GroupBox1.Controls.Add(Me.RecycleButton2)
        Me.GroupBox1.Controls.Add(Me.StopButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(125, 169)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Text"
        '
        'EditButton1
        '
        Me.EditButton1.Image = Global.Outworldz.My.Resources.Resources.document_dirty
        Me.EditButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.EditButton1.Location = New System.Drawing.Point(20, 134)
        Me.EditButton1.Name = "EditButton1"
        Me.EditButton1.Size = New System.Drawing.Size(85, 23)
        Me.EditButton1.TabIndex = 8
        Me.EditButton1.Text = "Edit"
        Me.EditButton1.UseVisualStyleBackColor = True
        '
        'StartButton3
        '
        Me.StartButton3.Image = Global.Outworldz.My.Resources.Resources.media_play
        Me.StartButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.StartButton3.Location = New System.Drawing.Point(20, 47)
        Me.StartButton3.Name = "StartButton3"
        Me.StartButton3.Size = New System.Drawing.Size(85, 23)
        Me.StartButton3.TabIndex = 7
        Me.StartButton3.Text = "Start"
        Me.StartButton3.UseVisualStyleBackColor = True
        '
        'RecycleButton2
        '
        Me.RecycleButton2.Image = Global.Outworldz.My.Resources.Resources.recycle
        Me.RecycleButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RecycleButton2.Location = New System.Drawing.Point(16, 105)
        Me.RecycleButton2.Name = "RecycleButton2"
        Me.RecycleButton2.Size = New System.Drawing.Size(89, 23)
        Me.RecycleButton2.TabIndex = 6
        Me.RecycleButton2.Text = "Restart"
        Me.RecycleButton2.UseVisualStyleBackColor = True
        '
        'StopButton1
        '
        Me.StopButton1.Image = Global.Outworldz.My.Resources.Resources.media_stop_red1
        Me.StopButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.StopButton1.Location = New System.Drawing.Point(16, 76)
        Me.StopButton1.Name = "StopButton1"
        Me.StopButton1.Size = New System.Drawing.Size(89, 23)
        Me.StopButton1.TabIndex = 5
        Me.StopButton1.Text = "Stop"
        Me.StopButton1.UseVisualStyleBackColor = True
        '
        'FormRegionPopup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(151, 193)
        Me.Controls.Add(Me.GroupBox1)
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormRegionPopup"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents EditButton1 As Button
    Friend WithEvents StartButton3 As Button
    Friend WithEvents RecycleButton2 As Button
    Friend WithEvents StopButton1 As Button
End Class
