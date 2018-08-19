<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegionSpecific
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RegionSpecific))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PhysicsSeparate = New System.Windows.Forms.RadioButton()
        Me.PhysicsNone = New System.Windows.Forms.RadioButton()
        Me.PhysicsubODE = New System.Windows.Forms.RadioButton()
        Me.PhysicsBullet = New System.Windows.Forms.RadioButton()
        Me.PhysicsODE = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.AutoLoadCheckbox = New System.Windows.Forms.CheckBox()
        Me.MapBox = New System.Windows.Forms.GroupBox()
        Me.MapHelp = New System.Windows.Forms.PictureBox()
        Me.MapPicture = New System.Windows.Forms.PictureBox()
        Me.MapNone = New System.Windows.Forms.RadioButton()
        Me.MapSimple = New System.Windows.Forms.RadioButton()
        Me.MapBetter = New System.Windows.Forms.RadioButton()
        Me.MapBest = New System.Windows.Forms.RadioButton()
        Me.MapGood = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.AllowGods = New System.Windows.Forms.CheckBox()
        Me.GodHelp = New System.Windows.Forms.PictureBox()
        Me.ManagerGod = New System.Windows.Forms.CheckBox()
        Me.RegionGod = New System.Windows.Forms.CheckBox()
        Me.DataSnapshotCheckBox = New System.Windows.Forms.CheckBox()
        Me.MaxPrims = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.MapBox.SuspendLayout()
        CType(Me.MapHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MapPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.GodHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PhysicsSeparate)
        Me.GroupBox1.Controls.Add(Me.PhysicsNone)
        Me.GroupBox1.Controls.Add(Me.PhysicsubODE)
        Me.GroupBox1.Controls.Add(Me.PhysicsBullet)
        Me.GroupBox1.Controls.Add(Me.PhysicsODE)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 220)
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
        Me.PhysicsSeparate.TabIndex = 37
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
        Me.PhysicsNone.TabIndex = 33
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
        Me.PhysicsubODE.TabIndex = 35
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
        Me.PhysicsBullet.TabIndex = 136
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
        Me.PhysicsODE.TabIndex = 34
        Me.PhysicsODE.TabStop = True
        Me.PhysicsODE.Text = "Open Dynamics Engine"
        Me.PhysicsODE.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.AutoLoadCheckbox)
        Me.GroupBox5.Location = New System.Drawing.Point(225, 321)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(189, 48)
        Me.GroupBox5.TabIndex = 1861
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Auto Boot on Teleport"
        Me.GroupBox5.Visible = False
        '
        'AutoLoadCheckbox
        '
        Me.AutoLoadCheckbox.AutoSize = True
        Me.AutoLoadCheckbox.Location = New System.Drawing.Point(12, 19)
        Me.AutoLoadCheckbox.Name = "AutoLoadCheckbox"
        Me.AutoLoadCheckbox.Size = New System.Drawing.Size(59, 17)
        Me.AutoLoadCheckbox.TabIndex = 21
        Me.AutoLoadCheckbox.Text = "Enable"
        Me.AutoLoadCheckbox.UseVisualStyleBackColor = True
        '
        'MapBox
        '
        Me.MapBox.Controls.Add(Me.MapHelp)
        Me.MapBox.Controls.Add(Me.MapPicture)
        Me.MapBox.Controls.Add(Me.MapNone)
        Me.MapBox.Controls.Add(Me.MapSimple)
        Me.MapBox.Controls.Add(Me.MapBetter)
        Me.MapBox.Controls.Add(Me.MapBest)
        Me.MapBox.Controls.Add(Me.MapGood)
        Me.MapBox.Location = New System.Drawing.Point(219, 28)
        Me.MapBox.Name = "MapBox"
        Me.MapBox.Size = New System.Drawing.Size(173, 245)
        Me.MapBox.TabIndex = 1868
        Me.MapBox.TabStop = False
        Me.MapBox.Text = "Maps"
        '
        'MapHelp
        '
        Me.MapHelp.Image = Global.Outworldz.My.Resources.Resources.about
        Me.MapHelp.Location = New System.Drawing.Point(112, 17)
        Me.MapHelp.Name = "MapHelp"
        Me.MapHelp.Size = New System.Drawing.Size(28, 27)
        Me.MapHelp.TabIndex = 1857
        Me.MapHelp.TabStop = False
        '
        'MapPicture
        '
        Me.MapPicture.InitialImage = CType(resources.GetObject("MapPicture.InitialImage"), System.Drawing.Image)
        Me.MapPicture.Location = New System.Drawing.Point(23, 135)
        Me.MapPicture.Name = "MapPicture"
        Me.MapPicture.Size = New System.Drawing.Size(100, 93)
        Me.MapPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.MapPicture.TabIndex = 138
        Me.MapPicture.TabStop = False
        '
        'MapNone
        '
        Me.MapNone.AutoSize = True
        Me.MapNone.Location = New System.Drawing.Point(6, 29)
        Me.MapNone.Name = "MapNone"
        Me.MapNone.Size = New System.Drawing.Size(51, 17)
        Me.MapNone.TabIndex = 7
        Me.MapNone.TabStop = True
        Me.MapNone.Text = "None"
        Me.MapNone.UseVisualStyleBackColor = True
        '
        'MapSimple
        '
        Me.MapSimple.AutoSize = True
        Me.MapSimple.Location = New System.Drawing.Point(6, 48)
        Me.MapSimple.Name = "MapSimple"
        Me.MapSimple.Size = New System.Drawing.Size(94, 17)
        Me.MapSimple.TabIndex = 8
        Me.MapSimple.TabStop = True
        Me.MapSimple.Text = "Simple but fast"
        Me.MapSimple.UseVisualStyleBackColor = True
        '
        'MapBetter
        '
        Me.MapBetter.AutoSize = True
        Me.MapBetter.Location = New System.Drawing.Point(7, 87)
        Me.MapBetter.Name = "MapBetter"
        Me.MapBetter.Size = New System.Drawing.Size(116, 17)
        Me.MapBetter.TabIndex = 10
        Me.MapBetter.TabStop = True
        Me.MapBetter.Text = "Better (Prims, Slow)"
        Me.MapBetter.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.MapBetter.UseVisualStyleBackColor = True
        '
        'MapBest
        '
        Me.MapBest.AutoSize = True
        Me.MapBest.Location = New System.Drawing.Point(6, 109)
        Me.MapBest.Name = "MapBest"
        Me.MapBest.Size = New System.Drawing.Size(144, 17)
        Me.MapBest.TabIndex = 11
        Me.MapBest.TabStop = True
        Me.MapBest.Text = "Best (Prims +Mesh, Slow)"
        Me.MapBest.UseVisualStyleBackColor = True
        '
        'MapGood
        '
        Me.MapGood.AutoSize = True
        Me.MapGood.Location = New System.Drawing.Point(7, 67)
        Me.MapGood.Name = "MapGood"
        Me.MapGood.Size = New System.Drawing.Size(100, 17)
        Me.MapGood.TabIndex = 9
        Me.MapGood.TabStop = True
        Me.MapGood.Text = "Good (Warp3D)"
        Me.MapGood.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.AllowGods)
        Me.GroupBox4.Controls.Add(Me.GodHelp)
        Me.GroupBox4.Controls.Add(Me.ManagerGod)
        Me.GroupBox4.Controls.Add(Me.RegionGod)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 95)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 119)
        Me.GroupBox4.TabIndex = 1869
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Permissions"
        '
        'AllowGods
        '
        Me.AllowGods.AutoSize = True
        Me.AllowGods.Location = New System.Drawing.Point(15, 35)
        Me.AllowGods.Name = "AllowGods"
        Me.AllowGods.Size = New System.Drawing.Size(85, 17)
        Me.AllowGods.TabIndex = 1858
        Me.AllowGods.Text = "Allow Gods?"
        Me.AllowGods.UseVisualStyleBackColor = True
        '
        'GodHelp
        '
        Me.GodHelp.Image = Global.Outworldz.My.Resources.Resources.about
        Me.GodHelp.Location = New System.Drawing.Point(117, 19)
        Me.GodHelp.Name = "GodHelp"
        Me.GodHelp.Size = New System.Drawing.Size(30, 34)
        Me.GodHelp.TabIndex = 1857
        Me.GodHelp.TabStop = False
        '
        'ManagerGod
        '
        Me.ManagerGod.AutoSize = True
        Me.ManagerGod.Location = New System.Drawing.Point(15, 82)
        Me.ManagerGod.Name = "ManagerGod"
        Me.ManagerGod.Size = New System.Drawing.Size(141, 17)
        Me.ManagerGod.TabIndex = 6
        Me.ManagerGod.Text = "Region manager is god?"
        Me.ManagerGod.UseVisualStyleBackColor = True
        '
        'RegionGod
        '
        Me.RegionGod.AutoSize = True
        Me.RegionGod.Location = New System.Drawing.Point(15, 58)
        Me.RegionGod.Name = "RegionGod"
        Me.RegionGod.Size = New System.Drawing.Size(132, 17)
        Me.RegionGod.TabIndex = 1855
        Me.RegionGod.Text = "Region owner is god? "
        Me.RegionGod.UseVisualStyleBackColor = True
        '
        'DataSnapshotCheckBox
        '
        Me.DataSnapshotCheckBox.AutoSize = True
        Me.DataSnapshotCheckBox.Location = New System.Drawing.Point(18, 28)
        Me.DataSnapshotCheckBox.Name = "DataSnapshotCheckBox"
        Me.DataSnapshotCheckBox.Size = New System.Drawing.Size(176, 17)
        Me.DataSnapshotCheckBox.TabIndex = 1870
        Me.DataSnapshotCheckBox.Text = "Publish Items marked for search"
        Me.DataSnapshotCheckBox.UseVisualStyleBackColor = True
        '
        'MaxPrims
        '
        Me.MaxPrims.Location = New System.Drawing.Point(79, 57)
        Me.MaxPrims.Name = "MaxPrims"
        Me.MaxPrims.Size = New System.Drawing.Size(75, 20)
        Me.MaxPrims.TabIndex = 1871
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 1872
        Me.Label1.Text = "Max prims"
        '
        'RegionSpecific
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 383)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MaxPrims)
        Me.Controls.Add(Me.DataSnapshotCheckBox)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.MapBox)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "RegionSpecific"
        Me.Text = "Region Specific Settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.MapBox.ResumeLayout(False)
        Me.MapBox.PerformLayout()
        CType(Me.MapHelp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MapPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.GodHelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PhysicsSeparate As RadioButton
    Friend WithEvents PhysicsNone As RadioButton
    Friend WithEvents PhysicsubODE As RadioButton
    Friend WithEvents PhysicsBullet As RadioButton
    Friend WithEvents PhysicsODE As RadioButton
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents AutoLoadCheckbox As CheckBox
    Friend WithEvents MapBox As GroupBox
    Friend WithEvents MapHelp As PictureBox
    Friend WithEvents MapPicture As PictureBox
    Friend WithEvents MapNone As RadioButton
    Friend WithEvents MapSimple As RadioButton
    Friend WithEvents MapBetter As RadioButton
    Friend WithEvents MapBest As RadioButton
    Friend WithEvents MapGood As RadioButton
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents AllowGods As CheckBox
    Friend WithEvents GodHelp As PictureBox
    Friend WithEvents ManagerGod As CheckBox
    Friend WithEvents RegionGod As CheckBox
    Friend WithEvents DataSnapshotCheckBox As CheckBox
    Friend WithEvents MaxPrims As TextBox
    Friend WithEvents Label1 As Label
End Class
