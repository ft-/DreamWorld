namespace UPnPPortForwardManager
{
    partial class UPnPMappingDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbEnabled = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtExternalPort = new System.Windows.Forms.TextBox();
            this.txtInternalClient = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInternalPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExternalIPAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbProtocol = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(212, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(131, 227);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbEnabled
            // 
            this.cbEnabled.AutoSize = true;
            this.cbEnabled.Checked = true;
            this.cbEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEnabled.Location = new System.Drawing.Point(116, 185);
            this.cbEnabled.Name = "cbEnabled";
            this.cbEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbEnabled.TabIndex = 7;
            this.cbEnabled.Text = "Enabled";
            this.cbEnabled.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "External Port:";
            // 
            // txtExternalPort
            // 
            this.txtExternalPort.Location = new System.Drawing.Point(117, 64);
            this.txtExternalPort.Name = "txtExternalPort";
            this.txtExternalPort.Size = new System.Drawing.Size(155, 20);
            this.txtExternalPort.TabIndex = 3;
            // 
            // txtInternalClient
            // 
            this.txtInternalClient.Location = new System.Drawing.Point(116, 90);
            this.txtInternalClient.Name = "txtInternalClient";
            this.txtInternalClient.Size = new System.Drawing.Size(156, 20);
            this.txtInternalClient.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Internal Client:";
            // 
            // txtInternalPort
            // 
            this.txtInternalPort.Location = new System.Drawing.Point(116, 116);
            this.txtInternalPort.Name = "txtInternalPort";
            this.txtInternalPort.Size = new System.Drawing.Size(156, 20);
            this.txtInternalPort.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Internal Port:";
            // 
            // txtExternalIPAddress
            // 
            this.txtExternalIPAddress.Location = new System.Drawing.Point(117, 38);
            this.txtExternalIPAddress.Name = "txtExternalIPAddress";
            this.txtExternalIPAddress.Size = new System.Drawing.Size(155, 20);
            this.txtExternalIPAddress.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "External IP Address:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(75, 12);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(197, 20);
            this.txtDescription.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Description:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Protocol:";
            // 
            // cbProtocol
            // 
            this.cbProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProtocol.FormattingEnabled = true;
            this.cbProtocol.Items.AddRange(new object[] {
            "TCP",
            "UDP"});
            this.cbProtocol.Location = new System.Drawing.Point(117, 144);
            this.cbProtocol.Name = "cbProtocol";
            this.cbProtocol.Size = new System.Drawing.Size(155, 21);
            this.cbProtocol.TabIndex = 6;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // UPnPMappingDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(299, 262);
            this.ControlBox = false;
            this.Controls.Add(this.cbProtocol);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtExternalIPAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtInternalPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInternalClient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtExternalPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbEnabled);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.MaximumSize = new System.Drawing.Size(315, 300);
            this.MinimumSize = new System.Drawing.Size(315, 300);
            this.Name = "UPnPMappingDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UPnPMappingDialog";
            this.Load += new System.EventHandler(this.UPnPMappingDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox cbEnabled;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExternalPort;
        private System.Windows.Forms.TextBox txtInternalClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInternalPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExternalIPAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbProtocol;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}