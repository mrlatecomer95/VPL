using System;
using System.CodeDom;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using TUM.CMS.VplControl.Core;
using TUM.CMS.VplControl.Core.DataTypes;
using TUM.CMS.VplControl.Utilities;

namespace TUM.CMS.VplControl.Nodes
{
    public class DataTypeConversion : Node
    {
        private ComboBox _comboBox;
        public DataTypeConversion(Core.VplControl hostCanvas)
            : base(hostCanvas)
        {
            AddInputPortToNode("Input1", typeof(object), true);
            AddOutputPortToNode("test", typeof(object));
            _comboBox = new ComboBox()
            {
                ItemsSource = VplDataType.GetVplDataType().Select(x => x.Name).ToList(),
                Width = 150

            };
            AddControlToNode(_comboBox);
        }


        public override void Calculate()
        {
            var comboBox = (ComboBox)ControlElements[1];
            if (_comboBox.SelectedItem == null) return;
            var vplType = VplDataType.GetVplDataType().FirstOrDefault(x => x.Name == comboBox.SelectedItem.ToString());
            var input = InputPorts[0];
            var output = Convert.ChangeType(input.Text, vplType.Type);
            OutputPorts[0].Data = output;
        }

        public override void SerializeNetwork(XmlWriter xmlWriter)
        {
            base.SerializeNetwork(xmlWriter);

            var textBox = ControlElements[0] as TextBox;
            if (textBox == null) return;

            xmlWriter.WriteStartAttribute("Text");
            xmlWriter.WriteValue(textBox.Text);
            xmlWriter.WriteEndAttribute();
        }

        public override void DeserializeNetwork(XmlReader xmlReader)
        {


        }

        public override Node Clone()
        {
            return new DataTypeConversion(HostCanvas)
            {
                Top = Top,
                Left = Left,

            };
        }
    }
}