using Contracts;
using HostView;
using System;
using System.AddIn.Pipeline;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostSideAdapters
{
    [HostAdapter]
    public class MyPluginContractToHostViewAdapter : IMyPlugin
    {
        private IMyPluginContract _contract;
        private ContractHandle _handle;

        public MyPluginContractToHostViewAdapter(IMyPluginContract contract)
        {
            _contract = contract;
            _handle = new ContractHandle(contract);
        }

        public string Name => _contract.Name;

        public string Description => _contract.Description;

        public void Initialize(IMyHost hostObj)
        {
            _contract.Initialize(HostSideAdapter.ViewToContractAdapter(hostObj));
        }

        public double Operate(double num1, double num2)
        {
            return _contract.Operate(num1, num2);
        }

        public void SimpleMethod()
        {
            _contract.SimpleMethod();
        }

        public void SimpleMethod(string message)
        {
            _contract.SimpleMethod(message);
        }

        public string SimpleMethod(string message1, string message2)
        {
            return _contract.SimpleMethod(message1, message2);
        }
    }
}
