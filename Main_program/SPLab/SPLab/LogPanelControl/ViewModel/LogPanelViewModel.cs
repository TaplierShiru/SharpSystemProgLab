using SPLab.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SPLab.LogPanelControl
{
    /// <inheritdoc/>
    class LogPanelViewModel : ILogPanelViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _logText;
        /// <inheritdoc/>
        public string LogText
        {
            get { return this._logText; }
            set 
            {
                this._logText = value;
                NotifyPropertyChanged("LogText");
            }
        }

        public LogPanelViewModel()
        {
            Mediator.Register("PrintLog", this.AddNewLine);
        }

        private void AddNewLine(object newLine)
        {
            this.LogText += (string)newLine + '\n';
            
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
