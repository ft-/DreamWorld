Imports System.Text.RegularExpressions

Public Class FormPersonality

    Dim Sleepy As Integer = 1500
    Dim Awake As Integer = 1000
    Dim Coffee As Integer = 500
    Dim Toomuch As Integer = 0

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

        Dim Chattime = Form1.MySetting.ChatTime

        If Chattime = Sleepy Then
            ChatSpeed.SelectedIndex = 0
        ElseIf Chattime = Awake Then
            ChatSpeed.SelectedIndex = 1
        ElseIf Chattime = Coffee Then
            ChatSpeed.SelectedIndex = 2
        Else
            ChatSpeed.SelectedIndex = 3
        End If

        TimerInterval.Text = Str(Form1.MySetting.TimerInterval)

        SetScreen()

    End Sub

    Private Sub ChatSpeed_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ChatSpeed.SelectedIndexChanged
        Dim text = ChatSpeed.SelectedItem.ToString()
        Dim ChatTime As Integer = 1500

        If text = "Sleepy" Then ChatTime = 1500
        If text = "Awake" Then ChatTime = 1000
        If text = "After Coffee" Then ChatTime = 500
        If text = "Too much Coffee" Then ChatTime = 0

        Form1.MySetting.ChatTime = ChatTime
        Form1.MySetting.SaveSettings()
        Form1.gChatTime = ChatTime
    End Sub


    Private Sub TimerInterval_TextChanged(sender As Object, e As EventArgs) Handles TimerInterval.TextChanged

        Dim digitsOnly As Regex = New Regex("[^\d]")
        TimerInterval.Text = digitsOnly.Replace(TimerInterval.Text, "")
        Try
            If Len(TimerInterval.Text) > 0 Then

                Form1.MySetting.TimerInterval = CInt(TimerInterval.Text)
                If (Form1.MySetting.TimerInterval > 0) Then
                    Form1.PaintImage()
                Else
                    Form1.PictureBox1.Visible = False
                End If
            Else
                Form1.PictureBox1.Visible = False
                Form1.MySetting.TimerInterval = 0
                Form1.MySetting.SaveSettings()
            End If
        Catch
        End Try

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PersonalityHelp.Click
        Dim webAddress As String = Form1.gDomain + "/Outworldz_installer/technical.htm#Personality"
        Process.Start(webAddress)
    End Sub

End Class