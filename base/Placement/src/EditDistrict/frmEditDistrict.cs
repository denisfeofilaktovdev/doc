using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Placements.main;

namespace Placements.src
{
    public partial class frmEditDistrict : Form
    {
        
       
        public frmEditDistrict()
        {
            InitializeComponent();

            txtNameDistrict.Select();

            txtNameDistrict.Focus();


        }

        

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            cDistrict.AddImage(openDialog);
        }
    }
}
