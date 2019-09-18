using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_KPO
{
    class Node
    {
        public Identificator Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node()
        {

        }
        public Node(Identificator value)
        {
            Value = value;
        }
    }
}
