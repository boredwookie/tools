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
using System.Runtime.InteropServices;
using Outlook = Microsoft.Office.Interop.Outlook;
using Microsoft.Win32;

namespace AvailableAgility {
    class AgileCalculator {

        /// <summary>
        /// Stores the time that the work day begins (user configurable setting in Outlook)
        /// </summary>
        DateTime WorkdayBegin;

        /// <summary>
        /// Stores the time that the work day ends (user configurable setting in Outlook)
        /// </summary>
        DateTime WorkdayEnd;

        /// <summary>
        /// Time that lunch starts each day (this should not be included as available time in sprint planning, but don't double dip if there is already an appointment over lunch!)
        /// </summary>
        DateTime LunchTimeStart;

        /// <summary>
        /// When does Lunch End?
        /// </summary>
        DateTime LunchTimeEnd;

        /// <summary>
        /// If we want to include small fragments of time as 'available', set this to true
        /// </summary>
        bool IncludeFragmentedTime;

        /// <summary>
        /// If we are not including fragmented time, this stores how many minutes a gap needs to be before it is considered to be a usable gap
        /// </summary>
        int MinimumUsableGapMins = 0;

        /// <summary>
        /// Set the lunch details so we can take it into account when calculating available time
        /// </summary>
        /// <param name="lunchStart"></param>
        /// <param name="lunchEnd"></param>
        public void SetLunchDetails(DateTime lunchStart, DateTime lunchEnd) {
            LunchTimeStart = lunchStart;
            LunchTimeEnd = lunchEnd;
        }

        /// <summary>
        /// Configure the Fragmentation time details
        /// </summary>
        /// <param name="includeFragmentedTime"></param>
        /// <param name="minimumUsableGapMins"></param>
        public void SetFragmentationDetails(bool includeFragmentedTime, int minimumUsableGapMins) {
            IncludeFragmentedTime = includeFragmentedTime;
            MinimumUsableGapMins = minimumUsableGapMins;
        }

        /// <summary>
        /// Calculates the used and available time from the Outlook Calendar. Assumes 8 hours equals a work day
        /// </summary>
        /// <param name="DateStart"></param>
        /// <param name="DateStop"></param>
        /// <returns>A tuple with calculated information</returns>
        public Tuple<double, double, double, double, double> CalculateAvailability(DateTime DateStart, DateTime DateStop) {
            // Ensure we always use the most up-to-date settings when performing the calculation
            GetOutlookSettings();

            // Get some variables of Outlook types
            Microsoft.Office.Interop.Outlook.Application OutlookApp = null;
            Microsoft.Office.Interop.Outlook.NameSpace MapiNamespace = null;
            Microsoft.Office.Interop.Outlook.MAPIFolder CalendarFolder = null;
            Microsoft.Office.Interop.Outlook.Items OCalendarItems = null;

            // Get the calendar items from Outlook
            OutlookApp = new Microsoft.Office.Interop.Outlook.Application();
            MapiNamespace = OutlookApp.GetNamespace("MAPI");
            CalendarFolder = MapiNamespace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderCalendar);
            OCalendarItems = CalendarFolder.Items;
            OCalendarItems.IncludeRecurrences = true;


            // Sort the calendar events by 'Start' date/time (Just to be sure, I'm not sure how this is returned to me)
            //      It needs to be sorted so I can figure out the gap between meetings
            //      Thought: what about 'all day' meetings? Or meetings that overlap other meetings?
            //                   I think in those cases there is no gap, so this calculation doesn't come into play
            //
            //                   In general I'd like to count double-booked meetings because it shows time pressure that needs to be recorded
            OCalendarItems.Sort("[Start]", Type.Missing);

            // After sorting we need to filter otherwise it doesn't work
            string CalItemsFilter = "[Start] >= '" + DateStart.ToString("g") + "' AND [End] <= '" + DateStop.ToString("g") + "'";
            OCalendarItems = OCalendarItems.Restrict(CalItemsFilter);

