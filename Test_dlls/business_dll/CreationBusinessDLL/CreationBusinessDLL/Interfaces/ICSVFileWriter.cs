using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.Interfaces
{
    interface ICSVFileWriter
    {
        void WriteCSV(ICSVDataElem singleElem);
        void Close();
    }
}
