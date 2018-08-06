
Imports System.Net

Public Class DNSName

#Region "Functions"

    Public Function Random() As String
        Dim value As Integer = CInt(Int((600000000 * Rnd()) + 1))
        Random = System.Convert.ToString(value)
    End Function

#End Region

#Region "Buttons"
    Private Sub DNS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Text = "DynDNS"

        TextBox1.Text = Form1.MySetting.DNSName

        NextNameButton.Enabled = True
        If TextBox1.Text = String.Empty Then
            MsgBox("Type in a 'name.Outworldz.net' for your grid, or just press 'Next' to get a suggested name. You can also use a DNS name.", vbInformation, "Name Needed")
        End If

    End Sub


    Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus

        If TextBox1.Text <> String.Empty Then

            TextBox1.Text = TextBox1.Text.Replace("http://", "")
            TextBox1.Text = TextBox1.Text.Replace("https://", "")

            Dim client As New System.Net.WebClient
            Dim Checkname As String = String.Empty
            Try
                Checkname = client.DownloadString("http://outworldz.net/getnewname.plx/?GridName=" + TextBox1.Text + "&r=" + Random())
            Catch ex As Exception
                Form1.Log("Cannot check the DNS Name, no connection to the Internet or www.Outworldz.com is down. " + ex.Message)
            End Try
            If (Checkname = TextBox1.Text) Then
                TextBox1.Text = Checkname
            End If
        End If
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click

        If TextBox1.Text <> String.Empty Then


            NextNameButton.Text = "Saving..."

            Form1.RegisterName(TextBox1.Text)

            NextNameButton.Text = "Next Name"

            Dim IP = Form1.DoGetHostAddresses(TextBox1.Text)
            Dim address As IPAddress = Nothing
            If IPAddress.TryParse(IP, address) Then
                Form1.MySetting.DNSName = TextBox1.Text
                Form1.MySetting.PublicIP = TextBox1.Text
                Form1.MySetting.SaveSettings()
                Me.Close()
                Return
            End If
            MsgBox("Could not use that name.  Must be valid domain name, a 'XYZ'.Outworldz.net name, the IP address of this machine or the router, a static or dynamic DNS name.", vbInformation, "Name Needed")
            Form1.MySetting.DNSName = TextBox1.Text
            Form1.MySetting.PublicIP = TextBox1.Text
            Form1.MySetting.SaveSettings()

        Else
            Form1.MySetting.DNSName = TextBox1.Text
            Form1.MySetting.PublicIP = TextBox1.Text
            Form1.MySetting.SaveSettings()

            Me.Close()
        End If

    End Sub


    Private Sub NextNameButton_Click(sender As Object, e As EventArgs) Handles NextNameButton.Click

        NextNameButton.Text = "Busy..."
        TextBox1.Text = String.Empty
        Application.DoEvents()
        Dim newname = Form1.GetNewDnsName()
        NextNameButton.Text = "Next Name"
        If newname = String.Empty Then
            MsgBox("Please enter a valid DNS name such as Name.Outworldz.net, or register for one at http://www.noip.com", vbInformation, "Name Needed")
            NextNameButton.Enabled = False
        Else
            NextNameButton.Enabled = True
            TextBox1.Text = newname
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub




#End Region
End Class