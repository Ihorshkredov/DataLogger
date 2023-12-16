using DataLogger.Helpers;
using Timer = System.Timers.Timer;



internal class Program
{
    private static string sourcePath;
    private static string connectionString;
    private static string backupPath;

    private static void Main(string[] args)
	{		
		var config = Configurator.ReadConfiguration();

		sourcePath = config.LogFilePath;
	    connectionString = config.ConString;
	    backupPath = config.BackupPath;

		if (string.IsNullOrEmpty(sourcePath) ||
			string.IsNullOrEmpty(connectionString) ||
			string.IsNullOrEmpty(backupPath))
		{
			Printer.PrintIncorrectConfigMessage();
			return;
		}

        var timer = new Timer(10000);
        timer.Elapsed += TimerElapsed;

        Console.WriteLine(DateTime.Now);
        timer.Start();
    }

    private static void TimerElapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
        var directory = new DirectoryInfo(sourcePath);
        var filesList = directory.GetFiles("*.xml");
        if (filesList.Any())
        {
            foreach (var file in filesList)
            {
                var testResult = XmlParser.ParseLog(file.FullName);
                if (testResult == null || testResult.TestStation.Name == "no data")
                {
                    Printer.PrintNOKSaving(file.FullName);
                    continue;
                }
                else
                {
                    try
                    {                                              
                        File.Move(file.FullName, backupPath + file.Name);
                        DataSaver.SaveData(connectionString, testResult);
                        Printer.PrintOKSaving(file.FullName);
                    }
                    catch (Exception ex)
                    {
                        Printer.PrintErrorMessage(ex.Message);
                    }
                }
            }
        }
    }
}