using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBUltimateBackupParser.Ui;
using System.IO;

namespace BBUltimateBackupParser.UBCalendar {
    /// <summary>
    /// Class that can parse a BB 'Ultimate Backup' calbak file
    /// </summary>
    public class CalendarParser {
        string CalBakFilePath { get; set; }

        /// <summary>
        /// Initialize a new CalendarParser with a reference to a specific calbak file
        /// </summary>
        /// <param name="pathToCalbakFile">Path on the file system to where the calbak file lives</param>
        public CalendarParser(string pathToCalbakFile) {
            CalBakFilePath = pathToCalbakFile;
        }

        /// <summary>
        /// Read the calbak file specified and return a list of rows that match all the filter criteria
        /// </summary>
        /// <param name="textFilters">List of Text Filters we should apply to the source input</param>
        /// <param name="from">If specified, we'll filter out calendar items that were created before the date</param>
        /// <param name="to">If specified we'll filter out calendar items that were created after the specified date</param>
        /// <returns>A List of filtered entries that match all specified filters</returns>
        public List<string> Filter(List<TextFilterEntry> textFilters, DateTime? from, DateTime? to) {
            //Get the file entries
            var calBkpLines = File.ReadAllLines(CalBakFilePath, Encoding.UTF8);

            // Apply Filters
            List<string> filteredEntries = new List<string>();
            foreach(var entry in calBkpLines){
                // Check the entry against all filters
                if(ApplyFilters(entry, textFilters, from, to)){
                    filteredEntries.Add(entry);
                }
            }

            return filteredEntries;
        }

        private bool ApplyFilters(string entry, List<TextFilterEntry> textFilters, DateTime? from, DateTime? to) {
            var entryParts = entry.Split('|');
            var subjectStr = entryParts[4].Trim(new char[] { '"' });
            var descriptionStr = entryParts[5].Trim(new char[] { '"' });
            var dateStartStr = entryParts[7].Trim(new char[] { '"' });
            var dateEndStr = entryParts[8].Trim(new char[] { '"' });

            // Evaluate the Date filters
            if (from != null) {
                var dateStart = DateTime.Parse(dateStartStr);

                if (dateStart >= from) {
                    // Things are good
                } else {
                    return false;
                }
            }

            if (to != null) {
                var dateStart = DateTime.Parse(dateStartStr);

                if (dateStart <= to) {
                    // Things are good
                } else {
                    return false;
                }
            }


            // Evaluate the text filters
            foreach (var filter in textFilters) {
                // Make sure we account for case sensitivity!
                if (!filter.CaseSensitive) {
                    subjectStr = subjectStr.ToUpperInvariant();
                    descriptionStr = descriptionStr.ToUpperInvariant();
                }

                switch (filter.Type) {
                    case TextFilterType.SubjectEquals:
                        if (subjectStr != filter.Filter) {
                            return false;
                        }
                        break;
                    case TextFilterType.SubjectContains:
                        if(!subjectStr.Contains(filter.Filter)){
                            return false;
                        }
                        break;
                    case TextFilterType.DescriptionEquals:
                        if (descriptionStr != filter.Filter) {
                            return false;
                        }
                        break;
                    case TextFilterType.DescriptionContains:
                        if (!descriptionStr.Contains(filter.Filter)) {
                            return false;
                        }
                        break;
                    case TextFilterType.None:
                        // Do nothing
                        break;
                }
            }

            // If we make it here then it means that all the filter rules passed
            return true;
        }
    }
}
