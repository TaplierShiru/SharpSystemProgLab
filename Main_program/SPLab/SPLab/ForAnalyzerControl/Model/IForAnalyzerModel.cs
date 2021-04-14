using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLab.ForAnalyzerControl
{
    interface IForAnalyzerModel
    {
        string AnalyzedCode { get; set; }
        bool AnalyzeCode();
        int GetNumFor { get; }
        string GetErrorMessage { get; }
    }
}
