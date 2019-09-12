using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_KPO
{
    class Checker
    {
        public Types DefineType(string type)
        {
            Types definedType = Types.bool_type;
            switch (type)
            {
                case "string":
                    definedType = Types.string_type;
                    break;

                case "char":
                    definedType = Types.char_type;
                    break;

                case "int":
                    definedType = Types.int_type;
                    break;

                case "float":
                    definedType = Types.float_type;
                    break;

                case "bool":
                    definedType = Types.bool_type;
                    break;
            }
            return definedType;
        }
        public bool IsEmpty(string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
    }
}
