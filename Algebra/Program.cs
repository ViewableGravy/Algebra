using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algebra
{
    public class Program
    {
        static void Main(string[] args)
        {
           // Console.WriteLine("enter variable name");

            int Menu = 0;
            bool runProgram = true;
            string[] cmd;
            string[] response;
            CreateVariableCommand crtCommand = new CreateVariableCommand();
            AddCommand addCommand = new AddCommand();
            AllVariables Variables = new AllVariables();

            while (Menu < 1)
            {
                Menu = DisplayLists.DisplayFunctionality();

                if (Menu < 1) {
                    while (runProgram == true) {
                        Console.WriteLine("Enter Command");
                        cmd = Console.ReadLine().Split(new char[] { ' ' });
                        switch (cmd[0].ToLower())
                        {
                            case "exit":
                                runProgram = false;
                                break;
                            case "create":
                                try {
                                    response = crtCommand.Execute(cmd,Variables).Split(new char[] { ' ' });
                                    Variables.CreateVariable(response[1], float.Parse(response[2]));
                                }
                                catch (Exception ex) { Console.WriteLine(ex.Message); }
                                break;
                            case "add":
                                try
                                {
                                    Console.WriteLine(addCommand.Execute(cmd, Variables));
                                }
                                catch (Exception ex) { Console.WriteLine(ex.Message); }
                                break;

                            default:
                                Console.WriteLine("Invalid command");
                                break;
                        }

                        for (int j = 0; j < Variables._variables.Count(); j++)
                        {
                            Console.WriteLine(Variables._variables[j].Name);
                            Console.WriteLine(Variables._variables[j].Value);
                        }
                    }
                }
            }
        }

        
    }
}
