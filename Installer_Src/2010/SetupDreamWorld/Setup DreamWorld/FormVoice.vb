Public Class Form2

    Private Sub Loaded(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "Vivox Voice Settings"
        VivoxEnable.Checked = My.Settings.VivoxEnabled
        VivoxPassword.Text = My.Settings.Vivox_password
        VivoxUserName.Text = My.Settings.Vivox_username
        VivoxPassword.UseSystemPasswordChar = True
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles VivoxEnable.CheckedChanged
        My.Settings.VivoxEnabled = VivoxEnable.Checked
        My.Settings.Save()
    End Sub

    Private Sub VivoxHelpButton_Click(sender As Object, e As EventArgs) Handles VivoxHelpButton.Click
        Dim webAddress As String = Form1.Domain + "/Outworldz_Installer/Vivox.htm"
        Process.Start(webAddress)
    End Sub

    Private Sub FreeSwitchHelpButton_Click(sender As Object, e As EventArgs)
        Dim webAddress As String = Form1.Domain + "/Outworldz_Installer/FreeSwitch.htm"
        Process.Start(webAddress)
    End Sub

    Private Sub RequestPassword_Click(sender As Object, e As EventArgs) Handles RequestPassword.Click
        Dim webAddress As String = "https://support.vivox.com/opensim/"
        Process.Start(webAddress)
    End Sub

    Private Sub VivoxUserName_TextChanged(sender As Object, e As EventArgs) Handles VivoxUserName.TextChanged
        My.Settings.Vivox_username = VivoxUserName.Text
        My.Settings.Save()
    End Sub

    Private Sub VivoxPassword_TextChanged(sender As Object, e As EventArgs) Handles VivoxPassword.TextChanged
        VivoxPassword.UseSystemPasswordChar = False
        My.Settings.Vivox_password = VivoxPassword.Text
        My.Settings.Save()
    End Sub
    Private Sub VivoxPassword_Clicked(sender As Object, e As EventArgs) Handles VivoxPassword.Click
        VivoxPassword.UseSystemPasswordChar = False
    End Sub
End Class