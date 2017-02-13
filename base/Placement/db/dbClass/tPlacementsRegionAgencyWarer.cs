using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placements.db
{
    public partial class tPlacementsRegionAgencyWarer
    {

        public static tPlacementsRegionAgencyWarer byID(int idPlacemanRAW)
        {
            IList<tPlacementsRegionAgencyWarer> tmpAreas = FindAllByProperty("ID_PlacementsRAW", idPlacemanRAW);
            if (tmpAreas.Count == 1)
                return tmpAreas[0];

            return null;
        }
        
        public static IList<tPlacementsRegionAgencyWarer> byRAW(int idRAW)
        {


            IList<tPlacementsRegionAgencyWarer> tmpRP =
                tRegionAgencyWarer.Find(tRegionAgencyWarer.byID(idRAW).ID_RAW).tPlacementsRegionAgencyWarers;


            return tmpRP;
        }
    }
}
