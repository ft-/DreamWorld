<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RegionList
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Robust", 0)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RegionList))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ViewButton = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Addregion = New System.Windows.Forms.Button()
        Me.AllNome = New System.Windows.Forms.CheckBox()
        Me.RegionHelp = New System.Windows.Forms.PictureBox()
        Me.RunAllButton = New System.Windows.Forms.Button()
        Me.StopAllButton = New System.Windows.Forms.Button()
        Me.RestartButton = New System.Windows.Forms.Button()
        CType(Me.RegionHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'ListView1
        '
        Me.ListView1.AllowColumnReorder = True
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        ListViewItem1.ToolTipText = "Click to Start or Stop Robust"
        Me.ListView1.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.ListView1.Location = New System.Drawing.Point(12, 66)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.ShowItemToolTips = True
        Me.ListView1.Size = New System.Drawing.Size(461, 316)
        Me.ListView1.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.ListView1, "Regions may start/stop in groups, depending upon how your bin\Regions folder is o" &
        "rganized.")
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(13, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(53, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Refresh"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ViewButton
        '
        Me.ViewButton.Location = New System.Drawing.Point(72, 14)
        Me.ViewButton.Name = "ViewButton"
        Me.ViewButton.Size = New System.Drawing.Size(57, 23)
        Me.ViewButton.TabIndex = 2
        Me.ViewButton.Text = "View"
        Me.ViewButton.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Click an enabled row to start or stop the region.  Click a disabled row to edit t" &
    "he region"
        '
        'Addregion
        '
        Me.Addregion.Location = New System.Drawing.Point(135, 13)
        Me.Addregion.Name = "Addregion"
        Me.Addregion.Size = New System.Drawing.Size(57, 23)
        Me.Addregion.TabIndex = 18593
        Me.Addregion.Text = "Add "
        Me.Addregion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Addregion.UseVisualStyleBackColor = True
        '
        'AllNome
        '
        Me.AllNome.AutoSize = True
        Me.AllNome.Location = New System.Drawing.Point(22, 43)
        Me.AllNome.Name = "AllNome"
        Me.AllNome.Size = New System.Drawing.Size(68, 17)
        Me.AllNome.TabIndex = 4
        Me.AllNome.Text = "All/None"
        Me.AllNome.UseVisualStyleBackColor = True
        '
        'RegionHelp
        '
        Me.RegionHelp.Image = Global.Outworldz.My.Resources.Resources.about
        Me.RegionHelp.Location = New System.Drawing.Point(387, 13)
        Me.RegionHelp.Name = "RegionHelp"
        Me.RegionHelp.Size = New System.Drawing.Size(28, 27)
        Me.RegionHelp.TabIndex = 1858
        Me.RegionHelp.TabStop = False
        '
        'RunAllButton
        '
        Me.RunAllButton.Location = New System.Drawing.Point(198, 13)
        Me.RunAllButton.Name = "RunAllButton"
        Me.RunAllButton.Size = New System.Drawing.Size(57, 23)
        Me.RunAllButton.TabIndex = 18594
        Me.RunAllButton.Text = "Run All"
        Me.RunAllButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.RunAllButton.UseVisualStyleBackColor = True
        '
        'StopAllButton
        '
        Me.StopAllButton.Location = New System.Drawing.Point(261, 12)
        Me.StopAllButton.Name = "StopAllButton"
        Me.StopAllButton.Size = New System.Drawing.Size(57, 23)
        Me.StopAllButton.TabIndex = 18595
        Me.StopAllButton.Text = "Stop All"
        Me.StopAllButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.StopAllButton.UseVisualStyleBackColor = True
        '
        'RestartButton
        '
        Me.RestartButton.Location = New System.Drawing.Point(324, 13)
        Me.RestartButton.Name = "RestartButton"
        Me.RestartButton.Size = New System.Drawing.Size(57, 23)
        Me.RestartButton.TabIndex = 18596
        Me.RestartButton.Text = "Restart All"
        Me.RestartButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.RestartButton.UseVisualStyleBackColor = True
        '
        'RegionList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(484, 361)
        Me.Controls.Add(Me.RestartButton)
        Me.Controls.Add(Me.StopAllButton)
        Me.Controls.Add(Me.RunAllButton)
        Me.Controls.Add(Me.AllNome)
        Me.Controls.Add(Me.Addregion)
        Me.Controls.Add(Me.RegionHelp)
        Me.Controls.Add(Me.ViewButton)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ListView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "RegionList"
        Me.Text = "Region List"
        CType(Me.RegionHelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Timer1 As Timer
    Friend WithEvents ListView1 As ListView
    Friend WithEvents Button1 As Button
    Friend WithEvents ViewButton As Button
    Friend WithEvents RegionHelp As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Addregion As Button
    Friend WithEvents AllNome As CheckBox
    Friend WithEvents RunAllButton As Button
    Friend WithEvents StopAllButton As Button
    Friend WithEvents RestartButton As Button
End Class
