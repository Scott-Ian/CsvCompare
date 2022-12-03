namespace Models;

public class VideoFileData
{
    public int No { get; set; }
    public string Name { get; set; }
    public string Tracks { get; set; }
    public string TimeCodeIn { get; set; }
    public string TimeCodeOut { get; set; }
    public string Tape { get; set; }
    public string Start { get; set; }
    public string End { get; set; }
    public string Channels { get; set; }

    public VideoFileData () {}
    public VideoFileData(string name, string tracks, string timeCodeIn, string timeCodeOut, string tape, string start, string end, string channels) 
    {
        Name = name;
        Tracks = tracks;
        TimeCodeIn = timeCodeIn;
        TimeCodeOut = timeCodeOut;
        Tape = tape;
        Start = start;
        End = end;
        Channels = channels;
    }
}