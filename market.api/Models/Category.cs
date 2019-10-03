using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
