namespace Make.Coffee.Steps.Extras
{
    using System;

    public class Sweetener : Extra, IStep
    {
        private readonly IStep _step;

        public Sweetener(IStep step, int quantity) : base(quantity)
        {
            _step = step;
        }

        public void Do()
        {
            Console.WriteLine(string.Format("Add {0} sweeteners", Quantity));

            if (_step == null)
                return;

            _step.Do();
        }
    }
}