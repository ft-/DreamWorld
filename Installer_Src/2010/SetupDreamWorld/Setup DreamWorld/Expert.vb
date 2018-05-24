Imports System.Diagnostics.Debug
Imports System.Net
Imports System.Security.Principal

Public Class Expert

    Dim initted As Boolean = False

#Region "Load/Exit"

    Private Sub Loaded(sender As Object, e As EventArgs) Handles Me.Load

        AutoStartCheckbox.Checked = Form1.MySetting.Autostart
        AutoLoadCheckbox.Checked = Form1.MySetting.AutoLoad
        BootStart.Checked = Form1.MySetting.BootStart

        'Clouds
        DomainUpDown1.SelectedIndex = (1 - Form1.MySetting.Density) * 10
        Clouds.Checked = Form1.MySetting.Clouds

        DNSName.Text = Form1.MySetting.DNSName
        EnableHypergrid.Checked = Form1.MySetting.EnableHypergrid

        GridName.Text = Form1.MySetting.SimName

        SplashPage.Text = Form1.MySetting.SplashPage

        'passwords are asterisks
        AdminPassword.UseSystemPasswordChar = True
        GmailPassword.UseSystemPasswordChar = True
        RobustDBPassword.UseSystemPasswordChar = True

        ' ports
        AdminPassword.Text = Form1.MySetting.Password
        AdminLast.Text = Form1.MySetting.AdminLast
        AdminFirst.Text = Form1.MySetting.AdminFirst

        'gods
        RegionGod.Checked = Form1.MySetting.region_owner_is_god
        ManagerGod.Checked = Form1.MySetting.region_manager_is_god

        'Wifi
        WifiEnabled.Checked = Form1.MySetting.WifiEnabled
        AdminEmail.Text = Form1.MySetting.AdminEmail
        AccountConfirmationRequired.Checked = Form1.MySetting.AccountConfirmationRequired
        GmailPassword.Text = Form1.MySetting.SmtpPassword
        GmailUsername.Text = Form1.MySetting.SmtpUsername
        SmtpPort.Text = Form1.MySetting.SmtpPort
        SmtpHost.Text = Form1.MySetting.SmtpHost

        ' Unique ID
        UniqueId.Text = Form1.MySetting.MachineID

        Select Case Form1.MySetting.Physics
            Case 0 : PhysicsNone.Checked = True
            Case 1 : PhysicsODE.Checked = True
            Case 2 : PhysicsBullet.Checked = True
            Case 3 : PhysicsSeparate.Checked = True
            Case 4 : PhysicsubODE.Checked = True
            Case Else : PhysicsSeparate.Checked = True
        End Select

        'ports
        DiagnosticPort.Text = Form1.MySetting.DiagnosticPort
        PrivatePort.Text = Form1.MySetting.PrivatePort
        HTTPPort.Text = Form1.MySetting.HttpPort
        DiagnosticPort.Text = Form1.MySetting.DiagnosticPort

        'Database 
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
        RegionDbName.Text = Form1.MySetting.RegionDBName
        RegionDBUsername.Text = Form1.MySetting.RegionDBUsername
        RegionMySqlPassword.Text = Form1.MySetting.RegionDbPassword

        ' Robust DB
        RobustServer.Text = Form1.MySetting.RobustServer
        RobustDbName.Text = Form1.MySetting.RobustMySqlName
        RobustDBPassword.Text = Form1.MySetting.RobustMySqlPassword
        RobustDBUsername.Text = Form1.MySetting.RobustMySqlUsername
        RobustDbPort.Text = Form1.MySetting.MySqlPort

        uPnPEnabled.Checked = Form1.MySetting.UPnPEnabled

        initted = True ' suppress the install of the startup on formload

    End Sub

#End Region

#Region "Ports"
    Private Sub Http_Port_TextChanged(sender As Object, e As EventArgs)
        Form1.MySetting.DiagnosticPort = DiagnosticPort.Text
        Form1.MySetting.SaveMyINI()
        Form1.CheckDefaultPorts()

    End Sub

    Private Sub PrivatePort_TextChanged(sender As Object, e As EventArgs) Handles PrivatePort.TextChanged
        Form1.MySetting.PrivatePort = PrivatePort.Text
        Form1.MySetting.SaveMyINI()
        Form1.CheckDefaultPorts()

    End Sub

    Private Sub PublicPort_TextChanged(sender As Object, e As EventArgs) Handles DiagnosticPort.TextChanged
        Form1.MySetting.DiagnosticPort = DiagnosticPort.Text
        Form1.MySetting.SaveMyINI()
        Form1.CheckDefaultPorts()

    End Sub

    Private Sub HTTP_Port_TextChanged_1(sender As Object, e As EventArgs) Handles HTTPPort.TextChanged
        Form1.MySetting.HttpPort = HTTPPort.Text
        Form1.MySetting.SaveMyINI()
        Form1.CheckDefaultPorts()
    End Sub


