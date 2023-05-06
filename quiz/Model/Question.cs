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
        private String []answers=new String[4];
        private bool[] ifCorrect = new bool[4];
       
        public Question(String que,String []ans,int []ifcor)
        {
            this.question = que;
            this.answers[0] = ans[0];
            this.answers[1] = ans[1];
            this.answers[2] = ans[2];
            this.answers[3] = ans[3];
            this.ifCorrect[0] = ifcor[0] % 2 == 0;
            this.ifCorrect[1] = ifcor[1] % 2 == 0;
            this.ifCorrect[2] = ifcor[2] % 2 == 0;
            this.ifCorrect[3] = ifcor[3] % 2 == 0;
        }
        public String Answers(int i)
        {
            return answers[i];
        }
        public bool IfCorrect(int i)
        {
            return ifCorrect[i];
        }
    }
}
