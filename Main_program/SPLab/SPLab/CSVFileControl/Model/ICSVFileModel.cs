using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLab.CSVFileControl
{
    /// <summary>
    /// Интерфейс описывающий модель для CSVFile виджета
    /// </summary>
    interface ICSVFileModel
    {
        /// <summary>
        /// Возвращает массив данных о файлах
        /// </summary>
        List<FileInfo> GetList {get;}

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

        /// <summary>
        /// Добавить в массив данные об файле
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <param name="version">Версия файла</param>
        /// <param name="dataOfCreation">Дата создания файла</param>
        void Add(string fileName, string version, string dataOfCreation);

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
        /// Возвращает размер массива, хранящего данные о файлах
        /// </summary>
        int GetSize();

        /// <summary>
        /// Вернуть данные записи по индексу
        /// </summary>
        /// <param name="index">Индекс записи</param>
        /// <returns>Массив данных записи</returns>
        string[] GetAtIndex(int indx);

        /// <summary>
        /// Устанавливает значение: имя файла, версию и дату созданию из элемента
        /// По индексу `indx_old` в хранящийся коллекции элементу `fileInfo`
        /// </summary>
        /// <param name="indx_old">Индекс элемента в кранящийся коллекции</param>
        /// <param name="fileInfo">Объект в котором следует обновить: имя файла, версию и дату созданию элемента</param>
        void RestoreValues(int indx_old, FileInfo fileInfo);

        /// <summary>
        /// Обновленние значения в business длл
        /// </summary>
        /// <param name="indx_edit">Индекс элемента, который был изменен</param>
        /// <param name="newFileInfo">Новый объект (измененный) с информацией об файле</param>
        /// <returns>true - если объект был изменен, иначе false</returns>
        bool UpdateValues(int indx_edit, FileInfo newFileInfo);
    }
}
