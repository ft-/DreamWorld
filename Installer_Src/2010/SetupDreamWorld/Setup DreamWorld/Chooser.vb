Public Class Chooser
    Implements IDisposable

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Button1.DialogResult = DialogResult.OK
        ListBox1.Items.Clear()


        For Each n As Integer In Form1.RegionClass.RegionNumbers
            If Form1.RegionClass.RegionEnabled(n) Then
                ListBox1.Items.Add(Form1.RegionClass.RegionName(n))
            End If
        Next

        ListBox1.Sorted = True
        ListBox1.Text = "Select from..."

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.RegionClass.CurRegionNum() = ListBox1.SelectedIndex
    End Sub

End Class