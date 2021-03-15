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
    /// Class to read data from a CSV file
    /// </summary>
    class CSVFileReader : StreamReader, ICSVFileReader
    {
        public CSVFileReader(Stream stream) : base(stream)
        { }

        public CSVFileReader(string filename) : base(filename)
        { }

        /// <summary>
        /// Reads a row of data from a CSV file
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
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
