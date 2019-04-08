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
using DevExpress.Xpf.Core;

namespace VPL.UI.View
{
    /// <summary>
    /// Interaction logic for ucToolbox.xaml
    /// </summary>
    public partial class ucToolbox : UserControl
    {
        public ucToolbox()
        {
            InitializeComponent();
        }


        private void DataViewBase_OnCompleteRecordDragDrop(object sender, CompleteRecordDragDropEventArgs e)
        {
            e.Handled = true;
        }
    }
}
