using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml;
using TUM.CMS.VplControl.Core;
using TUM.CMS.VplControl.NodeControls;

namespace TUM.CMS.VplControl.Nodes
{
    public class ActionBlock : Node
    {
        public ActionBlock(Core.VplControl hostCanvas) : base(hostCanvas)

        {
            AddInputPortToNode("Value1", typeof(object),true);
            AddOutputPortToNode("Value", typeof(object));

            var label = new Label
            {
                Content = "Action Block",
                FontSize = 12,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalAlignment= VerticalAlignment.Top
            };

            AddControlToNode(label);
        }

        public override void Calculate()
        {
            //OutputPorts[0].Data = double.Parse(InputPorts[0].Data.ToString())*
            //                      double.Parse(InputPorts[1].Data.ToString());
            foreach (var outport in OutputPorts)
            {
                
            }
        }

        public override void SerializeNetwork(XmlWriter xmlWriter)
        {
            base.SerializeNetwork(xmlWriter);

            // add your xml serialization methods here
        }

        public override void DeserializeNetwork(XmlReader xmlReader)
        {
            base.DeserializeNetwork(xmlReader);

            // add your xml deserialization methods here
        }

        public override Node Clone()
        {
            return new ActionBlock(HostCanvas)
            {
                Top = Top,
                Left = Left
            };
        }

        public override void Node_MouseDown(object sender, MouseButtonEventArgs e)
        {
            base.Node_MouseDown(sender, e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (e.ClickCount == 2)
                {
                    var frm = new NodePropertyWindow(this);
                    frm.Show();
                }
            }
        }
    }
}