#End Region

#Region "Wifi"
    Private Sub AdminFirst_TextChanged_2(sender As Object, e As EventArgs) Handles AdminFirst.TextChanged
        Form1.MySetting.AdminFirst = AdminFirst.Text
        Form1.MySetting.SaveMyINI()
    End Sub

    Private Sub AdminLast_TextChanged(sender As Object, e As EventArgs) Handles AdminLast.TextChanged
        Form1.MySetting.AdminLast = AdminLast.Text
        Form1.MySetting.SaveMyINI()
    End Sub

    Private Sub Password_click(sender As Object, e As EventArgs) Handles AdminPassword.GotFocus
        AdminPassword.UseSystemPasswordChar = False
    End Sub

    Private Sub Password_TextChanged(sender As Object, e As EventArgs) Handles AdminPassword.LostFocus
        Form1.MySetting.Password = AdminPassword.Text
        Form1.MySetting.SaveMyINI()

        If Form1.Running Then
            Form1.ConsoleCommand(Form1.gRobustProcID, "reset user password Wifi Admin " + Form1.MySetting.Password + "{Enter}")
        End If
        'Me.Focus()
    End Sub

    Private Sub TextBox1_TextChanged_3(sender As Object, e As EventArgs) Handles AdminEmail.TextChanged
        Form1.MySetting.AdminEmail = AdminEmail.Text
        Form1.MySetting.SaveMyINI()
    End Sub

    Private Sub AccountConfirmationRequired_CheckedChanged(sender As Object, e As EventArgs) Handles AccountConfirmationRequired.CheckedChanged
        Form1.MySetting.AccountConfirmationRequired = AccountConfirmationRequired.Checked
        Form1.MySetting.SaveMyINI()
    End Sub

    Private Sub SmtpUsername_TextChanged(sender As Object, e As EventArgs)
        Form1.MySetting.SmtpUsername = GmailUsername.Text
        Form1.MySetting.SaveMyINI()
    End Sub

    Private Sub SmtpUsername_Click(sender As Object, e As EventArgs)
        GmailPassword.UseSystemPasswordChar = False
    End Sub

    Private Sub SmtpPassword_TextChanged(sender As Object, e As EventArgs)
        Form1.MySetting.SmtpPassword = GmailPassword.Text
        Form1.MySetting.SaveMyINI()
    End Sub

    Private Sub WifiEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles WifiEnabled.CheckedChanged
        Form1.MySetting.WifiEnabled = WifiEnabled.Checked
        Form1.MySetting.SaveMyINI()

        If WifiEnabled.Checked Then
            AdminFirst.Enabled = True
            AdminLast.Enabled = True
            AdminPassword.Enabled = True
            AdminEmail.Enabled = True
            AccountConfirmationRequired.Enabled = True
            GmailUsername.Enabled = True
            GmailPassword.Enabled = True
        Else

            AdminFirst.Enabled = False
            AdminLast.Enabled = False
            AdminPassword.Enabled = False
            AdminEmail.Enabled = False
            AccountConfirmationRequired.Enabled = False
            GmailUsername.Enabled = False
            GmailPassword.Enabled = False
        End If

    End Sub

#End Region

#Region "Gods"
    Private Sub CheckBox1_CheckedChanged_2(sender As Object, e As EventArgs) Handles AllowGods.CheckedChanged
        Form1.MySetting.Allow_grid_gods = AllowGods.Checked
        Form1.MySetting.SaveMyINI()
    End Sub

    Private Sub RegionGod_CheckedChanged(sender As Object, e As EventArgs) Handles RegionGod.CheckedChanged
        Form1.MySetting.Region_owner_is_god = RegionGod.Checked
        If RegionGod.Checked Then AllowGods.Checked = True
        Form1.MySetting.SaveMyINI()
    End Sub

    Private Sub ManagerGod_CheckedChanged(sender As Object, e As EventArgs) Handles ManagerGod.CheckedChanged
        Form1.MySetting.Region_manager_is_god = ManagerGod.Checked
        If ManagerGod.Checked Then AllowGods.Checked = True
        Form1.MySetting.SaveMyINI()
    End Sub



#End Region

