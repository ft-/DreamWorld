

Public Class AdvancedForm
#Region "Declarations"



    Dim Tos As New TosForm
    Dim Maps As New FormMaps
    Dim Gloebits As New Gloebits
    Dim Icecast As New Icecast
    Dim Voice As New FormVoice
    Dim Bird As New BirdForm
    Dim Tide As New Tides
    Dim Expert As New Expert
    Dim Backups As New FormBackups
    Dim FormRegions As New FormRegions

#End Region


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

#Region "Clicks"


    Private Sub VoiceButton1_Click(sender As Object, e As EventArgs) Handles VoiceButton1.Click

        Voice.Close()
        Voice = New FormVoice
        Voice.Activate()
        Voice.Visible = True

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles GloebitsButton.Click

        ' Set the new form's desktop location so it appears below and
        ' to the right of the current form.
        Gloebits.Close()
        Gloebits = New Gloebits
        Gloebits.Activate()
        Gloebits.Visible = True
    End Sub

#End Region

    Private Sub ExpertButton1_Click(sender As Object, e As EventArgs) Handles ExpertButton1.Click

        Expert.Close()
        Expert = New Expert
        Expert.Visible = True
        Expert.Activate()

    End Sub

    Private Sub Shoutcast_Click(sender As Object, e As EventArgs) Handles Shoutcast.Click

        Icecast.Close()
        Icecast = New Icecast
        Icecast.Visible = True
        Icecast.Activate()

    End Sub

    Private Sub TOSButton_Click(sender As Object, e As EventArgs) Handles TOSButton.Click

        Tos.Close()
        Tos = New TosForm
        Tos.Activate()
        Tos.Visible = True

    End Sub

    Private Sub Birds_Click(sender As Object, e As EventArgs) Handles Birds.Click

        Bird.Close()
        Bird = New BirdForm
        Bird.Activate()
        Bird.Visible = True

    End Sub

    Private Sub TideButton_Click(sender As Object, e As EventArgs) Handles TideButton.Click

        Tide.Close()
        Tide = New Tides
        Tide.Activate()
        Tide.Visible = True

    End Sub

    Private Sub MapsButton_Click(sender As Object, e As EventArgs) Handles MapsButton.Click

        ' Set the new form's desktop location so it appears below and
        ' to the right of the current form.
        Maps.Close()
        Maps = New FormMaps
        Maps.Activate()
        Maps.Visible = True

    End Sub

    Private Sub BackupButton1_Click(sender As Object, e As EventArgs) Handles BackupButton1.Click

        ' Set the new form's desktop location so it appears below and
        ' to the right of the current form.
        Backups.Close()
        Backups = New FormBackups
        Backups.Activate()
        Backups.Visible = True

    End Sub

    Private Sub RegionsButton1_Click(sender As Object, e As EventArgs) Handles RegionsButton1.Click

        ' Set the new form's desktop location so it appears below and
        ' to the right of the current form.
        FormRegions.Close()
        FormRegions = New FormRegions
        FormRegions.Activate()
        FormRegions.Visible = True


    End Sub



#Region "Help"


    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs)
        Dim webAddress As String = Form1.gDomain + "/Outworldz_installer/technical.htm#Regions"
        Process.Start(webAddress)
    End Sub


#End Region


End Class
