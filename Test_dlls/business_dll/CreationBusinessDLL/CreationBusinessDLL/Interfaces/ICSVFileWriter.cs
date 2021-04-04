using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.Interfaces
{
    public interface ICSVFileWriter
    {
        void WriteCSV(ICSVDataElem singleElem);
        void Close();
    }
}
