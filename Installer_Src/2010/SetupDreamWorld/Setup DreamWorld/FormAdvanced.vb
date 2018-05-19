

Public Class AdvancedForm
#Region "Declarations"

    Dim Sleepy As Integer = 1500
    Dim Awake As Integer = 1000
    Dim Coffee As Integer = 500
    Dim Toomuch As Integer = 0

#End Region

#Region "Functions"

    Private Sub Loaded(sender As Object, e As EventArgs) Handles Me.Load
        AutoBackupKeepFilesForDays.Text = Form1.MySetting.KeepForDays
        If Form1.MySetting.AutobackupInterval = 60 Then
            AutoBackupInterval.SelectedIndex = 0
        ElseIf Form1.MySetting.AutobackupInterval = 12 * 60 Then
            AutoBackupInterval.SelectedIndex = 1
        ElseIf Form1.MySetting.AutobackupInterval = 24 * 60 Then
            AutoBackupInterval.SelectedIndex = 2
        Else
            AutoBackupInterval.SelectedIndex = 3
        End If

        BackupFolder.Text = Form1.MySetting.BackupFolder

        Dim Chattime = Form1.MySetting.ChatTime

        If Chattime = Sleepy Then
            ChatSpeed.SelectedIndex = 0
        ElseIf Chattime = Awake Then
            ChatSpeed.SelectedIndex = 1
        ElseIf Chattime = Coffee Then
            ChatSpeed.SelectedIndex = 2
        Else
            ChatSpeed.SelectedIndex = 3
        End If

        AutoBackup.Checked = Form1.MySetting.AutoBackup
        TimerInterval.Text = Str(Form1.MySetting.TimerInterval)

        If Form1.MySetting.MapType = "None" Then
            MapNone.Checked = True
            MapPicture.Image = Nothing
        ElseIf Form1.MySetting.MapType = "Simple" Then
            MapSimple.Checked = True
            MapPicture.Image = My.Resources.Simple
        ElseIf Form1.MySetting.MapType = "Good" Then
            MapGood.Checked = True
            MapPicture.Image = My.Resources.Good
        ElseIf Form1.MySetting.MapType = "Better" Then
            MapBetter.Checked = True
            MapPicture.Image = My.Resources.Better
        ElseIf Form1.MySetting.MapType = "Best" Then
            MapBest.Checked = True
            MapPicture.Image = My.Resources.Best
        End If
        LoadWelcomeBox()

    End Sub

    Private Sub Form1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        ' nothing

    End Sub

    Private Sub ABEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles AutoBackup.CheckedChanged
        Form1.MySetting.AutoBackup = AutoBackup.Checked
        Form1.MySetting.SaveMyINI()
    End Sub

    Private Sub AutoBackupInterval_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AutoBackupInterval.SelectedIndexChanged
        Dim text = AutoBackupInterval.SelectedItem.ToString()
        Dim Interval As Integer
        If text = "Hourly" Then Interval = 60
        If text = "12 Hour" Then Interval = 60 * 12
        If text = "Daily" Then Interval = 60 * 24
        If text = "Weekly" Then Interval = 60 * 24 * 7
        Form1.MySetting.AutobackupInterval = Interval
        Form1.MySetting.SaveMyINI()
    End Sub

    Private Sub AutoBackupKeepFilesForDays_TextChanged(sender As Object, e As EventArgs) Handles AutoBackupKeepFilesForDays.TextChanged
        If Convert.ToInt32(AutoBackupKeepFilesForDays.Text) > 0 Then
            Form1.MySetting.KeepForDays = Convert.ToInt32(AutoBackupKeepFilesForDays.Text)
            Form1.MySetting.SaveMyINI()
        End If
    End Sub

    Private Sub ChatSpeed_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ChatSpeed.SelectedIndexChanged
        Dim text = ChatSpeed.SelectedItem.ToString()
        Dim ChatTime As Integer = 1500

        If text = "Sleepy" Then ChatTime = 1500
        If text = "Awake" Then ChatTime = 1000
        If text = "After Coffee" Then ChatTime = 500
        If text = "Too much Coffee" Then ChatTime = 0

        Form1.MySetting.ChatTime = ChatTime
        Form1.MySetting.SaveMyINI()
        Form1.gChatTime = ChatTime
    End Sub

    Private Sub TimerInterval_TextChanged(sender As Object, e As EventArgs) Handles TimerInterval.TextChanged

        Try
            If Len(TimerInterval.Text) > 0 Then

                Form1.MySetting.TimerInterval = CInt(TimerInterval.Text)
                If (Form1.MySetting.TimerInterval > 0) Then
                    Form1.PaintImage()
                Else
                    Form1.PictureBox1.Visible = False
                End If
            Else
                Form1.PictureBox1.Visible = False
                Form1.MySetting.TimerInterval = 0
                Form1.MySetting.SaveMyINI()
            End If
        Catch
        End Try

    End Sub

    Private Sub RegionButton1_Click(sender As Object, e As EventArgs) Handles RegionButton.Click

        Dim X As Integer = 300
        Dim Y As Integer = 200
        Dim counter As Integer = 0

        Dim RegionClass As RegionMaker = RegionMaker.Instance

        For Each Z As Integer In RegionClass.RegionNumbers
            Try
                Dim RegionName = RegionClass.RegionName(Z)
                Dim ActualForm As New FormRegion
                ActualForm.SetDesktopLocation(X, Y)
                ActualForm.Init(RegionName)
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
        Dim RegionClass As RegionMaker = RegionMaker.Instance
        RegionClass.CreateRegion("")
        Dim ActualForm As New FormRegion
        ActualForm.SetDesktopLocation(X, Y)
        ActualForm.Init("")
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
        Form1.MySetting.MapType = "None"
        Form1.MySetting.SaveMyINI()
        MapPicture.Image = Nothing

    End Sub

    Private Sub MapSimple_CheckedChanged(sender As Object, e As EventArgs) Handles MapSimple.CheckedChanged
        Form1.MySetting.MapType = "Simple"
        Form1.MySetting.SaveMyINI()
        MapPicture.Image = My.Resources.Simple
    End Sub

    Private Sub MapGood_CheckedChanged(sender As Object, e As EventArgs) Handles MapGood.CheckedChanged
        Form1.MySetting.MapType = "Good"
        Form1.MySetting.SaveMyINI()
        MapPicture.Image = My.Resources.Good
    End Sub

    Private Sub MapBetter_CheckedChanged(sender As Object, e As EventArgs) Handles MapBetter.CheckedChanged
        Form1.MySetting.MapType = "Better"
        Form1.MySetting.SaveMyINI()
        MapPicture.Image = My.Resources.Better
    End Sub

    Private Sub MapBest_CheckedChanged(sender As Object, e As EventArgs) Handles MapBest.CheckedChanged
        Form1.MySetting.MapType = "Best"
        Form1.MySetting.SaveMyINI()
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
                Form1.MySetting.BackupFolder = thing
                Form1.MySetting.SaveMyINI()
                BackupFolder.Text = thing
            End If
        End If
    End Sub

    Private Sub ComboBox1_Click(sender As Object, e As EventArgs) Handles WelcomeBox1.Click
        LoadWelcomeBox()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles WelcomeBox1.SelectedIndexChanged

        Dim value As String = TryCast(WelcomeBox1.SelectedItem, String)
        Form1.MySetting.WelcomeRegion = value

        Debug.Print("Selected " + value)
        Form1.MySetting.SaveMyINI()

    End Sub

    Private Sub LoadWelcomeBox()

        ' Default welcome region load
        WelcomeBox1.Items.Clear()

        Dim RegionClass As RegionMaker = RegionMaker.Instance

        ' !!!regions = regions.OrderBy(Function(x) x.RegionPort).ToList()
        'Dim regions = RegionClass.RegionNumbers.OrderBy(Function(x) x.RegionName).ToList()

        For Each X As Integer In RegionClass.RegionNumbers
            If RegionClass.RegionEnabled(X) Then
                WelcomeBox1.Items.Add(RegionClass.RegionName(X))
            End If
        Next

        Dim s = WelcomeBox1.FindString(Form1.MySetting.WelcomeRegion)
        If s > -1 Then
            WelcomeBox1.SelectedIndex = s
        Else
            MsgBox("Choose your Welcome region ", vbInformation, "Choose")
            Dim chosen = Form1.ChooseRegion(False)
            Dim Index = WelcomeBox1.FindString(chosen)
            WelcomeBox1.SelectedIndex = Index
        End If

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

    Private Sub Shoutcast_Click(sender As Object, e As EventArgs) Handles Shoutcast.Click
        Dim ActualForm As New Icecast
        Dim X As Integer = 300
        Dim Y As Integer = 200
        ActualForm.SetDesktopLocation(X, Y)
        ActualForm.Visible = True
        ActualForm.Activate()
        Application.DoEvents()
    End Sub


#End Region


End Class
