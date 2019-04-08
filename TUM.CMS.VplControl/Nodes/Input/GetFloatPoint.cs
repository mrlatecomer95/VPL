using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Xaml;
using TUM.CMS.VplControl.Core;
using TUM.CMS.VplControl.Utilities;
namespace TUM.CMS.VplControl.Nodes.Input
{
    internal class GetFloatPoint :Node
    {
        private readonly ComboBox _cmbobox;
        //private readonly Dictionary<string, decimal> _pointList = new Dictionary<string, decimal>()
        //{
        //    {"Point1", Convert.ToDecimal(0.0 ) },
        //    {"Point2", Convert.ToDecimal(0.1 ) },
        //    {"Point3", Convert.ToDecimal(0.2 ) },
        //    {"Point4", Convert.ToDecimal(0.3 ) },
        //    {"Point5", Convert.ToDecimal(0.4 ) },

        //};
        public GetFloatPoint(Core.VplControl hostCanvas) : base(hostCanvas)
        {
            AddOutputPortToNode("Float Point Value", typeof(float));
             _cmbobox = new ComboBox()
            {
                 Width = 150,
                 ItemsSource = SamplePoints.GetPoints().Select(x=>x.Name).ToList(),
            };

            _cmbobox.SelectionChanged += _cmbobox_SelectionChanged;

            AddControlToNode(_cmbobox);
        }

        private void _cmbobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_cmbobox.SelectedItem == null) return;
            decimal output = Convert.ToDecimal(SamplePoints.GetPoint(_cmbobox.SelectedItem.ToString()).Value) ;
            OutputPorts[0].Data = output;
        }

        public override void Calculate()
        {
            //throw new System.NotImplementedException();
        }

        public override Node Clone()
        {
            var node = new GetFloatPoint(HostCanvas)
            {
                Top = Top,
                Left = Left
            };

            return node;
        }
    }
}
