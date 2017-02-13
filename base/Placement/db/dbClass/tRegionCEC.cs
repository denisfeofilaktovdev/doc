using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placements.db
{
    public partial class tRegionCEC
    {
        public static tRegionCEC byID(int idRegionCEC)
        {
            IList<tRegionCEC> tmpAreas = FindAllByProperty("ID_RegionCEC", idRegionCEC);
            if (tmpAreas.Count == 1)
                return tmpAreas[0];

            return null;
        }
    }
}
