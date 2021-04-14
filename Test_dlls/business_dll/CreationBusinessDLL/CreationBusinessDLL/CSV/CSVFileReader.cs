using CreationBusinessDLL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.CSV
{
    /// <summary>
    /// Класс для чтения данных из csv файла
    /// </summary>
    class CSVFileReader : StreamReader, ICSVFileReader
    {
        /// <summary>
        /// Конструктор для создания класса чтения csv элементов из файл
        /// </summary>
        /// <param name="stream">Класс потока, куда из которого необходимо считывать данные</param>
        public CSVFileReader(Stream stream) : base(stream)
        { }

        /// <summary>
        /// Конструктор для создания класса чтения csv элементов из файл
        /// </summary>
        /// <param name="filename">Название файла, от куда следует считывать данные</param>
        public CSVFileReader(string filename) : base(filename)
        { }

        /// <inheritdoc/>
        public List<ICSVDataElem> ReadCSV<T>() where T : ICSVDataElem, new()
        {
            string lineText = ReadLine();
            List<ICSVDataElem> elements = new List<ICSVDataElem>();
            while (!String.IsNullOrEmpty(lineText))
            {
                T rowElement = new T();
                rowElement.SetCSVData = lineText;
                elements.Add(rowElement);
                lineText = ReadLine();
            }

            return elements;
        }
    }
}