            // Get the total number of calendar items (since the interop thing keeps telling me 2 billion)
            int CalenderItemCount = 0;
            foreach (Outlook.AppointmentItem Item in OCalendarItems) {
                CalenderItemCount += 1;
            }

            //
            // Iterate over all the calendar items that were returned and perform calculations
            //
            //      Duration
            //      Overlap with Lunch
            //      Gaps between meetings
            //
            int TotalScheduledMinutes = 0;
            int TotalFragmentedMeetingTimeMins = 0;
            int TotalLunchOverlapTimeMins = 0;
            for (int i = 1; i <= CalenderItemCount; i++) {
                Outlook.AppointmentItem CalItem = OCalendarItems[i];

                //
                // Looping calculation to account for recurring appointments as well as stand alone ones
                //
//                if (CalItem.IsRecurring) {
//                    Microsoft.Office.Interop.Outlook.RecurrencePattern ORPattern = CalItem.GetRecurrencePattern();
//                    DateTime Start = new DateTime(DateStart.Year, DateStart.Month, DateStart.Day, CalItem.Start.Hour, CalItem.Start.Minute, 0);
//                    DateTime End = new DateTime(DateStop.Year, DateStop.Month, DateStop.Day, CalItem.Start.Hour, CalItem.Start.Minute, 0);

//                    var TalliedTime = TallyTimeRecurring(CalItem, ORPattern, Start, End);
//                    TotalScheduledMinutes += TalliedTime.Item1;
//                    TotalFragmentedMeetingTimeMins += TalliedTime.Item2;
//                    TotalLunchOverlapTimeMins += TalliedTime.Item3;
//                } else {
                    // We're only looking for calendar items that are within the specified range
                    if (CalItem.Start >= DateStart && CalItem.End <= DateStop) {

                        // Tally & Calculate the Meeting Duration and other pertinent information
                        var TalliedTime = TallyTime(OCalendarItems, i);
                        TotalScheduledMinutes += TalliedTime.Item1;
                        TotalFragmentedMeetingTimeMins += TalliedTime.Item2;
                        TotalLunchOverlapTimeMins += TalliedTime.Item3;
                    }
//                }

                // Skip the appointment if it is out of range
                if (CalItem == null) {
                    continue;
                }
            }


            /*
             * Note to self: Calculations are wrong at this point. I keep getting back 1815 minutes, when I should be getting 645 (or thereabouts)
             * 
             * Need to compensate for this madness!
             * 
             */


            // Figure out how much unscheduled time I have in the Time period (5 day work week)
            var TimeRange = DateStop.Subtract(DateStart);
            int Weeks = (int)(TimeRange.TotalDays / 7);         // We only want the total number of weeks that have passed

            // Compensate for weekends
            var WorkDays = TimeRange.TotalDays - (2 * Weeks);

            // Work hours per day is a setting controlled by Outlook
            var WorkHoursPerDay = (WorkdayEnd - WorkdayBegin).TotalHours;
            var WorkHours = WorkDays * WorkHoursPerDay;


            //
            // Compensate for Fragmented free time (we don't want really small amounts of free time to really count as 'free' since you can't get anything done in such a short time!)
            TotalScheduledMinutes += TotalFragmentedMeetingTimeMins;

            //
            // Compensate for Lunch time (Everyone needs lunch sometime!)
            TimeSpan LunchSpan = LunchTimeEnd - LunchTimeStart;
            double LunchSpanMinutes = LunchSpan.TotalMinutes;
            LunchSpanMinutes = (LunchSpanMinutes * WorkDays) - TotalLunchOverlapTimeMins;    // We don't want to double count lunch if meetings are scheduled over the top of it
            TotalScheduledMinutes += (int)LunchSpanMinutes;

            // Convert to total Hours Scheduled
            double TotalScheduledHours = TotalScheduledMinutes / 60.0;

