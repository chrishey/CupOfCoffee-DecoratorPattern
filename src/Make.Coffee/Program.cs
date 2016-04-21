using System;
using System.Collections.Generic;

namespace Make.Coffee
{
    using System.Collections;
    using System.Linq;

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

                var extras = GetExtras(commandLineArgs);
                
                switch (commandLineArgs["drink"].ToLower())
                {
                    case "tea":
                        var tea = new Tea(extras);
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

        private static Extra[] GetExtras(CommandLineArgsParser commandLineArgs)
        {
            // ** Spike of using reflection to find extras, then create them at runtime **


            // Gets all types in the AppDomain that derive from Extra
            var allExtraTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(Extra).IsAssignableFrom(p))
                .ToArray();

            var extras = new List<Extra>();
            foreach (DictionaryEntry commandLineArg in commandLineArgs)
            {
                var arg = (string)commandLineArg.Key;
                
                // Ignore reserved arguments
                if (arg.Equals("tea", StringComparison.InvariantCultureIgnoreCase) ||
                    arg.Equals("coffee", StringComparison.InvariantCultureIgnoreCase))
                    continue;
                
                // Try to find an extra that matches this command line argument. Another option would be to add a 'Name' property to each class,
                //  instantiate all Extras and interogate their name properties. This is quicker but requires the class name to match the argument
                var extra = allExtraTypes.FirstOrDefault(e => e.Name.Equals(arg, StringComparison.InvariantCultureIgnoreCase));
                if (extra == null)
                    continue;

                // Create a new instance of the Extra. We know that it has a constructor that takes an int
                var createdSugar = (Extra)Activator.CreateInstance(extra, null, int.Parse((string)commandLineArg.Value));
                extras.Add(createdSugar);
            }
            
            return extras.ToArray();
        }
    }
}
