using Contracts;
using HostView;
using System;
using System.AddIn.Pipeline;

namespace HostSideAdapters
{
    public class MyHostContractToHostViewAdapter : IMyHost
    {
        private IMyHostContract _contract;
        private ContractHandle _handle;

        public MyHostContractToHostViewAdapter(IMyHostContract contract)
        {
            _contract = contract;
            _handle = new ContractHandle(contract);
        }

        public string Name => _contract.Name;

        public string Description => _contract.Description;

        public string GetData()
        {
            return _contract.GetData();
        }

        public void LogMessage(string message)
        {
            _contract.LogMessage(message);
        }

        public IMyHostContract GetSourceContract()
        {
            return _contract;
        }
    }
}
