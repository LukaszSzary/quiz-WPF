using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz.ViewModel
{
    class MainWindow : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            private set
            {
                _currentView = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentView)));
            }
        }
        public MainWindow()
        {
            CurrentView = new HomeViewModel();

            Messenger.Default.Register<MyMessage>(this, OnLoginMessage);

        }

        private void OnLoginMessage(MyMessage MyMessage)
        {
            
            CurrentView = new QuizViewModel(MyMessage.a);
            
        }
    }
}
