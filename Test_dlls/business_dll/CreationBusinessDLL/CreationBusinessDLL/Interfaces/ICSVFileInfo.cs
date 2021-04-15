using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.Interfaces
{
    /// <summary>
    /// Интерфейс описывающий данные об одном .exe файле
    /// </summary>
    public interface ICSVFileInfo : ICSVDataElem
    {
        /// <summary>
        /// Id данного элемента (уникальное значение) 
        /// </summary>
        int Id { get; set; }

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
    }
}
