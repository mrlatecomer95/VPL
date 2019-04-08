
using System.Windows;
using System.Windows.Controls;
using TUM.CMS.VplControl.Core;

namespace TUM.CMS.VplControl.Nodes.Logic
{
    internal class LessThan : Node
    {
        public LessThan(Core.VplControl hostCanvas) : base(hostCanvas)
        {
            AddInputPortToNode("True value", typeof(object));
            AddInputPortToNode("False value", typeof(object));

            var label = new Label
            {
                Content = "<",
                Width = 60,
                FontSize = 30,
                HorizontalContentAlignment = HorizontalAlignment.Center
            };

            AddControlToNode(label);

            AddOutputPortToNode("Result", typeof(object));
        }

        public override void Calculate()
        {
            OutputPorts[0].Data = double.Parse(InputPorts[0].Data.ToString()) <
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
