using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Placements.db;
using Placements.Kernel;
using Placements.main;
using Placements.Properties;

namespace Placements
{
    public class cPlacements
    {
        private static DB dBase;

        public static bool Open(OpenFileDialog openDialog)
        {

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                dBase = new DB().OpenFromCMD(openDialog.FileName, TypeInDb.TypeInSpace);
                return true;
            }
            else
            {
                return false;
            }


        }

        private static async Task<ImageList> imlList()
        {

            ImageList imageList = new ImageList();

            imageList.ImageSize = new Size(32, 32);

            imageList.ColorDepth = ColorDepth.Depth32Bit;


            MemoryStream memoryStream = new MemoryStream((byte[]) new ImageConverter().ConvertTo(Resources.UkraineMain, typeof (byte[])));
            imageList.Images.Add(
                Image.FromStream(
                    memoryStream));

            memoryStream =
                new MemoryStream((byte[]) new ImageConverter().ConvertTo(Resources.RegionSES, typeof (byte[])));
            imageList.Images.Add(
                Image.FromStream(memoryStream));

            memoryStream =
                new MemoryStream((byte[]) new ImageConverter().ConvertTo(Resources.EcologyDepartment, typeof (byte[])));
            imageList.Images.Add(
                Image.FromStream(memoryStream));


            memoryStream =
                new MemoryStream((byte[]) new ImageConverter().ConvertTo(Resources.RegionAgencyWarer, typeof (byte[])));

            imageList.Images.Add(
                Image.FromStream(memoryStream));


            memoryStream =
                new MemoryStream((byte[]) new ImageConverter().ConvertTo(Resources.DistrictSES, typeof (byte[])));
            imageList.Images.Add(
                Image.FromStream(memoryStream));

            foreach (var VAR in tRegion.FindAll())
            {
                if (VAR.icon_ == null)
                {

                    memoryStream =
                        new MemoryStream((byte[]) new ImageConverter().ConvertTo(Resources.Ukraine, typeof (byte[])));
                    imageList.Images.Add(
                        Image.FromStream(memoryStream));
                }
                else
                {
                    memoryStream=new MemoryStream(VAR.icon_);
                    imageList.Images.Add(Image.FromStream(memoryStream));
                }

                foreach (var VARIABLE in tDistrict.FindAll())
                {
                    if (VARIABLE.tRegion.ID_Region==VAR.ID_Region)
                    {
                        if (VARIABLE.icon_ == null)
                        {

                            memoryStream=new MemoryStream((byte[])new ImageConverter().ConvertTo(Resources.Ukraine, typeof(byte[])));
                            imageList.Images.Add(
                                Image.FromStream(memoryStream));
                        }
                        else
                        {
                            memoryStream = new MemoryStream(VARIABLE.icon_);
                            imageList.Images.Add(Image.FromStream(memoryStream));
                        }
                    }
                    
                    

                }




            }

            return imageList;

        }

