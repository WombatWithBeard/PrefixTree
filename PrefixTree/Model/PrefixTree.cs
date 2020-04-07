using System;
using System.Linq;

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
    }
}