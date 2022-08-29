using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SymTabOckwig
{
    internal class Validation
    {

        public static byte checkSymbol(string symbol)
        {
            byte errorCode = 0;
            //https://www.techiedelight.com/check-string-consists-alphanumeric-characters-csharp/#:~:text=Using%20Regular%20Expression,%2C%20use%20%2B%20instead%20of%20*%20.
            if(symbol.Length > 12)
            {
                errorCode += 1;
            }
            
            if (!Regex.IsMatch(symbol, "^[a-zA-Z0-9]*$"))
            {
                errorCode += 2;
            }

            if (!char.IsLetter(symbol.FirstOrDefault()))
            {
                errorCode += 4;
            }

            return errorCode;
        }
        public static string formatSymbol(string symbol)
        {
            if(symbol.Length>6)
            {
                symbol = symbol.Substring(0,6);
            }
            return symbol;
        }
        public static int checkRFlag(string rFlag)
        {
            if (rFlag.Equals("true") || rFlag.Equals("1"))
                return 1;
            else if (rFlag.Equals("false") || rFlag.Equals("0"))
                return 0;
            else
                //-1 will indicate that the given input was invalid
            return -1;
        }
        public static bool checkValue(string value)
        {
            //https://stackoverflow.com/questions/894263/identify-if-a-string-is-a-number
            if (int.TryParse(value, out _))
            {
                return true;
            }

         return false;
        }
        public static int formatValue(string value)
         {
            int val;
            int.TryParse(value, out val);
            return val;

        }
        public static string[] parseline(String line)
        {
            //ABCDEFgh: true 100
            line = line.Trim(' ');
            string[] result = line.Split(' ');
            // result[0] = Symbol
            // result[1] = rFlag
            // result[2] = value
            result[0] = result[0].TrimEnd(':');
            return result;
        }
        /*
 * error lookup
 * 1 = symbol > 12
 * 2 = not alphanumeric
 * 4 = first symbol not a letter
 * 8 = not valid rFlag
 * 16 = value not valid
 * 32 = multiple (set mFlag to true)
 */
        public static void showError(byte errorCode,string symbol, string[] line)
        {
            if(errorCode % 2 == 1)
                Console.WriteLine("ERROR - " + symbol + " has a symbol greater than 12 characters");
            errorCode /= 2;
            if (errorCode % 2 == 1)
                Console.WriteLine("ERROR - " + symbol + " is not alphanumeric");
            errorCode /= 2;
            if (errorCode % 2 == 1)
                Console.WriteLine("ERROR - " + symbol + " first symbol must be a letter");
            errorCode /= 2;
            if (errorCode % 2 == 1)
                Console.WriteLine("ERROR - " + symbol + " does not have a valid RFlag");
            errorCode /= 2;
            if (errorCode % 2 == 1)
                Console.WriteLine("ERROR - " + symbol + " does not have a valid value. " + line[2]);
        }



    }
}
