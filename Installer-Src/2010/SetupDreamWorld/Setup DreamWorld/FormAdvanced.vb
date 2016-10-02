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
        WifiPort.Text = My.Settings.WifiPort
        Mysql.Text = My.Settings.MySqlPort
        AutoBackup.Checked = My.Settings.AutoBackup
        Password.Text = My.Settings.Password
        AdminLast.Text = My.Settings.AdminLast
        AdminFirst.Text = My.Settings.AdminFirst
        RegionPort.Text = My.Settings.RegionPort

    End Sub

    Private Sub CheckBox256_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox256.CheckedChanged
        If CheckBox256.Checked = True Then
            CheckBox512.Checked = False
            CheckBox1024.Checked = False
            My.Settings.SizeX = "256"
            My.Settings.SizeY = "256"
            SizeX.Text = ""
            SizeY.Text = ""
            My.Settings.Save()
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
            My.Settings.Save()
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
            My.Settings.Save()
        End If
    End Sub

    Private Sub SizeX_TextChanged(sender As Object, e As EventArgs) Handles SizeX.TextChanged
        If SizeX.Text <> "" Then
            CheckBox256.Checked = False
            CheckBox512.Checked = False
            CheckBox1024.Checked = False
            My.Settings.SizeX = SizeX.Text
            My.Settings.Save()
        End If
    End Sub

    Private Sub SizeY_TextChanged(sender As Object, e As EventArgs) Handles SizeY.TextChanged
        If SizeY.Text <> "" Then
            CheckBox256.Checked = False
            CheckBox512.Checked = False
            CheckBox1024.Checked = False
            My.Settings.SizeY = SizeY.Text
            My.Settings.Save()
        End If
    End Sub

    Private Sub PrivatePort_TextChanged(sender As Object, e As EventArgs) Handles PrivatePort.TextChanged
        My.Settings.PrivatePort = PrivatePort.Text
        My.Settings.Save()
    End Sub

    Private Sub PublicPort_TextChanged(sender As Object, e As EventArgs) Handles PublicPort.TextChanged
        My.Settings.PublicPort = PublicPort.Text
        My.Settings.Save()
    End Sub
    Private Sub RegionPort_TextChanged(sender As Object, e As EventArgs) Handles RegionPort.TextChanged
        My.Settings.RegionPort = RegionPort.Text
        My.Settings.Save()
    End Sub

    Private Sub Form2_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        'My.Settings.Save()
        Form1.ActualForm = Nothing
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles WifiPort.TextChanged
        My.Settings.WifiPort = WifiPort.Text
        My.Settings.Save()
    End Sub

    Private Sub DiagPort_TextChanged(sender As Object, e As EventArgs) Handles DiagPort.TextChanged
        My.Settings.LoopBack = DiagPort.Text
        My.Settings.Save()
    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles Mysql.TextChanged
        My.Settings.MySqlPort = Mysql.Text
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

    Private Sub Password_TextChanged(sender As Object, e As EventArgs) Handles Password.TextChanged
        My.Settings.Password = Password.Text
        My.Settings.Save()
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
        My.Settings.Save()

    End Sub
End Class