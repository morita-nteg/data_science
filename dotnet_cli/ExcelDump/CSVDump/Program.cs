using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVDump
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleCSVReader r = new SimpleCSVReader(args[0]);
            r.DumpNormalizedArrays();
        }
    }
}
