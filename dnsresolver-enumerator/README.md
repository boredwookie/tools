# README
This simple tool lets me take an NMAP xml output file, sift it for DNS servers (naive search on port 53 for now) and run a simple set of queries against the dns servers. If there are differences, they appear in the console output

# How to compile?
This library leverages a go dns library (`go get github.com/miekg/dns`) and will need to be installed

# How to use?
You'll need to be familiar enough with nmap to generate an xml output file (something like this will work: `nmap -T4 -F 192.168.0.0/24 -oX nmap-output.xml`)

A list of domains separated by newlines will be needed as well. It should look like this:
```
domain1.tld
domain2.tld
domain3.othertld
```

Pass the paths to the input files to the program like this:
dnsresolver -NmapFile=/path/to/nmap.xml -DomainsFile=/path/to/list-of-newline-separated-domains.txt

Output is pretty crude right now. Might improve with time if there is any call for it.
