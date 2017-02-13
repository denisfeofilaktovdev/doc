using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placements.db
{
    public partial class tPlacementsDepEco
    {
        public static tPlacementsDepEco byID(int idPlacemanRegionCEC)
        {
            IList<tPlacementsDepEco> tmpAreas = FindAllByProperty("ID_PlacementDepEco", idPlacemanRegionCEC);
            if (tmpAreas.Count == 1)
                return tmpAreas[0];

            return null;
        }


        public static IList<tPlacementsDepEco> byDepECO(int idDepECO)
        {


            IList<tPlacementsDepEco> tmpRP =
                tDepartmentECO.Find(tDepartmentECO.byID(idDepECO).ID_DepartmentECO).tPlacementsDepEcoes;
                    

            return tmpRP;
        }
    }
}
