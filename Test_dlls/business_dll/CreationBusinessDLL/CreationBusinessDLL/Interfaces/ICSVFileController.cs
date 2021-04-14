using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с .exe файлами - записи/удалении/сохранении/загрузки данных об файле
    /// </summary>
    public interface ICSVFileController
    {
        /// <summary>
        /// Добавление информации об файле в массив csv файла
        /// </summary>
        /// <param name="fileName">Название файла</param>
        /// <param name="version">Версия файла</param>
        /// <param name="dataOfCreation">Дата создания файла</param>
        void Add(string fileName, string version, string dataOfCreation);
    }
}
