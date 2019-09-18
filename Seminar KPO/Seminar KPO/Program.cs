using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Seminar_KPO
{
    class Program
    {      
       
        static void Main(string[] args)
        {
            string filePath = "input.txt";
            StreamReader codeReader = new StreamReader(filePath);

            FileParser parser = new FileParser();
            List<Identificator> entries = parser.ParseFile(codeReader);

            BinaryTree tree = new BinaryTree();
            Node root = tree.FillTreeWithValues(entries);

            codeReader.Close();
        }
        






























       
        
    }
}
