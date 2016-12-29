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
        Me.Region1 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.bRegionPort = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.bCoordY = New System.Windows.Forms.TextBox()
        Me.bCoordX = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.bCheckBox256 = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.bCheckBox1024 = New System.Windows.Forms.CheckBox()
        Me.bCheckBox512 = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CheckBox256 = New System.Windows.Forms.CheckBox()
        Me.bSizeY = New System.Windows.Forms.TextBox()
        Me.bSizeX = New System.Windows.Forms.TextBox()
        Me.bRegionName = New System.Windows.Forms.TextBox()
        Me.Region1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Region1
        '
        Me.Region1.BackColor = System.Drawing.SystemColors.Control
        Me.Region1.Controls.Add(Me.Label21)
        Me.Region1.Controls.Add(Me.bRegionName)
        Me.Region1.Controls.Add(Me.bRegionPort)
        Me.Region1.Controls.Add(Me.Label1)
        Me.Region1.Controls.Add(Me.Label4)
        Me.Region1.Controls.Add(Me.bCoordY)
        Me.Region1.Controls.Add(Me.bCoordX)
        Me.Region1.Controls.Add(Me.Label8)
        Me.Region1.Controls.Add(Me.GroupBox2)
        Me.Region1.Location = New System.Drawing.Point(12, 12)
        Me.Region1.Name = "Region1"
        Me.Region1.Size = New System.Drawing.Size(200, 275)
        Me.Region1.TabIndex = 0
        Me.Region1.TabStop = False
        Me.Region1.Text = "Region 1"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 105)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 13)
        Me.Label21.TabIndex = 19
        Me.Label21.Text = "Region Port"
        '
        'bRegionPort
        '
        Me.bRegionPort.Location = New System.Drawing.Point(98, 102)
        Me.bRegionPort.Name = "bRegionPort"
        Me.bRegionPort.Size = New System.Drawing.Size(46, 20)
        Me.bRegionPort.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(143, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Y"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Global Coords: X"
        '
        'bCoordY
        '
        Me.bCoordY.Location = New System.Drawing.Point(163, 67)
        Me.bCoordY.Name = "bCoordY"
        Me.bCoordY.Size = New System.Drawing.Size(33, 20)
        Me.bCoordY.TabIndex = 15
        '
        'bCoordX
        '
        Me.bCoordX.Location = New System.Drawing.Point(97, 67)
        Me.bCoordX.Name = "bCoordX"
        Me.bCoordX.Size = New System.Drawing.Size(33, 20)
        Me.bCoordX.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Region Name:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.bCheckBox256)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.bCheckBox1024)
        Me.GroupBox2.Controls.Add(Me.bCheckBox512)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.CheckBox256)
        Me.GroupBox2.Controls.Add(Me.bSizeY)
        Me.GroupBox2.Controls.Add(Me.bSizeX)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 149)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(195, 126)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sim Size"
        '
        'bCheckBox256
        '
        Me.bCheckBox256.AutoSize = True
        Me.bCheckBox256.Location = New System.Drawing.Point(23, 20)
        Me.bCheckBox256.Name = "bCheckBox256"
        Me.bCheckBox256.Size = New System.Drawing.Size(75, 17)
        Me.bCheckBox256.TabIndex = 4
        Me.bCheckBox256.Text = "256 X 256"
        Me.bCheckBox256.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(86, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Y"
        '
        'bCheckBox1024
        '
        Me.bCheckBox1024.AutoSize = True
        Me.bCheckBox1024.Location = New System.Drawing.Point(23, 67)
        Me.bCheckBox1024.Name = "bCheckBox1024"
        Me.bCheckBox1024.Size = New System.Drawing.Size(87, 17)
        Me.bCheckBox1024.TabIndex = 3
        Me.bCheckBox1024.Text = "1024 X 1024"
        Me.bCheckBox1024.UseVisualStyleBackColor = True
        '
        'bCheckBox512
        '
        Me.bCheckBox512.AutoSize = True
        Me.bCheckBox512.Location = New System.Drawing.Point(23, 43)
        Me.bCheckBox512.Name = "bCheckBox512"
        Me.bCheckBox512.Size = New System.Drawing.Size(75, 17)
        Me.bCheckBox512.TabIndex = 2
        Me.bCheckBox512.Text = "512 X 512"
        Me.bCheckBox512.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "X"
        '
        'CheckBox256
        '
        Me.CheckBox256.AutoSize = True
        Me.CheckBox256.Location = New System.Drawing.Point(23, 19)
        Me.CheckBox256.Name = "CheckBox256"
        Me.CheckBox256.Size = New System.Drawing.Size(75, 17)
        Me.CheckBox256.TabIndex = 1
        Me.CheckBox256.Text = "256 X 256"
        Me.CheckBox256.UseVisualStyleBackColor = True
        '
        'bSizeY
        '
        Me.bSizeY.Location = New System.Drawing.Point(106, 94)
        Me.bSizeY.Name = "bSizeY"
        Me.bSizeY.Size = New System.Drawing.Size(33, 20)
        Me.bSizeY.TabIndex = 1
        '
        'bSizeX
        '
        Me.bSizeX.Location = New System.Drawing.Point(40, 94)
        Me.bSizeX.Name = "bSizeX"
        Me.bSizeX.Size = New System.Drawing.Size(33, 20)
        Me.bSizeX.TabIndex = 0
        '
        'bRegionName
        '
        Me.bRegionName.Location = New System.Drawing.Point(9, 36)
        Me.bRegionName.Name = "bRegionName"
        Me.bRegionName.Size = New System.Drawing.Size(185, 20)
        Me.bRegionName.TabIndex = 6
        '
        'FormRegion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(243, 299)
        Me.Controls.Add(Me.Region1)
        Me.Name = "FormRegion"
        Me.Text = "Region"
        Me.Region1.ResumeLayout(False)
        Me.Region1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Region1 As GroupBox
    Friend WithEvents bRegionName As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents bCheckBox256 As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents bCheckBox1024 As CheckBox
    Friend WithEvents bCheckBox512 As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CheckBox256 As CheckBox
    Friend WithEvents bSizeY As TextBox
    Friend WithEvents bSizeX As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents bCoordY As TextBox
    Friend WithEvents bCoordX As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents bRegionPort As TextBox
End Class
