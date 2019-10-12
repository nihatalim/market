using market.dto.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Requests.Company.Property
{
    public class UpdatePropertyRequest
    {
        public int PropertyID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public PropertyType PropertyType { get; set; }
    }
}
