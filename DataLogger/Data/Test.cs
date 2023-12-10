using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogger.Data
{
	public class Test
	{
        public DateTime TestID { get; set; }
        public string Name { get; set; }

        public string Rule { get; set; }
        public string LowLimit { get; set; }
        public string HighLimit { get; set; }

        public string Value { get; set; }

        public string Status { get; set; }

        public Test( DateTime testId, string name, string rule, string LL, string value,string status, string HL = "none")
        {
            TestID = testId;
            Name = name;
            Rule = rule;
            LowLimit = LL;
            HighLimit = HL;
            Value = value;
            Status = status;
                
        }

	}
}
