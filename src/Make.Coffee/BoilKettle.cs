using System;

namespace Make.Coffee
{
    public class BoilKettle : IStep
    {
        private readonly IStep _step;

        public BoilKettle(IStep step)
        {
            _step = step;
        }

        public void Do()
        {
            Console.WriteLine("Turn Kettle on to boil");

            if (_step == null)
                return;

            _step.Do();
        }
    }
}
