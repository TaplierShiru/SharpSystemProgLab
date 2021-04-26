using SPLab.LogPanelControl.Utils;
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
    /// <summary>
    /// Класс реализующий ViewModel часть LowMath виджета
    /// Который рассчитывает значение при помощи низкоуровневого языка
    /// </summary>
    class LowMathViewModel : ILowMathViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ILowMathModel _lowMathModel;

        /// <inheritdoc/>
        public string VarA
        {
            get { return this._lowMathModel.VarA; }
            set
            {
                this._lowMathModel.VarA = value;
                NotifyPropertyChanged("VarA");
            }
        }

        /// <inheritdoc/>
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
        /// <inheritdoc/>
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
        /// <inheritdoc/>
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
        /// <inheritdoc/>
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

        /// <summary>
        /// Иницилазция ViewModel части виджета LowMath
        /// </summary>
        /// <param name="lowMathModel">Класс реализующий логику виджета</param>
        public LowMathViewModel(ILowMathModel lowMathModel)
        {
            this._lowMathModel = lowMathModel;
        }

        /// <summary>
        /// Расчет значения на низкоуровневом языке
        /// </summary>
        private void Calculate()
        {
            LogPanelMediator.PrintInLogPanel("Идет расчет при помощи низкоуровневой функции...");
            var res = this._lowMathModel.Calculate();
            this.Res = res + "";
            if (res is null)
            {
                LogPanelMediator.PrintInLogPanel("Расчет при помощи низкоуровневой функции закончен неудачно.");
                this.ErrorMess = this._lowMathModel.ErrorMess;
            }
            else
            {
                LogPanelMediator.PrintInLogPanel("Расчет при помощи низкоуровневой функции закончен успешно.");
                this.ErrorMess = "";
            }
        }

        /// <summary>
        /// Обновление ячеек таблицы и вывод информации в логгер
        /// </summary>
        /// <param name="logStr">Информация которую следует вывести в лог</param>
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
