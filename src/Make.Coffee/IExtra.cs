using Make.Coffee.Steps;

namespace Make.Coffee
{
    public interface IExtra : IStep
    {
        string Name { get; }
        int Quantity { get; set; }
    }
}
