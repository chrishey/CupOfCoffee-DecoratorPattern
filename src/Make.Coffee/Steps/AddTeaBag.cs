using System;

namespace Make.Coffee.Steps
{
    public class AddTeaBag : IStep
    {
        private readonly IStep _step;

        public AddTeaBag(IStep step)
        {
            _step = step;
        }

        public void Do()
        {
            Console.WriteLine("Add Tea Bag");

            if (_step == null)
                return;

            _step.Do();
        }
    }
}
