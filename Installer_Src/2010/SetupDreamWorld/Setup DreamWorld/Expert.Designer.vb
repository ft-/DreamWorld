<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Expert
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UniqueId = New System.Windows.Forms.TextBox()
        Me.DNSButton = New System.Windows.Forms.Button()
        Me.DNSHelp = New System.Windows.Forms.PictureBox()
        Me.HypericaButton = New System.Windows.Forms.Button()
        Me.TestButton1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GridName = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.SplashPage = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GodHelp = New System.Windows.Forms.PictureBox()
        Me.ManagerGod = New System.Windows.Forms.CheckBox()
        Me.RegionGod = New System.Windows.Forms.CheckBox()
        Me.AllowGod = New System.Windows.Forms.CheckBox()
        Me.Web = New System.Windows.Forms.GroupBox()
        Me.WifiEnabled = New System.Windows.Forms.CheckBox()
        Me.GmailPassword = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GmailUsername = New System.Windows.Forms.TextBox()
        Me.AdminEmail = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.AccountConfirmationRequired = New System.Windows.Forms.CheckBox()
        Me.AdminLast = New System.Windows.Forms.TextBox()
        Me.AdminFirst = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.AdminPassword = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.HTTPPort = New System.Windows.Forms.TextBox()
        Me.PrivatePort = New System.Windows.Forms.TextBox()
        Me.DiagnosticPort = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.StatsButton = New System.Windows.Forms.Button()
        Me.WebStats = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PhysicsSeparate = New System.Windows.Forms.RadioButton()
        Me.PhysicsNone = New System.Windows.Forms.RadioButton()
        Me.PhysicsubODE = New System.Windows.Forms.RadioButton()
        Me.PhysicsBullet = New System.Windows.Forms.RadioButton()
        Me.PhysicsODE = New System.Windows.Forms.RadioButton()
        Me.GridGroup = New System.Windows.Forms.GroupBox()
        Me.Dbnameindex = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.RobustDbPort = New System.Windows.Forms.TextBox()
        Me.RobustDbName = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.RobustDBPassword = New System.Windows.Forms.TextBox()
        Me.RobustDBUsername = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.RegionMySqlPassword = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.RegionDBUsername = New System.Windows.Forms.TextBox()
        Me.RegionDbName = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.StandaloneGroup = New System.Windows.Forms.GroupBox()
        Me.uPnPEnabled = New System.Windows.Forms.CheckBox()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DNSHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.GodHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Web.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GridGroup.SuspendLayout()
        Me.StandaloneGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.UniqueId)
        Me.GroupBox3.Controls.Add(Me.DNSButton)
        Me.GroupBox3.Controls.Add(Me.DNSHelp)
        Me.GroupBox3.Controls.Add(Me.HypericaButton)
        Me.GroupBox3.Controls.Add(Me.TestButton1)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.GridName)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.SplashPage)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(192, 299)
        Me.GroupBox3.TabIndex = 49
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Grid"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 1863
        Me.Label1.Text = "Unique Grid ID"
        '
        'UniqueId
        '
        Me.UniqueId.Location = New System.Drawing.Point(9, 105)
        Me.UniqueId.Name = "UniqueId"
        Me.UniqueId.Size = New System.Drawing.Size(173, 20)
        Me.UniqueId.TabIndex = 1862
        '
        'DNSButton
        '
        Me.DNSButton.Location = New System.Drawing.Point(6, 19)
        Me.DNSButton.Name = "DNSButton"
        Me.DNSButton.Size = New System.Drawing.Size(170, 23)
        Me.DNSButton.TabIndex = 1861
        Me.DNSButton.Text = "DNS Name or IP Address"
        Me.DNSButton.UseVisualStyleBackColor = True
        '
        'DNSHelp
        '
        Me.DNSHelp.Image = Global.Outworldz.My.Resources.Resources.about
        Me.DNSHelp.Location = New System.Drawing.Point(88, 48)
        Me.DNSHelp.Name = "DNSHelp"
        Me.DNSHelp.Size = New System.Drawing.Size(28, 27)
        Me.DNSHelp.TabIndex = 1859
        Me.DNSHelp.TabStop = False
        '
        'HypericaButton
        '
        Me.HypericaButton.Location = New System.Drawing.Point(9, 181)
        Me.HypericaButton.Name = "HypericaButton"
        Me.HypericaButton.Size = New System.Drawing.Size(172, 23)
        Me.HypericaButton.TabIndex = 34
        Me.HypericaButton.Text = "Add Details to Directory"
        Me.HypericaButton.UseVisualStyleBackColor = True
        '
        'TestButton1
        '
        Me.TestButton1.Location = New System.Drawing.Point(6, 50)
        Me.TestButton1.Name = "TestButton1"
        Me.TestButton1.Size = New System.Drawing.Size(75, 23)
        Me.TestButton1.TabIndex = 33
        Me.TestButton1.Text = "Test DNS"
        Me.TestButton1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 137)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "This Grid's Friendly Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 28
        '
        'GridName
        '
        Me.GridName.Location = New System.Drawing.Point(9, 155)
        Me.GridName.Name = "GridName"
        Me.GridName.Size = New System.Drawing.Size(173, 20)
        Me.GridName.TabIndex = 10
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 230)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(139, 13)
        Me.Label19.TabIndex = 46
        Me.Label19.Text = "Viewer Splash Screen URL:"
        '
        'SplashPage
        '
        Me.SplashPage.Location = New System.Drawing.Point(6, 248)
        Me.SplashPage.Name = "SplashPage"
        Me.SplashPage.Size = New System.Drawing.Size(177, 20)
        Me.SplashPage.TabIndex = 45
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GodHelp)
        Me.GroupBox4.Controls.Add(Me.ManagerGod)
        Me.GroupBox4.Controls.Add(Me.RegionGod)
        Me.GroupBox4.Controls.Add(Me.AllowGod)
        Me.GroupBox4.Location = New System.Drawing.Point(222, 149)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 101)
        Me.GroupBox4.TabIndex = 48
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Permissions"
        '
        'GodHelp
        '
        Me.GodHelp.Image = Global.Outworldz.My.Resources.Resources.about
        Me.GodHelp.Location = New System.Drawing.Point(134, 6)
        Me.GodHelp.Name = "GodHelp"
        Me.GodHelp.Size = New System.Drawing.Size(30, 34)
        Me.GodHelp.TabIndex = 1857
        Me.GodHelp.TabStop = False
        '
        'ManagerGod
        '
        Me.ManagerGod.AutoSize = True
        Me.ManagerGod.Location = New System.Drawing.Point(23, 69)
        Me.ManagerGod.Name = "ManagerGod"
        Me.ManagerGod.Size = New System.Drawing.Size(141, 17)
        Me.ManagerGod.TabIndex = 6
        Me.ManagerGod.Text = "Region manager is god?"
        Me.ManagerGod.UseVisualStyleBackColor = True
        '
        'RegionGod
        '
        Me.RegionGod.AutoSize = True
        Me.RegionGod.Location = New System.Drawing.Point(23, 46)
        Me.RegionGod.Name = "RegionGod"
        Me.RegionGod.Size = New System.Drawing.Size(132, 17)
        Me.RegionGod.TabIndex = 1855
        Me.RegionGod.Text = "Region owner is god? "
        Me.RegionGod.UseVisualStyleBackColor = True
        '
        'AllowGod
        '
        Me.AllowGod.AutoSize = True
        Me.AllowGod.Location = New System.Drawing.Point(23, 23)
        Me.AllowGod.Name = "AllowGod"
        Me.AllowGod.Size = New System.Drawing.Size(105, 17)
        Me.AllowGod.TabIndex = 4
        Me.AllowGod.Text = "Allow Grid gods?"
        Me.AllowGod.UseVisualStyleBackColor = True
        '
        'Web
        '
        Me.Web.Controls.Add(Me.WifiEnabled)
        Me.Web.Controls.Add(Me.GmailPassword)
        Me.Web.Controls.Add(Me.Label18)
        Me.Web.Controls.Add(Me.Label14)
        Me.Web.Controls.Add(Me.Label17)
        Me.Web.Controls.Add(Me.GmailUsername)
        Me.Web.Controls.Add(Me.AdminEmail)
        Me.Web.Controls.Add(Me.Label12)
        Me.Web.Controls.Add(Me.AccountConfirmationRequired)
        Me.Web.Controls.Add(Me.AdminLast)
        Me.Web.Controls.Add(Me.AdminFirst)
        Me.Web.Controls.Add(Me.Label11)
        Me.Web.Controls.Add(Me.Label10)
        Me.Web.Controls.Add(Me.AdminPassword)
        Me.Web.Location = New System.Drawing.Point(431, 155)
        Me.Web.Name = "Web"
        Me.Web.Size = New System.Drawing.Size(192, 224)
        Me.Web.TabIndex = 47
        Me.Web.TabStop = False
        Me.Web.Text = "Wifi Interface Admin"
        '
        'WifiEnabled
        '
        Me.WifiEnabled.AutoSize = True
        Me.WifiEnabled.Location = New System.Drawing.Point(26, 19)
        Me.WifiEnabled.Name = "WifiEnabled"
        Me.WifiEnabled.Size = New System.Drawing.Size(65, 17)
        Me.WifiEnabled.TabIndex = 22
        Me.WifiEnabled.Text = "Enabled"
        Me.ToolTip1.SetToolTip(Me.WifiEnabled, "A Web UI for creating and managing User Accounts")
        Me.WifiEnabled.UseVisualStyleBackColor = True
        '
        'GmailPassword
        '
        Me.GmailPassword.Location = New System.Drawing.Point(86, 186)
        Me.GmailPassword.Name = "GmailPassword"
        Me.GmailPassword.Size = New System.Drawing.Size(100, 20)
        Me.GmailPassword.TabIndex = 20
        Me.GmailPassword.UseSystemPasswordChar = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(4, 189)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 13)
        Me.Label18.TabIndex = 21
        Me.Label18.Text = "Gmail Password"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(4, 168)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 13)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "Gmail Email"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(4, 119)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(32, 13)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "Email"
        '
        'GmailUsername
        '
        Me.GmailUsername.Location = New System.Drawing.Point(86, 161)
        Me.GmailUsername.Name = "GmailUsername"
        Me.GmailUsername.Size = New System.Drawing.Size(100, 20)
        Me.GmailUsername.TabIndex = 19
        '
        'AdminEmail
        '
        Me.AdminEmail.Location = New System.Drawing.Point(86, 112)
        Me.AdminEmail.Name = "AdminEmail"
        Me.AdminEmail.Size = New System.Drawing.Size(100, 20)
        Me.AdminEmail.TabIndex = 17
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(4, 69)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 13)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Last Name"
        '
        'AccountConfirmationRequired
        '
        Me.AccountConfirmationRequired.AutoSize = True
        Me.AccountConfirmationRequired.Location = New System.Drawing.Point(21, 139)
        Me.AccountConfirmationRequired.Name = "AccountConfirmationRequired"
        Me.AccountConfirmationRequired.Size = New System.Drawing.Size(136, 17)
        Me.AccountConfirmationRequired.TabIndex = 18
        Me.AccountConfirmationRequired.Text = "Confirmation Required?"
        Me.AccountConfirmationRequired.UseVisualStyleBackColor = True
        '
        'AdminLast
        '
        Me.AdminLast.Location = New System.Drawing.Point(86, 66)
        Me.AdminLast.Name = "AdminLast"
        Me.AdminLast.Size = New System.Drawing.Size(100, 20)
        Me.AdminLast.TabIndex = 15
        '
        'AdminFirst
        '
        Me.AdminFirst.Location = New System.Drawing.Point(86, 44)
        Me.AdminFirst.Name = "AdminFirst"
        Me.AdminFirst.Size = New System.Drawing.Size(100, 20)
        Me.AdminFirst.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(4, 47)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "First Name"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 93)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Password"
        '
        'AdminPassword
        '
        Me.AdminPassword.Location = New System.Drawing.Point(86, 90)
        Me.AdminPassword.Name = "AdminPassword"
        Me.AdminPassword.Size = New System.Drawing.Size(100, 20)
        Me.AdminPassword.TabIndex = 16
        Me.AdminPassword.UseSystemPasswordChar = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.uPnPEnabled)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.HTTPPort)
        Me.GroupBox2.Controls.Add(Me.PrivatePort)
        Me.GroupBox2.Controls.Add(Me.DiagnosticPort)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(424, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(199, 121)
        Me.GroupBox2.TabIndex = 44
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ports"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 103)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Private Port"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Diagnostic Port"
        '
        'HTTPPort
        '
        Me.HTTPPort.Location = New System.Drawing.Point(138, 70)
        Me.HTTPPort.Name = "HTTPPort"
        Me.HTTPPort.Size = New System.Drawing.Size(47, 20)
        Me.HTTPPort.TabIndex = 39
        '
        'PrivatePort
        '
        Me.PrivatePort.Location = New System.Drawing.Point(138, 96)
        Me.PrivatePort.Name = "PrivatePort"
        Me.PrivatePort.Size = New System.Drawing.Size(47, 20)
        Me.PrivatePort.TabIndex = 35
        '
        'DiagnosticPort
        '
        Me.DiagnosticPort.Location = New System.Drawing.Point(139, 44)
        Me.DiagnosticPort.Name = "DiagnosticPort"
        Me.DiagnosticPort.Size = New System.Drawing.Size(47, 20)
        Me.DiagnosticPort.TabIndex = 34
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Http Port"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.StatsButton)
        Me.GroupBox7.Controls.Add(Me.WebStats)
        Me.GroupBox7.Location = New System.Drawing.Point(229, 263)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(189, 48)
        Me.GroupBox7.TabIndex = 43
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "WebStats"
        Me.GroupBox7.Visible = False
        '
        'StatsButton
        '
        Me.StatsButton.Location = New System.Drawing.Point(83, 15)
        Me.StatsButton.Name = "StatsButton"
        Me.StatsButton.Size = New System.Drawing.Size(75, 23)
        Me.StatsButton.TabIndex = 22
        Me.StatsButton.Text = "View"
        Me.StatsButton.UseVisualStyleBackColor = True
        '
        'WebStats
        '
        Me.WebStats.AutoSize = True
        Me.WebStats.Location = New System.Drawing.Point(12, 19)
        Me.WebStats.Name = "WebStats"
        Me.WebStats.Size = New System.Drawing.Size(59, 17)
        Me.WebStats.TabIndex = 21
        Me.WebStats.Text = "Enable"
        Me.WebStats.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PhysicsSeparate)
        Me.GroupBox1.Controls.Add(Me.PhysicsNone)
        Me.GroupBox1.Controls.Add(Me.PhysicsubODE)
        Me.GroupBox1.Controls.Add(Me.PhysicsBullet)
        Me.GroupBox1.Controls.Add(Me.PhysicsODE)
        Me.GroupBox1.Location = New System.Drawing.Point(219, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(189, 115)
        Me.GroupBox1.TabIndex = 42
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
        'GridGroup
        '
        Me.GridGroup.Controls.Add(Me.Dbnameindex)
        Me.GridGroup.Controls.Add(Me.Label9)
        Me.GridGroup.Controls.Add(Me.RobustDbPort)
        Me.GridGroup.Controls.Add(Me.RobustDbName)
        Me.GridGroup.Controls.Add(Me.Label15)
        Me.GridGroup.Controls.Add(Me.Label8)
        Me.GridGroup.Controls.Add(Me.RobustDBPassword)
        Me.GridGroup.Controls.Add(Me.RobustDBUsername)
        Me.GridGroup.Location = New System.Drawing.Point(629, 12)
        Me.GridGroup.Name = "GridGroup"
        Me.GridGroup.Size = New System.Drawing.Size(243, 137)
        Me.GridGroup.TabIndex = 53
        Me.GridGroup.TabStop = False
        Me.GridGroup.Text = "Robust Database"
        '
        'Dbnameindex
        '
        Me.Dbnameindex.AutoSize = True
        Me.Dbnameindex.Location = New System.Drawing.Point(16, 27)
        Me.Dbnameindex.Name = "Dbnameindex"
        Me.Dbnameindex.Size = New System.Drawing.Size(72, 13)
        Me.Dbnameindex.TabIndex = 35
        Me.Dbnameindex.Text = "Robust Name"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 79)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "Password"
        '
        'RobustDbPort
        '
        Me.RobustDbPort.Location = New System.Drawing.Point(122, 105)
        Me.RobustDbPort.Name = "RobustDbPort"
        Me.RobustDbPort.Size = New System.Drawing.Size(47, 20)
        Me.RobustDbPort.TabIndex = 33
        '
        'RobustDbName
        '
        Me.RobustDbName.Location = New System.Drawing.Point(118, 27)
        Me.RobustDbName.Name = "RobustDbName"
        Me.RobustDbName.Size = New System.Drawing.Size(107, 20)
        Me.RobustDbName.TabIndex = 36
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(14, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 13)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "Username"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 105)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "MySql Port"
        '
        'RobustDBPassword
        '
        Me.RobustDBPassword.Location = New System.Drawing.Point(120, 79)
        Me.RobustDBPassword.Name = "RobustDBPassword"
        Me.RobustDBPassword.Size = New System.Drawing.Size(107, 20)
        Me.RobustDBPassword.TabIndex = 37
        Me.RobustDBPassword.UseSystemPasswordChar = True
        '
        'RobustDBUsername
        '
        Me.RobustDBUsername.Location = New System.Drawing.Point(120, 53)
        Me.RobustDBUsername.Name = "RobustDBUsername"
        Me.RobustDBUsername.Size = New System.Drawing.Size(107, 20)
        Me.RobustDBUsername.TabIndex = 36
        '
        'RegionMySqlPassword
        '
        Me.RegionMySqlPassword.Location = New System.Drawing.Point(120, 77)
        Me.RegionMySqlPassword.Name = "RegionMySqlPassword"
        Me.RegionMySqlPassword.Size = New System.Drawing.Size(107, 20)
        Me.RegionMySqlPassword.TabIndex = 32
        Me.RegionMySqlPassword.UseSystemPasswordChar = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(17, 48)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(55, 13)
        Me.Label21.TabIndex = 16
        Me.Label21.Text = "Username"
        '
        'RegionDBUsername
        '
        Me.RegionDBUsername.Location = New System.Drawing.Point(120, 48)
        Me.RegionDBUsername.Name = "RegionDBUsername"
        Me.RegionDBUsername.Size = New System.Drawing.Size(107, 20)
        Me.RegionDBUsername.TabIndex = 31
        '
        'RegionDbName
        '
        Me.RegionDbName.Location = New System.Drawing.Point(120, 22)
        Me.RegionDbName.Name = "RegionDbName"
        Me.RegionDbName.Size = New System.Drawing.Size(107, 20)
        Me.RegionDbName.TabIndex = 30
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(16, 22)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(53, 13)
        Me.Label20.TabIndex = 13
        Me.Label20.Text = "DB Name"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(17, 75)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(53, 13)
        Me.Label22.TabIndex = 17
        Me.Label22.Text = "Password"
        '
        'StandaloneGroup
        '
        Me.StandaloneGroup.Controls.Add(Me.Label22)
        Me.StandaloneGroup.Controls.Add(Me.Label20)
        Me.StandaloneGroup.Controls.Add(Me.RegionDbName)
        Me.StandaloneGroup.Controls.Add(Me.RegionDBUsername)
        Me.StandaloneGroup.Controls.Add(Me.Label21)
        Me.StandaloneGroup.Controls.Add(Me.RegionMySqlPassword)
        Me.StandaloneGroup.Location = New System.Drawing.Point(629, 162)
        Me.StandaloneGroup.Name = "StandaloneGroup"
        Me.StandaloneGroup.Size = New System.Drawing.Size(243, 123)
        Me.StandaloneGroup.TabIndex = 54
        Me.StandaloneGroup.TabStop = False
        Me.StandaloneGroup.Text = "Region Databases"
        '
        'uPnPEnabled
        '
        Me.uPnPEnabled.AutoSize = True
        Me.uPnPEnabled.Location = New System.Drawing.Point(22, 23)
        Me.uPnPEnabled.Name = "uPnPEnabled"
        Me.uPnPEnabled.Size = New System.Drawing.Size(96, 17)
        Me.uPnPEnabled.TabIndex = 40
        Me.uPnPEnabled.Text = "UPnP Enabled"
        Me.uPnPEnabled.UseVisualStyleBackColor = True
        '
        'Expert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(897, 405)
        Me.Controls.Add(Me.StandaloneGroup)
        Me.Controls.Add(Me.GridGroup)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Web)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Expert"
        Me.Text = "Expert"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DNSHelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.GodHelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Web.ResumeLayout(False)
        Me.Web.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GridGroup.ResumeLayout(False)
        Me.GridGroup.PerformLayout()
        Me.StandaloneGroup.ResumeLayout(False)
        Me.StandaloneGroup.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents DNSButton As Button
    Friend WithEvents DNSHelp As PictureBox
    Friend WithEvents HypericaButton As Button
    Friend WithEvents TestButton1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GridName As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GodHelp As PictureBox
    Friend WithEvents ManagerGod As CheckBox
    Friend WithEvents RegionGod As CheckBox
    Friend WithEvents AllowGod As CheckBox
    Friend WithEvents Web As GroupBox
    Friend WithEvents GmailPassword As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents GmailUsername As TextBox
    Friend WithEvents AdminEmail As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents AccountConfirmationRequired As CheckBox
    Friend WithEvents AdminLast As TextBox
    Friend WithEvents AdminFirst As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents AdminPassword As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents SplashPage As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents PrivatePort As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents DiagnosticPort As TextBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents StatsButton As Button
    Friend WithEvents WebStats As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PhysicsSeparate As RadioButton
    Friend WithEvents PhysicsNone As RadioButton
    Friend WithEvents PhysicsubODE As RadioButton
    Friend WithEvents PhysicsBullet As RadioButton
    Friend WithEvents PhysicsODE As RadioButton
    Friend WithEvents GridGroup As GroupBox
    Friend WithEvents Dbnameindex As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents RobustDbPort As TextBox
    Friend WithEvents RobustDbName As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents RobustDBPassword As TextBox
    Friend WithEvents RobustDBUsername As TextBox
    Friend WithEvents WifiEnabled As CheckBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents HTTPPort As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents RegionMySqlPassword As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents RegionDBUsername As TextBox
    Friend WithEvents RegionDbName As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents StandaloneGroup As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents UniqueId As TextBox
    Friend WithEvents uPnPEnabled As CheckBox
End Class
