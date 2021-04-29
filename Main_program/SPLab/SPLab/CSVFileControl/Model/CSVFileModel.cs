using CreationBusinessDLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SPLab.CSVFileControl
{
    /// <summary>
    /// Класс описывающий модель для CSVFile виджета
    /// </summary>
    class CSVFileModel : ICSVFileModel
    {
        // Поля необходимые для работы с dll
        private Type _classType;
        private Assembly _dll_info;
        private object _file_controller;
        // Путь до dll 
        private string _path_to_dll = @"CreationBusinessDLL.dll";
        
        ///<inheritdoc/>
        public List<FileInfo> GetList
        {
            get
            {
                if (this._file_controller is null)
                {
                    return null;
                }
                List<FileInfo> fileInfoList = new List<FileInfo>();
                for (int i = 0; i < this.GetSize(); i++)
                {
                    string[] taken_params = this.GetAtIndex(i);
                    fileInfoList.Add(new FileInfo(taken_params[0], taken_params[1], taken_params[2], i));
                }
                return fileInfoList;
            }
        }

        /// <summary>
        /// Инициализация класса модели CSVFile виджета
        /// </summary>
        public CSVFileModel()
        {
            this._dll_info = Assembly.LoadFile(Path.GetFullPath(this._path_to_dll));
            this._classType = this._dll_info.GetType("CreationBusinessDLL.CSV.CSVFileController");
            this._file_controller = Activator.CreateInstance(this._classType);
        }

        ///<inheritdoc/>
        public void Load(string path)
        {
            this._classType.GetMethod("Load").Invoke(this._file_controller, new object[] {
                path
            });

        }

        ///<inheritdoc/>
        public void Save(string path)
        {
            this._classType.GetMethod("Save").Invoke(this._file_controller, new object[] {
                path
            });
        }

        ///<inheritdoc/>
        public void Add(string fileName, string version, string dataOfCreation)
        {
            this._classType.GetMethod(
                    "Add", 
                    new Type[] { typeof(string), typeof(string), typeof(string) }
                ).Invoke(this._file_controller, new object[] {
                    fileName, version, dataOfCreation
                }
            );
        }

        ///<inheritdoc/>
        public void Add(string path)
        {
            this._classType.GetMethod(
                    "Add",
                    new Type[] { typeof(string) }
                ).Invoke(this._file_controller, new object[] {
                    path
                }
            );
        }

        ///<inheritdoc/>
        public void Remove(int indx)
        {
            this._classType.GetMethod(
                    "Remove",
                    new Type[] { typeof(int) }
                ).Invoke(this._file_controller, new object[] {
                    indx
                }
            );
        }

        ///<inheritdoc/>
        public int GetSize()
        {
            var size = this._classType.GetProperty("GetListSize").GetValue(this._file_controller);
            return size is null ? 0 : (int)size;
        }

        ///<inheritdoc/>
        public string[] GetAtIndex(int indx)
        {
            return (string[])this._classType.GetMethod(
                    "GetAtIndex", 
                    new Type[] { typeof(int) }
                ).Invoke(this._file_controller, new object[] { indx });
        }

        /// <inheritdoc/>
        public void RestoreValues(int indx_old, FileInfo newFileInfo)
        {
            var infos = this.GetAtIndex(indx_old);
            newFileInfo.FileName = infos[0];
            newFileInfo.Version = infos[1];
            newFileInfo.DataOfCreation = infos[2];
        }

        /// <inheritdoc/>
        public bool UpdateValues(int indx_edit, FileInfo newFileInfo)
        {
            // Берем обновленную дату создания (новое)
            var date_creation = newFileInfo.DataOfCreation;

            // Проверяем корректность новой даты
            DateTime result;
            CultureInfo ci = CultureInfo.CurrentCulture;
            string[] fmts = ci.DateTimeFormat.GetAllDateTimePatterns();
            if (!DateTime.TryParseExact(date_creation, fmts, ci,
               DateTimeStyles.AssumeLocal, out result))
            {
                // Кидаем исключение, если дата была введение неверно
                throw new FormatException();
            }
            // Дата была введена верно, делаем обновление значения поля
            return (bool)this._classType.GetMethod(
                    "Edit",
                    new Type[] { typeof(int), typeof(string), typeof(string), typeof(string) }
                ).Invoke(this._file_controller, new object[] {
                    indx_edit, newFileInfo.FileName, newFileInfo.Version, newFileInfo.DataOfCreation
                }
            );
        }
    }
}
