Imports System.Text.RegularExpressions
Imports System.Net

Public Class FormDNSName

    Dim initted As Boolean = False

#Region "ScreenSize"
    Public ScreenPosition As ScreenPos
    Private Handler As New EventHandler(AddressOf resize_page)

    'The following detects  the location of the form in screen coordinates
    Private Sub resize_page(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.Text = "Form screen position = " + Me.Location.ToString
        ScreenPosition.SaveXY(Me.Left, Me.Top)
    End Sub
    Private Sub SetScreen()
        Me.Show()
        ScreenPosition = New ScreenPos(Me.Name)
        AddHandler ResizeEnd, Handler
        Dim xy As List(Of Integer) = ScreenPosition.GetXY()
        Me.Left = xy.Item(0)
        Me.Top = xy.Item(1)
    End Sub

#End Region
#Region "Load"

    Private Sub DNS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetScreen()
        Me.Text = "DynDNS"

        DNSNameBox.Text = Form1.MySetting.DNSName
        DNSNameBox.Text = Form1.MySetting.DNSName
        UniqueId.Text = Form1.MySetting.Machine()
        EnableHypergrid.Checked = Form1.MySetting.EnableHypergrid
        SuitcaseCheckbox.Checked = Form1.MySetting.Suitcase

        NextNameButton.Enabled = True

        If DNSNameBox.Text = String.Empty Then
            MsgBox("Type in a 'name.Outworldz.net' for your grid, or just press 'Next' to get a suggested name. You can also use a DNS name.", vbInformation, "Name Needed")
        End If
        initted = True

    End Sub

#End Region

#Region "Functions"


    Public Function Random() As String
        Dim value As Integer = CInt(Int((600000000 * Rnd()) + 1))
        Random = System.Convert.ToString(value)
    End Function

#End Region

#Region "Buttons"


    Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles DNSNameBox.LostFocus

        If DNSNameBox.Text <> String.Empty Then

            DNSNameBox.Text = DNSNameBox.Text.Replace("http://", "")
            DNSNameBox.Text = DNSNameBox.Text.Replace("https://", "")

            DNSNameBox.Text = Regex.Replace(DNSNameBox.Text, ":\d+", "") ' no :8002 on end.


            Dim client As New System.Net.WebClient
            Dim Checkname As String = String.Empty
            Try
                Checkname = client.DownloadString("http://outworldz.net/getnewname.plx/?GridName=" + DNSNameBox.Text + "&r=" + Random())
            Catch ex As Exception
                Form1.Log("Cannot check the DNS Name, no connection to the Internet or www.Outworldz.com is down. " + ex.Message)
            End Try
            If (Checkname = DNSNameBox.Text) Then
                DNSNameBox.Text = Checkname
            End If
        End If
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click

        If DNSNameBox.Text <> String.Empty Then
            NextNameButton.Text = "Saving..."
            Form1.RegisterName(DNSNameBox.Text)

            NextNameButton.Text = "Next Name"

            Dim IP = Form1.DoGetHostAddresses(DNSNameBox.Text)
            Dim address As IPAddress = Nothing
            If IPAddress.TryParse(IP, address) Then
                Form1.MySetting.DNSName = DNSNameBox.Text
                Form1.MySetting.PublicIP = DNSNameBox.Text
                Form1.MySetting.SaveSettings()
                Me.Close()
                Return
            End If
            MsgBox("Could not use that name.  Must be valid domain name, a 'XYZ'.Outworldz.net name, the IP address of this machine or the router, a static or dynamic DNS name.", vbInformation, "Name Needed")
            Form1.MySetting.DNSName = DNSNameBox.Text
            Form1.MySetting.PublicIP = DNSNameBox.Text
            Form1.MySetting.SaveSettings()

        Else
            Form1.MySetting.DNSName = DNSNameBox.Text
            Form1.MySetting.PublicIP = DNSNameBox.Text
            Form1.MySetting.SaveSettings()

            Me.Close()
        End If

    End Sub


    Private Sub NextNameButton_Click(sender As Object, e As EventArgs) Handles NextNameButton.Click

        NextNameButton.Text = "Busy..."
        DNSNameBox.Text = String.Empty
        Application.DoEvents()
        Dim newname = Form1.GetNewDnsName()
        NextNameButton.Text = "Next Name"
        If newname = String.Empty Then
            MsgBox("Please enter a valid DNS name such as Name.Outworldz.net, or register for one at http://www.noip.com", vbInformation, "Name Needed")
            NextNameButton.Enabled = False
        Else
            NextNameButton.Enabled = True
            DNSNameBox.Text = newname
        End If

    End Sub


    Private Sub TestButton1_Click(sender As Object, e As EventArgs) Handles TestButton1.Click

        Form1.RegisterName(DNSNameBox.Text)
        Dim IP = Form1.DoGetHostAddresses(DNSNameBox.Text)
        Dim address As IPAddress = Nothing
        If IPAddress.TryParse(IP, address) Then
            MsgBox(DNSNameBox.Text + " was resolved to " + IP, vbInformation, "Test Result")
        Else
            MsgBox("Cannot resolve " + DNSNameBox.Text, vbInformation, "Error")
        End If

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs)
        '!!!
        Dim webAddress As String = Form1.gDomain + "/Outworldz_installer/technical.htm#DNSHelp"
        Process.Start(webAddress)

    End Sub

    Private Sub UniqueId_TextChanged(sender As Object, e As EventArgs)

        If Not initted Then Return
        Form1.MySetting.Machine() = UniqueId.Text
        Form1.MySetting.SaveSettings()

    End Sub

    Private Sub UniqueId_TextChanged_1(sender As Object, e As EventArgs) Handles UniqueId.TextChanged

        If Not initted Then Return
        Form1.MySetting.Machine() = UniqueId.Text
        Form1.MySetting.SaveSettings()

    End Sub

    Private Sub EnableHypergrid_CheckedChanged(sender As Object, e As EventArgs) Handles EnableHypergrid.CheckedChanged

        If Not initted Then Return
        Form1.MySetting.EnableHypergrid = EnableHypergrid.Checked
        Form1.MySetting.SaveSettings()

    End Sub

    Private Sub SuitcaseCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles SuitcaseCheckbox.CheckedChanged

        If Not initted Then Return
        Form1.MySetting.Suitcase() = SuitcaseCheckbox.Checked
        Form1.MySetting.SaveSettings()

        If Not SuitcaseCheckbox.Checked Then
            MsgBox("Disabling the Inventory Suitcase exposes all your inventory to other grids. ")
        End If

    End Sub

    Private Sub DynDNSPassword_Click(sender As Object, e As EventArgs) Handles DynDNSPassword.Click
        Form1.Help("DNS")
    End Sub




#End Region
End Class