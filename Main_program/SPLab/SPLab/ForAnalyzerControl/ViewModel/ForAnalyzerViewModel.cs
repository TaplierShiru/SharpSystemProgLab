using SPLab.LogPanelControl.Utils;
using SPLab.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SPLab.ForAnalyzerControl
{
    /// <summary>
    /// Класс реализующий ViewModel часть для виджета ForAnalyzer
    /// </summary>
    class ForAnalyzerViewModel : INotifyPropertyChanged, IForAnalyzerViewModel
    {
        // Константа нужна чтобы разбить большое сообщение об ошибке в несколько строк
        // Иначе в самом окне оно будет как длинная строка - что плохо и неудобно читать
        public const int MAX_LENGTH = 30;

        public event PropertyChangedEventHandler PropertyChanged;
        
        private IForAnalyzerModel _forAnalyzerModel;
        
        ///<inheritdoc/>
        public string AnalyzedCode
        {
            get => this._forAnalyzerModel.AnalyzedCode;
            set
            {
                _forAnalyzerModel.AnalyzedCode = value;
                NotifyPropertyChanged("AnalyzedCode");
            }
        }

        ///<inheritdoc/>
        public int GetNumFor => _forAnalyzerModel.GetNumFor;

        ///<inheritdoc/>
        public string GetErrorMessage
        {
            get {
                var error_mess = this._forAnalyzerModel.GetErrorMessage;
                string final_str = "";                
                if (error_mess.Length > MAX_LENGTH)
                {
                    // Split into several lines
                    int parts = (int)Math.Ceiling(error_mess.Length / (double)MAX_LENGTH);
                    int i = 0;
                    for (; i < parts-1; i++)
                    {
                        final_str += error_mess.Substring(i * MAX_LENGTH, MAX_LENGTH) + "\n";
                    }
                    final_str += error_mess.Substring(i * MAX_LENGTH) + "\n";
                }
                else
                {
                    final_str = error_mess;
                }
                return final_str; 
            }
        }

        private ICommand _AnalyzeCommand;
        /// <inheritdoc/>
        public ICommand AnalyzeCommand
        {
            get
            {
                if (this._AnalyzeCommand == null)
                {
                    this._AnalyzeCommand = new RelayCommand(
                        param => this.AnalyzeCode()
                    );
                }
                return this._AnalyzeCommand;
            }
        }

        /// <summary>
        /// Инициализация класса реализующего ViewModel часть виджета ForAnalyzer
        /// </summary>
        /// <param name="forAnalyzerModel">Модуль реализующий логику виджета</param>
        public ForAnalyzerViewModel(IForAnalyzerModel forAnalyzerModel)
        {
            this._forAnalyzerModel = forAnalyzerModel;
        }

        /// <summary>
        /// Анализ кода и обновление окошен по выводу итоговой информации
        /// </summary>
        private void AnalyzeCode()
        {
            LogPanelMediator.PrintInLogPanel("Анализ выражения...");
            this._forAnalyzerModel.AnalyzeCode();
            LogPanelMediator.PrintInLogPanel("Анализ завершен.");
            NotifyPropertyChanged("GetErrorMessage");
            NotifyPropertyChanged("GetNumFor");
        }

        /// <summary>
        /// Вызов события - изменилось поле
        /// </summary>
        /// <param name="propertyName">Имя поля что было измененно</param>
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
