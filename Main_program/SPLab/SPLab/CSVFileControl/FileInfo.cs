using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLab.CSVFileControl
{
    // Impliments ICSVFileInfo - swap it in dll and take list from dll - 
    // After that connect list from dll to view - we have what we want!!!
    public class FileInfo : INotifyPropertyChanged
    {
        public static readonly char SPLIT_CHAR = ';';
        public static readonly int INDX_FILE_NAME = 0;
        public static readonly int INDX_VERSION = 1;
        public static readonly int INDX_DATA_CREATION = 2;
    
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private string _fileName;
        private string _version;
        private string _dataOfCreation;
        private int _indx;

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

        public int Indx
        {
            get { return this._indx; }
            set { this._indx = value; }
        }

        /// <summary>
        /// Return elements in next order:
        /// file_name, version, data_creation
        /// </summary>
        public string[] GetCSVData => new string[] { this._fileName, this._version, this._dataOfCreation };

        /// <summary>
        /// Set up CSV data with certain input string
        /// Each element must separate each other with some char 
        /// (By default its ;)
        /// Order of CSV: file_name, version, data_creation
        /// Example: "meow_file; v1.222; 20.03.2000"
        /// </summary>
        public string SetCSVData
        {
            set
            {
                string[] in_str = value.Split(FileInfo.SPLIT_CHAR);
                this.FileName = in_str[FileInfo.INDX_FILE_NAME];
                this.Version = in_str[FileInfo.INDX_VERSION];
                this.DataOfCreation = in_str[FileInfo.INDX_DATA_CREATION];

            }
        }

        public FileInfo()
        {
            this.FileName = "None";
            this.Version = "None";
            this.DataOfCreation = "None";
        }
        public FileInfo(string fileName, string version, string dataOfCreation)
        {
            this.FileName = fileName;
            this.Version = version;
            this.DataOfCreation = dataOfCreation;
        }
        public FileInfo(string fileName, string version, string dataOfCreation, int indx) : this(fileName, version, dataOfCreation)
        {
            this.Indx = indx;
        }
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
