using System;
using CreationBusinessDLL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.CSV
{
    public class CSVFileInfo : ICSVFileInfo
    {
        public static readonly char SPLIT_CHAR = ';';
        public static readonly int INDX_FILE_NAME = 0;
        public static readonly int INDX_VERSION = 1;
        public static readonly int INDX_DATA_CREATION = 2;

        private string _file_name;
        private string _version;
        private string _data_creation;
        public CSVFileInfo()
        {
            this._file_name = "";
            this._version = "";
            this._data_creation = "";
        }

        public CSVFileInfo(string file_name, string version, string data_cretion)
        {
            this._file_name = file_name;
            this._version = version;
            this._data_creation = data_cretion;
        }
        public string FileName { get => this._file_name; set => this._file_name = value; }
        public string Version { get => this._version; set => this._version = value; }
        public string DataOfCreation { get => this._data_creation; set => this._data_creation = value; }

        /// <summary>
        /// Return elements in next order:
        /// file_name, version, data_creation
        /// </summary>
        public string[] GetCSVData => new string[] { this._file_name, this._version, this._data_creation };

        /// <summary>
        /// Set up CSV data with certain input string
        /// Each element must separate each other with some char 
        /// (By default its ;)
        /// Order of CSV: file_name, version, data_creation
        /// Example: "meow_file; v1.222; 20.03.2000"
        /// </summary>
        public string SetCSVData { set {
                string[] in_str = value.Split(CSVFileInfo.SPLIT_CHAR);
                this.FileName = in_str[CSVFileInfo.INDX_FILE_NAME];
                this.Version = in_str[CSVFileInfo.INDX_VERSION];
                this.DataOfCreation = in_str[CSVFileInfo.INDX_DATA_CREATION];

            }
        }
    }
}
