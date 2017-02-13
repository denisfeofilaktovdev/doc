using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placements.db
{
    public partial class tPlacementsDistrictStateAdministration
    {
        public static tPlacementsDistrictStateAdministration byID(int idPlacemanDSA)
        {
            IList<tPlacementsDistrictStateAdministration> tmp= FindAllByProperty("ID_PlacementsDSA", idPlacemanDSA);
            if (tmp.Count == 1)
                return tmp[0];

            return null;
        }

        public static IList<tPlacementsDistrictStateAdministration> byDSA(int idDSA)
        {


            IList<tPlacementsDistrictStateAdministration> tmp =
                tDistrictStateAdministration.Find(tDistrictStateAdministration.byID(idDSA).ID_DSA).tPlacementsDistrictStateAdministrations;


            return tmp;
        }

       


    }
}
