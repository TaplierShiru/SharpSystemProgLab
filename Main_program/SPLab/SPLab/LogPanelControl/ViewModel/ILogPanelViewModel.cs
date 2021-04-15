using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SPLab.LogPanelControl
{
    /// <summary>
    /// Интерфейс для ViewModel части виджета LogPanel
    /// </summary>
    interface ILogPanelViewModel
    {
        /// <summary>
        /// Свойство хранящие текст логга
        /// </summary>
        string LogText { get; set; }
    }
}
