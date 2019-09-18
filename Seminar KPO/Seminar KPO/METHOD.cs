using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Seminar_KPO
{
    public enum TransferType
    {
        param_val,
        param_ref,
        param_out,
    }
    class METHOD: Identificator
    {
        Params[] Arguments { get; set; }

        public METHOD(string name, int hash, UsageMethods usageMethod, Types type, string arguments)
            :base (name, hash, usageMethod, type)
        {
            Arguments = GetArgumets(arguments);
        }
        private Params[] GetArgumets(string arguments)
        {          
            char[] splitter = { ',' };
            string[] parametersByOne = arguments.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
            Params[] parameters = new Params[parametersByOne.Length];

            Checker checker = new Checker();

            for (int i = 0; i < parametersByOne.Length; i++)
            {
                Regex singleParameter = new Regex(@"\s*((?<transferType>(ref|out))\s+)*(?<parameterType>(string|int|char|float|bool)).*");
                Match parameterMatch = singleParameter.Match(parametersByOne[i]);

                if (parameterMatch.Success)
                {
                    string transferType = parameterMatch.Groups["transferType"].Value;
                    string parameterType = parameterMatch.Groups["parameterType"].Value;

                    parameters[i] = new Params(checker.DefineType(parameterType), DefineTransferType(transferType));
                }
                else
                {
                    throw new Exception("Regex does not match");
                }
            }
            return parameters;
        }
        private TransferType DefineTransferType(string transType)
        {
            TransferType definedTransferType = TransferType.param_val;
            switch (transType)
            {
                case "":
                    definedTransferType = TransferType.param_val;
                    break;
                case "ref":
                    definedTransferType = TransferType.param_ref;
                    break;
                case "out":
                    definedTransferType = TransferType.param_out;
                    break;

            }
            return definedTransferType;
        }
    }
}
