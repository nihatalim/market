using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Requests.Company.Order
{
    public class AddProductToOrderRequest : BaseCompanyRequest
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Count { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal DiscountPrice { get; set; }
    }
}
