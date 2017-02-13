using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Placements.Properties;

namespace Placements.db
{
    public partial class tRegionalStateAdministration
    {
        public static tRegionalStateAdministration byID(int idRSA)
        {
            IList<tRegionalStateAdministration> tmpAreas = FindAllByProperty("ID_RSA", idRSA);
            if (tmpAreas.Count == 1)
                return tmpAreas[0];

            return null;
        }

        
    }
}
