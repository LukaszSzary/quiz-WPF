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
        public String what { get; }
        public String path { get; }
        public String score { get; }
        public MyMessage(int a,String path,String what)
        {
            this.a = a;
            this.path = path;
            this.what = what;
        }
        public MyMessage( String score, String path, String what)
        {
            this.score = score;
            this.path = path;
            this.what = what;

        }
        public MyMessage(String path, String what)
        {
            this.path = path;
            this.what = what;

        }
    }
}
