using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SPLab.ForAnalyzerControl
{
    /// <summary>
    /// Класс реализующий Model часть для ForAnalyzer виджета
    /// </summary>
    class ForAnalyzerModel : IForAnalyzerModel
    {
        // Поля необходимые для работы с dll файлом
        private Type _classType;
        private Assembly _dll_info;
        private object _sharp_analyzer;
        // Путь до dll файла
        private string _path_to_dll = @"CreationBusinessDLL.dll";

        ///<inheritdoc/>
        public string AnalyzedCode
        {
            get => (string)this._classType.GetProperty("AnalyzedCode").GetValue(this._sharp_analyzer);
            set => this._classType.GetProperty("AnalyzedCode").SetValue(this._sharp_analyzer, value);
        }

        ///<inheritdoc/>
        public int GetNumFor => (int)this._classType.GetProperty("GetNumFor").GetValue(this._sharp_analyzer);

        ///<inheritdoc/>
        public string GetErrorMessage => (string)this._classType.GetProperty("GetErrorMessage").GetValue(this._sharp_analyzer);

        public ForAnalyzerModel()
        {
            this._dll_info = Assembly.LoadFile(Path.GetFullPath(this._path_to_dll));
            this._classType = this._dll_info.GetType("CreationBusinessDLL.SharpAnalyzer.SharpForAnalyzer");
            this._sharp_analyzer = Activator.CreateInstance(this._classType);
        }

        ///<inheritdoc/>
        public bool AnalyzeCode()
        {
            return (bool)this._classType.GetMethod("AnalyzeCode").Invoke(this._sharp_analyzer, null);
        }
    }
}
