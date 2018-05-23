Public Class Chooser

    Dim OpensimID As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        ListBox1.Items.Clear()

        Dim counter As Integer = 1
        While counter <= Form1.aRegion.GetUpperBound(0)
            ListBox1.Items.Add(Form1.aRegion(counter).RegionName)
            counter += 1
        End While

        ListBox1.Sorted = True
        ListBox1.Text = "Select from..."

        Me.Focus()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.DialogResult = DialogResult.OK
    End Sub
End Class