Imports System.Diagnostics.Debug
Imports System.Net
Imports System.Security.Principal
Imports System.Text.RegularExpressions

Public Class FormRestart

    Dim initted As Boolean = False

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

        AutoRestartBox.Text = Form1.MySetting.AutoRestartInterval.ToString
        AutoStartCheckbox.Checked = Form1.MySetting.Autostart
        BootStart.Checked = Form1.MySetting.BootStart
        SetScreen()
        Form1.HelpOnce("Restart")
        initted = True ' suppress the install of the startup on formload
    End Sub

#Region "AutoStart"

    Private Sub AutoStartCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles AutoStartCheckbox.CheckedChanged

        If Not initted Then Return
        Form1.MySetting.Autostart = AutoStartCheckbox.Checked
        Form1.MySetting.SaveSettings()

    End Sub

    Private Sub RunOnBoot_Click_1(sender As Object, e As EventArgs) Handles RunOnBoot.Click

        Form1.Help("Restart")

    End Sub


    Private Sub BootStart_CheckedChanged(sender As Object, e As EventArgs) Handles BootStart.CheckedChanged

        If Not initted Then Return

        Form1.MySetting.BootStart = BootStart.Checked
        Dim ProcessTask As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.WindowStyle = ProcessWindowStyle.Normal
        pi.FileName = "schtasks.exe"
        If IsUserAdministrator() Then
            If BootStart.Checked Then
                pi.Arguments = "/Create /TN DreamGrid /SC ONSTART /TR " & """" + Form1.MyFolder & "\Start.exe" + """"

                ProcessTask.StartInfo = pi
                Try
                    ProcessTask.Start()
                    AutoStartCheckbox.Checked = True
                    Form1.MySetting.Autostart = True
                    Form1.MySetting.SaveSettings()
                Catch ex As Exception
                    Form1.Log("Error:Scheduled Task failed to launch:" + ex.Message)
                End Try
            Else
                pi.Arguments = "/Delete /TN DreamGrid"
                ProcessTask.StartInfo = pi
                Try
                    ProcessTask.Start()
                Catch ex As Exception
                    Form1.Log("Error:Scheduled Task Delete failed:" + ex.Message)
                End Try

            End If

        Else
            MsgBox("DreamGrid must be started in Administrator mode to setup a scheduled task. Right click the icon and select Run As Administrator.", vbInformation, "Escalation Needed")
            BootStart.Checked = False
        End If

    End Sub

    Private Function IsUserAdministrator() As Boolean

        Dim isAdmin As Boolean
        Try
            Dim user As WindowsIdentity = WindowsIdentity.GetCurrent()
            Dim principal As WindowsPrincipal = New WindowsPrincipal(user)
            isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator)

        Catch ex As Exception
            isAdmin = False
        End Try
        Return isAdmin

    End Function

    Private Sub AutoRestartBox_TextChanged(sender As Object, e As EventArgs) Handles AutoRestartBox.TextChanged

        Dim digitsOnly As Regex = New Regex("[^\d]")
        AutoRestartBox.Text = digitsOnly.Replace(AutoRestartBox.Text, "")
        If initted Then
            Try
                Form1.MySetting.AutoRestartInterval = Convert.ToInt16(AutoRestartBox.Text)
                Form1.MySetting.SaveSettings()
            Catch
            End Try
        End If

    End Sub




#End Region



End Class