using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Xml;
using TUM.CMS.VplControl.Core;
using TUM.CMS.VplControl.Utilities;
using Expression = NCalc.Expression;

namespace TUM.CMS.VplControl.Nodes.Logic
{
    internal class IfNode2 : Node
    {
        private Expression expression;
        public IfNode2(Core.VplControl hostCanvas)
            : base(hostCanvas)
        {
            //AddInputPortToNode("Condition", typeof (bool));
            //AddInputPortToNode("True value", typeof (object));
            //AddInputPortToNode("False value", typeof (object));

            //var label = new Label
            //{
            //    Content = "If",
            //    Width = 60,
            //    FontSize = 30,
            //    HorizontalContentAlignment = HorizontalAlignment.Center
            //};

            //AddControlToNode(label);

            //AddOutputPortToNode("Result", typeof (object));

            AddOutputPortToNode("True", typeof(object));
            AddOutputPortToNode("False", typeof(object));

            var label = new Label
            {
                Content = "IF",
                HorizontalAlignment = HorizontalAlignment.Center
            };
            AddControlToNode(label);

            var textbox = new RichTextBox() { MinWidth = 120, MaxWidth = 450, };
            textbox.TextChanged += Textbox_TextChanged;
            textbox.KeyUp += Textbox_KeyUp;

            AddControlToNode(textbox);

            MouseEnter += IfNode2_MouseEnter;
            MouseLeave += IfNode2_MouseLeave;


        }

        private void IfNode2_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Border.Focusable = true;
            Border.Focus();
            Border.Focusable = false;
        }

        private void IfNode2_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ControlElements[0].Focus();
        }

        private void Textbox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var stextBox = sender as RichTextBox;
            var textBox = new TextRange(stextBox.Document.ContentStart, stextBox.Document.ContentEnd);
            if (textBox != null)
            {
                if (textBox.Text != "")
                {
                    expression = new Expression(textBox.Text);

                    var paras = GetParametersInExpression(textBox.Text).Distinct().ToList();

                    if (paras.Any())
                    {
                        RemoveAllInputPortsFromNode(paras);

                        var filteredParas = paras.Where(parameter => InputPorts.All(p => p.Name != parameter)).ToList();

                        foreach (var parameter in filteredParas)
                            AddInputPortToNode(parameter, typeof(object));
                    }
                }
                else
                {
                    expression = null;
                    RemoveAllInputPortsFromNode();
                }
            }

            Calculate();
        }


        public List<string> GetParametersInExpression(string formula)
        {
            try
            {
                var expr = NCalc.Expression.Compile(formula, false);

                var visitor = new ParameterExtractionVisitor();
                expr.Accept(visitor);

                return visitor.Parameters;
            }
            catch (Exception ex)
            {
                return new List<string>();
            }
        }
        public override void Calculate()
        {
            //var data = InputPorts[0].Data;
            //if (data != null && (bool)data)
            //    OutputPorts[0].Data = InputPorts[1].Data;
            //else if (data != null)
            //    OutputPorts[0].Data = InputPorts[2].Data;

            if (expression != null)
            {
                foreach (var port in InputPorts)
                    expression.Parameters[port.Name] = port.Data;

                try
                {
                    //OutputPorts[0].Data = expression.Evaluate();
                    var data = expression.Evaluate();

                    if (data != null && (bool) data)
                    {
                        OutputPorts[1].Data = null;
                        OutputPorts[0].Data = data;
                    }
                    else if (data != null)
                    {
                        OutputPorts[0].Data = null;
                        OutputPorts[1].Data = data;
                    }
                }
                catch (Exception ex)
                {
                    OutputPorts[0].Data = null;
                    OutputPorts[1].Data = null;
                }
            }
            else
            {
                OutputPorts[0].Data = null;
                OutputPorts[1].Data = null;
            }
                


        }

        public override void SerializeNetwork(XmlWriter xmlWriter)
        {
            base.SerializeNetwork(xmlWriter);

            var textBox = ControlElements[0] as TextBox;
            if (textBox == null) return;

            xmlWriter.WriteStartAttribute("Formula");
            xmlWriter.WriteValue(textBox.Text);
            xmlWriter.WriteEndAttribute();
        }

        public override void DeserializeNetwork(XmlReader xmlReader)
        {
            base.DeserializeNetwork(xmlReader);

            var textBox = ControlElements[0] as TextBox;
            if (textBox == null) return;

            textBox.Text = xmlReader.GetAttribute("Formula");
        }



        public override Node Clone()
        {
            var node = new IfNode2(HostCanvas)
            {
                Top = Top,
                Left = Left
            };

            return node;
        }
    }
}