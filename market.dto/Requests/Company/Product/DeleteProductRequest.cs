using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Requests.Company.Product
{
    public class DeleteProductRequest : BaseCompanyRequest
    {
        public int ProductID { get; set; }
    }
}
