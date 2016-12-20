namespace BB_Password_Keeper_to_KeePass
{
    partial class BB_PK_to_KP_FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BB_PK_to_KP_FormMain));
            this.selectCsvBtn = new System.Windows.Forms.Button();
            this.csvPathBx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.migrateBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.keePassOutputBx = new System.Windows.Forms.TextBox();
            this.outputFileSelectBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.helpAboutLinkLbl = new System.Windows.Forms.LinkLabel();
            this.finishedLbl = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectCsvBtn
            // 
            this.selectCsvBtn.Location = new System.Drawing.Point(336, 161);
            this.selectCsvBtn.Name = "selectCsvBtn";
            this.selectCsvBtn.Size = new System.Drawing.Size(86, 23);
            this.selectCsvBtn.TabIndex = 0;
            this.selectCsvBtn.Text = "Input Select";
            this.selectCsvBtn.UseVisualStyleBackColor = true;
            this.selectCsvBtn.Click += new System.EventHandler(this.selectCsvBtn_Click);
            // 
            // csvPathBx
            // 
            this.csvPathBx.Location = new System.Drawing.Point(127, 163);
            this.csvPathBx.Name = "csvPathBx";
            this.csvPathBx.Size = new System.Drawing.Size(203, 20);
            this.csvPathBx.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 117);
            this.label1.TabIndex = 2;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password Keeper file:";
            // 
            // migrateBtn
            // 
            this.migrateBtn.Location = new System.Drawing.Point(347, 242);
            this.migrateBtn.Name = "migrateBtn";
            this.migrateBtn.Size = new System.Drawing.Size(75, 23);
            this.migrateBtn.TabIndex = 4;
            this.migrateBtn.Text = "Migrate";
            this.migrateBtn.UseVisualStyleBackColor = true;
            this.migrateBtn.Click += new System.EventHandler(this.migrateBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 142);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Directions";
            // 
            // keePassOutputBx
            // 
            this.keePassOutputBx.Location = new System.Drawing.Point(127, 192);
            this.keePassOutputBx.Name = "keePassOutputBx";
            this.keePassOutputBx.Size = new System.Drawing.Size(203, 20);
            this.keePassOutputBx.TabIndex = 7;
            // 
            // outputFileSelectBtn
            // 
            this.outputFileSelectBtn.Location = new System.Drawing.Point(336, 190);
            this.outputFileSelectBtn.Name = "outputFileSelectBtn";
            this.outputFileSelectBtn.Size = new System.Drawing.Size(86, 23);
            this.outputFileSelectBtn.TabIndex = 6;
            this.outputFileSelectBtn.Text = "Output Select";
            this.outputFileSelectBtn.UseVisualStyleBackColor = true;
            this.outputFileSelectBtn.Click += new System.EventHandler(this.outputFileSelectBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "KeePass output file:";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 306);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(407, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 23;
            this.progressBar.Visible = false;
            // 
            // helpAboutLinkLbl
            // 
            this.helpAboutLinkLbl.AutoSize = true;
            this.helpAboutLinkLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.helpAboutLinkLbl.Location = new System.Drawing.Point(12, 281);
            this.helpAboutLinkLbl.Name = "helpAboutLinkLbl";
            this.helpAboutLinkLbl.Size = new System.Drawing.Size(85, 17);
            this.helpAboutLinkLbl.TabIndex = 24;
            this.helpAboutLinkLbl.TabStop = true;
            this.helpAboutLinkLbl.Text = "Help / about";
            this.helpAboutLinkLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.helpAboutLinkLbl_LinkClicked);
            // 
            // finishedLbl
            // 
            this.finishedLbl.AutoSize = true;
            this.finishedLbl.Location = new System.Drawing.Point(180, 311);
            this.finishedLbl.Name = "finishedLbl";
            this.finishedLbl.Size = new System.Drawing.Size(49, 13);
            this.finishedLbl.TabIndex = 25;
            this.finishedLbl.Text = "Finished!";
            this.finishedLbl.Visible = false;
            this.finishedLbl.Click += new System.EventHandler(this.label4_Click);
            // 
            // BB_PK_to_KP_FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 341);
            this.Controls.Add(this.finishedLbl);
            this.Controls.Add(this.helpAboutLinkLbl);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.keePassOutputBx);
            this.Controls.Add(this.outputFileSelectBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.migrateBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.csvPathBx);
            this.Controls.Add(this.selectCsvBtn);
            this.Name = "BB_PK_to_KP_FormMain";
            this.Text = "BB to KeePass Converter";
            this.Load += new System.EventHandler(this.BB_to_KP_FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectCsvBtn;
        private System.Windows.Forms.TextBox csvPathBx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button migrateBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox keePassOutputBx;
        private System.Windows.Forms.Button outputFileSelectBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.LinkLabel helpAboutLinkLbl;
        private System.Windows.Forms.Label finishedLbl;
    }
}

