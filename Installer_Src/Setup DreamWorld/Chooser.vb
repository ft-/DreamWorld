Public Class Choice
    Implements IDisposable

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Set the column header style.
        Dim columnHeaderStyle As New DataGridViewCellStyle
        columnHeaderStyle.Font = New Font("Verdana", 10, FontStyle.Bold)
        DataGridView.ColumnHeadersDefaultCellStyle = columnHeaderStyle

        DataGridView.Text = "Select from..."

    End Sub

    Public Sub FillGrid(type As String, Optional JustRunning As Boolean = False)

        Dim RegionClass As RegionMaker = RegionMaker.Instance(Form1.MysqlConn)

        Dim L As New List(Of String)

        ' add to list Unique Name

        For Each X As Integer In RegionClass.RegionNumbers
            Dim name As String
            If type = "Group" Then
                name = RegionClass.GroupName(X)
            Else
                name = RegionClass.RegionName(X)
            End If

            ' Only show running sims option
            If (JustRunning And RegionClass.Booted(X)) Then
                If L.Contains(name) Then
                Else
                    If name <> "" Then DataGridView.Rows.Add(name)
                End If
            ElseIf Not JustRunning Then
                If L.Contains(name) Then
                Else
                    If name <> "" Then DataGridView.Rows.Add(name)
                End If
            End If

            L.Add(name)
        Next

        L.Sort()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim selectedRowCount = DataGridView.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 1 Then
            MsgBox("Please select only one row", vbInformation, "Oops")
        End If
        If selectedRowCount = 1 Then
            DialogResult = DialogResult.OK
        End If
    End Sub


End Class