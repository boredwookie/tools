namespace BBUltimateBackupParser {
    partial class FormMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.uxCalBkpTxtBx = new System.Windows.Forms.TextBox();
            this.uxSelectCalBkpBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whatDoIDoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uxSaveFileBtn = new System.Windows.Forms.Button();
            this.uxFilteredFileTxtBx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uxDateBoundLower = new System.Windows.Forms.CheckBox();
            this.uxDateBoundLowerDateTime = new System.Windows.Forms.DateTimePicker();
            this.uxDateBoundLowerLbl = new System.Windows.Forms.Label();
            this.uxDateBoundUpperLbl = new System.Windows.Forms.Label();
            this.uxDateBoundUpperDateTime = new System.Windows.Forms.DateTimePicker();
            this.uxDateBoundUpper = new System.Windows.Forms.CheckBox();
            this.uxDateRangeGroupBx = new System.Windows.Forms.GroupBox();
            this.uxGoBtn = new System.Windows.Forms.Button();
            this.uxTextFiltersGroupBx = new System.Windows.Forms.GroupBox();
            this.uxTextFilterCaseSensitiveChkBx = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.uxAddTextFilterBtn = new System.Windows.Forms.Button();
            this.uxTextFilterStringTxtBx = new System.Windows.Forms.TextBox();
            this.uxTextFilterTypeComboBx = new System.Windows.Forms.ComboBox();
            this.uxTextFilterListBx = new System.Windows.Forms.ListBox();
            this.uxTextFilterListBxContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.uxMoreInfoLinkLbl = new System.Windows.Forms.LinkLabel();
            this.menuStrip1.SuspendLayout();
            this.uxDateRangeGroupBx.SuspendLayout();
            this.uxTextFiltersGroupBx.SuspendLayout();
            this.uxTextFilterListBxContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path to Input Zip:";
            // 
            // uxCalBkpTxtBx
            // 
            this.uxCalBkpTxtBx.Location = new System.Drawing.Point(112, 36);
            this.uxCalBkpTxtBx.Name = "uxCalBkpTxtBx";
            this.uxCalBkpTxtBx.ReadOnly = true;
            this.uxCalBkpTxtBx.Size = new System.Drawing.Size(233, 20);
            this.uxCalBkpTxtBx.TabIndex = 1;
            // 
            // uxSelectCalBkpBtn
            // 
            this.uxSelectCalBkpBtn.Location = new System.Drawing.Point(351, 34);
            this.uxSelectCalBkpBtn.Name = "uxSelectCalBkpBtn";
            this.uxSelectCalBkpBtn.Size = new System.Drawing.Size(75, 23);
            this.uxSelectCalBkpBtn.TabIndex = 2;
            this.uxSelectCalBkpBtn.Text = "Select File...";
            this.uxSelectCalBkpBtn.UseVisualStyleBackColor = true;
            this.uxSelectCalBkpBtn.Click += new System.EventHandler(this.uxSelectCalBkpBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(442, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whatDoIDoToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // whatDoIDoToolStripMenuItem
            // 
            this.whatDoIDoToolStripMenuItem.Name = "whatDoIDoToolStripMenuItem";
            this.whatDoIDoToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.whatDoIDoToolStripMenuItem.Text = "What do I do?";
            this.whatDoIDoToolStripMenuItem.Click += new System.EventHandler(this.whatDoIDoToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // uxSaveFileBtn
            // 
            this.uxSaveFileBtn.Location = new System.Drawing.Point(351, 63);
            this.uxSaveFileBtn.Name = "uxSaveFileBtn";
            this.uxSaveFileBtn.Size = new System.Drawing.Size(75, 23);
            this.uxSaveFileBtn.TabIndex = 6;
            this.uxSaveFileBtn.Text = "Select File...";
            this.uxSaveFileBtn.UseVisualStyleBackColor = true;
            this.uxSaveFileBtn.Click += new System.EventHandler(this.uxSaveFileBtn_Click);
            // 
            // uxFilteredFileTxtBx
            // 
            this.uxFilteredFileTxtBx.Location = new System.Drawing.Point(112, 65);
            this.uxFilteredFileTxtBx.Name = "uxFilteredFileTxtBx";
            this.uxFilteredFileTxtBx.ReadOnly = true;
            this.uxFilteredFileTxtBx.Size = new System.Drawing.Size(233, 20);
            this.uxFilteredFileTxtBx.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Output zip file:";
            // 
            // uxDateBoundLower
            // 
            this.uxDateBoundLower.AutoSize = true;
            this.uxDateBoundLower.Location = new System.Drawing.Point(328, 32);
            this.uxDateBoundLower.Name = "uxDateBoundLower";
            this.uxDateBoundLower.Size = new System.Drawing.Size(59, 17);
            this.uxDateBoundLower.TabIndex = 7;
            this.uxDateBoundLower.Text = "Enable";
            this.uxDateBoundLower.UseVisualStyleBackColor = true;
            this.uxDateBoundLower.CheckedChanged += new System.EventHandler(this.uxDateBoundLower_CheckedChanged);
            // 
            // uxDateBoundLowerDateTime
            // 
            this.uxDateBoundLowerDateTime.Enabled = false;
            this.uxDateBoundLowerDateTime.Location = new System.Drawing.Point(122, 30);
            this.uxDateBoundLowerDateTime.Name = "uxDateBoundLowerDateTime";
            this.uxDateBoundLowerDateTime.Size = new System.Drawing.Size(200, 20);
            this.uxDateBoundLowerDateTime.TabIndex = 8;
            // 
            // uxDateBoundLowerLbl
            // 
            this.uxDateBoundLowerLbl.AutoSize = true;
            this.uxDateBoundLowerLbl.Enabled = false;
            this.uxDateBoundLowerLbl.Location = new System.Drawing.Point(19, 33);
            this.uxDateBoundLowerLbl.Name = "uxDateBoundLowerLbl";
            this.uxDateBoundLowerLbl.Size = new System.Drawing.Size(99, 13);
            this.uxDateBoundLowerLbl.TabIndex = 9;
            this.uxDateBoundLowerLbl.Text = "Created on or After:";
            // 
            // uxDateBoundUpperLbl
            // 
            this.uxDateBoundUpperLbl.AutoSize = true;
            this.uxDateBoundUpperLbl.Enabled = false;
            this.uxDateBoundUpperLbl.Location = new System.Drawing.Point(10, 59);
            this.uxDateBoundUpperLbl.Name = "uxDateBoundUpperLbl";
            this.uxDateBoundUpperLbl.Size = new System.Drawing.Size(108, 13);
            this.uxDateBoundUpperLbl.TabIndex = 12;
            this.uxDateBoundUpperLbl.Text = "Created on or Before:";
            // 
            // uxDateBoundUpperDateTime
            // 
            this.uxDateBoundUpperDateTime.Enabled = false;
            this.uxDateBoundUpperDateTime.Location = new System.Drawing.Point(122, 56);
            this.uxDateBoundUpperDateTime.Name = "uxDateBoundUpperDateTime";
            this.uxDateBoundUpperDateTime.Size = new System.Drawing.Size(200, 20);
            this.uxDateBoundUpperDateTime.TabIndex = 11;
            // 
            // uxDateBoundUpper
            // 
            this.uxDateBoundUpper.AutoSize = true;
            this.uxDateBoundUpper.Location = new System.Drawing.Point(328, 58);
            this.uxDateBoundUpper.Name = "uxDateBoundUpper";
            this.uxDateBoundUpper.Size = new System.Drawing.Size(59, 17);
            this.uxDateBoundUpper.TabIndex = 10;
            this.uxDateBoundUpper.Text = "Enable";
            this.uxDateBoundUpper.UseVisualStyleBackColor = true;
            this.uxDateBoundUpper.CheckedChanged += new System.EventHandler(this.uxDateBoundUpper_CheckedChanged);
            // 
            // uxDateRangeGroupBx
            // 
            this.uxDateRangeGroupBx.Controls.Add(this.uxDateBoundLowerDateTime);
            this.uxDateRangeGroupBx.Controls.Add(this.uxDateBoundUpperLbl);
            this.uxDateRangeGroupBx.Controls.Add(this.uxDateBoundLower);
            this.uxDateRangeGroupBx.Controls.Add(this.uxDateBoundUpperDateTime);
            this.uxDateRangeGroupBx.Controls.Add(this.uxDateBoundLowerLbl);
            this.uxDateRangeGroupBx.Controls.Add(this.uxDateBoundUpper);
            this.uxDateRangeGroupBx.Location = new System.Drawing.Point(15, 120);
            this.uxDateRangeGroupBx.Name = "uxDateRangeGroupBx";
            this.uxDateRangeGroupBx.Size = new System.Drawing.Size(411, 100);
            this.uxDateRangeGroupBx.TabIndex = 13;
            this.uxDateRangeGroupBx.TabStop = false;
            this.uxDateRangeGroupBx.Text = "Date Range Filters";
            // 
            // uxGoBtn
            // 
            this.uxGoBtn.Location = new System.Drawing.Point(351, 416);
            this.uxGoBtn.Name = "uxGoBtn";
            this.uxGoBtn.Size = new System.Drawing.Size(75, 23);
            this.uxGoBtn.TabIndex = 14;
            this.uxGoBtn.Text = "Go";
            this.uxGoBtn.UseVisualStyleBackColor = true;
            this.uxGoBtn.Click += new System.EventHandler(this.uxGoBtn_Click);
            // 
            // uxTextFiltersGroupBx
            // 
            this.uxTextFiltersGroupBx.Controls.Add(this.uxTextFilterCaseSensitiveChkBx);
            this.uxTextFiltersGroupBx.Controls.Add(this.label6);
            this.uxTextFiltersGroupBx.Controls.Add(this.label5);
            this.uxTextFiltersGroupBx.Controls.Add(this.uxAddTextFilterBtn);
            this.uxTextFiltersGroupBx.Controls.Add(this.uxTextFilterStringTxtBx);
            this.uxTextFiltersGroupBx.Controls.Add(this.uxTextFilterTypeComboBx);
            this.uxTextFiltersGroupBx.Controls.Add(this.uxTextFilterListBx);
            this.uxTextFiltersGroupBx.Location = new System.Drawing.Point(15, 226);
            this.uxTextFiltersGroupBx.Name = "uxTextFiltersGroupBx";
            this.uxTextFiltersGroupBx.Size = new System.Drawing.Size(411, 184);
            this.uxTextFiltersGroupBx.TabIndex = 15;
            this.uxTextFiltersGroupBx.TabStop = false;
            this.uxTextFiltersGroupBx.Text = "Subject / Description Filters";
            // 
            // uxTextFilterCaseSensitiveChkBx
            // 
            this.uxTextFilterCaseSensitiveChkBx.AutoSize = true;
            this.uxTextFilterCaseSensitiveChkBx.Location = new System.Drawing.Point(53, 130);
            this.uxTextFilterCaseSensitiveChkBx.Name = "uxTextFilterCaseSensitiveChkBx";
            this.uxTextFilterCaseSensitiveChkBx.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.uxTextFilterCaseSensitiveChkBx.Size = new System.Drawing.Size(96, 17);
            this.uxTextFilterCaseSensitiveChkBx.TabIndex = 6;
            this.uxTextFilterCaseSensitiveChkBx.Text = "Case Sensitive";
            this.uxTextFilterCaseSensitiveChkBx.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Filter Value";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Filter Type";
            // 
            // uxAddTextFilterBtn
            // 
            this.uxAddTextFilterBtn.Location = new System.Drawing.Point(74, 153);
            this.uxAddTextFilterBtn.Name = "uxAddTextFilterBtn";
            this.uxAddTextFilterBtn.Size = new System.Drawing.Size(75, 23);
            this.uxAddTextFilterBtn.TabIndex = 3;
            this.uxAddTextFilterBtn.Text = "Add Filter";
            this.uxAddTextFilterBtn.UseVisualStyleBackColor = true;
            this.uxAddTextFilterBtn.Click += new System.EventHandler(this.uxAddTextFilterBtn_Click);
            // 
            // uxTextFilterStringTxtBx
            // 
            this.uxTextFilterStringTxtBx.Location = new System.Drawing.Point(13, 82);
            this.uxTextFilterStringTxtBx.Multiline = true;
            this.uxTextFilterStringTxtBx.Name = "uxTextFilterStringTxtBx";
            this.uxTextFilterStringTxtBx.Size = new System.Drawing.Size(136, 42);
            this.uxTextFilterStringTxtBx.TabIndex = 2;
            // 
            // uxTextFilterTypeComboBx
            // 
            this.uxTextFilterTypeComboBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxTextFilterTypeComboBx.FormattingEnabled = true;
            this.uxTextFilterTypeComboBx.Items.AddRange(new object[] {
            "Subject Equals",
            "Subject Contains",
            "Description Equals",
            "Description Contains"});
            this.uxTextFilterTypeComboBx.Location = new System.Drawing.Point(13, 35);
            this.uxTextFilterTypeComboBx.Name = "uxTextFilterTypeComboBx";
            this.uxTextFilterTypeComboBx.Size = new System.Drawing.Size(136, 21);
            this.uxTextFilterTypeComboBx.TabIndex = 1;
            // 
            // uxTextFilterListBx
            // 
            this.uxTextFilterListBx.FormattingEnabled = true;
            this.uxTextFilterListBx.Location = new System.Drawing.Point(173, 8);
            this.uxTextFilterListBx.Name = "uxTextFilterListBx";
            this.uxTextFilterListBx.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.uxTextFilterListBx.Size = new System.Drawing.Size(232, 173);
            this.uxTextFilterListBx.TabIndex = 0;
            this.uxTextFilterListBx.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uxTextFilterListBx_MouseDown);
            this.uxTextFilterListBx.MouseUp += new System.Windows.Forms.MouseEventHandler(this.uxTextFilterListBx_MouseUp);
            // 
            // uxTextFilterListBxContextMenu
            // 
            this.uxTextFilterListBxContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modifyToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.uxTextFilterListBxContextMenu.Name = "uxTextFilterListBxContextMenu";
            this.uxTextFilterListBxContextMenu.Size = new System.Drawing.Size(107, 48);
            // 
            // modifyToolStripMenuItem
            // 
            this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
            this.modifyToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.modifyToolStripMenuItem.Text = "Modify";
            this.modifyToolStripMenuItem.Click += new System.EventHandler(this.modifyToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(429, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Note: The Output Zip file name **HAS** to start with Calendar_, so I prepend it i" +
    "f you don\'t";
            // 
            // uxMoreInfoLinkLbl
            // 
            this.uxMoreInfoLinkLbl.AutoSize = true;
            this.uxMoreInfoLinkLbl.Location = new System.Drawing.Point(12, 421);
            this.uxMoreInfoLinkLbl.Name = "uxMoreInfoLinkLbl";
            this.uxMoreInfoLinkLbl.Size = new System.Drawing.Size(117, 13);
            this.uxMoreInfoLinkLbl.TabIndex = 17;
            this.uxMoreInfoLinkLbl.TabStop = true;
            this.uxMoreInfoLinkLbl.Text = "boredwookie.net - Help";
            this.uxMoreInfoLinkLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.uxMoreInfoLinkLbl_LinkClicked);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 448);
            this.Controls.Add(this.uxMoreInfoLinkLbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uxTextFiltersGroupBx);
            this.Controls.Add(this.uxGoBtn);
            this.Controls.Add(this.uxDateRangeGroupBx);
            this.Controls.Add(this.uxSaveFileBtn);
            this.Controls.Add(this.uxFilteredFileTxtBx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uxSelectCalBkpBtn);
            this.Controls.Add(this.uxCalBkpTxtBx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "BB Ultimate Backup Calendar Parser";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.uxDateRangeGroupBx.ResumeLayout(false);
            this.uxDateRangeGroupBx.PerformLayout();
            this.uxTextFiltersGroupBx.ResumeLayout(false);
            this.uxTextFiltersGroupBx.PerformLayout();
            this.uxTextFilterListBxContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uxCalBkpTxtBx;
        private System.Windows.Forms.Button uxSelectCalBkpBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whatDoIDoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button uxSaveFileBtn;
        private System.Windows.Forms.TextBox uxFilteredFileTxtBx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox uxDateBoundLower;
        private System.Windows.Forms.DateTimePicker uxDateBoundLowerDateTime;
        private System.Windows.Forms.Label uxDateBoundLowerLbl;
        private System.Windows.Forms.Label uxDateBoundUpperLbl;
        private System.Windows.Forms.DateTimePicker uxDateBoundUpperDateTime;
        private System.Windows.Forms.CheckBox uxDateBoundUpper;
        private System.Windows.Forms.GroupBox uxDateRangeGroupBx;
        private System.Windows.Forms.Button uxGoBtn;
        private System.Windows.Forms.GroupBox uxTextFiltersGroupBx;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button uxAddTextFilterBtn;
        private System.Windows.Forms.TextBox uxTextFilterStringTxtBx;
        private System.Windows.Forms.ComboBox uxTextFilterTypeComboBx;
        private System.Windows.Forms.ListBox uxTextFilterListBx;
        private System.Windows.Forms.CheckBox uxTextFilterCaseSensitiveChkBx;
        private System.Windows.Forms.ContextMenuStrip uxTextFilterListBxContextMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel uxMoreInfoLinkLbl;
    }
}

