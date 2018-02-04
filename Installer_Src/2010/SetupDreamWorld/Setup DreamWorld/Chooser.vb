Public Class Chooser
    Implements IDisposable

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim RegionClass As RegionMaker = RegionMaker.Instance
        Button1.DialogResult = DialogResult.OK
        ListBox1.Items.Clear()


        Dim n As Integer = 0
        For Each X As Integer In RegionClass.RegionNumbers
            If RegionClass.RegionEnabled(n) Then
                ListBox1.Items.Add(RegionClass.RegionName(n))
            End If
            n = n + 1
        Next

        ListBox1.Sorted = True
        ListBox1.Text = "Select from..."

    End Sub

End Class