
using System.Windows;
using System.Windows.Controls;
using TUM.CMS.VplControl.Core;

namespace TUM.CMS.VplControl.Nodes.Logic
{
    internal class GreaterThan: Node
    {
        public GreaterThan(Core.VplControl hostCanvas) : base(hostCanvas)
        {
            //AddInputPortToNode("Condition", typeof(bool));
            //AddInputPortToNode("True value", typeof(object));
            //AddInputPortToNode("False value", typeof(object));
            AddInputPortToNode("Value 1",typeof(object),true);
            AddInputPortToNode("Value 2",typeof(object),true);
            ;

            var label = new Label
            {
                Content = ">",
                Width = 60,
                FontSize = 30,
                HorizontalContentAlignment = HorizontalAlignment.Center
            };

            AddControlToNode(label);

            AddOutputPortToNode("Result", typeof(object));
        }

        public override void Calculate()
        {
            //var data = InputPorts[0].Data;
            //if (data != null && (bool)data)
            //    OutputPorts[0].Data = InputPorts[1].Data;
            //else if (data != null)
            //    OutputPorts[0].Data = InputPorts[2].Data;
            OutputPorts[0].Data = double.Parse(InputPorts[0].Data.ToString()) >
                                 double.Parse(InputPorts[1].Data.ToString());
        }

        public override Node Clone()
        {
            var node = new IfNode(HostCanvas)
            {
                Top = Top,
                Left = Left
            };

            return node;
        }
    }
}
