using System.Collections.Generic;
using System.Linq;

namespace TUM.CMS.VplControl.Utilities
{
    public static class SamplePoints
    {

        private static readonly List<Points> _pointList = new List<Points>()
        {
            new Points() {Name = "APR-ACTION1.OVATION", Alias =  "Point1", Type = "decimal", Value = "10"},
            new Points() {Name = "Point2", Alias =  "Point2", Type = "decimal", Value = "0"},
            new Points() {Name = "Point3", Alias =  "Point3", Type = "decimal", Value = "30.2"},
            new Points() {Name = "Point4", Alias =  "Point4", Type = "decimal", Value = "40.19"},
            new Points() {Name = "Point5", Alias =  "Point5", Type = "decimal", Value = "10.50"},
            new Points() {Name = "Point6", Alias =  "Point6", Type = "decimal", Value = "10"},
            new Points() {Name = "Point7", Alias =  "Point7", Type = "decimal", Value = "40.02"},
            new Points() {Name = "Point8", Alias =  "Point8", Type = "decimal", Value = "30.30"},
            new Points() {Name = "Point9", Alias =  "Point9", Type = "decimal", Value = "10"},
            new Points() {Name = "APR-ACTION2.OVATION", Alias =  "APR-ACTION2.OVATION", Type = "decimal", Value = "0"},
        };
        public static List<Points> GetPoints()
        {
            return _pointList.ToList();
        }

        public static Points GetPoint(string Name)
        {
            return _pointList.FirstOrDefault(x => x.Name == Name);
        }

        public static void SetFloatPoint(string Name, decimal value)
        {

            var point = _pointList.FirstOrDefault(x => x.Name == Name);
            if (point != null)
            {
                point.Value = value.ToString();
            }
        }
    }


    public class Points
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
