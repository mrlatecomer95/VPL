using System.Windows;
using System.Windows.Controls;
using TUM.CMS.VplControl.Core;
using TUM.CMS.VplControl.Utilities;

namespace TUM.CMS.VplControl.Nodes
{
    internal class WriteAdvisory: Node
    {
        public WriteAdvisory(Core.VplControl hostCanvas) : base(hostCanvas)
        {
            AddInputPortToNode("Object", typeof(object));

            var textBlock = new TextBox()
            {
                TextWrapping = TextWrapping.Wrap,
                FontSize = 14,
                Padding = new Thickness(5),
            };
            AddControlToNode(textBlock);
        }

        public override void Calculate()
        {
            var textbox = (TextBox)ControlElements[1];
            SamplePoints.WriteAdvisory(textbox.Text);
        }

        public override Node Clone()
        {
            var node = new WriteAdvisory(HostCanvas)
            {
                Top = Top,
                Left = Left
            };

            return node;
        }
    }
}
