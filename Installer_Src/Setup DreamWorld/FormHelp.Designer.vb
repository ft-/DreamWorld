<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormHelp
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.WebSiteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HomeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DreamgridToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TechnicalInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TroubleshootingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StepbyStepInstallationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatabaseHelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PortsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoopbackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SourceCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.WebSiteToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(433, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(12, 20)
        '
        'WebSiteToolStripMenuItem
        '
        Me.WebSiteToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HomeToolStripMenuItem, Me.DreamgridToolStripMenuItem, Me.TechnicalInfoToolStripMenuItem, Me.TroubleshootingToolStripMenuItem, Me.StepbyStepInstallationToolStripMenuItem, Me.DatabaseHelpToolStripMenuItem, Me.PortsToolStripMenuItem, Me.LoopbackToolStripMenuItem, Me.SourceCodeToolStripMenuItem})
        Me.WebSiteToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.about
        Me.WebSiteToolStripMenuItem.Name = "WebSiteToolStripMenuItem"
        Me.WebSiteToolStripMenuItem.Size = New System.Drawing.Size(248, 20)
        Me.WebSiteToolStripMenuItem.Text = "For More Help on the Website, click this."
        '
        'HomeToolStripMenuItem
        '
        Me.HomeToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.about
        Me.HomeToolStripMenuItem.Name = "HomeToolStripMenuItem"
        Me.HomeToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.HomeToolStripMenuItem.Text = "www.Outworldz.com"
        '
        'DreamgridToolStripMenuItem
        '
        Me.DreamgridToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.cube_blue
        Me.DreamgridToolStripMenuItem.Name = "DreamgridToolStripMenuItem"
        Me.DreamgridToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.DreamgridToolStripMenuItem.Text = "Dreamgrid Home"
        '
        'TechnicalInfoToolStripMenuItem
        '
        Me.TechnicalInfoToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.gear
        Me.TechnicalInfoToolStripMenuItem.Name = "TechnicalInfoToolStripMenuItem"
        Me.TechnicalInfoToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.TechnicalInfoToolStripMenuItem.Text = "Technical Info"
        '
        'TroubleshootingToolStripMenuItem
        '
        Me.TroubleshootingToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.gear_run
        Me.TroubleshootingToolStripMenuItem.Name = "TroubleshootingToolStripMenuItem"
        Me.TroubleshootingToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.TroubleshootingToolStripMenuItem.Text = "Troubleshooting"
        '
        'StepbyStepInstallationToolStripMenuItem
        '
        Me.StepbyStepInstallationToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.document_connection
        Me.StepbyStepInstallationToolStripMenuItem.Name = "StepbyStepInstallationToolStripMenuItem"
        Me.StepbyStepInstallationToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.StepbyStepInstallationToolStripMenuItem.Text = "Starting up the first time"
        '
        'DatabaseHelpToolStripMenuItem
        '
        Me.DatabaseHelpToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.data
        Me.DatabaseHelpToolStripMenuItem.Name = "DatabaseHelpToolStripMenuItem"
        Me.DatabaseHelpToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.DatabaseHelpToolStripMenuItem.Text = "Database Help"
        '
        'PortsToolStripMenuItem
        '
        Me.PortsToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.earth_network
        Me.PortsToolStripMenuItem.Name = "PortsToolStripMenuItem"
        Me.PortsToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.PortsToolStripMenuItem.Text = "Port Forwarding Help"
        '
        'LoopbackToolStripMenuItem
        '
        Me.LoopbackToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.replace2
        Me.LoopbackToolStripMenuItem.Name = "LoopbackToolStripMenuItem"
        Me.LoopbackToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.LoopbackToolStripMenuItem.Text = "Loopback Help"
        '
        'SourceCodeToolStripMenuItem
        '
        Me.SourceCodeToolStripMenuItem.Image = Global.Outworldz.My.Resources.Resources.transform
        Me.SourceCodeToolStripMenuItem.Name = "SourceCodeToolStripMenuItem"
        Me.SourceCodeToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.SourceCodeToolStripMenuItem.Text = "Source Code"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.SystemColors.MenuBar
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Location = New System.Drawing.Point(0, 24)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(433, 449)
        Me.RichTextBox1.TabIndex = 1
        Me.RichTextBox1.Text = ""
        '
        'FormHelp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 473)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormHelp"
        Me.Text = "Help"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents WebSiteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HomeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DreamgridToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TechnicalInfoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TroubleshootingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StepbyStepInstallationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PortsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoopbackToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DatabaseHelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SourceCodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RichTextBox1 As RichTextBox
End Class
