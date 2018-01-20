Imports System.Net

Public Class AdvancedForm

#Region "Declarations"

#End Region

#Region "Functions"

    Friend WithEvents Label1 As Label
    Dim Sleepy As Integer = 1500
    Dim Awake As Integer = 1000
    Dim Coffee As Integer = 500
    Dim Toomuch As Integer = 0


    Private Class Region_data
        Public RegionName As String
        Public UUID As String
        Public CoordX As Integer
        Public CoordY As String
        Public RegionPort As Integer
        Public SizeX As Integer
        Public SizeY As Integer
    End Class

    Private Sub Loaded(sender As Object, e As EventArgs) Handles Me.Load

        uPnPEnabled.Checked = My.Settings.UPnPEnabled
        PublicPort.Text = My.Settings.PublicPort
        PrivatePort.Text = My.Settings.PrivatePort
        httpPort.Text = My.Settings.HttpPort

        If Form1.isRunning Then
            StatsButton.Enabled = True
        Else
            StatsButton.Enabled = False
        End If

        'Form1.RegisterDNS()  ' 1.66 why?

        Password.UseSystemPasswordChar = True
        DbPassword.UseSystemPasswordChar = True
        SmtpPassword.UseSystemPasswordChar = True

        AutoBackupKeepFilesForDays.Text = My.Settings.KeepForDays
        If My.Settings.AutobackupInterval = 60 Then
            AutoBackupInterval.SelectedIndex = 0
        ElseIf My.Settings.AutobackupInterval = 12 * 60 Then
            AutoBackupInterval.SelectedIndex = 1
        ElseIf My.Settings.AutobackupInterval = 24 * 60 Then
            AutoBackupInterval.SelectedIndex = 2
        Else
            AutoBackupInterval.SelectedIndex = 3
        End If

        BackupFolder.Text = My.Settings.BackupFolder

        Dim Chattime = My.Settings.ChatTime

        If Chattime = Sleepy Then
            ChatSpeed.SelectedIndex = 0
        ElseIf Chattime = Awake Then
            ChatSpeed.SelectedIndex = 1
        ElseIf Chattime = Coffee Then
            ChatSpeed.SelectedIndex = 2
        Else
            ChatSpeed.SelectedIndex = 3
        End If

        DbPort.Text = My.Settings.MySqlPort
        AutoBackup.Checked = My.Settings.AutoBackup
        Password.Text = My.Settings.Password
        AdminLast.Text = My.Settings.AdminLast
        AdminFirst.Text = My.Settings.AdminFirst

        RegionGod.Checked = My.Settings.region_owner_is_god
        ManagerGod.Checked = My.Settings.region_manager_is_god

        TimerInterval.Text = Str(My.Settings.TimerInterval)
        AdminEmail.Text = My.Settings.AdminEmail

        AccountConfirmationRequired.Checked = My.Settings.AccountConfirmationRequired

        SmtpPassword.Text = My.Settings.SmtpPassword
        SmtpUsername.Text = My.Settings.SmtpUsername

        DnsName.Text = My.Settings.DnsName
        WebStats.Checked = My.Settings.WebStats

        DbConnection.Text = My.Settings.DBSource
        DbName.Text = My.Settings.DBName
        DbUsername.Text = My.Settings.DBUserID
        DbPassword.Text = My.Settings.DBPassword
        SplashPage.Text = My.Settings.SplashPage

        ' physics engines differ between 0.8.2.1 and 0.9.1
        If My.Settings.GridFolder = "Opensim" And PhysicsubODE.Checked Then
            My.Settings.Physics = 3 ' They just switched engines, set a default of Bullet, separate thread for 0.8.1
            My.Settings.Save()
            PhysicsSeparate.Checked = True
        End If

        If My.Settings.GridFolder = "Opensim" Then
            PhysicsubODE.Enabled = False
        Else
            PhysicsubODE.Enabled = True
        End If

        Select Case My.Settings.Physics
            Case 0 : PhysicsNone.Checked = True
            Case 1 : PhysicsODE.Checked = True
            Case 2 : PhysicsBullet.Checked = True
            Case 3 : PhysicsSeparate.Checked = True
            Case 4 : PhysicsubODE.Checked = True
            Case Else : PhysicsSeparate.Checked = True
        End Select

        ' Grid
        If My.Settings.GridFolder = "Opensim" Then
            OpensimOld.Checked = True
            Form1.Log("Info:0.8.2.1 enabled")
        Else
            OpensImNew.Checked = True
            Form1.Log("Info:0.9.1 enabled")
        End If

        GridName.Text = My.Settings.SimName

        If My.Settings.MapType = "None" Then
            MapNone.Checked = True
            MapPicture.Image = Nothing
        ElseIf My.Settings.MapType = "Simple" Then
            MapSimple.Checked = True
            MapPicture.Image = My.Resources.Simple
        ElseIf My.Settings.MapType = "Good" Then
            MapGood.Checked = True
            MapPicture.Image = My.Resources.Good
        ElseIf My.Settings.MapType = "Better" Then
            MapBetter.Checked = True
            MapPicture.Image = My.Resources.Better
        ElseIf My.Settings.MapType = "Best" Then
            MapBest.Checked = True
            MapPicture.Image = My.Resources.Best
        End If

        LoadWelcomeBox()
    End Sub

    Private Sub Form1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        If Form1.Running Then
            Form1.ConsoleCommand("reset user password Wifi Admin " + My.Settings.Password + "{Enter}")
        End If

    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles DbPort.TextChanged
        My.Settings.MySqlPort = DbPort.Text
        My.Settings.Save()
    End Sub

    Private Sub ABEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles AutoBackup.CheckedChanged
        My.Settings.AutoBackup = AutoBackup.Checked
        My.Settings.Save()
    End Sub

    Private Sub AutoBackupInterval_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AutoBackupInterval.SelectedIndexChanged
        Dim text = AutoBackupInterval.SelectedItem.ToString()
        Dim Interval As Integer
        If text = "Hourly" Then Interval = 60
        If text = "12 Hour" Then Interval = 60 * 12
        If text = "Daily" Then Interval = 60 * 24
        If text = "Weekly" Then Interval = 60 * 24 * 7
        My.Settings.AutobackupInterval = Interval
        My.Settings.Save()

    End Sub

    Private Sub AutoBackupKeepFilesForDays_TextChanged(sender As Object, e As EventArgs) Handles AutoBackupKeepFilesForDays.TextChanged
        If Convert.ToInt32(AutoBackupKeepFilesForDays.Text) > 0 Then
            My.Settings.KeepForDays = Convert.ToInt32(AutoBackupKeepFilesForDays.Text)
            My.Settings.Save()
        End If

    End Sub

    Private Sub TextBox1_TextChanged_2(sender As Object, e As EventArgs) Handles AdminFirst.TextChanged
        My.Settings.AdminFirst = AdminFirst.Text
        My.Settings.Save()

    End Sub

    Private Sub AdminLast_TextChanged(sender As Object, e As EventArgs) Handles AdminLast.TextChanged
        My.Settings.AdminLast = AdminLast.Text
        My.Settings.Save()

    End Sub

    Private Sub Password_click(sender As Object, e As EventArgs) Handles Password.Click
        Password.UseSystemPasswordChar = False

    End Sub
    Private Sub Password_TextChanged(sender As Object, e As EventArgs) Handles Password.TextChanged
        My.Settings.Password = Password.Text
        My.Settings.Save()

        If Form1.Running Then
            Form1.ConsoleCommand("reset user password Wifi Admin " + My.Settings.Password + "{Enter}")
        End If

    End Sub

    Private Sub ChatSpeed_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ChatSpeed.SelectedIndexChanged

        Dim text = ChatSpeed.SelectedItem.ToString()
        Dim ChatTime As Integer = 1500

        If text = "Sleepy" Then ChatTime = 1500
        If text = "Awake" Then ChatTime = 1000
        If text = "After Coffee" Then ChatTime = 500
        If text = "Too much Coffee" Then ChatTime = 0

        My.Settings.ChatTime = ChatTime
        My.Settings.Save()
        Form1.gChatTime = ChatTime
    End Sub



    Private Sub RegionGod_CheckedChanged(sender As Object, e As EventArgs) Handles RegionGod.CheckedChanged
        My.Settings.region_owner_is_god = RegionGod.Checked
        My.Settings.Save()

    End Sub

    Private Sub ManagerGod_CheckedChanged(sender As Object, e As EventArgs) Handles ManagerGod.CheckedChanged
        My.Settings.region_manager_is_god = ManagerGod.Checked
        My.Settings.Save()

    End Sub


    Private Sub TimerInterval_TextChanged(sender As Object, e As EventArgs) Handles TimerInterval.TextChanged
        If Len(TimerInterval.Text) > 0 Then
            My.Settings.TimerInterval = CInt(TimerInterval.Text)
            If (My.Settings.TimerInterval > 0) Then
                Form1.PaintImage()
            Else
                Form1.PictureBox1.Visible = False
            End If
        Else
            Form1.PictureBox1.Visible = False
            My.Settings.TimerInterval = 0
            My.Settings.Save()
        End If
    End Sub

    Private Sub TextBox1_TextChanged_3(sender As Object, e As EventArgs) Handles AdminEmail.TextChanged
        My.Settings.AdminEmail = AdminEmail.Text
        My.Settings.Save()

    End Sub

    Private Sub AccountConfirmationRequired_CheckedChanged(sender As Object, e As EventArgs) Handles AccountConfirmationRequired.CheckedChanged
        My.Settings.AccountConfirmationRequired = AccountConfirmationRequired.Checked
        My.Settings.Save()

    End Sub

    Private Sub SmtpUsername_TextChanged(sender As Object, e As EventArgs) Handles SmtpUsername.TextChanged

        My.Settings.SmtpUsername = SmtpUsername.Text
        My.Settings.Save()

    End Sub
    Private Sub SmtpUsername_Click(sender As Object, e As EventArgs) Handles SmtpPassword.Click

        SmtpPassword.UseSystemPasswordChar = False
        My.Settings.Save()

    End Sub
    Private Sub SmtpPassword_TextChanged(sender As Object, e As EventArgs) Handles SmtpPassword.TextChanged

        My.Settings.SmtpPassword = SmtpPassword.Text
        My.Settings.Save()

    End Sub

    Private Sub DnsName_TextChanged(sender As Object, e As EventArgs) Handles DnsName.TextChanged
        My.Settings.DnsName = DnsName.Text
        My.Settings.Save()

    End Sub

    Private Sub DnsName_TextClicked(sender As Object, e As EventArgs) Handles DnsName.Click
        Dim F As New DNSName
        F.Show()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles WebStats.CheckedChanged
        My.Settings.WebStats = WebStats.Checked
        My.Settings.Save()
        Form1.WebStatsToolStripMenuItem.Visible = WebStats.Checked

    End Sub

    Private Sub DatabaseNameUser_TextChanged(sender As Object, e As EventArgs) Handles DbName.TextChanged
        My.Settings.DBName = DbName.Text
        My.Settings.Save()

    End Sub

    Private Sub DbConnection_TextChanged(sender As Object, e As EventArgs) Handles DbConnection.TextChanged

        My.Settings.DBSource = DbConnection.Text
        My.Settings.Save()

    End Sub

    Private Sub DbUsername_TextChanged(sender As Object, e As EventArgs) Handles DbUsername.TextChanged
        My.Settings.DBUserID = DbUsername.Text
        My.Settings.Save()

    End Sub
    Private Sub DbPassword_click(sender As Object, e As EventArgs) Handles DbPassword.Click
        DbPassword.UseSystemPasswordChar = False

    End Sub

    Private Sub DbPassword_TextChanged(sender As Object, e As EventArgs) Handles DbPassword.TextChanged
        My.Settings.DBPassword = DbPassword.Text
        My.Settings.Save()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles SplashPage.TextChanged
        My.Settings.SplashPage = SplashPage.Text
        My.Settings.Save()

    End Sub

    Private Sub PrivatePort_TextChanged(sender As Object, e As EventArgs) Handles PrivatePort.TextChanged
        My.Settings.PrivatePort = PrivatePort.Text
        My.Settings.Save()
    End Sub

    Private Sub PublicPort_TextChanged(sender As Object, e As EventArgs) Handles PublicPort.TextChanged
        My.Settings.PublicPort = PublicPort.Text
        My.Settings.Save()
    End Sub

    Private Sub RegionButton1_Click(sender As Object, e As EventArgs) Handles RegionButton.Click

        Form1.GetAllRegions()
        Dim X As Integer = 300
        Dim Y As Integer = 200
        Dim fname As String

        Dim counter As Integer = 1
        Dim l = Form1.aRegion.Length ' 5 for 4 items as we skip 0
        While counter <= l - 1      ' so we subtract 1
            Try
                fname = Form1.aRegion(counter).RegionName

                Dim ActualForm As New FormRegion
                ActualForm.SetDesktopLocation(X, Y)
                ActualForm.Init(counter)
                ActualForm.Activate()
                ActualForm.Visible = True
                Application.DoEvents()
            Catch ex As Exception
                Form1.Log("Info:" + ex.Message)
            End Try

            counter = counter + 1
            Y += 100
            X += 100
        End While
    End Sub

    Private Sub AddRegion_Click(sender As Object, e As EventArgs) Handles AddRegion.Click

        Dim X As Integer = 300
        Dim Y As Integer = 200

        Array.Resize(Form1.aRegion, Form1.aRegion.Length + 1)
        Dim index = Form1.aRegion.Length - 1
        Form1.aRegion(index) = New Region_data
        Form1.aRegion(index).RegionPort = 0
        Form1.aRegion(index).CoordX = 0
        Form1.aRegion(index).CoordY = 0
        Form1.aRegion(index).SizeX = 256
        Form1.aRegion(index).SizeY = 256
        Form1.aRegion(index).UUID = ""
        Form1.aRegion(index).RegionName = ""

        Try
            Dim ActualForm As New FormRegion
            ActualForm.SetDesktopLocation(X, Y)
            ActualForm.Init(index)
            ActualForm.Activate()
            ActualForm.Visible = True

        Catch ex As Exception
            Form1.Log("Info:" + ex.Message)
        End Try
    End Sub

    Private Sub PhysicsNone_CheckedChanged(sender As Object, e As EventArgs) Handles PhysicsNone.CheckedChanged
        If PhysicsNone.Checked Then
            My.Settings.Physics = 0
            My.Settings.Save()

        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles PhysicsODE.CheckedChanged
        If PhysicsODE.Checked Then
            My.Settings.Physics = 1
            My.Settings.Save()

        End If
    End Sub

    Private Sub PhysicsBullet_CheckedChanged(sender As Object, e As EventArgs) Handles PhysicsBullet.CheckedChanged
        If PhysicsBullet.Checked Then
            My.Settings.Physics = 2
            My.Settings.Save()

        End If
    End Sub

    Private Sub PhysicsSeparate_CheckedChanged(sender As Object, e As EventArgs) Handles PhysicsSeparate.CheckedChanged
        If PhysicsSeparate.Checked Then
            My.Settings.Physics = 3
            My.Settings.Save()

        End If
    End Sub

    Private Sub PhysicsubODE_CheckedChanged(sender As Object, e As EventArgs) Handles PhysicsubODE.CheckedChanged
        If PhysicsubODE.Checked Then
            My.Settings.Physics = 4
            My.Settings.Save()

        End If
    End Sub

    Private Sub OpensImNew_CheckedChanged(sender As Object, e As EventArgs) Handles OpensImNew.CheckedChanged
        My.Settings.GridFolder = "Opensim-0.9"
        My.Settings.Save()

        Try
            My.Computer.FileSystem.RenameFile(Form1.MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\Regions\RegionConfig.ini", "Outworldz.ini")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub OpensimOld_CheckedChanged(sender As Object, e As EventArgs) Handles OpensimOld.CheckedChanged
        My.Settings.GridFolder = "Opensim"
        My.Settings.Save()

        Try
            My.Computer.FileSystem.RenameFile(Form1.MyFolder & "\OutworldzFiles\" & My.Settings.GridFolder & "\bin\Regions\RegionConfig.ini", "Outworldz.ini")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GridName_TextChanged(sender As Object, e As EventArgs) Handles GridName.TextChanged
        My.Settings.SimName = GridName.Text
        My.Settings.Save()

    End Sub

    Private Sub DnsName_TextChanged_1(sender As Object, e As EventArgs) Handles DnsName.TextChanged
        My.Settings.PublicIP = DnsName.Text
        My.Settings.Save()
    End Sub

    Private Sub StatsButton_Click(sender As Object, e As EventArgs) Handles StatsButton.Click
        If Form1.isRunning And WebStats.Checked Then
            Dim webAddress As String = "http://127.0.0.1:" + My.Settings.HttpPort + "/SStats/"
            Process.Start(webAddress)
        Else
            Print("Opensim is not running. Cannot open the Statistics web page.")
        End If
    End Sub

    Private Sub VoiceButton1_Click(sender As Object, e As EventArgs) Handles VoiceButton1.Click
        Dim Voice As New Form2
        ' Set the new form's desktop location so it appears below and
        ' to the right of the current form.
        Voice.SetDesktopLocation(300, 200)
        Voice.Activate()
        Voice.Visible = True
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub http_Port_TextChanged(sender As Object, e As EventArgs) Handles httpPort.TextChanged
        My.Settings.HttpPort = httpPort.Text
        My.Settings.Save()
    End Sub

    Private Sub MapNone_CheckedChanged(sender As Object, e As EventArgs) Handles MapNone.CheckedChanged
        My.Settings.MapType = "None"
        My.Settings.Save()
        MapPicture.Image = Nothing

    End Sub

    Private Sub MapSimple_CheckedChanged(sender As Object, e As EventArgs) Handles MapSimple.CheckedChanged
        My.Settings.MapType = "Simple"
        My.Settings.Save()
        MapPicture.Image = My.Resources.Simple

    End Sub

    Private Sub MapGood_CheckedChanged(sender As Object, e As EventArgs) Handles MapGood.CheckedChanged
        My.Settings.MapType = "Good"
        My.Settings.Save()
        MapPicture.Image = My.Resources.Good

    End Sub

    Private Sub MapBetter_CheckedChanged(sender As Object, e As EventArgs) Handles MapBetter.CheckedChanged
        My.Settings.MapType = "Better"
        My.Settings.Save()
        MapPicture.Image = My.Resources.Better

    End Sub

    Private Sub MapBest_CheckedChanged(sender As Object, e As EventArgs) Handles MapBest.CheckedChanged
        My.Settings.MapType = "Best"
        My.Settings.Save()
        MapPicture.Image = My.Resources.Best

    End Sub

    Private Sub BackupFolder_clicked(sender As Object, e As EventArgs) Handles BackupFolder.Click
        'Create an instance of the open file dialog box.
        Dim openFileDialog1 As FolderBrowserDialog = New FolderBrowserDialog

        openFileDialog1.ShowNewFolderButton = True
        openFileDialog1.Description = "Pick folder for backups"
        Dim UserClickedOK As Boolean = openFileDialog1.ShowDialog

        ' Process input if the user clicked OK.
        If UserClickedOK = True Then
            Dim thing = openFileDialog1.SelectedPath
            If thing.Length Then
                My.Settings.BackupFolder = thing
                My.Settings.Save()
                BackupFolder.Text = thing
            End If
        End If
    End Sub

    Private Sub ComboBox1_Click(sender As Object, e As EventArgs) Handles WelcomeBox1.Click
        LoadWelcomeBox()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles WelcomeBox1.SelectedIndexChanged
        My.Settings.WelcomeRegion = WelcomeBox1.SelectedIndex
        My.Settings.Save()

    End Sub

    Private Sub LoadWelcomeBox()
        ' Default welcome region load
        WelcomeBox1.Items.Clear()
        Dim counter As Integer = 1
        Dim L = Form1.aRegion.GetUpperBound(0)
        While counter <= L
            WelcomeBox1.Items.Add(Form1.aRegion(counter).RegionName)
            counter += 1
        End While

        Try
            WelcomeBox1.SelectedIndex = My.Settings.WelcomeRegion
        Catch ex As Exception
            WelcomeBox1.SelectedIndex = -1
        End Try

    End Sub



#End Region

#Region "Help"
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim webAddress As String = Form1.Domain + "/Outworldz_installer/technical.htm#GridGod"
        Process.Start(webAddress)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim webAddress As String = Form1.Domain + "/Outworldz_installer/technical.htm#Backup"
        Process.Start(webAddress)
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim webAddress As String = Form1.Domain + "/Outworldz_installer/technical.htm#Maps"
        Process.Start(webAddress)
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dim webAddress As String = Form1.Domain + "/Outworldz_installer/technical.htm#Personality"
        Process.Start(webAddress)
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles GridNameHelp.Click
        Dim webAddress As String = Form1.Domain + "/Outworldz_installer/technical.htm#Grid"
        Process.Start(webAddress)
    End Sub

    Private Sub TestButton1_Click(sender As Object, e As EventArgs) Handles TestButton1.Click

        Dim IP = Form1.DoGetHostAddresses(My.Settings.DnsName)
        Dim address As IPAddress = Nothing
        If IPAddress.TryParse(IP, address) Then
            MsgBox("DNS name " + My.Settings.DnsName + " was resolved to " + IP)
        Else
            MsgBox("Cannot resolve " + My.Settings.DnsName + ". Check for illegal characters")
        End If
    End Sub

    Private Sub HypericaButton_Click(sender As Object, e As EventArgs) Handles HypericaButton.Click
        Dim webAddress As String = "http://www.hyperica.com/directory/"
        Process.Start(webAddress)
    End Sub

    Private Sub GloebitsButton_Click(sender As Object, e As EventArgs) Handles GloebitsButton.Click

        Dim Gloebits As New Gloebits
        ' Set the new form's desktop location so it appears below and
        ' to the right of the current form.
        Gloebits.SetDesktopLocation(300, 200)
        Gloebits.Activate()
        Gloebits.Visible = True

    End Sub

    Private Sub uPnPEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles uPnPEnabled.CheckedChanged

        My.Settings.UPnPEnabled = uPnPEnabled.Checked
        My.Settings.Save()

    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PhysicsHelp.Click

        Dim webAddress As String = Form1.Domain + "/Outworldz_installer/technical.htm#Physics"
        Process.Start(webAddress)

    End Sub

    Private Sub VoiceHelp_Click(sender As Object, e As EventArgs) Handles VoiceHelp.Click

        Dim webAddress As String = Form1.Domain + "/Outworldz_installer/technical.htm#Voice"
        Process.Start(webAddress)

    End Sub

    Private Sub Gloebits_Click(sender As Object, e As EventArgs) Handles Gloebits.Click

        Dim webAddress As String = Form1.Domain + "/Outworldz_installer/technical.htm#Gloebits"
        Process.Start(webAddress)

    End Sub

    Private Sub Webstat_Click(sender As Object, e As EventArgs) Handles Webstat.Click

        Dim webAddress As String = Form1.Domain + "/Outworldz_installer/technical.htm#WebStats"
        Process.Start(webAddress)

    End Sub

    Private Sub PictureBox7_Click_1(sender As Object, e As EventArgs) Handles PictureBox7.Click

        Dim webAddress As String = Form1.Domain + "/Outworldz_installer/technical.htm#RegionDatabase"
        Process.Start(webAddress)


    End Sub

    Private Sub RegionHelp_Click(sender As Object, e As EventArgs) Handles RegionHelp.Click

        Dim webAddress As String = Form1.Domain + "/Outworldz_installer/technical.htm#Regions"
        Process.Start(webAddress)

    End Sub

    Private Sub PortHelp_Click(sender As Object, e As EventArgs) Handles PortHelp.Click

        Dim webAddress As String = Form1.Domain + "/Outworldz_installer/technical.htm#Ports"
        Process.Start(webAddress)

    End Sub


#End Region


End Class
