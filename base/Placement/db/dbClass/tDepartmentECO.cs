using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placements.db
{
    public partial class tDepartmentECO
    {
        public static tDepartmentECO byID(int idDepECO)
        {
            IList<tDepartmentECO> tmpAreas = FindAllByProperty("ID_DepartmentECO", idDepECO);
            if (tmpAreas.Count == 1)
                return tmpAreas[0];

            return null;
        }
    }
}
