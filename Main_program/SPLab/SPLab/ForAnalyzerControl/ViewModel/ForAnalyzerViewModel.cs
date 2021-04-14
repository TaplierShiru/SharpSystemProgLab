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
    class ForAnalyzerViewModel : INotifyPropertyChanged, IForAnalyzerViewModel
    {
        public const int MAX_LENGTH = 30;
        public event PropertyChangedEventHandler PropertyChanged;
        private ForAnalyzerModel _forAnalyzerModel;
        public string AnalyzedCode
        {
            get => this._forAnalyzerModel.AnalyzedCode;
            set
            {
                _forAnalyzerModel.AnalyzedCode = value;
                NotifyPropertyChanged("AnalyzedCode");
            }
        }

        public int GetNumFor => _forAnalyzerModel.GetNumFor;

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


        public ForAnalyzerViewModel()
        {
            this._forAnalyzerModel = new ForAnalyzerModel();
        }

        private void AnalyzeCode()
        {
            Mediator.NotifyColleagues("PrintLog", "Анализ выражения...");
            this._forAnalyzerModel.AnalyzeCode();
            Mediator.NotifyColleagues("PrintLog", "Анализ завершен.");
            NotifyPropertyChanged("GetErrorMessage");
            NotifyPropertyChanged("GetNumFor");
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
