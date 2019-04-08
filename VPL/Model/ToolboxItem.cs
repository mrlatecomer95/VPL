using System;
using System.Windows.Media;

namespace VPL.UI.Model
{
    public class ToolboxItem
    {
        public string Name{ get; set; }
        public ImageSource Image { get; set; }

        public Type Type { get; set; }

    }
}
