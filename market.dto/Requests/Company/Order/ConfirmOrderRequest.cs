using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Requests.Company.Order
{
    public class ConfirmOrderRequest : BaseCompanyRequest
    {
        public int OrderID { get; set; }
    }
}
