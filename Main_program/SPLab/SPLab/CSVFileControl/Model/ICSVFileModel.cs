using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLab.CSVFileControl
{
    interface ICSVFileModel
    {
        List<FileInfo> GetList {get;}

        void Load(string path);
        void Save(string path);

        void Add(string fileName, string version, string dataOfCreation);

        void Add(string path);

        void Remove(int indx);
        int GetSize();

        string[] GetAtIndex(int indx);
    }
}
