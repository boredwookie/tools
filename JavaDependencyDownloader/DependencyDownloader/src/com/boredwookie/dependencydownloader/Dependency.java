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

public class Dependency {
	public String GroupId;
	public String ArtifactId;
	public String Version;
	
	public Dependency(String groupId, String artifactId, String version){
		this.GroupId = groupId;
		this.ArtifactId = artifactId;
		this.Version = version;
	}
	
	/**
	 * Get the Repository relative URL to the artifact
	 * @return
	 */
	public String UrlStub(){
		String groupPath = GroupId.replaceAll("\\.", "/");
		
		String urlStub = groupPath + "/" + ArtifactId + "/" + Version + "/";
		return urlStub;
	}
	
	/**
	 * Base name of artifacts contained in an 'Artifact ID' entry in the repository
	 * 
	 * Useful so you can get the .pom/.pom.asc/.jar/.jar.asc/-config.jar/-config.jar.asc, etc...
	 * @return
	 */
	public String ArtifactBaseName(){
		return ArtifactId + "-" + Version;
	}
	
	/**
	 * Get the relative repository URL to the artifact's POM file
	 * @return
	 */
	public String UrlStubPOM(){
		String pomStub = UrlStub() + ArtifactBaseName() + ".pom";
		return pomStub;
	}
}
