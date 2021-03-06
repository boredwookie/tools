﻿/*
Copyright 2014 Rion Carter

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BBUltimateBackupParser.Ui;
using BBUltimateBackupParser.UBLibrary;

namespace BBUltimateBackupParser {
    public partial class FormMain : Form {
        public FormMain() {
            InitializeComponent();
        }

        #region Form Events
        private void FormMain_Load(object sender, EventArgs e) {
            // Make sure the Filter Type combo box is set to the first entry
            uxTextFilterTypeComboBx.SelectedIndex = 0;

            // Make sure there is an empty string instead of 'null' in the Path Class Variables
            PathToCalBkpZipFile = string.Empty;
            PathToFilteredZipFile = string.Empty;
        }
        #endregion Form Events


        #region File Selectors
        string PathToCalBkpZipFile { get; set; }
        string PathToFilteredZipFile { get; set; }

        private void uxSelectCalBkpBtn_Click(object sender, EventArgs e) {
            OpenFileDialog calBkpFileDialog = new OpenFileDialog();
            calBkpFileDialog.Title = "Select the zip file generated by the Ultimate Backup app";
            calBkpFileDialog.Filter = "ZIP files|*.zip";
            calBkpFileDialog.InitialDirectory = @"%USERPROFILE%\Desktop";
            calBkpFileDialog.RestoreDirectory = true;

            if (calBkpFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                PathToCalBkpZipFile = calBkpFileDialog.FileName;
                uxCalBkpTxtBx.Text = calBkpFileDialog.FileName;
                uxCalBkpTxtBx.SelectionStart = uxCalBkpTxtBx.Text.Length;
                uxCalBkpTxtBx.ScrollToCaret();
            }
        }

        private void uxSaveFileBtn_Click(object sender, EventArgs e) {
            SaveFileDialog saveFilteredFileDialog = new SaveFileDialog();
            saveFilteredFileDialog.Title = "New Calendar File Name";
            saveFilteredFileDialog.Filter = "ZIP files|*.zip";
            saveFilteredFileDialog.InitialDirectory = @"%USERPROFILE%\Desktop";
            saveFilteredFileDialog.RestoreDirectory = true;

            if (saveFilteredFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                // The Ultimate Backup app in AppWorld requires that zip archives begin with "Calendar_"
                PathToFilteredZipFile = saveFilteredFileDialog.FileName;
                var filteredFileName = System.IO.Path.GetFileName(PathToFilteredZipFile);
                var filteredFileParentDir = System.IO.Path.GetDirectoryName(PathToFilteredZipFile);
                if (!filteredFileName.StartsWith("Calendar_")) {
                    PathToFilteredZipFile = filteredFileParentDir + System.IO.Path.DirectorySeparatorChar + "Calendar_" + filteredFileName;
                }

                // Assign the entry to the correct places for readability
                uxFilteredFileTxtBx.Text = PathToFilteredZipFile;
                uxFilteredFileTxtBx.SelectionStart = uxFilteredFileTxtBx.Text.Length;
                uxFilteredFileTxtBx.ScrollToCaret();
            }
        }
        #endregion File Selectors


        #region MenuBar Items
        private void whatDoIDoToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show(
@"This utility lets you take the calendar file backed up by the BlackBerry 10 App named 'Ultimate Backup' and filter its contents down to a set that work for you.

1) Select the Calendar Backup Zip file
2) Select where you want the updated Zip file to be saved
3) Select the filter criteria. This lets you determine what you want to filter out
4) Click the 'Go' Button to generate a revised zip file that can be imported to your new BB device using the Ultimate Backup tool", "Instructions");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("This program is designed to help you deal with Calendar files exported by the 'Ultimate Backup' App available in BlackBerry App World. The Calendar files that are exported can muddy up a new device with unnecessary clutter.\r\n\r\nUse this program to filter the calendar entries down to a set that you can actually use.\r\n\r\nCopyright 2014 Bored Wookie. Feel free to use under Apache 2.0 license terms", "About " + Application.ProductName);
        }
        #endregion MenuBar Items


        #region Filter Date
        private void uxDateBoundLower_CheckedChanged(object sender, EventArgs e) {
            var checkBox = (CheckBox)sender;
            uxDateBoundLowerLbl.Enabled = checkBox.Checked;
            uxDateBoundLowerDateTime.Enabled = checkBox.Checked;
        }

        private void uxDateBoundUpper_CheckedChanged(object sender, EventArgs e) {
            var checkBox = (CheckBox)sender;
            uxDateBoundUpperLbl.Enabled = checkBox.Checked;
            uxDateBoundUpperDateTime.Enabled = checkBox.Checked;
        }
        #endregion Filter Date


        #region Text Filters
        private void uxAddTextFilterBtn_Click(object sender, EventArgs e) {
            if (uxTextFilterStringTxtBx.Text.Length < 1) {
                MessageBox.Show("Make sure you enter at least one character in the filter value text box. It's kind of hard to filter something if there is no filter provided", "Have to enter filter text!");
                return;
            }
            
            string textFilterEnumStr = uxTextFilterTypeComboBx.Items[uxTextFilterTypeComboBx.SelectedIndex].ToString().Replace(" ", "");
            var textFilterT = (TextFilterType)Enum.Parse(typeof(TextFilterType), textFilterEnumStr);
            TextFilterEntry tfe = new TextFilterEntry(textFilterT, uxTextFilterStringTxtBx.Text, uxTextFilterCaseSensitiveChkBx.Checked);

            uxTextFilterListBx.Items.Add(tfe);

            // Reset the filter fields
            uxTextFilterCaseSensitiveChkBx.Checked = false;
            uxTextFilterStringTxtBx.Text = string.Empty;
        }

        private void uxTextFilterListBx_MouseDown(object sender, MouseEventArgs e) {

        }

        private void uxTextFilterListBx_MouseUp(object sender, MouseEventArgs e) {
            var textFilterList = (ListBox)sender;

            if (e.Button == MouseButtons.Right) {
                // Make sure we don't allow bulk-modify
                if (textFilterList.SelectedItems.Count > 1) {
                    uxTextFilterListBxContextMenu.Items[0].Enabled = false;
                } else {
                    uxTextFilterListBxContextMenu.Items[0].Enabled = true;  //
                    uxTextFilterListBx.ClearSelected();                     // Ensures we are only selecting the targetted item
                }

                var item = uxTextFilterListBx.IndexFromPoint(e.Location);
                if (item >= 0) {
                    uxTextFilterListBx.SelectedIndex = item;
                    uxTextFilterListBxContextMenu.Show(textFilterList, e.Location);
                }
            }
        }

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e) {
            // Get the entry that was selected
            var textFilterEntry = (TextFilterEntry)uxTextFilterListBx.Items[uxTextFilterListBx.SelectedIndex];

            // Populate the edit fields with the data
            uxTextFilterStringTxtBx.Text = textFilterEntry.Filter;
            uxTextFilterCaseSensitiveChkBx.Checked = textFilterEntry.CaseSensitive;
            uxTextFilterTypeComboBx.SelectedIndex = ((int)textFilterEntry.Type - 1);    // When setting the Type Selector, remember it doesn't know about 'None'

            // Remove it from the list
            uxTextFilterListBx.Items.RemoveAt(uxTextFilterListBx.SelectedIndex);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            var selectedIndices = uxTextFilterListBx.SelectedIndices;

            for (int i = (selectedIndices.Count - 1); i >= 0 ; i--) {
                int idx = selectedIndices[i];
                uxTextFilterListBx.Items.RemoveAt(idx);
            }
        }
        #endregion Text Filters


        #region Logic
        private void uxGoBtn_Click(object sender, EventArgs e) {
            // Ensure that Source and Destination file have been selected
            if (PathToFilteredZipFile.Length < 10 || PathToCalBkpZipFile.Length < 10) {
                MessageBox.Show("Make sure you select the backup file you want to filter\r\n\r\nAlso, make sure you have selected where you want the filtered backup file to go", "Have you selected your files yet?");
                return;
            }

            // Ensure that the source zip file exists before going further
            if (!System.IO.File.Exists(PathToCalBkpZipFile)) {
                MessageBox.Show("I was unable to locate a file at '"+ PathToCalBkpZipFile + "\r\n\r\nCould you try selecting the Backup Zip file again? I'll need that to continue.", "Could not find the Zip archive");
                return;
            }

            // Ensure the date ranges selected make sense
            var lowerBoundDate = uxDateBoundLowerDateTime.Value;
            var upperBoundDate = uxDateBoundUpperDateTime.Value;
            if (lowerBoundDate > upperBoundDate) {
                MessageBox.Show("Right now you have selected a date range where the 'from' date is more recent than the 'to' date. Please correct this before continuing.", "Please Select a Date Range that makes sense");
                return;
            }

            // Collect the state data we need to pass along to the business logic
            DateTime? from = null;
            if (uxDateBoundLower.Checked) {
                from = lowerBoundDate;
            }
            DateTime? to = null;
            if (uxDateBoundUpper.Checked) {
                to = upperBoundDate;
            }
            
            List<TextFilterEntry> textFilters = uxTextFilterListBx.Items.Cast<TextFilterEntry>().ToList();

            // Perform the calendar parsing and generate the zip file
            UBParser calendarParser = new UBParser(PathToCalBkpZipFile);
            calendarParser.CreateFilteredCalendarZip(PathToFilteredZipFile, textFilters, from, to);

            // Announce that things went well!
            MessageBox.Show("The filtered zip file is available here: " + PathToFilteredZipFile, "Success!");

            // Clear out the filter list and the destination file picker
            uxTextFilterListBx.Items.Clear();
            PathToFilteredZipFile = string.Empty;
            uxFilteredFileTxtBx.Text = string.Empty;
        }
        #endregion Logic

        private void uxMoreInfoLinkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("https://boredwookie.net/index.php/blog/calendar-parser-utility-3rd-party-blackberry-ultimate-backup-app/");
        }
    }
}
