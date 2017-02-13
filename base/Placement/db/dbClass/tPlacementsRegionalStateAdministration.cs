using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Placements.Properties;

namespace Placements.db
{
    public partial class tPlacementsRegionalStateAdministration
    {

        public static tPlacementsRegionalStateAdministration byID(int idPlacemanRSA)
        {
            IList<tPlacementsRegionalStateAdministration> tmpAreas = FindAllByProperty("ID_PlacementsRSA", idPlacemanRSA);
            if (tmpAreas.Count == 1)
                return tmpAreas[0];

            return null;
        }


        public static IList<tPlacementsRegionalStateAdministration> byRSA(int idRSA)
        {


            IList<tPlacementsRegionalStateAdministration> tmpRP =
                tRegionalStateAdministration.Find(tRegionalStateAdministration.byID(idRSA).ID_RSA)
                    .tPlacementsRegionalStateAdministrations;

            return tmpRP;
        }

        
    }
}
