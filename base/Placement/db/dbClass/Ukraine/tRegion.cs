using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placements.db
{
    public partial class tRegion
    {
        public static tRegion byID(int idRegion)
        {
            IList<tRegion> tmpAreas = FindAllByProperty("ID_Region", idRegion);
            if (tmpAreas.Count == 1)
                return tmpAreas[0];

            return null;
        }

    }
}
