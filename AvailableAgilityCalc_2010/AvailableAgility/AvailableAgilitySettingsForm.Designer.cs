namespace AvailableAgility {
    partial class AvailableAgilitySettingsForm {
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
            this.label1 = new System.Windows.Forms.Label();
            this.uxLunchStartDtime = new System.Windows.Forms.DateTimePicker();
            this.uxSaveAgilityBtn = new System.Windows.Forms.Button();
            this.uxFragmentEstimatesChkBx = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uxLunchEndDTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uxFragmentMinsBx = new System.Windows.Forms.NumericUpDown();
            this.uxDaysInRange = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxFragmentMinsBx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxDaysInRange)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lunch Start:";
            // 
            // uxLunchStartDtime
            // 
            this.uxLunchStartDtime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.uxLunchStartDtime.Location = new System.Drawing.Point(91, 19);
            this.uxLunchStartDtime.Name = "uxLunchStartDtime";
            this.uxLunchStartDtime.ShowUpDown = true;
            this.uxLunchStartDtime.Size = new System.Drawing.Size(97, 20);
            this.uxLunchStartDtime.TabIndex = 2;
            this.uxLunchStartDtime.Value = new System.DateTime(2014, 5, 10, 12, 0, 0, 0);
            // 
            // uxSaveAgilityBtn
            // 
            this.uxSaveAgilityBtn.Location = new System.Drawing.Point(158, 231);
            this.uxSaveAgilityBtn.Name = "uxSaveAgilityBtn";
            this.uxSaveAgilityBtn.Size = new System.Drawing.Size(53, 23);
            this.uxSaveAgilityBtn.TabIndex = 5;
            this.uxSaveAgilityBtn.Text = "Save";
            this.uxSaveAgilityBtn.UseVisualStyleBackColor = true;
            this.uxSaveAgilityBtn.Click += new System.EventHandler(this.uxSaveAgilityBtn_Click);
            // 
            // uxFragmentEstimatesChkBx
            // 
            this.uxFragmentEstimatesChkBx.AutoSize = true;
            this.uxFragmentEstimatesChkBx.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uxFragmentEstimatesChkBx.Location = new System.Drawing.Point(10, 19);
            this.uxFragmentEstimatesChkBx.Name = "uxFragmentEstimatesChkBx";
            this.uxFragmentEstimatesChkBx.Size = new System.Drawing.Size(116, 17);
            this.uxFragmentEstimatesChkBx.TabIndex = 6;
            this.uxFragmentEstimatesChkBx.Text = "Include Fragments:";
            this.uxFragmentEstimatesChkBx.UseVisualStyleBackColor = true;
            this.uxFragmentEstimatesChkBx.CheckedChanged += new System.EventHandler(this.uxFragmentEstimatesChkBx_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uxLunchEndDTime);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.uxLunchStartDtime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 81);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lunch Settings";
            // 
            // uxLunchEndDTime
            // 
            this.uxLunchEndDTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.uxLunchEndDTime.Location = new System.Drawing.Point(91, 45);
            this.uxLunchEndDTime.Name = "uxLunchEndDTime";
            this.uxLunchEndDTime.ShowUpDown = true;
            this.uxLunchEndDTime.Size = new System.Drawing.Size(97, 20);
            this.uxLunchEndDTime.TabIndex = 4;
            this.uxLunchEndDTime.Value = new System.DateTime(2014, 5, 10, 13, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lunch End:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.uxFragmentMinsBx);
            this.groupBox2.Controls.Add(this.uxFragmentEstimatesChkBx);
            this.groupBox2.Location = new System.Drawing.Point(11, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Meeting Fragmentation Settings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Min Usable Time:";
            // 
            // uxFragmentMinsBx
            // 
            this.uxFragmentMinsBx.Location = new System.Drawing.Point(112, 42);
            this.uxFragmentMinsBx.Name = "uxFragmentMinsBx";
            this.uxFragmentMinsBx.Size = new System.Drawing.Size(78, 20);
            this.uxFragmentMinsBx.TabIndex = 7;
            this.uxFragmentMinsBx.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // uxDaysInRange
            // 
            this.uxDaysInRange.Location = new System.Drawing.Point(102, 12);
            this.uxDaysInRange.Name = "uxDaysInRange";
            this.uxDaysInRange.Size = new System.Drawing.Size(97, 20);
            this.uxDaysInRange.TabIndex = 9;
            this.uxDaysInRange.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Days in Range:";
            // 
            // AvailableAgilitySettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 263);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.uxDaysInRange);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.uxSaveAgilityBtn);
            this.Name = "AvailableAgilitySettingsForm";
            this.Text = "Agility Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxFragmentMinsBx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxDaysInRange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker uxLunchStartDtime;
        private System.Windows.Forms.Button uxSaveAgilityBtn;
        private System.Windows.Forms.CheckBox uxFragmentEstimatesChkBx;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown uxFragmentMinsBx;
        private System.Windows.Forms.DateTimePicker uxLunchEndDTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown uxDaysInRange;
        private System.Windows.Forms.Label label4;
    }
}