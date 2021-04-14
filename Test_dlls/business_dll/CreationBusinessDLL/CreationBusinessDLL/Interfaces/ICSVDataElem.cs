using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.Interfaces
{
    /// <summary>
    /// Интерфейс для хранения информации одной строки csv
    /// </summary>
    public interface ICSVDataElem
    { 
        /// <summary>
        /// Возвращает хранимые элементы в виде массива
        /// </summary>
        string[] GetCSVData { get; }

        /// <summary>
        /// Установка строки csv файла для её хранения
        /// </summary>
        string SetCSVData { set; }
    }
}
