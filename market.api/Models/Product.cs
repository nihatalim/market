using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } 
        public string Barcode { get; set; }
        public decimal Price { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TotalPrice { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public ICollection<Property> Properties { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
