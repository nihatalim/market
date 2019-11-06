using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Models
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
