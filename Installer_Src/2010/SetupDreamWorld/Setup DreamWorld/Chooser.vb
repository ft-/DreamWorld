Public Class Chooser
    Implements IDisposable

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Button1.DialogResult = DialogResult.OK
        ListBox1.Items.Clear()

        'Dim regions = New List(Of Object)
        'regions = Form1.RegionClass.RegionList
        'regions = Form1.RegionClass.RegionList.OrderBy(Function(x) x.RegionName).ToList()

        For Each o In Form1.RegionClass.RegionList
            If o.RegionEnabled Then
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