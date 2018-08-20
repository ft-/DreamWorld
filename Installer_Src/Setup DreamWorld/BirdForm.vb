Public Class BirdForm
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        BirdsModuleStartupbox.Checked = Form1.MySetting.BirdsModuleStartup

        BirdsFlockSizeDomain.Sorted = False

        Dim i As Integer
        For i = 1 To 100
            BirdsFlockSizeDomain.Items.Add(i.ToString)
        Next
        BirdsFlockSizeDomain.SelectedIndex = 25


        ChatChanelTextBox.Text = Form1.MySetting.BirdsChatChannel.ToString
        MaxSpeedTextBox.Text = Form1.MySetting.BirdsMaxSpeed.ToString
        MaxForceTextBox.Text = Form1.MySetting.BirdsMaxForce.ToString
        BirdsNeighbourDistanceTextBox.Text = Form1.MySetting.BirdsNeighbourDistance.ToString
        DesiredSeparationTextBox.Text = Form1.MySetting.BirdsDesiredSeparation.ToString
        BirdsToleranceTextBox.Text = Form1.MySetting.BirdsTolerance.ToString
        BirdsBorderSizeTextBox.Text = Form1.MySetting.BirdsBorderSize.ToString
        BirdsMaxHeightTextBox.Text = Form1.MySetting.BirdsMaxHeight.ToString
        PrimNameTextBox.Text = Form1.MySetting.BirdsPrim

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim thing As String = Form1.MyFolder + "/Outworldzfiles/IAR/OpenSimBirds.iar"
        Form1.LoadIARContent(thing)
    End Sub

    Private Sub BirdHelp_Click(sender As Object, e As EventArgs) Handles BirdHelp.Click
        Dim webAddress As String = Form1.Domain + "/Outworldz_installer/Bird_Module.htm"
        Process.Start(webAddress)
    End Sub

    Private Sub BirdsModuleStartupbox_CheckedChanged(sender As Object, e As EventArgs) Handles BirdsModuleStartupbox.CheckedChanged
        If BirdsModuleStartupbox.Checked Then
            Form1.MySetting.BirdsModuleStartup = True
        Else
            Form1.MySetting.BirdsModuleStartup = False
        End If
    End Sub

    Private Sub ChatChanelTextBox_TextChanged(sender As Object, e As EventArgs) Handles ChatChanelTextBox.TextChanged
        Try
            Form1.MySetting.BirdsChatChannel = CInt(ChatChanelTextBox.Text)
        Catch
        End Try
    End Sub

    Private Sub MaxSpeedTextBox_TextChanged(sender As Object, e As EventArgs) Handles MaxSpeedTextBox.TextChanged
        Try
            Form1.MySetting.BirdsMaxSpeed = Convert.ToDouble(MaxSpeedTextBox.Text)
        Catch
        End Try
    End Sub

    Private Sub MaxForceTextBox_TextChanged(sender As Object, e As EventArgs) Handles MaxForceTextBox.TextChanged
        Try
            Form1.MySetting.BirdsMaxForce = Convert.ToDouble(MaxForceTextBox.Text)
        Catch
        End Try
    End Sub

    Private Sub BirdsNeighbourDistanceTextBox_TextChanged(sender As Object, e As EventArgs) Handles BirdsNeighbourDistanceTextBox.TextChanged
        Try
            Form1.MySetting.BirdsNeighbourDistance = Convert.ToDouble(BirdsNeighbourDistanceTextBox.Text)
        Catch
        End Try
    End Sub

    Private Sub DesiredSeparationTextBox_TextChanged(sender As Object, e As EventArgs) Handles DesiredSeparationTextBox.TextChanged
        Try
            Form1.MySetting.BirdsDesiredSeparation = Convert.ToDouble(DesiredSeparationTextBox.Text)
        Catch
        End Try
    End Sub

    Private Sub BirdsToleranceTextBox_TextChanged(sender As Object, e As EventArgs) Handles BirdsToleranceTextBox.TextChanged
        Try
            Form1.MySetting.BirdsTolerance = Convert.ToDouble(BirdsToleranceTextBox.Text)
        Catch
        End Try
    End Sub

    Private Sub BirdsBorderSizeTextBox_TextChanged(sender As Object, e As EventArgs) Handles BirdsBorderSizeTextBox.TextChanged
        Try
            Form1.MySetting.BirdsBorderSize = Convert.ToDouble(BirdsBorderSizeTextBox.Text)
        Catch
        End Try
    End Sub

    Private Sub BirdsMaxHeightTextBox_TextChanged(sender As Object, e As EventArgs) Handles BirdsMaxHeightTextBox.TextChanged
        Try
            Form1.MySetting.BirdsMaxHeight = Convert.ToDouble(BirdsMaxHeightTextBox.Text)
        Catch
        End Try
    End Sub

    Private Sub PrimNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles PrimNameTextBox.TextChanged
        Form1.MySetting.BirdsPrim = PrimNameTextBox.Text
    End Sub
End Class