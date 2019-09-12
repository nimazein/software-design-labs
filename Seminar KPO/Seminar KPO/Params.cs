using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_KPO
{
    class Params
    {
        Types Type { get; set; }
        TransferType ParamType { get; set; }
        public Params(Types type, TransferType paramType)
        {
            Type = type;
            ParamType = paramType;
        }
    }
}
