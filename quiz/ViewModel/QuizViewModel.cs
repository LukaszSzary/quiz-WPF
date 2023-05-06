using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace quiz.ViewModel 
{
    public class QuizViewModel : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;
        private Model.QuizModel model = new Model.QuizModel();
        private String _path;
        private List<Model.Question> Questions = new List<Model.Question>();
        private int _indexOfQuiz;
        public int IndexOfQuiz
        {
            get { return _indexOfQuiz; }
            private set
            {
                _indexOfQuiz = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IndexOfQuiz)));
            }
        }
        public QuizViewModel(int a, String s)
        {
            this._indexOfQuiz = a;
            this._path = s;
            this.Questions = model.getQuestions(IndexOfQuiz, _path);
            this.Ans = Questions[0].Answers();
            QuestionContent = Questions[0].question;


        }
        private String []_ans=new String[4];
        public String[] Ans
        {
            get { return _ans; }
            private set
            {
                _ans = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ans)));
            }
        }

        


        private String questionContent ;
        public String QuestionContent
        {
            get { return questionContent; }
            private set
            {
                questionContent = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuestionContent)));
            }
        }


    }
}
