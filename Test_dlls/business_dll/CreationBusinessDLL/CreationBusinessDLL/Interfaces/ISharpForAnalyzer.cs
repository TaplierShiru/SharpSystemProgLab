using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.Interfaces
{
    public interface ISharpForAnalyzer
    {
        string AnalyzedCode { get; set; }
        bool AnalyzeCode();
        int GetNumFor { get; }
        string GetErrorMessage { get; }

    }
}
