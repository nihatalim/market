using market.dto.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Requests.Company.Order
{
    public class UpdateOrderRequest
    {
        public OrderType Type { get; set; }
    }
}
