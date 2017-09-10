Public Class Chooser
    Implements IDisposable

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Button1.DialogResult = DialogResult.OK
        ListBox1.Items.Clear()

        Dim oldID = Form1.RegionClass.RegionNum
        Dim counter As Integer = 1
        While counter <= Form1.RegionClass.Count
            Form1.RegionClass.RegionNum = counter
            ListBox1.Items.Add(Form1.RegionClass.RegionName)
            counter += 1
        End While

        ListBox1.Sorted = True
        ListBox1.Text = "Select from..."
        Form1.RegionClass.RegionNum = oldID

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Form1.RegionClass.RegionNum = ListBox1.SelectedIndex
        My.Settings.WelcomeRegion = ListBox1.SelectedIndex
    End Sub
End Class