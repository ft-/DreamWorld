Public Class Tides

    Private Sub Loaded(sender As Object, e As EventArgs) Handles Me.Load

        TideEnabledCheckbox.Checked = CType(Form1.MySetting.TideEnabled, Boolean)
        TideHighLevelTextBox.Text = Form1.MySetting.TideHighLevel()
        TideLowLevelTextBox.Text = Form1.MySetting.TideLowLevel()
        CycleTimeTextBox.Text = Form1.MySetting.CycleTime.ToString
        BroadcastTideInfo.Checked = CType(Form1.MySetting.BroadcastTideInfo, Boolean)
        TideInfoChannelTextBox.Text = Form1.MySetting.TideInfoChannel
        TideHiLoChannelTextBox.Text = Form1.MySetting.TideLevelChannel
        TideInfoDebugCheckBox.Checked = Form1.MySetting.TideInfoDebug
    End Sub

    Private Sub TideEnabledCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles TideEnabledCheckbox.CheckedChanged
        Form1.MySetting.TideEnabled = TideEnabledCheckbox.Checked
        Form1.MySetting.SaveOtherINI()
    End Sub

    Private Sub TideHghLevelTextBox_TextChanged(sender As Object, e As EventArgs) Handles TideHighLevelTextBox.TextChanged
        Form1.MySetting.TideHighLevel() = TideHighLevelTextBox.Text
        Form1.MySetting.SaveOtherINI()
    End Sub

    Private Sub TideLowLevelTextBox_TextChanged(sender As Object, e As EventArgs) Handles TideLowLevelTextBox.TextChanged
        Form1.MySetting.TideLowLevel() = TideLowLevelTextBox.Text
        Form1.MySetting.SaveOtherINI()
    End Sub

    Private Sub CycleTimeTextBox_TextChanged(sender As Object, e As EventArgs) Handles CycleTimeTextBox.TextChanged
        Form1.MySetting.CycleTime = CycleTimeTextBox.Text
        Form1.MySetting.SaveOtherINI()
    End Sub

    Private Sub BroadcastTideInfo_CheckedChanged(sender As Object, e As EventArgs) Handles BroadcastTideInfo.CheckedChanged
        Form1.MySetting.BroadcastTideInfo = BroadcastTideInfo.Checked
        Form1.MySetting.SaveOtherINI()
    End Sub

    Private Sub TideInfoChannelTextBox_TextChanged(sender As Object, e As EventArgs) Handles TideInfoChannelTextBox.TextChanged
        Form1.MySetting.TideInfoChannel = TideInfoChannelTextBox.Text
        Form1.MySetting.SaveOtherINI()
    End Sub

    Private Sub TideHiLoChannelTextBox_TextChanged(sender As Object, e As EventArgs) Handles TideHiLoChannelTextBox.TextChanged
        Form1.MySetting.TideLevelChannel = TideHiLoChannelTextBox.Text
        Form1.MySetting.SaveOtherINI()
    End Sub

    Private Sub TideInfoDebugCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles TideInfoDebugCheckBox.CheckedChanged
        Form1.MySetting.TideInfoDebug = TideInfoDebugCheckBox.Checked
        Form1.MySetting.SaveOtherINI()
    End Sub


End Class