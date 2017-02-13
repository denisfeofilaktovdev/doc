using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placements.db
{

    public partial class tPlacementRegionCEC
    {


        public static tPlacementRegionCEC byID(int idPlacemanRegionCEC)
        {
            IList<tPlacementRegionCEC> tmpAreas = FindAllByProperty("ID_PlacementRegionCEC", idPlacemanRegionCEC);
            if (tmpAreas.Count == 1)
                return tmpAreas[0];

            return null;
        }


        public static IList<tPlacementRegionCEC> byRegionCEC(int idRegionCEC)
        {


            IList<tPlacementRegionCEC> tmpRP =
                tRegionCEC.Find(tRegionCEC.byID(idRegionCEC).ID_RegionCEC)
                    .tPlacementRegionCECs;

            return tmpRP;
        }
    }
}
