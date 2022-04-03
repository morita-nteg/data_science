using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace CSVData
{
    public class SimpleCSVReader
    {
        private string csvFilePath = "";
        private List<string[]> csvLines = null;
        public SimpleCSVReader(string csvFilePath)
        {
            this.csvFilePath = csvFilePath;
            csvLines = File.ReadAllLines(csvFilePath).Where(line => !string.IsNullOrWhiteSpace(line)).Skip(1).Select(line => line.Split(',')).ToList();
        }

        private double[] NormalizedArrays(string[] token, int offset)
        {
            double[] ret = new double[token.Length + offset];
            double total = double.Parse(token[1]);

            for (int i = 2; i < token.Length; i++)
            {
                double elem = double.Parse(token[i]);
                ret[i + offset] = elem * elem / total;
            }
            return ret;
        }

        public List<double[]> ToValues()
        {
            List<double[]> csvValues = new List<double[]>();
            csvLines.ForEach(line => csvValues.Add(NormalizedArrays(line, 0)));
            return csvValues;
        }

        public void DumpNormalizedArrays()
        {
            List<double[]> normalizedArrays = ToValues();
            normalizedArrays.ForEach(narr => Console.WriteLine(String.Join(",", narr)));
        }
    }
}
