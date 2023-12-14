using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace vmmapdemo
{
    internal static class Win32
    {
        [DllImport("kernel32")]
        public static extern void DebugBreak();
    }
}
