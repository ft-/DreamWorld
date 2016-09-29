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
        Me.Mysql = New System.Windows.Forms.TextBox()
        Me.Label = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.WifiPort = New System.Windows.Forms.TextBox()
        Me.PublicPort = New System.Windows.Forms.TextBox()
        Me.DiagPort = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PrivatePort = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.AutoBackupKeepFilesForDays = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.AutoBackupInterval = New System.Windows.Forms.ComboBox()
        Me.AutoBackup = New System.Windows.Forms.CheckBox()
        Me.Web = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.AdminLast = New System.Windows.Forms.TextBox()
        Me.AdminFirst = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Password = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.RegionPort = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Web.SuspendLayout()
        Me.SuspendLayout()
        '
        'CheckBox256
        '
        Me.CheckBox256.AutoSize = True
        Me.CheckBox256.Location = New System.Drawing.Point(23, 35)
        Me.CheckBox256.Name = "CheckBox256"
        Me.CheckBox256.Size = New System.Drawing.Size(75, 17)
        Me.CheckBox256.TabIndex = 1
        Me.CheckBox256.Text = "256 X 256"
        Me.CheckBox256.UseVisualStyleBackColor = True
        '
        'CheckBox512
        '
        Me.CheckBox512.AutoSize = True
        Me.CheckBox512.Location = New System.Drawing.Point(23, 59)
        Me.CheckBox512.Name = "CheckBox512"
        Me.CheckBox512.Size = New System.Drawing.Size(75, 17)
        Me.CheckBox512.TabIndex = 2
        Me.CheckBox512.Text = "512 X 512"
        Me.CheckBox512.UseVisualStyleBackColor = True
        '
        'CheckBox1024
        '
        Me.CheckBox1024.AutoSize = True
        Me.CheckBox1024.Location = New System.Drawing.Point(23, 83)
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
        Me.GroupBox1.Size = New System.Drawing.Size(195, 148)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sim Size"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(86, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Y"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "X"
        '
        'SizeY
        '
        Me.SizeY.Location = New System.Drawing.Point(106, 110)
        Me.SizeY.Name = "SizeY"
        Me.SizeY.Size = New System.Drawing.Size(33, 20)
        Me.SizeY.TabIndex = 1
        '
        'SizeX
        '
        Me.SizeX.Location = New System.Drawing.Point(40, 110)
        Me.SizeX.Name = "SizeX"
        Me.SizeX.Size = New System.Drawing.Size(33, 20)
        Me.SizeX.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.RegionPort)
        Me.GroupBox2.Controls.Add(Me.Mysql)
        Me.GroupBox2.Controls.Add(Me.Label)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.WifiPort)
        Me.GroupBox2.Controls.Add(Me.PublicPort)
        Me.GroupBox2.Controls.Add(Me.DiagPort)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.PrivatePort)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(223, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(157, 177)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ports"
        '
        'Mysql
        '
        Me.Mysql.Location = New System.Drawing.Point(17, 141)
        Me.Mysql.Name = "Mysql"
        Me.Mysql.Size = New System.Drawing.Size(47, 20)
        Me.Mysql.TabIndex = 11
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.Location = New System.Drawing.Point(69, 144)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(36, 13)
        Me.Label.TabIndex = 10
        Me.Label.Text = "MySql"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(69, 124)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(25, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Wifi"
        '
        'WifiPort
        '
        Me.WifiPort.Location = New System.Drawing.Point(17, 119)
        Me.WifiPort.Name = "WifiPort"
        Me.WifiPort.Size = New System.Drawing.Size(47, 20)
        Me.WifiPort.TabIndex = 8
        '
        'PublicPort
        '
        Me.PublicPort.Location = New System.Drawing.Point(17, 51)
        Me.PublicPort.Name = "PublicPort"
        Me.PublicPort.Size = New System.Drawing.Size(47, 20)
        Me.PublicPort.TabIndex = 0
        '
        'DiagPort
        '
        Me.DiagPort.Location = New System.Drawing.Point(17, 25)
        Me.DiagPort.Name = "DiagPort"
        Me.DiagPort.Size = New System.Drawing.Size(47, 20)
        Me.DiagPort.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(68, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Diagnostic"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(68, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Private"
        '
        'PrivatePort
        '
        Me.PrivatePort.Location = New System.Drawing.Point(17, 74)
        Me.PrivatePort.Name = "PrivatePort"
        Me.PrivatePort.Size = New System.Drawing.Size(47, 20)
        Me.PrivatePort.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(69, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Public "
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.AutoBackupKeepFilesForDays)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.AutoBackupInterval)
        Me.GroupBox3.Controls.Add(Me.AutoBackup)
        Me.GroupBox3.Location = New System.Drawing.Point(386, 13)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(180, 148)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Auto Backup"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 87)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Keep for Days"
        '
        'AutoBackupKeepFilesForDays
        '
        Me.AutoBackupKeepFilesForDays.Location = New System.Drawing.Point(94, 84)
        Me.AutoBackupKeepFilesForDays.Name = "AutoBackupKeepFilesForDays"
        Me.AutoBackupKeepFilesForDays.Size = New System.Drawing.Size(47, 20)
        Me.AutoBackupKeepFilesForDays.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 38)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Interval:"
        '
        'AutoBackupInterval
        '
        Me.AutoBackupInterval.AutoCompleteCustomSource.AddRange(New String() {"1 Hour", "4 Hour", "12 Hour", "Daily", "Weekly"})
        Me.AutoBackupInterval.FormattingEnabled = True
        Me.AutoBackupInterval.Items.AddRange(New Object() {"Hourly", "12 Hour", "Daily", "Weekly"})
        Me.AutoBackupInterval.Location = New System.Drawing.Point(17, 54)
        Me.AutoBackupInterval.Name = "AutoBackupInterval"
        Me.AutoBackupInterval.Size = New System.Drawing.Size(121, 21)
        Me.AutoBackupInterval.TabIndex = 4
        '
        'AutoBackup
        '
        Me.AutoBackup.AutoSize = True
        Me.AutoBackup.Location = New System.Drawing.Point(17, 19)
        Me.AutoBackup.Name = "AutoBackup"
        Me.AutoBackup.Size = New System.Drawing.Size(65, 17)
        Me.AutoBackup.TabIndex = 2
        Me.AutoBackup.Text = "Enabled"
        Me.AutoBackup.UseVisualStyleBackColor = True
        '
        'Web
        '
        Me.Web.Controls.Add(Me.Label12)
        Me.Web.Controls.Add(Me.AdminLast)
        Me.Web.Controls.Add(Me.AdminFirst)
        Me.Web.Controls.Add(Me.Label11)
        Me.Web.Controls.Add(Me.Label10)
        Me.Web.Controls.Add(Me.Password)
        Me.Web.Location = New System.Drawing.Point(572, 13)
        Me.Web.Name = "Web"
        Me.Web.Size = New System.Drawing.Size(145, 144)
        Me.Web.TabIndex = 8
        Me.Web.TabStop = False
        Me.Web.Text = "Web Interface"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 60)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 13)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Last Name"
        '
        'AdminLast
        '
        Me.AdminLast.Location = New System.Drawing.Point(9, 76)
        Me.AdminLast.Name = "AdminLast"
        Me.AdminLast.Size = New System.Drawing.Size(100, 20)
        Me.AdminLast.TabIndex = 12
        '
        'AdminFirst
        '
        Me.AdminFirst.Location = New System.Drawing.Point(9, 39)
        Me.AdminFirst.Name = "AdminFirst"
        Me.AdminFirst.Size = New System.Drawing.Size(100, 20)
        Me.AdminFirst.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "First Name"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 102)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Password"
        '
        'Password
        '
        Me.Password.Location = New System.Drawing.Point(9, 118)
        Me.Password.Name = "Password"
        Me.Password.Size = New System.Drawing.Size(100, 20)
        Me.Password.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(68, 98)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 13)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Region"
        '
        'RegionPort
        '
        Me.RegionPort.Location = New System.Drawing.Point(17, 96)
        Me.RegionPort.Name = "RegionPort"
        Me.RegionPort.Size = New System.Drawing.Size(47, 20)
        Me.RegionPort.TabIndex = 12
        '
        'AdvancedForm
        '
        Me.ClientSize = New System.Drawing.Size(729, 201)
        Me.Controls.Add(Me.Web)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "AdvancedForm"
        Me.Text = "Advanced"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Web.ResumeLayout(False)
        Me.Web.PerformLayout()
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
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents WifiPort As TextBox
    Friend WithEvents DiagPort As TextBox
    Friend WithEvents Mysql As TextBox
    Friend WithEvents Label As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents AutoBackup As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents AutoBackupInterval As ComboBox
    Friend WithEvents AutoBackupKeepFilesForDays As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Web As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Password As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents AdminLast As TextBox
    Friend WithEvents AdminFirst As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents RegionPort As TextBox
End Class
