using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogger.Data
{
	public class Tester
	{
        public int TesterID { get; set; }
        public string Name { get; set; }

        public Tester(int id, string name)
        {
            TesterID = id;
            Name = name;
                
        }

    }
}
