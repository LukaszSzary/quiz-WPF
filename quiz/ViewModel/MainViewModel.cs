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

        private String filePath;

        private ICommand chooseFile;
        public ICommand ChooseFile
        {
            get
            {

                return chooseFile ?? (chooseFile= new RelayCommand(
                    (p) => { filePath = model.chooseFile(); }
                    ,
                    p => true)
                    );
                
            }

        }    
    }
}
