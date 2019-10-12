using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Models
{
    public class OrderProduct :BaseDTO
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
