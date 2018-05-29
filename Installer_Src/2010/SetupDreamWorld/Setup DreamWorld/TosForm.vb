Imports System.IO

Public Class TosForm

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ShowToLocalUsersCheckbox.Checked = My.Settings.ShowToLocalUsers
        ShowToHGUsersCheckbox.Checked = My.Settings.ShowToForeignUsers
        TOSEnable.Checked = My.Settings.TOSEnabled

        'Load file MyFolder + "TOS.txt"
        Dim reader As System.IO.StreamReader
        reader = System.IO.File.OpenText(Form1.MyFolder + "\TOS.txt")
        'now loop through each line
        Dim HTML As String = ""
        While reader.Peek <> -1
            HTML = HTML + reader.ReadLine() + vbCrLf
        End While
        RichTextBox1.Text = HTML

    End Sub
    Private Sub Form1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        ' save file MyFolder + "TOS.txt"
        Using outputFile As New StreamWriter(Form1.MyFolder + "\TOS.txt")
            outputFile.WriteLine(RichTextBox1.Text)
        End Using

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles ShowToLocalUsersCheckbox.CheckedChanged

        My.Settings.ShowToLocalUsers = ShowToLocalUsersCheckbox.Checked
        My.Settings.Save()

    End Sub

    Private Sub ShowToHGUsersCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles ShowToHGUsersCheckbox.CheckedChanged

        My.Settings.ShowToForeignUsers = ShowToHGUsersCheckbox.Checked
        My.Settings.Save()

    End Sub

    Private Sub TOSEnable_CheckedChanged(sender As Object, e As EventArgs) Handles TOSEnable.CheckedChanged

        My.Settings.TOSEnabled = TOSEnable.Checked
        My.Settings.Save()

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
End Class