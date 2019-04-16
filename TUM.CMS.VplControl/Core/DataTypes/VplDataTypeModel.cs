using System;

namespace TUM.CMS.VplControl.Core.DataTypes
{
    public class VplDataTypeModel : IVplDataTypeModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Type Type { get; set; }
    }
}
