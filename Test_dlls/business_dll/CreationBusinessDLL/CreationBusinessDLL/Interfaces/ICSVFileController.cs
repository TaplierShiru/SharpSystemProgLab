using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.Interfaces
{
    interface ICSVFileController
    {
        void Add(ICSVDataElem singleElem);
        bool Remove(int indx, ICSVDataElem singleElem);
        void Edit(int indx, ICSVDataElem oldSingleElem, ICSVDataElem newSingleElem);
        void Load(string path);
        void Save(string path);
    }
}
