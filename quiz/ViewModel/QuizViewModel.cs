﻿using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;

namespace quiz.ViewModel 
{
    public class QuizViewModel : INotifyPropertyChanged
    {
        public QuizViewModel(int a, String p)
        {
            this._indexOfQuiz = a;
            this._path = p;
            this.Questions = model.getQuestions(IndexOfQuiz, _path);
            
            this._lenOfQuiz = this.Questions.Count();
            Timer = string.Format("{0}:{1}", m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
            //this._maxPoints = 0;
            //this._userPoints = 0;
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;
            t.Start();
            foreach(Model.Question q in Questions)
            {
                foreach(bool b in q.IfCorrect())
                {
                    if(b) { this._maxPoints += 1; }
                }
            }
            _loadQuestionAndAnswers(1);
        }

        //Time for quiz
        private int m = 15, s = 0;
        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            
            if (m == 0&&s == 0){
                t.Stop();
                _atEndOfTime();
            }
            if (s==0)
            {
                s = 60;
                if(m>0) m -= 1;
            }
            s -= 1;
            Timer = string.Format("{0}:{1}", m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));

        }

        private int _lenOfQuiz;
        private int _maxPoints=0;
        private int _userPoints=0;
        private int _currentQuestion;
        private bool[] _userAns = new bool[4];
        public bool[] UserAns
        {
            get { return _userAns; }
            private set
            {
                _userAns = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UserAns)));
            }
        }
        public int CurrentQuestion
        {
            get { return _currentQuestion; }
            private set
            {
                _currentQuestion = value;
                Progres = "";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentQuestion)));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private System.Timers.Timer t = new System.Timers.Timer();
        
        private Model.QuizModel model = new Model.QuizModel();
        private List<Model.Question> Questions = new List<Model.Question>();
        private String _path;
       
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
        private bool[] _ansTF = new bool[4];
        public bool[] AnsTF
        {
            get { return _ansTF; }
            private set
            {
                _ansTF = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnsTF)));
            }
        }
        private String _questionContent ;
        public String QuestionContent
        {
            get { return _questionContent; }
            private set
            {
                _questionContent = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuestionContent)));
            }
        }

        private String _progre;
        public String Progres
        {
            get { return _progre; }
            private set
            {
                _progre = CurrentQuestion.ToString() + "/"+_lenOfQuiz.ToString(); 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Progres)));
            }
        }

        private ICommand _nextQuestion;
        public ICommand NextQuestion
        {
            get {

                return _nextQuestion ?? (_nextQuestion = new RelayCommand(
                    (p) => {
                        if (CurrentQuestion == _lenOfQuiz) {
                            //end of Quiz
                            bool ifGood = true;
                            for (int i = 0; i < 4; i++)
                            {
                                if (UserAns[i] == true && AnsTF[i] == false) { ifGood = false; }
                            
                            
                            }
                            if (ifGood)
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    if (UserAns[i] == true && AnsTF[i] == true) { this._userPoints +=1; }
                                
                                }
                            }
                            Messenger.Default.Send(new MyMessage(this._userPoints.ToString() + "/" + this._maxPoints.ToString(),_path,"end"));
                            //QuestionContent = this._userPoints.ToString() + "/" + this._maxPoints.ToString();
                        }
                        else
                        {
                            bool ifGood = true;
                            //during quiz
                            //check answers
                            for(int i = 0; i < 4; i++)
                            {
                                if (UserAns[i] == true && AnsTF[i] == false) { ifGood = false; }
                            }
                            if (ifGood)
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    if (UserAns[i] == true && AnsTF[i] == true) { this._userPoints +=1; }
                                }
                            }

                            //load next question
                           
                            _loadQuestionAndAnswers(CurrentQuestion + 1);
                        }
                    }
                    ,
                    p => UserAns[0] || UserAns[1] || UserAns[2] || UserAns[3] )
                    );
            }
            
        }
        private String _timer;
        public String Timer
        {
            get { return _timer; }
            private set
            {
                _timer = value;
                
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Timer)));
            }
        }
        private void _loadQuestionAndAnswers(int i)
        {
            this.UserAns =new bool[4]{ false, false,false,false};
            /*
            this.UserAns[0] = false;
            this.UserAns[1] = false;
            this.UserAns[2] = false;
            this.UserAns[3] = false;*/
            this.CurrentQuestion = i;
            this.Ans = Questions[i-1].Answers();
            this.AnsTF = Questions[i - 1].IfCorrect();
            QuestionContent = Questions[i - 1].question;
        }
        private void _atEndOfTime()
        {

            Messenger.Default.Send(new MyMessage(this._userPoints.ToString() + "/" + this._maxPoints.ToString(), _path, "end"));
            //QuestionContent = this._userPoints.ToString() + "/" + this._maxPoints.ToString();
        }
    }
}
