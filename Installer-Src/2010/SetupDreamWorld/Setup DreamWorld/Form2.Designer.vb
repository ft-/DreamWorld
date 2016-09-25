<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdvancedForm
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
        Me.CheckBox256 = New System.Windows.Forms.CheckBox()
        Me.CheckBox512 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1024 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SizeY = New System.Windows.Forms.TextBox()
        Me.SizeX = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PrivatePort = New System.Windows.Forms.TextBox()
        Me.PublicPort = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CheckBox256
        '
        Me.CheckBox256.AutoSize = True
        Me.CheckBox256.Location = New System.Drawing.Point(11, 17)
        Me.CheckBox256.Name = "CheckBox256"
        Me.CheckBox256.Size = New System.Drawing.Size(75, 17)
        Me.CheckBox256.TabIndex = 1
        Me.CheckBox256.Text = "256 X 256"
        Me.CheckBox256.UseVisualStyleBackColor = True
        '
        'CheckBox512
        '
        Me.CheckBox512.AutoSize = True
        Me.CheckBox512.Location = New System.Drawing.Point(11, 41)
        Me.CheckBox512.Name = "CheckBox512"
        Me.CheckBox512.Size = New System.Drawing.Size(75, 17)
        Me.CheckBox512.TabIndex = 2
        Me.CheckBox512.Text = "512 X 512"
        Me.CheckBox512.UseVisualStyleBackColor = True
        '
        'CheckBox1024
        '
        Me.CheckBox1024.AutoSize = True
        Me.CheckBox1024.Location = New System.Drawing.Point(11, 65)
        Me.CheckBox1024.Name = "CheckBox1024"
        Me.CheckBox1024.Size = New System.Drawing.Size(87, 17)
        Me.CheckBox1024.TabIndex = 3
        Me.CheckBox1024.Text = "1024 X 1024"
        Me.CheckBox1024.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.CheckBox1024)
        Me.GroupBox1.Controls.Add(Me.CheckBox512)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CheckBox256)
        Me.GroupBox1.Controls.Add(Me.SizeY)
        Me.GroupBox1.Controls.Add(Me.SizeX)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(195, 120)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sim Size"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(74, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Y"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "X"
        '
        'SizeY
        '
        Me.SizeY.Location = New System.Drawing.Point(94, 91)
        Me.SizeY.Name = "SizeY"
        Me.SizeY.Size = New System.Drawing.Size(33, 20)
        Me.SizeY.TabIndex = 1
        '
        'SizeX
        '
        Me.SizeX.Location = New System.Drawing.Point(28, 91)
        Me.SizeX.Name = "SizeX"
        Me.SizeX.Size = New System.Drawing.Size(33, 20)
        Me.SizeX.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.PrivatePort)
        Me.GroupBox2.Controls.Add(Me.PublicPort)
        Me.GroupBox2.Location = New System.Drawing.Point(223, 18)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(157, 115)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ports"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Public Port"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Private Port"
        '
        'PrivatePort
        '
        Me.PrivatePort.Location = New System.Drawing.Point(82, 46)
        Me.PrivatePort.Name = "PrivatePort"
        Me.PrivatePort.Size = New System.Drawing.Size(47, 20)
        Me.PrivatePort.TabIndex = 1
        '
        'PublicPort
        '
        Me.PublicPort.Location = New System.Drawing.Point(82, 20)
        Me.PublicPort.Name = "PublicPort"
        Me.PublicPort.Size = New System.Drawing.Size(47, 20)
        Me.PublicPort.TabIndex = 0
        '
        'AdvancedForm
        '
        Me.ClientSize = New System.Drawing.Size(408, 149)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "AdvancedForm"
        Me.Text = "Advanced"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CheckBox256 As CheckBox
    Friend WithEvents CheckBox512 As CheckBox
    Friend WithEvents CheckBox1024 As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents SizeY As TextBox
    Friend WithEvents SizeX As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents PublicPort As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents PrivatePort As TextBox
    Friend WithEvents Label5 As Label
End Class
