using market.dto.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Requests.Company.Order
{
    public class CreateOrderRequest : BaseCompanyRequest
    {
        public OrderType Type { get; set; }
        public int? ClientID { get; set; }
        public decimal DiscountRate { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
