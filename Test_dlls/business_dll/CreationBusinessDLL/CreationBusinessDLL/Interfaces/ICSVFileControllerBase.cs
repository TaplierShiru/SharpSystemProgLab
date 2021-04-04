using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.Interfaces
{
    public interface ICSVFileControllerBase
    {
        int GetListSize { get; }
        string[] GetAtIndex(int index);
        void Add(ICSVDataElem singleElem);
        void Add(string path);
        bool Remove(ICSVDataElem singleElem);
        void Remove(int indx);
        void Edit(int indx, ICSVDataElem oldSingleElem, ICSVDataElem newSingleElem);
        void Load(string path);
        void Save(string path);
    }
}
