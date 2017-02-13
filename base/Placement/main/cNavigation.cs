using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Placements.db;
using Placements.Properties;
using Placements.src;

namespace Placements.main
{
    public class cNavigation
    {
        public static void SelectNode(tDistrict DSA)
        {



            foreach (TreeNode node in AllNodes.GetNodes(Program.fMainPlacements.trvMain))
            {
                if (node.Text == DSA.District &&node.Parent.Text==DSA.tRegion.Region)
                {
                    Program.fMainPlacements.trvMain.SelectedNode = node;

                   



                }
            }
        }

        public static void SelectParentNode(tRegion RSA)
        {
            foreach (TreeNode node in AllNodes.GetNodes(Program.fMainPlacements.trvMain))
            {
                if (node.Parent.Text == RSA.Region)
                {
                    Program.fMainPlacements.trvMain.SelectedNode = node;



                }
            }
        }

    }
}
