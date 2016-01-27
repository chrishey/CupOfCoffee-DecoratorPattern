using System;

namespace Make.Coffee
{
    class Program
    {
        static void Main(string[] args)
        {
            var brewUp = new BrewUp(new FillKettle(null));

            brewUp.CuppaFather();

            Console.ReadKey();
        }
    }
}
