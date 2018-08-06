Imports System.IO

Public Class TosForm

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Load file MyFolder + "TOS.txt"
        Dim reader As System.IO.StreamReader
        reader = System.IO.File.OpenText(Form1.MyFolder + "\tos.html")
        'now loop through each line
        Dim HTML As String = ""
        While reader.Peek <> -1
            HTML = HTML + reader.ReadLine() + vbCrLf
        End While
        reader.Close()
        Editor1.BodyHtml = HTML

        ShowToLocalUsersCheckbox.Checked = Form1.MySetting.ShowToLocalUsers
        ShowToHGUsersCheckbox.Checked = Form1.MySetting.ShowToForeignUsers
        TOSEnable.Checked = Form1.MySetting.TOSEnabled


    End Sub
    Private Sub Form1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        'nothing

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles ShowToLocalUsersCheckbox.CheckedChanged

        Form1.MySetting.ShowToLocalUsers = ShowToLocalUsersCheckbox.Checked
        Form1.MySetting.SaveSettings()

    End Sub

    Private Sub ShowToHGUsersCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles ShowToHGUsersCheckbox.CheckedChanged

        Form1.MySetting.ShowToForeignUsers = ShowToHGUsersCheckbox.Checked
        Form1.MySetting.SaveSettings()

    End Sub

    Private Sub TOSEnable_CheckedChanged(sender As Object, e As EventArgs) Handles TOSEnable.CheckedChanged

        Form1.MySetting.TOSEnabled = TOSEnable.Checked
        Form1.MySetting.SaveSettings()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Form1.Running Then
            Dim webAddress As String = "http://" + Form1.MySetting.DNSName + ":" + Form1.MySetting.HttpPort + "/wifi/termsofservice.html"
            Process.Start(webAddress)
        Else
            MsgBox("Opensim must be running to show you the TOS.")
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim response = MsgBox("Clicking Yes will force all users to re-agree to the TOS on next login or visit.", vbYesNo)
        If response = vbYes Then
            Dim m As New Mysql(Form1.robustconnStr)
            If m.IsMySqlRunning() Is Nothing Then
                MsgBox("MySql is not running, so I cannot save the re-validate data. Start Opensim or Mysql and try again.")
            Else
                m.QueryString("update opensim.griduser set TOS = '';")
            End If
        End If

    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click

        Using outputFile As New StreamWriter(Form1.MyFolder + "\tos.html")
            outputFile.WriteLine(Editor1.BodyHtml)
        End Using

        Using outputFile As New StreamWriter(Form1.MyFolder + "\Outworldzfiles\opensim\bin\WifiPages\tos.html")
            outputFile.WriteLine(Editor1.BodyHtml)
        End Using

        Me.Close()

    End Sub

    Private Sub ApplyButton_Click(sender As Object, e As EventArgs) Handles ApplyButton.Click

        Using outputFile As New StreamWriter(Form1.MyFolder + "\tos.html")
            outputFile.WriteLine(Editor1.BodyHtml)
        End Using

        Using outputFile As New StreamWriter(Form1.MyFolder + "\Outworldzfiles\opensim\bin\WifiPages\tos.html")
            outputFile.WriteLine(Editor1.BodyHtml)
        End Using
    End Sub

End Class