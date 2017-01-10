Public Class DNSName

#Region "Functions"
    Public Function Random() As String
        Dim value As Integer = CInt(Int((600000000 * Rnd()) + 1))
        Random = System.Convert.ToString(value)
    End Function
#End Region

#Region "Buttons"
    Private Sub DNS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        SaveButton.Enabled = False
        NextNameButton.Enabled = True
        If TextBox1.Text = String.Empty Then
            RichTextBox1.Text = "Choose or type in a desired name for your grid and press Next. You can also use a Dynamic DNS name."
        End If

    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        Dim text = TextBox1.Text
        text = text.Replace("http://", "")

    End Sub

    Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus

        Dim client As New System.Net.WebClient
        Dim Checkname As String = String.Empty
        Try
            Checkname = client.DownloadString("http://outworldz.net/getnewname.plx/?GridName=" + TextBox1.Text + "?r=" + Random())
        Catch ex As Exception
            Form1.Log("Cannot get a check of the DNS Name" + ex.Message)
            SaveButton.Enabled = True
        End Try
        If (Checkname = TextBox1.Text) Then
            TextBox1.Text = Checkname
            SaveButton.Enabled = True
        ElseIf Checkname = "USED" Then
            RichTextBox1.Text = "That name is already in use"
            SaveButton.Enabled = False
        End If

    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs)

        Try
            Checkname = client.DownloadString("http://outworldz.net/getnewname.plx/?GridName=" + TextBox1.Text + "?r=" + Random())
        Catch ex As Exception
            Form1.Log("Cannot get a check of the DNS Name" + ex.Message)
            SaveButton.Enabled = True
        End Try
        My.Settings.DnsName = Text
        My.Settings.Save()
        Form1.GetPubIP()

    End Sub

    Private Sub NextNameButton_Click(sender As Object, e As EventArgs) Handles NextNameButton.Click

        Dim client As New System.Net.WebClient
        Dim Checkname As String = String.Empty
        Try
            Checkname = client.DownloadString("http://outworldz.net/getnewname.plx/?r=" + Random())
        Catch ex As Exception
            Form1.Log("Cannot get a new DNS Name: " + ex.Message)
            RichTextBox1.Text = "Please enter a DNS name, if you have one, or register for one at http://www.noip.com"
            NextNameButton.Enabled = False
        End Try
        If (Checkname = TextBox1.Text) Then
            TextBox1.Text = Checkname
        End If
    End Sub

#End Region
End Class