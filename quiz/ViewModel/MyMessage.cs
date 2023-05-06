using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz.ViewModel
{
    public class MyMessage
    {
        public int a { get; }

        public String path { get; }
        public MyMessage(int a,String path)
        {
            this.a = a;
            this.path = path;
        }
    }
}
