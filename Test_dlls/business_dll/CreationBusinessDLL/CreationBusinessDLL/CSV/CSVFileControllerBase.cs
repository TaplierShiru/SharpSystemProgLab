using CreationBusinessDLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.CSV
{
    /// <summary>
    /// Keep certain CSV data for futher work with it
    /// </summary>
    /// <typeparam name="T">Interface of single CSV data elements</typeparam>
    public class CSVFileControllerBase<T> : ICSVFileControllerBase where T : ICSVDataElem, new()
    {
        private List<ICSVDataElem> _elements;

        public int GetListSize => this._elements.Count;

        /// <summary>
        /// Init CSV file controller class with empty elements
        /// </summary>
        public CSVFileControllerBase()
        {
            this._elements = new List<ICSVDataElem>();
        }

        /// <summary>
        /// Init CSV file controller class with certain CSV data
        /// from `path`
        /// </summary>
        /// <param name="path">Path to csv file, example: "/home/user/tas.csv"</param>
        public CSVFileControllerBase(string path)
        {
            this.Load(path);
        }

        /// <summary>
        /// Load CSV file from certain `path`
        /// Into CSV file controller
        /// </summary>
        /// <param name="path">Path to csv file, example: "/home/user/tas.csv"</param>
        public void Load(string path)
        {
            var reader = new CSVFileReader(path);
            this._elements = reader.ReadCSV<T>();
            reader.Close();
        }

        /// <summary>
        /// Add single CSV element into controller
        /// </summary>
        /// <param name="singleElem">Single CSV elements</param>
        public void Add(ICSVDataElem singleElem)
        {
            this._elements.Add(singleElem);
        }

        public virtual void Add(string path)
        {
            throw new NotImplementedException();
        }
        public void Edit(int indx, ICSVDataElem oldSingleElem, ICSVDataElem newSingleElem)
        {
            throw new NotImplementedException();
        }

        public void Remove(int indx)
        {
            this._elements.RemoveAt(indx);
        }

        public bool Remove(ICSVDataElem singleElem)
        {
            return this._elements.Remove(singleElem);
        }
        /// <summary>
        /// Write current elements into CSV file
        /// </summary>
        /// <param name="path">Path where save CSV data, example: "/home/user/data.csv"</param>
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

        public string[] GetAtIndex(int index)
        {
            return this._elements[index].GetCSVData;
        }

    }
}
