using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vmmapdemo
{
    public struct ModelC
    {
        public byte[] data;


        public ModelC(long data)
        {
            this.data = BitConverter.GetBytes(data);
        }


        /// <summary>
        /// 
        /// </summary>

        public long Data
        {
            get { return BitConverter.ToInt64(data, 0); }
            set { data = BitConverter.GetBytes(value); }
        }
    }
}
