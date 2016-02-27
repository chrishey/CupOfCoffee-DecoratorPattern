using System;

namespace Make.Coffee.Steps
{
    public class FillKettle : IStep
    {
        private readonly IStep _step;

        public FillKettle(IStep step)
        {
            _step = step;
        }

        public void Do()
        {
            Console.WriteLine("Fill the Kettle");
            
            if (_step == null)
                return;

            _step.Do();
        }
    }
}
