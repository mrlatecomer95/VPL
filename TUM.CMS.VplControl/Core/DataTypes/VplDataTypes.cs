using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUM.CMS.VplControl.Core.DataTypes
{
    
    public static class VplDataType
    {

        public static List<IVplDataTypeModel> GetVplDataType()
        {
            var types = new List<IVplDataTypeModel>
            {
                new VplDataTypeModel() {Name = "Boolean", Type = typeof(bool)},
                new VplDataTypeModel() {Name = "Float", Type = typeof(double)},
                new VplDataTypeModel() {Name = "Any", Type = typeof(object)},
                new VplDataTypeModel() {Name = "String", Type = typeof(string)},
                new VplDataTypeModel() {Name = "Int", Type = typeof(int)},
                new VplDataTypeModel() {Name = "Byte", Type = typeof(byte)},
                new VplDataTypeModel() {Name = "UInt16", Type = typeof(ushort)},
                new VplDataTypeModel() {Name = "UInt32", Type = typeof(uint)},
                new VplDataTypeModel() {Name = "Single", Type = typeof(float)},
                new VplDataTypeModel() {Name = "Int8", Type = typeof(sbyte)},
                new VplDataTypeModel() {Name = "Int16", Type = typeof(short)},
                new VplDataTypeModel() {Name = "DateTime", Type = typeof(DateTime)},
                new VplDataTypeModel() {Name = "UInt64", Type = typeof(ulong)},
                new VplDataTypeModel() {Name = "Int64", Type = typeof(long)},
                new VplDataTypeModel() {Name = "Decimal", Type = typeof(decimal)}
            };
            return types;
        }
    }
    
    
    
}
