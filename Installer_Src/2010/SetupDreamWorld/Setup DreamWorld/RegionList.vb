Public Class RegionList

    Dim writetodisk As Boolean
    Dim TheView As Integer = 0
    Private Shared FormExists As Boolean = False



    ' property exposing FormExists
    Public Shared ReadOnly Property InstanceExists() As Boolean
        Get
            ' Access shared members through the Class name, not an instance.
            Return RegionList.FormExists
        End Get
    End Property


    Private Sub _Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RegionList.FormExists = True

        ' Set the view to show details.
        ListView1.View = View.Details
        ' Allow the user to edit item text.
        ListView1.LabelEdit = True
        ' Allow the user to rearrange columns.
        ListView1.AllowColumnReorder = True
        ' Display check boxes.
        ListView1.CheckBoxes = True
        ' Select the item and subitems when selection is made.
        ListView1.FullRowSelect = True
        ' Display grid lines.
        ListView1.GridLines = True
        ' Sort the items in the list in ascending order.
        ListView1.Sorting = SortOrder.Ascending

        'Add the items to the ListView.
        ' Connect the ListView.ColumnClick event to the ColumnClick event handler.
        AddHandler Me.ListView1.ColumnClick, AddressOf ColumnClick

        ' Me.Controls.Add(ListView1)
        Me.Name = "Region List"
        Me.Text = "Region List"

        LoadMyListView()

        Timer1.Interval = 10000
        Timer1.Start() 'Timer starts functioning

    End Sub
    Private Sub SingletonForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        RegionList.FormExists = False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        LoadMyListView()

    End Sub

    Private Sub LoadMyListView()

        Dim RegionClass As RegionMaker = RegionMaker.Instance

        RegionClass.GetAllRegions()

        writetodisk = False

        ListView1.Clear()
        ListView1.Items.Clear()

        Dim imageListSmall As New ImageList()
        Dim imageListLarge As New ImageList()

        ' Create columns for the items and subitems.
        ' Width of -2 indicates auto-size.
        ListView1.Columns.Add("Enabled", 120, HorizontalAlignment.Center)
        ListView1.Columns.Add("Agents", 60, HorizontalAlignment.Center)
        ListView1.Columns.Add("Status", 60, HorizontalAlignment.Center)

        ' Me.SuspendLayout()

        ' index of 0-4 to display icons
        imageListSmall.Images.Add(My.Resources.ResourceManager.GetObject("navigate_up2"))   ' 0 booting up
        imageListSmall.Images.Add(My.Resources.ResourceManager.GetObject("navigate_down2")) ' 1 shutting down
        imageListSmall.Images.Add(My.Resources.ResourceManager.GetObject("check2")) ' 2 okay, up
        imageListSmall.Images.Add(My.Resources.ResourceManager.GetObject("media_stop_red")) ' 3 disabled
        imageListSmall.Images.Add(My.Resources.ResourceManager.GetObject("media_stop"))  ' 4 enabled


        ' index of 0-4 to display icons
        imageListLarge.Images.Add(My.Resources.ResourceManager.GetObject("navigate_up2"))   ' 0 booting up
        imageListLarge.Images.Add(My.Resources.ResourceManager.GetObject("navigate_down2")) ' 1 shutting down
        imageListLarge.Images.Add(My.Resources.ResourceManager.GetObject("check2")) ' 2 okay, up
        imageListLarge.Images.Add(My.Resources.ResourceManager.GetObject("media_stop_red")) ' 3 disabled
        imageListLarge.Images.Add(My.Resources.ResourceManager.GetObject("media_stop"))  ' 4 enabled

        Dim imageList1 As New ImageList
        Dim Num As Integer
        For Each n As Integer In RegionClass.RegionNumbers
            Application.DoEvents()
            RegionClass.DebugRegions(n)

            ' Create  items and subitems for each item.
            Dim item1 As New ListViewItem(RegionClass.RegionName(n), n)
            ' Place a check mark next to the item.
            item1.Checked = RegionClass.RegionEnabled(n)
            item1.SubItems.Add(RegionClass.AvatarCount(n).ToString)

            Dim Letter As String = ""
            If RegionClass.WarmingUp(n) Then
                Letter = "Booting"
            ElseIf RegionClass.ShuttingDown(n) Then
                Letter = "Shutting Down"
            ElseIf RegionClass.Ready(n) Then
                Letter = "Running"
            ElseIf Not RegionClass.RegionEnabled(n) Then
                Letter = "Disabled"
            ElseIf RegionClass.RegionEnabled(n) Then
                Letter = "Stopped"
            End If

            '=================

            If RegionClass.WarmingUp(n) Then
                Num = 0
            ElseIf RegionClass.ShuttingDown(n) Then
                Num = 1
            ElseIf RegionClass.Ready(n) Then
                Num = 2
            ElseIf Not RegionClass.RegionEnabled(n) Then
                Num = 3
            ElseIf RegionClass.RegionEnabled(n) Then
                Num = 4
            End If

            '-----------------
            item1.SubItems.Add(Letter)
            ListView1.Items.AddRange(New ListViewItem() {item1})
            ListView1.Items(n).ImageIndex = Num

            n = n + 1
        Next


        Dim ctr As Integer = 0
        For Each Item In ListView1.Items
            Dim i As Integer = RegionClass.FindRegionByName(ListView1.Items(ctr).Text)

            If RegionClass.WarmingUp(ctr) Then
                Num = 0
            ElseIf RegionClass.ShuttingDown(ctr) Then
                Num = 1
            ElseIf RegionClass.Ready(ctr) Then
                Num = 2
            ElseIf Not RegionClass.RegionEnabled(ctr) Then
                Num = 3
            ElseIf RegionClass.RegionEnabled(ctr) Then
                Num = 4
            End If
            ListView1.Items(ctr).ImageIndex = Num
            ctr = ctr + 1
            Form1.Sleep(100)
        Next
        '
        'Assign the ImageList objects to the ListView.
        ListView1.LargeImageList = imageListLarge
        ListView1.SmallImageList = imageListSmall

        Me.ListView1.TabIndex = 0
        Me.ListView1.LabelEdit = False
        ' Me.ResumeLayout(True)
        writetodisk = True

    End Sub 'listView1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        LoadMyListView()

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

        Dim RegionClass As RegionMaker = RegionMaker.Instance
        Dim regions As ListView.SelectedListViewItemCollection = Me.ListView1.SelectedItems
        Dim item As ListViewItem

        For Each item In regions
            Dim RegionName = item.SubItems(0).Text
            Debug.Print("Clicked row " + RegionName)
            Dim n As Integer = RegionClass.FindRegionByName(RegionName)
            'If n = Nothing Then Return
            StartStop(n)
        Next

    End Sub
    Private Sub StartStop(n As Integer)

        ' Running, stop it
        Dim RegionClass As RegionMaker = RegionMaker.Instance
        If RegionClass.RegionEnabled(n) And (RegionClass.Ready(n) Or RegionClass.WarmingUp(n)) Then
            ' if enabled and running, even partly up, stop it.
            Try
                Form1.ConsoleCommand(RegionClass.ProcessID(n), "quit{ENTER}")
                Me.Focus()

                RegionClass.Ready(n) = False
                RegionClass.WarmingUp(n) = False
                RegionClass.ShuttingDown(n) = True

                Form1.LoadIni(RegionClass.RegionPath(n), ";")
                Form1.SetIni(RegionClass.RegionName(n), "Enabled", "false")
                Form1.SaveINI()

                Form1.Log("Region:Stopped Region " + RegionClass.RegionName(n))

            Catch ex As Exception
                Form1.Log("Region:Could not stop " + RegionClass.RegionName(n))
            End Try

        ElseIf RegionClass.RegionEnabled(n) And Not (RegionClass.Ready(n) Or RegionClass.WarmingUp(n) Or RegionClass.ShuttingDown(n)) Then
            ' it was stopped, and disabled, so we start up
            If Not Form1.StartMySQL() Then Return
            Form1.Start_Robust()

            Form1.Boot(RegionClass.RegionName(n))
            Debug.Print("Region:Started Region " + RegionClass.RegionName(n))
        Else
            Try
                Dim ActualForm As New FormRegion
                ActualForm.Init(RegionClass.RegionName(n))
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

        Dim RegionClass As RegionMaker = RegionMaker.Instance
        Dim Item As ListViewItem = ListView1.Items.Item(e.Index)
        Dim n As Integer = RegionClass.FindRegionByName(Item.Text)
        'If n = Nothing Then Return
        If writetodisk Then
            If (e.CurrentValue = CheckState.Unchecked) Then
                RegionClass.RegionEnabled(n) = True
                ' and region file on disk
                Form1.LoadIni(RegionClass.RegionPath(n), ";")
                Form1.SetIni(RegionClass.RegionName(n), "Enabled", "true")
                Form1.SaveINI()
                Application.DoEvents()

            ElseIf (e.CurrentValue = CheckState.Checked) Then
                RegionClass.RegionEnabled(n) = False
                ' and region file on disk
                Form1.LoadIni(RegionClass.RegionPath(n), ";")
                Form1.SetIni(RegionClass.RegionName(n), "Enabled", "false")
                Form1.SaveINI()
                Application.DoEvents()

            End If
        End If


    End Sub

    ' ColumnClick event handler.
    Private Sub ColumnClick(ByVal o As Object, ByVal e As ColumnClickEventArgs)
        Me.ListView1.Sorting = SortOrder.None
        ' Set the ListViewItemSorter property to a new ListViewItemComparer 
        ' object. Setting this property immediately sorts the 
        ' ListView using the ListViewItemComparer object.
        Me.ListView1.ListViewItemSorter = New ListViewItemComparer(e.Column)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ViewButton.Click

        If TheView = 0 Then
            ListView1.CheckBoxes = False
            ListView1.View = View.List
            TheView = 1
        ElseIf TheView = 1 Then
            ListView1.View = View.Details
            ListView1.CheckBoxes = True
            TheView = 0
        End If

    End Sub

    Private Sub Addregion_Click(sender As Object, e As EventArgs) Handles Addregion.Click
        Dim X As Integer = 300
        Dim Y As Integer = 200

        Dim RegionClass As RegionMaker = RegionMaker.Instance
        RegionClass.CreateRegion("")
        Dim ActualForm As New FormRegion
        ActualForm.SetDesktopLocation(X, Y)
        ActualForm.Init("Enter a name here")
        ActualForm.Activate()
        ActualForm.Visible = True

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
