using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SPLab.LowMathControl
{
    interface ILowMathViewModel
    {
        string VarA { get; set; }
        string VarB { get; set; }
        string Res { get; set; }
        string ErrorMess { get; set; }
        /// <summary>
        /// Команда для добавления нового элемента в таблицу
        /// </summary>
        ICommand CalculateCommand { get; }

    }
}
