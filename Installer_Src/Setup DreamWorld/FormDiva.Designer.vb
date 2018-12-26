<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDiva
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
        Me.Web = New System.Windows.Forms.GroupBox()
        Me.WiFi = New System.Windows.Forms.PictureBox()
        Me.WifiEnabled = New System.Windows.Forms.CheckBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.AdminEmail = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.AccountConfirmationRequired = New System.Windows.Forms.CheckBox()
        Me.AdminLast = New System.Windows.Forms.TextBox()
        Me.AdminFirst = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.AdminPassword = New System.Windows.Forms.TextBox()
        Me.ViewerSplash = New System.Windows.Forms.PictureBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.SmtpPort = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.SmtpHost = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.GmailPassword = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GmailUsername = New System.Windows.Forms.TextBox()
        Me.FriendlyName = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GridName = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.SplashPage = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Web.SuspendLayout()
        CType(Me.WiFi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ViewerSplash, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.FriendlyName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Web
        '
        Me.Web.Controls.Add(Me.WiFi)
        Me.Web.Controls.Add(Me.WifiEnabled)
        Me.Web.Controls.Add(Me.Label17)
        Me.Web.Controls.Add(Me.AdminEmail)
        Me.Web.Controls.Add(Me.Label12)
        Me.Web.Controls.Add(Me.AccountConfirmationRequired)
        Me.Web.Controls.Add(Me.AdminLast)
        Me.Web.Controls.Add(Me.AdminFirst)
        Me.Web.Controls.Add(Me.Label11)
        Me.Web.Controls.Add(Me.Label10)
        Me.Web.Controls.Add(Me.AdminPassword)
        Me.Web.Location = New System.Drawing.Point(12, 12)
        Me.Web.Name = "Web"
        Me.Web.Size = New System.Drawing.Size(200, 173)
        Me.Web.TabIndex = 48
        Me.Web.TabStop = False
        Me.Web.Text = "Wifi Interface Admin"
        '
        'WiFi
        '
        Me.WiFi.Image = Global.Outworldz.My.Resources.Resources.about
        Me.WiFi.Location = New System.Drawing.Point(148, 6)
        Me.WiFi.Name = "WiFi"
        Me.WiFi.Size = New System.Drawing.Size(30, 34)
        Me.WiFi.TabIndex = 1858
        Me.WiFi.TabStop = False
        '
        'WifiEnabled
        '
        Me.WifiEnabled.AutoSize = True
        Me.WifiEnabled.Location = New System.Drawing.Point(26, 19)
        Me.WifiEnabled.Name = "WifiEnabled"
        Me.WifiEnabled.Size = New System.Drawing.Size(65, 17)
        Me.WifiEnabled.TabIndex = 26
        Me.WifiEnabled.Text = "Enabled"
        Me.WifiEnabled.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(4, 119)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(62, 13)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "Notify Email"
        '
        'AdminEmail
        '
        Me.AdminEmail.Location = New System.Drawing.Point(86, 112)
        Me.AdminEmail.Name = "AdminEmail"
        Me.AdminEmail.Size = New System.Drawing.Size(100, 20)
        Me.AdminEmail.TabIndex = 30
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
        Me.AccountConfirmationRequired.Size = New System.Drawing.Size(175, 17)
        Me.AccountConfirmationRequired.TabIndex = 31
        Me.AccountConfirmationRequired.Text = "Confirmation required to Log in?"
        Me.AccountConfirmationRequired.UseVisualStyleBackColor = True
        '
        'AdminLast
        '
        Me.AdminLast.Location = New System.Drawing.Point(86, 66)
        Me.AdminLast.Name = "AdminLast"
        Me.AdminLast.Size = New System.Drawing.Size(100, 20)
        Me.AdminLast.TabIndex = 28
        '
        'AdminFirst
        '
        Me.AdminFirst.Location = New System.Drawing.Point(86, 44)
        Me.AdminFirst.Name = "AdminFirst"
        Me.AdminFirst.Size = New System.Drawing.Size(100, 20)
        Me.AdminFirst.TabIndex = 27
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
        Me.AdminPassword.TabIndex = 29
        Me.AdminPassword.UseSystemPasswordChar = True
        '
        'ViewerSplash
        '
        Me.ViewerSplash.Image = Global.Outworldz.My.Resources.Resources.about
        Me.ViewerSplash.Location = New System.Drawing.Point(246, 85)
        Me.ViewerSplash.Name = "ViewerSplash"
        Me.ViewerSplash.Size = New System.Drawing.Size(30, 34)
        Me.ViewerSplash.TabIndex = 1871
        Me.ViewerSplash.TabStop = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.SmtpPort)
        Me.GroupBox6.Controls.Add(Me.Label24)
        Me.GroupBox6.Controls.Add(Me.SmtpHost)
        Me.GroupBox6.Controls.Add(Me.Label23)
        Me.GroupBox6.Controls.Add(Me.GmailPassword)
        Me.GroupBox6.Controls.Add(Me.Label18)
        Me.GroupBox6.Controls.Add(Me.Label14)
        Me.GroupBox6.Controls.Add(Me.GmailUsername)
        Me.GroupBox6.Location = New System.Drawing.Point(529, 12)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(200, 132)
        Me.GroupBox6.TabIndex = 1862
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "SMTP Send Email Account"
        '
        'SmtpPort
        '
        Me.SmtpPort.Location = New System.Drawing.Point(96, 107)
        Me.SmtpPort.Name = "SmtpPort"
        Me.SmtpPort.Size = New System.Drawing.Size(33, 20)
        Me.SmtpPort.TabIndex = 36
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(10, 110)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(53, 13)
        Me.Label24.TabIndex = 1870
        Me.Label24.Text = "Smtp Port"
        '
        'SmtpHost
        '
        Me.SmtpHost.Location = New System.Drawing.Point(97, 81)
        Me.SmtpHost.Name = "SmtpHost"
        Me.SmtpHost.Size = New System.Drawing.Size(95, 20)
        Me.SmtpHost.TabIndex = 186735
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(9, 84)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(56, 13)
        Me.Label23.TabIndex = 1868
        Me.Label23.Text = "Smtp Host"
        '
        'GmailPassword
        '
        Me.GmailPassword.Location = New System.Drawing.Point(95, 55)
        Me.GmailPassword.Name = "GmailPassword"
        Me.GmailPassword.Size = New System.Drawing.Size(95, 20)
        Me.GmailPassword.TabIndex = 34
        Me.GmailPassword.UseSystemPasswordChar = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(7, 58)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(86, 13)
        Me.Label18.TabIndex = 1866
        Me.Label18.Text = "SMTP Password"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 37)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 13)
        Me.Label14.TabIndex = 1865
        Me.Label14.Text = "Username"
        '
        'GmailUsername
        '
        Me.GmailUsername.Location = New System.Drawing.Point(95, 30)
        Me.GmailUsername.Name = "GmailUsername"
        Me.GmailUsername.Size = New System.Drawing.Size(95, 20)
        Me.GmailUsername.TabIndex = 33
        '
        'FriendlyName
        '
        Me.FriendlyName.Image = Global.Outworldz.My.Resources.Resources.about
        Me.FriendlyName.Location = New System.Drawing.Point(246, 30)
        Me.FriendlyName.Name = "FriendlyName"
        Me.FriendlyName.Size = New System.Drawing.Size(30, 34)
        Me.FriendlyName.TabIndex = 1870
        Me.FriendlyName.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 13)
        Me.Label2.TabIndex = 1867
        Me.Label2.Text = "This Grid's Friendly Name"
        '
        'GridName
        '
        Me.GridName.Location = New System.Drawing.Point(21, 63)
        Me.GridName.Name = "GridName"
        Me.GridName.Size = New System.Drawing.Size(255, 20)
        Me.GridName.TabIndex = 1869
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(18, 106)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(139, 13)
        Me.Label19.TabIndex = 1868
        Me.Label19.Text = "Viewer Splash Screen URL:"
        '
        'SplashPage
        '
        Me.SplashPage.Location = New System.Drawing.Point(18, 124)
        Me.SplashPage.Name = "SplashPage"
        Me.SplashPage.Size = New System.Drawing.Size(258, 20)
        Me.SplashPage.TabIndex = 1866
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GridName)
        Me.GroupBox1.Controls.Add(Me.ViewerSplash)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.SplashPage)
        Me.GroupBox1.Controls.Add(Me.FriendlyName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(230, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(293, 173)
        Me.GroupBox1.TabIndex = 186736
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Splash Screen"
        '
        'FormDiva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 189)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Web)
        Me.Controls.Add(Me.GroupBox6)
        Me.Name = "FormDiva"
        Me.Text = "Diva Wifi Panel"
        Me.Web.ResumeLayout(False)
        Me.Web.PerformLayout()
        CType(Me.WiFi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ViewerSplash, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.FriendlyName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Web As GroupBox
    Friend WithEvents WiFi As PictureBox
    Friend WithEvents WifiEnabled As CheckBox
    Friend WithEvents Label17 As Label
    Friend WithEvents AdminEmail As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents AccountConfirmationRequired As CheckBox
    Friend WithEvents AdminLast As TextBox
    Friend WithEvents AdminFirst As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents AdminPassword As TextBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents SmtpPort As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents SmtpHost As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents GmailPassword As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents GmailUsername As TextBox
    Friend WithEvents ViewerSplash As PictureBox
    Friend WithEvents FriendlyName As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GridName As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents SplashPage As TextBox
    Friend WithEvents GroupBox1 As GroupBox
End Class
