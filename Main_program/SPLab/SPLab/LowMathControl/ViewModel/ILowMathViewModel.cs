using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SPLab.LowMathControl
{
    /// <summary>
    /// Интерфейс для ViewModel части LowMath виджета
    /// Который рассчитывает значение при помощи низкоуровневого языка
    /// </summary>
    interface ILowMathViewModel
    {
        /// <summary>
        /// Переменная А (первая)
        /// </summary>
        string VarA { get; set; }

        /// <summary>
        /// Переменная В (вторая)
        /// </summary>
        string VarB { get; set; }

        /// <summary>
        /// Результат операции функции на низкоуровневом языке
        /// </summary>
        string Res { get; set; }

        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        string ErrorMess { get; set; }

        /// <summary>
        /// Команда для добавления нового элемента в таблицу
        /// </summary>
        ICommand CalculateCommand { get; }

    }
}
