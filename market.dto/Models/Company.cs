using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Models
{
    public class Company : BaseDTO
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
