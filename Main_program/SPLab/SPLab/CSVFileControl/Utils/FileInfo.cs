using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLab.CSVFileControl
{
    /// <summary>
    /// Класс хранящий данные об одном .exe файле
    /// для их последующей визуализации
    /// </summary>
    public class FileInfo : INotifyPropertyChanged, IFileInfo
    {
    
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private string _fileName;
        private string _version;
        private string _dataOfCreation;
        private int _indx;

        ///<inheritdoc/>
        public string FileName 
        {
            get { return this._fileName; }
            set 
            {
                this._fileName = value;
                this.NotifyPropertyChanged("FileName");
            }
        }

        ///<inheritdoc/>
        public string Version
        {
            get { return this._version; }
            set
            {
                this._version = value;
                this.NotifyPropertyChanged("Version");
            }
        }

        ///<inheritdoc/>
        public string DataOfCreation
        {
            get { return this._dataOfCreation; }
            set
            {
                this._dataOfCreation = value;
                this.NotifyPropertyChanged("DataOfCreation");
            }
        }

        ///<inheritdoc/>
        public int Indx
        {
            get { return this._indx; }
            set { this._indx = value; }
        }

        /// <summary>
        /// Иинициализация класса для хранения данных об .exe файле
        /// Все поля инициализируются как "None" значения
        /// </summary>
        public FileInfo()
        {
            this.FileName = "None";
            this.Version = "None";
            this.DataOfCreation = "None";
            this.Indx = 0;
        }

        /// <summary>
        /// Иинициализация класса для хранения данных об .exe файле
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <param name="version">Версия файла</param>
        /// <param name="dataOfCreation">Дата создания файла</param>
        public FileInfo(string fileName, string version, string dataOfCreation)
        {
            this.FileName = fileName;
            this.Version = version;
            this.DataOfCreation = dataOfCreation;
            this.Indx = 0;
        }

        /// <summary>
        /// Иинициализация класса для хранения данных об .exe файле
        /// с определенным индексом
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <param name="version">Версия файла</param>
        /// <param name="dataOfCreation">Дата создания файла</param>
        /// <param name="indx">Индекс файла</param>
        public FileInfo(string fileName, string version, string dataOfCreation, int indx) : this(fileName, version, dataOfCreation)
        {
            this.Indx = indx;
        }

        #region Private Helpers

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

        #endregion
    }
}
