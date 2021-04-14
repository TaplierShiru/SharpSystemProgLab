using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.Interfaces
{
    /// <summary>
    /// Интерфейс для базовой работы с csv файлами, 
    /// содержащий структуру для хранения данных строк csv файла
    /// </summary>
    public interface ICSVFileControllerBase
    {
        /// <summary>
        /// Размер массива записей
        /// </summary>
        int GetListSize { get; }

        /// <summary>
        /// Вернуть данные записи по индексу
        /// </summary>
        /// <param name="index">Индекс записи</param>
        /// <returns>Массив данных записи</returns>
        string[] GetAtIndex(int index);

        /// <summary>
        /// Добавление элемента csv в текущий массив
        /// </summary>
        /// <param name="singleElem">Элемент, который нужно вставить</param>
        void Add(ICSVDataElem singleElem);

        /// <summary>
        /// Чтение данных с определенного файла и добавление его данных в текущий массив
        /// </summary>
        /// <param name="path">Путь до файла, с которого нужно взять информацию</param>
        void Add(string path);

        /// <summary>
        /// Удаление элемента по индексу из массива
        /// </summary>
        /// <param name="indx">Индекс элемента, который следует удалить</param>
        /// <returns>Булевое значение, показывающие было ли успешно удаление</returns>
        void Remove(int indx);

        /// <summary>
        /// Чтение csv файла и загрузка всех его записей в текущий массив.
        /// Текущий массив перед этим будет очищен
        /// </summary>
        /// <param name="path">Путь до csv файла, с которого нужно считать данные</param>
        void Load(string path);

        /// <summary>
        /// Сохранение текущего массива в csv файл
        /// </summary>
        /// <param name="path">Путь до сохранения csv файла</param>
        void Save(string path);
    }
}
