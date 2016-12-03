Public Class AdvancedForm
    Friend WithEvents Label1 As Label
    Public Property Form2 As Object

    Dim Sleepy As Integer = 1500
    Dim Awake As Integer = 1000
    Dim Coffee As Integer = 500
    Dim Toomuch As Integer = 0

    Private Sub Loaded(sender As Object, e As EventArgs) Handles Me.Load

        If My.Settings.SizeX = "256" And My.Settings.SizeY = "256" Then
            CheckBox256.Checked = True
            CheckBox512.Checked = False
            CheckBox1024.Checked = False
            SizeX.Text = ""
            SizeY.Text = ""
        ElseIf My.Settings.SizeX = "512" And My.Settings.SizeY = "512" Then
            CheckBox256.Checked = False
            CheckBox512.Checked = True
            CheckBox1024.Checked = False
            SizeX.Text = ""
            SizeY.Text = ""
        ElseIf My.Settings.SizeX = "1024" And My.Settings.SizeY = "1024" Then
            CheckBox256.Checked = False
            CheckBox512.Checked = False
            CheckBox1024.Checked = True
            SizeX.Text = ""
            SizeY.Text = ""
        Else
            SizeX.Text = My.Settings.SizeX
            SizeY.Text = My.Settings.SizeY
        End If

        PublicPort.Text = My.Settings.PublicPort
        PrivatePort.Text = My.Settings.PrivatePort

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

        DiagPort.Text = My.Settings.LoopBack

        DbPort.Text = My.Settings.MySqlPort
        AutoBackup.Checked = My.Settings.AutoBackup
        Password.Text = My.Settings.Password
        AdminLast.Text = My.Settings.AdminLast
        AdminFirst.Text = My.Settings.AdminFirst
        RegionPort.Text = My.Settings.RegionPort

        AllowGod.Checked = My.Settings.allow_grid_gods
        RegionGod.Checked = My.Settings.region_owner_is_god
        ManagerGod.Checked = My.Settings.region_manager_is_god
        ParcelGod.Checked = My.Settings.parcel_owner_is_god

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

    End Sub

    Private Sub CheckBox256_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox256.CheckedChanged
        If CheckBox256.Checked = True Then
            CheckBox512.Checked = False
            CheckBox1024.Checked = False
            My.Settings.SizeX = "256"
            My.Settings.SizeY = "256"
            SizeX.Text = ""
            SizeY.Text = ""
        End If

    End Sub

    Private Sub CheckBox512_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox512.CheckedChanged
        If CheckBox512.Checked = True Then
            CheckBox256.Checked = False
            CheckBox1024.Checked = False
            My.Settings.SizeX = "512"
            My.Settings.SizeY = "512"
            SizeX.Text = ""
            SizeY.Text = ""
        End If
    End Sub

    Private Sub CheckBox1024_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1024.CheckedChanged
        If CheckBox1024.Checked = True Then
            CheckBox256.Checked = False
            CheckBox512.Checked = False
            My.Settings.SizeX = "1024"
            My.Settings.SizeY = "1024"
            SizeX.Text = ""
            SizeY.Text = ""
        End If
    End Sub

    Private Sub SizeX_TextChanged(sender As Object, e As EventArgs) Handles SizeX.TextChanged
        If SizeX.Text <> "" Then
            CheckBox256.Checked = False
            CheckBox512.Checked = False
            CheckBox1024.Checked = False
            My.Settings.SizeX = SizeX.Text
        End If
    End Sub

    Private Sub SizeY_TextChanged(sender As Object, e As EventArgs) Handles SizeY.TextChanged
        If SizeY.Text <> "" Then
            CheckBox256.Checked = False
            CheckBox512.Checked = False
            CheckBox1024.Checked = False
            My.Settings.SizeY = SizeY.Text
        End If
    End Sub

    Private Sub PrivatePort_TextChanged(sender As Object, e As EventArgs) Handles PrivatePort.TextChanged
        My.Settings.PrivatePort = PrivatePort.Text
    End Sub

    Private Sub PublicPort_TextChanged(sender As Object, e As EventArgs) Handles PublicPort.TextChanged
        My.Settings.PublicPort = PublicPort.Text
    End Sub
    Private Sub RegionPort_TextChanged(sender As Object, e As EventArgs) Handles RegionPort.TextChanged
        My.Settings.RegionPort = RegionPort.Text
    End Sub

    Private Sub Form2_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        My.Settings.Save()
        Form1.ActualForm = Nothing
    End Sub


    Private Sub DiagPort_TextChanged(sender As Object, e As EventArgs) Handles DiagPort.TextChanged
        My.Settings.LoopBack = DiagPort.Text
    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles DbPort.TextChanged
        My.Settings.MySqlPort = DbPort.Text
    End Sub

    Private Sub ABEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles AutoBackup.CheckedChanged
        My.Settings.AutoBackup = AutoBackup.Checked
    End Sub

    Private Sub AutoBackupInterval_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AutoBackupInterval.SelectedIndexChanged
        Dim text = AutoBackupInterval.SelectedItem.ToString()
        Dim Interval As Integer
        If text = "Hourly" Then Interval = 60
        If text = "12 Hour" Then Interval = 60 * 12
        If text = "Daily" Then Interval = 60 * 24
        If text = "Weekly" Then Interval = 60 * 24 * 7

        My.Settings.AutobackupInterval = Interval
    End Sub

    Private Sub AutoBackupKeepFilesForDays_TextChanged(sender As Object, e As EventArgs) Handles AutoBackupKeepFilesForDays.TextChanged
        If Convert.ToInt32(AutoBackupKeepFilesForDays.Text) > 0 Then
            My.Settings.KeepForDays = Convert.ToInt32(AutoBackupKeepFilesForDays.Text)
        End If
    End Sub

    Private Sub TextBox1_TextChanged_2(sender As Object, e As EventArgs) Handles AdminFirst.TextChanged
        My.Settings.AdminFirst = AdminFirst.Text
    End Sub

    Private Sub AdminLast_TextChanged(sender As Object, e As EventArgs) Handles AdminLast.TextChanged
        My.Settings.AdminLast = AdminLast.Text
    End Sub

    Private Sub Password_TextChanged(sender As Object, e As EventArgs) Handles Password.TextChanged
        My.Settings.Password = Password.Text
    End Sub

    Private Sub ChatSpeed_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ChatSpeed.SelectedIndexChanged

        Dim text = ChatSpeed.SelectedItem.ToString()
        Dim ChatTime As Integer = 1500

        If text = "Sleepy" Then ChatTime = 1500
        If text = "Awake" Then ChatTime = 1000
        If text = "After Coffee" Then ChatTime = 500
        If text = "Too much Coffee" Then ChatTime = 0

        My.Settings.ChatTime = ChatTime
        Form1.gChatTime = ChatTime
    End Sub

    Private Sub AllowGod_CheckedChanged(sender As Object, e As EventArgs) Handles AllowGod.CheckedChanged
        My.Settings.allow_grid_gods = AllowGod.Checked
    End Sub

    Private Sub RegionGod_CheckedChanged(sender As Object, e As EventArgs) Handles RegionGod.CheckedChanged
        My.Settings.region_owner_is_god = RegionGod.Checked
    End Sub

    Private Sub ManagerGod_CheckedChanged(sender As Object, e As EventArgs) Handles ManagerGod.CheckedChanged
        My.Settings.region_manager_is_god = ManagerGod.Checked
    End Sub

    Private Sub ParcelGod_CheckedChanged(sender As Object, e As EventArgs) Handles ParcelGod.CheckedChanged
        My.Settings.parcel_owner_is_god = ParcelGod.Checked
    End Sub

    Private Sub TimerInterval_TextChanged(sender As Object, e As EventArgs) Handles TimerInterval.TextChanged
        My.Settings.TimerInterval = CInt(TimerInterval.Text)
        If (My.Settings.TimerInterval > 0) Then
            Form1.PaintImage()
        End If
    End Sub

    Private Sub TextBox1_TextChanged_3(sender As Object, e As EventArgs) Handles AdminEmail.TextChanged
        My.Settings.AdminEmail = AdminEmail.Text
    End Sub

    Private Sub AccountConfirmationRequired_CheckedChanged(sender As Object, e As EventArgs) Handles AccountConfirmationRequired.CheckedChanged
        My.Settings.AccountConfirmationRequired = AccountConfirmationRequired.Checked
    End Sub

    Private Sub SmtpUsername_TextChanged(sender As Object, e As EventArgs) Handles SmtpUsername.TextChanged
        My.Settings.SmtpUsername = SmtpUsername.Text
    End Sub

    Private Sub SmtpPassword_TextChanged(sender As Object, e As EventArgs) Handles SmtpPassword.TextChanged
        My.Settings.SmtpPassword = SmtpPassword.Text
    End Sub

    Private Sub DnsName_TextChanged(sender As Object, e As EventArgs) Handles DnsName.TextChanged
        My.Settings.DnsName = DnsName.Text
        Form1.GetPubIP()

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles WebStats.CheckedChanged
        My.Settings.WebStats = WebStats.Checked
        Form1.WebStatsToolStripMenuItem.Visible = WebStats.Checked
    End Sub



    Private Sub DatabaseNameUser_TextChanged(sender As Object, e As EventArgs) Handles DbName.TextChanged
        My.Settings.DBName = DbName.Text
    End Sub

    Private Sub DbConnection_TextChanged(sender As Object, e As EventArgs) Handles DbConnection.TextChanged
        My.Settings.DBSource = DbConnection.Text
    End Sub

    Private Sub DbUsername_TextChanged(sender As Object, e As EventArgs) Handles DbUsername.TextChanged
        My.Settings.DBUserID = DbUsername.Text
    End Sub

    Private Sub DbPassword_TextChanged(sender As Object, e As EventArgs) Handles DbPassword.TextChanged
        My.Settings.DBPassword = DbPassword.Text
    End Sub
End Class