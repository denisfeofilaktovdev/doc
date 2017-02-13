using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Placements.db;

namespace Placements.src
{
    public partial class frmAdressDepartament : Form
    {
        private List<tRegion> regionList;



        private List<tDistrict> districtlList;

        public frmAdressDepartament()
        {
            InitializeComponent();

            regionList = new List<tRegion>();
            districtlList = new List<tDistrict>();

            foreach (var VARIABLE in tRegion.FindAll())
            {
                regionList.Add(VARIABLE);
            }
            foreach (var VARIABLE in regionList)
            {
                Region.Items.Add(VARIABLE.Region);
            }

            foreach (var VARIABLE in tDistrict.FindAll())
            {
                districtlList.Add(VARIABLE);
            }

            PostIndex.Select();
            PostIndex.Focus();


        }

        
        private void Region_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            int ID_Region = 0;
            District.Items.Clear();

            if (Region.SelectedIndex != -1)
            {
                foreach (var VARIABLE in regionList)
                {
                    if (VARIABLE.Region == Region.SelectedItem)
                    {
                        ID_Region = VARIABLE.ID_Region;

                    }
                }

                foreach (var VARIABLE in districtlList)
                {
                    if (VARIABLE.tRegion.ID_Region == ID_Region)
                    {
                        District.Items.Add(VARIABLE.District);
                    }
                }
            }

           SettlementName.Text = ToponimName.Text = Building.Text = OfficeName.Text =
           OfficeType.Text = SettlementType.Text = ToponimType.Text = Corpus.Text = null;
        }

       

       

        public void SetDistrict(ComboBox cmdRegion, ComboBox cmdDistrict)
        {

            

        }
    }
}
