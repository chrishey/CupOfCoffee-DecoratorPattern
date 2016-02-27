using System;

namespace Make.Coffee
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Sorry, we couldn't find your beverage");
            }
            else
            {
                var commandLineArgs = new CommandLineArgsParser(args);

                switch (commandLineArgs["drink"].ToLower())
                {
                    case "tea":
                        var tea = new Tea();
                        tea.CuppaFather();
                        break;
                    case "coffee":
                        var coffee = new Coffee();
                        coffee.CuppaFather();
                        break;
                    default:
                        Console.WriteLine("Sorry, we couldn't find your beverage. Would you like a cuppa Tea, Father?");
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
