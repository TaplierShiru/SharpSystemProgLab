using System;
using System.Collections.Generic;
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

namespace SPLab.LowMathControl
{
    /// <summary>
    /// Interaction logic for LowMathView.xaml
    /// </summary>
    public partial class LowMathView : UserControl
    {
        public LowMathView()
        {
            InitializeComponent();
            DataContext = new LowMathViewModel(new LowMathModel());
        }

    }
}
