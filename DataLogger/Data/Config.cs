using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogger.Data
{
    public class Config
    {
        public string LogFilePath { get; }
        public string ConString { get; }

        public string BackupPath { get; }

        public Config(string path = "no data", string connection = "no data", string backup = "no data")
        {
            LogFilePath = path;
            ConString = connection;
            BackupPath = backup;
        }
    }
}
