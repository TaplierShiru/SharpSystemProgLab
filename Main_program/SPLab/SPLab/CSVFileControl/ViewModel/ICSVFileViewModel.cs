using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SPLab.CSVFileControl
{
    /// <summary>
    /// Реализует логику CSVFile части приложения
    /// </summary>
    interface ICSVFileViewModel
    {
        /// <summary>
        /// Предоставляет/устанавливает текущий выбранный элемент в таблице
        /// </summary>
        FileInfo SelectedItem { get; set; }

        /// <summary>
        /// Возвращает коллекцию элементов, которые должны быть отображены в таблице
        /// </summary>
        ICollectionView FileInfo { get; }

        /// <summary>
        /// Команда для добавления нового элемента в таблицу
        /// </summary>
        ICommand AddCommand { get; }

        /// <summary>
        /// Команда для удаления выбранного элемента
        /// </summary>
        ICommand RemoveCommand { get; }

        /// <summary>
        /// Команда для загрузки уже существующего CSV файла
        /// </summary>
        ICommand LoadCommand { get; }

        /// <summary>
        /// Команда для сохранения текущий таблицы в CSV файл
        /// </summary>
        ICommand SaveCommand { get; }
    }
}
