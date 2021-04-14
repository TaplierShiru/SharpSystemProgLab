using Microsoft.Win32;
using SPLab.LogPanelControl;
using SPLab.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace SPLab.CSVFileControl
{
    /// <inheritdoc/>
    class CSVFileViewModel : INotifyPropertyChanged, ICSVFileViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private FileInfo _selectedItem;
        /// <inheritdoc/>
        public FileInfo SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                NotifyPropertyChanged("SelectedItem");
                if (!(this._selectedItem is null))
                {
                    Trace.WriteLine("Select: " + _selectedItem.FileName);
                }
            }
        }
        private CSVFileModel _file_controller;
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

        public CSVFileViewModel()
        {
            this._file_controller = new CSVFileModel();
            GenerateFilesTest();
        }
        
        private void AddNewFileInfo()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executable files (*.exe)|*.exe";
            if (openFileDialog.ShowDialog() == true)
            {
                Trace.WriteLine(openFileDialog.FileName);
                this._file_controller.Add(openFileDialog.FileName);
                this.NotifyFileInfoAndUpdateLogInfo("Add new item.");
            }
        }
        private void RemoveSelectedItem()
        {
            this._file_controller.Remove(this._selectedItem.Indx);
            this.NotifyFileInfoAndUpdateLogInfo("Remove selected item from table.");
        }

        private void LoadFileInfo()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                Trace.WriteLine(openFileDialog.FileName);
                this._file_controller.Load(openFileDialog.FileName);
                this.NotifyFileInfoAndUpdateLogInfo("Load current table from: " + openFileDialog.FileName);
            }
        }

        private void SaveFileInfo()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == true)
            {
                Trace.WriteLine(saveFileDialog.FileName);
                this._file_controller.Save(saveFileDialog.FileName);
                this.NotifyFileInfoAndUpdateLogInfo("Save current table to: " + saveFileDialog.FileName);
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void NotifyFileInfoAndUpdateLogInfo(string logStr)
        {
            Mediator.NotifyColleagues("PrintLog", logStr);
            NotifyPropertyChanged("FileInfo");
        }
        private void GenerateFilesTest()
        {
            this._file_controller.Add("Badyda", "v1", "20.20.20");
            this._file_controller.Add("Badyda", "v1", "20.2.5");
            this._file_controller.Add("Szdad2", "v1", "20.2.3");
            this._file_controller.Add("VVxZZZ", "v3", "20.20.1");
            this._file_controller.Add("Badyda", "v2", "20.20.2");
            this._file_controller.Add("ZZZZZZ", "v1", "20.20.2");
            NotifyPropertyChanged("FileInfo");
        }
    }
}
