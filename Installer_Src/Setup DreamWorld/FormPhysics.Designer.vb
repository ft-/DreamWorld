<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPhysics
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
        Me.PhysicsSeparate = New System.Windows.Forms.RadioButton()
        Me.PhysicsNone = New System.Windows.Forms.RadioButton()
        Me.PhysicsubODE = New System.Windows.Forms.RadioButton()
        Me.PhysicsBullet = New System.Windows.Forms.RadioButton()
        Me.PhysicsODE = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PhysicsSeparate)
        Me.GroupBox1.Controls.Add(Me.PhysicsNone)
        Me.GroupBox1.Controls.Add(Me.PhysicsubODE)
        Me.GroupBox1.Controls.Add(Me.PhysicsBullet)
        Me.GroupBox1.Controls.Add(Me.PhysicsODE)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(189, 115)
        Me.GroupBox1.TabIndex = 43
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Physics Engine"
        '
        'PhysicsSeparate
        '
        Me.PhysicsSeparate.AutoSize = True
        Me.PhysicsSeparate.Location = New System.Drawing.Point(6, 92)
        Me.PhysicsSeparate.Name = "PhysicsSeparate"
        Me.PhysicsSeparate.Size = New System.Drawing.Size(180, 17)
        Me.PhysicsSeparate.TabIndex = 13
        Me.PhysicsSeparate.TabStop = True
        Me.PhysicsSeparate.Text = "Bullet physics in separate thread."
        Me.PhysicsSeparate.UseVisualStyleBackColor = True
        '
        'PhysicsNone
        '
        Me.PhysicsNone.AutoSize = True
        Me.PhysicsNone.Location = New System.Drawing.Point(6, 19)
        Me.PhysicsNone.Name = "PhysicsNone"
        Me.PhysicsNone.Size = New System.Drawing.Size(51, 17)
        Me.PhysicsNone.TabIndex = 9
        Me.PhysicsNone.TabStop = True
        Me.PhysicsNone.Text = "None"
        Me.PhysicsNone.UseVisualStyleBackColor = True
        '
        'PhysicsubODE
        '
        Me.PhysicsubODE.AutoSize = True
        Me.PhysicsubODE.Location = New System.Drawing.Point(6, 56)
        Me.PhysicsubODE.Name = "PhysicsubODE"
        Me.PhysicsubODE.Size = New System.Drawing.Size(153, 17)
        Me.PhysicsubODE.TabIndex = 11
        Me.PhysicsubODE.TabStop = True
        Me.PhysicsubODE.Text = "Ubit Open Dynamic Engine"
        Me.PhysicsubODE.UseVisualStyleBackColor = True
        '
        'PhysicsBullet
        '
        Me.PhysicsBullet.AutoSize = True
        Me.PhysicsBullet.Location = New System.Drawing.Point(6, 74)
        Me.PhysicsBullet.Name = "PhysicsBullet"
        Me.PhysicsBullet.Size = New System.Drawing.Size(90, 17)
        Me.PhysicsBullet.TabIndex = 12
        Me.PhysicsBullet.TabStop = True
        Me.PhysicsBullet.Text = "Bullet Physics"
        Me.PhysicsBullet.UseVisualStyleBackColor = True
        '
        'PhysicsODE
        '
        Me.PhysicsODE.AutoSize = True
        Me.PhysicsODE.Location = New System.Drawing.Point(6, 38)
        Me.PhysicsODE.Name = "PhysicsODE"
        Me.PhysicsODE.Size = New System.Drawing.Size(136, 17)
        Me.PhysicsODE.TabIndex = 10
        Me.PhysicsODE.TabStop = True
        Me.PhysicsODE.Text = "Open Dynamics Engine"
        Me.PhysicsODE.UseVisualStyleBackColor = True
        '
        'FormPhysics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(239, 160)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormPhysics"
        Me.Text = "FormPhysics"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PhysicsSeparate As RadioButton
    Friend WithEvents PhysicsNone As RadioButton
    Friend WithEvents PhysicsubODE As RadioButton
    Friend WithEvents PhysicsBullet As RadioButton
    Friend WithEvents PhysicsODE As RadioButton
End Class
