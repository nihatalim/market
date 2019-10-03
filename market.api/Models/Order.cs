using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Models
{
    public class Order : BaseEntity
    {
        public string OrderNumber { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        public decimal TotalTax { get; set;}
        public decimal TotalPrice { get; set; }
        public decimal TotalDiscount { get; set; }
        public OrderType Type { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }

    public enum OrderType
    {
        IN = 0,
        OUT = 1
    }
}
