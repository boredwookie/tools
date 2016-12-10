using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBUltimateBackupParser.Ui {
    /// <summary>
    /// Represents a line item in the Text Filters box
    /// </summary>
    public class TextFilterEntry {
        public TextFilterType Type { get; set; }
        public string Filter { get; set; }
        public bool CaseSensitive { get; set; }

        /// <summary>
        /// Create a new Text Filter Entry
        /// </summary>
        /// <param name="tft">What sort of text filter is this?</param>
        /// <param name="filter">Filter text to apply</param>
        /// <param name="caseSensitive">Is this case sensitive?</param>
        public TextFilterEntry(TextFilterType tft, string filter, bool caseSensitive) {
            Type = tft;
            CaseSensitive = caseSensitive;
            if (CaseSensitive) {
                Filter = filter;
            } else {
                Filter = filter.ToUpperInvariant();
            }
            
        }

        /// <summary>
        /// Override ToString so that the entry shows up correctly in the list
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return Type.ToString() + "  -  " + Filter;
        }
    }
}
