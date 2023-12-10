using DataLogger.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DataLogger.Helpers
{
    public static class XmlParser

    {
        public static Result ParseLog(string path)
		{
            if (string.IsNullOrEmpty(path))
            {
                return new Result();
            }
           
            XDocument document = XDocument.Load(path);

            var stationID =int.Parse( document.Descendants().Where(x=>x.Name=="Station").Attributes("id").FirstOrDefault().Value);
            var stationName = document.Descendants().Where(x=>x.Name=="Station").Attributes("name").FirstOrDefault().Value;
            var status = document.Descendants().Where(x => x.Name == "FullTest").Attributes("status").FirstOrDefault().Value.ToUpper();
            DateTime testID = DateTime.Parse(document.Descendants().Where(x => x.Name == "FullTest").Attributes("timestamp").FirstOrDefault().Value);

            if (stationID == 0 ||
                string.IsNullOrEmpty(stationName) ||
                string.IsNullOrEmpty(status) ||
                testID == DateTime.MinValue)
            {
                
                return new Result();
            }

            var tests = document.Descendants().Where(x => x.Name == "Test").ToList();

            List<Test> testsList = new List<Test>();

            foreach (var test in tests)
            {
                testsList.Add(new Test
                (
                testID,
                test.Attribute("name").Value,
                test.Attribute("rule").Value,
                test.Attribute("LowLimit").Value,
                test.Attribute("Value").Value,
                test.Attribute("Status").Value,
                test.Attribute("HighLimit").Value
                ));

            }

			return new Result(new Tester(stationID, stationName),
								new FullCheck(stationID, status, testID, testsList));
		}
    }
}
