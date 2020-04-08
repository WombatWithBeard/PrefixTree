using System.Collections.Generic;

namespace PrefixTree.Interfaces
{
    public interface IPrefixTree
    {
        void Add(string key, int value);
        int Get(string key);
        List<string> GetAllWords(string key);
    }
}