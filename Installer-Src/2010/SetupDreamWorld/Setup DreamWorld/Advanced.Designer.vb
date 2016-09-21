<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Advanced
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
        Me.Y = New System.Windows.Forms.TextBox()
        Me.X = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SizeY = New System.Windows.Forms.TextBox()
        Me.SizeX = New System.Windows.Forms.TextBox()
        Me.Check1024 = New System.Windows.Forms.CheckBox()
        Me.Check512 = New System.Windows.Forms.CheckBox()
        Me.Check256 = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PrivatePort = New System.Windows.Forms.TextBox()
        Me.PublicPort = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Y
        '
        Me.Y.Location = New System.Drawing.Point(167, 73)
        Me.Y.Name = "Y"
        Me.Y.Size = New System.Drawing.Size(51, 20)
        Me.Y.TabIndex = 2
        '
        'X
        '
        Me.X.Location = New System.Drawing.Point(100, 73)
        Me.X.Name = "X"
        Me.X.Size = New System.Drawing.Size(49, 20)
        Me.X.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Sim Coords"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Sim Size:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.SizeY)
        Me.Panel1.Controls.Add(Me.SizeX)
        Me.Panel1.Controls.Add(Me.Check1024)
        Me.Panel1.Controls.Add(Me.Check512)
        Me.Panel1.Controls.Add(Me.Check256)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PrivatePort)
        Me.Panel1.Controls.Add(Me.PublicPort)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.X)
        Me.Panel1.Controls.Add(Me.Y)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(251, 201)
        Me.Panel1.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(80, 174)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(14, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "X"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(155, 177)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Y"
        '
        'SizeY
        '
        Me.SizeY.Location = New System.Drawing.Point(167, 174)
        Me.SizeY.Name = "SizeY"
        Me.SizeY.Size = New System.Drawing.Size(51, 20)
        Me.SizeY.TabIndex = 17
        '
        'SizeX
        '
        Me.SizeX.Location = New System.Drawing.Point(100, 174)
        Me.SizeX.Name = "SizeX"
        Me.SizeX.Size = New System.Drawing.Size(49, 20)
        Me.SizeX.TabIndex = 16
        '
        'Check1024
        '
        Me.Check1024.AutoSize = True
        Me.Check1024.Location = New System.Drawing.Point(100, 151)
        Me.Check1024.Name = "Check1024"
        Me.Check1024.Size = New System.Drawing.Size(87, 17)
        Me.Check1024.TabIndex = 15
        Me.Check1024.Text = "1024 X 1024"
        Me.Check1024.UseVisualStyleBackColor = True
        '
        'Check512
        '
        Me.Check512.AutoSize = True
        Me.Check512.Location = New System.Drawing.Point(100, 128)
        Me.Check512.Name = "Check512"
        Me.Check512.Size = New System.Drawing.Size(75, 17)
        Me.Check512.TabIndex = 14
        Me.Check512.Text = "512 X 512"
        Me.Check512.UseVisualStyleBackColor = True
        '
        'Check256
        '
        Me.Check256.AutoSize = True
        Me.Check256.Location = New System.Drawing.Point(100, 105)
        Me.Check256.Name = "Check256"
        Me.Check256.Size = New System.Drawing.Size(75, 17)
        Me.Check256.TabIndex = 13
        Me.Check256.Text = "256 X 256"
        Me.Check256.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(155, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Y"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(84, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "X"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Private Port"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Public Port"
        '
        'PrivatePort
        '
        Me.PrivatePort.Location = New System.Drawing.Point(98, 21)
        Me.PrivatePort.Name = "PrivatePort"
        Me.PrivatePort.Size = New System.Drawing.Size(51, 20)
        Me.PrivatePort.TabIndex = 8
        '
        'PublicPort
        '
        Me.PublicPort.Location = New System.Drawing.Point(100, 47)
        Me.PublicPort.Name = "PublicPort"
        Me.PublicPort.Size = New System.Drawing.Size(49, 20)
        Me.PublicPort.TabIndex = 7
        '
        'Advanced
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(286, 225)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Advanced"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Advanced"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Y As TextBox
    Friend WithEvents X As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PrivatePort As TextBox
    Friend WithEvents PublicPort As TextBox

    Private Sub X_TextChanged(sender As Object, e As EventArgs) Handles X.TextChanged
        My.Settings.CoordX = X.Text
        My.Settings.Save()
    End Sub

    Private Sub Y_TextChanged(sender As Object, e As EventArgs) Handles Y.TextChanged
        My.Settings.CoordY = Y.Text
        My.Settings.Save()
    End Sub

    Private Sub Advanced_Load(sender As Object, e As EventArgs) Handles Me.Load
        Y.Text = My.Settings.CoordY
        X.Text = My.Settings.CoordX
        PublicPort.Text = My.Settings.PublicPort
        PrivatePort.Text = My.Settings.PrivatePort

    End Sub

    Private Sub PrivatePort_TextChanged(sender As Object, e As EventArgs) Handles PrivatePort.TextChanged
        My.Settings.PrivatePort = PrivatePort.Text
    End Sub

    Private Sub PublicPort_TextChanged(sender As Object, e As EventArgs) Handles PublicPort.TextChanged
        My.Settings.PublicPort = PublicPort.Text
    End Sub

    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents SizeY As TextBox
    Friend WithEvents SizeX As TextBox
    Friend WithEvents Check1024 As CheckBox
    Friend WithEvents Check512 As CheckBox
    Friend WithEvents Check256 As CheckBox

    Private Sub Check256_CheckedChanged(sender As Object, e As EventArgs) Handles Check256.CheckedChanged
        If Check256.Checked = True Then
            Check512.Checked = False
            Check1024.Checked = False
            My.Settings.SizeX = "256"
            My.Settings.SizeY = "256"
            SizeX.Text = ""
            SizeY.Text = ""
        End If

    End Sub

    Private Sub Check512_CheckedChanged(sender As Object, e As EventArgs) Handles Check512.CheckedChanged
        If Check512.Checked = True Then
            Check256.Checked = False
            Check1024.Checked = False
            My.Settings.SizeX = "512"
            My.Settings.SizeY = "512"
            SizeX.Text = ""
            SizeY.Text = ""
        End If
    End Sub

    Private Sub Check1024_CheckedChanged(sender As Object, e As EventArgs) Handles Check1024.CheckedChanged
        If Check1024.Checked = True Then
            Check256.Checked = False
            Check512.Checked = False
            My.Settings.SizeX = "1024"
            My.Settings.SizeX = "1024"
            SizeX.Text = ""
            SizeY.Text = ""
        End If
    End Sub

    Private Sub SizeX_TextChanged(sender As Object, e As EventArgs) Handles SizeX.TextChanged
        If SizeX.Text <> "" Then
            Check256.Checked = False
            Check512.Checked = False
            Check1024.Checked = False
            My.Settings.SizeX = SizeX.Text
        End If

    End Sub

    Private Sub SizeY_TextChanged(sender As Object, e As EventArgs) Handles SizeY.TextChanged
        If SizeY.Text <> "" Then
            Check256.Checked = False
            Check512.Checked = False
            Check1024.Checked = False
            My.Settings.SizeY = SizeY.Text
        End If
    End Sub



End Class
