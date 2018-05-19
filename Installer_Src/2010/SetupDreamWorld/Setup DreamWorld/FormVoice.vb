Public Class FormVoice

    Private Sub Loaded(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "Vivox Voice Settings"
        VivoxEnable.Checked = Form1.MySetting.VivoxEnabled
        VivoxPassword.Text = Form1.MySetting.Vivox_password
        VivoxUserName.Text = Form1.MySetting.Vivox_UserName
        VivoxPassword.UseSystemPasswordChar = True
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles VivoxEnable.CheckedChanged
        Form1.MySetting.VivoxEnabled = VivoxEnable.Checked
        Form1.MySetting.SaveMyINI()
    End Sub

    Private Sub RequestPassword_Click(sender As Object, e As EventArgs) Handles RequestPassword.Click
        Dim webAddress As String = "https://support.vivox.com/opensim/"
        Process.Start(webAddress)
    End Sub

    Private Sub VivoxUserName_TextChanged(sender As Object, e As EventArgs) Handles VivoxUserName.TextChanged
        Form1.MySetting.Vivox_UserName = VivoxUserName.Text
        Form1.MySetting.SaveMyINI()
    End Sub

    Private Sub VivoxPassword_TextChanged(sender As Object, e As EventArgs) Handles VivoxPassword.TextChanged
        VivoxPassword.UseSystemPasswordChar = False
        Form1.MySetting.Vivox_password = VivoxPassword.Text
        Form1.MySetting.SaveMyINI()
    End Sub
    Private Sub VivoxPassword_Clicked(sender As Object, e As EventArgs) Handles VivoxPassword.Click
        VivoxPassword.UseSystemPasswordChar = False
    End Sub
End Class