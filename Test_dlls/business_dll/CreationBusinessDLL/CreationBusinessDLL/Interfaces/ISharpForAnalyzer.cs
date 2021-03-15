using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL
{
    interface ISharpForAnalyzer
    {

        bool Analyze(string in_str);
        int GetNumFor();
        KeyValuePair<int, string> GetError();

    }
}
