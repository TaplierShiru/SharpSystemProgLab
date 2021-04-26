using SPLab.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLab.LogPanelControl.Utils
{
    /// <summary>
    /// Медиатор для соединения других виджетов с лог виджетом
    /// Основная функция - вывод сообщений, что присылают другие виджеты
    /// </summary>
    public static class LogPanelMediator
    {
        /// <summary>
        /// Вывод сообщения в лог окне
        /// </summary>
        /// <param name="mess">Сообщение</param>
        public static void PrintInLogPanel(string mess)
        {
            Mediator.NotifyColleagues("PrintLog", mess);
        }
    }
}
