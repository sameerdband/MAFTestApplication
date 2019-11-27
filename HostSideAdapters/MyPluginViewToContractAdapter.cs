using Contracts;
using HostView;
using System.AddIn.Pipeline;

namespace HostSideAdapters
{
    public class MyPluginViewToContractAdapter : ContractBase, IMyPluginContract
    {
        IMyPlugin _view;

        public MyPluginViewToContractAdapter(IMyPlugin view)
        {
            _view = view;
        }
        public string Name => _view.Name;

        public string Description => _view.Description;

        public void Initialize(IMyHostContract hostObj)
        {
            _view.Initialize(HostSideAdapter.ContractToViewAdapter(hostObj));
        }

        public double Operate(double num1, double num2)
        {
            return _view.Operate(num1, num2);
        }

        public void SimpleMethod()
        {
            _view.SimpleMethod();
        }

        public void SimpleMethod(string message)
        {
            _view.SimpleMethod(message);
        }

        public string SimpleMethod(string message1, string message2)
        {
            return _view.SimpleMethod(message1, message2);
        }
    }
}
