/*  By http://pietschsoft.com/post/2009/02/05/NET-Framework-Communicate-through-NAT-Router-via-UPnP */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace UPnPPortForwardManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbPortMappings.DoubleClick += new EventHandler(lbPortMappings_DoubleClick);

            RefreshPortMappings();
        }

        void lbPortMappings_DoubleClick(object sender, EventArgs e)
        {
            // Double clicking on a Static Port Mapping in the list will open up the Edit Dialog.
            btnEdit_Click(sender, e);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshPortMappings();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UPnPMappingDialog dialog = new UPnPMappingDialog();

            dialog.MappingInternalClient = NetworkHelper.LocalIPAddress;
            dialog.MappingProtocol = "TCP";
            dialog.MappingEditMode = false;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                UPnPNATHelper.Add(dialog.MappingExternalPort, dialog.MappingProtocol, dialog.MappingInternalPort, dialog.MappingInternalClient, dialog.MappingEnabled, dialog.MappingDescription);
                RefreshPortMappings();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbPortMappings.SelectedItem != null)
            {
                NATUPNPLib.IStaticPortMapping p = ((NATUPnPListBoxItem)lbPortMappings.SelectedItem).Mapping;

                UPnPMappingDialog dialog = new UPnPMappingDialog();
                
                dialog.MappingDescription = p.Description;
                dialog.MappingEnabled = p.Enabled;
                dialog.MappingExternalIPAddress = p.ExternalIPAddress;
                dialog.MappingExternalPort = p.ExternalPort;
                dialog.MappingInternalClient = p.InternalClient;
                dialog.MappingInternalPort = p.InternalPort;
                dialog.MappingProtocol = p.Protocol;
                dialog.MappingEditMode = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    p.EditDescription(dialog.MappingDescription);
                    p.Enable(dialog.MappingEnabled);
                    p.EditInternalClient(dialog.MappingInternalClient);
                    p.EditInternalPort(dialog.MappingInternalPort);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (NATUPnPListBoxItem p in lbPortMappings.SelectedItems)
            {
                UPnPNATHelper.Remove(p.Mapping.ExternalPort, p.Mapping.Protocol);
            }
            RefreshPortMappings();
        }

        void RefreshPortMappings()
        {
            lbPortMappings.Items.Clear();

            try
            {
                foreach (NATUPNPLib.IStaticPortMapping p in UPnPNATHelper.StaticPortMappings)
                {
                    lbPortMappings.Items.Add(new NATUPnPListBoxItem(p));
                }
            } 
            catch
            {
                MessageBox.Show("UPnp is not supported on this router with this program");
                Application.Exit();

            }

        }

        private void lbPortMappings_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public class NATUPnPListBoxItem
    {
        public NATUPnPListBoxItem(NATUPNPLib.IStaticPortMapping mapping)
        {
            this.Mapping = mapping;
        }

        public NATUPNPLib.IStaticPortMapping Mapping { get; set; }

        public override string ToString()
        {
            return this.Mapping.Description;
        }
    }
}
