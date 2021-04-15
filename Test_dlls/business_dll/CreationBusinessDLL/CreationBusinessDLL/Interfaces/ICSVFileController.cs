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

        /// <summary>
        /// Изменить значение в элементе по индексу `indx_old`
        /// На новые значения
        /// </summary>
        /// <param name="indx_old">Индекс элемента, который стоит заменить</param>
        /// <param name="new_fileName">Имя нового файла</param>
        /// <param name="new_version">Новая версия файла</param>
        /// <param name="new_dataOfCreation">Новая дата создания файла</param>
        void Edit(int indx_old, string new_fileName, string new_version, string new_dataOfCreation);
    }
}
