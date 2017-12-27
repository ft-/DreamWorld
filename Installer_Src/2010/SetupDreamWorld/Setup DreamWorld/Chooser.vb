Public Class Chooser
    Implements IDisposable

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Button1.DialogResult = DialogResult.OK
        ListBox1.Items.Clear()

        For Each o In Form1.RegionClass.AllRegionObjects()
            If o.RegionEnabled And o.Ready Then
                ListBox1.Items.Add(o.RegionName)
            End If
        Next

        ListBox1.Sorted = True
        ListBox1.Text = "Select from..."

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Form1.RegionClass.CurRegionNum() = ListBox1.SelectedIndex
    End Sub

End Class