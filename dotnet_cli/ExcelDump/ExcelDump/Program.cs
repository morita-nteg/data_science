using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelDump
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> lst = new List<string[]>();
            lst.Add(new [] { "a1", "b1", "c1" });
            lst.Add(new [] { "a2", "b1", "c2", "d2" });
            CSNPOIWrapper.ExcelWriter.FromList("result.xlsx", "Sheet1", lst);
            List<string[]> clst = CSNPOIWrapper.ExcelReader.GenerateListFromExcel("result.xlsx", "Sheet1");
            clst.ForEach(elem => Console.WriteLine(String.Join(",", elem)));
        }
    }
}
