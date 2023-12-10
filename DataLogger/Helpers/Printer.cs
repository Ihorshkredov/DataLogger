using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataLogger.Helpers
{
	public static class Printer
	{
		public static void PrintIncorrectConfigMessage()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("There is missing settings in your config file");
			Console.ResetColor();
		}

		public static void PrintOKSaving(string filePath)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(new string('-',50));
			Console.WriteLine("Data saved succesfull from log:");
			Console.WriteLine($"{filePath}");
			Console.WriteLine(new string('-', 50));
			Console.ResetColor();
		}

		public static void PrintNOKSaving(string filePath)
		{
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine(new string('-', 50));
			Console.WriteLine("Data Not Saved from log:");
			Console.WriteLine($"{filePath}");
			Console.WriteLine(new string('-', 50));
			Console.ResetColor();
		}

		public static void PrintErrorMessage(string errorMessage)
		{
			string logPath = AppDomain.CurrentDomain.BaseDirectory + "ErrorsList.txt";
			
			using (StreamWriter writer = new StreamWriter(logPath))
			{
				writer.WriteLine(errorMessage);
			}
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Some error happened.");
			Console.WriteLine("Please check Error list file");
			Console.ResetColor();

		}

	}
}
