using System;

namespace PrefixTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var trie = new Model.PrefixTree();
            
            trie.Add("obama", 10);
            trie.Add("obam", 12);
            
            Console.WriteLine(trie.Get("obama"));
            Console.WriteLine(trie.Get("obam"));
        }
    }
}