using Contracts;
using HostView;
using System.AddIn.Pipeline;

namespace HostSideAdapters
{
    class MyHostHostViewToContractAdapter : ContractBase, IMyHostContract
    {
        private IMyHost _view;

        public MyHostHostViewToContractAdapter(IMyHost view)
        {
            _view = view;
        }

        public string Name => _view.Name;

        public string Description => _view.Description;


        public string GetData()
        {
            return _view.GetData();
        }


        public void LogMessage(string message)
        {
            _view.LogMessage(message);
        }

        public IMyHost GetSourceView()
        {
            return _view;
        }
    }
}
