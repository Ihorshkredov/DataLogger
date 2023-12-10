using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogger.Data
{
	public class Result
	{
        public Tester TestStation { get; set; }
        public FullCheck FullTest { get; set; }

        public Result( Tester tester, FullCheck fullTest)
        {
            TestStation = tester;
            FullTest = fullTest;
      
        }

        public Result()
        {
            TestStation = new Tester(9999,"no data"); 
            FullTest = new FullCheck();
        }
    }
}
