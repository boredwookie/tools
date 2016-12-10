/*
Copyright (c) 2014, Rion Carter
All rights reserved.
 
Redistribution and use in source and binary forms, with or without 
modification, are permitted provided that the following conditions are met:
 
1. Redistributions of source code must retain the above copyright notice, 
this list of conditions and the following disclaimer.
 
2. Redistributions in binary form must reproduce the above copyright notice, 
this list of conditions and the following disclaimer in the documentation 
and/or other materials provided with the distribution.
 
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE 
LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF 
SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
POSSIBILITY OF SUCH DAMAGE.

 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AvailableAgility {
    /// <summary>
    /// Form which allows users to configure the Agility calculator's settings
    /// </summary>
    public partial class AvailableAgilitySettingsForm : Form {
        /// <summary>
        /// User-configurable 'Lunch Time' start time which should always be excluded from agile estimates
        /// </summary>
        public DateTime LunchStartTime;

        /// <summary>
        /// When does lunch end?
        /// </summary>
        public DateTime LunchEndTime;

        /// <summary>
        /// Let the user choose if they want to include chunks of free time less than 30 minutes in their estimates
        /// </summary>
        public bool IncludeFragmentedTime;

        /// <summary>
        /// Stores how many minutes are the minimum-usable. Anything below this number of minutes will not be counted as 'available' time
        /// </summary>
        public int MinimumUsableGapMins;

        /// <summary>
        /// How many days from NOW should we include in our calculationS
        /// </summary>
        public int DaysToCalculate;

        /// <summary>
        /// Initializes a new Form which lets you configure the Agile calculation settings
        /// </summary>
        public AvailableAgilitySettingsForm() {
            InitializeComponent();

            // Load the default values
            SetPublicMembers();
        }

        /// <summary>
        /// Save the user defined settings to the Form properties so they can be read by the other pieces of the Outlook plugin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSaveAgilityBtn_Click(object sender, EventArgs e) {
            SetPublicMembers();
            this.Close();
        }

        private void SetPublicMembers() {
            DaysToCalculate = (int)uxDaysInRange.Value;
            LunchStartTime = uxLunchStartDtime.Value;
            LunchEndTime = uxLunchEndDTime.Value;
            IncludeFragmentedTime = uxFragmentEstimatesChkBx.Checked;
            MinimumUsableGapMins = (int)uxFragmentMinsBx.Value;
        }

        /// <summary>
        /// Controls what Fragmentation settings are visible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxFragmentEstimatesChkBx_CheckedChanged(object sender, EventArgs e) {
            uxFragmentMinsBx.Enabled = !uxFragmentMinsBx.Enabled;
        }

    }
}
