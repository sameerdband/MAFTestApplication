using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo outputFolder = new DirectoryInfo(Environment.CurrentDirectory);
            var pipelineRoot = outputFolder.Parent.GetDirectories("Pipeline").FirstOrDefault();
            var addInsRoot = outputFolder.Parent.GetDirectories("AddIns").FirstOrDefault();

            if(pipelineRoot != null && pipelineRoot.Exists && addInsRoot != null && addInsRoot.Exists)
            {
                MyHost host = new MyHost(pipelineRoot.FullName, addInsRoot.FullName);
                host.ActivatePlugins();
            }
            else if(pipelineRoot== null || !pipelineRoot.Exists)
            {
                Console.Error.WriteLine("Could not find the 'Pipeline' directory'");
            }
            else
            {
                Console.Error.WriteLine("Could not find the 'AddIns' directory'");
            }
            
        }
    }
}
