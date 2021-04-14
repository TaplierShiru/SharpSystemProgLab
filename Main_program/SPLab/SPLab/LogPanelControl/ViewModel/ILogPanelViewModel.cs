using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SPLab.LogPanelControl
{
    /// <summary>
    /// Отображает информацию о действиях пользователя в окне логгов
    /// </summary>
    interface ILogPanelViewModel
    {
        /// <summary>
        /// Свойство хранящие текст логга
        /// </summary>
        string LogText { get; set; }
    }
}
