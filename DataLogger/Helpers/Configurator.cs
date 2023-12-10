using System.Xml.Linq;
using DataLogger.Data;
using System.Configuration;

namespace DataLogger.Helpers
{
	public static class Configurator
    {
        

        public static Config ReadConfiguration()
        {
            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            string filePath = ConfigurationManager.AppSettings["filePath"];
            string backUp = ConfigurationManager.AppSettings["backupPath"];

           if (connectionString != null 
                && filePath != null
                && backUp != null)
            { 
                return new Config(filePath,connectionString,backUp);

            }
           return new Config();
        }

    }
}
