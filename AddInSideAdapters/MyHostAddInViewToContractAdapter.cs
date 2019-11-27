using AddInViews;
using Contracts;
using System;
using System.AddIn.Pipeline;

namespace AddInSideAdapters
{
    public class MyHostAddInViewToContractAdapter : ContractBase, IMyHostContract
    {
        IMyHost _view;

        public MyHostAddInViewToContractAdapter(IMyHost view)
        {
            _view = view;
        }
        public string Name => _view.Name;

        public string Description => _view.Description;

        public string GetData()
        {
            return _view.GetData();
        }

        internal IMyHost GetSourceView()
        {
            return _view;
        }

        public void LogMessage(string message)
        {
            _view.LogMessage(message);
        }
    }
}
