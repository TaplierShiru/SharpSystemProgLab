using CreationBusinessDLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.CSV
{
    /// <summary>
    /// Класс для базовой работы с csv файлами, 
    /// содержащий структуру для хранения данных строк csv файла
    /// </summary>
    /// <typeparam name="T">Интерфейс хранящий один элемент csv строки</typeparam>
    public class CSVFileControllerBase<T> : ICSVFileControllerBase where T : ICSVDataElem, new()
    {
        /// <summary>
        /// Структура, хранящая элементы 
        /// </summary>
        private List<ICSVDataElem> _elements;

        /// <inheritdoc/>
        public int GetListSize => this._elements.Count;

        /// <summary>
        /// Инициализация класса для работы с файлом csv
        /// </summary>
        public CSVFileControllerBase()
        {
            this._elements = new List<ICSVDataElem>();
        }

        /// <summary>
        /// Инициализация класса для работы с файлом csv
        /// </summary>
        /// <param name="path">Путь до csv файла из которого будут считаны данные, пример: "/home/user/tas.csv"</param>
        public CSVFileControllerBase(string path)
        {
            this.Load(path);
        }

        /// <inheritdoc/>
        public void Load(string path)
        {
            var reader = new CSVFileReader(path);
            this._elements = reader.ReadCSV<T>();
            reader.Close();
        }

        /// <inheritdoc/>
        public void Add(ICSVDataElem singleElem)
        {
            this._elements.Add(singleElem);
        }

        /// <inheritdoc/>
        public virtual void Add(string path)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Remove(int indx)
        {
            this._elements.RemoveAt(indx);
        }

        /// <inheritdoc/>
        public void Save(string path)
        {
            var writer = new CSVFileWriter(path);
            foreach (var elem in this._elements)
            {
                writer.WriteCSV(elem);
            }

            writer.Flush();
            writer.Close();
        }

        /// <inheritdoc/>
        public string[] GetAtIndex(int index)
        {
            return this._elements[index].GetCSVData;
        }

    }
}
