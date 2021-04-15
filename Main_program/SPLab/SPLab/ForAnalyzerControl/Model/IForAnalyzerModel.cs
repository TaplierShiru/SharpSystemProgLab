using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLab.ForAnalyzerControl
{
    /// <summary>
    /// Интерфейс для Model части ForAnalyzer виджета
    /// </summary>
    interface IForAnalyzerModel
    {
        /// <summary>
        /// Код который следует проанализировать
        /// </summary>
        string AnalyzedCode { get; set; }

        /// <summary>
        /// Возвращает кол-во выполнений цикла в анализируемом коде
        /// Внимание! Код перед этим должен быть проанализирован, т. е. вызванно `AnalyzeCode`
        /// </summary>
        int GetNumFor { get; }

        /// <summary>
        /// Возвращает сообщение об ошибке в анализируемом коде
        /// Внимание! Код перед этим должен быть проанализирован, т. е. вызванно `AnalyzeCode`
        /// </summary>
        string GetErrorMessage { get; }

        /// <summary>
        /// Анализ кода
        /// </summary>
        /// <returns>true - в случае успешного анализа, иначе false</returns>
        bool AnalyzeCode();
    }
}
