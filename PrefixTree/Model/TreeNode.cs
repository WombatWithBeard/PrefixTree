using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace PrefixTree.Model
{
    public class TreeNode
    {
        public TreeNode()
        {
            Childs = new List<TreeNode>();
        }

        public char Key { get; set; }

        public int Value { get; set; }

        public List<TreeNode> Childs { get; }
    }
}