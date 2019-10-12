using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Requests.Company.Property
{
    public class DeletePropertyFromProductRequest
    {
        public int ProductID { get; set; }
        public int PropertyID { get; set; }
    }
}
