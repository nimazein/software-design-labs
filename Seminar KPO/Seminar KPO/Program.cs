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
        private static BinaryTree tree = new BinaryTree();
        private static Identificator root = null;

        private static List<Identificator> entries = new List<Identificator>();
        private static Checker checker = new Checker();
        static void Main(string[] args)
        {
            string filePath = "input.txt";
            StreamReader CodeReader = new StreamReader(filePath);

            while (!CodeReader.EndOfStream)
            {
                string currentString = CodeReader.ReadLine();
                if (!checker.IsEmpty(currentString))
                { 
                    CheckCurrentString(currentString);
                }
            }
            CodeReader.Close();
        }
        static void CheckCurrentString(string currentString)
        {
            if (currentString.Contains("class"))
            {
                CreateClassEntry(currentString);
            }
            else if (currentString.Contains("const"))
            {
                CreateConstEntry(currentString);
            }       
            else if (ContainsMethod(currentString))
            {
                CreateMethodEntry(currentString);
            }
            else if (ContainsVar(currentString))
            {
                CreateVarEntry(currentString);
            }

        }
        static void CreateClassEntry(string str)
        {
            string name = str.Replace("class ", "");
            int hash = name.GetHashCode();
            CLASSES classEntry = new CLASSES(name, hash, UsageMethods.CLASSES, Types.class_type);

            root = tree.Insert(root, classEntry);
        }
        static void CreateConstEntry(string str)
        {
            Regex lineWithConst = new Regex(@"\s*(const)\s+(?<constType>(string|int|char|float|bool))\s+(?<constName>\w+\d*)\s+\=\s+\W*(?<constValue>([\w+\s*]+|[\d+\W*]+))\W*\;");
            Match constMatch = lineWithConst.Match(str);

            if (constMatch.Success)
            {
                string constType = constMatch.Groups["constType"].Value;
                string constName = constMatch.Groups["constName"].Value;
                string constValue = constMatch.Groups["constValue"].Value;
                int hash = constName.GetHashCode();

                Types type = checker.DefineType(constType);

                CONSTS constEntry = new CONSTS(constName, hash, UsageMethods.CONSTS, type, constValue);

                root = tree.Insert(root, constEntry);

            }
            else
            {
                throw new Exception("Regex does not match");
            }
        }
        static void CreateVarEntry(string str)
        {
            Regex lineWithVar = new Regex(@"\s*(?<varType>(string|int|char|float|bool))\s+(?<varName>\w+\d*)\s*;");
            Match varMatch = lineWithVar.Match(str);

            if (varMatch.Success)
            {
                string varType = varMatch.Groups["varType"].Value;
                string varName = varMatch.Groups["varName"].Value;
                int hash = varName.GetHashCode();

                Types type = checker.DefineType(varType);

                VARS varEntry = new VARS(varName, hash, UsageMethods.VARS, type);

                root = tree.Insert(root, varEntry);
            }
            else
            {
                throw new Exception("Regex does not match");
            }
        }
        static void CreateMethodEntry(string str)
        {

            Regex methodDefaulSignature = new Regex(@"\s*(?<methodType>(int|char|float|bool|void|string))\s+(?<methodName>[\w+\d*]+)\s*\((?<methodArguments>.*)\)\s*");
            Match methodMatch = methodDefaulSignature.Match(str);

            if (methodMatch.Success)
            {
                string methodType = methodMatch.Groups["methodType"].Value;
                string methodName = methodMatch.Groups["methodName"].Value;
                string methodArguments = methodMatch.Groups["methodArguments"].Value;

                METHODS method = new METHODS(methodName, methodName.GetHashCode(), UsageMethods.METHODS, checker.DefineType(methodType), methodArguments);

                root = tree.Insert(root, method);
            }
            else
            {
                throw new Exception("Regex does not match");
            }
        }





























        static bool ContainsMethod(string str)
        {
            // no void? really?
            Regex methodDefaulSignature = new Regex(@"\s*(int|char|float|bool|string){1}\s+\w+\({1}.*\){1}");
            return methodDefaulSignature.IsMatch(str);
            
        }
        static bool ContainsVar(string str)
        {
            Regex varNamingTemplate = new Regex(@".*\W*[(int)(char)(float)(bool)(string)]\s[a-z].*\W*\;");
            return varNamingTemplate.IsMatch(str);  
        }
        
    }
}
