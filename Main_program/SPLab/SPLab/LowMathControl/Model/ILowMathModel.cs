using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLab.LowMathControl
{
    /// <summary>
    /// Интерфейс для Model части LowMath виджета
    /// Который рассчитывает значение при помощи низкоуровневого языка
    /// </summary>
    interface ILowMathModel
    {
        /// <summary>
        /// Переменная А (первая)
        /// </summary>
        string VarA { get; set; }

        /// <summary>
        /// Переменная B (вторая)
        /// </summary>
        string VarB { get; set; }

        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        string ErrorMess { get; set; }

        /// <summary>
        /// Расчет функции при помощи вызова функции на низкоуровневом языке
        /// Результат - байтовая операция OR к переменной А и В
        /// </summary>
        uint? Calculate();
    }
}
