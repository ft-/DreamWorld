<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDNSName
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDNSName))
        Me.DNSNameBox = New System.Windows.Forms.TextBox()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.NextNameButton = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.TestButton1 = New System.Windows.Forms.Button()
        Me.EnableHypergrid = New System.Windows.Forms.CheckBox()
        Me.DynDNSPassword = New System.Windows.Forms.PictureBox()
        Me.UniqueId = New System.Windows.Forms.TextBox()
        Me.SuitcaseCheckbox = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DynDNSPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DNSNameBox
        '
        Me.DNSNameBox.Location = New System.Drawing.Point(24, 135)
        Me.DNSNameBox.Name = "DNSNameBox"
        Me.DNSNameBox.Size = New System.Drawing.Size(253, 20)
        Me.DNSNameBox.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.DNSNameBox, "Alpha-Numeric plus - ( no spaces or special chars)")
        '
        'SaveButton
        '
        Me.SaveButton.Location = New System.Drawing.Point(213, 167)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(64, 23)
        Me.SaveButton.TabIndex = 3
        Me.SaveButton.Text = "Save"
        Me.ToolTip1.SetToolTip(Me.SaveButton, "Save DNS name")
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'NextNameButton
        '
        Me.NextNameButton.Location = New System.Drawing.Point(24, 167)
        Me.NextNameButton.Name = "NextNameButton"
        Me.NextNameButton.Size = New System.Drawing.Size(78, 23)
        Me.NextNameButton.TabIndex = 2
        Me.NextNameButton.Text = "Next Name"
        Me.ToolTip1.SetToolTip(Me.NextNameButton, "Get a free DYN DNS Name")
        Me.NextNameButton.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipTitle = "If marked Public, this sim will be published to an online directory so others peo" &
    "pkle on the hypergrid can find it."
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.Outworldz.My.Resources.Resources.about
        Me.PictureBox4.Location = New System.Drawing.Point(287, 123)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(28, 32)
        Me.PictureBox4.TabIndex = 1859
        Me.PictureBox4.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox4, "Click for Help on DNS Names")
        '
        'TestButton1
        '
        Me.TestButton1.Location = New System.Drawing.Point(120, 167)
        Me.TestButton1.Name = "TestButton1"
        Me.TestButton1.Size = New System.Drawing.Size(75, 23)
        Me.TestButton1.TabIndex = 1860
        Me.TestButton1.Text = "Test DNS"
        Me.ToolTip1.SetToolTip(Me.TestButton1, "test DNS and return IP address")
        Me.TestButton1.UseVisualStyleBackColor = True
        '
        'EnableHypergrid
        '
        Me.EnableHypergrid.AutoSize = True
        Me.EnableHypergrid.Location = New System.Drawing.Point(12, 23)
        Me.EnableHypergrid.Name = "EnableHypergrid"
        Me.EnableHypergrid.Size = New System.Drawing.Size(107, 17)
        Me.EnableHypergrid.TabIndex = 1863
        Me.EnableHypergrid.Text = "Enable Hypergrid"
        Me.ToolTip1.SetToolTip(Me.EnableHypergrid, "Enables Hypergrid to all sims.")
        Me.EnableHypergrid.UseVisualStyleBackColor = True
        '
        'DynDNSPassword
        '
        Me.DynDNSPassword.Image = Global.Outworldz.My.Resources.Resources.about
        Me.DynDNSPassword.Location = New System.Drawing.Point(227, 61)
        Me.DynDNSPassword.Name = "DynDNSPassword"
        Me.DynDNSPassword.Size = New System.Drawing.Size(30, 34)
        Me.DynDNSPassword.TabIndex = 1864
        Me.DynDNSPassword.TabStop = False
        Me.ToolTip1.SetToolTip(Me.DynDNSPassword, "This ID reserves your DYNDNS name. ")
        '
        'UniqueId
        '
        Me.UniqueId.Location = New System.Drawing.Point(120, 91)
        Me.UniqueId.Name = "UniqueId"
        Me.UniqueId.Size = New System.Drawing.Size(101, 20)
        Me.UniqueId.TabIndex = 1865
        Me.ToolTip1.SetToolTip(Me.UniqueId, "Reserves your DYN DNS name, this is like a password to your name.")
        '
        'SuitcaseCheckbox
        '
        Me.SuitcaseCheckbox.AutoSize = True
        Me.SuitcaseCheckbox.Location = New System.Drawing.Point(12, 46)
        Me.SuitcaseCheckbox.Name = "SuitcaseCheckbox"
        Me.SuitcaseCheckbox.Size = New System.Drawing.Size(150, 17)
        Me.SuitcaseCheckbox.TabIndex = 1867
        Me.SuitcaseCheckbox.Text = "Enable Inventory Suitcase"
        Me.ToolTip1.SetToolTip(Me.SuitcaseCheckbox, "Disbale the suitcase is less secure but easier to travel with")
        Me.SuitcaseCheckbox.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 1866
        Me.Label1.Text = "DynDns password"
        '
        'FormDNSName
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(327, 235)
        Me.Controls.Add(Me.SuitcaseCheckbox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.EnableHypergrid)
        Me.Controls.Add(Me.DynDNSPassword)
        Me.Controls.Add(Me.UniqueId)
        Me.Controls.Add(Me.TestButton1)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.NextNameButton)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.DNSNameBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FormDNSName"
        Me.Text = "DNS Name"
        Me.ToolTip1.SetToolTip(Me, "Get Help")
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DynDNSPassword, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DNSNameBox As TextBox
    Friend WithEvents SaveButton As Button
    Friend WithEvents NextNameButton As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents TestButton1 As Button
    Friend WithEvents EnableHypergrid As CheckBox
    Friend WithEvents DynDNSPassword As PictureBox
    Friend WithEvents UniqueId As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents SuitcaseCheckbox As CheckBox
End Class
