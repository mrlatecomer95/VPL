using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DevExpress.Xpf.Core;
using VPL.UI.Model;

namespace VPL.UI.Controls
{
    /// <summary>
    /// Interaction logic for ucVplControl.xaml
    /// </summary>
    public partial class ucVplControl : UserControl
    {
        public ucVplControl()
        {
            InitializeComponent();
            this.KeyDown += VplControl.VplControl_KeyDown;
            this.KeyUp += VplControl.VplControl_KeyUp;
            VplControl.Drop += VplControl_Drop;

            btnZoomToFit.ItemClick += BtnZoomToFit_ItemClick;
            btnSave.ItemClick += BtnSave_ItemClick;
            btnGroup.ItemClick += BtnGroup_ItemClick;

        }

        private void BtnGroup_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            VplControl.GroupNodes();
        }

        private void BtnSave_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            VplControl.SaveFile();
        }

        private void BtnZoomToFit_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            VplControl.ZoomToFitNodes();
        }

        private void VplControl_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(RecordDragDropData)))
            {
                object data = e.Data.GetData(typeof(RecordDragDropData));
                var draggedNode = ((RecordDragDropData)data).Records;
                var dataContext = ((ToolboxItem)((IList)draggedNode)[0]).Type;
                VplControl.CreateNode(dataContext, e.GetPosition(this).X, e.GetPosition(this).Y);
            }
        }

        //private void VplControl_OnKeyDown(object sender, KeyEventArgs e)
        //{
        //    VplControl.VplControl_KeyDown(sender, e);
        //}

        //private void VplControl_OnKeyUp(object sender, KeyEventArgs e)
        //{
        //    VplControl.VplControl_KeyDown(sender,e);
        //}
    }
}
