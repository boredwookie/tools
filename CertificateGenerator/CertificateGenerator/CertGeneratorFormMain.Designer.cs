namespace CertificateGenerator
{
    partial class CertGeneratorFormMain
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
            this.uxCertTypeCbx = new System.Windows.Forms.ComboBox();
            this.uxCertTypeLbl = new System.Windows.Forms.Label();
            this.uxCnPrefixLbl = new System.Windows.Forms.Label();
            this.uxCnPrefixBx = new System.Windows.Forms.TextBox();
            this.uxBitStrengthLbl = new System.Windows.Forms.Label();
            this.uxHashTypeLbl = new System.Windows.Forms.Label();
            this.uxValidFromLbl = new System.Windows.Forms.Label();
            this.uxHashTypeCbx = new System.Windows.Forms.ComboBox();
            this.uxBitStrengthNumBx = new System.Windows.Forms.NumericUpDown();
            this.uxValidToLbl = new System.Windows.Forms.Label();
            this.uxValidFromPicker = new System.Windows.Forms.DateTimePicker();
            this.uxValidToPicker = new System.Windows.Forms.DateTimePicker();
            this.uxOutputLbl = new System.Windows.Forms.Label();
            this.uxOutputBx = new System.Windows.Forms.TextBox();
            this.uxGoBtn = new System.Windows.Forms.Button();
            this.uxQuantityLbl = new System.Windows.Forms.Label();
            this.uxQuantityNumBx = new System.Windows.Forms.NumericUpDown();
            this.uxPwdBx = new System.Windows.Forms.TextBox();
            this.uxPwdLbl = new System.Windows.Forms.Label();
            this.helpAboutLinkLbl = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.uxBitStrengthNumBx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxQuantityNumBx)).BeginInit();
            this.SuspendLayout();
            // 
            // uxCertTypeCbx
            // 
            this.uxCertTypeCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxCertTypeCbx.FormattingEnabled = true;
            this.uxCertTypeCbx.Items.AddRange(new object[] {
            "PKCS12",
            "DER"});
            this.uxCertTypeCbx.Location = new System.Drawing.Point(130, 89);
            this.uxCertTypeCbx.Name = "uxCertTypeCbx";
            this.uxCertTypeCbx.Size = new System.Drawing.Size(121, 21);
            this.uxCertTypeCbx.TabIndex = 0;
            this.uxCertTypeCbx.SelectedIndexChanged += new System.EventHandler(this.uxCertTypeCbx_SelectedIndexChanged);
            // 
            // uxCertTypeLbl
            // 
            this.uxCertTypeLbl.AutoSize = true;
            this.uxCertTypeLbl.Location = new System.Drawing.Point(36, 92);
            this.uxCertTypeLbl.Name = "uxCertTypeLbl";
            this.uxCertTypeLbl.Size = new System.Drawing.Size(84, 13);
            this.uxCertTypeLbl.TabIndex = 1;
            this.uxCertTypeLbl.Text = "Certificate Type:";
            // 
            // uxCnPrefixLbl
            // 
            this.uxCnPrefixLbl.AutoSize = true;
            this.uxCnPrefixLbl.Location = new System.Drawing.Point(9, 16);
            this.uxCnPrefixLbl.Name = "uxCnPrefixLbl";
            this.uxCnPrefixLbl.Size = new System.Drawing.Size(111, 13);
            this.uxCnPrefixLbl.TabIndex = 2;
            this.uxCnPrefixLbl.Text = "Common Name Prefix:";
            // 
            // uxCnPrefixBx
            // 
            this.uxCnPrefixBx.Location = new System.Drawing.Point(129, 13);
            this.uxCnPrefixBx.Name = "uxCnPrefixBx";
            this.uxCnPrefixBx.Size = new System.Drawing.Size(121, 20);
            this.uxCnPrefixBx.TabIndex = 3;
            this.uxCnPrefixBx.Text = "certPrefix";
            // 
            // uxBitStrengthLbl
            // 
            this.uxBitStrengthLbl.AutoSize = true;
            this.uxBitStrengthLbl.Location = new System.Drawing.Point(55, 158);
            this.uxBitStrengthLbl.Name = "uxBitStrengthLbl";
            this.uxBitStrengthLbl.Size = new System.Drawing.Size(65, 13);
            this.uxBitStrengthLbl.TabIndex = 4;
            this.uxBitStrengthLbl.Text = "Bit Strength:";
            // 
            // uxHashTypeLbl
            // 
            this.uxHashTypeLbl.AutoSize = true;
            this.uxHashTypeLbl.Location = new System.Drawing.Point(58, 190);
            this.uxHashTypeLbl.Name = "uxHashTypeLbl";
            this.uxHashTypeLbl.Size = new System.Drawing.Size(62, 13);
            this.uxHashTypeLbl.TabIndex = 5;
            this.uxHashTypeLbl.Text = "Hash Type:";
            // 
            // uxValidFromLbl
            // 
            this.uxValidFromLbl.AutoSize = true;
            this.uxValidFromLbl.Location = new System.Drawing.Point(61, 220);
            this.uxValidFromLbl.Name = "uxValidFromLbl";
            this.uxValidFromLbl.Size = new System.Drawing.Size(59, 13);
            this.uxValidFromLbl.TabIndex = 6;
            this.uxValidFromLbl.Text = "Valid From:";
            // 
            // uxHashTypeCbx
            // 
            this.uxHashTypeCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxHashTypeCbx.FormattingEnabled = true;
            this.uxHashTypeCbx.Location = new System.Drawing.Point(129, 187);
            this.uxHashTypeCbx.Name = "uxHashTypeCbx";
            this.uxHashTypeCbx.Size = new System.Drawing.Size(121, 21);
            this.uxHashTypeCbx.TabIndex = 7;
            // 
            // uxBitStrengthNumBx
            // 
            this.uxBitStrengthNumBx.Location = new System.Drawing.Point(130, 156);
            this.uxBitStrengthNumBx.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.uxBitStrengthNumBx.Minimum = new decimal(new int[] {
            361,
            0,
            0,
            0});
            this.uxBitStrengthNumBx.Name = "uxBitStrengthNumBx";
            this.uxBitStrengthNumBx.Size = new System.Drawing.Size(120, 20);
            this.uxBitStrengthNumBx.TabIndex = 8;
            this.uxBitStrengthNumBx.Value = new decimal(new int[] {
            2047,
            0,
            0,
            0});
            // 
            // uxValidToLbl
            // 
            this.uxValidToLbl.AutoSize = true;
            this.uxValidToLbl.Location = new System.Drawing.Point(71, 246);
            this.uxValidToLbl.Name = "uxValidToLbl";
            this.uxValidToLbl.Size = new System.Drawing.Size(49, 13);
            this.uxValidToLbl.TabIndex = 9;
            this.uxValidToLbl.Text = "Valid To:";
            // 
            // uxValidFromPicker
            // 
            this.uxValidFromPicker.Location = new System.Drawing.Point(129, 214);
            this.uxValidFromPicker.Name = "uxValidFromPicker";
            this.uxValidFromPicker.Size = new System.Drawing.Size(200, 20);
            this.uxValidFromPicker.TabIndex = 10;
            // 
            // uxValidToPicker
            // 
            this.uxValidToPicker.Location = new System.Drawing.Point(129, 240);
            this.uxValidToPicker.Name = "uxValidToPicker";
            this.uxValidToPicker.Size = new System.Drawing.Size(200, 20);
            this.uxValidToPicker.TabIndex = 11;
            // 
            // uxOutputLbl
            // 
            this.uxOutputLbl.AutoSize = true;
            this.uxOutputLbl.Location = new System.Drawing.Point(78, 276);
            this.uxOutputLbl.Name = "uxOutputLbl";
            this.uxOutputLbl.Size = new System.Drawing.Size(42, 13);
            this.uxOutputLbl.TabIndex = 12;
            this.uxOutputLbl.Text = "Output:";
            // 
            // uxOutputBx
            // 
            this.uxOutputBx.Location = new System.Drawing.Point(129, 273);
            this.uxOutputBx.Name = "uxOutputBx";
            this.uxOutputBx.Size = new System.Drawing.Size(121, 20);
            this.uxOutputBx.TabIndex = 13;
            this.uxOutputBx.Text = "c:\\temp";
            // 
            // uxGoBtn
            // 
            this.uxGoBtn.Location = new System.Drawing.Point(253, 313);
            this.uxGoBtn.Name = "uxGoBtn";
            this.uxGoBtn.Size = new System.Drawing.Size(75, 23);
            this.uxGoBtn.TabIndex = 14;
            this.uxGoBtn.Text = "Go!";
            this.uxGoBtn.UseVisualStyleBackColor = true;
            this.uxGoBtn.Click += new System.EventHandler(this.uxGoBtn_Click);
            // 
            // uxQuantityLbl
            // 
            this.uxQuantityLbl.AutoSize = true;
            this.uxQuantityLbl.Location = new System.Drawing.Point(71, 43);
            this.uxQuantityLbl.Name = "uxQuantityLbl";
            this.uxQuantityLbl.Size = new System.Drawing.Size(49, 13);
            this.uxQuantityLbl.TabIndex = 15;
            this.uxQuantityLbl.Text = "Quantity:";
            // 
            // uxQuantityNumBx
            // 
            this.uxQuantityNumBx.Location = new System.Drawing.Point(129, 41);
            this.uxQuantityNumBx.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.uxQuantityNumBx.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxQuantityNumBx.Name = "uxQuantityNumBx";
            this.uxQuantityNumBx.Size = new System.Drawing.Size(120, 20);
            this.uxQuantityNumBx.TabIndex = 16;
            this.uxQuantityNumBx.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // uxPwdBx
            // 
            this.uxPwdBx.Enabled = false;
            this.uxPwdBx.Location = new System.Drawing.Point(129, 116);
            this.uxPwdBx.Name = "uxPwdBx";
            this.uxPwdBx.Size = new System.Drawing.Size(121, 20);
            this.uxPwdBx.TabIndex = 18;
            this.uxPwdBx.Text = "password_here";
            // 
            // uxPwdLbl
            // 
            this.uxPwdLbl.AutoSize = true;
            this.uxPwdLbl.Location = new System.Drawing.Point(64, 119);
            this.uxPwdLbl.Name = "uxPwdLbl";
            this.uxPwdLbl.Size = new System.Drawing.Size(56, 13);
            this.uxPwdLbl.TabIndex = 17;
            this.uxPwdLbl.Text = "Password:";
            // 
            // helpAboutLinkLbl
            // 
            this.helpAboutLinkLbl.AutoSize = true;
            this.helpAboutLinkLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.helpAboutLinkLbl.Location = new System.Drawing.Point(9, 313);
            this.helpAboutLinkLbl.Name = "helpAboutLinkLbl";
            this.helpAboutLinkLbl.Size = new System.Drawing.Size(85, 17);
            this.helpAboutLinkLbl.TabIndex = 19;
            this.helpAboutLinkLbl.TabStop = true;
            this.helpAboutLinkLbl.Text = "Help / about";
            this.helpAboutLinkLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.helpAboutLinkLbl_LinkClicked);
            // 
            // CertGeneratorFormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 343);
            this.Controls.Add(this.helpAboutLinkLbl);
            this.Controls.Add(this.uxPwdBx);
            this.Controls.Add(this.uxPwdLbl);
            this.Controls.Add(this.uxQuantityNumBx);
            this.Controls.Add(this.uxQuantityLbl);
            this.Controls.Add(this.uxGoBtn);
            this.Controls.Add(this.uxOutputBx);
            this.Controls.Add(this.uxOutputLbl);
            this.Controls.Add(this.uxValidToPicker);
            this.Controls.Add(this.uxValidFromPicker);
            this.Controls.Add(this.uxValidToLbl);
            this.Controls.Add(this.uxBitStrengthNumBx);
            this.Controls.Add(this.uxHashTypeCbx);
            this.Controls.Add(this.uxValidFromLbl);
            this.Controls.Add(this.uxHashTypeLbl);
            this.Controls.Add(this.uxBitStrengthLbl);
            this.Controls.Add(this.uxCnPrefixBx);
            this.Controls.Add(this.uxCnPrefixLbl);
            this.Controls.Add(this.uxCertTypeLbl);
            this.Controls.Add(this.uxCertTypeCbx);
            this.MaximumSize = new System.Drawing.Size(350, 370);
            this.MinimumSize = new System.Drawing.Size(350, 370);
            this.Name = "CertGeneratorFormMain";
            this.Text = "Self Signed Certificate Generator - 1.0.1";
            ((System.ComponentModel.ISupportInitialize)(this.uxBitStrengthNumBx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxQuantityNumBx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox uxCertTypeCbx;
        private System.Windows.Forms.Label uxCertTypeLbl;
        private System.Windows.Forms.Label uxCnPrefixLbl;
        private System.Windows.Forms.TextBox uxCnPrefixBx;
        private System.Windows.Forms.Label uxBitStrengthLbl;
        private System.Windows.Forms.Label uxHashTypeLbl;
        private System.Windows.Forms.Label uxValidFromLbl;
        private System.Windows.Forms.ComboBox uxHashTypeCbx;
        private System.Windows.Forms.NumericUpDown uxBitStrengthNumBx;
        private System.Windows.Forms.Label uxValidToLbl;
        private System.Windows.Forms.DateTimePicker uxValidFromPicker;
        private System.Windows.Forms.DateTimePicker uxValidToPicker;
        private System.Windows.Forms.Label uxOutputLbl;
        private System.Windows.Forms.TextBox uxOutputBx;
        private System.Windows.Forms.Button uxGoBtn;
        private System.Windows.Forms.Label uxQuantityLbl;
        private System.Windows.Forms.NumericUpDown uxQuantityNumBx;
        private System.Windows.Forms.TextBox uxPwdBx;
        private System.Windows.Forms.Label uxPwdLbl;
        private System.Windows.Forms.LinkLabel helpAboutLinkLbl;
    }
}

