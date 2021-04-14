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
        /// <inheritdoc/>
        public void Add(string fileName, string version, string dataOfCreation)
        {
            base.Add(new CSVFileInfo(fileName, version, dataOfCreation));
        }

        /// <inheritdoc/>
        public override void Add(string path)
        { 
            string version = FileVersionInfo.GetVersionInfo(path).FileVersion; // Will typically return "1.0.0.0"
            var fileInfo = new FileInfo(path);
            string fileName = fileInfo.Name;
            string dataOfCreation = fileInfo.CreationTime.ToString();

            base.Add(new CSVFileInfo(fileName, version, dataOfCreation));
        }
    }
}
