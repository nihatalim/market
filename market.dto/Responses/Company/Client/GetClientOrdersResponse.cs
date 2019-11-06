using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Responses.Company.Client
{
    public class GetClientOrdersResponse : BaseResponse
    {
        public int Size { get; set; }
        public int Page { get; set; }
        public int SizeOfItems { get; set; }
        public int PageQuantity { get; set; }
        public ICollection<Models.Order> Orders { get; set; }
    }
}
