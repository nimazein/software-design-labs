using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Seminar_KPO
{
    class FileParser
    {
        public List<Identificator> ParseFile(StreamReader codeReader)
        {
            List<Identificator> entries = new List<Identificator>();
            Checker checker = new Checker();
            while (!codeReader.EndOfStream)
            {
                string currentString = codeReader.ReadLine();
                if (!string.IsNullOrWhiteSpace(currentString))
                {
                    CheckCurrentString(currentString, entries);
                }
            }
            return entries;
            
        }
        static void CheckCurrentString(string currentString, List<Identificator> entries)
        {
            Checker checker = new Checker();
            if (currentString.Contains("class"))
            {
                CreateClassEntry(currentString, entries, checker);
            }
            else if (currentString.Contains("const"))
            {
                CreateConstEntry(currentString, entries, checker);
            }
            else if (ContainsMethod(currentString))
            {
                CreateMethodEntry(currentString, entries, checker);
            }
            else if (ContainsVar(currentString))
            {
                CreateVarEntry(currentString, entries, checker);
            }
            else
            {
                throw new Exception("Конструкций языка в строке не найдено");
            }

        }
        static void CreateClassEntry(string str, List<Identificator> entries, Checker checker)
        {
            string name = str.Replace("class ", "");
            int hash = name.GetHashCode();
            CLASS classEntry = new CLASS(name, hash, UsageMethods.CLASSES, Types.class_type);

            entries.Add(classEntry);
        }
        static void CreateConstEntry(string str, List<Identificator> entries, Checker checker)
        {
            Regex lineWithConst = new Regex(@"\s*(const)\s+(?<constType>(string|int|char|float|bool))\s+(?<constName>\w+\d*)\s+\=\s+(?<constValue>\W*([\w+\s*]+|[\d+\W*]+)\W*)\;");
            Match constMatch = lineWithConst.Match(str);

            if (constMatch.Success)
            {
                string constType = constMatch.Groups["constType"].Value;
                string constName = constMatch.Groups["constName"].Value;
                string constValue = constMatch.Groups["constValue"].Value;
                int hash = constName.GetHashCode();

                Types type = checker.DefineType(constType);
                checker.CreateObject(type, constValue);

                CONST constEntry = new CONST(constName, hash, UsageMethods.CONSTS, type, constValue);

                entries.Add(constEntry);
            }
            else
            {
                throw new Exception("Regex does not match");
            }
        }
        static void CreateVarEntry(string str, List<Identificator> entries, Checker checker)
        {
            Regex lineWithVar = new Regex(@"\s*(?<varType>(string|int|char|float|bool))\s+(?<varName>\w+\d*)\s*;");
            Match varMatch = lineWithVar.Match(str);

            if (varMatch.Success)
            {
                string varType = varMatch.Groups["varType"].Value;
                string varName = varMatch.Groups["varName"].Value;
                int hash = varName.GetHashCode();

                Types type = checker.DefineType(varType);

                VAR varEntry = new VAR(varName, hash, UsageMethods.VARS, type);

                entries.Add(varEntry);
            }
            else
            {
                throw new Exception("Regex does not match");
            }
        }
        static void CreateMethodEntry(string str, List<Identificator> entries, Checker checker)
        {

            Regex methodDefaulSignature = new Regex(@"\s*(?<methodType>(int|char|float|bool|void|string))\s+(?<methodName>[\w+\d*]+)\s*\((?<methodArguments>.*)\)\s*");
            Match methodMatch = methodDefaulSignature.Match(str);

            if (methodMatch.Success)
            {
                string methodType = methodMatch.Groups["methodType"].Value;
                string methodName = methodMatch.Groups["methodName"].Value;
                string methodArguments = methodMatch.Groups["methodArguments"].Value;

                METHOD method = new METHOD(methodName, methodName.GetHashCode(), UsageMethods.METHODS, checker.DefineType(methodType), methodArguments);

                entries.Add(method);
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
