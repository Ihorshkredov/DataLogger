using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataLogger.Data;
using System.Data.SqlClient;

namespace DataLogger.Helpers
{
	public static class DataSaver
	{
		public static void SaveData(string connectionString,Result testResult)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				DynamicParameters testerParameters = new DynamicParameters();
				testerParameters.Add("@TesterID", testResult.TestStation.TesterID);
				var resultTester = connection.Query<Tester>("GetTesterById", testerParameters, commandType: System.Data.CommandType.StoredProcedure);

				if (resultTester.Count() == 0)
				{
					testerParameters.Add("@TesterName", testResult.TestStation.Name);
					var testerResult = connection.Query("SaveTester", testerParameters, commandType: System.Data.CommandType.StoredProcedure);
				}

				DynamicParameters fullCheckParameters = new DynamicParameters();
				fullCheckParameters.Add("@TesterID", testResult.TestStation.TesterID);
				fullCheckParameters.Add("@FulCheckStatus", testResult.FullTest.Status);
				fullCheckParameters.Add("@FulCheckTimeStamp", testResult.FullTest.TimeStamp);
				var result = connection.Query("SaveFullCheck",fullCheckParameters, commandType: System.Data.CommandType.StoredProcedure);


				DynamicParameters stepsParameters = new DynamicParameters();	
				foreach (var test in testResult.FullTest.Steps)
				{
					stepsParameters.Add("@FulCheckTimeStamp", testResult.FullTest.TimeStamp);
					stepsParameters.Add("@TestName", test.Name);
					stepsParameters.Add("@TestRule", test.Rule);
					stepsParameters.Add("@TestLowLimit", test.LowLimit);
					stepsParameters.Add("@TestHighLimit", test.HighLimit);
					stepsParameters.Add("@TestValue", test.Value);
					stepsParameters.Add("@TestStatus", test.Status);

					var stepsResult = connection.Query("SaveTests", stepsParameters, commandType: System.Data.CommandType.StoredProcedure);
				}
			}
		}
	}

}
