using market.dto.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Requests.Company.Order
{
    public class CreateOrderRequest
    {
        public OrderType Type { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
