using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

                if (string.IsNullOrEmpty(line)) continue;
                
                var row = line.Split(',');
                
                if (row.Length >= 1) 
                    list.Add((row[0].ToLower(), TryToConvert(row)));
            }

            return list;
        }

        private int TryToConvert(string[] s)
        {
            try
            {
                return string.IsNullOrEmpty(s.Last()) && s.Length > 1 ? 0 : Convert.ToInt32(s.Last());
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}