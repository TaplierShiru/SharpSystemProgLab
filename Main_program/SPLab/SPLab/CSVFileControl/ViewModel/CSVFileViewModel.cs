using Microsoft.Win32;
using SPLab.LogPanelControl;
using SPLab.LogPanelControl.Utils;
using SPLab.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace SPLab.CSVFileControl
{
    /// <summary>
    /// Класс реализующий логику ViewModel части CSVFile виджета
    /// </summary>
    class CSVFileViewModel : INotifyPropertyChanged, ICSVFileViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _is_table_update = false;
        private ICSVFileModel _file_controller;

        private FileInfo _selectedItem;
        /// <inheritdoc/>
        public FileInfo SelectedItem
        {
            get { return this._selectedItem; }
            set
            {
                // Update previous selected item
                if (!(this._selectedItem is null) && !this._is_table_update)
                {
                    try
                    {
                        if (this._file_controller.UpdateValues(this._selectedItem.Indx, this._selectedItem))
                        {
                            LogPanelMediator.PrintInLogPanel("Запись в таблице была изменена");
                        }
                    } catch (FormatException)
                    {
                        MessageBox.Show("Ошибка ввода даты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        this._file_controller.RestoreValues(this._selectedItem.Indx, this._selectedItem);
                    }
                }
                this._selectedItem = value;
                NotifyPropertyChanged("SelectedItem");

                if (!(this._selectedItem is null))
                {
                    this._is_table_update = false;
                }
            }
        }

        /// <inheritdoc/>
        public ICollectionView FileInfo
        {
            get { return CollectionViewSource.GetDefaultView(this._file_controller.GetList); }
        }

        private ICommand _addCommand;
        /// <inheritdoc/>
        public ICommand AddCommand
        {
            get
            {
                if (this._addCommand == null)
                {
                    this._addCommand = new RelayCommand(
                        param => this.AddNewFileInfo()
                    );
                }
                return this._addCommand;
            }
        }

        private ICommand _removeCommand;
        /// <inheritdoc/>
        public ICommand RemoveCommand
        {
            get
            {
                if (this._removeCommand == null)
                {
                    this._removeCommand = new RelayCommand(
                        param => this.RemoveSelectedItem()
                    );
                }
                return this._removeCommand;
            }
        }

        private ICommand _loadCommand;
        /// <inheritdoc/>
        public ICommand LoadCommand
        {
            get
            {
                if (this._loadCommand == null)
                {
                    this._loadCommand = new RelayCommand(
                        param => this.LoadFileInfo()
                    );
                }
                return this._loadCommand;
            }
        }

        private ICommand _saveCommand;
        /// <inheritdoc/>
        public ICommand SaveCommand
        {
            get
            {
                if (this._saveCommand == null)
                {
                    this._saveCommand = new RelayCommand(
                        param => this.SaveFileInfo()
                    );
                }
                return this._saveCommand;
            }
        }

        /// <summary>
        /// Инициализация ViewModel виджета CSVFile
        /// </summary>
        /// <param name="csvFileModel">Класс реализующий логику виджета</param>
        public CSVFileViewModel(ICSVFileModel csvFileModel)
        {
            this._file_controller = csvFileModel;
        }
        
        /// <summary>
        /// Добавление новой информации об файле
        /// </summary>
        private void AddNewFileInfo()
        {
            this._is_table_update = true;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executable files (*.exe)|*.exe";
            if (openFileDialog.ShowDialog() == true)
            {
                this._file_controller.Add(openFileDialog.FileName);
                this.NotifyFileInfoAndUpdateLogInfo("Новая запись была добавлена");
            }
        }

        /// <summary>
        /// Удаление выбранного элемента
        /// </summary>
        private void RemoveSelectedItem()
        {
            this._is_table_update = true;
            this._file_controller.Remove(this._selectedItem.Indx);
            this.NotifyFileInfoAndUpdateLogInfo("Выбранная запись была удалена");
        }

        /// <summary>
        /// Загрузка csv файла
        /// </summary>
        private void LoadFileInfo()
        {
            this._is_table_update = true;
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                this._file_controller.Load(openFileDialog.FileName);
                this.NotifyFileInfoAndUpdateLogInfo("Загрузка csv файла по пути: " + openFileDialog.FileName);
            }
        }


        /// <summary>
        /// Сохранение текущих данных в csv файл
        /// </summary>
        private void SaveFileInfo()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == true)
            {
                this._file_controller.Save(saveFileDialog.FileName);
                this.NotifyFileInfoAndUpdateLogInfo("Сохранение csv файла по пути: " + saveFileDialog.FileName);
            }
        }

        /// <summary>
        /// Вызов события - изменилось поле
        /// </summary>
        /// <param name="propertyName">Имя поля что было измененно</param>
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Обновление ячеек таблицы и вывод информации в логгер
        /// </summary>
        /// <param name="logStr">Информация которую следует вывести в лог</param>
        private void NotifyFileInfoAndUpdateLogInfo(string logStr)
        {
            LogPanelMediator.PrintInLogPanel(logStr);
            NotifyPropertyChanged("FileInfo");
        }

    }
}
