using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vmmapdemo
{
    public class FScenario
    {
        List<string> list = new List<string>();

        public FScenario()
        {
            list.Add("1");
            list.Add("2");
            list.Add("3");
        }

        ~FScenario()
        {
            Thread.Sleep(5000);
        }


    }
    public class FinalizersScenario
    {
        public void Execute()
        {
            for (int i = 0; i < 100000; i++)
            {
                FScenario fScenario = new ();
            }

            GC.Collect();
            Win32.DebugBreak();
        }
    }
}