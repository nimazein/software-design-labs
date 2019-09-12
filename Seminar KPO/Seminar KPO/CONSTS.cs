using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_KPO
{
    class CONSTS: Identificator
    {
        string Value{ get;set;}

        public CONSTS(string name, int hash, UsageMethods usageMethod, Types type, string value)
            :base(name, hash, usageMethod, type)
        {
            Value = value;
        }
    }
}
