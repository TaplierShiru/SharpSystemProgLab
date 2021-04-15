using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SPLab.ForAnalyzerControl
{
    /// <summary>
    /// Интерфейс ViewModel части для виджета ForAnalyzer
    /// </summary>
    interface IForAnalyzerViewModel
    {
        /// <summary>
        /// Анализируемый кусок кода
        /// </summary>
        string AnalyzedCode { get; set; }

        /// <summary>
        /// Кол-во итераций цикла
        /// </summary>
        int GetNumFor { get; }

        /// <summary>
        /// Сообщение об ошибках
        /// </summary>
        string GetErrorMessage { get; }

        /// <summary>
        /// Команда анализа куска кода, 
        /// Производится подсчет кол-ва итераций и запись сообщения об ошибках
        /// </summary>
        ICommand AnalyzeCommand { get; }
    }
}
