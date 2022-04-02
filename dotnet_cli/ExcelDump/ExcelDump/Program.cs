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
            CSNPOIWrapper.ExcelReader.DumpConsole(args[0], 0);
        }
    }
}
