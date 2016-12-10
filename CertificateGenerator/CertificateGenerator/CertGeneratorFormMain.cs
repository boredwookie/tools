using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CertificateGenerator.Utility;

namespace CertificateGenerator
{
    public partial class CertGeneratorFormMain : Form
    {
        public CertGeneratorFormMain()
        {
            InitializeComponent();

            // setup Combo boxes
            uxCertTypeCbx.SelectedIndex = 0;
            PopulateHashComboBox();
        }

        private void uxGoBtn_Click(object sender, EventArgs e)
        {
            BeginGenerateCertificates();
        }

        /// <summary>
        /// Kicks off the Certificate Generation process
        /// </summary>
        private void BeginGenerateCertificates()
        {
            // Capture user settings
            string cnPrefix = uxCnPrefixBx.Text;
            int qty = (int)uxQuantityNumBx.Value;
            ContainerType cType = (ContainerType)Enum.Parse(typeof(ContainerType), uxCertTypeCbx.Text);
            HashType hType = (HashType)Enum.Parse(typeof(HashType), uxHashTypeCbx.Text);
            int bitStrength = (int)uxBitStrengthNumBx.Value;
            DateTime validFrom = uxValidFromPicker.Value;
            DateTime validTo = uxValidToPicker.Value;
            string destDir = uxOutputBx.Text;

            string password = uxPwdBx.Text;

            // Kick off GenerateCertificates()
            GenerateCertificates(cnPrefix, qty, cType, hType, bitStrength, validFrom, validTo, destDir, password);

        }
        
        /// <summary>
        /// Utilizes utility methods to create the number of certificates with the specified settings
        /// </summary>
        private void GenerateCertificates(string cnPrefix, int qty, ContainerType cType, HashType hType, int bitStrength, DateTime validFrom, DateTime validTo, string destDir, string password)
        {
            // Determine file extension
            string extension = ".unknown";
            switch (cType){
                case ContainerType.PKCS12:
                    extension = ".pfx";
                    break;
                case ContainerType.DER:
                    extension = ".der";
                    break;
            }

            for (int i = 0; i < qty; i++) {
                string commonName = cnPrefix + i.ToString();
                byte[] cert = Certificate.Generate(commonName, commonName, bitStrength, hType, cType, validFrom, validTo, password);
                Certificate.Save(destDir + @"\" + commonName + "-" + bitStrength + "-" + hType.ToString() + extension, cert);
            }
        }

        /// <summary>
        /// Populate the Hash type checkbox with available hashing types. Set the default selected index
        /// </summary>
        private void PopulateHashComboBox()
        {
            foreach (var type in Enum.GetValues(typeof(HashType))){
                uxHashTypeCbx.Items.Add(type.ToString());
            }

            uxHashTypeCbx.SelectedIndex = 8;
        }

        private void uxCertTypeCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure that the password field only shows up for PKCS12 certificates
            //      Field should be cleared and disabled when it doesn't apply
            if (uxCertTypeCbx.Text == "PKCS12"){
                uxPwdBx.Enabled = true;
            }
            else {
                uxPwdBx.Enabled = false;
                uxPwdBx.Text = string.Empty;
            }
        }

        /// <summary>
        /// Help / About link
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpAboutLinkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://boredwookie.net/index.php/blog/test-tool-certificate-generator/");
        }
    }
}
