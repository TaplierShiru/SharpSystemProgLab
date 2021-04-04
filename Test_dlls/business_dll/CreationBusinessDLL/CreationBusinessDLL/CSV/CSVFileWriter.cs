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
    /// Class to write data to a CSV file
    /// </summary>
    class CSVFileWriter : StreamWriter, ICSVFileWriter
    {

        public CSVFileWriter(Stream stream) : base(stream)
        { }

        public CSVFileWriter(string filename) : base(filename)
        { }

        /// <summary>
        /// Writes a single element to a CSV file.
        /// </summary>
        /// <param name="singleElem">The element to be written</param>
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
