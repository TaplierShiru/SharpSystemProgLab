using CreationBusinessDLL.DataBase;
using CreationBusinessDLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.CSV
{
    /// <summary>
    /// Класс для работы с .exe файлами - записи/удалении/сохранении/загрузки данных об файле
    /// </summary>
    public class CSVFileController : CSVFileControllerBase<CSVFileInfo>, ICSVFileController
    {

        /// <summary>
        /// Инициализация класса для работы с файлом csv
        /// </summary>
        public CSVFileController()
        {
            var files = DbController.GetFiles();
            foreach (CSVFileInfo elem in files)
            {
                base.Add(elem);
            }
        }

        /// <inheritdoc/>
        public void Add(string fileName, string version, string dataOfCreation)
        {
            var new_fileInfo = new CSVFileInfo(fileName, version, dataOfCreation);
            DbController.AddFileInfo(new_fileInfo);
            base.Add(new_fileInfo);
        }

        /// <inheritdoc/>
        public override void Add(string path)
        { 
            string version = FileVersionInfo.GetVersionInfo(path).FileVersion; // Will typically return "1.0.0.0"
            var fileInfo = new FileInfo(path);
            string fileName = fileInfo.Name;
            string dataOfCreation = fileInfo.CreationTime.ToString();

            this.Add(fileName, version, dataOfCreation);
        }

        /// <inheritdoc/>
        public new void Remove(int indx)
        {
            DbController.DeleteFileInfo((CSVFileInfo)base.GetAtIndexDataElem(indx));
            base.Remove(indx);
        }

        /// <inheritdoc/>
        public bool Edit(int indx_old, string new_fileName, string new_version, string new_dataOfCreation)
        {
            var old_fileInfo = (CSVFileInfo)base.GetAtIndexDataElem(indx_old);
            if (old_fileInfo.FileName == new_fileName &&
                old_fileInfo.Version == new_version && 
                old_fileInfo.DataOfCreation == new_dataOfCreation)
            {
                // Elemnt does not change at all
                return false;
            }
            DbController.EditFileInfo(old_fileInfo, new_fileName, new_version, new_dataOfCreation);

            old_fileInfo.FileName = new_fileName;
            old_fileInfo.Version = new_version;
            old_fileInfo.DataOfCreation = new_dataOfCreation;

            return true;
        }

        /// <inheritdoc/>
        public new void Load(string path)
        {
            int old_size = base.GetListSize;
            base.Load(path);
            int new_size = base.GetListSize;
            // Update database
            for (int i = old_size; i < new_size; i++)
            {
                DbController.AddFileInfo((CSVFileInfo)base.GetAtIndexDataElem(i));
            }
        }
    }
}
