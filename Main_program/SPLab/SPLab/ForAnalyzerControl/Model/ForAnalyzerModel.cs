using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SPLab.ForAnalyzerControl
{
    class ForAnalyzerModel : IForAnalyzerModel
    {
        private Type _classType;
        private Assembly _dll_info;
        private object _sharp_analyzer;
        private string _path_to_dll = @"D:\University\СП\Лаба\SharpSystemProgLab\Test_dlls\" +
                                      @"business_dll\CreationBusinessDLL\CreationBusinessDLL\" +
                                      @"bin\Debug\CreationBusinessDLL.dll";


        public ForAnalyzerModel()
        {
            this._dll_info = Assembly.LoadFile(this._path_to_dll);
            this._classType = this._dll_info.GetType("CreationBusinessDLL.SharpAnalyzer.SharpForAnalyzer");
            this._sharp_analyzer = Activator.CreateInstance(this._classType);
        }

        public string AnalyzedCode
        {
            get => (string)this._classType.GetProperty("AnalyzedCode").GetValue(this._sharp_analyzer);
            set => this._classType.GetProperty("AnalyzedCode").SetValue(this._sharp_analyzer, value);
        }

        public int GetNumFor => (int)this._classType.GetProperty("GetNumFor").GetValue(this._sharp_analyzer);

        public string GetErrorMessage => (string)this._classType.GetProperty("GetErrorMessage").GetValue(this._sharp_analyzer);

        public bool AnalyzeCode()
        {
            return (bool)this._classType.GetMethod("AnalyzeCode").Invoke(this._sharp_analyzer, null);
        }
    }
}
