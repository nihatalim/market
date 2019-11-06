using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Requests.Company.Client
{
    public class GetAllClientsRequest : BaseCompanyRequest
    {
        public int Size { get; set; }
        public int Page { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public string OrderType { get; set; }
    }
}