#Region "Misc"
    Private Sub GridName_TextChanged(sender As Object, e As EventArgs) Handles GridName.TextChanged

        Form1.MySetting.SimName = GridName.Text
        Form1.MySetting.SaveMyINI()

    End Sub

    Private Sub UPnPEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles uPnPEnabled.CheckedChanged

        Form1.MySetting.UPnPEnabled = uPnPEnabled.Checked
        Form1.MySetting.SaveMyINI()

    End Sub


    Private Sub UniqueId_TextChanged(sender As Object, e As EventArgs) Handles UniqueId.TextChanged

        Form1.MySetting.MachineID = UniqueId.Text
        Form1.MySetting.SaveMyINI()

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles Clouds.CheckedChanged

        Form1.MySetting.Clouds = Clouds.Checked
        Form1.MySetting.SaveMyINI()

    End Sub
#End Region

#Region "Splash"

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles SplashPage.TextChanged
        Form1.MySetting.SplashPage = SplashPage.Text
        Form1.MySetting.SaveMyINI()
    End Sub
#End Region

#Region "Physics"

    Private Sub PhysicsNone_CheckedChanged(sender As Object, e As EventArgs) Handles PhysicsNone.CheckedChanged
        If PhysicsNone.Checked Then
            Form1.MySetting.Physics = 0
            Form1.MySetting.SaveMyINI()
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles PhysicsODE.CheckedChanged
        If PhysicsODE.Checked Then
            Form1.MySetting.Physics = 1
            Form1.MySetting.SaveMyINI()
        End If
    End Sub

    Private Sub PhysicsBullet_CheckedChanged(sender As Object, e As EventArgs) Handles PhysicsBullet.CheckedChanged
        If PhysicsBullet.Checked Then
            Form1.MySetting.Physics = 2
            Form1.MySetting.SaveMyINI()
        End If
    End Sub

    Private Sub PhysicsSeparate_CheckedChanged(sender As Object, e As EventArgs) Handles PhysicsSeparate.CheckedChanged
        If PhysicsSeparate.Checked Then
            Form1.MySetting.Physics = 3
            Form1.MySetting.SaveMyINI()
        End If
    End Sub

    Private Sub PhysicsubODE_CheckedChanged(sender As Object, e As EventArgs) Handles PhysicsubODE.CheckedChanged
        If PhysicsubODE.Checked Then
            Form1.MySetting.Physics = 4
            Form1.MySetting.SaveMyINI()
        End If
    End Sub

#End Region

#Region "DNS"

    Private Sub EnableHypergrid_CheckedChanged(sender As Object, e As EventArgs) Handles EnableHypergrid.CheckedChanged

        Form1.MySetting.EnableHypergrid = EnableHypergrid.Checked
        Form1.MySetting.SaveMyINI()

    End Sub

    Private Sub DNSButton_Click(sender As Object, e As EventArgs) Handles DNSButton.Click

        Dim F As New DNSName
        F.Show()

    End Sub

    Private Sub TestButton1_Click_1(sender As Object, e As EventArgs) Handles TestButton1.Click

        Dim IP = Form1.DoGetHostAddresses(Form1.MySetting.DNSName)
        Dim address As IPAddress = Nothing
        If IPAddress.TryParse(IP, address) Then
            MsgBox(Form1.MySetting.DNSName + " was resolved to " + IP, vbInformation, "Test Result")
        Else
            MsgBox("Cannot resolve " + Form1.MySetting.DNSName, vbInformation, "Error")
        End If

    End Sub

    Private Sub HypericaButton_Click(sender As Object, e As EventArgs) Handles HypericaButton.Click

        Dim webAddress As String = "http://www.hyperica.com/directory/?GridName=" + Form1.MySetting.DNSName
        Process.Start(webAddress)

    End Sub

#End Region

#Region "Database"


    Private Sub RobustServer_TextChanged(sender As Object, e As EventArgs) Handles RobustServer.TextChanged
        Form1.MySetting.RobustServer = RobustServer.Text
        Form1.MySetting.SaveMyINI()
    End Sub

    Private Sub DatabaseNameUser_TextChanged(sender As Object, e As EventArgs) Handles RegionDbName.TextChanged
        Form1.MySetting.RegionDBName = RegionDbName.Text
        Form1.MySetting.SaveMyINI()
    End Sub

    Private Sub DbUsername_TextChanged(sender As Object, e As EventArgs) Handles RegionDBUsername.TextChanged
        Form1.MySetting.RegionDBUsername = RegionDBUsername.Text
        Form1.MySetting.SaveMyINI()
    End Sub

    Private Sub DbPassword_click(sender As Object, e As EventArgs) Handles RegionMySqlPassword.Click
        RegionMySqlPassword.UseSystemPasswordChar = False
    End Sub

    Private Sub DbPassword_TextChanged(sender As Object, e As EventArgs) Handles RegionMySqlPassword.TextChanged
        Form1.MySetting.RegionDbPassword = RegionMySqlPassword.Text
        Form1.MySetting.SaveMyINI()
    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles RobustDbName.TextChanged
        Form1.MySetting.RobustMySqlName = RobustDbName.Text
        Form1.MySetting.SaveMyINI()
    End Sub

    Private Sub RobustUsernameTextBox_TextChanged(sender As Object, e As EventArgs) Handles RobustDBUsername.TextChanged
        Form1.MySetting.RobustMySqlUsername = RobustDBUsername.Text
        Form1.MySetting.SaveMyINI()
    End Sub

    Private Sub RobustPasswordTextBox_TextChanged(sender As Object, e As EventArgs) Handles RobustDBPassword.TextChanged
        Form1.MySetting.RobustMySqlPassword = RobustDBPassword.Text
        Form1.MySetting.SaveMyINI()
    End Sub

    Private Sub RobustPasswordClicked(sender As Object, e As EventArgs) Handles RobustDBPassword.Click
        RobustDBPassword.UseSystemPasswordChar = False
    End Sub

    Private Sub RobustDbPortTextbox_TextChanged(sender As Object, e As EventArgs) Handles RobustDbPort.TextChanged
        Form1.MySetting.MySqlPort = RobustDbPort.Text
        Form1.MySetting.SaveMyINI()
    End Sub



