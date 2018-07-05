Imports System.IO

Public Class TosForm

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'ShowToLocalUsersCheckbox.Checked = MySettings.ShowToLocalUsers
        'ShowToHGUsersCheckbox.Checked = MySettings.ShowToForeignUsers
        'TOSEnable.Checked = My.SettingsTOSEnabled

        'Dim x = New LiveSwitch.TextControl.Editor


        'Load file MyFolder + "TOS.txt"
        Dim reader As System.IO.StreamReader
        reader = System.IO.File.OpenText(Form1.MyFolder + "\Outworldzfiles\tos.html")
        'now loop through each line
        Dim HTML As String = ""
        While reader.Peek <> -1
            HTML = HTML + reader.ReadLine() + vbCrLf
        End While

        Editor1.BodyHtml = HTML

        'RichTextBox1.Text = HTML

    End Sub
    Private Sub Form1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        ' save file MyFolder + "TOS.txt"
        ' Using outputFile As New StreamWriter(Form1.MyFolder + "\termsofservice.proto")
        '  outputFile.WriteLine(RichTextBox1.Text)
        ' End Using

        ' save file MyFolder + "TOS.txt"
        ' Using outputFile As New StreamWriter(Form1.MyFolder + "Outworldzfiles\opensim\bin\WifiPages\termsofservice.html")
        '  outputFile.WriteLine(RichTextBox1.Text)
        '  End Using

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles ShowToLocalUsersCheckbox.CheckedChanged

        'Form1.MySettings.ShowToLocalUsers = ShowToLocalUsersCheckbox.Checked
        'My.Settings.Save()

    End Sub

    Private Sub ShowToHGUsersCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles ShowToHGUsersCheckbox.CheckedChanged

        ' Form1.MySettings.ShowToForeignUsers = ShowToHGUsersCheckbox.Checked
        'My.Settings.Save()

    End Sub

    Private Sub TOSEnable_CheckedChanged(sender As Object, e As EventArgs) Handles TOSEnable.CheckedChanged

        ' Form1.MySettings.TOSEnabled = TOSEnable.Checked
        'My.Settings.Save()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Form1.Running Then
            Dim webAddress As String = My.Settings.DnsName + ":" + My.Settings.HttpPort + "/wifi/termsofservice.html"
            Process.Start(webAddress)
            Process.Start(webAddress)
        Else
            MsgBox("Opensim must be running to show you the TOS.")
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim response = MsgBox("Clicking OK will force all users to re-agree to the TOS on next login or visit.", vbYesNoCancel)
        If response = vbYes Then
            Dim m As New Mysql
            If m.isMySqlRunning() Is Nothing Then
                MsgBox("MySql is not running, so I cannot save the re-validate data. Start Opensim or Mysql and try again.")
            Else
                m.QueryString("update opensim.griduser set TOS = '';")
            End If

        End If
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click

        Using outputFile As New StreamWriter(Form1.MyFolder + "\Outworldzfiles\tos.html")
            outputFile.WriteLine(Editor1.BodyHtml)
        End Using

        Using outputFile As New StreamWriter(Form1.MyFolder + "\Outworldzfiles\opensim\bin\WifiPages\termsofservice.html")
            outputFile.WriteLine(Editor1.BodyHtml)
        End Using
    End Sub

End Class