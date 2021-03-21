using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLab
{
    public class FileInfo : INotifyPropertyChanged
    {
        private string _fileName;
        private string _version;
        private string _dataOfCreation;

        public string FileName 
        {
            get { return this._fileName; }
            set 
            {
                this._fileName = value;
                this.NotifyPropertyChanged("FileName");
            }
        }

        public string Version
        {
            get { return this._version; }
            set
            {
                this._version = value;
                this.NotifyPropertyChanged("Version");
            }
        }

        public string DataOfCreation
        {
            get { return this._dataOfCreation; }
            set
            {
                this._dataOfCreation = value;
                this.NotifyPropertyChanged("DataOfCreation");
            }
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Private Helpers

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
