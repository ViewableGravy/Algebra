using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algebra
{
    public static class AssignCommand
    {
        public static string Execute(string[] text, ref AllVariables vars)
        {
            if (text.Length != 4)
                throw new AssignCommandException("incorrect command length");
            if (!BoolClass.IsNumber(text[1]))
                throw new AssignCommandException("not a number");
            if (text[2] != "to")
                throw new AssignCommandException("incorrect format");
            if (!vars.Exist(text[3]))
                throw new AssignCommandException("Variable does not exist");
            string output = $"Variable {text[3]} does not exist";
            foreach (Variable vr in vars._variables)
            {
                if (text[3] == vr.Name)
                {
                    float.TryParse(text[1], out float val);
                    vr.Value = val;
                    output = $"successfully assigned the value {text[1]} to {text[3]}"; 
                }
            }
            return output;


 
            // else if{ BoolClass.IsFunction(); }

            //Format: "assign ( Group => (int) ) to (variable)"
            //Format: "assign ( float ) to (variable)"

            //Group = string from [1] to [string.length - 3]
        }



    }
}
