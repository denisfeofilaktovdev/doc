using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Placements.db;
using Placements.main;
using Placements.Properties;


namespace Placements.src
{
    public partial class frmMainPlacements : Form
    {
        
        public frmMainPlacements()
        {
            InitializeComponent();
            
            
        }


        private void tspMain_Open_Click(object sender, EventArgs e)
        {

            if (cPlacements.Open(openDialog))
            {
                Cursor.Current = Cursors.WaitCursor;


                cPlacements.UpdateData(trvMain);

                trvMain.SelectedNode = trvMain.Nodes[0];
                

                Cursor.Current = Cursors.Default;
               
            }
        }


       

        private void trvMain_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                
                if (e.Node.Name == Resources.constDistrict)
                {
                    e.Node.ContextMenuStrip = cmsEditDistrict;
                    trvMain.SelectedNode = e.Node;
                }


                if (e.Node.Name == Resources.constRegion)
                {

                    e.Node.ContextMenuStrip = cmsEditRegion;
                    trvMain.SelectedNode = e.Node;


                    cmsEditRegion.Show(MousePosition);

                }

                if (e.Node.Name==Resources.constRegionCEC)
                {
                    e.Node.ContextMenuStrip = cmsRegionCEC;
                    trvMain.SelectedNode = e.Node;

                    cmsRegionCEC.Show(MousePosition);
                }

                if (e.Node.Name == Resources.constDepartmentECO)
                {
                    e.Node.ContextMenuStrip = cmsDepartmentECO;
                    trvMain.SelectedNode = e.Node;

                    cmsDepartmentECO.Show(MousePosition);
                }

                if (e.Node.Name==Resources.constRegionAgencyWarer)
                {
                    e.Node.ContextMenuStrip = cmsRAW;
                    trvMain.SelectedNode = e.Node;

                    cmsRAW.Show(MousePosition);
                }

                if (e.Node.Name==Resources.constDistrict)
                {
                    e.Node.ContextMenuStrip = cmsEditDistrict;
                    trvMain.SelectedNode = e.Node;

                    cmsEditDistrict.Show(MousePosition);

                }


