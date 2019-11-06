using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Models
{
    public class Client : BaseDTO
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
