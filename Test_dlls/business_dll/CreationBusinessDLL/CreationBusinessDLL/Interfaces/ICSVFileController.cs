using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.Interfaces
{
    public interface ICSVFileController
    {
        void Add(string fileName, string version, string dataOfCreation);
    }
}
