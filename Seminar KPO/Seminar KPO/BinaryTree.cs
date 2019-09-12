using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_KPO
{
    class BinaryTree
    {
        public Identificator Root { get; set; }
        public Identificator Insert(Identificator root, Identificator newNode)
        {
            if (root == null)
            {
                root = newNode;
            }
            else if (newNode.Hash < root.Hash)
            {
                root.Left = Insert(root.Left, newNode);
            }
            else
            {
                root.Right = Insert(root.Right, newNode);
            }
            return root;
        }
    }
}
