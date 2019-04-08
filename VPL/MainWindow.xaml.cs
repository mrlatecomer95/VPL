using System.Collections;
using System.Windows;
using DevExpress.Xpf.Core;
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
            this.KeyDown += VplControl.VplControl_KeyDown;
            this.KeyUp += VplControl.VplControl_KeyUp;
            VplControl.Drop += VplControl_Drop;
        }

        private void VplControl_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(RecordDragDropData)))
            {
                object data = e.Data.GetData(typeof(RecordDragDropData));
                var draggedNode = ((RecordDragDropData)data).Records;
                var dataContext = ((ToolboxItem)((IList)draggedNode)[0]).Type;

                VplControl.CreateNode(dataContext, e.GetPosition(this).X,e.GetPosition(this).Y);
            }
        }
    }
}
