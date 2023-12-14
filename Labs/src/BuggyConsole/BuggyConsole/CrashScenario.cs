using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vmmapdemo
{
    public class CrashScenario
    {
        private int[]? _values = null;
        
        public void AccessViolation()
        {
            _values![1] = 0;
        }

        public int Ratio { get; set; }

        public void DivisionByZero()
        {
            int div0Errors = 7;
            int totalErrors = 23;
            totalErrors -= totalErrors;
            Ratio = div0Errors / totalErrors;

        }

        public void StackOverflow()
        {
            StackOverflowRecursive(0);
        }

        private void StackOverflowRecursive(int count)
        {
            if (count < 0)
                return;
            
            StackOverflowRecursive(count + 1);
        }

        public void UnhandledException()
        {
            throw new Exception("Ooops!");
        }

        public void SilentException()
        {
            for (var x = 0; x < 100; x++)
            {
                try
                {

                    throw new Exception("Ooops!");
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }
    }        
}
