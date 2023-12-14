using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vmmapdemo
{
    public class MemoryScenario
    {
        public void allocate()
        {
            try
            {
                unsafe
                {

                    List< byte[]> bytes = new List<byte[] >();

                    for (int x = 0; x < 1024; x++)
                    {
                        byte[] buffer = new byte[1024 * 1024];
                        bytes.Add( buffer );

                        var memoryInfo1 = GC.GetGCMemoryInfo();
                        fixed (byte* p = buffer.ToArray())
                        {

                        }
                        Console.WriteLine($"Total HeapSize MB: {memoryInfo1.HeapSizeBytes.ToSize(MyExtension.SizeUnits.MB)}");
                        System.Threading.Thread.Sleep(250);
                    }
                }
            }
            catch (OutOfMemoryException)
            {
                throw;
            }

            var memoryInfo = GC.GetGCMemoryInfo();
            Console.WriteLine($"Total HeapSize MB: {memoryInfo.HeapSizeBytes.ToSize(MyExtension.SizeUnits.MB)}");
        }
    }
}
