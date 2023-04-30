using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz.Model
{
    class Model
    {
        public String chooseFile() {
            return "wow";
        }
        public List<String> GetQuizList()
        {
            List<String> numbers = new List<String>() { "1", "2", "5", "7", "8", "10" };
            return numbers;
        }
        public Model() { }
    }
}
