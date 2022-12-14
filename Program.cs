using System.Data;
using System.Text;
using System;
using Helpers;
using Models;


string ListAPath;
string ListBPath;
string OutputDirectory;
bool csvHasHeaders = false;
List<VideoFileData> AlphaData;
List<VideoFileData> BravoData;
List<VideoFileData> OutputData = new List<VideoFileData>();

// Intro
Console.WriteLine("Instructions go here. Read Readme for some random notes...");
Console.WriteLine();


// Get File Paths
Console.WriteLine("Please enter the absolute file path for List A csv");
ListAPath = InputHelper.GetInput();
if (CsvReader.DoesFileExist(ListAPath) == false)
{
    Console.WriteLine("File A does not exist. Terminating execution");
    Environment.Exit(0);
}
Console.WriteLine("Please enter the absolute file path for List B csv");
ListBPath = InputHelper.GetInput();
if (CsvReader.DoesFileExist(ListBPath) == false)
{
    Console.WriteLine("File B does not exist. Terminating execution");
    Environment.Exit(0);
}
Console.WriteLine();

// Get Output Folder
Console.WriteLine("Please enter an output folder location, including the file name!");
OutputDirectory = InputHelper.GetInput();
Console.WriteLine();

// Determine if there are headers
Console.WriteLine("Do these CSV files have headers? Both must be the same");
Console.WriteLine("y/yes or anything else to indicate 'No'");
csvHasHeaders = InputHelper.DetermineYesResponse(InputHelper.GetInput());

// Convert Input to Lists and Report
AlphaData = CsvReader.ReadVideoFileDataFromCsv(ListAPath, csvHasHeaders);
Console.WriteLine("Entry Count for List A: " + AlphaData.Count.ToString());

BravoData = CsvReader.ReadVideoFileDataFromCsv(ListBPath, csvHasHeaders);
Console.WriteLine("Entry Count for List B: " + BravoData.Count.ToString());

// Generate a Dict of Start and End times with truncated names
Dictionary<string, string> BStartTimes = new Dictionary<string, string>();
Dictionary<string, string> BEndTimes = new Dictionary<string, string>();
Dictionary<string, string> BFileType = new Dictionary<string, string>();
int DuplicateBListNames = 0;
foreach(VideoFileData entry in BravoData)
{
    string[] splitName = entry.Name.Split('.');
    string baseName = splitName[0];
    
    string startTime = entry.Start;
    string endTime = entry.End;

    if (BStartTimes.ContainsKey(baseName) == false) 
    {
        BStartTimes.Add(baseName, startTime);
        DuplicateBListNames++;
    }
    if (BEndTimes.ContainsKey(baseName) == false) BEndTimes.Add(baseName, endTime);

    if (splitName.Length >= 1 && BEndTimes.ContainsKey(baseName) == false) BFileType.Add(baseName, $".{splitName[1]}");
}

int StartTimeReplaces = 0;
int EndTimeReplaces = 0;
int FileTypeReplaces = 0;
foreach(VideoFileData entry in AlphaData)
{
    string[] splitName = entry.Name.Split('.');
    string baseName = splitName[0];

    if (BStartTimes.ContainsKey(baseName))
    {
        entry.Start = BStartTimes.GetValueOrDefault(baseName);
        StartTimeReplaces++;
    }

    if (BEndTimes.ContainsKey(baseName))
    {
        entry.End = BEndTimes.GetValueOrDefault(baseName);
        EndTimeReplaces++;
    }

    if (BFileType.ContainsKey(baseName))
    {
        entry.Name = baseName + BFileType.GetValueOrDefault(baseName);
        FileTypeReplaces++;
    }

    OutputData.Add(entry);
}


// Write output
Console.WriteLine("Outputing new file!");
StringBuilder sb = new StringBuilder();
foreach(VideoFileData entry in OutputData)
{
    string rowToWrite = $"{entry.No},{entry.Name},{entry.Tracks},{entry.TimeCodeIn},{entry.TimeCodeOut},";
    rowToWrite+= $"{entry.Tape},{entry.Start},{entry.End},{entry.Channels}";

    sb.AppendLine(rowToWrite);
}

File.WriteAllText(OutputDirectory , sb.ToString());
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Records Created Count: " + OutputData.Count);
Console.WriteLine("Start Time Replaces: " + StartTimeReplaces.ToString());
Console.WriteLine("End Time Replaces: " + EndTimeReplaces.ToString());
Console.WriteLine("File Type Replaces: " + FileTypeReplaces.ToString());
Console.WriteLine("Duplicate B List Name Entries: " + DuplicateBListNames.ToString());
Console.WriteLine();
Console.WriteLine();
AsciiArt.PraiseTheOmnissiah();