        public static async void UpdateData(TreeView MainTreeView)
        {

            try
            {
                MainTreeView.ImageList = await imlList();

                MainTreeView.Nodes.Clear();

              

                TreeNode Ukraine = new TreeNode();
                Ukraine.Text = Resources.stringUkraine;
                Ukraine.ImageIndex =0;
                Ukraine.SelectedImageIndex = 0;
                Ukraine.Tag = Resources.constUkraine;
                Ukraine.Name = Resources.constUkraine;
                MainTreeView.Nodes.Add(Ukraine);

                TreeNode Region;

                TreeNode RegionSES;

                TreeNode DistrictSES;

                TreeNode RAW;

                TreeNode EcologyDepartment;


                int a = 0;


                foreach (var VARI in tRegion.FindAll())
                {

                    Region = new TreeNode
                    {

                        Text = VARI.Region,
                        ImageIndex = 5 + a,
                        SelectedImageIndex = 5 + a,
                        Tag = VARI.ID_Region,
                        Name = Resources.constRegion
                    };
                    Ukraine.Nodes.Add(Region);
                    a++;

                    RegionSES = new TreeNode
                    {
                        Text = Resources.stringRegionSES,
                        ImageIndex = 1,
                        SelectedImageIndex = 1,
                        Tag = VARI.ID_Region,
                        Name = Resources.constRegionCEC
                    };

                    Region.Nodes.Add(RegionSES);

                    EcologyDepartment = new TreeNode
                    {
                        Text = Resources.stringDepartmentECO,
                        ImageIndex = 2,
                        SelectedImageIndex = 2,
                        Tag = VARI.ID_Region,
                        Name = Resources.constDepartmentECO
                    };

                    Region.Nodes.Add(EcologyDepartment);

                    RAW = new TreeNode
                    {
                        Text = Resources.stringRegionRAW,
                        ImageIndex = 3,
                        SelectedImageIndex = 3,
                        Tag = VARI.ID_Region,
                        Name = Resources.constRegionAgencyWarer

                    };

                    Region.Nodes.Add(RAW);


                    foreach (var VARIABLE in tDistrict.FindAll())
                    {
                        if (VARIABLE.tRegion.ID_Region == VARI.ID_Region)
                        {
                            TreeNode District = new TreeNode
                            {

                                Text = VARIABLE.District,
                                ImageIndex = 5 + a,
                                SelectedImageIndex = 5 + a,
                                Tag = VARIABLE.ID_District,
                                Name = Resources.constDistrict
                            };
                            Region.Nodes.Add(District);
                            a++;

                            DistrictSES = new TreeNode
                            {
                                Text = Resources.stringDistrictSES,
                                ImageIndex = 4,
                                SelectedImageIndex = 4,
                                Tag = VARIABLE.ID_District,
                                Name = Resources.constDistrictCEC
                            };

                            District.Nodes.Add(DistrictSES);

                        }
                    }
                }
                MainTreeView.Nodes[0].Expand();
            }
            catch (Exception)
            {
                
                
            }

           
            

        }

        public static void SelectNode(TreeNode trn)
        {
            Program.fMainPlacements.lsvMain.Items.Clear();

            if (trn.Name==Resources.constRegion)
            {
                Program.fMainPlacements.tspPlaceman_Add.Enabled = true;
                Program.fMainPlacements.lsvMain.Enabled = true;

                Program.fMainPlacements.grbProperty.Text = trn.Text.Substring(0,trn.Text.IndexOf(" "))+" ОДА";

                cRegion.cRSA.cPlacementsRSA.LV(trn);

               
            }
            else if (trn.Name == Resources.constRegionCEC)
            {
                Program.fMainPlacements.tspPlaceman_Add.Enabled = true;
                
                Program.fMainPlacements.lsvMain.Enabled = true;

                Program.fMainPlacements.grbProperty.Text = trn.Parent.Text +": "+ trn.Text;

                cRegion.cRegionCEC.cPlacementRegionCEC.LV(trn);


            }
            else if (trn.Name == Resources.constDepartmentECO)
            {
                Program.fMainPlacements.tspPlaceman_Add.Enabled = true;
                Program.fMainPlacements.lsvMain.Enabled = true;
                
                Program.fMainPlacements.grbProperty.Text = trn.Parent.Text + ": " + trn.Text;

                cRegion.cDepartmentECO.cPlacementsDepEco.LV(trn);
            }

            else if (trn.Name == Resources.constRegionAgencyWarer)
            {
                Program.fMainPlacements.tspPlaceman_Add.Enabled = true;
                Program.fMainPlacements.lsvMain.Enabled = true;
                Program.fMainPlacements.grbProperty.Text = trn.Parent.Text + ": " + trn.Text;

                cRegion.cRegionAgencyWarer.cPlacementsRAW.LV(trn);
            }

            else if (trn.Name == Resources.constDistrict)
            {
                Program.fMainPlacements.tspPlaceman_Add.Enabled = true;
                Program.fMainPlacements.lsvMain.Enabled = true;
                Program.fMainPlacements.grbProperty.Text = trn.Parent.Text + ": " + trn.Text;

                cDistrict.cDSA.cPlacementsDSA.LV(trn);
            }

            else if (trn.Name == Resources.constDistrictCEC)
            {
                Program.fMainPlacements.tspPlaceman_Add.Enabled = true;
                Program.fMainPlacements.lsvMain.Enabled = true;
                Program.fMainPlacements.grbProperty.Text = trn.Parent.Text + ": " + trn.Text;

                cDistrict.cDistrictCEC.cPlacementsDistrictCEC.LV(trn);
            }


            else
            {
                //Program.fMainPlacements.tspPlaceman_Add.Enabled = false;
               // Program.fMainPlacements.lsvMain.Enabled = false;
                Program.fMainPlacements.grbProperty.Text = trn.Text;
            }


        }

       
    }
}
