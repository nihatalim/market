using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Models
{
    public class Property :BaseDTO
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public PropertyType PropertyType { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }

    public enum PropertyType
    {
        STRING = 0,
        INT = 1,
        DECIMAL = 2,
        JSON = 9
    }
}
