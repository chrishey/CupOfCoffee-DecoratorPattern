using System;

namespace Make.Coffee.Steps
{
    public class AddSugar : IExtra
    {
        private readonly IStep _step;

        public AddSugar(IStep step)
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

        public string Name { get { return "AddSugar"; } }
        public int Quantity { get; set; }
    }
}
