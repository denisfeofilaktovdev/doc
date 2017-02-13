using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Placements.src
{
    public static class AllNodes
    {
        private static List<TreeNode> tmListNodes = new List<TreeNode>();

        public static IList<TreeNode> GetNodes(TreeView treeView)
        {
            tmListNodes.Clear();
            

            
            
            foreach (TreeNode VARIABLE in treeView.Nodes)
            {
                AllNodesRecursive(VARIABLE);

            }

            return tmListNodes;
        }

        private static void AllNodesRecursive(TreeNode treeNode)
        {



            tmListNodes.Add(treeNode);

            // Print each node recursively.
            foreach (TreeNode tn in treeNode.Nodes)
            {
                AllNodesRecursive(tn);
            }


        }
    }
}