            // Final conversion to 'days' of scheduled time
            double TotalScheduledDays = TotalScheduledHours / 24.0;

            // Write out some information for the user:
            Console.WriteLine("\r\n");
            Console.WriteLine("Summary:");
            Console.WriteLine("Days in time period: " + TimeRange.TotalDays);
            Console.WriteLine("Work Days in time period: " + WorkDays);
            Console.WriteLine("Total Meetings Scheduled: " + CalenderItemCount);
            Console.WriteLine("Total Days Scheduled: " + TotalScheduledDays);
            Console.WriteLine("Total Available Days: " + (WorkDays - TotalScheduledDays));

            return new Tuple<double, double, double, double, double>(TimeRange.TotalDays, WorkDays, CalenderItemCount, TotalScheduledDays, (WorkDays - TotalScheduledDays));
        }

        Tuple<int, int, int> TallyTimeRecurring(Outlook.AppointmentItem calItem, Outlook.RecurrencePattern rPattern, DateTime start, DateTime end) {
            // Place to hold all the tallied times
            int TotalScheduledMinutes = 0;
            int TotalFragmentedMeetingTimeMins = 0;
            int TotalLunchOverlapTimeMins = 0;

            // Go over each recurring item and get all the pertinent details
            for (DateTime Current = start; Current <= end; Current = Current.AddDays(1)) {
                try {
                    Microsoft.Office.Interop.Outlook.AppointmentItem Appointment = rPattern.GetOccurrence(Current);
                    Microsoft.Office.Interop.Outlook.AppointmentItem PrevAppointment = null;
                    try {
                        PrevAppointment = rPattern.GetOccurrence(Current.AddDays(-1));
                    } catch {
                        // Don't do anything: It means that we don't have a previous appointment to compare it with
                    }

                    // Tally & Calculate the Meeting Duration and other pertinent information
                    var TalliedTime = TallyTime(Appointment, PrevAppointment);
                    TotalScheduledMinutes += TalliedTime.Item1;
                    TotalFragmentedMeetingTimeMins += TalliedTime.Item2;
                    TotalLunchOverlapTimeMins += TalliedTime.Item3;

                } catch (COMException e) {
                    var c = e;
                    // Eat the exception! It means there isn't a recurring appointment on the date in question.
                }

            }

            // Return the tallied stuff
            return new Tuple<int, int, int>(TotalScheduledMinutes, TotalFragmentedMeetingTimeMins, TotalLunchOverlapTimeMins);
        }

        /// <summary>
        /// Filter out calendar appointments that are more reminders and tallies the total occupied time
        /// </summary>
        /// <param name="calItems">From the outlook interop: This is all the cal items we're working with here</param>
        /// <param name="i">Current index of where we're at</param>
        /// <returns>Tuple with Scheduled Time, Fragmented Time and Lunch Overlap Time (all in MINUTES)</returns>
        Tuple<int, int, int> TallyTime(Microsoft.Office.Interop.Outlook.Items calItems, int i) {
            Microsoft.Office.Interop.Outlook.AppointmentItem CalItem = calItems[i];

            Microsoft.Office.Interop.Outlook.AppointmentItem PrevCalItem = null;
            if (i > 1) {
                PrevCalItem = calItems[i-1];
            }

            var TalliedTime = TallyTime(CalItem, PrevCalItem);

            // Collate data and return
            return TalliedTime;//new Tuple<int, int, int>(ScheduledTimeMins, FragmentedTimeMins, LunchOverlapTimeMins);
        }

