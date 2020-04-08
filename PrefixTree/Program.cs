using System;
using PrefixTree.Interfaces;

namespace PrefixTree
{
    class Program
    {
        static void Main(string[] args)
        {
            IPrefixTree trie = new Models.PrefixTree();
            
            trie.Add("мама", 10);
            trie.Add("машинка", 12);
            trie.Add("машиностроение", 12);

            var words = trie.GetAllWords("ма");
            words.ForEach(Console.WriteLine);
            
            words = trie.GetAllWords("па");
            words.ForEach(Console.WriteLine);
            
            Console.WriteLine(trie.Get("мама"));
            Console.WriteLine(trie.Get("машинка"));
        }
    }
}