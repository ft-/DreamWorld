Public Class Hyperica
    Private Sub Hyperica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.DNSPublic Then
            CheckBox1.Checked = True
        End If
        If Not My.Settings.DNSPublic Then
            CheckBox1.Checked = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        My.Settings.DNSPublic = True
        My.Settings.Save()
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        My.Settings.DNSPublic = False
        My.Settings.Save()
    End Sub
End Class