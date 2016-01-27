using System;

namespace Make.Coffee
{
    class Program
    {
        static void Main(string[] args)
        {
            var brewUp = new BrewUp(new FillKettle(new BoilKettle(new AddCoffeeToCup(null))));

            brewUp.CuppaFather();

            Console.ReadKey();
        }
    }
}
