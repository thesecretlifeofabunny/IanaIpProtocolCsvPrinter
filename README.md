# IanaIpProtocolCsvPrinter.cs
Simple project to test out dotnet 10 shebang scripts. https://devblogs.microsoft.com/dotnet/announcing-dotnet-run-app/

All this does is take in an iana prepared csv file and print the contents to std out

# Prerequisites
To run the application have dotnet 10 installed on your UNIX system.  

Download the .csv from this link https://www.iana.org/assignments/protocol-numbers/protocol-numbers.xhtml

# Running
$ chmod u+x IanaIpProtocolCsvPrinter.cs  
$ ./IanaIpProtocolCsvPrinter.cs path/to/iana-protocols.csv
