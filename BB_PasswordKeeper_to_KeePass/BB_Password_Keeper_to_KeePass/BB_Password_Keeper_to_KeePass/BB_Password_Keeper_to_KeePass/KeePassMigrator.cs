/*
 * Copyright 2016 Rion Carter
 * 
 * Made available to the public under the GNU GPLv3 license
 */
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace BB_Password_Keeper_to_KeePass
{
    /// <summary>
    /// Converts BlackBerry Password Keepr CSV files to KeePass CSV files
    /// </summary>
    class KeePassMigrator
    {
        /// <summary>
        /// Stores the path to the BB Password Keeper CSV Input file
        /// </summary>
        public string PkInputFile { get; set; }

        /// <summary>
        /// Path to the output KeePass CSV file
        /// </summary>
        public string KpOutputFile { get; set; }

        public KeePassMigrator()
        {
        }

        /// <summary>
        /// Performs the password migration from BB Password Keeper to Kee Pass
        /// </summary>
        public void Migrate()
        {
            if (PkInputFile == null || KpOutputFile == null)
            {
                throw new Exception("Input and Output file paths must be specified");
            }
            /* 
             * Iterate over all lines (except for the first, which contains header information)
             * 
             * Mash the input into this CSV column format:
             * 
             *  KeePass:        Password Keeper
             *  --------        ---------------
             *  
             *  Account     <=  name
             *  Login Name  <=  username
             *  Password    <=  password
             *  Web Site    <=  url
             *  Comments    <= extra, passwordSetDate, lastModifiedTime
             */

            var inputCsvStream = new CsvReader(new StreamReader(PkInputFile));
            var pkEntries = inputCsvStream.GetRecords<PasswordKeeperEntry>();

            List<KeePassEntry> keePassEntries = new List<KeePassEntry>();
            foreach (var entry in pkEntries)
            {
                var kpEntry = new KeePassEntry();

                // Build a KeePass entry from the PasswordKeeper entry
                kpEntry.Account = entry.name;
                kpEntry.LoginName = entry.username;
                kpEntry.Password = entry.password;
                kpEntry.WebSite = entry.url;
                String comments = entry.extra + "\r\n\r\nDate Modified: " + UnixToDateTime(entry.lastModifiedTime).ToLongDateString() + "\r\nDate Created: " + UnixToDateTime(entry.passwordSetDate).ToLongDateString();
                kpEntry.Comments = comments;

                keePassEntries.Add(kpEntry);
            }


            // Write the output CSV file
            using (var csvWriter = new CsvWriter(new StreamWriter(KpOutputFile)))
            {
                csvWriter.Configuration.RegisterClassMap<KeePassClassMap>();
                csvWriter.Configuration.QuoteAllFields = true;
                csvWriter.WriteRecords(keePassEntries);
            }
        }

        /// <summary>
        /// Convert Unix Time to C# DateTime object
        /// </summary>
        /// <param name="unixTimeStamp">Seconds since January 1st, 1970</param>
        /// <returns>Datetime representation of the Unix time entered</returns>
        DateTime UnixToDateTime(double unixTimeStamp)
        {
            var unix_time_base = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return unix_time_base.AddSeconds(unixTimeStamp);
        }

        /// <summary>
        /// Representation of a PasswordKeeper entry for CSV seralizer/deserializer (Using "String" type when I can't determine the format of the column)
        /// </summary>
        class PasswordKeeperEntry
        {
            public String url { get; set; }
            public String username { get; set; }
            public String password { get; set; }
            public String extra { get; set; }
            public String name { get; set; }
            public String grouping { get; set; }
            public String fav { get; set; }
            public String customFields { get; set; }
            public long lastModifiedTime { get; set; }
            public String uid { get; set; }
            public String usernameLabel { get; set; }
            public String passwordLabel { get; set; }
            public String websiteLabel { get; set; }
            public String notesLabel { get; set; }
            public long passwordSetDate { get; set; }
            public String flags { get; set; }
            public String imageIndex { get; set; }
            public String dataVersion { get; set; }
        }

        /// <summary>
        /// Representation of a KeePass entry for CSV serialization/deserialization
        /// </summary>
        class KeePassEntry
        {
            public String Account { get; set; }
            public String LoginName { get; set; }
            public String Password { get; set; }
            public String WebSite { get; set; }
            public String Comments { get; set; }
        }

        /// <summary>
        /// Lets the CSV Writer get the header information correct
        /// </summary>
        sealed class KeePassClassMap : CsvClassMap<KeePassEntry>
        {
            public KeePassClassMap()
            {
                Map(m => m.Account).Name("Account");
                Map(m => m.LoginName).Name("Login Name");
                Map(m => m.Password).Name("Password");
                Map(m => m.WebSite).Name("Web Site");
                Map(m => m.Comments).Name("Comments");
            }
        }
    }
}