                if (e.Node.Name == Resources.constDistrictCEC)
                {
                    e.Node.ContextMenuStrip = cmsDistrictCEC;
                    trvMain.SelectedNode = e.Node;

                    cmsDistrictCEC.Show(MousePosition);
                }
            }
        }

        private void cmsEditRegion_Edit_Click(object sender, EventArgs e)
        {

            cRegion.Edit((int)trvMain.SelectedNode.Tag);

        }


        private void tspMain_Update_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                cPlacements.UpdateData(trvMain);

                trvMain.SelectedNode = trvMain.Nodes[0];

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                
                Debug.WriteLine("\n"+ex+"\n");
            }
            
        }

        private void cmsEditRegion_AddDistrict_Click(object sender, EventArgs e)
        {
            cRegion aRegion = new cRegion((int)trvMain.SelectedNode.Tag);

             aRegion+=new cDistrict();
        }

       
        private void cmsEditDistrict_Edit_Click(object sender, EventArgs e)
        {
            cDistrict.Edit((int)trvMain.SelectedNode.Tag);
        }

        private void trvMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tspPlaceman_Def.Enabled = false;
            tspPlaceman_Del.Enabled = false;
            tspPlaceman_Edit.Enabled = false;
            cPlacements.SelectNode(trvMain.SelectedNode);
               
        }

        private void cmsEditRegion_EditRSA_Click(object sender, EventArgs e)
        {
            cRegion.cRSA.Edit(trvMain.SelectedNode);
        }

        private void tspPlaceman_Add_Click(object sender, EventArgs e)
        {
            if (trvMain.SelectedNode.Name==Resources.constRegion)
            {
                cRegion.cRSA.cPlacementsRSA.Add(trvMain.SelectedNode);

                cRegion.cRSA.cPlacementsRSA.LV(trvMain.SelectedNode);
            }
            else if (trvMain.SelectedNode.Name==Resources.constRegionCEC)
            {
                cRegion.cRegionCEC.cPlacementRegionCEC.Add(trvMain.SelectedNode);

                cRegion.cRegionCEC.cPlacementRegionCEC.LV(trvMain.SelectedNode);
            }
            else if (trvMain.SelectedNode.Name == Resources.constDepartmentECO)
            {
                cRegion.cDepartmentECO.cPlacementsDepEco.Add(trvMain.SelectedNode);

                cRegion.cDepartmentECO.cPlacementsDepEco.LV(trvMain.SelectedNode);
            }
            else if (trvMain.SelectedNode.Name == Resources.constRegionAgencyWarer)
            {
                cRegion.cRegionAgencyWarer.cPlacementsRAW.Add(trvMain.SelectedNode);

                cRegion.cRegionAgencyWarer.cPlacementsRAW.LV(trvMain.SelectedNode);
            }
            else if (trvMain.SelectedNode.Name == Resources.constDistrict)
            {
                cDistrict.cDSA.cPlacementsDSA.Add(trvMain.SelectedNode);

                cDistrict.cDSA.cPlacementsDSA.LV(trvMain.SelectedNode);
            }
            else if (trvMain.SelectedNode.Name == Resources.constDistrictCEC)
            {
                cDistrict.cDistrictCEC.cPlacementsDistrictCEC.Add(trvMain.SelectedNode);

                cDistrict.cDistrictCEC.cPlacementsDistrictCEC.LV(trvMain.SelectedNode);
            }
        }

        
        private void lsvMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvMain.SelectedIndices.Count != 0)
            {
                tspPlaceman_Edit.Enabled = true;
                tspPlaceman_Del.Enabled = true;
                tspPlaceman_Def.Enabled = true;
            }
            else
            {

                tspPlaceman_Edit.Enabled = false;
                tspPlaceman_Del.Enabled = false;
                tspPlaceman_Def.Enabled = false;
            }
        }

        private void tspPlaceman_Edit_Click(object sender, EventArgs e)
        {
            
            if (lsvMain.SelectedItems[0].Name==Resources.constRegion)
            {
                int i = lsvMain.SelectedIndices[0];

                cRegion.cRSA.cPlacementsRSA.Edit(lsvMain.SelectedItems[0]);

                cRegion.cRSA.cPlacementsRSA.LV(trvMain.SelectedNode);

                lsvMain.Items[i].Selected = true;

                lsvMain.Items[i].Focused = true;


            }else if (lsvMain.SelectedItems[0].Name==Resources.constRegionCEC)
            {
                int i = lsvMain.SelectedIndices[0];

                cRegion.cRegionCEC.cPlacementRegionCEC.Edit(lsvMain.SelectedItems[0]);

                cRegion.cRegionCEC.cPlacementRegionCEC.LV(trvMain.SelectedNode);
                
                lsvMain.Items[i].Selected = true;

                lsvMain.Items[i].Focused = true;
            }
            else if (lsvMain.SelectedItems[0].Name == Resources.constDepartmentECO)
            {
                int i = lsvMain.SelectedIndices[0];

                cRegion.cDepartmentECO.cPlacementsDepEco.Edit(lsvMain.SelectedItems[0]);

                cRegion.cDepartmentECO.cPlacementsDepEco.LV(trvMain.SelectedNode);
                
                lsvMain.Items[i].Selected = true;

                lsvMain.Items[i].Focused = true;
            }
             
            else if (lsvMain.SelectedItems[0].Name == Resources.constRegionAgencyWarer)
            {
                int i = lsvMain.SelectedIndices[0];

                cRegion.cRegionAgencyWarer.cPlacementsRAW.Edit(lsvMain.SelectedItems[0]);

                cRegion.cRegionAgencyWarer.cPlacementsRAW.LV(trvMain.SelectedNode);

                lsvMain.Items[i].Selected = true;

                lsvMain.Items[i].Focused = true;
            }
// Почему тут функция добавления вместо редактировать????
                //Потому что Дима лох и Завтыкал

            else if (lsvMain.SelectedItems[0].Name == Resources.constDistrict)
            {
                int i = lsvMain.SelectedIndices[0];

                cDistrict.cDSA.cPlacementsDSA.Edit(lsvMain.SelectedItems[0]);

                cDistrict.cDSA.cPlacementsDSA.LV(trvMain.SelectedNode);

                lsvMain.Items[i].Selected = true;

                lsvMain.Items[i].Focused = true;
            }
            else if (lsvMain.SelectedItems[0].Name == Resources.constDistrictCEC)
            {
                int i = lsvMain.SelectedIndices[0];

                cDistrict.cDistrictCEC.cPlacementsDistrictCEC.Edit(lsvMain.SelectedItems[0]);

                cDistrict.cDistrictCEC.cPlacementsDistrictCEC.LV(trvMain.SelectedNode);

                lsvMain.Items[i].Selected = true;

                lsvMain.Items[i].Focused = true;
            }
            else
            {
                return;
            }




        }

        private void tspPlaceman_Del_Click(object sender, EventArgs e)
        {
            if (lsvMain.SelectedItems[0].Name == Resources.constRegion)
            {
                cRegion.cRSA.cPlacementsRSA.Del(lsvMain.SelectedItems[0]);

                cRegion.cRSA.cPlacementsRSA.LV(trvMain.SelectedNode);

                tspPlaceman_Edit.Enabled = false;
                tspPlaceman_Del.Enabled = false;
                tspPlaceman_Def.Enabled = false;

            }
            else if (lsvMain.SelectedItems[0].Name==Resources.constRegionCEC)
            {

                cRegion.cRegionCEC.cPlacementRegionCEC.Del(lsvMain.SelectedItems[0]);

                cRegion.cRegionCEC.cPlacementRegionCEC.LV(trvMain.SelectedNode);

                tspPlaceman_Edit.Enabled = false;
                tspPlaceman_Del.Enabled = false;
                tspPlaceman_Def.Enabled = false;
            }

            else if(lsvMain.SelectedItems[0].Name==Resources.constDepartmentECO)
            {
                cRegion.cDepartmentECO.cPlacementsDepEco.Del(lsvMain.SelectedItems[0]);
                
                cRegion.cDepartmentECO.cPlacementsDepEco.LV(trvMain.SelectedNode);


                tspPlaceman_Edit.Enabled = false;
                tspPlaceman_Del.Enabled = false;
                tspPlaceman_Def.Enabled = false;
            }
            else if (lsvMain.SelectedItems[0].Name == Resources.constRegionAgencyWarer)
            {
                cRegion.cRegionAgencyWarer.cPlacementsRAW.Del(lsvMain.SelectedItems[0]);
                
                cRegion.cRegionAgencyWarer.cPlacementsRAW.LV(trvMain.SelectedNode);

                tspPlaceman_Edit.Enabled = false;
                tspPlaceman_Del.Enabled = false;
                tspPlaceman_Def.Enabled = false;
            }
            else if (lsvMain.SelectedItems[0].Name == Resources.constDistrict)
            {
                cDistrict.cDSA.cPlacementsDSA.Del(lsvMain.SelectedItems[0]);

                cDistrict.cDSA.cPlacementsDSA.LV(trvMain.SelectedNode);

                tspPlaceman_Edit.Enabled = false;
                tspPlaceman_Del.Enabled = false;
                tspPlaceman_Def.Enabled = false;
            }
            else if (lsvMain.SelectedItems[0].Name == Resources.constDistrictCEC)
            {
                cDistrict.cDistrictCEC.cPlacementsDistrictCEC.Del(lsvMain.SelectedItems[0]);

                cDistrict.cDistrictCEC.cPlacementsDistrictCEC.LV(trvMain.SelectedNode);

                tspPlaceman_Edit.Enabled = false;
                tspPlaceman_Del.Enabled = false;
                tspPlaceman_Def.Enabled = false;
            }
            else
            {
                return;
                
            }
            
        }

        private void tspPlaceman_Def_Click(object sender, EventArgs e)
        {
            if (lsvMain.SelectedItems[0].Name == Resources.constRegion)
            {
                int i = lsvMain.SelectedIndices[0];

                cRegion.cRSA.cPlacementsRSA.Def(lsvMain.SelectedItems[0]);

                cRegion.cRSA.cPlacementsRSA.LV(trvMain.SelectedNode);

                lsvMain.Items[i].Selected = true;

                lsvMain.Items[i].Focused = true;
            }

            else if (lsvMain.SelectedItems[0].Name==Resources.constRegionCEC)
            {
                int i = lsvMain.SelectedIndices[0];

                cRegion.cRegionCEC.cPlacementRegionCEC.Def(lsvMain.SelectedItems[0]);

                cRegion.cRegionCEC.cPlacementRegionCEC.LV(trvMain.SelectedNode);

                lsvMain.Items[i].Selected = true;

                lsvMain.Items[i].Focused = true;
            }
            else if(lsvMain.SelectedItems[0].Name==Resources.constDepartmentECO)
            {
                int i = lsvMain.SelectedIndices[0];
                
                cRegion.cDepartmentECO.cPlacementsDepEco.Def(lsvMain.SelectedItems[0]);

                cRegion.cDepartmentECO.cPlacementsDepEco.LV(trvMain.SelectedNode);

                lsvMain.Items[i].Selected = true;

                lsvMain.Items[i].Focused = true;
            }
            else if (lsvMain.SelectedItems[0].Name == Resources.constRegionAgencyWarer)
            {
                int i = lsvMain.SelectedIndices[0];

                cRegion.cRegionAgencyWarer.cPlacementsRAW.Def(lsvMain.SelectedItems[0]);

                cRegion.cRegionAgencyWarer.cPlacementsRAW.LV(trvMain.SelectedNode);

                lsvMain.Items[i].Selected = true;

                lsvMain.Items[i].Focused = true;
            }
            else if (lsvMain.SelectedItems[0].Name == Resources.constDistrict)
            {
                int i = lsvMain.SelectedIndices[0];

                cDistrict.cDSA.cPlacementsDSA.Def(lsvMain.SelectedItems[0]);

                cDistrict.cDSA.cPlacementsDSA.LV(trvMain.SelectedNode);

                lsvMain.Items[i].Selected = true;

                lsvMain.Items[i].Focused = true;

            }
            else if (lsvMain.SelectedItems[0].Name == Resources.constDistrictCEC)
            {
                int i = lsvMain.SelectedIndices[0];

                cDistrict.cDistrictCEC.cPlacementsDistrictCEC.Def(lsvMain.SelectedItems[0]);

                cDistrict.cDistrictCEC.cPlacementsDistrictCEC.LV(trvMain.SelectedNode);

                lsvMain.Items[i].Selected = true;

                lsvMain.Items[i].Focused = true;
            }
            else
            {
                return;
            }

        }

        private void lsvMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tspPlaceman_Edit_Click(sender, e); 
            

            
        }

        private void cmsRegionCEC_Edit_Click(object sender, EventArgs e)
        {
            cRegion.cRegionCEC.Edit(trvMain.SelectedNode);
        }

        private void trvMain_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
            if (trvMain.SelectedNode.Name == Resources.constRegionCEC)
            {

                cRegion.cRegionCEC.Edit(trvMain.SelectedNode);

            }
            else if (trvMain.SelectedNode.Name == Resources.constDepartmentECO)
            {
                cRegion.cDepartmentECO.Edit(trvMain.SelectedNode);
            }
            else if (trvMain.SelectedNode.Name == Resources.constRegionAgencyWarer)
            {
                cRegion.cRegionAgencyWarer.Edit(trvMain.SelectedNode);
            }
            else if (trvMain.SelectedNode.Name == Resources.constDistrictCEC)
            {
                cDistrict.cDistrictCEC.Edit(trvMain.SelectedNode);
            }
            else
            {
                return;
            }
        }

        private void cmsDepartmentECO_Edit_Click(object sender, EventArgs e)
        {
            cRegion.cDepartmentECO.Edit(trvMain.SelectedNode);
        }

        private void cmsRAW_Edit_Click(object sender, EventArgs e)
        {
            cRegion.cRegionAgencyWarer.Edit(trvMain.SelectedNode);
        }
        
        private void cmsEditDistrict_DelDistrict_Click(object sender, EventArgs e)
        {
            DialogResult q =
               MessageBox.Show("Удалить \"" + trvMain.SelectedNode.Text + "\" и все связанные с ним данные",
                   "Чиновники", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Warning);

            if (q==DialogResult.Yes)
            {
                cRegion aRegion = new cRegion((int)trvMain.SelectedNode.Parent.Tag);

                aRegion -= new cDistrict((int)trvMain.SelectedNode.Tag);



                tspMain_Update_Click(sender, e);

                





            }
            


        }

        private void cmsEditDistrict_EditDSA_Click(object sender, EventArgs e)
        {
            cDistrict.cDSA.Edit(trvMain.SelectedNode);
        }

        private void cmsDistrictCEC_Edit_Click(object sender, EventArgs e)
        {
            cDistrict.cDistrictCEC.Edit(trvMain.SelectedNode);
        }

       
        
    }

       
}
