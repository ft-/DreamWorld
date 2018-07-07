Imports System.IO


Public Class Icecast

    Private Sub SC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ShoutcastPort.Text = Form1.MySetting.SC_PortBase
        ShoutcastPort1.Text = Form1.MySetting.SC_PortBase1
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

        Dim icecast As String = "<icecast>" + vbCrLf +
                           "<hostname>" + Form1.MySetting.DNSName + "</hostname>" + vbCrLf +
                            "<location>" + Form1.MySetting.SimName + "</location>" + vbCrLf +
                            "<admin>" + Form1.MySetting.AdminEmail + "</admin>" + vbCrLf +
                            "<shoutcast-mount>/stream</shoutcast-mount>" + vbCrLf +
                            "<listen-socket>" + vbCrLf +
                            "    <port>" + Form1.MySetting.SC_PortBase.ToString() + "</port>" + vbCrLf +
                            "</listen-socket>" + vbCrLf +
                            "<listen-socket>" + vbCrLf +
                            "   <port>" + Form1.MySetting.SC_PortBase1.ToString() + "</port>" + vbCrLf +
                            "   <shoutcast-compat>1</shoutcast-compat>" + vbCrLf +
                            "</listen-socket>" + vbCrLf +
                             "<limits>" + vbCrLf +
                              "   <clients>20</clients>" + vbCrLf +
                              "    <sources>2</sources>" + vbCrLf +
                              "    <queue-size>524288</queue-size>" + vbCrLf +
                              "     <client-timeout>30</client-timeout>" + vbCrLf +
                              "    <header-timeout>15</header-timeout>" + vbCrLf +
                              "    <source-timeout>10</source-timeout>" + vbCrLf +
                              "    <burst-on-connect>1</burst-on-connect>" + vbCrLf +
                              "    <burst-size>65535</burst-size>" + vbCrLf +
                              "</limits>" + vbCrLf +
                              "<authentication>" + vbCrLf +
                                  "<source-password>" + ShoutcastPassword.Text + "</source-password>" + vbCrLf +
                                  "<relay-password>" + ShoutcastPassword.Text + "</relay-password>" + vbCrLf +
                                  "<admin-user>admin</admin-user>" + vbCrLf +
                                  "<admin-password>" + AdminPassword.Text + "</admin-password>" + vbCrLf +
                              "</authentication>" + vbCrLf +
                              "<http-headers>" + vbCrLf +
                              "    <header name=" + """" + "Access-Control-Allow-Origin" + """" + " value=" + """" + "*" + """" + "/>" + vbCrLf +
                              "</http-headers>" + vbCrLf +
                              "<fileserve>1</fileserve>" + vbCrLf +
                              "<paths>" + vbCrLf +
                                  "<logdir>./log</logdir>" + vbCrLf +
                                  "<webroot>./web</webroot>" + vbCrLf +
                                  "<adminroot>./admin</adminroot>" + vbCrLf +  '
                                   "<alias source=" + """" + "/" + """" + " destination=" + """" + "/status.xsl" + """" + "/>" + vbCrLf +
                              "</paths>" + vbCrLf +
                              "<logging>" + vbCrLf +
                                  "<accesslog>access.log</accesslog>" + vbCrLf +
                                  "<errorlog>error.log</errorlog>" + vbCrLf +
                                  "<loglevel>3</loglevel>" + vbCrLf +
                                  "<logsize>10000</logsize>" + vbCrLf +
                              "</logging>" + vbCrLf +
                          "</icecast>" + vbCrLf

        Using outputFile As New StreamWriter(Form1.MyFolder + "\Outworldzfiles\Icecast\icecast_run.xml")
            outputFile.WriteLine(icecast)
        End Using

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

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles ShoutcastPort1.TextChanged
        Form1.MySetting.SC_PortBase1 = ShoutcastPort1.Text
    End Sub
End Class