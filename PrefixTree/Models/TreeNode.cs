using System.Collections.Generic;

namespace PrefixTree.Models
{
    public class TreeNode
    {
        public TreeNode()
        {
            Childs = new Dictionary<char, TreeNode>();
        }

        public char Key { get; set; }

        public int Value { get; set; }

        public Dictionary<char, TreeNode> Childs { get; }
    }
}