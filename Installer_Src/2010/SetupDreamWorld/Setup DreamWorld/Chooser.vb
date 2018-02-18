Public Class Choice
    Implements IDisposable

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Set the column header style.
        Dim columnHeaderStyle As New DataGridViewCellStyle
        columnHeaderStyle.Font = New Font("Verdana", 10, FontStyle.Bold)
        DataGridView.ColumnHeadersDefaultCellStyle = columnHeaderStyle

        DataGridView.Text = "Select from..."

    End Sub

    Public Sub FillGrid(type As String)

        Dim RegionClass As RegionMaker = RegionMaker.Instance

        Dim L As New List(Of String)

        ' add to list Unique Name
        Dim n As Integer = 0
        For Each X As Integer In RegionClass.RegionNumbers
            Dim name As String
            If type = "Group" Then
                name = RegionClass.GroupName(n)
            Else
                name = RegionClass.RegionName(n)
            End If

            If L.Contains(name) Then
            Else
                If name <> "" Then DataGridView.Rows.Add(name)
            End If

            L.Add(name)

            n = n + 1
        Next


    End Sub

    Private Sub DataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView.CellContentClick
        DialogResult = vbOK
    End Sub
End Class