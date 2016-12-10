using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBUltimateBackupParser.Ui {
    /// <summary>
    /// Represents the types of text filters we can do
    /// </summary>
    public enum TextFilterType {
        /// <summary>
        /// We're not doing any filtering
        /// </summary>
        None = 0,
        /// <summary>
        /// Calendar Item subject line equals the specified text
        /// </summary>
        SubjectEquals = 1,
        /// <summary>
        /// Calendar Item subject line contains the specified text
        /// </summary>
        SubjectContains = 2,
        /// <summary>
        /// Calendar Item description equals the specified text
        /// </summary>
        DescriptionEquals = 3,
        /// <summary>
        /// Calendar Item description contains the specified text
        /// </summary>
        DescriptionContains = 4
    }
}
