using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.Interfaces
{
    interface ICSVFileReader
    {
        List<ICSVDataElem> ReadCSV<T>() where T : ICSVDataElem, new();
        void Close();
    }
}
