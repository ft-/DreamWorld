using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UPnPPortForwardManager
{
    public partial class UPnPMappingDialog : Form
    {
        public UPnPMappingDialog()
        {
            InitializeComponent();
        }

        private void UPnPMappingDialog_Load(object sender, EventArgs e)
        {
            UpdateFieldsForMappingEditMode();

            this.Validating += new CancelEventHandler(UPnPMappingDialog_Validating);
            this.txtDescription.Validating += new CancelEventHandler(UPnPMappingDialog_Validating);
            this.txtExternalPort.Validating+= new CancelEventHandler(UPnPMappingDialog_Validating);
            this.txtInternalClient.Validating+= new CancelEventHandler(UPnPMappingDialog_Validating);
            this.txtInternalPort.Validating += new CancelEventHandler(UPnPMappingDialog_Validating);
        }

        private bool ErrorsClean = true;
        void UPnPMappingDialog_Validating(object sender, CancelEventArgs e)
        {
            ErrorsClean = true;
            errorProvider1.Clear();
            ProcessTextBoxValidation(txtDescription);
            ProcessTextBoxValidation(txtExternalPort);
            ProcessTextBoxValidation(txtInternalClient);
            ProcessTextBoxValidation(txtInternalPort);
        }

        void ProcessTextBoxValidation(TextBox txt)
        {
            if (string.IsNullOrEmpty(txt.Text))
            {
                errorProvider1.SetError(txt, "Value is Required.");
                ErrorsClean = false;
            }
        }

        private bool _MappingEditMode = false;
        /// <summary>
        /// When set to False the dialog is being used for Adding a new Mapping, when set to True its used to edit an existing Mapping
        /// </summary>
        public bool MappingEditMode
        {
            get
            {
                return _MappingEditMode;
            }
            set
            {
                _MappingEditMode = value;
                UpdateFieldsForMappingEditMode();
            }
        }

        private void UpdateFieldsForMappingEditMode()
        {
            txtExternalIPAddress.Enabled = false;
            
            txtExternalPort.Enabled = !this.MappingEditMode;
            cbProtocol.Enabled = !this.MappingEditMode;

        }

        public string MappingDescription
        {
            get
            {
                return txtDescription.Text;
            }
            set
            {
                txtDescription.Text = value;
            }
        }

        public string MappingExternalIPAddress
        {
            get
            {
                return txtExternalIPAddress.Text;
            }
            set
            {
                txtExternalIPAddress.Text = value;
            }
        }

        public int MappingExternalPort
        {
            get
            {
                return int.Parse(txtExternalPort.Text);
            }
            set
            {
                txtExternalPort.Text = value.ToString();
            }
        }

        public string MappingInternalClient
        {
            get
            {
                return txtInternalClient.Text;
            }
            set
            {
                txtInternalClient.Text = value;
            }
        }

        public int MappingInternalPort
        {
            get
            {
                return int.Parse(txtInternalPort.Text);
            }
            set
            {
                txtInternalPort.Text = value.ToString();
            }
        }

        public bool MappingEnabled
        {
            get
            {
                return cbEnabled.Checked;
            }
            set
            {
                cbEnabled.Checked = value;
            }
        }

        public string MappingProtocol
        {
            get
            {
                return cbProtocol.Text;
            }
            set
            {
                cbProtocol.Text = value;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ErrorsClean)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
