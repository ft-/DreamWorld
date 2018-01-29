Public Class RegionList

    Dim writetodisk As Boolean
    Dim TheView As Boolean = True

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Set the view to show details.
        ListView1.View = View.Details
        ' Allow the user to edit item text.
        listView1.LabelEdit = True
        ' Allow the user to rearrange columns.
        listView1.AllowColumnReorder = True
        ' Display check boxes.
        listView1.CheckBoxes = True
        ' Select the item and subitems when selection is made.
        listView1.FullRowSelect = True
        ' Display grid lines.
        listView1.GridLines = True
        ' Sort the items in the list in ascending order.
        listView1.Sorting = SortOrder.Ascending

        'Add the items to the ListView.
        ' Connect the ListView.ColumnClick event to the ColumnClick event handler.
        AddHandler Me.ListView1.ColumnClick, AddressOf ColumnClick

        Me.Controls.Add(ListView1)
        Me.Name = "Region List"
        Me.Text = "Region List"


        LoadMyListView()


        Timer1.Interval = 60000
        Timer1.Start() 'Timer starts functioning

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        LoadMyListView()

    End Sub

    Private Sub LoadMyListView()

        writetodisk = False

        ListView1.Clear()
        Dim imageListSmall As New ImageList()
        ' Create columns for the items and subitems.
        ' Width of -2 indicates auto-size.
        ListView1.Columns.Add("Enabled", 120, HorizontalAlignment.Center)
        ListView1.Columns.Add("Status", 60, HorizontalAlignment.Center)
        ListView1.Columns.Add("Agents", 60, HorizontalAlignment.Center)


        Dim Rlist = Form1.RegionClass.AllRegionObjects
        Dim o As Object
        Dim i As Integer = 0

        Me.SuspendLayout()

        For Each o In Rlist
            ' Create  items and subitems for each item.
            Dim item1 As New ListViewItem(o.RegionName.ToString, 0)

            'Debug.Print(o.RegionName)
            'Debug.Print(" WarmingUp=" + o.WarmingUp.ToString)
            'Debug.Print(" ShuttingDown=" + o.ShuttingDown.ToString)
            'Debug.Print(" Ready=" + o.Ready.ToString)
            'Debug.Print(" RegionEnabled=" + o.RegionEnabled.ToString)

            ' Place a check mark next to the item.
            item1.Checked = o.RegionEnabled


            Dim Letter As String = "X"
            If (o.RegionName = "Isis") Then
                Debug.Print("Isis")
            End If
            Dim SImage As String = "question_and_answer"
            If o.WarmingUp Then
                SImage = "refresh"
                Letter = "Booting"
            ElseIf o.ShuttingDown Then
                SImage = "flash"
                Letter = "Shutting Down"
            ElseIf o.Ready Then
                SImage = "media_play_green"
                Letter = "Running"
            ElseIf Not o.RegionEnabled And Not o.Ready Then
                SImage = "media_stop_red"
                Letter = "Disabled"
            ElseIf o.RegionEnabled And Not o.Ready Then
                Letter = "Stopped"
                SImage = "media_pause"
            End If

            item1.SubItems.Add(Letter)

            ListView1.Items.AddRange(New ListViewItem() {item1})
            item1.SubItems.Add(o.AvatarCount.ToString)

            ' imageListSmall.Images.Add(My.Resources.ResourceManager.GetObject(SImage))
            'ListView1.Items(i).ImageIndex = i
            i = i + 1

        Next
        ListView1.SmallImageList = imageListSmall
        Me.ListView1.TabIndex = 0
        Me.ListView1.LabelEdit = False
        Me.ResumeLayout(True)
        writetodisk = True

    End Sub 'listView1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        LoadMyListView()

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

        Dim regions As ListView.SelectedListViewItemCollection = Me.ListView1.SelectedItems
        Dim item As ListViewItem

        For Each item In regions
            Dim RegionName = item.SubItems(0).Text
            Debug.Print("Clicked row" + RegionName)
            Dim o = Form1.RegionClass.FindRegionByName(RegionName)
            If o Is Nothing Then Return
            StartStop(o)
        Next

    End Sub
    Private Sub StartStop(ByVal o As Object)

        ' Running, stop it
        If o.RegionEnabled And (o.Ready Or o.WarmingUp) Then
            ' if enabled and running, even partly up, stop it.
            Try
                Form1.ConsoleCommand(o.ProcessID, "quit{ENTER}")
                Me.Focus()

                o.Ready = False
                o.WarmingUp = False
                o.ShuttingDown = True

                Form1.LoadIni(o.RegionPath, ";")
                Form1.SetIni(o.RegionName, "Enabled", "false")
                Form1.SaveINI()

                Form1.Log("Region:Stopped Region " + o.RegionName)
            Catch ex As Exception
                Form1.Log("Region:Could not stop " + o.RegionName)
            End Try

        ElseIf o.RegionEnabled And Not (o.Ready Or o.WarmingUp Or o.ShuttingDown) Then
            ' it was stopped, and disabled, so we start up
            If Not Form1.StartMySQL() Then Return
            Form1.Start_Robust()

            Form1.Boot(o)
            Debug.Print("Region:Started Region " + o.RegionName)
        Else
            Try
                Dim ActualForm As New FormRegion
                ActualForm.Init(o)
                ActualForm.Activate()
                ActualForm.Visible = True
            Catch ex As Exception
                Form1.Log("Info:" + ex.Message)
            End Try
        End If

    End Sub

    ' Handles the ItemChecked event. The method uses the CurrentValue property 
    ' of the ItemCheckEventArgs to retrieve and tally the price of the menu 
    ' items selected.  
    Private Sub ListView1_ItemCheck1(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListView1.ItemCheck

        Dim Item As ListViewItem = ListView1.Items.Item(e.Index)
        Dim o = Form1.RegionClass.FindRegionByName(Item.Text)
        If o Is Nothing Then Return
        If writetodisk Then
            If (e.CurrentValue = CheckState.Unchecked) Then
                o.RegionEnabled = True
                ' and region file on disk
                Form1.LoadIni(o.RegionPath, ";")
                Form1.SetIni(o.RegionName, "Enabled", "true")
                Form1.SaveINI()
                LoadMyListView()
            ElseIf (e.CurrentValue = CheckState.Checked) Then
                o.RegionEnabled = False
                ' and region file on disk
                Form1.LoadIni(o.RegionPath, ";")
                Form1.SetIni(o.RegionName, "Enabled", "false")
                Form1.SaveINI()
                LoadMyListView()
            End If
        End If

        'Form1.RegionClass.WriteRegionObject()

    End Sub

    ' ColumnClick event handler.
    Private Sub ColumnClick(ByVal o As Object, ByVal e As ColumnClickEventArgs)
        Me.ListView1.Sorting = SortOrder.None
        ' Set the ListViewItemSorter property to a new ListViewItemComparer 
        ' object. Setting this property immediately sorts the 
        ' ListView using the ListViewItemComparer object.
        Me.ListView1.ListViewItemSorter = New ListViewItemComparer(e.Column)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If TheView Then
            ListView1.CheckBoxes = False
            ListView1.View = View.List
            TheView = False
        Else
            ListView1.View = View.Details
            ListView1.CheckBoxes = True
            TheView = True
        End If

    End Sub

End Class

' Implements the manual sorting of items by columns.
Class ListViewItemComparer
    Implements IComparer
    Private col As Integer

    Public Sub New()
        col = 0
    End Sub

    Public Sub New(ByVal column As Integer)
        col = column
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare

        Return [String].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)

    End Function
End Class
