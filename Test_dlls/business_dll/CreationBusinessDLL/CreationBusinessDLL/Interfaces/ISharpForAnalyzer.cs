using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.Interfaces
{
    /// <summary>
    /// Интерфейс для анализа строки for из синтаксиса языка c#
    /// И подсчета количества выполнений цикла
    /// </summary>
    public interface ISharpForAnalyzer
    {
        /// <summary>
        /// Код который следует анализировать
        /// </summary>
        string AnalyzedCode { get; set; }

        /// <summary>
        /// Количество выполнений цикла for
        /// </summary>
        int GetNumFor { get; }

        /// <summary>
        /// Сообщение об ошибки при компиляции
        /// </summary>
        string GetErrorMessage { get; }

        /// <summary>
        /// Анализ кода
        /// </summary>
        /// <returns>Если была ошибка в написании куска кода, будет возвращенно false, иначе true</returns>
        bool AnalyzeCode();

    }
}
