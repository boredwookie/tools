using System;
using System.IO;
using System.Windows.Forms;

namespace BB_Password_Keeper_to_KeePass
{
    public partial class BB_PK_to_KP_FormMain : Form
    {
        public BB_PK_to_KP_FormMain()
        {
            InitializeComponent();
        }

        private void BB_to_KP_FormMain_Load(object sender, EventArgs e)
        {

        }

        private void selectCsvBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog csvSelector = new OpenFileDialog();
            csvSelector.Title = "Select the Password Keeper CSV file";
            csvSelector.InitialDirectory = @"c:\";

            if (csvSelector.ShowDialog() == DialogResult.OK)
            {
                csvPathBx.Text = csvSelector.FileName;

                string pathToCsvInput = Path.GetDirectoryName(csvSelector.FileName);
                string outputCsvFileName = pathToCsvInput + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(csvSelector.FileName) + "_keepass.csv";
                keePassOutputBx.Text = outputCsvFileName;
            }
        }

        private void helpAboutLinkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://boredwookie.net/2016-12-19-bb-password-keeper-to-keepass-tool");
        }

        private void outputFileSelectBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog keepassSaveFileDialog = new SaveFileDialog();
            keepassSaveFileDialog.Title = "Select where to save your migrated KeePass CSV file";
            keepassSaveFileDialog.InitialDirectory = @"c:\";

            string pathToCsvInput = Path.GetDirectoryName(csvPathBx.Text);
            keepassSaveFileDialog.FileName = pathToCsvInput + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(csvPathBx.Text) + "_keepass.csv";

            if(keepassSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                keePassOutputBx.Text = keepassSaveFileDialog.FileName;
            }
        }

        private void migrateBtn_Click(object sender, EventArgs e)
        {
            // Make the progress bar visible:
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.Visible = true;

            KeePassMigrator migrator = new KeePassMigrator();
            migrator.PkInputFile = csvPathBx.Text;
            migrator.KpOutputFile = keePassOutputBx.Text;
            migrator.Migrate();

            progressBar.Visible = false;
            finishedLbl.Visible = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
