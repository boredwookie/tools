namespace CPUGrab.NET {
    partial class Form1 {
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
            this.cpuPercentBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.cpuPercentLbl = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cpuPercentBar)).BeginInit();
            this.SuspendLayout();
            // 
            // cpuPercentBar
            // 
            this.cpuPercentBar.Location = new System.Drawing.Point(15, 44);
            this.cpuPercentBar.Maximum = 100;
            this.cpuPercentBar.Minimum = 1;
            this.cpuPercentBar.Name = "cpuPercentBar";
            this.cpuPercentBar.Size = new System.Drawing.Size(171, 42);
            this.cpuPercentBar.TabIndex = 0;
            this.cpuPercentBar.TickFrequency = 5;
            this.cpuPercentBar.Value = 1;
            this.cpuPercentBar.Scroll += new System.EventHandler(this.cpuPercentBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "CPU Percent Grabbed:";
            // 
            // cpuPercentLbl
            // 
            this.cpuPercentLbl.AutoSize = true;
            this.cpuPercentLbl.Location = new System.Drawing.Point(144, 21);
            this.cpuPercentLbl.Name = "cpuPercentLbl";
            this.cpuPercentLbl.Size = new System.Drawing.Size(21, 13);
            this.cpuPercentLbl.TabIndex = 2;
            this.cpuPercentLbl.Text = "1%";
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(201, 21);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(49, 23);
            this.startBtn.TabIndex = 3;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.Enabled = false;
            this.stopBtn.Location = new System.Drawing.Point(201, 50);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(49, 23);
            this.stopBtn.TabIndex = 4;
            this.stopBtn.Text = "Stop";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 85);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.cpuPercentLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cpuPercentBar);
            this.Name = "Form1";
            this.Text = "CPUGrab.NET";
            ((System.ComponentModel.ISupportInitialize)(this.cpuPercentBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar cpuPercentBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label cpuPercentLbl;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button stopBtn;
    }
}

