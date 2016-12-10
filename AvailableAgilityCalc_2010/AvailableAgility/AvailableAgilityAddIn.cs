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
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;

namespace AvailableAgility
{
    public partial class AvailableAgilityAddIn {
        #region Properties & Fields
        /// <summary>
        /// This performs the time calculation functions
        /// </summary>
        private AgileCalculator Calculator;

        // This lets users configure their user-defined settings that only apply to this add-in
        AvailableAgilitySettingsForm SettingsForm = new AvailableAgilitySettingsForm();

        //
        // These are needed to add an outlook menu item and button
        //
        private Office.CommandBar MainOutlookMenuBar;
        private Office.CommandBarPopup AgilityMenuBar;
        private Office.CommandBarButton CalculateBtn;
        private Office.CommandBarButton SettingsBtn;

        //
        // Add-in specific settings
        //
        DateTime LunchStart;
        DateTime LunchEnd;
        bool IncludeFragmentedTime;
        int MinimumUsableGapMins;

        int DaysToCalculate;
        #endregion


        #region Add-in Startup and ShutDown Events
        private void ThisAddIn_Startup(object sender, System.EventArgs e) {
            Calculator = new AgileCalculator();
            AddAgilityMenuBarAndButtons();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e){
        }
        #endregion


        private void AddAgilityMenuBarAndButtons() {
            try {
                // Setup the Menu Bar
                MainOutlookMenuBar = this.Application.ActiveExplorer().CommandBars.ActiveMenuBar;
                AgilityMenuBar = (Office.CommandBarPopup)MainOutlookMenuBar.Controls.Add(Office.MsoControlType.msoControlPopup, missing,missing, missing, true);
                if (AgilityMenuBar != null) {
                    AgilityMenuBar.Caption = "Agile Availability Calculator";
                    AgilityMenuBar.Visible = true;

                    // Setup the 'Calculate' functionality
                    CalculateBtn = (Office.CommandBarButton)AgilityMenuBar.Controls.Add(Office.MsoControlType.msoControlButton, missing, missing, 1, true);
                    CalculateBtn.Style = Office.MsoButtonStyle.msoButtonIconAndCaption;
                    CalculateBtn.Caption = "Calculate Availability";
                    CalculateBtn.FaceId = 65;
                    CalculateBtn.Tag = "c123";
                    CalculateBtn.Click += new Office._CommandBarButtonEvents_ClickEventHandler(CalculateBtn_Click);

                    // Setup the 'Settings' stuff
                    SettingsBtn = (Office.CommandBarButton)AgilityMenuBar.Controls.Add(Office.MsoControlType.msoControlButton, missing, missing, 1, true);
                    SettingsBtn.Style = Office.MsoButtonStyle.msoButtonIconAndCaption;
                    SettingsBtn.Caption = "Settings...";
                    SettingsBtn.FaceId = 65;
                    SettingsBtn.Tag = "c124";
                    SettingsBtn.Click += new Office._CommandBarButtonEvents_ClickEventHandler(SettingsBtn_Click);
                }
            } catch (Exception ex) {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                throw ex;
            }


        }

        #region Button Events

        /// <summary>
        /// Lets user make changes to the Settings form
        /// </summary>
        /// <param name="Ctrl"></param>
        /// <param name="CancelDefault"></param>
        void SettingsBtn_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault) {
            SettingsForm.ShowDialog();
        }

        /// <summary>
        /// Gets the user settings from the settings form (defaults if no changes have been made by the user
        /// </summary>
        void LoadSettings() {
            // Capture the saved settings from the form
            LunchStart = SettingsForm.LunchStartTime;
            LunchEnd = SettingsForm.LunchEndTime;
            IncludeFragmentedTime = SettingsForm.IncludeFragmentedTime;
            MinimumUsableGapMins = SettingsForm.MinimumUsableGapMins;
            DaysToCalculate = SettingsForm.DaysToCalculate;

            // Update the Calculator with the details
            Calculator.SetLunchDetails(LunchStart, LunchEnd);
            Calculator.SetFragmentationDetails(IncludeFragmentedTime, MinimumUsableGapMins);
        }

        void CalculateBtn_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault) {
            // Get all the settings the user has configured
            LoadSettings();

            // Set the time range we want to calculate
            DateTime StartDate = DateTime.Now;
            DateTime StopDate = StartDate.AddDays(DaysToCalculate);


            var CalculatedData = Calculator.CalculateAvailability(StartDate, StopDate);

            // Display a message box indicating:
            //      The time period in Days
            //      Time of Day range
            //      Hours or Days of meetings scheduled in the range
            //      Available hours or days you can schedule in your agile process
            StringBuilder AvailabilityMsg = new StringBuilder("Total Days in Range: ");
            AvailabilityMsg.Append(CalculatedData.Item1);
            AvailabilityMsg.Append("\r\nWork Days in Range: ");
            AvailabilityMsg.Append(CalculatedData.Item2);
            AvailabilityMsg.Append("\r\nTotal Meetings Scheduled: ");
            AvailabilityMsg.Append(CalculatedData.Item3);
            AvailabilityMsg.Append("\r\nTotal Days of Scheduled Time: ");
            AvailabilityMsg.Append(CalculatedData.Item4);
            AvailabilityMsg.Append("\r\n\r\nTotal Available Days: ");
            AvailabilityMsg.Append(CalculatedData.Item5);

            MessageBox.Show(AvailabilityMsg.ToString());
        }
        #endregion

        /*
         * TODO Items (in a form or in the bar as configurable options
         *          [DONE] Respect business hours set in outlook
         * 
         *          [DONE] Pick lunch time and duration
         * Be able to SAVE the lunch time and duration!
         * 
         *          [DONE] Exclude gaps between meetings less than an hour | 30 mins | blah
         * 
         */


        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
