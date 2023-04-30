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
       
        public Question(String que,String ans1, String ans2, String ans3, String ans4,int ifcor1, int ifcor2, int ifcor3, int ifcor4)
        {
            this.question = que;
            this.answers[0] = ans1;
            this.answers[1] = ans2;
            this.answers[2] = ans3;
            this.answers[3] = ans4;
            this.ifCorrect[0] = ifcor1 % 2 == 0;
            this.ifCorrect[1] = ifcor2 % 2 == 0;
            this.ifCorrect[2] = ifcor3 % 2 == 0;
            this.ifCorrect[3] = ifcor4 % 2 == 0;
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
