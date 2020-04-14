using System;
using System.Collections.Generic;
using System.IO;

namespace PrefixTree.Utilities
{
    public class ReadCsvFile
    {
        public IEnumerable<(string, int)> Read(string path)
        {
            using var reader = new StreamReader(path);
            
            var list = new List<(string, int)>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();

                var row = line?.Split(',');

                if (row != null) 
                    list.Add((row[0].ToLower(), TryToConvert(row[1])));
            }

            return list;
        }

        private int TryToConvert(string s)
        {
            try
            {
                return string.IsNullOrEmpty(s) ? 0 : Convert.ToInt32(s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + $" from {s}");
                return 0;
            }
        }
    }
}