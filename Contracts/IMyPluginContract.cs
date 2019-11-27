using System.AddIn.Contract;
using System.AddIn.Pipeline;

namespace Contracts
{
    [AddInContract]
    public interface IMyPluginContract : IContract
    {
        string Name { get; }

        string Description { get; }

        void Initialize(IMyHostContract hostObj);

        void SimpleMethod();

        void SimpleMethod(string message);

        string SimpleMethod(string message1, string message2);

        double Operate(double num1, double num2);
    }
}
