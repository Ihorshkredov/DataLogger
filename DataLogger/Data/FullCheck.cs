using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogger.Data
{
	public class FullCheck
	{
        public int ID { get; set; }
        public string Status { get; set; }
        public DateTime TimeStamp { get; set; }
        public IEnumerable<Test> Steps { get; set; }

        public FullCheck(int id, string status, DateTime timestamp, IEnumerable<Test> teststeps)
        {
            ID = id;
            Status = status;
            TimeStamp = timestamp;
            Steps = teststeps;       
        }

        public FullCheck()
        {
            ID = 9999;
            Status = "no data";
            TimeStamp = DateTime.Now;
            Steps = new List<Test>();
                
        }
    }
}
