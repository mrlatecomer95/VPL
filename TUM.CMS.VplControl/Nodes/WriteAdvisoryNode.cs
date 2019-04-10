using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Xml;
using TUM.CMS.VplControl.Core;

namespace TUM.CMS.VplControl.Nodes
{
    internal class WriteAdvisoryNode : Node
    {
        public WriteAdvisoryNode(Core.VplControl hostCanvas) : base(hostCanvas)
        {
            AddControlToNode(new RichTextBox() {MinWidth = 100, MaxWidth = 400, Width = 150});
            AddInputPortToNode("Object",typeof(object));
        }
        public override void Calculate()
        {
            
        }
   
        public override Node Clone()
        {
            return new WriteAdvisoryNode(HostCanvas)
            {
                Top = Top,
                Left = Left
            };
        }
    }
}