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

namespace TUM.CMS.VplControl.NodeControls
{
    /// <summary>
    /// Interaction logic for ActionBlockProperty.xaml
    /// </summary>
    public partial class ActionBlockProperty : UserControl
    {

        private List<string> _listItems = new List<string>();
        public ActionBlockProperty()
        {
            InitializeComponent();
            LoadListItems();
        }

        public void LoadListItems()
        {
            _listItems.Add("Test");
            _listItems.Add("Test1");
            _listItems.Add("Test2");
            _listItems.Add("Test3");
            _listItems.Add("Test4");
            _listItems.Add("Test5");
            _listItems.Add("Test6");
            _listItems.Add("Test7");
            _listItems.Add("Test8");
            ListView.ItemsSource = _listItems;
        }

        private void btnMoveUp_OnClick(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            if (ListView.SelectedIndex <= 0) return;

            var selectedIndex = ListView.SelectedIndex;

            var item = _listItems[selectedIndex];

            var itemToIndex = ListView.SelectedIndex - 1;
            var itemto = _listItems[itemToIndex];

            _listItems[itemToIndex] = item;
            _listItems[selectedIndex] = itemto;
            ListView.ItemsSource = null;
            ListView.ItemsSource = _listItems;
            ListView.SelectedItem = ListView.Items[itemToIndex];
        }

        private void btnMoveDown_OnClick(object sender, RoutedEventArgs e)
        {
            if (ListView.SelectedIndex < 0 || ListView.SelectedIndex + 1 >= _listItems.Count) return;

            var selectedIndex = ListView.SelectedIndex;

            var item = _listItems[selectedIndex];

            var itemToIndex = ListView.SelectedIndex + 1;
            var itemto = _listItems[itemToIndex];

            _listItems[itemToIndex] = item;
            _listItems[selectedIndex] = itemto;
            ListView.ItemsSource = null;
            ListView.ItemsSource = _listItems;
            ListView.SelectedItem = ListView.Items[itemToIndex];
        }
    }
}
