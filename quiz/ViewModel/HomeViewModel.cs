﻿using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace quiz.ViewModel
{
    
   public class HomeViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Model.HomeModel model = new Model.HomeModel();
        public HomeViewModel() { }
        public HomeViewModel(String path) {
            this.FilePath = path;
            QuizList = model.GetQuizList(FilePath);
        }

        private String filePath=default;
        public String FilePath
        {
            get { return filePath; }
            private set
            {
                filePath = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FilePath)));
            }
        }

        private List<String> quizList = new List<string>();
        public List<String> QuizList
        {
            get { return quizList; }
            private set
            {
                quizList = value;
                quizList.Reverse();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuizList)));
            }
        }
        private ICommand chooseFile;
        public ICommand ChooseFile
        {
            get
            {
                return chooseFile ?? (chooseFile= new RelayCommand(
                    (p) => { FilePath = model.chooseFile(); }
                    ,
                    p => true)
                    );
            }
        }

        private ICommand submit;
        public ICommand Submit
        {
            get
            {
                return submit ?? (submit = new RelayCommand(
                    (p) => { QuizList = model.GetQuizList(FilePath);}
                    ,
                    p => !String.IsNullOrEmpty(filePath)
                    ));
            }
        }
        private int _index=-1;
        public int Index
        {
            get { return _index; }
            set
            {
                _index = value;
            }
        }

        private ICommand startQuiz;
        public ICommand StartQuiz
        {
            get
            {
                return startQuiz ?? (startQuiz = new RelayCommand(
                    (p) => { Messenger.Default.Send(new MyMessage(Index,FilePath,"quiz")); },
                    p => Index != -1
                    )) ;
            }
        }

        

    }
}
