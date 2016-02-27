using System.Linq;
using Make.Coffee.Steps;

namespace Make.Coffee
{
    public class Tea : BrewUp
    {
        private readonly Extra[] _extras;

        public Tea(Extra[] extras) : base (new FillKettle(new BoilKettle(new AddTeaBag(new AddMilk(null)))))
        {
            _extras = extras;
        }

        public new void CuppaFather()
        {
            base.CuppaFather();

            if (_extras.Any())
            {
                foreach (var extra in _extras)
                {
                    var step = extra as IStep;
                    if (step != null) step.Do();
                }
            }
        }
    }
}
