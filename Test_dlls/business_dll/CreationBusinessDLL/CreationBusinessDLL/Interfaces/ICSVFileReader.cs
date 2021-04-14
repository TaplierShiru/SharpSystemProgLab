using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с csv данными:
    /// Делает чтение данных из csv файла
    /// </summary>
    public interface ICSVFileReader
    {
        /// <summary>
        /// Считывается все строки из csv файла
        /// </summary>
        /// <typeparam name="T">Параметр для работы с одним элементом строки csv файла</typeparam>
        /// <returns>Возвращает лист csv элементов</returns>
        List<ICSVDataElem> ReadCSV<T>() where T : ICSVDataElem, new();

        /// <summary>
        /// Закрытие текущего потока записи
        /// </summary>
        void Close();
    }
}
