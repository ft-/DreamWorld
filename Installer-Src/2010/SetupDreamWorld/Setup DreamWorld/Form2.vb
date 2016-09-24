Public Class AdvancedForm
    Friend WithEvents Label1 As Label
    Public Property Form2 As Object

    Private Sub Loaded(sender As Object, e As EventArgs) Handles Me.Load

        If My.Settings.SizeX = "256" And My.Settings.SizeY = "256" Then
            CheckBox256.Checked = True
            CheckBox512.Checked = False
            CheckBox1024.Checked = False
            SizeX.Text = ""
            SizeY.Text = ""

        ElseIf My.Settings.SizeX = "512" And My.Settings.SizeY = "512" Then
            CheckBox256.Checked = False
            CheckBox512.Checked = True
            CheckBox1024.Checked = False
            SizeX.Text = ""
            SizeY.Text = ""
        ElseIf My.Settings.SizeX = "1024" And My.Settings.SizeY = "1024" Then
            CheckBox256.Checked = False
            CheckBox512.Checked = False
            CheckBox1024.Checked = True
            SizeX.Text = ""
            SizeY.Text = ""
        Else
            SizeX.Text = My.Settings.SizeX
            SizeY.Text = My.Settings.SizeY
        End If

        PublicPort.Text = My.Settings.PublicPort
        PrivatePort.Text = My.Settings.PrivatePort
        WifiPort.Text = My.Settings.WifiPort
    End Sub

    Private Sub CheckBox256_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox256.CheckedChanged
        If CheckBox256.Checked = True Then
            CheckBox512.Checked = False
            CheckBox1024.Checked = False
            My.Settings.SizeX = "256"
            My.Settings.SizeY = "256"
            SizeX.Text = ""
            SizeY.Text = ""
            My.Settings.Save()
        End If

    End Sub

    Private Sub CheckBox512_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox512.CheckedChanged
        If CheckBox512.Checked = True Then
            CheckBox256.Checked = False
            CheckBox1024.Checked = False
            My.Settings.SizeX = "512"
            My.Settings.SizeY = "512"
            SizeX.Text = ""
            SizeY.Text = ""
            My.Settings.Save()
        End If
    End Sub

    Private Sub CheckBox1024_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1024.CheckedChanged
        If CheckBox1024.Checked = True Then
            CheckBox256.Checked = False
            CheckBox512.Checked = False
            My.Settings.SizeX = "1024"
            My.Settings.SizeX = "1024"
            SizeX.Text = ""
            SizeY.Text = ""
            My.Settings.Save()
        End If
    End Sub

    Private Sub SizeX_TextChanged(sender As Object, e As EventArgs) Handles SizeX.TextChanged
        If SizeX.Text <> "" Then
            CheckBox256.Checked = False
            CheckBox512.Checked = False
            CheckBox1024.Checked = False
            My.Settings.SizeX = SizeX.Text
            My.Settings.Save()
        End If

    End Sub

    Private Sub SizeY_TextChanged(sender As Object, e As EventArgs) Handles SizeY.TextChanged
        If SizeY.Text <> "" Then
            CheckBox256.Checked = False
            CheckBox512.Checked = False
            CheckBox1024.Checked = False
            My.Settings.SizeY = SizeY.Text
            My.Settings.Save()
        End If
    End Sub

    Private Sub X_TextChanged(sender As Object, e As EventArgs) Handles SizeX.TextChanged
        My.Settings.CoordX = SizeX.Text
        CheckBox256.Checked = False
        CheckBox512.Checked = False
        CheckBox1024.Checked = False
        My.Settings.Save()
    End Sub

    Private Sub Y_TextChanged(sender As Object, e As EventArgs) Handles SizeY.TextChanged
        My.Settings.CoordY = SizeY.Text
        CheckBox256.Checked = False
        CheckBox512.Checked = False
        CheckBox1024.Checked = False
        My.Settings.Save()
    End Sub
    Private Sub PrivatePort_TextChanged(sender As Object, e As EventArgs) Handles PrivatePort.TextChanged
        My.Settings.PrivatePort = PrivatePort.Text
        My.Settings.Save()
    End Sub

    Private Sub PublicPort_TextChanged(sender As Object, e As EventArgs) Handles PublicPort.TextChanged
        My.Settings.PublicPort = PublicPort.Text
        My.Settings.Save()
    End Sub
    Private Sub Form2_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        Form1.ActualForm = Nothing

    End Sub

End Class