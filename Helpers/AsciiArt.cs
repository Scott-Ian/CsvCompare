namespace Helpers;

public static class AsciiArt
{
        public static void PraiseTheOmnissiah()
        {
            //Console.WindowWidth = 200;
            //WriteStringArray(AsciiArt.Mechanicus, 50);
            WriteStringArray(AsciiArt.PraiseTheOmnissiahText);
        }

        public static void WriteStringArray(string[] array, int msDelayBetweenLines = 0)
        {
			foreach(string line in array)
            {
				Console.WriteLine(line);
				System.Threading.Thread.Sleep(msDelayBetweenLines);
            }
        }

        public static readonly string[] PraiseTheOmnissiahText =
		{
			@"______          _            _   _            _____                 _         _       _",
			@"| ___ \        (_)          | | | |          |  _  |               (_)       (_)     | |",
			@"| |_/ / __ __ _ _ ___  ___  | |_| |__   ___  | | | |_ __ ___  _ __  _ ___ ___ _  __ _| |__",
			@"|  __/ '__/ _` | / __|/ _ \ | __| '_ \ / _ \ | | | | '_ ` _ \| '_ \| / __/ __| |/ _` | '_ \ ",
			@"| |  | | | (_| | \__ \  __/ | |_| | | |  __/ \ \_/ / | | | | | | | | \__ \__ \ | (_| | | | |",
			@"\_|  |_|  \__,_|_|___/\___|  \__|_| |_|\___|  \___/|_| |_| |_|_| |_|_|___/___/_|\__,_|_| |_|",
		};
}