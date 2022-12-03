namespace Helpers;

public static class InputHelper
{
    public static string GetInput()
    {
        string? input = Console.ReadLine();

        if(string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid Empty Input");
            return InputHelper.GetInput();
        }
        return input;
    }

    public static bool DetermineYesResponse(string input)
    {
        if (input.ToLower() == "yes" || input.ToLower() == "y")
        {
            return true;
        }
        return false;
    }

    public static string GetFileNameFromFilePath (string filePath)
    {
        string[] nameArray = filePath.Split('\\', StringSplitOptions.RemoveEmptyEntries);
        string fileName = nameArray[nameArray.Length -1];

        return fileName;
    }
}