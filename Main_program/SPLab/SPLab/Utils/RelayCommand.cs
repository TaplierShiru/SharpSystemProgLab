using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SPLab.Utils
{
    /// <summary>
    /// Реализация RelayCommand для вызова комманд из View и связке с ViewModel
    /// </summary>
    public class RelayCommand : ICommand
    {
        // То что должно быть выполненно
        private Action<object> execute;
        // Можно устанавливать условия при которых комманда будет не вызываться
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Иницилазция класса для вызова некоторого действия
        /// </summary>
        /// <param name="execute">То, что должно быть выполненно</param>
        /// <param name="canExecute">Условие при котором комманда должна сработать, может быть не заданно</param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Возвращает bool значение, может ли команда выполниться в данный момент или нет
        /// </summary>
        /// <param name="parameter">Параметры необходимые для проверки действия</param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        /// <summary>
        /// Выполнение команды
        /// </summary>
        /// <param name="parameter">Параметр команды</param>
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