#End Region

#Region "Help"

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles GodHelp.Click
        Dim webAddress As String = Form1.Domain + "/Outworldz_installer/technical.htm#GridGod"
        Process.Start(webAddress)
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles DNSHelp.Click
        Dim webAddress As String = Form1.Domain + "/Outworldz_installer/technical.htm#Grid"
        Process.Start(webAddress)
    End Sub


#End Region

#Region "AutoStart"

    Private Sub AutoStartCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles AutoStartCheckbox.CheckedChanged

        Form1.MySetting.Autostart = AutoStartCheckbox.Checked
        Form1.MySetting.SaveMyINI()

    End Sub

    Private Sub BootStart_CheckedChanged(sender As Object, e As EventArgs) Handles BootStart.CheckedChanged

        If Not initted Then Return


        Form1.MySetting.BootStart = BootStart.Checked
        Dim ProcessTask As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.WindowStyle = ProcessWindowStyle.Normal
        pi.FileName = "schtasks.exe"
        If IsUserAdministrator() Then
            If BootStart.Checked Then
                pi.Arguments = "/Create /TN DreamGrid /SC ONSTART /TR " & Form1.MyFolder & "\Start.exe"

                ProcessTask.StartInfo = pi
                Try
                    ProcessTask.Start()
                    AutoStartCheckbox.Checked = True
                    Form1.MySetting.Autostart = True
                    Form1.MySetting.SaveMyINI()
                Catch ex As Exception
                    Form1.Log("Error:ProcessTask failed to launch:" + ex.Message)
                End Try
            Else
                pi.Arguments = "/Delete /TN DreamGrid"
                ProcessTask.StartInfo = pi
                Try
                    ProcessTask.Start()
                Catch ex As Exception
                    Form1.Log("Error:ProcessTask Delete failed to launch:" + ex.Message)
                End Try

            End If

        Else
            MsgBox("DreamGrid must be started in Administrator mode to setup a scheduled task. Right click the icon and select Run As Administrator.", vbInformation, "Escalation Needed")
        End If
    End Sub

    Private Function IsUserAdministrator() As Boolean

        Dim isAdmin As Boolean
        Try

            Dim user As WindowsIdentity = WindowsIdentity.GetCurrent()
            Dim principal As WindowsPrincipal = New WindowsPrincipal(user)
            isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator)

        Catch ex As Exception

            isAdmin = False

        End Try
        Return isAdmin

    End Function

    Private Sub CheckBox1_CheckedChanged_1(sender As Object, e As EventArgs) Handles AutoLoadCheckbox.CheckedChanged

        Form1.MySetting.AutoLoad = AutoLoadCheckbox.Checked
        Form1.MySetting.SaveMyINI()

    End Sub

    Private Sub DomainUpDown1_SelectedItemChanged(sender As Object, e As EventArgs) Handles DomainUpDown1.SelectedItemChanged

        If initted Then
            Dim var = DomainUpDown1.SelectedIndex.ToString()
            If var = -1 Then var = 0.5
            var = (10 - var) / 10
            Debug.Print(var)

            Form1.MySetting.Density = var
            Form1.MySetting.SaveMyINI()
        End If

    End Sub

    Private Sub SmtpHost_TextChanged(sender As Object, e As EventArgs)
        Form1.MySetting.SmtpHost = SmtpHost.Text
        Form1.MySetting.SaveMyINI()
    End Sub

    Private Sub SmtpPort_TextChanged(sender As Object, e As EventArgs)
        Form1.MySetting.SmtpPort = SmtpPort.Text
        Form1.MySetting.SaveMyINI()
    End Sub


#End Region


End Class