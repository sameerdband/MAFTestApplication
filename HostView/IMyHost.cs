using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostView
{
    public interface IMyHost
    {

        string Name { get; }

        string Description { get; }

        void LogMessage(string message);

        string GetData();
    }
}
