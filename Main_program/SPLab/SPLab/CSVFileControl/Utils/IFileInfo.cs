using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLab.CSVFileControl
{
    /// <summary>
    /// Интерфейс хранящий данные об одном .exe файле
    /// для их последующей визуализации
    /// </summary>
    interface IFileInfo
    {
        /// <summary>
        /// Имя файла
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// Версия файла
        /// </summary>
        string Version { get; set; }

        /// <summary>
        /// Дата создания файла
        /// </summary>
        string DataOfCreation { get; set; }

        /// <summary>
        /// Возвращает индекс данного элемента
        /// </summary>
        int Indx { get; set; }
    }
}
