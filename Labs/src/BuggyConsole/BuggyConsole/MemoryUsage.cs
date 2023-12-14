using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vmmapdemo
{
    public class MemoryUsage
    {
        public void Execute()
        {
            var model = new ModelA();
            Console.WriteLine("ModelA instance just created");
            Win32.DebugBreak();

            GC.Collect();
            Console.WriteLine("GC run once, find ModelA");
            Win32.DebugBreak();

            GC.Collect();
            Console.WriteLine("GC run twice, find ModelA");
            Win32.DebugBreak();

            model = null;

            GC.Collect();
            Console.WriteLine("GC run after ModelA unrooted");
            Win32.DebugBreak();
        }
    }
}
