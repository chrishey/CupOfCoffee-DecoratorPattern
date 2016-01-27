using System;

namespace Make.Coffee
{
    public class AddCoffeeToCup : IStep
    {
        private readonly IStep _step;

        public AddCoffeeToCup(IStep step)
        {
            _step = step;
        }

        public void Do()
        {
            Console.WriteLine("Add Coffee to the cup");

            if (_step == null)
                return;

            _step.Do();
        }
    }
}
