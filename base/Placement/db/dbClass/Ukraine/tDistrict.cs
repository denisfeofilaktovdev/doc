using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placements.db
{
    public partial class tDistrict
    {
        public static tDistrict byID(int idDistrict)
        {
            IList<tDistrict> tmpAreas = FindAllByProperty("ID_District", idDistrict);
            if (tmpAreas.Count == 1)
                return tmpAreas[0];

            return null;
        }

       

    }
}
