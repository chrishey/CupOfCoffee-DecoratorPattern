using Make.Coffee.Steps;

namespace Make.Coffee
{
    public class BrewUp
    {
        private readonly IStep _step;

        public BrewUp(IStep step)
        {
            _step = step;
        }

        public void CuppaFather()
        {
            _step.Do();
        }
    }
}
