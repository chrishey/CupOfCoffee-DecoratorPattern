using Make.Coffee.Steps;

namespace Make.Coffee
{
    public class Coffee : BrewUp
    {
        public Coffee(IStep step) : base(new FillKettle(new BoilKettle(new AddCoffeeToCup(new AddMilk(step)))))
        {
        }
    }
}
