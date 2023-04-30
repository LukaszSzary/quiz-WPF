using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace quiz.ViewModel
{
    
    class MainViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Model.Model model = new Model.Model();

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
                    (p) => { QuizList = model.GetQuizList();}
                    ,
                    p => !String.IsNullOrEmpty(filePath)
                    ));
            }
        }
     
    }
}
