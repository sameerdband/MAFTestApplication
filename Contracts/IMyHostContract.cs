using System.AddIn.Contract;

namespace Contracts
{
    public interface IMyHostContract : IContract
    {
        string Name { get; }

        string Description { get; }

        void LogMessage(string message);

        string GetData();
    }
}