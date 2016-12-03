<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdvancedForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.CheckBox256 = New System.Windows.Forms.CheckBox()
        Me.CheckBox512 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1024 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SizeY = New System.Windows.Forms.TextBox()
        Me.SizeX = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DnsName = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.RegionPort = New System.Windows.Forms.TextBox()
        Me.PublicPort = New System.Windows.Forms.TextBox()
        Me.DiagPort = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PrivatePort = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DbPort = New System.Windows.Forms.TextBox()
        Me.Label = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.AutoBackupKeepFilesForDays = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.AutoBackupInterval = New System.Windows.Forms.ComboBox()
        Me.AutoBackup = New System.Windows.Forms.CheckBox()
        Me.Web = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.AdminEmail = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.AdminLast = New System.Windows.Forms.TextBox()
        Me.AdminFirst = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Password = New System.Windows.Forms.TextBox()
        Me.AllowGod = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ParcelGod = New System.Windows.Forms.CheckBox()
        Me.ManagerGod = New System.Windows.Forms.CheckBox()
        Me.RegionGod = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TimerInterval = New System.Windows.Forms.TextBox()
        Me.ChatSpeed = New System.Windows.Forms.ComboBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.SmtpPassword = New System.Windows.Forms.TextBox()
        Me.SmtpUsername = New System.Windows.Forms.TextBox()
        Me.AccountConfirmationRequired = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.WebStats = New System.Windows.Forms.CheckBox()
        Me.DbName = New System.Windows.Forms.TextBox()
        Me.DbUsername = New System.Windows.Forms.TextBox()
        Me.DbPassword = New System.Windows.Forms.TextBox()
        Me.DbConnection = New System.Windows.Forms.TextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Web.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'CheckBox256
        '
        Me.CheckBox256.AutoSize = True
        Me.CheckBox256.Location = New System.Drawing.Point(23, 19)
        Me.CheckBox256.Name = "CheckBox256"
        Me.CheckBox256.Size = New System.Drawing.Size(75, 17)
        Me.CheckBox256.TabIndex = 1
        Me.CheckBox256.Text = "256 X 256"
        Me.ToolTip1.SetToolTip(Me.CheckBox256, "Second Life sized single sim")
        Me.CheckBox256.UseVisualStyleBackColor = True
        '
        'CheckBox512
        '
        Me.CheckBox512.AutoSize = True
        Me.CheckBox512.Location = New System.Drawing.Point(23, 43)
        Me.CheckBox512.Name = "CheckBox512"
        Me.CheckBox512.Size = New System.Drawing.Size(75, 17)
        Me.CheckBox512.TabIndex = 2
        Me.CheckBox512.Text = "512 X 512"
        Me.ToolTip1.SetToolTip(Me.CheckBox512, "Two By Two (4 sims)")
        Me.CheckBox512.UseVisualStyleBackColor = True
        '
        'CheckBox1024
        '
        Me.CheckBox1024.AutoSize = True
        Me.CheckBox1024.Location = New System.Drawing.Point(23, 67)
        Me.CheckBox1024.Name = "CheckBox1024"
        Me.CheckBox1024.Size = New System.Drawing.Size(87, 17)
        Me.CheckBox1024.TabIndex = 3
        Me.CheckBox1024.Text = "1024 X 1024"
        Me.ToolTip1.SetToolTip(Me.CheckBox1024, "4 X 4 ( 16 sims)")
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
        Me.GroupBox1.Location = New System.Drawing.Point(3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(195, 126)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sim Size"
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "X"
        '
        'SizeY
        '
        Me.SizeY.Location = New System.Drawing.Point(106, 94)
        Me.SizeY.Name = "SizeY"
        Me.SizeY.Size = New System.Drawing.Size(33, 20)
        Me.SizeY.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.SizeY, "256 or higher")
        '
        'SizeX
        '
        Me.SizeX.Location = New System.Drawing.Point(40, 94)
        Me.SizeX.Name = "SizeX"
        Me.SizeX.Size = New System.Drawing.Size(33, 20)
        Me.SizeX.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.SizeX, "256 or higher")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.DnsName)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.RegionPort)
        Me.GroupBox2.Controls.Add(Me.PublicPort)
        Me.GroupBox2.Controls.Add(Me.DiagPort)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.PrivatePort)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(620, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(134, 190)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ports"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 130)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "DNS Name (if available)"
        '
        'DnsName
        '
        Me.DnsName.Location = New System.Drawing.Point(4, 153)
        Me.DnsName.Name = "DnsName"
        Me.DnsName.Size = New System.Drawing.Size(122, 20)
        Me.DnsName.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.DnsName, "MySQL port is normally 3306. I add one so it will not intyerfere with other insta" &
        "llations.")
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(69, 94)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 13)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Region"
        '
        'RegionPort
        '
        Me.RegionPort.Location = New System.Drawing.Point(18, 92)
        Me.RegionPort.Name = "RegionPort"
        Me.RegionPort.Size = New System.Drawing.Size(47, 20)
        Me.RegionPort.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.RegionPort, "Thr Region Port must be open to the internet for Hypergrid to work. Default:8004")
        '
        'PublicPort
        '
        Me.PublicPort.Location = New System.Drawing.Point(18, 47)
        Me.PublicPort.Name = "PublicPort"
        Me.PublicPort.Size = New System.Drawing.Size(47, 20)
        Me.PublicPort.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.PublicPort, "The Public port for your hypergrid. Default 8002")
        '
        'DiagPort
        '
        Me.DiagPort.Location = New System.Drawing.Point(18, 24)
        Me.DiagPort.Name = "DiagPort"
        Me.DiagPort.Size = New System.Drawing.Size(47, 20)
        Me.DiagPort.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.DiagPort, "This port will be opened briefly to allow Hypertgrid to be tested before Opensim " &
        "runs. Default is 8001")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(69, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Diagnostic"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(69, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Private"
        '
        'PrivatePort
        '
        Me.PrivatePort.Location = New System.Drawing.Point(18, 70)
        Me.PrivatePort.Name = "PrivatePort"
        Me.PrivatePort.Size = New System.Drawing.Size(47, 20)
        Me.PrivatePort.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.PrivatePort, "A Private Port used only on the LAN, never the WAN. Default: 8003")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(70, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Public "
        '
        'DbPort
        '
        Me.DbPort.Location = New System.Drawing.Point(6, 38)
        Me.DbPort.Name = "DbPort"
        Me.DbPort.Size = New System.Drawing.Size(47, 20)
        Me.DbPort.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.DbPort, "MySQL port is normally 3306. I add one so it will not intyerfere with other insta" &
        "llations.")
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.Location = New System.Drawing.Point(117, 38)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(26, 13)
        Me.Label.TabIndex = 10
        Me.Label.Text = "Port"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.AutoBackupKeepFilesForDays)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.AutoBackupInterval)
        Me.GroupBox3.Controls.Add(Me.AutoBackup)
        Me.GroupBox3.Location = New System.Drawing.Point(204, 7)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(180, 121)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Auto Backup"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(70, 86)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Keep for Days"
        '
        'AutoBackupKeepFilesForDays
        '
        Me.AutoBackupKeepFilesForDays.Location = New System.Drawing.Point(17, 81)
        Me.AutoBackupKeepFilesForDays.Name = "AutoBackupKeepFilesForDays"
        Me.AutoBackupKeepFilesForDays.Size = New System.Drawing.Size(47, 20)
        Me.AutoBackupKeepFilesForDays.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.AutoBackupKeepFilesForDays, "Backaups older than this number will be deleted")
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
        Me.ToolTip1.SetToolTip(Me.AutoBackupInterval, "The sim nust run this long and it will back up")
        '
        'AutoBackup
        '
        Me.AutoBackup.AutoSize = True
        Me.AutoBackup.Location = New System.Drawing.Point(17, 19)
        Me.AutoBackup.Name = "AutoBackup"
        Me.AutoBackup.Size = New System.Drawing.Size(65, 17)
        Me.AutoBackup.TabIndex = 2
        Me.AutoBackup.Text = "Enabled"
        Me.ToolTip1.SetToolTip(Me.AutoBackup, "Saves OAR files periodically")
        Me.AutoBackup.UseVisualStyleBackColor = True
        '
        'Web
        '
        Me.Web.Controls.Add(Me.Label17)
        Me.Web.Controls.Add(Me.AdminEmail)
        Me.Web.Controls.Add(Me.Label12)
        Me.Web.Controls.Add(Me.AdminLast)
        Me.Web.Controls.Add(Me.AdminFirst)
        Me.Web.Controls.Add(Me.Label11)
        Me.Web.Controls.Add(Me.Label10)
        Me.Web.Controls.Add(Me.Password)
        Me.Web.Location = New System.Drawing.Point(390, 8)
        Me.Web.Name = "Web"
        Me.Web.Size = New System.Drawing.Size(214, 120)
        Me.Web.TabIndex = 8
        Me.Web.TabStop = False
        Me.Web.Text = "Web Interface (0.9.1)"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 95)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(32, 13)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "Email"
        '
        'AdminEmail
        '
        Me.AdminEmail.Location = New System.Drawing.Point(69, 88)
        Me.AdminEmail.Name = "AdminEmail"
        Me.AdminEmail.Size = New System.Drawing.Size(100, 20)
        Me.AdminEmail.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.AdminEmail, "An email will be sent is someone registers for your grid")
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 45)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 13)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Last Name"
        '
        'AdminLast
        '
        Me.AdminLast.Location = New System.Drawing.Point(69, 42)
        Me.AdminLast.Name = "AdminLast"
        Me.AdminLast.Size = New System.Drawing.Size(100, 20)
        Me.AdminLast.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.AdminLast, "Last Name for Administering your grid")
        '
        'AdminFirst
        '
        Me.AdminFirst.Location = New System.Drawing.Point(69, 20)
        Me.AdminFirst.Name = "AdminFirst"
        Me.AdminFirst.Size = New System.Drawing.Size(100, 20)
        Me.AdminFirst.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.AdminFirst, "First Name for Administering your grid")
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
        Me.Label10.Location = New System.Drawing.Point(6, 69)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Password"
        '
        'Password
        '
        Me.Password.Location = New System.Drawing.Point(69, 66)
        Me.Password.Name = "Password"
        Me.Password.Size = New System.Drawing.Size(100, 20)
        Me.Password.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.Password, "Password for Administering your grid")
        Me.Password.UseSystemPasswordChar = True
        '
        'AllowGod
        '
        Me.AllowGod.AutoSize = True
        Me.AllowGod.Location = New System.Drawing.Point(23, 23)
        Me.AllowGod.Name = "AllowGod"
        Me.AllowGod.Size = New System.Drawing.Size(105, 17)
        Me.AllowGod.TabIndex = 16
        Me.AllowGod.Text = "Allow Grid gods?"
        Me.ToolTip1.SetToolTip(Me.AllowGod, "Enable all God Functions ")
        Me.AllowGod.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ParcelGod)
        Me.GroupBox4.Controls.Add(Me.ManagerGod)
        Me.GroupBox4.Controls.Add(Me.RegionGod)
        Me.GroupBox4.Controls.Add(Me.AllowGod)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 138)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(195, 118)
        Me.GroupBox4.TabIndex = 18
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Permissions"
        '
        'ParcelGod
        '
        Me.ParcelGod.AutoSize = True
        Me.ParcelGod.Location = New System.Drawing.Point(24, 92)
        Me.ParcelGod.Name = "ParcelGod"
        Me.ParcelGod.Size = New System.Drawing.Size(127, 17)
        Me.ParcelGod.TabIndex = 20
        Me.ParcelGod.Text = "Parcel Owner is god?"
        Me.ParcelGod.UseVisualStyleBackColor = True
        '
        'ManagerGod
        '
        Me.ManagerGod.AutoSize = True
        Me.ManagerGod.Location = New System.Drawing.Point(23, 69)
        Me.ManagerGod.Name = "ManagerGod"
        Me.ManagerGod.Size = New System.Drawing.Size(141, 17)
        Me.ManagerGod.TabIndex = 19
        Me.ManagerGod.Text = "Region manager is god?"
        Me.ManagerGod.UseVisualStyleBackColor = True
        '
        'RegionGod
        '
        Me.RegionGod.AutoSize = True
        Me.RegionGod.Location = New System.Drawing.Point(23, 46)
        Me.RegionGod.Name = "RegionGod"
        Me.RegionGod.Size = New System.Drawing.Size(129, 17)
        Me.RegionGod.TabIndex = 18
        Me.RegionGod.Text = "Region owner is god?"
        Me.RegionGod.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.TimerInterval)
        Me.GroupBox5.Controls.Add(Me.ChatSpeed)
        Me.GroupBox5.Location = New System.Drawing.Point(204, 140)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(180, 116)
        Me.GroupBox5.TabIndex = 22
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Personality"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(45, 64)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(43, 13)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "(0 = off)"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(11, 49)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(135, 13)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "Wallpaper Time in seconds"
        '
        'TimerInterval
        '
        Me.TimerInterval.Location = New System.Drawing.Point(105, 64)
        Me.TimerInterval.Name = "TimerInterval"
        Me.TimerInterval.Size = New System.Drawing.Size(39, 20)
        Me.TimerInterval.TabIndex = 24
        Me.ToolTip1.SetToolTip(Me.TimerInterval, "The cycle time for the wall paper - in seconds")
        '
        'ChatSpeed
        '
        Me.ChatSpeed.FormattingEnabled = True
        Me.ChatSpeed.Items.AddRange(New Object() {"Sleepy", "Awake", "After Coffee", "Too much Coffee"})
        Me.ChatSpeed.Location = New System.Drawing.Point(25, 19)
        Me.ChatSpeed.Name = "ChatSpeed"
        Me.ChatSpeed.Size = New System.Drawing.Size(121, 21)
        Me.ChatSpeed.TabIndex = 22
        Me.ToolTip1.SetToolTip(Me.ChatSpeed, "The speed the sleepy chat occurs")
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label18)
        Me.GroupBox6.Controls.Add(Me.Label14)
        Me.GroupBox6.Controls.Add(Me.SmtpPassword)
        Me.GroupBox6.Controls.Add(Me.SmtpUsername)
        Me.GroupBox6.Controls.Add(Me.AccountConfirmationRequired)
        Me.GroupBox6.Location = New System.Drawing.Point(390, 140)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(214, 116)
        Me.GroupBox6.TabIndex = 23
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Grid Registrations (0.9.1)"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(124, 68)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 13)
        Me.Label18.TabIndex = 21
        Me.Label18.Text = "Gmail Password"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(124, 45)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 13)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "Gmail Email"
        '
        'SmtpPassword
        '
        Me.SmtpPassword.Location = New System.Drawing.Point(17, 68)
        Me.SmtpPassword.Name = "SmtpPassword"
        Me.SmtpPassword.Size = New System.Drawing.Size(100, 20)
        Me.SmtpPassword.TabIndex = 19
        Me.ToolTip1.SetToolTip(Me.SmtpPassword, "Gmail Passeord")
        Me.SmtpPassword.UseSystemPasswordChar = True
        '
        'SmtpUsername
        '
        Me.SmtpUsername.Location = New System.Drawing.Point(17, 42)
        Me.SmtpUsername.Name = "SmtpUsername"
        Me.SmtpUsername.Size = New System.Drawing.Size(100, 20)
        Me.SmtpUsername.TabIndex = 18
        Me.ToolTip1.SetToolTip(Me.SmtpUsername, "A Gmail email name to send email from")
        '
        'AccountConfirmationRequired
        '
        Me.AccountConfirmationRequired.AutoSize = True
        Me.AccountConfirmationRequired.Location = New System.Drawing.Point(17, 19)
        Me.AccountConfirmationRequired.Name = "AccountConfirmationRequired"
        Me.AccountConfirmationRequired.Size = New System.Drawing.Size(136, 17)
        Me.AccountConfirmationRequired.TabIndex = 17
        Me.AccountConfirmationRequired.Text = "Confirmation Required?"
        Me.ToolTip1.SetToolTip(Me.AccountConfirmationRequired, "If checked, you must log into the web interface and approve the new users.")
        Me.AccountConfirmationRequired.UseVisualStyleBackColor = True
        '
        'WebStats
        '
        Me.WebStats.AutoSize = True
        Me.WebStats.Location = New System.Drawing.Point(20, 19)
        Me.WebStats.Name = "WebStats"
        Me.WebStats.Size = New System.Drawing.Size(65, 17)
        Me.WebStats.TabIndex = 25
        Me.WebStats.Text = "Enabled"
        Me.ToolTip1.SetToolTip(Me.WebStats, "SHows Sim Stats on the web")
        Me.WebStats.UseVisualStyleBackColor = True
        '
        'DbName
        '
        Me.DbName.Location = New System.Drawing.Point(6, 61)
        Me.DbName.Name = "DbName"
        Me.DbName.Size = New System.Drawing.Size(107, 20)
        Me.DbName.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.DbName, "MySQL port is normally 3306. I add one so it will not intyerfere with other insta" &
        "llations.")
        '
        'DbUsername
        '
        Me.DbUsername.Location = New System.Drawing.Point(6, 83)
        Me.DbUsername.Name = "DbUsername"
        Me.DbUsername.Size = New System.Drawing.Size(107, 20)
        Me.DbUsername.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.DbUsername, "MySQL port is normally 3306. I add one so it will not intyerfere with other insta" &
        "llations.")
        '
        'DbPassword
        '
        Me.DbPassword.Location = New System.Drawing.Point(6, 105)
        Me.DbPassword.Name = "DbPassword"
        Me.DbPassword.Size = New System.Drawing.Size(107, 20)
        Me.DbPassword.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.DbPassword, "MySQL port is normally 3306. I add one so it will not intyerfere with other insta" &
        "llations.")
        '
        'DbConnection
        '
        Me.DbConnection.Location = New System.Drawing.Point(6, 17)
        Me.DbConnection.Name = "DbConnection"
        Me.DbConnection.Size = New System.Drawing.Size(105, 20)
        Me.DbConnection.TabIndex = 18
        Me.ToolTip1.SetToolTip(Me.DbConnection, "MySQL port is normally 3306. I add one so it will not intyerfere with other insta" &
        "llations.")
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.WebStats)
        Me.GroupBox7.Location = New System.Drawing.Point(624, 204)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(130, 48)
        Me.GroupBox7.TabIndex = 26
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "WebStats"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label23)
        Me.GroupBox8.Controls.Add(Me.DbConnection)
        Me.GroupBox8.Controls.Add(Me.Label22)
        Me.GroupBox8.Controls.Add(Me.Label21)
        Me.GroupBox8.Controls.Add(Me.DbPassword)
        Me.GroupBox8.Controls.Add(Me.DbUsername)
        Me.GroupBox8.Controls.Add(Me.Label20)
        Me.GroupBox8.Controls.Add(Me.DbName)
        Me.GroupBox8.Controls.Add(Me.Label)
        Me.GroupBox8.Controls.Add(Me.DbPort)
        Me.GroupBox8.Location = New System.Drawing.Point(771, 8)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(189, 131)
        Me.GroupBox8.TabIndex = 27
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Database"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(117, 17)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(61, 13)
        Me.Label23.TabIndex = 19
        Me.Label23.Text = "Connection"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(119, 105)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(53, 13)
        Me.Label22.TabIndex = 17
        Me.Label22.Text = "Password"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(119, 83)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(55, 13)
        Me.Label21.TabIndex = 16
        Me.Label21.Text = "Username"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(119, 61)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(53, 13)
        Me.Label20.TabIndex = 13
        Me.Label20.Text = "Database"
        '
        'AdvancedForm
        '
        Me.ClientSize = New System.Drawing.Size(976, 261)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Web)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
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
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
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
    Friend WithEvents DiagPort As TextBox
    Friend WithEvents DbPort As TextBox
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
    Friend WithEvents AllowGod As CheckBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents ManagerGod As CheckBox
    Friend WithEvents RegionGod As CheckBox
    Friend WithEvents ParcelGod As CheckBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents TimerInterval As TextBox
    Friend WithEvents ChatSpeed As ComboBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Label17 As Label
    Friend WithEvents AdminEmail As TextBox
    Friend WithEvents AccountConfirmationRequired As CheckBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents SmtpPassword As TextBox
    Friend WithEvents SmtpUsername As TextBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label7 As Label
    Friend WithEvents DnsName As TextBox
    Friend WithEvents WebStats As CheckBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents Label21 As Label
    Friend WithEvents DbPassword As TextBox
    Friend WithEvents DbUsername As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents DbName As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents DbConnection As TextBox
End Class
