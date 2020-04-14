using System;
using System.Text;
using PrefixTree.Interfaces;
using PrefixTree.Models;
using PrefixTree.Utilities;

namespace PrefixTree
{
    public class Application
    {
        private bool _isQuit;
        private readonly IPrefixTree _tree = new PrefixTrie();
        
        public void Start()
        {
            Info.GetHelpInfo();
            
            try
            {
                GetCommands();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void GetCommands()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            
            while (!_isQuit)
            {
                var x = Console.ReadLine()?.ToLower();
                switch (x)
                {
                    case null:
                        Console.WriteLine("Incorrect keyword, please use \"help\" for get all keywords");
                        break;
                    case "quit":
                        _isQuit = true;
                        break;
                    default:
                    {
                        if (x.Contains("help"))
                            Info.GetHelpInfo();
                        else if (x.Contains("load "))
                            CreatePrefixTree(ClearUserString(x));
                        else if (x.Contains("get "))
                            GetByIdFromPrefixTree(ClearUserString(x));
                        else if (x.Contains("getall "))
                            GetAllByIdFromPrefixTree(ClearUserString(x));
                        break;
                    }
                }
            }
        }

        private string ClearUserString(string s)
        {
            return s.Split(' ')[1];
        }

        private void GetAllByIdFromPrefixTree(string s)
        {
            if (string.IsNullOrEmpty(s)) return;
            
            var words = _tree.GetAllWords(s);
            words.ForEach(Console.WriteLine);
        }

        private void GetByIdFromPrefixTree(string s)
        {
            if (string.IsNullOrEmpty(s)) return;
            
            Console.WriteLine(_tree.Get(s));
        }

        private void CreatePrefixTree(string s)
        {
            var csv = new ReadCsvFile().Read(s);
            
            foreach (var (key, value) in csv)
            {
                _tree.Add(key, value);
            }
            
            Console.WriteLine("data was loaded");
        }
    }
}