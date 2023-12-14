using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vmmapdemo
{
    public class ModelB
    {
        private string text;


        public ModelB()
        {
            this.text = "hello world";
        }


        public string Text
        {
            get { return text; }
        }
    }
}
