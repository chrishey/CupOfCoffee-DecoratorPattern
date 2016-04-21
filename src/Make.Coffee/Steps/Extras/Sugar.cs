namespace Make.Coffee.Steps.Extras
{
    using System;

    public class Sugar : Extra, IStep
    {
        private readonly IStep _step;

        public Sugar(IStep step, int quantity):base(quantity)
        {
            _step = step;
        }

        public void Do()
        {
            Console.WriteLine(string.Format("Add {0} spoons of sugar", Quantity));

            if (_step == null)
                return;

            _step.Do();
        }
    }
}
