using Models;

namespace Helpers;


public static class CsvReader
{

    public static bool DoesFileExist(string filePath)
    {
        return File.Exists(filePath);
    }

    public static List<VideoFileData> ReadVideoFileDataFromCsv(string filePath, bool skipFirstLine)
    {
        List<VideoFileData> videoData = new List<VideoFileData>();

        using var streamReader = File.OpenText(filePath);
        Console.WriteLine("Stream Reader created");
        if (skipFirstLine) streamReader.ReadLine();
        
        while(streamReader.EndOfStream == false)
        {
            string newLine = streamReader.ReadLine();
            VideoFileData newData = new VideoFileData();

            string[] columns = newLine.Split(',');
            
            newData.No = Int.ToString(columns[0]);
            newData.Name = columns[1];
            newData.Tracks = columns[2];
            newData.TimeCodeIn = columns[3];

            newData.TimeCodeOut = columns[4];
            newData.Tape = columns[5];
            newData.Start = columns[6];
            newData.End = columns[7];
            newData.Channels = columns[8];

            videoData.Add(newData);
        }
        
        return videoData;
    }
}