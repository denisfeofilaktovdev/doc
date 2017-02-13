using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placements.db
{
    public partial class tDistrictStateAdministration
    {
        public static tDistrictStateAdministration byID(int idDSA)
        {
            IList<tDistrictStateAdministration> tmpAreas = FindAllByProperty("ID_DSA", idDSA);
            if (tmpAreas.Count == 1)
                return tmpAreas[0];

            return null;
        }
    }
}
