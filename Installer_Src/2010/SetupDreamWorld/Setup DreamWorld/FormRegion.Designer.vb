<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRegion
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
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.RegionPort = New System.Windows.Forms.TextBox()
        Me.CoordY = New System.Windows.Forms.TextBox()
        Me.CoordX = New System.Windows.Forms.TextBox()
        Me.RegionName = New System.Windows.Forms.TextBox()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.SizeY = New System.Windows.Forms.TextBox()
        Me.SizeX = New System.Windows.Forms.TextBox()
        Me.MaxAgents = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PhysicalPrimMax = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.MaxPrims = New System.Windows.Forms.TextBox()
        Me.NonphysicalPrimMax = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ClampPrimSize = New System.Windows.Forms.CheckBox()
        Me.Advanced = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UUID = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DeleteButton = New System.Windows.Forms.Button()
        Me.EnabledCheckBox = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Advanced.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'RegionPort
        '
        Me.RegionPort.Location = New System.Drawing.Point(129, 48)
        Me.RegionPort.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RegionPort.Name = "RegionPort"
        Me.RegionPort.Size = New System.Drawing.Size(52, 22)
        Me.RegionPort.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.RegionPort, "The UDP port the region will operate on. Must be uinique")
        '
        'CoordY
        '
        Me.CoordY.Location = New System.Drawing.Point(217, 16)
        Me.CoordY.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CoordY.Name = "CoordY"
        Me.CoordY.Size = New System.Drawing.Size(49, 22)
        Me.CoordY.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.CoordY, "The Up-Down position on the world map")
        '
        'CoordX
        '
        Me.CoordX.Location = New System.Drawing.Point(129, 16)
        Me.CoordX.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CoordX.Name = "CoordX"
        Me.CoordX.Size = New System.Drawing.Size(52, 22)
        Me.CoordX.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.CoordX, "The L-R position on the world map")
        '
        'RegionName
        '
        Me.RegionName.Location = New System.Drawing.Point(19, 44)
        Me.RegionName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RegionName.Name = "RegionName"
        Me.RegionName.Size = New System.Drawing.Size(305, 22)
        Me.RegionName.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.RegionName, "Alpa-Numeric plus Spaces")
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(27, 105)
        Me.RadioButton4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(62, 21)
        Me.RadioButton4.TabIndex = 5
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "4 X 4"
        Me.ToolTip1.SetToolTip(Me.RadioButton4, "1024 X 1024")
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(27, 76)
        Me.RadioButton3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(62, 21)
        Me.RadioButton3.TabIndex = 4
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "3 X 3"
        Me.ToolTip1.SetToolTip(Me.RadioButton3, "768 X 768")
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(27, 48)
        Me.RadioButton2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(62, 21)
        Me.RadioButton2.TabIndex = 3
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "2 X 2"
        Me.ToolTip1.SetToolTip(Me.RadioButton2, "512 X 512")
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(27, 20)
        Me.RadioButton1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(62, 21)
        Me.RadioButton1.TabIndex = 2
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "1 X 1"
        Me.ToolTip1.SetToolTip(Me.RadioButton1, "256 X 256")
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'SizeY
        '
        Me.SizeY.Location = New System.Drawing.Point(224, 54)
        Me.SizeY.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SizeY.Name = "SizeY"
        Me.SizeY.Size = New System.Drawing.Size(56, 22)
        Me.SizeY.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.SizeY, "Must be the same as X")
        '
        'SizeX
        '
        Me.SizeX.Location = New System.Drawing.Point(224, 23)
        Me.SizeX.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SizeX.Name = "SizeX"
        Me.SizeX.Size = New System.Drawing.Size(56, 22)
        Me.SizeX.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.SizeX, "Must be the same as Y")
        '
        'MaxAgents
        '
        Me.MaxAgents.Location = New System.Drawing.Point(195, 261)
        Me.MaxAgents.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaxAgents.Name = "MaxAgents"
        Me.MaxAgents.Size = New System.Drawing.Size(52, 22)
        Me.MaxAgents.TabIndex = 23
        Me.ToolTip1.SetToolTip(Me.MaxAgents, "Clamps how many Avatars + NPC's can be in a sim before the region is shown as Ful" &
        "l.   The actual value is set in Estate Settings in the viewer.")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(43, 140)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(138, 17)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "NonphysicalPrimMax"
        Me.ToolTip1.SetToolTip(Me.Label5, "You cannot make a regular prim bigger than this.")
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(80, 169)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(113, 17)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "PhysicalPrimMax"
        Me.ToolTip1.SetToolTip(Me.Label9, "You cannot make a physical prim bigger than this.")
        '
        'PhysicalPrimMax
        '
        Me.PhysicalPrimMax.Location = New System.Drawing.Point(195, 165)
        Me.PhysicalPrimMax.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PhysicalPrimMax.Name = "PhysicalPrimMax"
        Me.PhysicalPrimMax.Size = New System.Drawing.Size(52, 22)
        Me.PhysicalPrimMax.TabIndex = 32
        Me.ToolTip1.SetToolTip(Me.PhysicalPrimMax, "You cannot make a physical prim bigger than this.")
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(81, 201)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(102, 17)
        Me.Label10.TabIndex = 34
        Me.Label10.Text = "ClampPrimSize"
        Me.ToolTip1.SetToolTip(Me.Label10, "ClampPrimSize option to ensure no prim can exceed the set size.")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(113, 233)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 17)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "MaxPrims"
        Me.ToolTip1.SetToolTip(Me.Label11, "Not what you think it is.  Only used to tell scripts the max size allowed. Id not" &
        " enforced by Opensim.  Viewer stop at 45,000, Opensim does not!")
        '
        'MaxPrims
        '
        Me.MaxPrims.Location = New System.Drawing.Point(195, 229)
        Me.MaxPrims.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaxPrims.Name = "MaxPrims"
        Me.MaxPrims.Size = New System.Drawing.Size(52, 22)
        Me.MaxPrims.TabIndex = 35
        Me.ToolTip1.SetToolTip(Me.MaxPrims, "Not what you think it is.  Only used to tell scripts the max size allowed. Id not" &
        " enforced by Opensim.  Viewer stop at 45,000, Opensim does not!")
        '
        'NonphysicalPrimMax
        '
        Me.NonphysicalPrimMax.Location = New System.Drawing.Point(195, 132)
        Me.NonphysicalPrimMax.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NonphysicalPrimMax.Name = "NonphysicalPrimMax"
        Me.NonphysicalPrimMax.Size = New System.Drawing.Size(52, 22)
        Me.NonphysicalPrimMax.TabIndex = 37
        Me.ToolTip1.SetToolTip(Me.NonphysicalPrimMax, "You cannot make a regular prim bigger than this.")
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(103, 265)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 17)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "MaxAgents"
        Me.ToolTip1.SetToolTip(Me.Label12, "Clamps how many Avatars + NPC's can be in a sim before the region is shown as Ful" &
        "l.   The actual value is set in Estate Settings in the viewer.")
        '
        'ClampPrimSize
        '
        Me.ClampPrimSize.AutoSize = True
        Me.ClampPrimSize.Location = New System.Drawing.Point(195, 201)
        Me.ClampPrimSize.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ClampPrimSize.Name = "ClampPrimSize"
        Me.ClampPrimSize.Size = New System.Drawing.Size(18, 17)
        Me.ClampPrimSize.TabIndex = 39
        Me.ToolTip1.SetToolTip(Me.ClampPrimSize, "ClampPrimSize option to ensure no prim can exceed the set size..")
        Me.ClampPrimSize.UseVisualStyleBackColor = True
        '
        'Advanced
        '
        Me.Advanced.Controls.Add(Me.ClampPrimSize)
        Me.Advanced.Controls.Add(Me.Label12)
        Me.Advanced.Controls.Add(Me.Label10)
        Me.Advanced.Controls.Add(Me.NonphysicalPrimMax)
        Me.Advanced.Controls.Add(Me.Label11)
        Me.Advanced.Controls.Add(Me.PhysicalPrimMax)
        Me.Advanced.Controls.Add(Me.Label6)
        Me.Advanced.Controls.Add(Me.Label9)
        Me.Advanced.Controls.Add(Me.MaxPrims)
        Me.Advanced.Controls.Add(Me.Label5)
        Me.Advanced.Controls.Add(Me.MaxAgents)
        Me.Advanced.Controls.Add(Me.Label4)
        Me.Advanced.Controls.Add(Me.Label1)
        Me.Advanced.Controls.Add(Me.UUID)
        Me.Advanced.Controls.Add(Me.RegionPort)
        Me.Advanced.Controls.Add(Me.Label21)
        Me.Advanced.Controls.Add(Me.CoordY)
        Me.Advanced.Controls.Add(Me.CoordX)
        Me.Advanced.Location = New System.Drawing.Point(20, 298)
        Me.Advanced.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Advanced.Name = "Advanced"
        Me.Advanced.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Advanced.Size = New System.Drawing.Size(307, 297)
        Me.Advanced.TabIndex = 26
        Me.Advanced.TabStop = False
        Me.Advanced.Text = "Advanced"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 80)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 17)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "UUID"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 20)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 17)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Map Coords: X"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(191, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 17)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Y"
        '
        'UUID
        '
        Me.UUID.Location = New System.Drawing.Point(12, 100)
        Me.UUID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.UUID.Name = "UUID"
        Me.UUID.Size = New System.Drawing.Size(285, 22)
        Me.UUID.TabIndex = 11
        Me.UUID.Text = "ae823f8a-edcc-4351-b797-0e10711312a8"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(7, 52)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(83, 17)
        Me.Label21.TabIndex = 19
        Me.Label21.Text = "Region Port"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 25)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 17)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Region Name:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.RadioButton4)
        Me.GroupBox2.Controls.Add(Me.RadioButton3)
        Me.GroupBox2.Controls.Add(Me.RadioButton2)
        Me.GroupBox2.Controls.Add(Me.RadioButton1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.SizeY)
        Me.GroupBox2.Controls.Add(Me.SizeX)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 107)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(303, 140)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sim Size"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(139, 32)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 17)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Or:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(197, 58)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Y"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(197, 32)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "X"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(124, 255)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(79, 28)
        Me.Button1.TabIndex = 27
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DeleteButton
        '
        Me.DeleteButton.Location = New System.Drawing.Point(225, 255)
        Me.DeleteButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DeleteButton.Name = "DeleteButton"
        Me.DeleteButton.Size = New System.Drawing.Size(100, 28)
        Me.DeleteButton.TabIndex = 28
        Me.DeleteButton.Text = "Delete"
        Me.DeleteButton.UseVisualStyleBackColor = True
        '
        'EnabledCheckBox
        '
        Me.EnabledCheckBox.AutoSize = True
        Me.EnabledCheckBox.Location = New System.Drawing.Point(31, 79)
        Me.EnabledCheckBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EnabledCheckBox.Name = "EnabledCheckBox"
        Me.EnabledCheckBox.Size = New System.Drawing.Size(82, 21)
        Me.EnabledCheckBox.TabIndex = 29
        Me.EnabledCheckBox.Text = "Enabled"
        Me.EnabledCheckBox.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(19, 255)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(92, 28)
        Me.Button2.TabIndex = 30
        Me.Button2.Text = "More"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FormRegion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(345, 610)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.EnabledCheckBox)
        Me.Controls.Add(Me.DeleteButton)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Advanced)
        Me.Controls.Add(Me.RegionName)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormRegion"
        Me.Text = "Region"
        Me.Advanced.ResumeLayout(False)
        Me.Advanced.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Advanced As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents UUID As TextBox
    Friend WithEvents RegionPort As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents CoordY As TextBox
    Friend WithEvents CoordX As TextBox
    Friend WithEvents RegionName As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents SizeY As TextBox
    Friend WithEvents SizeX As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents DeleteButton As Button
    Friend WithEvents EnabledCheckBox As CheckBox
    Friend WithEvents MaxAgents As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents PhysicalPrimMax As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents NonphysicalPrimMax As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents MaxPrims As TextBox
    Friend WithEvents ClampPrimSize As CheckBox
    Friend WithEvents Button2 As Button
End Class
