using Contracts;
using HostView;
using System.Runtime.Remoting;

namespace HostSideAdapters
{
    public class HostSideAdapter
    {
        public static IMyHost ContractToViewAdapter(IMyHostContract contract)
        {
            if(((RemotingServices.IsObjectOutOfAppDomain(contract) != true)
                        && contract.GetType().Equals(typeof(MyHostHostViewToContractAdapter))))
            {
                return ((MyHostHostViewToContractAdapter)(contract)).GetSourceView();
            }
            else
            {
                return new MyHostContractToHostViewAdapter(contract);
            }
        }

        public static IMyHostContract ViewToContractAdapter(IMyHost view)
        {
            if (view.GetType().Equals(typeof(MyHostContractToHostViewAdapter)))
            {
                return ((MyHostContractToHostViewAdapter)(view)).GetSourceContract();
            }
            else
            {
                return new MyHostHostViewToContractAdapter(view);
            }
        }
    }
}
