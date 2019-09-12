using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_KPO
{
    public enum UsageMethods
    {
        CLASSES,
        CONSTS,
        VARS,
        METHODS
    }
    public enum Types
    {
        int_type,
        float_type,
        bool_type,
        char_type,
        string_type,
        class_type
    }

    abstract class Identificator
    {
        public string Name { get; set; }
        public int Hash { get; set; }
        public UsageMethods UsageMethod { get; set; }
        public Types Type { get; set; }
        public Identificator Left { get; set; }
        public Identificator Right { get; set; }
        public Identificator Parent { get; set; }

        public Identificator()
        {

        }
        public Identificator(string name, int hash, UsageMethods usageMethod, Types type)
        {
            Name = name;
            Hash = hash;
            UsageMethod = usageMethod;
            Type = type;
        }

    
    }
}
