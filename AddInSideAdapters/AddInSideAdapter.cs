using AddInViews;
using Contracts;
using System.Runtime.Remoting;

namespace AddInSideAdapters
{
    public class AddInSideAdapter
    {
        public static IMyHost ContractToViewAdapter(IMyHostContract contract)
        {
            if(((RemotingServices.IsObjectOutOfAppDomain(contract) != true)
                        && contract.GetType().Equals(typeof(MyHostAddInViewToContractAdapter))))
            {
                return ((MyHostAddInViewToContractAdapter)(contract)).GetSourceView();
            }
            else
            {
                return new MyHostContractToAddInViewAdapter(contract);
            }
        }

        public static IMyHostContract ViewToContractAdapter(IMyHost view)
        {
            if (view.GetType().Equals(typeof(MyHostContractToAddInViewAdapter)))
            {
                return ((MyHostContractToAddInViewAdapter)(view)).GetSourceContract();
            }
            else
            {
                return new MyHostAddInViewToContractAdapter(view);
            }
        }
    }
}
