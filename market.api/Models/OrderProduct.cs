using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Models
{
    public class OrderProduct : BaseEntity
    {
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxPrice { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
