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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ViewButton = New System.Windows.Forms.Button()
        Me.RegionHelp = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Addregion = New System.Windows.Forms.Button()
        CType(Me.RegionHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'ListView1
        '
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        ListViewItem1.ToolTipText = "Click to Start or Stop Robust"
        Me.ListView1.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.ListView1.Location = New System.Drawing.Point(12, 42)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.ShowItemToolTips = True
        Me.ListView1.Size = New System.Drawing.Size(261, 316)
        Me.ListView1.TabIndex = 0
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
        Me.ViewButton.Location = New System.Drawing.Point(81, 13)
        Me.ViewButton.Name = "ViewButton"
        Me.ViewButton.Size = New System.Drawing.Size(57, 23)
        Me.ViewButton.TabIndex = 2
        Me.ViewButton.Text = "View"
        Me.ViewButton.UseVisualStyleBackColor = True
        '
        'RegionHelp
        '
        Me.RegionHelp.Image = Global.Outworldz.My.Resources.Resources.about
        Me.RegionHelp.Location = New System.Drawing.Point(234, 9)
        Me.RegionHelp.Name = "RegionHelp"
        Me.RegionHelp.Size = New System.Drawing.Size(28, 27)
        Me.RegionHelp.TabIndex = 1858
        Me.RegionHelp.TabStop = False
        Me.ToolTip1.SetToolTip(Me.RegionHelp, "Click a disabled region to edit it. Click an enabled region to Start or Stop it. " &
        "  ")
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Click an enabled row to start or stop the region.  Click a disabled row to edit t" &
    "he region"
        '
        'Addregion
        '
        Me.Addregion.Location = New System.Drawing.Point(156, 13)
        Me.Addregion.Name = "Addregion"
        Me.Addregion.Size = New System.Drawing.Size(57, 23)
        Me.Addregion.TabIndex = 1859
        Me.Addregion.Text = "Add "
        Me.Addregion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Addregion.UseVisualStyleBackColor = True
        '
        'RegionList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(285, 370)
        Me.Controls.Add(Me.Addregion)
        Me.Controls.Add(Me.RegionHelp)
        Me.Controls.Add(Me.ViewButton)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ListView1)
        Me.MaximizeBox = False
        Me.Name = "RegionList"
        Me.Text = "Region List"
        CType(Me.RegionHelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Timer1 As Timer
    Friend WithEvents ListView1 As ListView
    Friend WithEvents Button1 As Button
    Friend WithEvents ViewButton As Button
    Friend WithEvents RegionHelp As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Addregion As Button
End Class
