// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * while !EOF
 * parse
 * validate
 * add/error
 * 
 */
/*
 * error lookup
 * 1 = symbol > 12
 * 2 = not alphanumeric
 * 4 = first symbol not a letter
 * 8 = not valid rFlag
 * 16 = value not valid
 * 32 = multiple (set mFlag to true)
 */
namespace SymTabOckwig 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BST SymbolTable = new BST();
            string[] LineValues = System.IO.File.ReadAllLines("Symbols.dat");
            string[] CurrentLine;
            foreach (string LineValue in LineValues)
            {
                CurrentLine = Validation.parseline(LineValue);
                string symbol = Validation.formatSymbol(CurrentLine[0]);//Symbol is formatted

                byte errorCode;
                errorCode = Validation.checkSymbol(CurrentLine[0]);
                //byte now has error code. 0 means good data

                bool rFlag = false;
                int flag = Validation.checkRFlag(CurrentLine[1]);
                if (flag == 1)
                {
                    rFlag = true;
                }
                else if (flag == 0)
                {
                    rFlag = false;
                }
                else
                {
                   
                    errorCode += 8;
                    //Flag was not in valid input format (true,false,1,0)
                }
                int value = 0;
                if (Validation.checkValue(CurrentLine[2]))
                {
                    value = Validation.formatValue(CurrentLine[2]);
                }
                else
                {
                    errorCode += 16;
                }
                if (errorCode == 0)
                {
                    if (!SymbolTable.AddNode(symbol, value, rFlag))
                    {
                        errorCode += 32;
                    }
                }
                Validation.showError(errorCode,symbol, CurrentLine);
           
            }
            Console.WriteLine("Symbol    RFlag  MFlag  IFlag  Value");
            BST.LeftTraverse(SymbolTable.Root);
        }
    }
}


