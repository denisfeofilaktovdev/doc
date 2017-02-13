using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placements.db
{
    public partial class tPlacementsDistrictCEC
    {
        public static tPlacementsDistrictCEC byID(int idPlacemanDistrictCEC)
        {
            IList<tPlacementsDistrictCEC> tmp = FindAllByProperty("ID_PlacementsDistrictCEC", idPlacemanDistrictCEC);
            if (tmp.Count == 1)
                return tmp[0];

            return null;
        }

        public static IList<tPlacementsDistrictCEC> byDistrictCEC(int idDistrictCEC)
        {


            IList<tPlacementsDistrictCEC> tmp =
                tDistrictCEC.Find(tDistrictCEC.byID(idDistrictCEC).ID_DistrictCEC).tPlacementsDistrictCECs;


            return tmp;
        }

    }
}
