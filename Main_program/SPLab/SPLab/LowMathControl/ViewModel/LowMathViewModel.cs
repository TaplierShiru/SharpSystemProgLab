using SPLab.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SPLab.LowMathControl
{
    class LowMathViewModel : ILowMathViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string VarA
        {
            get { return this._lowMathModel.VarA; }
            set
            {
                this._lowMathModel.VarA = value;
                NotifyPropertyChanged("VarA");
            }
        }


        public string VarB
        {
            get { return this._lowMathModel.VarB; }
            set
            {
                this._lowMathModel.VarB = value;
                NotifyPropertyChanged("VarB");
            }
        }

        private string _res;
        public string Res
        {
            get { return _res; }
            set
            {
                _res = value;
                NotifyPropertyChanged("Res");
            }
        }

        private string _error;
        public string ErrorMess
        {
            get { return _error; }
            set
            {
                _error = value;
                NotifyPropertyChanged("ErrorMess");
            }
        }

        private ICommand _calculateCommand;
        public ICommand CalculateCommand
        {
            get
            {
                if (this._calculateCommand == null)
                {
                    this._calculateCommand = new RelayCommand(
                        param => this.Calculate()
                    );
                }
                return this._calculateCommand;
            }
        }
        private LowMathModel _lowMathModel;
        public LowMathViewModel()
        {
            this._lowMathModel = new LowMathModel();
        }

        private void Calculate()
        {
            Mediator.NotifyColleagues("PrintLog", "Идет расчет при помощи низкоуровневой функции...");
            var res = this._lowMathModel.Calculate();
            this.Res = res + "";
            if (res is null)
            {
                Mediator.NotifyColleagues("PrintLog", "Расчет при помощи низкоуровневой функции закончен неудачно.");
                this.ErrorMess = this._lowMathModel.ErrorMess;
            }
            else
            {
                Mediator.NotifyColleagues("PrintLog", "Расчет при помощи низкоуровневой функции закончен успешно.");
                this.ErrorMess = "";
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
