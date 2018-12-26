using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Algebra
{
    public static class CreateVariableCommand
    {

        public static string Execute(string[] var, AllVariables vars)
        {
            if (var.Length != 4)
                throw new CreateVariableCommandException($"Length of command should be 4, not {var.Length}");
            if (!BoolClass.IsChar(var[1]))
                throw new CreateVariableCommandException($"{var[1]} is not a valid variable name");
            if (vars.Exist(var[1]))
                throw new CreateVariableCommandException($"the variable {var[1]} already exists");
            if (var[2] != "as")
                throw new CreateVariableCommandException($"third word must be \"as\", not {var[2]}");
            if (!BoolClass.IsNumber(var[3]))
                throw new CreateVariableCommandException($"{var[3]} is not a number");
            return $"Variable: {var[1]} {var[3]}";
        }
    }
}
