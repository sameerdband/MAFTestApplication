using AddInViews;
using Contracts;
using System;
using System.AddIn.Pipeline;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddInSideAdapters
{
    [AddInAdapter]
    public class MyPluginAddInViewToContractAdapter : ContractBase, IMyPluginContract
    {
        private IMyPlugin _view;

        public MyPluginAddInViewToContractAdapter(IMyPlugin view)
        {
            _view = view;
        }

        public string Name => _view.Name;

        public string Description => _view.Description;

        public void Initialize(IMyHostContract hostObj)
        {
            _view.Initialize(AddInSideAdapter.ContractToViewAdapter(hostObj));
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
