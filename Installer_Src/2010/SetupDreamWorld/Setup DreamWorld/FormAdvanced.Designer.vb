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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdvancedForm))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MapHelp = New System.Windows.Forms.PictureBox()
        Me.MapNone = New System.Windows.Forms.RadioButton()
        Me.MapSimple = New System.Windows.Forms.RadioButton()
        Me.MapBetter = New System.Windows.Forms.RadioButton()
        Me.MapBest = New System.Windows.Forms.RadioButton()
        Me.MapGood = New System.Windows.Forms.RadioButton()
        Me.PersonalityHelp = New System.Windows.Forms.PictureBox()
        Me.TimerInterval = New System.Windows.Forms.TextBox()
        Me.ChatSpeed = New System.Windows.Forms.ComboBox()
        Me.AutoBackupHelp = New System.Windows.Forms.PictureBox()
        Me.AutoBackupKeepFilesForDays = New System.Windows.Forms.TextBox()
        Me.AutoBackupInterval = New System.Windows.Forms.ComboBox()
        Me.AutoBackup = New System.Windows.Forms.CheckBox()
        Me.WelcomeRegion = New System.Windows.Forms.Label()
        Me.WelcomeBox1 = New System.Windows.Forms.ComboBox()
        Me.RegionHelp = New System.Windows.Forms.PictureBox()
        Me.GloebitsButton = New System.Windows.Forms.Button()
        Me.ExpertButton1 = New System.Windows.Forms.Button()
        Me.MapBox = New System.Windows.Forms.GroupBox()
        Me.MapPicture = New System.Windows.Forms.PictureBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.VoiceButton1 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BackupFolder = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.AddRegion = New System.Windows.Forms.Button()
        Me.RegionButton = New System.Windows.Forms.Button()
        Me.Shoutcast = New System.Windows.Forms.Button()
        CType(Me.MapHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PersonalityHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AutoBackupHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RegionHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MapBox.SuspendLayout()
        CType(Me.MapPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MapHelp
        '
        Me.MapHelp.Image = Global.Outworldz.My.Resources.Resources.about
        Me.MapHelp.Location = New System.Drawing.Point(112, 17)
        Me.MapHelp.Name = "MapHelp"
        Me.MapHelp.Size = New System.Drawing.Size(28, 27)
        Me.MapHelp.TabIndex = 1857
        Me.MapHelp.TabStop = False
        Me.ToolTip1.SetToolTip(Me.MapHelp, "Click for Help on Maps")
        '
        'MapNone
        '
        Me.MapNone.AutoSize = True
        Me.MapNone.Location = New System.Drawing.Point(6, 29)
        Me.MapNone.Name = "MapNone"
        Me.MapNone.Size = New System.Drawing.Size(63, 21)
        Me.MapNone.TabIndex = 137
        Me.MapNone.TabStop = True
        Me.MapNone.Text = "None"
        Me.ToolTip1.SetToolTip(Me.MapNone, "No Maps at all")
        Me.MapNone.UseVisualStyleBackColor = True
        '
        'MapSimple
        '
        Me.MapSimple.AutoSize = True
        Me.MapSimple.Location = New System.Drawing.Point(6, 48)
        Me.MapSimple.Name = "MapSimple"
        Me.MapSimple.Size = New System.Drawing.Size(122, 21)
        Me.MapSimple.TabIndex = 33
        Me.MapSimple.TabStop = True
        Me.MapSimple.Text = "Simple but fast"
        Me.ToolTip1.SetToolTip(Me.MapSimple, "Simple - ")
        Me.MapSimple.UseVisualStyleBackColor = True
        '
        'MapBetter
        '
        Me.MapBetter.AutoSize = True
        Me.MapBetter.Location = New System.Drawing.Point(7, 87)
        Me.MapBetter.Name = "MapBetter"
        Me.MapBetter.Size = New System.Drawing.Size(153, 21)
        Me.MapBetter.TabIndex = 35
        Me.MapBetter.TabStop = True
        Me.MapBetter.Text = "Better (Prims, Slow)"
        Me.MapBetter.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.ToolTip1.SetToolTip(Me.MapBetter, "Warp3DImageModule with Prims and Textures")
        Me.MapBetter.UseVisualStyleBackColor = True
        '
        'MapBest
        '
        Me.MapBest.AutoSize = True
        Me.MapBest.Location = New System.Drawing.Point(6, 109)
        Me.MapBest.Name = "MapBest"
        Me.MapBest.Size = New System.Drawing.Size(189, 21)
        Me.MapBest.TabIndex = 136
        Me.MapBest.TabStop = True
        Me.MapBest.Text = "Best (Prims +Mesh, Slow)"
        Me.ToolTip1.SetToolTip(Me.MapBest, "Slow, but has Prims and Mesh")
        Me.MapBest.UseVisualStyleBackColor = True
        '
        'MapGood
        '
        Me.MapGood.AutoSize = True
        Me.MapGood.Location = New System.Drawing.Point(7, 67)
        Me.MapGood.Name = "MapGood"
        Me.MapGood.Size = New System.Drawing.Size(130, 21)
        Me.MapGood.TabIndex = 34
        Me.MapGood.TabStop = True
        Me.MapGood.Text = "Good (Warp3D)"
        Me.ToolTip1.SetToolTip(Me.MapGood, "Fast and simple map usng Warp3DImageModule")
        Me.MapGood.UseVisualStyleBackColor = True
        '
        'PersonalityHelp
        '
        Me.PersonalityHelp.Image = Global.Outworldz.My.Resources.Resources.about
        Me.PersonalityHelp.Location = New System.Drawing.Point(141, 0)
        Me.PersonalityHelp.Name = "PersonalityHelp"
        Me.PersonalityHelp.Size = New System.Drawing.Size(28, 32)
        Me.PersonalityHelp.TabIndex = 1858
        Me.PersonalityHelp.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PersonalityHelp, "Click for Help on Personality")
        '
        'TimerInterval
        '
        Me.TimerInterval.Location = New System.Drawing.Point(130, 68)
        Me.TimerInterval.Name = "TimerInterval"
        Me.TimerInterval.Size = New System.Drawing.Size(39, 22)
        Me.TimerInterval.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.TimerInterval, "The cycle time for the wall paper - in seconds. 0 = Off")
        '
        'ChatSpeed
        '
        Me.ChatSpeed.FormattingEnabled = True
        Me.ChatSpeed.Items.AddRange(New Object() {"Sleepy", "Awake", "After Coffee", "Too much Coffee"})
        Me.ChatSpeed.Location = New System.Drawing.Point(9, 21)
        Me.ChatSpeed.Name = "ChatSpeed"
        Me.ChatSpeed.Size = New System.Drawing.Size(113, 24)
        Me.ChatSpeed.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.ChatSpeed, "The speed the sleepy chat occurs at.  ")
        '
        'AutoBackupHelp
        '
        Me.AutoBackupHelp.Image = Global.Outworldz.My.Resources.Resources.about
        Me.AutoBackupHelp.Location = New System.Drawing.Point(154, 17)
        Me.AutoBackupHelp.Name = "AutoBackupHelp"
        Me.AutoBackupHelp.Size = New System.Drawing.Size(28, 32)
        Me.AutoBackupHelp.TabIndex = 1857
        Me.AutoBackupHelp.TabStop = False
        Me.ToolTip1.SetToolTip(Me.AutoBackupHelp, "Click for Help on Backup")
        '
        'AutoBackupKeepFilesForDays
        '
        Me.AutoBackupKeepFilesForDays.Location = New System.Drawing.Point(125, 85)
        Me.AutoBackupKeepFilesForDays.Name = "AutoBackupKeepFilesForDays"
        Me.AutoBackupKeepFilesForDays.Size = New System.Drawing.Size(47, 22)
        Me.AutoBackupKeepFilesForDays.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.AutoBackupKeepFilesForDays, "Backaups older than this number will be deleted")
        '
        'AutoBackupInterval
        '
        Me.AutoBackupInterval.AutoCompleteCustomSource.AddRange(New String() {"1 Hour", "4 Hour", "12 Hour", "Daily", "Weekly"})
        Me.AutoBackupInterval.FormattingEnabled = True
        Me.AutoBackupInterval.Items.AddRange(New Object() {"Hourly", "12 Hour", "Daily", "Weekly"})
        Me.AutoBackupInterval.Location = New System.Drawing.Point(80, 55)
        Me.AutoBackupInterval.Name = "AutoBackupInterval"
        Me.AutoBackupInterval.Size = New System.Drawing.Size(121, 24)
        Me.AutoBackupInterval.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.AutoBackupInterval, "The sim nust run this long and it will back up")
        '
        'AutoBackup
        '
        Me.AutoBackup.AutoSize = True
        Me.AutoBackup.Location = New System.Drawing.Point(22, 24)
        Me.AutoBackup.Name = "AutoBackup"
        Me.AutoBackup.Size = New System.Drawing.Size(82, 21)
        Me.AutoBackup.TabIndex = 1
        Me.AutoBackup.Text = "Enabled"
        Me.ToolTip1.SetToolTip(Me.AutoBackup, "Saves OAR files periodically")
        Me.AutoBackup.UseVisualStyleBackColor = True
        '
        'WelcomeRegion
        '
        Me.WelcomeRegion.AutoSize = True
        Me.WelcomeRegion.Location = New System.Drawing.Point(6, 22)
        Me.WelcomeRegion.Name = "WelcomeRegion"
        Me.WelcomeRegion.Size = New System.Drawing.Size(166, 17)
        Me.WelcomeRegion.TabIndex = 32
        Me.WelcomeRegion.Text = "Default region for visitors"
        Me.ToolTip1.SetToolTip(Me.WelcomeRegion, "This region is where visitors first arrive")
        '
        'WelcomeBox1
        '
        Me.WelcomeBox1.AutoCompleteCustomSource.AddRange(New String() {"1 Hour", "4 Hour", "12 Hour", "Daily", "Weekly"})
        Me.WelcomeBox1.FormattingEnabled = True
        Me.WelcomeBox1.Items.AddRange(New Object() {"Hourly", "12 Hour", "Daily", "Weekly"})
        Me.WelcomeBox1.Location = New System.Drawing.Point(4, 38)
        Me.WelcomeBox1.Name = "WelcomeBox1"
        Me.WelcomeBox1.Size = New System.Drawing.Size(148, 24)
        Me.WelcomeBox1.TabIndex = 31
        Me.ToolTip1.SetToolTip(Me.WelcomeBox1, "The first sim a visitor will arrive in")
        '
        'RegionHelp
        '
        Me.RegionHelp.Image = Global.Outworldz.My.Resources.Resources.about
        Me.RegionHelp.Location = New System.Drawing.Point(168, 14)
        Me.RegionHelp.Name = "RegionHelp"
        Me.RegionHelp.Size = New System.Drawing.Size(28, 27)
        Me.RegionHelp.TabIndex = 1858
        Me.RegionHelp.TabStop = False
        Me.ToolTip1.SetToolTip(Me.RegionHelp, "Click for Help on Regions")
        '
        'GloebitsButton
        '
        Me.GloebitsButton.Location = New System.Drawing.Point(467, 150)
        Me.GloebitsButton.Name = "GloebitsButton"
        Me.GloebitsButton.Size = New System.Drawing.Size(143, 23)
        Me.GloebitsButton.TabIndex = 1867
        Me.GloebitsButton.Text = "Gloebits Currency Setup"
        Me.GloebitsButton.UseVisualStyleBackColor = True
        '
        'ExpertButton1
        '
        Me.ExpertButton1.Location = New System.Drawing.Point(467, 237)
        Me.ExpertButton1.Name = "ExpertButton1"
        Me.ExpertButton1.Size = New System.Drawing.Size(143, 23)
        Me.ExpertButton1.TabIndex = 1866
        Me.ExpertButton1.Text = "Expert Settings"
        Me.ExpertButton1.UseVisualStyleBackColor = True
        '
        'MapBox
        '
        Me.MapBox.Controls.Add(Me.MapHelp)
        Me.MapBox.Controls.Add(Me.MapPicture)
        Me.MapBox.Controls.Add(Me.MapNone)
        Me.MapBox.Controls.Add(Me.MapSimple)
        Me.MapBox.Controls.Add(Me.MapBetter)
        Me.MapBox.Controls.Add(Me.MapBest)
        Me.MapBox.Controls.Add(Me.MapGood)
        Me.MapBox.Location = New System.Drawing.Point(225, 13)
        Me.MapBox.Name = "MapBox"
        Me.MapBox.Size = New System.Drawing.Size(210, 267)
        Me.MapBox.TabIndex = 1865
        Me.MapBox.TabStop = False
        Me.MapBox.Text = "Maps"
        '
        'MapPicture
        '
        Me.MapPicture.InitialImage = CType(resources.GetObject("MapPicture.InitialImage"), System.Drawing.Image)
        Me.MapPicture.Location = New System.Drawing.Point(49, 154)
        Me.MapPicture.Name = "MapPicture"
        Me.MapPicture.Size = New System.Drawing.Size(100, 93)
        Me.MapPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.MapPicture.TabIndex = 138
        Me.MapPicture.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.PersonalityHelp)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.TimerInterval)
        Me.GroupBox5.Controls.Add(Me.ChatSpeed)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 176)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(182, 104)
        Me.GroupBox5.TabIndex = 1863
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Personality"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(13, 51)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(156, 17)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "Wallpaper Time (0=Off)"
        '
        'VoiceButton1
        '
        Me.VoiceButton1.Location = New System.Drawing.Point(467, 179)
        Me.VoiceButton1.Name = "VoiceButton1"
        Me.VoiceButton1.Size = New System.Drawing.Size(143, 23)
        Me.VoiceButton1.TabIndex = 1864
        Me.VoiceButton1.Text = "Voice Setup"
        Me.VoiceButton1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.AutoBackupHelp)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.BackupFolder)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.AutoBackupKeepFilesForDays)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.AutoBackupInterval)
        Me.GroupBox3.Controls.Add(Me.AutoBackup)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(207, 158)
        Me.GroupBox3.TabIndex = 1862
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Auto Backup"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 17)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Save To Folder:"
        '
        'BackupFolder
        '
        Me.BackupFolder.Location = New System.Drawing.Point(9, 133)
        Me.BackupFolder.Name = "BackupFolder"
        Me.BackupFolder.Size = New System.Drawing.Size(163, 22)
        Me.BackupFolder.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 17)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Keep for Days"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 17)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Interval:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RegionHelp)
        Me.GroupBox2.Controls.Add(Me.WelcomeRegion)
        Me.GroupBox2.Controls.Add(Me.WelcomeBox1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.AddRegion)
        Me.GroupBox2.Controls.Add(Me.RegionButton)
        Me.GroupBox2.Location = New System.Drawing.Point(458, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(202, 131)
        Me.GroupBox2.TabIndex = 1861
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Regions"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 17)
        Me.Label3.TabIndex = 28
        '
        'AddRegion
        '
        Me.AddRegion.Location = New System.Drawing.Point(4, 65)
        Me.AddRegion.Name = "AddRegion"
        Me.AddRegion.Size = New System.Drawing.Size(148, 23)
        Me.AddRegion.TabIndex = 26
        Me.AddRegion.Text = "Add Region"
        Me.AddRegion.UseVisualStyleBackColor = True
        '
        'RegionButton
        '
        Me.RegionButton.Location = New System.Drawing.Point(4, 94)
        Me.RegionButton.Name = "RegionButton"
        Me.RegionButton.Size = New System.Drawing.Size(148, 23)
        Me.RegionButton.TabIndex = 27
        Me.RegionButton.Text = "Configure Regions"
        Me.RegionButton.UseVisualStyleBackColor = True
        '
        'Shoutcast
        '
        Me.Shoutcast.Location = New System.Drawing.Point(467, 208)
        Me.Shoutcast.Name = "Shoutcast"
        Me.Shoutcast.Size = New System.Drawing.Size(143, 23)
        Me.Shoutcast.TabIndex = 1868
        Me.Shoutcast.Text = "Icecast Setup"
        Me.Shoutcast.UseVisualStyleBackColor = True
        '
        'AdvancedForm
        '
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(672, 292)
        Me.Controls.Add(Me.Shoutcast)
        Me.Controls.Add(Me.GloebitsButton)
        Me.Controls.Add(Me.ExpertButton1)
        Me.Controls.Add(Me.MapBox)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.VoiceButton1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AdvancedForm"
        Me.Text = "Common Settings"
        CType(Me.MapHelp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PersonalityHelp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AutoBackupHelp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RegionHelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapBox.ResumeLayout(False)
        Me.MapBox.PerformLayout()
        CType(Me.MapPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents GloebitsButton As Button
    Friend WithEvents ExpertButton1 As Button
    Friend WithEvents MapBox As GroupBox
    Friend WithEvents MapHelp As PictureBox
    Friend WithEvents MapPicture As PictureBox
    Friend WithEvents MapNone As RadioButton
    Friend WithEvents MapSimple As RadioButton
    Friend WithEvents MapBetter As RadioButton
    Friend WithEvents MapBest As RadioButton
    Friend WithEvents MapGood As RadioButton
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents PersonalityHelp As PictureBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TimerInterval As TextBox
    Friend WithEvents ChatSpeed As ComboBox
    Friend WithEvents VoiceButton1 As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents AutoBackupHelp As PictureBox
    Friend WithEvents Label6 As Label
    Friend WithEvents BackupFolder As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents AutoBackupKeepFilesForDays As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents AutoBackupInterval As ComboBox
    Friend WithEvents AutoBackup As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents WelcomeRegion As Label
    Friend WithEvents WelcomeBox1 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents AddRegion As Button
    Friend WithEvents RegionButton As Button
    Friend WithEvents RegionHelp As PictureBox
    Friend WithEvents Shoutcast As Button
End Class
