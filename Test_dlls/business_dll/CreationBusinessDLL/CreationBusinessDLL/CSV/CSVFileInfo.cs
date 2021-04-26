using System;
using CreationBusinessDLL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.CSV
{
    /// <summary>
    /// Класс описывающий данные об одном .exe файле
    /// </summary>
    public class CSVFileInfo : ICSVFileInfo
    {
        // Если какое-то из полей неизвестно - оно будет иметь такое имя
        public static readonly string UNKNOWN = "Unknown";
        // Элементы одной строки разделяются ; символом
        public static readonly char SPLIT_CHAR = ';';
        // Далее идет порядок хранения данных в csv файле 
        // это нужно для чтения и записи данных в csv файл
        public static readonly int INDX_FILE_NAME = 0;
        public static readonly int INDX_VERSION = 1;
        public static readonly int INDX_DATA_CREATION = 2;

        private string _file_name;
        private string _version;
        private string _data_creation;

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string FileName { get => this._file_name; set => this._file_name = value; }
        
        /// <inheritdoc/>
        public string Version { get => this._version; set => this._version = value; }
        
        /// <inheritdoc/>
        public string DataOfCreation { get => this._data_creation; set => this._data_creation = value; }


        /// <inheritdoc/>
        public string[] GetCSVData => new string[] { this._file_name, this._version, this._data_creation };

        /// <inheritdoc/>
        public string SetCSVData
        {
            set
            {
                string[] in_str = value.Split(CSVFileInfo.SPLIT_CHAR);
                this.FileName = in_str[CSVFileInfo.INDX_FILE_NAME];
                this.Version = in_str[CSVFileInfo.INDX_VERSION];
                this.DataOfCreation = in_str[CSVFileInfo.INDX_DATA_CREATION];

            }
        }

        /// <summary>
        /// Создание класса для хранения информации об одном файле
        /// </summary>
        public CSVFileInfo()
        {
            this._file_name = "";
            this._version = "";
            this._data_creation = "";
        }

        /// <summary>
        /// Создание класса для хранения данных об файле
        /// </summary>
        /// <param name="file_name">Имя файла</param>
        /// <param name="version">Версия файла</param>
        /// <param name="data_cretion">Дата создания файла</param>
        public CSVFileInfo(string file_name, string version, string data_cretion)
        {
            if (file_name is null)
            {
                file_name = CSVFileInfo.UNKNOWN;
            }

            if (version is null)
            {
                version = CSVFileInfo.UNKNOWN;
            }

            if (data_cretion is null)
            {
                data_cretion = CSVFileInfo.UNKNOWN;
            }

            this._file_name = file_name;
            this._version = version;
            this._data_creation = data_cretion;
        }
    }
}
