using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algebra
{
    public static class AddCommand
    {

        public static string Execute(string[] text, AllVariables vars)
        {
            float count = 0;
            for (int i = 2; i < text.Length - 1; i = i + 2)
            {
                if (text[i] != "and")
                {
                    throw new AddCommandException("please check your \"and's\"");
                }  
            }
            Variable last = vars._variables.Last();
            for (int i = 1; i < text.Length; i = i + 2)
            {
                if (BoolClass.IsNumber(text[i]))
                {
                    count = count + float.Parse(text[i]);
                }
                else
                {
                    foreach (Variable var in vars._variables)
                    {
                        if (text[i] == Convert.ToString(var.Name))
                        {
                            count = count + var.Value;
                            break;
                        }
                        else if (var == last)
                            if (!BoolClass.IsNumber(text[i].Substring(0, 1)))
                                throw new AddCommandException($"The variable {text[i]} does not currently exist");
                            else
                                throw new AddCommandException($"{text[i]} is not a valid number");
                    }
                }
            }
            return Convert.ToString(count);
        }
    }
}
