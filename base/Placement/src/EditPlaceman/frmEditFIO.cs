using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Placements.src
{
    public partial class frmEditFIO : Form
    {
        public frmEditFIO()
        {
            InitializeComponent();

            txtLastName.Select();

            txtLastName.Focus();
        }
        
    }
}
