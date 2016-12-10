/*
 * CPUGrab.NET  v1.0
 * 
 * Released under an MIT Open Source License (http://www.opensource.org/licenses/mit-license.php)
 * 
 * Copyright 2012 Rion Carter
 */
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CPUGrab.NET {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        /// <summary>
        /// Reference to the worker thread
        /// </summary>
        Thread Worker;

        int CpuPercentage;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cpuPercentBar_Scroll(object sender, EventArgs e) {
            CpuPercentage = cpuPercentBar.Value;
            cpuPercentLbl.Text = cpuPercentBar.Value.ToString() + "%";
        }

        /// <summary>
        /// Start a HIGHEST priority Thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startBtn_Click(object sender, EventArgs e) {

            // Start the thread
            Worker = new Thread(ThreadWork);
            Worker.Priority = ThreadPriority.Highest;
            Worker.Start();

            // Disable the 'start' button so another thread can't be started
            startBtn.Enabled = false;

            // Enable the 'stop' button
            stopBtn.Enabled = true;

            // Disable the slider from being changed while the thread is executing
            cpuPercentBar.Enabled = false;
        }

        private void stopBtn_Click(object sender, EventArgs e) {
            
            // Terminate and cleanup the thread
            Worker.Abort();
            Worker = null;
            
            // Enable the 'start' button for another run
            startBtn.Enabled = true;

            // Disable the 'stop' button since it doesn't apply anymore
            stopBtn.Enabled = false;

            // enable the slider
            cpuPercentBar.Enabled = true;
        }

        /// <summary>
        /// Occupy the CPU for the percentage of time specified by the slider. Operates in 100ms chunks
        /// </summary>
        private void ThreadWork() {
            
            // Find out when 'now' is so we can loop the correct amount of work and idle
            DateTime now = DateTime.Now;

            // Work/idle ratio calculation based on 50ms timeslice
            int TotalTime = 50;
            int WorkTime = CpuPercentage/2;
            int IdleTime = TotalTime - WorkTime;

            // Perpetual Loop
            UInt32 counter = 0;
            while (true) {
                DateTime later = DateTime.Now;

                // Idlework
                counter++;
                if (counter > 3000000) {
                    counter = 0;
                }

                // Work the CPU for as long as specified, then sleep for a time
                if (later >= now.AddMilliseconds(WorkTime)) {
                    Thread.Sleep(IdleTime);
                    now = DateTime.Now;
                }
            }
        }
    }
}
