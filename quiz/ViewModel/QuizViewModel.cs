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

        private Model.Model model = new Model.Model();

        private int a; 
        public int A
        {
            get { return a; }
            private set
            {
                a = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(A)));
            }
        }
        public QuizViewModel(int a)
        {
            this.A = a;
        }
        
    }
}
