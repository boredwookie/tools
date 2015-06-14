/*
Copyright (c) 215, Rion Carter (boredwookie.net)
All rights reserved.

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.

3. Neither the name of the copyright holder nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */
package com.boredwookie.dependencydownloader;

public class Main {
	
	static String repo1 = "http://repo1.maven.org/maven2/";
	static String central = "http://central.maven.org/maven2/";
	
	public static void main(String[] args) {
		/*
		 * args[0] = path to pom file you want to download dependencies for
		 * args[1] = path to where you want to download dependencies to
		 * args[2] = Path to the repository URL -or- CENTRAL -or- REPO1 [if nothing, defaults to CENTRAL]
		 * args[3] = true|false to enable or disable exception message write out to stdio
		 */

		if(args.length > 4 || args.length == 0 || args[0] == "-?" || args[0] == "--help" || args[0] == "-help" || args[0] == "--?"){
			System.out.println("Java Project Dependency Downloader");
			System.out.println("Copyright 2015 The Bored Wookie (boredwookie.net");
			System.out.println("");
			System.out.println("Usage:");
			System.out.println("\tjava -jar dependencydownloader.jar -?\t(Displays This message)");
			System.out.println("");
			System.out.println("\tjava -jar dependencydownloader.jar <path_to_pom> <path_to_local_download_dir> CENTRAL|REPO1|<URL_to_repo> <true|false to enable or disable debug mode>");
			System.out.println("");
			System.out.println("For Example:");
			System.out.println("\tjava -jar dependencydownloader.jar some-pom.xml \"C:\\temp\\depsHere\" CENTRAL true");
			System.out.println("");
			System.out.println("");
			System.out.println("This tool defaults to \"http://central.maven.org/maven2/\" if no repo is entered");
			System.out.println("This tool also defaults debug mode to \"false\"");
			
			System.exit(0);
		}
		
		
		String pathToPom = args[0];
		String downloadFolder = args[1];
		String repo = central;
		boolean debugMode = false;
		if(args.length >= 3){
			switch(args[2]){
			case "CENTRAL":
				repo = central;
				break;
			case "REPO1":
				repo = repo1;
				break;
			default:
				repo = args[3];
				break;
			}
			
			switch(args[3]){
			case "true":
				debugMode = true;
				break;
			default:
				debugMode = false;
				break;
			}
		}
		
		System.out.println("Path to POM file: " + pathToPom);
		System.out.println("Local Download Directory: " + downloadFolder);
		System.out.println("Repository URL: " + repo);
				
		DependencyDownloader downloader = new DependencyDownloader(downloadFolder, central);
		downloader.DebugMode = debugMode;
		downloader.DownloadDependencies(pathToPom);
		
		System.out.println("");
		System.out.println("Finished!");
	}

}

