Public Class RegionTreeView

    'https://msdn.microsoft.com/en-us/library/system.windows.forms.treeview(v=vs.110).aspx

    ' Populates a TreeView control with example nodes. 
    Private Sub InitializeTreeView()
        TreeView1.BeginUpdate()
        TreeView1.Nodes.Add("Parent")
        TreeView1.Nodes(0).Nodes.Add("Child 1")
        TreeView1.Nodes(0).Nodes.Add("Child 2")
        TreeView1.Nodes(0).Nodes(1).Nodes.Add("Grandchild")
        TreeView1.Nodes(0).Nodes(1).Nodes(0).Nodes.Add("Great Grandchild")
        TreeView1.EndUpdate()
    End Sub

End Class