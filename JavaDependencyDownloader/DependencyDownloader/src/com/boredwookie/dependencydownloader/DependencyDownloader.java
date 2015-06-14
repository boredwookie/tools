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

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.net.URL;
import java.nio.channels.Channels;
import java.nio.channels.ReadableByteChannel;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Vector;

import org.jdom2.Document;
import org.jdom2.Element;
import org.jdom2.JDOMException;
import org.jdom2.Namespace;
import org.jdom2.input.SAXBuilder;

public class DependencyDownloader {
	private String MavenRepoUrl;
	private String DownloadLocation;
	private SAXBuilder JdomBuilder;
	
	/**
	 * Controls whether or not exceptions are logged to stdio
	 */
	public boolean DebugMode = false;
	
	public DependencyDownloader(String downloadLocation, String repoUrl){
		DownloadLocation = downloadLocation;
		MavenRepoUrl = repoUrl;
		JdomBuilder = new SAXBuilder();
	}
	
	
	/**
	 * Pass in a path (Http or local file system) to a .pom file and this will
	 * recursively resolve dependencies and store them in the download location
	 * specified in the constructor
	 * @param pomFilePath
	 */
	public void DownloadDependencies(String pomFilePath){
		String splitChar = null;
		try{
			//
			// Get XML objects from the pom file
			//
			Document pom = GetXmlDocument(pomFilePath);
			Element project = pom.getRootElement();

			// JDom is Namespace aware and needs to know what's going on
			//System.out.println(project.getNamespacesIntroduced());
			Namespace pomNamespace = project.getNamespacesIntroduced().get(0);
			

			//
			// Enumerate properties
			//
			Map<String, String> Properties = new HashMap<String, String>();
			Element propertiesNode = project.getChild("properties", pomNamespace);
			
			// We only need to extract properties if there are any
			if(propertiesNode != null){
				List<Element> properties = propertiesNode.getChildren();
				int propertiesCount = properties.toArray().length;
				for(int i = 0; i < propertiesCount; i++){
					Element property = properties.get(i);
					String propertyName = property.getName();
					String propertyValue = property.getValue();
					
					// Adds -or- updates if already in the HashMap
					Properties.put(propertyName, propertyValue);
				}
			}
			
			
			//
			// Enumerate dependencies
			//		(Resolve versioning along the way)
			//
			List<Dependency> Dependencies = new Vector<Dependency>();
			Element dependenciesNode = project.getChild("dependencies", pomNamespace);
			
			// We only need to get dependencies if there are actually dependencies
			if(dependenciesNode != null){
				List<Element> dependencies = dependenciesNode.getChildren();
				int dependenciesCount = dependencies.toArray().length;
				
				for(int i = 0; i < dependenciesCount; i++){
					Element dependency = dependencies.get(i);
					String groupId = dependency.getChildText("groupId", pomNamespace);
					String artifactId = dependency.getChildText("artifactId", pomNamespace);
					String version = dependency.getChildText("version", pomNamespace);
					
					// Add the dependency to the list
					Dependency depToAdd = new Dependency(ReplaceTokens(groupId, Properties), ReplaceTokens(artifactId, Properties), ReplaceTokens(version, Properties));
					Dependencies.add(depToAdd);
				}
				
				//
				// Recursively download Dependencies from Maven repository
				//
				int dependencyCount = Dependencies.toArray().length;
				for(int i = 0; i < dependencyCount; i++){
					Dependency dep = Dependencies.get(i);
					
					String pomUrl = MavenRepoUrl + dep.UrlStubPOM();
					DownloadDependencies(pomUrl);
				}
			}
			
			//
			// Download This artifact from the Maven repository
			//
			
			// What extensions should we try?
			List<String> extensions = Arrays.asList(".pom", ".pom.asc", ".jar", ".jar.asc", "-config.jar", "-config.jar.asc", "-javadoc.jar", "-javadoc.jar.asc", "-sources.jar", "-sources.jar.asc", "-tests.jar", "-tests.jar.asc");
			
			// Get the absolute base path
			String absoluteBase = pomFilePath.replaceFirst(".pom$", "");
			
			// Get the file name [split is in case file is on a windows file system]
			splitChar = "/";
			if(pomFilePath.contains("\\")){
				splitChar = "\\\\";
			}
			String[] pomFilePathPieces = pomFilePath.split(splitChar);
			String fileNameBase = pomFilePathPieces[pomFilePathPieces.length - 1].replaceAll("\\.pom", "");
			
			// Download
			int extensionsCount = extensions.toArray().length;
			for(int i=0; i < extensionsCount; i++){
				String extension = extensions.get(i);
				
				try{
					// Ensure the destination folder exists
					File fileToDownload = new File(DownloadLocation + File.separator + fileNameBase + extension);
					boolean folderCreateResult = fileToDownload.getParentFile().mkdirs();
					if(!folderCreateResult && !Files.isDirectory(Paths.get(fileToDownload.getParentFile().toString()))){
						// If we can't create the folder, we need to stop
						System.exit(42);
					}
					
					// Perform the download
					URL artifactItem = new URL(absoluteBase + extension);
					ReadableByteChannel rbc = Channels.newChannel(artifactItem.openStream());
					FileOutputStream fos = new FileOutputStream(DownloadLocation + File.separator + fileNameBase + extension);
					fos.getChannel().transferFrom(rbc, 0, Long.MAX_VALUE);
					fos.close();
				} catch (Exception e){
					System.out.println("Trouble retrieving: " + absoluteBase + extension);
					
					if(DebugMode){
						e.printStackTrace();
					}
				}
			}
			
		} catch(Exception e){
			System.out.println("Pom File Path: " + pomFilePath + "\r\nSplit Character: " + splitChar);
			if(DebugMode){
				e.printStackTrace();
			}
		}
	}
	
	/**
	 * For now this will handle the simple case that the entire string is a property
	 * @param raw
	 * @param properties
	 * @return
	 */
	private String ReplaceTokens(String raw, Map<String, String> properties){
		String tokenized = null;
		String prop = null;
		
		if(raw == null){
			return "";
		}
		
		try{
			String token = raw.replaceAll("\\$", "")
					.replaceAll("\\{", "")
					.replaceAll("\\}", "");
			
			prop = properties.get(token);
			
			// Only replace the token if we're dealing with tokenized values
			if(raw.startsWith("$")){
				tokenized = prop;
			} else {
				tokenized = raw;
			}
		} catch(Exception e){
			System.out.println("raw: " + raw + "\r\nProp: " + prop);
			if(DebugMode){
				e.printStackTrace();
			}
		}
		
		return tokenized;
	}
	
	/**
	 * Get a JDom XML object from the specified Pom XML file
	 * 
	 * @param pathToPomFile
	 * @return
	 */
	private Document GetXmlDocument(String pathToPomFile){
		Document xmlDoc = null;
		
		try{
			xmlDoc = JdomBuilder.build(pathToPomFile);
		} catch (JDOMException | IOException e) {
			if(DebugMode){
				e.printStackTrace();
			}
		}
		
		return xmlDoc;
	}
}