        /// <summary>
        /// Had to create another method here to accomodate the recurring meetings
        /// </summary>
        /// <param name="CalItem"></param>
        /// <param name="prevCalItem"></param>
        /// <returns></returns>
        Tuple<int, int, int> TallyTime(Microsoft.Office.Interop.Outlook.AppointmentItem CalItem, Microsoft.Office.Interop.Outlook.AppointmentItem prevCalItem) {
            int ScheduledTimeMins = 0;
            int FragmentedTimeMins = 0;
            int LunchOverlapTimeMins = 0;

            // You can exclude particular meetings
            if (CalItem.Location != null) {
                if (CalItem.Location.ToLowerInvariant().Contains("Home Address for example")) {
                    return new Tuple<int,int,int>(0, 0, 0);
                }
            }

            // Some appointments are more 'reminders'
            if (CalItem.Subject != null) {
                if (CalItem.Subject == "Personal Reminder") {
                    // We don't need to tally time on this appointment if any of these conditions are true
                    return new Tuple<int, int, int>(0, 0, 0);
                }
            }

            // Only grab business hour schedule (As configured by the user in Outlook)
            if (CalItem.Start.Hour < WorkdayBegin.Hour || CalItem.Start.Hour > WorkdayEnd.Hour) {
                return new Tuple<int, int, int>(0, 0, 0);
            }

            //
            // Gap Calculation
            // Only try to do a gap calculation if there is a previous meeting to calculate from (and if we're configured to calculate unusable gaps)
            //
            if ((!IncludeFragmentedTime) && (prevCalItem != null)) {

                TimeSpan MeetingGap = CalItem.Start - prevCalItem.End;

                if (MeetingGap.TotalMinutes < MinimumUsableGapMins) {
                    FragmentedTimeMins = (int)MeetingGap.TotalMinutes; // Cast is justified as Outlook won't let you schedule 'seconds' of a meeting
                }
            }


            //
            // Check for lunch overlap (we don't want to double-dip)
            //      Simple calculation, an approximation
            DateTime LunchStart = new DateTime(CalItem.Start.Year, CalItem.Start.Month, CalItem.Start.Day, LunchTimeStart.Hour, LunchTimeStart.Minute, 0);
            DateTime LunchEnd = new DateTime(CalItem.End.Year, CalItem.End.Month, CalItem.End.Day, LunchTimeEnd.Hour, LunchTimeEnd.Minute, 0);
            if (CalItem.End <= LunchEnd && CalItem.End >= LunchStart) {
                TimeSpan LunchOverlap = CalItem.End - LunchStart;
                LunchOverlapTimeMins = (int)LunchOverlap.TotalMinutes; // Cast is justified as Outlook won't let you schedule 'seconds' of a meeting
            }

            //
            // Duration Check
            //
            ScheduledTimeMins = CalItem.Duration;

            // Return the schtuff
            return new Tuple<int, int, int>(ScheduledTimeMins, FragmentedTimeMins, LunchOverlapTimeMins);
        }


        /// <summary>
        /// Gets the User Configurable 'WorkDay' settings
        /// </summary>
        private void GetOutlookSettings() {
            var OutlookApp = new Microsoft.Office.Interop.Outlook.Application();

            // Find outlook version
            var OutlookVersionRaw = OutlookApp.Version;// MyAddIn.Globals.ThisAddIn.Application.Version.ToString();

            // Trim outlook version
            string[] OutlookVersions = OutlookVersionRaw.Split('.');
            string OutlookVersion = OutlookVersions[0] + ".0";

            RegistryKey OutlookOptionsKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Office\\" + OutlookVersion + "\\Outlook\\Options\\Calendar", false);

            // Cal start is stored in 'minutes from midnight', so I need to convert to DateTime objects
            DateTime Today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            int WorkDayBeginMins = Int32.Parse(OutlookOptionsKey.GetValue("CalDefStart").ToString());
            int WorkDayEndMins = Int32.Parse(OutlookOptionsKey.GetValue("CalDefEnd").ToString());

            // Set the WorkDay properties
            WorkdayBegin = Today.AddMinutes(WorkDayBeginMins);
            WorkdayEnd = Today.AddMinutes(WorkDayEndMins);
        }
    }
}
