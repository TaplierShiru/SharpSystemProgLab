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
    /// <summary>
    /// Класс реализует ViewModel часть виджета LogPanel
    /// LogPanel - отображает окно логгов действий пользователя
    /// </summary>
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

        /// <summary>
        /// Добавляет строку в логгер с временем срабатывания
        /// </summary>
        /// <param name="newLine"></param>
        private void AddNewLine(object newLine)
        {
            this.LogText += DateTime.Now + " : "  + (string)newLine + '\n';
            
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
