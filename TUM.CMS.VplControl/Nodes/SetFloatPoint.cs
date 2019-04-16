using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TUM.CMS.VplControl.Core;
using TUM.CMS.VplControl.Utilities;

namespace TUM.CMS.VplControl.Nodes
{
    internal class SetFloatPoint: Node
    {
        private readonly ComboBox _cmbobox;
        private string _selectedPoint;
        public SetFloatPoint(Core.VplControl hostCanvas) : base(hostCanvas)
        {
            AddInputPortToNode("Object", typeof(object));
            _cmbobox = new ComboBox()
            {
                Width = 150,
                ItemsSource = SamplePoints.GetPoints().Select(x => x.Name).ToList(),
            };

            var textBlock = new TextBox()
            {
                TextWrapping = TextWrapping.Wrap,
                FontSize = 14,
                Padding = new Thickness(5),
            };

            AddControlToNode(_cmbobox);
            AddControlToNode(textBlock);
            _cmbobox.SelectionChanged += _cmbobox_SelectionChanged;

        }

        private void _cmbobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_cmbobox.SelectedItem == null) return;
            _selectedPoint = _cmbobox.SelectedItem.ToString();
        }

        public override void Calculate()
        {
        }


        public override Node Clone()
        {
            var node = new SetFloatPoint(HostCanvas)
            {
                Top = Top,
                Left = Left
            };

            return node;
        }
    }
}
