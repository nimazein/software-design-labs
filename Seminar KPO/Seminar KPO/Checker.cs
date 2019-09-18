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
        public object CreateObject(Types type, string value)
        {
            object objectValue = new object();
            if (type == Types.string_type)
            {
                if (value.Contains(@""""))
                {
                    string buf = value.Replace(@"""", "");
                    objectValue = buf;
                }
                else
                {
                    throw new Exception("Type does not match value");
                }
            }
            else if (type == Types.char_type)
            {
                if (value.Contains(@"'"))
                {
                    string buf = value.Replace("'", "");
                    char charValue;
                    if (char.TryParse(buf, out charValue))
                    {
                        objectValue = charValue;
                    }
                    else
                    {
                        throw new Exception("Type does not match value");
                    }
                }
                else
                {
                    throw new Exception("Type does not match value");
                }
            }
            else if (type == Types.bool_type)
            {
                bool boolValue;
                if (bool.TryParse(value, out boolValue))
                {
                    objectValue = boolValue;
                }
                else
                {
                    throw new Exception("Type does not match value");
                }
            }
            else if (type == Types.int_type)
            {
                int intValue;
                if (int.TryParse(value, out intValue))
                {
                    objectValue = intValue;
                }
                else
                {
                    throw new Exception("Type does not match value");
                }
            }
            else if (type == Types.float_type)
            {
                float floatValue;
                if (float.TryParse(value, out floatValue))
                {
                    objectValue = floatValue;
                }
                else
                {
                    throw new Exception();
                }
            }

            return objectValue;
        }
    }
}
