using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Models
{
    public class Order : BaseDTO
    {
        public string OrderNumber { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        public decimal TotalTax { get; set; }
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
