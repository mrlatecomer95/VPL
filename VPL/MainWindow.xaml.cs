using System.Collections;
using System.Windows;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.Native;
using DevExpress.Xpf.Docking;
using VPL.UI.Controls;
using VPL.UI.Model;

namespace VPL.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnNew.ItemClick += BtnNew_ItemClick;
            //this.KeyDown += VplControl.VplControl_KeyDown;
            //this.KeyUp += VplControl.VplControl_KeyUp;
            //VplControl.Drop += VplControl_Drop;
        }

        private void BtnNew_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {

            var Name = "";
            var Caption = "";
            SetDocumentName(out Name, out Caption);
            DocumentGroup.Add(new DocumentPanel()
            {
                   Name = Name,
                   Caption = Caption,
                   Content = new ucVplControl()
            });
        }

        private void SetDocumentName(out string Name,out string Caption)
        {
            if (DocumentGroup.Items.Count >= 0)
            {
                foreach (var item in DocumentGroup.Items)
                {
                    if (item.GetType() == typeof(DocumentPanel))
                    {
                        Name = $@"Document{DocumentGroup.Items.Count + 1}";
                        Caption = $@"Document {DocumentGroup.Items.Count + 1}";
                        return;
                    }
                } 
            }
            Name = "Document1";
            Caption = "Document 1";
        }

        //private void VplControl_Drop(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent(typeof(RecordDragDropData)))
        //    {
        //        object data = e.Data.GetData(typeof(RecordDragDropData));
        //        var draggedNode = ((RecordDragDropData)data).Records;
        //        var dataContext = ((ToolboxItem)((IList)draggedNode)[0]).Type;

        //        VplControl.CreateNode(dataContext, e.GetPosition(this).X,e.GetPosition(this).Y);
        //    }
        //}
    }
}
