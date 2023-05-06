using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz.Model
{
  
    class Question
    {
        public String question {get;}
        private String[] answers = new String[4];
        private bool[] ifCorrect = new bool[4];
       
        public Question(String que,String []ans, Int64[]ifcor)
        {
            this.question = que;
            this.answers = ans;
            
            this.ifCorrect[0] = ifcor[0] % 2 == 0;
            this.ifCorrect[1] = ifcor[1] % 2 == 0;
            this.ifCorrect[2] = ifcor[2] % 2 == 0;
            this.ifCorrect[3] = ifcor[3] % 2 == 0;
        }
        public String[] Answers()
        {
            return answers;
        }
        public bool[] IfCorrect()
        {
            return ifCorrect;
        }
    }
}
