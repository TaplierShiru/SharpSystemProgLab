using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.Interfaces
{
    public interface ICSVFileInfo : ICSVDataElem
    {
        string FileName { get; set; }
        string Version { get; set; }
        string DataOfCreation { get; set; }
    }
}
