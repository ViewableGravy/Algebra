using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algebra
{
    public static class BoolClass
    {

        public static bool IsNumber(string val)
        {
            return decimal.TryParse(val, out decimal i);

            /*
            foreach (char c in val)
            {
                if (c != '.' && !char.IsDigit(c))
                {
                    Console.WriteLine(c);
                    return false;
                }
            }
            return true;
            */
    }

        public static bool IsChar(string val)
        {
            foreach (char c in val)
            {
                if (!char.IsLetter(c))
                    return false;
            }
            return true;
        }

        
    }
}
