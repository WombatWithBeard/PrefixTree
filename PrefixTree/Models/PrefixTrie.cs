using System;
using System.Collections.Generic;
using PrefixTree.Interfaces;

namespace PrefixTree.Models
{
    public class PrefixTrie : IPrefixTree
    {
        private readonly TreeNode _root = new TreeNode();
        
        public void Add(string key, int value)
        {
            var current = _root;

            foreach (char c in key)
            {
                try
                {
                    if (!current.Childs.ContainsKey(c))
                    {
                        current.Childs.Add(c, new TreeNode {Key = c});
                    }

                    current = current.Childs[c];
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            current.Value = value;
        }

        public int Get(string key)
        {
            var current = _root;

            foreach (var c in key)
            {
                current = current.Childs[c];
            }

            return current.Value;
        }

        public List<string> GetAllWords(string key)
        {
            var current = _root;
            var result = new List<string>();
            var wordBase = "";

            foreach (var c in key)
            {
                if (current == null) continue;
                if (!current.Childs.ContainsKey(c)) return result;
                
                var node = current.Childs[c];
                if (node != null) wordBase += c;
                current = node;
            }

            if (current == null) return result;
            
            var wordEnding = GetWordEnding(current);
            wordEnding.ForEach(w => result.Add(wordBase + w));

            return result;
        }

        private List<string> GetWordEnding(TreeNode child)
        {
            var result = new List<string>();
            var wordEnding = new List<string>();

            foreach (var (key, value) in child.Childs)
            {
                if (value.Childs.Count > 0)
                {
                    wordEnding = GetWordEnding(value);
                }

                if (wordEnding.Count == 0)
                {
                    result.Add(key.ToString());
                }
                else
                {
                    wordEnding.ForEach(w => result.Add(key + w));
                }
            }
            
            return result;
        }
    }
}