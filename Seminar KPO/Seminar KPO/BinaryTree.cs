using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_KPO
{
    class BinaryTree
    {
        public Node Root { get; set; }
        public Node FillTreeWithValues(List<Identificator> entries)
        {
            Node root = null;
            foreach (Identificator entry in entries)
            {
                Node newNode = new Node(entry);

                root = Insert(root, newNode);
            }
            return root;
        }
        public Node Insert(Node root, Node newNode)
        {
            if (root == null)
            {
                root = newNode;
            }
            else if (newNode.Value.Hash < root.Value.Hash)
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
