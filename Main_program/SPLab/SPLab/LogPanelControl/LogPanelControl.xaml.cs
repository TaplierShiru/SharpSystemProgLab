using SPLab.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace SPLab.LogPanelControl
{
    /// <summary>
    /// Interaction logic for LogPanelControl.xaml
    /// </summary>
    public partial class LogPanelControl : UserControl
    {
        public LogPanelControl()
        {
            InitializeComponent();
            Mediator.Register("PrintLog", UpdateLogTextBox);
        }

        protected virtual void UpdateLogTextBox(object args)
        {
            Trace.WriteLine("Trigger event");
            this.LogRichTextBox.AppendText((string)args);
            this.LogRichTextBox.AppendText(Environment.NewLine);

        }
    }
}
