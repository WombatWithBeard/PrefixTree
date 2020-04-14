using System;

namespace PrefixTree.Utilities
{
    public static class Info
    {
        public static void GetHelpInfo()
        {
            Console.WriteLine("Program keys:");
            Console.WriteLine("help - repeat help info");
            Console.WriteLine("load - load data file");
            Console.WriteLine("getall <key> - get all key that starts on <key>");
            Console.WriteLine("get <key> - get value from <key> data");
            Console.WriteLine("quit - quit from program");
        }
    }
}