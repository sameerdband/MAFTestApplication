using HostView;
using System;
using System.AddIn.Hosting;
using System.Collections.ObjectModel;
using System.Reflection;

namespace HostApplication
{
    public class MyHost : IMyHost
    {
        private string _pluginRoot;
        Collection<AddInToken> _plugins;
        private string _pipelineRootFolder;

        public string Name => "My Sample Host";

        public string Description => "This is my sample host in Host Application and it is running in domain: " + AppDomain.CurrentDomain.FriendlyName;

        public MyHost(string pipelineRoot, string pluginRoot)
        {
            _pipelineRootFolder = pipelineRoot;
            _pluginRoot = pluginRoot;
            RefreshPluginStore();
        }

        public void RefreshPluginStore()
        {
            AddInStore.Rebuild(_pipelineRootFolder);
            AddInStore.RebuildAddIns(_pluginRoot);
            _plugins = AddInStore.FindAddIns(typeof(IMyPlugin), _pipelineRootFolder, _pluginRoot);
        }

        public string GetData()
        {
            return $"This is some sample data from the host. The host is running in {AppDomain.CurrentDomain.FriendlyName} app domain";
        }

        public void LogMessage(string message)
        {
            Console.WriteLine("Host log::: " + message);
        }

        public void ActivatePlugins()
        {
            if(_plugins == null)
            {
                RefreshPluginStore();
            }

            foreach (AddInToken addinToken in _plugins)
            {

                try
                {
                    // Activate the add-in
                    IMyPlugin addinInstance = addinToken.Activate<IMyPlugin>(AddInSecurityLevel.FullTrust);
                    addinInstance.Initialize(this);

                    //var d = addinToken.QualificationData[AddInSegmentType.AddIn];
                    // Use the add-in
                    Console.WriteLine($"Add-in {addinToken.Name} Version {addinToken.Version}");
                    Console.WriteLine($"---------------------");

                    Console.WriteLine($"Plugin name: {addinInstance.Name}");
                    Console.WriteLine($"Plugin description: {addinInstance.Description}");
                    Console.WriteLine($"---------------------");
                    Console.WriteLine();


                    Console.WriteLine("Executing Operate: ");
                    Console.WriteLine("Operate(10, 20) = " + addinInstance.Operate(10, 20));
                    Console.WriteLine();

                    Console.WriteLine("Executing SimpleMethod(): ");
                    addinInstance.SimpleMethod();
                    Console.WriteLine();
                    Console.WriteLine("Executing SimpleMethod(\"This is some message from host\"): ");
                    addinInstance.SimpleMethod("This is some message from host");
                    Console.WriteLine();
                    Console.WriteLine("Executing: SimpleMethod(\"Host message1\", \"Host message2\")");
                    Console.WriteLine(addinInstance.SimpleMethod("Host message1", "Host message2"));

                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("''''''''''''''''''''''''''''''''''''''''''''''''''''");
                    Console.WriteLine("Shutting it down.....: ->");
                    AddInController.GetAddInController(addinInstance).Shutdown();
                    Console.WriteLine("Shut down.....: ->");
                }
                catch (TargetInvocationException ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }
    }
}
