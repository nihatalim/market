using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Models
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public int UserID { get; set; }
        public User User { get; set;}
        public ICollection<Product> Products { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
