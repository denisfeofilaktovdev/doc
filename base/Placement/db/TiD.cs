using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Placements.db
{
    public class TypeInDb
    {
        public static Type[] TypeInSpace()
        {
            
            return Assembly.GetExecutingAssembly().GetTypes().Where(t => String.Equals(t.Namespace, t.Namespace, StringComparison.Ordinal)).ToArray();
        }
    }
}
