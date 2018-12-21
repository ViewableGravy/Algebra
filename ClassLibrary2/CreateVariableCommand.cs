using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Algebra
{
    public class CreateVariableCommand
    {
        public CreateVariableCommand()
        {
        }

        public string Execute(string[] var, AllVariables vars)
        {
            if (var.Length == 4)
            {
                if (IsChar(var[1]) && !Exist(var[1],vars))
                {
                    if (var[2] == "as")
                    {
                        if (IsNumber(var[3]))
                        {
                            return "Variable: " + var[1] + " " + var[3];
                        }
                        throw new CreateVariableCommandException("this is not a number");
                    }
                    throw new CreateVariableCommandException("third word must be \"as\"");
                }
                throw new CreateVariableCommandException("please choose a valid variable name");
            }
            throw new CreateVariableCommandException("this is not a valid command");
        }

        private bool Exist(string var, AllVariables vars)
        {
            foreach (Variable vr in vars._variables)
            {
                if (var == vr.Name)
                {
                    throw new CreateVariableCommandException("The variable already exists. Please Use the \"Modify Command\"");
                }
            }
            return false;
        }

        private bool IsNumber(string val)
        {
            foreach( char c in val)
            {
                if (c != '.' && !char.IsDigit(c))
                {
                    Console.WriteLine(c);
                    return false;
                }
            }
            return true;
        }

        private bool IsChar(string val)
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
