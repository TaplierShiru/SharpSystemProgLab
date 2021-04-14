using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SPLab.ForAnalyzerControl
{
    interface IForAnalyzerViewModel
    {
        string AnalyzedCode { get; set; }
        int GetNumFor { get; }
        string GetErrorMessage { get; }
        ICommand AnalyzeCommand { get; }
    }
}
