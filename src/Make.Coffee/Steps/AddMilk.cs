using System;

namespace Make.Coffee.Steps
{
    public class AddMilk : IStep
    {
        private readonly IStep _step;

        public AddMilk(IStep step)
        {
            _step = step;
        }

        public void Do()
        {
            Console.WriteLine("Add Milk");

            if (_step == null)
                return;

            _step.Do();
        }
    }
}
