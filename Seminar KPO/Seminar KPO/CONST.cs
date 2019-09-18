using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_KPO
{
    class CONST: Identificator
    {
        object Value{ get;set;}

        public CONST(string name, int hash, UsageMethods usageMethod, Types type, object value)
            :base(name, hash, usageMethod, type)
        {
            Value = value;
        }
        
    }
}
