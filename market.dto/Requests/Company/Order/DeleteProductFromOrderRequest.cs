using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Requests.Company.Order
{
    public class DeleteProductFromOrderRequest : BaseCompanyRequest
    {
        public int OrderID { get; set; }
        public int OrderProductID { get; set; }
    }
}
