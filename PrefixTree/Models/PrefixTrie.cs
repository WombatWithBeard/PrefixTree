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
                    var node = current.Childs.Find(t => t.Key == c);
                
                    if (node == null) 
                        current.Childs.Add(new TreeNode {Key = c});

                    current = current.Childs.Find(t => t.Key == c);
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
                current = current.Childs.Find(t => t.Key == c);
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
                var node = current?.Childs.Find(t => t.Key == c);
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

            foreach (var node in child.Childs)
            {
                if (node?.Childs.Count != null)
                {
                    wordEnding = GetWordEnding(node);
                }

                if (wordEnding.Count == 0)
                {
                    result.Add(node.Key.ToString());
                }
                else
                {
                    wordEnding.ForEach(w => result.Add(node.Key + w));
                }
            }
            
            return result;
        }
    }
}