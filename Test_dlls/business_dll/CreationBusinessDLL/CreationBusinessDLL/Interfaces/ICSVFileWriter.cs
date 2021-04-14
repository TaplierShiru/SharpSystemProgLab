using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с csv данными:
    /// Делает запись данных в csv файл
    /// </summary>
    public interface ICSVFileWriter
    {
        /// <summary>
        /// Записывает элемент в csv файл
        /// </summary>
        /// <param name="singleElem">Элемент csv таблицы</param>
        void WriteCSV(ICSVDataElem singleElem);

        /// <summary>
        /// Закрытие текущего потока записи
        /// </summary>
        void Close();
    }
}
