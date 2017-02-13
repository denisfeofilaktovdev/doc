using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Placements.src;

namespace Placements
{
    static class Program
    {

        public static frmMainPlacements fMainPlacements ;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            fMainPlacements=new frmMainPlacements();
           // fMainPlacements.lsvMain.Enabled = false;
            fMainPlacements.tspPlaceman_Add.Enabled = false;
            Application.Run(fMainPlacements);
        }
    }
}
