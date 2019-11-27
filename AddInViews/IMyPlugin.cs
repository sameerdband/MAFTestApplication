using System.AddIn.Pipeline;

namespace AddInViews
{
    [AddInBase]
    public interface IMyPlugin
    {
        string Name { get; }

        string Description { get; }

        void Initialize(IMyHost hostObj);

        void SimpleMethod();

        void SimpleMethod(string message);

        string SimpleMethod(string message1, string message2);

        double Operate(double num1, double num2);
    }
}
