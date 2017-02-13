using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placements.db
{
    public partial class tDistrictCEC
    {

        public static tDistrictCEC byID(int idDistrictCEC)
        {
            IList<tDistrictCEC> tmp = FindAllByProperty("ID_DistrictCEC", idDistrictCEC);
            if (tmp.Count == 1)
                return tmp[0];

            return null;
        }

    }
}
