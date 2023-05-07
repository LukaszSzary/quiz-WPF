using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace quiz.ViewModel
{
    class EndViewModel : INotifyPropertyChanged
    {
        public EndViewModel(String a,String path)
        {
            this.Score = a;
            this._path = path;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private String _path;
        private String _score;
        public String Score
        {
            get { return _score; }
            private  set {
                _score = "Twój wynik to: "+value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Score)));
            }
        }
        private ICommand _return;
        public ICommand Return {
            get
            {
                return _return ?? (_return = new RelayCommand(
                    (p) => { Messenger.Default.Send(new MyMessage( _path,"home")); },
                    p => true
                    ));
            }
        }
    }
}
