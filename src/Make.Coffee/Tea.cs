using Make.Coffee.Steps;

namespace Make.Coffee
{
    public class Tea : BrewUp
    {
        public Tea() : base (new FillKettle(new BoilKettle(new AddTeaBag(null))))
        {
            
        }
    }
}
