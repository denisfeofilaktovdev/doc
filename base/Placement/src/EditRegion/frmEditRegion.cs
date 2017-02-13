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
using Placements.main;

namespace Placements.src
{
    public partial class frmEditRegion : Form
    {
        public frmEditRegion()
        {
            InitializeComponent();

            txtNameRegion.Select();

            txtNameRegion.Focus();
        }

        

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            cRegion.AddImage(openDialog);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }
    }
}
