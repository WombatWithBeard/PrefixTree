using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace PrefixTree.Model
{
    public class PrefixTree
    {
        private readonly TreeNode _root = new TreeNode();

        public void Add(string key, int value)
        {
            var current = _root;

            foreach (char c in key)
            {
                var node = current.Childs.Find(t => t.Key == c);
                
                if (node == null) 
                    current.Childs.Add(new TreeNode {Key = c});

                current = current.Childs.Find(t => t.Key == c);
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
                if (current?.Childs.Find(t => t.Key == c) != null)
                {
                    wordBase += c;
                }
                current = current?.Childs.Find(t => t.Key == c);
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