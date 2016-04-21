using System;
using System.Collections.Generic;
using Make.Coffee.Steps;

namespace Make.Coffee
{
    class Program
    {
        //private List<Type> _extras = new List<Type>
        //{
        //    typeof()
        //}; 

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Sorry, we couldn't find your beverage");
            }
            else
            {
                var commandLineArgs = new CommandLineArgsParser(args);

                var extras = GetExtras(commandLineArgs);
                

                switch (commandLineArgs["drink"].ToLower())
                {
                    case "tea":
                        var tea = new Tea(null);
                        tea.CuppaFather();
                        break;
                    case "coffee":
                        var coffee = new Coffee(null);
                        coffee.CuppaFather();
                        break;
                    default:
                        Console.WriteLine("Sorry, we couldn't find your beverage. Would you like a cuppa Tea, Father?");
                        break;
                }
            }

            Console.ReadKey();
        }

        //private static Extra[] GetExtras(CommandLineArgsParser commandLineArgs)
        //{
        //    var extras = new List<Extra>();

        //    if (commandLineArgs["sugar"] != null)
        //    {
        //        var sugar = int.Parse(commandLineArgs["sugar"]);
        //        extras.Add(new AddSugar(null, sugar));
        //    }

        //    return extras.ToArray();
        //}

        private IStep BuildExtras(CommandLineArgsParser args)
        {

            IStep currentStep = 1stStep;
            foreach (var extra in extras)
            {
                var newStep = currentStep(extra.step);
                
            }
        }
    }
}
