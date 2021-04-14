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
    /// Класс для работы с csv данными:
    /// Делает запись данных в csv файл
    /// </summary>
    class CSVFileWriter : StreamWriter, ICSVFileWriter
    {
        /// <summary>
        /// Конструктор для создания класса записи csv элементов в файл
        /// </summary>
        /// <param name="stream">Класс потока, куда необходимо записывать данные</param>
        public CSVFileWriter(Stream stream) : base(stream)
        { }

        /// <summary>
        /// Конструктор для создания класса записи csv элементов в файл
        /// </summary>
        /// <param name="filename">Название файла, куда следует записывать данные, 
        /// при его отсуствии - файл будет создан
        /// </param>
        public CSVFileWriter(string filename) : base(filename)
        { }

        /// <inheritdoc/>
        public void WriteCSV(ICSVDataElem singleElem)
        {
            StringBuilder builder = new StringBuilder();
            bool firstColumn = true;
            foreach (string value in singleElem.GetCSVData)
            {
                // Add separator if this isn't the first value
                if (!firstColumn)
                {
                    builder.Append(CSVFileInfo.SPLIT_CHAR);

                }
                // Implement special handling for values that contain comma or quote
                // Enclose in quotes and double up any double quotes
                if (value.IndexOfAny(new char[] { '"', ';' }) != -1)
                {
                    builder.AppendFormat("\"{0}\"", value.Replace("\"", "\"\""));
                }
                else
                {
                    builder.Append(value);
                }
                firstColumn = false;
            }
            WriteLine(builder.ToString());
        }
    }
}
