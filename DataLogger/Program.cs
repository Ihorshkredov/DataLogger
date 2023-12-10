using DataLogger.Helpers;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata.Ecma335;
using System.Xml;
using Dapper;
using System.Data.SqlClient;



internal class Program
{
	private static void Main(string[] args)
	{
		
		var config = Configurator.ReadConfiguration();
		
		string sourcePath = config.LogFilePath;
		string connectionString = config.ConString;
		string backupPath = config.BackupPath;
		
		if (string.IsNullOrEmpty(sourcePath)||
			string.IsNullOrEmpty(connectionString)||
			string.IsNullOrEmpty(backupPath))
		{
			Printer.PrintIncorrectConfigMessage();
		}

		else 
		{
			while (true)
			{
				var directory = new DirectoryInfo(sourcePath);
				var filesList = directory.GetFiles();
				if (filesList.Any())
				{
					foreach (var file in filesList)
					{
						var testResult = XmlParser.ParseLog(file.FullName);
						if (testResult == null ||
							testResult.TestStation.Name == "no data") 
						{
							Printer.PrintNOKSaving(file.FullName);
							continue;
						}
						else
						{
							try
							{
								DataSaver.SaveData(connectionString, testResult);
								Printer.PrintOKSaving(file.FullName);
								File.Move(file.FullName,backupPath + file.Name);

							}
							catch (Exception ex)
							{
								Printer.PrintErrorMessage(ex.Message);
							}
						}
					}

				}

				Thread.Sleep(10000);
			}
		}
	
	}
}