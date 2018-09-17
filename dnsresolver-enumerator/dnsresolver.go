// Copyright 2018 Rion Carter
// Licensed under the terms of the GPLv3
package main

import (
	"encoding/xml"
	"flag"
	"fmt"
	"github.com/miekg/dns"
	"io/ioutil"
	"scratches/dnsresolver/nmaps"
	"strings"
)

func main() {
	nmapFilePath := flag.String("NmapFile", "", "Pass in the full path to the NMAP XML file here")
	testDomainsPath := flag.String("DomainsFile", "", "Pass in the list of newline-delimited domains that are to be tested")
	flag.Parse()

	// Read in the specified nmap file
	nmapXml, _ := ioutil.ReadFile(*nmapFilePath)

	// Unmarshal the XML
	var nmapRun nmaps.Nmaprun
	xml.Unmarshal(nmapXml, &nmapRun)

	// Find DNS servers
	var dnsServers []string
	for _, host := range nmapRun.Host{
		for _, port := range host.Ports.Port{
			if port.Portid == "53"{
				dnsServers = append(dnsServers, host.Address.Addr)
			}
		}
	}

	// Get the list of domains to test
	//var domains []string
	domainsRaw, _ := ioutil.ReadFile(*testDomainsPath)
	domains := strings.Split(strings.Replace(string(domainsRaw), "\r", "", -1), "\n")

	fmt.Println("These DNS servers were identified:")
	fmt.Println(dnsServers)

	fmt.Println("Testing specified domain names against the dns resolvers")
	var responses []DnsResponse
	for _, dns := range dnsServers{
		for _, domain := range domains{
			response := testDns(dns, domain)
			responses = append(responses, response)
		}
	}

	// Check to see if every response has the same number of response and if the results are consistent:
	dnsDifferences := make(map[string]DnsDifferenceReport)
	for _, response := range responses{
		// Check against all others _EXCEPT_ this same DnsResolver/Domain pair
		for _, otherResponse := range responses{
			if !(response.Dns == otherResponse.Dns && response.Domain == otherResponse.Domain) &&
				(response.Domain == otherResponse.Domain){
				// Not checking against itself (checking domain as represented by another dns resolver) so continue

				if len(response.DnsResponses) == len(otherResponse.DnsResponses){
					// Check each response string to see if there are any differences
					for _,dnsResponse := range response.DnsResponses {

						if response.Domain == otherResponse.Domain {
							match := false
							for _, otherDnsResponse := range otherResponse.DnsResponses {
								if dnsResponse == otherDnsResponse {
									match = true
								}
							}

							if !match {
								// Once we get a proposed 'insertion index', we need to check the string at that index
								// to see if it already exists or not. If the strings don't match, we have a difference
								dnsDifferences[response.Domain] = DnsDifferenceReport{
									Domain:      response.Domain,
									Differences: []DnsResponse{response, otherResponse},
								}
							}
						}
					}

				} else {
					// No need to check further: There's a difference!
					dnsDifferences[response.Domain] = DnsDifferenceReport{
						Domain:response.Domain,
						Differences:[]DnsResponse{response, otherResponse},
					}
				}
			}
		}
	}

	fmt.Print(dnsDifferences)
	fmt.Println("Done")
}

type DnsResponse struct{
	Dns          string
	Domain       string
	DnsResponses []string
}

type DnsDifferenceReport struct{
	Domain string
	Differences []DnsResponse
}

func testDns(dnsResolver string, domain string) DnsResponse{
	dnsClient := dns.Client{}

	// Prepare the DNS message (append a period at the end if one is not already present
	if !strings.HasSuffix(domain, "."){
		domain = domain + "."
	}
	dnsRequest := &dns.Msg{}
	dnsRequest.SetQuestion(domain, dns.TypeA)

	response, _, err := dnsClient.Exchange(dnsRequest, dnsResolver + ":53")
	if err!= nil{
		fmt.Println(err)
	}
	//fmt.Print("Timing: ", t, "\n", "Response:", response)
	var responses []string
	for _, answer := range response.Answer{
		//fmt.Println(answer.String())
		// We need to grab the first, 3rd, 4th and 5th entries
		pieces := strings.Split(answer.String(), "\t")
		responses = append(responses, pieces[0]+"\t"+pieces[2]+"\t"+pieces[3]+"\t"+pieces[4])
	}

	return DnsResponse{
		Dns:          dnsResolver,
		Domain:       domain,
		DnsResponses: responses,
	}
}