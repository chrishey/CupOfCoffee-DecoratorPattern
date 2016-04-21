using Make.Coffee.Steps;

namespace Make.Coffee
{
    public class Tea : BrewUp
    {
        public Tea(IStep step) : base (new FillKettle(new BoilKettle(new AddTeaBag(new AddMilk(step)))))
        {
        }
    }
}
