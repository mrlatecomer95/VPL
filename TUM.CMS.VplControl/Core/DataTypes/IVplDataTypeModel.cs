using System;

namespace TUM.CMS.VplControl.Core.DataTypes
{
    public interface IVplDataTypeModel
    {
        string Description { get; set; }
        string Name { get; set; }
        Type Type { get; set; }
    }
}