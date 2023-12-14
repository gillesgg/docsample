using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace vmmapdemo
{
    public class ObjectsScenarios
    {
        public void Execute()
        {
            var model = new ModelA();
            var other = new object();

            Console.WriteLine(
                    "ManagedObject invoked and Break called..  How many object were just " +
                    "created and what are their types?");

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Win32.DebugBreak();
            }
        }
    }
}
