using System.Windows;
using TUM.CMS.VplControl.Core;

namespace TUM.CMS.VplControl.NodeControls
{
    /// <summary>
    /// Interaction logic for NodePropertyWindow.xaml
    /// </summary>
    public partial class NodePropertyWindow : Window
    {
        public NodePropertyWindow(Node NodeType)
        {
            InitializeComponent();

            //MainGrid.Children.Add(new ActionBlockProperty());
            MainGrid.Children.Add(new ExpressionControl());
        }
    }
}
