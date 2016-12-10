package com.rion.jOutlookAvailabilityCalculator;

import java.io.Console;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Date;

import microsoft.exchange.webservices.data.Appointment;
import microsoft.exchange.webservices.data.CalendarFolder;
import microsoft.exchange.webservices.data.CalendarView;
import microsoft.exchange.webservices.data.ExchangeCredentials;
import microsoft.exchange.webservices.data.ExchangeService;
import microsoft.exchange.webservices.data.ExchangeVersion;
import microsoft.exchange.webservices.data.FindItemsResults;
import microsoft.exchange.webservices.data.TimeSpan;
import microsoft.exchange.webservices.data.WebCredentials;
import microsoft.exchange.webservices.data.WellKnownFolderName;

/**
 * Primary entry point for the CLI version of the outlook availability calculator
 * 
 * @author Rion Carter
 * 
 * Copyright (c) 2014, Rion Carter
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
 *
 * 1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
 *
 * 2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *
 */
public class OACli {

	// arg0 = number of weeks
	// arg1 = username
	// arg2 = password
	public static void main(String[] args) throws IOException {
		// ex 1: -u rion -p password
		// ex 2: -u rion -p password (default days of 14)
		// ex 3: -u rion -p (prompt for password) (default days of 14)
		// ex 4: rion w 2 (prompt for password)
		
		Console console = System.console();
		
		String Username = null;
		String Password = null;
		int    Weeks = 2;
		for(int i=0; i < args.length; i++){
			if(args[i].equals("-u")){
				Username = args[i+1];
			} else if(args[i].equals("-p")){
				Password = args[i+1];
			} else if(args[i].equals("-w")){
				Weeks = Integer.parseInt(args[i+1]);
			}
			// Print help then quit if we have a help args
			if(args[i].equals("--help") || args[i].equals("-help") || args[i].equals("-?")){
				System.out.println("  ");
				System.out.println("jCalendarView (For Fr-Agile environments)");
				System.out.println("\tShows you how much time you REALLy have to do things!");
				System.out.println("  ");
				System.out.println("\t2014 Rion Carter");
				System.out.println("  ");
				System.out.println("  ");
				System.out.println("Available arguments:");
				System.out.println("\t-u <Username String>");
				System.out.println("\t-p <Password String>");
				System.out.println("\t-w <Integer>");
				System.out.println("  ");
				System.out.println("  ");
				System.out.println("Example:");
				System.out.println("java -jar jCalendarView -u rion.carter@companyname.tld -p ThisIsPassword -w 2");
				System.out.println("\tIn this example, MS Exchange will be queried for the next 2 WEEKS worth");
				System.out.println("\tof appointments. Your available time will be displayed after subtracting");
				System.out.println("\tthe time allotted to the meetings retrieved.");
				
				return;
			}
		}

		if(Username == null){
			System.out.println("Enter the username@domain.tld, please:");
			java.io.BufferedReader reader = new java.io.BufferedReader(new InputStreamReader(System.in));
			Username = reader.readLine();
		}
		if(Password == null){
			System.out.println("Enter the password, please:");
			if(console == null){
				java.io.BufferedReader reader = new java.io.BufferedReader(new InputStreamReader(System.in));
				Password = reader.readLine();
			} else {
				char[] passwordChars = console.readPassword();
				Password = new String(passwordChars);
			}
		}
		DoOutlookyStuff(Username, Password, Weeks);
	}

	
	public static void DoOutlookyStuff(String user, String password, long weeks){
		try{
			// Setup EWS classes
			ExchangeService s = new ExchangeService(ExchangeVersion.Exchange2010_SP2);
			ExchangeCredentials c = new WebCredentials(user, password);
			
			s.setCredentials(c);
			s.autodiscoverUrl(user);
			
			
			// Try to read all calendar items (including recursive items) in the timeframe specified
			CalendarFolder cal = CalendarFolder.bind(s, WellKnownFolderName.Calendar);
			Date Now = new Date();
			Date TwoWeeksFromNow = new Date(Now.getTime() + (1000L *60L *60L *24L * 7L * weeks)); // 1000L *60L *60L *24L * 14L  // 2 weeks
			CalendarView cview = new CalendarView(Now, TwoWeeksFromNow);
			FindItemsResults<Appointment> appointments = cal.findAppointments(cview);
			
			// Print out the calendar items, locations and durations
			System.out.println("Appointments in the upcoming time period: " + appointments.getItems().size());
			TimeSpan TotalAppointmentTime = new TimeSpan(0);
			for(Appointment a : appointments.getItems()){
				String AppointmentLocation = a.getLocation();
				TimeSpan AppointmentDuration = a.getDuration();
				String AppointmentSubject = a.getSubject();
				System.out.println("Appointment Name: " + AppointmentSubject + "\nAppointment Location:"+AppointmentLocation+"\nAppointment Duration:"+ AppointmentDuration.getHours()+" Hours "+ AppointmentDuration.getMinutes() + "\n");
				TotalAppointmentTime = new TimeSpan(TotalAppointmentTime.getTotalMilliseconds() + AppointmentDuration.getTotalMilliseconds());		// Running total of meeting time
			}
			
			System.out.println("\nTotal number of meetings in the upcoming time period: " + appointments.getItems().size());
			System.out.println("Total Time taken up in meetings: "+TotalAppointmentTime.getHours() + " Hours " + TotalAppointmentTime.getMinutes() + " Minutes");
			
			// Calculate & display available free time (assuming 8 hour days, 5 day work week)
			long HoursWorkWeek = 40L;
			long GrossTotalWorkHoursAvailableInTimePeriod = HoursWorkWeek * weeks;
			long GrossTotalWorkMinutesAvailableInTimePerod = GrossTotalWorkHoursAvailableInTimePeriod * 60L;
			
			long PlannedMinutesInWorkWeek = (TotalAppointmentTime.getHours() * 60L) + TotalAppointmentTime.getMinutes();
			long NetWorkMinutesInTimePeriod = GrossTotalWorkMinutesAvailableInTimePerod - PlannedMinutesInWorkWeek;
			
			// Display available free time
			System.out.println("\nTotal Free Time: " + (NetWorkMinutesInTimePeriod/60L) + " Hours " + (NetWorkMinutesInTimePeriod%60L));
			
		} catch(Throwable t){
			System.out.println("error: " + t.toString());
			// Something happened that I don't much care about
		}
	}
}
