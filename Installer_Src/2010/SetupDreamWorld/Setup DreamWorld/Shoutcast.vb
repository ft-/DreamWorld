Public Class Shoutcast

    Private Sub SC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ShoutcastPort.Text = Form1.MySetting.SC_PortBase
        AdminPassword.Text = Form1.MySetting.SC_AdminPassword
        ShoutcastPassword.Text = Form1.MySetting.SC_Password
        ShoutcastEnable.Checked = Form1.MySetting.SC_Enable
        SC_Show.Checked = Form1.MySetting.SC_Show

        AdminPassword.UseSystemPasswordChar = True
        ShoutcastPassword.UseSystemPasswordChar = True

    End Sub

    Public Sub ShoutcastPort_TextChanged(sender As Object, e As EventArgs) Handles ShoutcastPort.TextChanged

        Form1.MySetting.SC_PortBase = ShoutcastPort.Text

    End Sub

    Private Sub AdminPassword_TextChanged(sender As Object, e As EventArgs) Handles AdminPassword.TextChanged

        Form1.MySetting.SC_AdminPassword = AdminPassword.Text

    End Sub


    Private Sub AdminPassword_Click(sender As Object, e As EventArgs) Handles AdminPassword.Click

        AdminPassword.UseSystemPasswordChar = False

    End Sub


    Private Sub ShoutcastEnable_CheckedChanged(sender As Object, e As EventArgs) Handles ShoutcastEnable.CheckedChanged

        Form1.MySetting.SC_Enable = ShoutcastEnable.Checked

    End Sub
    Private Sub ShoutcastPassword_TextChanged(sender As Object, e As EventArgs) Handles ShoutcastPassword.TextChanged

        Form1.MySetting.SC_Password = ShoutcastPassword.Text

    End Sub
    Private Sub ShoutcastPassword_CLickChanged(sender As Object, e As EventArgs) Handles ShoutcastPassword.Click

        ShoutcastPassword.UseSystemPasswordChar = False

    End Sub
    Private Sub SC_Show_CheckedChanged(sender As Object, e As EventArgs) Handles SC_Show.CheckedChanged

        Form1.MySetting.SC_Show = SC_Show.Checked

    End Sub
    Private Sub FormisClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        Form1.MySetting.SaveMyINI()
        Form1.DoShoutcast()

    End Sub

    Private Sub LoadURL_Click(sender As Object, e As EventArgs) Handles LoadURL.Click
        If Form1.Running Then
            Dim webAddress As String = "http://" + Form1.MySetting.PublicIP + ":" + ShoutcastPort.Text
            Form1.Print("Shoutcast lets you stream music into your sim. The address will be " + webAddress)
            Process.Start(webAddress)
        ElseIf Form1.MySetting.SC_Enable = False Then
            Form1.Print("Shoutcast is not Enabled.")
        Else
            Form1.Print("Shoutcast is not running. Click Start to boot the system.")
        End If

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim webAddress As String = Form1.Domain + "/Outworldz_installer/Shoutcast.htm"
        Process.Start(webAddress)
    End Sub


End Class