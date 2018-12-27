Imports System.ComponentModel
Public Class FormMaps
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

    Private Sub Loaded(sender As Object, e As EventArgs) Handles Me.Load
        If Form1.MySetting.MapType = "None" Then
            MapNone.Checked = True
            MapPicture.Image = My.Resources.blankbox
        ElseIf Form1.MySetting.MapType = "Simple" Then
            MapSimple.Checked = True
            MapPicture.Image = My.Resources.Simple
        ElseIf Form1.MySetting.MapType = "Good" Then
            MapGood.Checked = True
            MapPicture.Image = My.Resources.Good
        ElseIf Form1.MySetting.MapType = "Better" Then
            MapBetter.Checked = True
            MapPicture.Image = My.Resources.Better
        ElseIf Form1.MySetting.MapType = "Best" Then
            MapBest.Checked = True
            MapPicture.Image = My.Resources.Best
        End If

        SetScreen()

    End Sub

    Private Sub MapHelp_Click(sender As Object, e As EventArgs) Handles MapHelp.Click

        Dim webAddress As String = Form1.gDomain + "/Outworldz_installer/technical.htm#Maps"
        Process.Start(webAddress)

    End Sub

    Private Sub MapNone_CheckedChanged(sender As Object, e As EventArgs) Handles MapNone.CheckedChanged

        Form1.MySetting.MapType = "None"
        Form1.MySetting.SaveSettings()
        MapPicture.Image = My.Resources.blankbox

    End Sub
    Private Sub MapSimple_CheckedChanged(sender As Object, e As EventArgs) Handles MapSimple.CheckedChanged

        Form1.MySetting.MapType = "Simple"
        Form1.MySetting.SaveSettings()
        MapPicture.Image = My.Resources.Simple

    End Sub

    Private Sub MapGood_CheckedChanged(sender As Object, e As EventArgs) Handles MapGood.CheckedChanged

        Form1.MySetting.MapType = "Good"
        Form1.MySetting.SaveSettings()
        MapPicture.Image = My.Resources.Good

    End Sub

    Private Sub MapBetter_CheckedChanged(sender As Object, e As EventArgs) Handles MapBetter.CheckedChanged

        Form1.MySetting.MapType = "Better"
        Form1.MySetting.SaveSettings()
        MapPicture.Image = My.Resources.Better

    End Sub

    Private Sub MapBest_CheckedChanged(sender As Object, e As EventArgs) Handles MapBest.CheckedChanged

        Form1.MySetting.MapType = "Best"
        Form1.MySetting.SaveSettings()
        MapPicture.Image = My.Resources.Best

    End Sub

End Class