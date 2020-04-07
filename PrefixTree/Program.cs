using System;

namespace PrefixTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var trie = new Model.PrefixTree();
            
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