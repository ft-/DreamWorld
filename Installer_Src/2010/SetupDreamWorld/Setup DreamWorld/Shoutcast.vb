Public Class Shoutcast

    Private Sub SC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ShoutcastPort.Text = Form1.MySetting.SC_PortBase
        AdminPassword.Text = Form1.MySetting.SC_AdminPassword
        ShoutcastPassword.Text = Form1.MySetting.SC_Password
        ShoutcastEnable.Checked = Form1.MySetting.SC_Enable
        SC_Show.Checked = Form1.MySetting.SC_Show

    End Sub

    Public Sub ShoutcastPort_TextChanged(sender As Object, e As EventArgs) Handles ShoutcastPort.TextChanged
        Form1.MySetting.SC_PortBase = ShoutcastPort.Text
    End Sub

    Private Sub AdminPassword_TextChanged(sender As Object, e As EventArgs) Handles AdminPassword.TextChanged
        Form1.MySetting.SC_AdminPassword = AdminPassword.Text
    End Sub

    Private Sub ShoutcastEnable_CheckedChanged(sender As Object, e As EventArgs) Handles ShoutcastEnable.CheckedChanged
        Form1.MySetting.SC_Enable = ShoutcastEnable.Checked
    End Sub

    Private Sub ShoutcastPassword_TextChanged(sender As Object, e As EventArgs) Handles ShoutcastPassword.TextChanged
        Form1.MySetting.SC_Password = ShoutcastPassword.Text
    End Sub

    Private Sub SC_Show_CheckedChanged(sender As Object, e As EventArgs) Handles SC_Show.CheckedChanged
        Form1.MySetting.SC_Show = SC_Show.Checked
    End Sub

    Private Sub FormisClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        Form1.MySetting.SaveMyINI()
        Form1.DoShoutcast()

    End Sub
End Class