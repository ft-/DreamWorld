

Public Class AdvancedForm
#Region "Declarations"

    Dim Sleepy As Integer = 1500
    Dim Awake As Integer = 1000
    Dim Coffee As Integer = 500
    Dim Toomuch As Integer = 0
    Dim MyRegion As RegionMaker


#End Region

#Region "Functions"

    Private Sub Loaded(sender As Object, e As EventArgs) Handles Me.Load
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

        AutoBackup.Checked = My.Settings.AutoBackup
        TimerInterval.Text = Str(My.Settings.TimerInterval)

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

    Private Sub RegionButton1_Click(sender As Object, e As EventArgs) Handles RegionButton.Click

        Dim X As Integer = 300
        Dim Y As Integer = 200
        Dim fname As String
        Dim counter As Integer = 0

        Form1.RegionClass.GetAllRegions()

        For Each o As Object In Form1.RegionClass.AllRegionObjects()
            Try
                fname = o.RegionName
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
        Next
    End Sub

    Private Sub AddRegion_Click(sender As Object, e As EventArgs) Handles AddRegion.Click

        Dim X As Integer = 300
        Dim Y As Integer = 200

        Form1.RegionClass.CreateRegion("")
        Dim ActualForm As New FormRegion
        ActualForm.SetDesktopLocation(X, Y)
        ActualForm.Init(Form1.RegionClass.CurRegionNum())
        ActualForm.Activate()
        ActualForm.Visible = True

    End Sub


    Private Sub VoiceButton1_Click(sender As Object, e As EventArgs) Handles VoiceButton1.Click
        Dim Voice As New FormVoice
        ' Set the new form's desktop location so it appears below and
        ' to the right of the current form.
        Voice.SetDesktopLocation(300, 200)
        Voice.Activate()
        Voice.Visible = True
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

        Dim value As String = TryCast(WelcomeBox1.SelectedItem, String)
        My.Settings.WelcomeRegion = value

        Debug.Print("Selected " + value)
        My.Settings.Save()
    End Sub

    Private Sub LoadWelcomeBox()
        ' Default welcome region load
        WelcomeBox1.Items.Clear()

        For Each o In Form1.RegionClass.AllRegionObjects
            If o.RegionEnabled Then
                WelcomeBox1.Items.Add(o.RegionName())
            End If
        Next
        Try
            Dim s = WelcomeBox1.FindString(My.Settings.WelcomeRegion)
            If s > -1 Then
                WelcomeBox1.SelectedIndex = s
            Else
                MsgBox("Welcome region reset to " + WelcomeBox1.SelectedItem.ToString, vbInformation)
                WelcomeBox1.SelectedIndex = 0
            End If
        Catch ex As Exception
            WelcomeBox1.SelectedIndex = 0
            MsgBox("Welcome region reset to " + WelcomeBox1.SelectedItem.ToString, vbInformation)
        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles GloebitsButton.Click
        Dim Gloebits As New Gloebits
        ' Set the new form's desktop location so it appears below and
        ' to the right of the current form.
        Gloebits.SetDesktopLocation(300, 200)
        Gloebits.Activate()
        Gloebits.Visible = True
    End Sub

#End Region

#Region "Help"

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles AutoBackupHelp.Click
        Dim webAddress As String = Form1.Domain + "/Outworldz_installer/technical.htm#Backup"
        Process.Start(webAddress)
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles MapHelp.Click
        Dim webAddress As String = Form1.Domain + "/Outworldz_installer/technical.htm#Maps"
        Process.Start(webAddress)
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PersonalityHelp.Click
        Dim webAddress As String = Form1.Domain + "/Outworldz_installer/technical.htm#Personality"
        Process.Start(webAddress)
    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles RegionHelp.Click
        Dim webAddress As String = Form1.Domain + "/Outworldz_installer/technical.htm#Regions"
        Process.Start(webAddress)
    End Sub

    Private Sub ExpertButton1_Click(sender As Object, e As EventArgs) Handles ExpertButton1.Click
        Dim ActualForm As New Expert
        Dim X As Integer = 300
        Dim Y As Integer = 200
        ActualForm.SetDesktopLocation(X, Y)
        ActualForm.Visible = True
        ActualForm.Activate()
        Application.DoEvents()
    End Sub

#End Region


End Class
