using AddInViews;
using System;
using System.AddIn;

namespace MySimpleAddIn
{
    [AddIn("My First Add-In", Version = "1.0.0.0", Description = "Description of My First Add-In", Publisher = "Sameer")]
    public class SimplePlugin : IMyPlugin
    {
        IMyHost _host;
        public string Name => "Sameer's First Add In";

        public string Description => $"This is my first simple addIn for the demo running in '{AppDomain.CurrentDomain.FriendlyName}' AppDomain";

        public void Initialize(IMyHost hostObj)
        {
            _host = hostObj;
        }

        public double Operate(double num1, double num2)
        {
            var result = num1 + num2;
            _host.LogMessage($"Operating on {num1} and {num2}: {num1} + {num2} = {result}");
            return result;
        }

        public void SimpleMethod()
        {
            _host.LogMessage("This is a simple method in my first plugin which doesn't do anything");
        }

        public void SimpleMethod(string message)
        {
            _host.LogMessage("A sample method from first plugin which recieve message: " + message);
        }

        public string SimpleMethod(string message1, string message2)
        {
            _host.LogMessage($"A sample method from first plugin which recieve message1: {message1} & message2: {message2}.");

            return message1.ToUpper() + message2.ToLower();
        }
    }
}
