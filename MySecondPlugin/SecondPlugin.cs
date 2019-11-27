using AddInViews;
using System;
using System.AddIn;

namespace MySecondPlugin
{
    [AddIn("Second", Version = "1.0.0.0", Description = "Second Simple Plugin", Publisher = "Sameer")]
    public class SecondPlugin : IMyPlugin
    {
        IMyHost _host;
        public string Name => "Second Plugin";

        public string Description => $"AppDomian: '{AppDomain.CurrentDomain.FriendlyName}'";

        public void Initialize(IMyHost hostObj)
        {
            _host = hostObj;
        }

        public double Operate(double num1, double num2)
        {
            return num1 * num2;
        }

        public void SimpleMethod()
        {
            _host.LogMessage($"Host name = {_host.Name}");
            _host.LogMessage($"Host Desc = {_host.Description}");
            _host.LogMessage($"Host Data = {_host.GetData()}");
        }

        public void SimpleMethod(string message)
        {
            _host.LogMessage($"Simple method called with message = {message}");
        }

        public string SimpleMethod(string message1, string message2)
        {
            return $"Simple method called with message1 = '{message1}' && message2 = '{message2}'";
        }
    }
}
