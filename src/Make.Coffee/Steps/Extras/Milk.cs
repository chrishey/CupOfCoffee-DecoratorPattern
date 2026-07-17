using System;

namespace Make.Coffee.Steps.Extras
{
    public class Milk : Extra, IStep
    {
        private readonly IStep _step;

        public Milk(IStep step, int quantity) : base(quantity)
        {
            _step = step;
        }

        public void Do()
        {
            Console.WriteLine(string.Format("Add {0} units of milk", Quantity));

            if (_step == null)
                return;

            _step.Do();
        }
    }
}
