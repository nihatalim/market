using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Models
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
