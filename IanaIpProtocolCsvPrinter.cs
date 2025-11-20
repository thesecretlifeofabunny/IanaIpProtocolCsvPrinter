#!/usr/bin/env dotnet

#:package CsvHelper@33.1.0

using CsvHelper;
using System;
using System.Globalization;
using System.IO;

string[] arguments = Environment.GetCommandLineArgs();

if (arguments.Count() < 2)
{
    Console.WriteLine("This script takes in a iana protocol csv found at https://www.iana.org/assignments/protocol-numbers/protocol-numbers.xhtml");    
    return;
}

string filePath = arguments[1];

if(!File.Exists(filePath))
{
    Console.WriteLine("File does not exist, please check the path to file, or if file exists in expected directory");
    return;
}

try
{
    using (var reader = new StreamReader(filePath))
    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
    {
        var ianaIpProtocols = new List<IpProtocol>();
        csv.Read();
        csv.ReadHeader();
        while (csv.Read())
        {
            var protocol = new IpProtocol
            {
                Number = csv.GetField("Decimal"),
                Keyword = csv.GetField("Keyword"),
                Protocol = csv.GetField("Protocol"),
                Ipv6ExtensionHeader = csv.GetField("IPv6 Extension Header"),
                Reference = csv.GetField("Reference"),
            };
            ianaIpProtocols.Add(protocol);
        }

        foreach(IpProtocol protocol in ianaIpProtocols)
        {
            Console.WriteLine(protocol.ToString());
        }
    }
}catch (Exception exception)
{
    Console.WriteLine("Failed to parse and print the csv with exception {0}", exception);
}

public class IpProtocol()
{
    public string? Number { get; init; } = default;
    public string? Keyword { get; init; } = default;
    public string? Protocol { get; init; } = default;
    public string? Ipv6ExtensionHeader { get; init; } = default;
    public string? Reference { get; init; } = default;

    public override string ToString()
    {
        return "Value: " + Number + " " +
            "Keyword: " + Keyword + " " +
            "Protocol: " + Protocol + " " +
            "IPv6 Extension Header: " + Ipv6ExtensionHeader + " " +
            "Reference: " + Reference;
    }
}
