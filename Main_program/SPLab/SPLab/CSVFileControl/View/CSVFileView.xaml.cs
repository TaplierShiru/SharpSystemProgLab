using Microsoft.Win32;
using SPLab.LogPanelControl;
using SPLab.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SPLab.CSVFileControl
{
    /// <summary>
    /// Реализует View часть виджета CSVFile
    /// </summary>
    public partial class CSVFileView : UserControl
    {
        public CSVFileView()
        {
            InitializeComponent();
            DataContext = new CSVFileViewModel();
        }
    }
}
