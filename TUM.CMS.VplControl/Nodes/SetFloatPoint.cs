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
            AddInputPortToNode("Value",typeof(decimal));
            _cmbobox = new ComboBox()
            {
                Width = 150,
                ItemsSource = SamplePoints.GetPoints().Select(x => x.Name).ToList(),
            };


            var textBlock = new TextBlock
            {
                TextWrapping = TextWrapping.Wrap,
                FontSize = 14,
                Padding = new Thickness(5),
                IsHitTestVisible = false
            };

            var scrollViewer = new ScrollViewer
            {
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                MinWidth = 120,
                MinHeight = 20,
                MaxWidth = 200,
                MaxHeight = 400,
                CanContentScroll = true,
                Content = textBlock,
                // IsHitTestVisible = false
            };

            AddControlToNode(scrollViewer);
            _cmbobox.SelectionChanged += _cmbobox_SelectionChanged;

            AddControlToNode(_cmbobox);
        }

        private void _cmbobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_cmbobox.SelectedItem == null) return;
            decimal output = Convert.ToDecimal(SamplePoints.GetPoint(_cmbobox.SelectedItem.ToString()).Value);
            //OutputPorts[0].Data = output;
            _selectedPoint = _cmbobox.SelectedItem.ToString();
        }

        public override void Calculate()
        {
            //throw new System.NotImplementedException(); 
            var scrollViewer = ControlElements[0] as ScrollViewer;
            if (scrollViewer == null) return;

            var textBlock = scrollViewer.Content as TextBlock;
            if (textBlock == null) return;

            SamplePoints.SetFloatPoint(_selectedPoint,Convert.ToDecimal(InputPorts[0].Data.ToString()) );

            textBlock.Text = Utilities.Utilities.DataToString(InputPorts[0].Data);
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
