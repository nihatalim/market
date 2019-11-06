using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Models
{
    public class Property : BaseEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public PropertyType Type { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
    }

    public enum PropertyType
    {
        STRING = 0,
        INT = 1,
        DECIMAL = 2,
        JSON = 9
    }
}
