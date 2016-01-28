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
                switch (args[0].ToLower())
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
                        Console.WriteLine("Sorry, we couldn't find your beverage");
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
