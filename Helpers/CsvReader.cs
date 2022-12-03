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
            
            newData.Name = columns[0];
            newData.Tracks = columns[1];
            newData.TimeCodeIn = columns[2];

            newData.TimeCodeOut = columns[3];
            newData.Tape = columns[4];
            newData.Start = columns[5];
            newData.End = columns[6];
            newData.Channels = columns[7];

            videoData.Add(newData);
        }
        
        return videoData;
    }
}