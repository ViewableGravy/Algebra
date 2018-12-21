using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algebra
{
    public static class DisplayLists
    {
        public static int DisplayFunctionality()
        {
            int i = 0;
            while (i < 1)
            {
                Console.WriteLine("The following are a list of available functionality");
                Console.WriteLine(" 1: exit");
                Console.WriteLine(" 2: variable manipulation");
                Console.WriteLine(" 3: variable addition");
                Console.WriteLine(" 4: Use Program");
                Console.WriteLine("Enter a value to see a list of available commands");
                i = DisplayCommands();
            }
            if (i == 1)
            {
                return 1;
            } else
                return 0;
        }

        public static int DisplayCommands()
        {
            bool chosen = false;
            //DisplayCommands();
            while (chosen == false) {
                int choice = Convert.ToInt16(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        return 1;
                    case 2:
                        return DisplayVariableCommands();
                    case 3:
                        return DisplayAddOptions();
                    case 4:
                        return 2;
                    default:
                        break;
                }
                Console.WriteLine("Please Enter a Valid Number");
            }
            return 1;
        }

        private static int DisplayVariableCommands()
        {
            Console.WriteLine();
            Console.WriteLine("Variable commands are in the format as follows");
            Console.WriteLine(" 1: Create \"variable name\" as \"value\"");
            Console.WriteLine("      e.g. \"create d as 5\" creates the variable d with the value 5");
            Console.WriteLine(" 2: To Implement ");
            Console.WriteLine("      Modify variable values");
            Console.WriteLine(" Click Enter to Continue ");
            Console.ReadKey();
            return 0;
        }

        private static int DisplayAddOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Variable addition commands are in the following format");
            Console.WriteLine(" 1: Add \"variable\" and \"variable\" ... ");
            Console.WriteLine("      e.g. \"Add test1 and test2\" will add the variables together");
            Console.WriteLine("      note that this will work for \"n\" values");
            Console.WriteLine("   ");
            Console.WriteLine(" Click Enter to Continue ");
            Console.ReadKey();
            return 0;
        }
    }
}
