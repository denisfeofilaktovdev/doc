using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placements.db
{
    public partial class tRegionAgencyWarer
    {
        public static tRegionAgencyWarer byID(int idRAW)
        {
            IList<tRegionAgencyWarer> tmpAreas = FindAllByProperty("ID_RAW", idRAW);
            if (tmpAreas.Count == 1)
                return tmpAreas[0];

            return null;
        }
    }
}
