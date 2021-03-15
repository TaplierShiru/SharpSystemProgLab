using CreationBusinessDLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.CSV
{
    class CSVFileController<T> : ICSVFileController where T : ICSVDataElem, new()
    {
        private List<ICSVDataElem> _elements;
        public CSVFileController()
        {
            this._elements = new List<ICSVDataElem>();
        }
        public CSVFileController(string path)
        {
            this.Load(path);
        }
        public void Load(string path)
        {
            var reader = new CSVFileReader(path);
            this._elements = reader.ReadCSV<T>();
            reader.Close();
        }
        public void Add(ICSVDataElem singleElem)
        {
            this._elements.Add(singleElem);
        }

        public void Edit(int indx, ICSVDataElem oldSingleElem, ICSVDataElem newSingleElem)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int indx, ICSVDataElem singleElem)
        {
            throw new NotImplementedException();
        }

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
    }
}
