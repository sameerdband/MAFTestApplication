using AddInViews;
using Contracts;
using System;
using System.AddIn.Pipeline;

namespace AddInSideAdapters
{
    public class MyHostContractToAddInViewAdapter : IMyHost
    {
        IMyHostContract _contract;
        ContractHandle _handle;

        public MyHostContractToAddInViewAdapter(IMyHostContract contract)
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

        internal IMyHostContract GetSourceContract()
        {
            return _contract;
        }
    }
}
