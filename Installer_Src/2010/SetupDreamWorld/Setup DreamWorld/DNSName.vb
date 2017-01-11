Imports System.Text.RegularExpressions

Public Class DNSName

#Region "Functions"

    Private Function Getnewname()
        Dim client As New System.Net.WebClient
        Dim Checkname As String = String.Empty
        Try
            Checkname = client.DownloadString("http://outworldz.net/getnewname.plx/?r=" + Random())
        Catch ex As Exception
            Form1.Log("Cannot get new name:" + ex.Message)
        End Try
        Return Checkname
    End Function
    Public Function Random() As String
        Dim value As Integer = CInt(Int((600000000 * Rnd()) + 1))
        Random = System.Convert.ToString(value)
    End Function
#End Region

#Region "Buttons"
    Private Sub DNS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Text = ""

        TextBox1.Text = My.Settings.DnsName
        SaveButton.Enabled = False
        NextNameButton.Enabled = True
        If TextBox1.Text = String.Empty Then
            RichTextBox1.Text = "Type in a name for your grid, or just press 'Next' to get a suggested name. You can also use a Dynamic DNS name."
        End If

    End Sub


    Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus

        If TextBox1.Text <> String.Empty Then

            TextBox1.Text = TextBox1.Text.Replace("http://", "")
            TextBox1.Text = TextBox1.Text.Replace("https://", "")
            'TextBox1.Text = Replace(TextBox1.Text, "[^\da-z\.-]+", String.Empty)

            Dim client As New System.Net.WebClient
            Dim Checkname As String = String.Empty
            Try
                Checkname = client.DownloadString("http://outworldz.net/getnewname.plx/?GridName=" + TextBox1.Text + "&r=" + Random())
            Catch ex As Exception
                Form1.Log("Cannot get a check of the DNS Name" + ex.Message)
            End Try
            If (Checkname = TextBox1.Text) Then
                TextBox1.Text = Checkname

            ElseIf Checkname = "USED" Then
                RichTextBox1.Text = "That name is already in use"

            End If
        End If
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click

        Dim client As New System.Net.WebClient

        RichTextBox1.Text = "Saving..."
        Dim Checkname As String = String.Empty
        If Not InStr(TextBox1.Text, ".") Then
            Dim pub As String
            If My.Settings.DNSPublic Then
                pub = "1"
            Else
                pub = "0"
            End If
            Try
                Checkname = client.DownloadString("http://outworldz.net/dns.plx/?GridName=" + TextBox1.Text + "&Public=" + pub + "&r=" + Random())
            Catch ex As Exception
                Form1.Log("Cannot get a check of the DNS Name" + ex.Message)
                SaveButton.Enabled = True
            End Try
        End If
        If Checkname = "NEW" Or Checkname = "UPDATED" Then
            TextBox1.Text = TextBox1.Text + ".Outworldz.net"
        End If
        My.Settings.DnsName = TextBox1.Text
        My.Settings.Save()
        Form1.ActualForm.DnsName.Text = TextBox1.Text

        Me.Close()

    End Sub

    Private Sub NextNameButton_Click(sender As Object, e As EventArgs) Handles NextNameButton.Click

        RichTextBox1.Text = "Busy..."
        TextBox1.Text = String.Empty
        Application.DoEvents()
        Dim newname = Getnewname()
        If newname = String.Empty Then
            RichTextBox1.Text = "Please enter a DNS name, if you have one, or register for one at http://www.noip.com"
            NextNameButton.Enabled = False
        Else
            RichTextBox1.Text = ""
            NextNameButton.Enabled = True
            SaveButton.Enabled = True
            TextBox1.Text = newname
        End If

    End Sub

    Private Sub PublicBox_CheckedChanged(sender As Object, e As EventArgs) Handles PublicBox.CheckedChanged
        If PublicBox.Checked Then
            SaveButton.Enabled = True
            My.Settings.DNSPublic = True
        Else
            SaveButton.Enabled = True
            My.Settings.DNSPublic = False
        End If
    End Sub





#End Region
End Class